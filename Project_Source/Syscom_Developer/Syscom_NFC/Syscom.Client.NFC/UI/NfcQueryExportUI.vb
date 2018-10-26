Imports Syscom.Client.Servicefactory
Imports Syscom.Client.CMM
Imports Syscom.Comm.Utility
Imports Syscom.Comm.TableFactory
Imports Syscom.Client.UCL
Imports Microsoft.Office.Interop

Public Class NfcQueryExportUI



#Region "Global Param"
    Dim nfcManager As NfcServiceManager = NfcServiceManager.getInstance
    Private currentUserId As String = AppContext.userProfile.userId
    Dim initDS As DataSet
    Dim dgvDS As DataSet
    Dim strSortAble As String = "4,7"


#End Region

    Sub New()

        ' 此為設計工具所需的呼叫。
        InitializeComponent()

        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。

    End Sub


    Private Sub NfcQueryExportUI_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown

        initDS = nfcManager.initialNfcQueryExportUI
        Dim comboSource As New Dictionary(Of String, String)()
        comboSource.Add("", "全部")

        For i As Integer = 0 To initDS.Tables(0).Rows.Count - 1

            'cbo_Task.Items.Add(initDS.Tables(0).Rows(i).Item("fun_function_no").ToString.Trim & "-" & initDS.Tables(0).Rows(i).Item("fun_function_name").ToString.Trim)
            comboSource.Add(initDS.Tables(0).Rows(i).Item("fun_function_no").ToString.Trim, initDS.Tables(0).Rows(i).Item("fun_function_name").ToString.Trim)
        Next
        cbo_Task.DataSource = New BindingSource(comboSource, Nothing)
        cbo_Task.DisplayMember = "Value"
        cbo_Task.ValueMember = "Key"




        cbo_Level.Items.Add("全部")
        cbo_Level.Items.Add("資訊") '-INFO
        cbo_Level.Items.Add("警示") '-WARN
        cbo_Level.Items.Add("錯誤") '-ERROR

        cbo_Status.Items.Add("全部")
        cbo_Status.Items.Add("已處理") '"Y"
        cbo_Status.Items.Add("未處理") '""
        cbo_Status.Items.Add("已確認") '"O"
        cbo_Status.Items.Add("未確認") '"X"

        cbo_Recipient.Items.Add("全院")
        cbo_Recipient.Items.Add("科室")
        cbo_Recipient.Items.Add("個人")


        cbo_Level.SelectedIndex = 0
        cbo_Status.SelectedIndex = 0
        cbo_Recipient.SelectedIndex = 0
        cbo_Task.SelectedIndex = 0

        dtp_StartDate.SetValue(Now)
        dtp_EndDate.SetValue(Now)

    End Sub


    Private Sub btn_Query_Click(sender As Object, e As EventArgs) Handles btn_Query.Click

        lbl_totalCount.Text = "總計：0 筆"

        CleanBackColor()

        If (Not CheckFields()) Then
            'Error

        End If

        Dim key As String = DirectCast(cbo_Task.SelectedItem, KeyValuePair(Of String, String)).Key
        Dim value As String = DirectCast(cbo_Task.SelectedItem, KeyValuePair(Of String, String)).Value
        Dim fun_function_no As String = key

        Dim Type As String = ""

        Dim Level As String = ""

        Dim Status As String = ""

        Dim Recipient As String = ""

        Dim SendUser As String = ""

        If chk_Window.Checked Then
            Type += "W"
        End If

        If chk_Mail.Checked Then
            Type += "M"
        End If

        If chk_SMS.Checked Then
            Type += "S"
        End If


        If cbo_Level.SelectedIndex = 0 Then
            Level = ""
        ElseIf cbo_Level.SelectedIndex = 1 Then
            Level = "1"
        ElseIf cbo_Level.SelectedIndex = 2 Then
            Level = "2"
        ElseIf cbo_Level.SelectedIndex = 3 Then
            Level = "3"
        End If

        If cbo_Status.SelectedIndex = 0 Then
            Status = ""
        ElseIf cbo_Status.SelectedIndex = 1 Then
            Status = "Y"
        ElseIf cbo_Status.SelectedIndex = 2 Then
            Status = "N"
        ElseIf cbo_Status.SelectedIndex = 3 Then
            Status = "O"
        ElseIf cbo_Status.SelectedIndex = 4 Then
            Status = "X"
        End If

        If cbo_Recipient.SelectedIndex = 0 Then
            Recipient = ""
        ElseIf cbo_Recipient.SelectedIndex = 1 Then

            If tcq_Department.getCode = "" Then
                MessageHandling.ShowWarnMsg("CMMCMMB300", New String() {"請輸入科室代碼"})
                Exit Sub
            End If

            Recipient = "@@@" & tcq_Department.getCode()
        ElseIf cbo_Recipient.SelectedIndex = 2 Then

            If tcq_Employee.getCode = "" Then
                MessageHandling.ShowWarnMsg("CMMCMMB300", New String() {"請輸入員工編號"})
                Exit Sub
            End If

            Recipient = tcq_Employee.getCode()

        End If

        If tcq_Send_user.getCode() <> "" Then
            SendUser = tcq_Send_user.getCode()
        End If



        Dim queryDS As DataSet = nfcManager.QueryNFCNotifyMsgByCond(dtp_StartDate.GetUsDateStr + " 00:00", dtp_EndDate.GetUsDateStr + " 23:59", fun_function_no, Type, Level, Status, Recipient, SendUser)
        dgvDS = New DataSet

        dgvDS.Tables.Add()
        dgvDS.Tables(0).Columns.Add("SendDate")
        dgvDS.Tables(0).Columns.Add("Fun_Function_No")
        dgvDS.Tables(0).Columns.Add("Level")
        dgvDS.Tables(0).Columns.Add("Type")
        dgvDS.Tables(0).Columns.Add("Create_User")
        dgvDS.Tables(0).Columns.Add("Recipient")
        dgvDS.Tables(0).Columns.Add("Subject")
        dgvDS.Tables(0).Columns.Add("MsgBody")
        dgvDS.Tables(0).Columns.Add("Status")

        If queryDS IsNot Nothing Then
            lbl_totalCount.Text = "總計：" & queryDS.Tables(0).Rows.Count & " 筆"
            For i As Integer = 0 To queryDS.Tables(0).Rows.Count - 1

                dgvDS.Tables(0).Rows.Add()

                dgvDS.Tables(0).Rows(dgvDS.Tables(0).Rows.Count - 1).Item("SendDate") = DateUtil.TransDateToROC(CDate(queryDS.Tables(0).Rows(i).Item("SendDate"))) & " " & CDate(queryDS.Tables(0).Rows(i).Item("SendDate")).ToString("HH:mm")

                If initDS.Tables(0).Select("Fun_Function_No='" & queryDS.Tables(0).Rows(i).Item("Fun_Function_No") & "'").Count > 0 Then
                    dgvDS.Tables(0).Rows(dgvDS.Tables(0).Rows.Count - 1).Item("Fun_Function_No") = initDS.Tables(0).Select("Fun_Function_No='" & queryDS.Tables(0).Rows(i).Item("Fun_Function_No") & "'")(0).Item("fun_function_name").ToString.Trim
                    'Else
                    '    If queryDS.Tables(0).Rows(i).Item("Create_User").ToString.Trim.ToLower = "system" Then
                    '        dgvDS.Tables(0).Rows(dgvDS.Tables(0).Rows.Count - 1).Item("Fun_Function_No") = "Batch"
                    '    End If

                End If

                If queryDS.Tables(0).Rows(i).Item("Level").ToString.Trim = "" Then
                    dgvDS.Tables(0).Rows(dgvDS.Tables(0).Rows.Count - 1).Item("Level") = "資訊-INFO"
                ElseIf queryDS.Tables(0).Rows(i).Item("Level").ToString.Trim = "1" Then
                    dgvDS.Tables(0).Rows(dgvDS.Tables(0).Rows.Count - 1).Item("Level") = "資訊-INFO"
                ElseIf queryDS.Tables(0).Rows(i).Item("Level").ToString.Trim = "2" Then
                    dgvDS.Tables(0).Rows(dgvDS.Tables(0).Rows.Count - 1).Item("Level") = "警示-WARN"
                ElseIf queryDS.Tables(0).Rows(i).Item("Level").ToString.Trim = "3" Then
                    dgvDS.Tables(0).Rows(dgvDS.Tables(0).Rows.Count - 1).Item("Level") = "錯誤-ERROR"
                End If

                If queryDS.Tables(0).Rows(i).Item("Type").ToString.Trim = "W" Then
                    dgvDS.Tables(0).Rows(dgvDS.Tables(0).Rows.Count - 1).Item("Type") = "浮動視窗"
                ElseIf queryDS.Tables(0).Rows(i).Item("Type").ToString.Trim = "S" Then
                    dgvDS.Tables(0).Rows(dgvDS.Tables(0).Rows.Count - 1).Item("Type") = "簡訊"
                ElseIf queryDS.Tables(0).Rows(i).Item("Type").ToString.Trim = "M" Then
                    dgvDS.Tables(0).Rows(dgvDS.Tables(0).Rows.Count - 1).Item("Type") = "電子郵件"
                End If


                dgvDS.Tables(0).Rows(dgvDS.Tables(0).Rows.Count - 1).Item("Create_User") = IIf(queryDS.Tables(0).Rows(i).Item("sendUser").ToString.Trim <> "", queryDS.Tables(0).Rows(i).Item("sendUser").ToString.Trim, "系統管理員")
                dgvDS.Tables(0).Rows(dgvDS.Tables(0).Rows.Count - 1).Item("Recipient") = queryDS.Tables(0).Rows(i).Item("Employee_Name").ToString.Trim
                dgvDS.Tables(0).Rows(dgvDS.Tables(0).Rows.Count - 1).Item("Subject") = queryDS.Tables(0).Rows(i).Item("Subject").ToString.Trim
                dgvDS.Tables(0).Rows(dgvDS.Tables(0).Rows.Count - 1).Item("MsgBody") = queryDS.Tables(0).Rows(i).Item("MsgBody").ToString.Trim

                Dim tmpStatus As String = queryDS.Tables(0).Rows(i).Item("Status").ToString.Trim
                Dim tmpSpecFlag As String = queryDS.Tables(0).Rows(i).Item("Spec_Flag").ToString.Trim


                If tmpStatus = "Y" AndAlso tmpSpecFlag = "Y" Then
                    dgvDS.Tables(0).Rows(dgvDS.Tables(0).Rows.Count - 1).Item("Status") = "未確認"
                ElseIf tmpStatus = "Y" AndAlso tmpSpecFlag = "O" Then
                    dgvDS.Tables(0).Rows(dgvDS.Tables(0).Rows.Count - 1).Item("Status") = "已確認"
                ElseIf tmpStatus = "Y" AndAlso tmpSpecFlag = "N" Then
                    dgvDS.Tables(0).Rows(dgvDS.Tables(0).Rows.Count - 1).Item("Status") = "已處理"
                ElseIf queryDS.Tables(0).Rows(i).Item("Status").ToString.Trim = "" Then
                    dgvDS.Tables(0).Rows(dgvDS.Tables(0).Rows.Count - 1).Item("Status") = "未處理"
                End If

            Next

        End If

        dgv.Initial(dgvDS)
        dgv.uclHeaderText = "發送日期時間,作業,層級,型態,發送者,發送對象,主旨,內容,狀態"
        dgv.uclColumnWidth = "150,150,100,100,100,100,200,350,100"
        strSortAble = "0,1,2,3,4,5,8"
        dgv.uclSortColIndex = strSortAble

    End Sub


    Private Sub CleanBackColor()
        Try
            dtp_StartDate.BackColor = Color.White
            dtp_EndDate.BackColor = Color.White

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function CheckFields() As Boolean
        Try
            Dim IsError As Boolean = False

            If (dtp_StartDate.GetUsDateStr.Length = 0) Then
                IsError = True
                dtp_StartDate.BackColor = Color.White
            End If

            If (dtp_EndDate.GetUsDateStr.Length = 0) Then
                IsError = True
                dtp_EndDate.BackColor = Color.White
            End If

            Return IsError
        Catch ex As Exception
            Syscom.Client.CMM.ClientExceptionHandler.ProccessException(ex)
        End Try
    End Function


    Private Sub btn_ExportExcel_Click(sender As Object, e As EventArgs) Handles btn_ExportExcel.Click
        If dgvDS IsNot Nothing Then
            DataSetToExcel(dgvDS)
        End If
    End Sub

