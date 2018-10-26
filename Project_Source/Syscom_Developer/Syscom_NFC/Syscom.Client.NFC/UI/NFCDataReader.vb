Imports System.ServiceModel
Imports Syscom.Comm.BASE
Imports Syscom.Comm.EXP
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
Imports Syscom.Client.CMM


Public Class NFCDataReader
    Inherits Syscom.Client.UCL.BaseFormUI

    '更新版本及時通知(ExternalFunction)
    Private globalNotifyDeploy As String = "deploy"

    Private pkTable As Hashtable
    Private pkHashSet As HashSet(Of String)
    Private midFullData As DataTable
    Private deployHashSet As HashSet(Of String)

    '加入接取訊息傳遞的Event
    Dim WithEvents eventManager As EventManager = eventManager.getInstance
    Dim pDS As New DataSet
    '接取訊息傳遞的Event
    Public Sub DisplayStatusBar() Handles eventManager.NFCForceRefresh
        nfcReload()
    End Sub

    Private Sub initialUI()
        Try
            Me.Font = AppConfigUtil.ControlFont
            ReloadTimer.Interval = 10 * 60 * 1000
            ReloadTimer.Start()

            pkHashSet = New HashSet(Of String)
            deployHashSet = New HashSet(Of String)
            pkTable = New Hashtable
            midFullData = New DataTable("NFC_Notify_Msg")
            midFullData.Columns.Add("MID")
            midFullData.Columns.Add("SendDate")
            midFullData.Columns.Add("Type")
            midFullData.Columns.Add("Start_Time")
            midFullData.Columns.Add("End_Time")
            midFullData.Columns.Add("Status")
            midFullData.Columns.Add("Subject")
            midFullData.Columns.Add("MsgBody")
            midFullData.Columns.Add("ReplyMsg")
            midFullData.Columns.Add("ExternalFuction")
            midFullData.Columns.Add("Recipient")
            midFullData.Columns.Add("Create_User")
            midFullData.Columns.Add("Create_Time")
            midFullData.Columns.Add("Modified_User")
            midFullData.Columns.Add("Modified_Time")
            Dim pkColArrayFull(2) As DataColumn
            pkColArrayFull(0) = midFullData.Columns("MID")
            pkColArrayFull(1) = midFullData.Columns("SendDate")
            pkColArrayFull(2) = midFullData.Columns("Recipient")
            midFullData.PrimaryKey = pkColArrayFull
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Sub

    Private Sub NFCTable_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            initialUI()
            'Dim client As Servicefactory.NfcServiceReference.NfcServiceClient = New Servicefactory.NfcServiceReference.NfcServiceClient()
            Dim client As Servicefactory.NfcServiceManager = Servicefactory.NfcServiceManager.getInstance
            pDS = client.getNfcPhrase("A")
            nfcReload24()
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    Public Delegate Sub reload()

    Public msgHandler As New reload(AddressOf nfcReload)

    Public Sub nfcReload()
        Try
            Dim data As DataSet = Servicefactory.NfcServiceManager.getInstance.readUIMessage(AppContext.userProfile.userId)
            displayDataGrid(data)
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Sub

    Public Sub nfcReload24()
        Try
            Dim data As DataSet = Servicefactory.NfcServiceManager.getInstance.readUIMessage24Hr(AppContext.userProfile.userId)
            'Dim pDS As DataSet = Servicefactory.NfcServiceManager.getInstance.getNfcPhrase("A") '開頭是'A' 代表訊息片語
            displayDataGrid(data, True)
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB300", ex, New String() {"查詢過期訊息失敗"})
        End Try
    End Sub

    Private Sub displayDataGrid(ByVal data As DataSet, Optional ByVal hr24 As Boolean = False)
        SyncLock Me

            Try

                If data IsNot Nothing AndAlso data.Tables.Count > 0 AndAlso data.Tables(0).Rows.Count > 0 Then
                    'MessageHandling.showInfo("開始處理" + (IIf(hr24, "過期", "")) + "訊息")
                    MessageHandling.ShowInfoMsg("CMMCMMB300", New String() {"開始處理" + (IIf(hr24, "過期", "")) + "訊息"})
                    Dim DisplayMsg As Boolean = False   '是否要啟動NotifyWindow
                    Dim msgData As List(Of String) = New List(Of String)
                    Dim subject As String = ""
                    For Each row As DataRow In data.Tables(0).Rows
                        subject = row.Item("Subject").ToString
                        Dim pkeys As String = row.Item("MID") + "^" + DateUtil.TransDateToROC(CDate(row.Item("SendDate"))) + "^" + (row.Item("Create_User")).ToString.Trim
                        If Not pkHashSet.Contains(pkeys) Then

                            '複製全部
                            Dim fullDataRow = midFullData.NewRow
                            For Each col As DataColumn In midFullData.Columns
                                fullDataRow(col.ColumnName) = row(col.ColumnName)
                            Next
                            midFullData.Rows.Add(fullDataRow)

                            '複製要顯示的部分               
                            Dim msgType = ""
                            Dim _type = ""
                            Dim groupType As String = IIf(IsDBNull(row.Item("Group_Type")), "P", row.Item("Group_Type"))
                            _type = row.Item("Type")
                            If groupType.ToUpper.Equals("P") Then
                                msgType = "個人"

                                If (StringUtil.nvl(row.Item("ExternalFuction")).Equals(globalNotifyDeploy) AndAlso _
                                   (Not deployHashSet.Contains(StringUtil.nvl(row.Item("MID"))))) Then
                                    deployHashSet.Add(StringUtil.nvl(row.Item("MID")))
                                    msgData.Add(StringUtil.nvl(row.Item("Subject")))
                                    msgData.Add(StringUtil.nvl(row.Item("MsgBody")))
                                    DisplayMsg = True


                                    'Dim dg As New DisplayMsgDialog(row)
                                    'dg.ShowDialog()

                                End If

                            ElseIf groupType.ToUpper.Equals("D") Then
                                msgType = "科室"
                                If (StringUtil.nvl(row.Item("ExternalFuction")).ToUpper.Equals(globalNotifyDeploy.ToUpper) AndAlso _
                                   (Not deployHashSet.Contains(StringUtil.nvl(row.Item("MID"))))) Then
                                    deployHashSet.Add(StringUtil.nvl(row.Item("MID")))
                                    msgData.Add(StringUtil.nvl(row.Item("Subject")))
                                    msgData.Add(StringUtil.nvl(row.Item("MsgBody")))
                                    DisplayMsg = True
                                End If
                            ElseIf groupType.ToUpper.Equals("C") Then
                                msgType = "全院"
                                '判斷是否要啟動notifywindow show message
                                If ((Not hr24) AndAlso StringUtil.nvl(row.Item("ExternalFuction")).Equals(globalNotifyDeploy) AndAlso _
                                   (Not deployHashSet.Contains(StringUtil.nvl(row.Item("MID"))))) Then
                                    deployHashSet.Add(StringUtil.nvl(row.Item("MID")))
                                    msgData.Add(StringUtil.nvl(row.Item("Subject")))
                                    msgData.Add(StringUtil.nvl(row.Item("MsgBody")))
                                    DisplayMsg = True
                                End If
                            ElseIf groupType.ToUpper.Equals("G") Then
                                msgType = "群組"
                                '判斷是否要啟動notifywindow show message
                                If ((Not hr24) AndAlso StringUtil.nvl(row.Item("ExternalFuction")).Equals(globalNotifyDeploy) AndAlso _
                                   (Not deployHashSet.Contains(StringUtil.nvl(row.Item("MID"))))) Then
                                    deployHashSet.Add(StringUtil.nvl(row.Item("MID")))
                                    msgData.Add(StringUtil.nvl(row.Item("Subject")))
                                    msgData.Add(StringUtil.nvl(row.Item("MsgBody")))
                                    DisplayMsg = True
                                End If
                            Else
                                msgType = "個人"
                            End If
                            Dim _time As String = Format(row.Item("SendDate"), "HH:mm")
                            Dim currentRowIndex = NFCDGV.Rows.Add(New Object() {msgType, convertType(_type), row.Item("Subject"), row.Item("MsgBody"), row.Item("MID"), DateUtil.TransDateToROC(CDate(row.Item("SendDate"))) & " " & _time, (row.Item("sendUser")).ToString.Trim})
                            pkHashSet.Add(pkeys)
                            pkTable.Add(currentRowIndex, row)
                            If hr24 Then
                                NFCDGV.Rows(currentRowIndex).DefaultCellStyle.BackColor = Color.LightSteelBlue
                            End If
                            If subject = "危險值通報" Then
                                NFCDGV.Rows(currentRowIndex).DefaultCellStyle.BackColor = Color.Red
                            End If
                            'If subject = "會診通知" Then
                            '    NFCDGV.Rows(currentRowIndex).DefaultCellStyle.BackColor = Color.LightCyan
                            'End If
                        End If
                    Next
                    NFCDGV.Refresh()
                    'MessageHandling.showInfo("處理" + (IIf(hr24, "過期", "")) + "訊息完成")


                    ' + NFC Window Proccess
                    'If (DisplayMsg) Then
                    '    DisplayNotifyMsg(msgData)
                    'End If

                    MessageHandling.ShowInfoMsg("CMMCMMB300", New String() {"處理" + (IIf(hr24, "過期", "")) + "訊息完成"})
                End If
            Catch ex As Exception
                'MessageHandling.showInfo("處理" + (IIf(hr24, "過期", "")) + "訊息失敗")
                MessageHandling.ShowInfoMsg("CMMCMMB300", New String() {"處理" + (IIf(hr24, "過期", "")) + "訊息失敗"})
            End Try
        End SyncLock
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            clearMsg()
            nfcReload24()
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            nfcReload24()
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    Private Sub ReloadTimer_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReloadTimer.Tick
        Try
            nfcReload()
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim Box As MsgBoxResult = MsgBox("個人訊息清除後，將不再出現(可使用『讀取過期訊息』再次讀取)，是否繼續？", MsgBoxStyle.YesNo)

        If Box = MsgBoxResult.Yes Then
            Try
                clearMsg()
                MessageHandling.ShowInfoMsg("CMMCMMB300", New String() {"已清除訊息視窗"})
            Catch ex As Exception
                ClientExceptionHandler.ProccessException(ex)
            End Try
        End If
    End Sub

    Private Sub NFCDGV_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles NFCDGV.CellClick

        Try
            If e.RowIndex > -1 And e.ColumnIndex > -1 Then

                Dim dg As New DisplayMsgDialog(pkTable.Item(e.RowIndex), pDS)
                dg.ShowDialog()
                clearMsg()
                nfcReload24()
            End If
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    ''' <summary>
    ''' 啟動NotifyWindow顯示訊息
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DisplayNotifyMsg(ByRef msgData As List(Of String))
        Try
            For i As Integer = 0 To msgData.Count - 1 Step 2
                Dim nw As NotifyWindows = New NotifyWindows(msgData(i), msgData(i + 1))
                nw.SetDimensions(250, 160)
                nw.WaitTime = 1800000
                nw.Font = New System.Drawing.Font("標楷體", 12.0F)

                If HospConfigUtil.HospConfig = HospConfigUtil.hospConfigList.Tw_Tnhosp Then
                    '設定提示顏色
                    nw.BackColor = Color.Yellow

                End If

                nw.Notify()
            Next
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Sub

    Function convertType(ByVal _type As String) As String
        Try
            Select Case _type
                Case "W"
                    Return "浮動視窗"
                Case "M"
                    Return "電子郵件"
                Case "S"
                    Return "簡訊"
                Case "G"
                    Return "群組"
                Case Else
                    Return ""
            End Select
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    Sub clearMsg()
        Try
            NFCDGV.Rows.Clear()
            pkHashSet.Clear()
            pkTable.Clear()
            midFullData.Rows.Clear()
            NFCDGV.Refresh()
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

End Class