#Region "   函數功能 To Excel"

    Dim columnName As String() = {"發送日期時間", "作業", "層級", "型態", "發送者", "發送對象", "主旨", "內容", "狀態"}

    Public Function DataSetToExcel(ByVal ds As DataSet) As Int32

        Try



            Dim xlsapp As New Excel.Application

            xlsapp.Workbooks.Add()

            xlsapp.Visible = True

            xlsapp.Selection.Merge()

            xlsapp.Columns(3).WrapText = True '自動換行

            'xlsapp.Columns(3).ColumnWidth = 30



            Dim i As Int16

            For i = 1 To ds.Tables(0).Columns.Count

                xlsapp.Cells(1, i) = columnName(i - 1) 'ds.Tables(0).Columns(i - 1).ColumnName

            Next

            Dim rowindex As Integer = 2

            Dim colindex As Integer

            Dim col As DataColumn

            Dim row As DataRow

            Dim nxh As Integer = 1

            For Each row In ds.Tables(0).Rows

                colindex = 1

                For Each col In ds.Tables(0).Columns

                    If colindex = 1 Then

                        xlsapp.Cells(rowindex, colindex) = RTrim(Convert.ToString(row(col.ColumnName)))

                        xlsapp.Cells(rowindex, colindex).NumberFormat = "yyyy-MM-dd HH:mm"

                    Else

                        xlsapp.Cells(rowindex, colindex) = RTrim(Convert.ToString(row(col.ColumnName)))

                    End If

                    colindex += 1

                Next

                rowindex += 1

                nxh += 1

            Next

            xlsapp.Range(xlsapp.Cells(1, 1), xlsapp.Cells(ds.Tables(0).Rows.Count + 2, ds.Tables(0).Columns.Count)).Font.Size = 9

            'xlsapp.Range(xlsapp.Cells(2, 6), xlsapp.Cells(ds.Tables(0).Rows.Count + 2, 4)).NumberFormat = "yyyy-MM-dd"

            'xlsapp.Range(xlsapp.Cells(2, 7), xlsapp.Cells(ds.Tables(0).Rows.Count + 2, 5)).NumberFormat = "yyyy-MM-dd"

            'xlsapp.Range(xlsapp.Cells(1, 1), xlsapp.Cells(ds.Tables(0).Rows.Count + 2, ds.Tables(0).Columns.Count)).NumberFormat = "yyyy-MM-dd"

            xlsapp.Columns.AutoFit()

        Catch ex As Exception

            'ShowAndLogErrorDebug(ex, "查詢")

        End Try

    End Function



#End Region


    Private Sub cbo_Recipient_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_Recipient.SelectedIndexChanged

        Try
            If cbo_Recipient.SelectedIndex = 0 Then
                lbl_Recipient2.Text = ""

                tcq_Department.Visible = False
                tcq_Employee.Visible = False

            ElseIf cbo_Recipient.SelectedIndex = 1 Then
                lbl_Recipient2.Text = "科室代碼"
                tcq_Department.Visible = True
                tcq_Employee.Visible = False
            ElseIf cbo_Recipient.SelectedIndex = 2 Then
                lbl_Recipient2.Text = "員工編號"
                tcq_Department.Visible = False
                tcq_Employee.Visible = True
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class