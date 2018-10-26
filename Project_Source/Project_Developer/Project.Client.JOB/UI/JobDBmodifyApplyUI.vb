'/*
'*****************************************************************************
'*
'*    Page/Class Name:  資料庫異動申請
'*              Title:	JobDBModifiedApplyUI
'*        Description:	
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Sean.Lin
'*        Create Date:	2017-04-25
'*      Last Modifier:	Sean.Lin
'*   Last Modify Date:	2017-04-25
'*
'*****************************************************************************
'*/

Imports System.ServiceModel

Imports Syscom.Comm.EXP
Imports Syscom.Comm.Utility
Imports Syscom.Comm.Utility.StringUtil
Imports Syscom.Comm.Utility.CheckMethodUtil
Imports System.Collections.Generic

Imports Syscom.Client.CMM
Imports Syscom.Client.CMM.MessageHandling
Imports Syscom.Client.Servicefactory
Imports Syscom.Client.UCL
Imports Syscom.Client.UCL.UCLScreenUtil
Imports JOBClientServiceFactory
Imports System.Data
Imports System.Text
Imports System.IO

Public Class JobDBmodifyApplyUI
    Inherits Syscom.Client.UCL.BaseFormUI
#Region "     變數宣告 "

#Region "     使用者宣告　"

    '目前使用者的ID
    Private CurrentUserID As String = AppContext.userProfile.userId

    '目前使用者的院區
    Private CurrentUserSection As String = AppContext.userProfile.userSection

    Private keys As String() = {"DB_Name", "Table_Name", "Table_Ch_Name", "Index", "Effect_Desc", "Script", "Modified_Classify", "Restrict"}

    Private MyParent As JobSAJobListUI = Nothing

    Dim gblFID As String = ""
    Dim gblModifiedClassify As String = ""
    Dim gblRestrict As String = ""
#End Region

#Region "     使用的service宣告 "

    '定義使用的service介面
    Dim Job As IJOBServiceManager

#End Region

#Region "     使用的Instance宣告 "

    Private Shared myInstance As JobDBmodifyApplyUI
    Public Shared Function GetInstance() As JobDBmodifyApplyUI
        If myInstance Is Nothing Then
            myInstance = New JobDBmodifyApplyUI
        End If
        Return myInstance
    End Function

#End Region

#Region "     使用的Event宣告 "

    '定義使用的Event介面
    Dim WithEvents eventMgr As EventManager

#End Region

#End Region

#Region "     屬性設定 "
    Public Sub SetParent(ByRef Parent As JobSAJobListUI)
        MyParent = Parent
    End Sub


#End Region

#Region "     主要功能 "

#Region "     按鈕事件 "

#Region "     新增 "

    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns >Boolean</returns>
    ''' <remarks>by Sean.Lin on 2017-04-25</remarks>
    Private Function InsertData() As Boolean
        Dim saveFilePath As String = Environment.CurrentDirectory & "\TempFiles\" & Now.ToString("yyyyMMddHHmmss") & "doc.docx"
        Dim SendDS As DataSet = ProjectClientBP.getInstance.GetActionDS(ProjectClientBP.ActionName.ApplyDBModified)
        Dim Folder As New DirectoryInfo(Environment.CurrentDirectory & "\TempFiles\")
        If Not Folder.Exists Then
            Folder.Create()
        End If
        Try

            If ProjectClientBP.getInstance.ExportWordByKeyAndValue("TempDBModifiedDoc.docx", saveFilePath, GetKeyValue()) Then
                gblFID = UploadFileToFTM(saveFilePath)
            End If
            If gblFID.Length > 0 Then
                SendDS.Tables(0).Rows.Add("ApplyDBModified", MyParent.ProjectID,
                                          MyParent.SystemID,
                                          txt_TableName.Text,   'Table_Name
                                          txt_TableChName.Text,   'Table_Ch_Name
                                          txt_DBName.Text,   'DBName
                                          txt_Index.Text,   'Index
                                          gblRestrict,   'Opportunity
                                          gblModifiedClassify,   'Modified_Classify
                                          rtb_Script.Text,   'Sql_Script
                                          MyParent.PGEmployee,   'DBA_Employee_Code
                                          CurrentUserID,   'Create_User
                                          AppContext.userProfile.userName,   'Create_User_Name
                                          gblFID) 'FID
            End If
            Dim retDS As DataSet = Job.PRJDoAction(SendDS)

            If CheckMethodUtil.CheckHasValue(retDS) AndAlso ClearData() Then
                Return True
            End If

            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB912", ex)
        Finally
            Folder.Delete(True)
        End Try
        Return False
    End Function

#End Region

#Region "     清除 "

    ''' <summary>
    ''' 清除
    ''' </summary>
    ''' <returns >Boolean</returns>
    ''' <remarks>by Sean.Lin on 2017-04-25</remarks>
    Private Function ClearData() As Boolean

        Try

            txt_DBName.Clear()
            txt_Index.Clear()
            txt_TableChName.Clear()
            txt_TableName.Clear()
            rtb_Desc.Text = ""
            rtb_Script.Text = ""

            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB916", ex)
        End Try
        Return True
    End Function

#End Region

#End Region

#Region "     外部參數傳遞 (提供其他UI呼叫、傳入參數) "



#End Region

#End Region

#Region "     內部功能 "

#Region "     初始化設定 "

#Region "     初始化 - 顯示UI "

    ''' <summary>
    ''' 初始化 - 顯示UI
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2017-04-25</remarks>
    Public Sub ShownMe() Handles Me.Shown

        Try

            '載入服務管理員
            LoadServiceManager()

            '載入事件管理員
            LoadEventManager()

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB990", ex)
        End Try

    End Sub

#End Region

#Region "     載入服務管理員 "

    ''' <summary>
    ''' 載入ServiceManager的Instance
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2017-04-25</remarks>
    Private Sub LoadServiceManager()

        Try

            Job = JOBServiceManager.getInstance()

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB991", ex)
        End Try


    End Sub

#End Region

#Region "     載入事件管理員(EventManager) "

    ''' <summary>
    ''' 載入EventManager的Instance
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2017-4-25</remarks>
    Private Sub LoadEventManager()

        Try

            eventMgr = EventManager.getInstance()

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB992", ex)
        End Try

    End Sub

#End Region

#Region "     關閉事件管理員(EventManager) "

    ''' <summary>
    ''' 關閉事件管理員(EventManager)
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2017-04-25</remarks>
    Private Sub UIDisposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed

        Try

            eventMgr = Nothing

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB993", ex)
        End Try

    End Sub

#End Region

#End Region

#Region "     必填檢查 "



#End Region

#Region "     事件集合 "

#Region "     檢核"

    Private Function CheckBeforeSave() As Boolean

        Dim errMsg As String = ""

        Try
            If txt_DBName.Text.Length = 0 Then
                errMsg = errMsg & "DB名稱不得為空、" & vbCrLf
                txt_DBName.BackColor = System.Drawing.Color.LightPink
            Else
                txt_DBName.BackColor = System.Drawing.Color.White
            End If

            If txt_TableChName.Text.Length = 0 Then
                errMsg = errMsg & "Table中文名稱不得為空、" & vbCrLf
                txt_TableChName.BackColor = System.Drawing.Color.LightPink
            Else
                txt_TableChName.BackColor = System.Drawing.Color.White
            End If

            If txt_TableName.Text.Length = 0 Then
                errMsg = errMsg & "Table名稱不得為空、" & vbCrLf
                txt_TableName.BackColor = System.Drawing.Color.LightPink
            Else
                txt_TableName.BackColor = System.Drawing.Color.White
            End If

            If rtb_Desc.Text.Length = 0 Then
                errMsg = errMsg & "影響說明不得為空、" & vbCrLf
                rtb_Desc.BackColor = System.Drawing.Color.LightPink
            Else
                rtb_Desc.BackColor = System.Drawing.Color.White
            End If

            If rtb_Script.Text.Length = 0 Then
                errMsg = errMsg & "Sql Script 不得為空、" & vbCrLf
                rtb_Script.BackColor = System.Drawing.Color.LightPink
            Else
                rtb_Script.BackColor = System.Drawing.Color.White
            End If

            Dim RestrictSelect As Boolean = False
            For Each c As System.Windows.Forms.Control In flp_Restrict.Controls
                If CType(c, System.Windows.Forms.CheckBox).Checked Then
                    RestrictSelect = True
                End If
            Next

            If Not RestrictSelect Then
                errMsg = errMsg & "限制 至少選一項、" & vbCrLf
                flp_Restrict.BackColor = System.Drawing.Color.LightPink
            Else
                flp_Restrict.BackColor = System.Drawing.Color.White
            End If

            Dim ModifiedClassify As Boolean = False
            For Each c As System.Windows.Forms.Control In flp_ModifiedClassify.Controls
                If CType(c, System.Windows.Forms.CheckBox).Checked Then
                    ModifiedClassify = True
                End If
            Next

            If Not ModifiedClassify Then
                errMsg = errMsg & "異動類別 至少選一項、" & vbCrLf
                flp_ModifiedClassify.BackColor = System.Drawing.Color.LightPink
            Else
                flp_ModifiedClassify.BackColor = System.Drawing.Color.White
            End If

            If MyParent.PGEmployee = "" Then
                errMsg = errMsg & "尚未選擇負責人員、" & vbCrLf
            End If

            If errMsg.Length > 0 Then
                errMsg = errMsg.Substring(0, errMsg.Length - 1)
                MessageHandling.ShowWarnMsg("CMMCMMB300", errMsg)
                Return False
            End If

            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"存檔前檢核"})
        End Try
        Return True
    End Function

#End Region

#End Region

#Region "     取得存檔的Dataset資料 "

    Private Function GetKeyValue() As Dictionary(Of String, String)

        Dim retKey As New Dictionary(Of String, String)


        Try
            For i As Int32 = 0 To keys.Length - 1
                retKey.Add(keys(i), GetValue(keys(i)))
            Next


            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"資料庫異動申請"})
        End Try

        Return retKey
    End Function

    Private Function GetValue(ByVal key As String) As String
        Try
            Select Case key
                Case "DB_Name"
                    Return txt_DBName.Text
                Case "Table_Name"
                    Return txt_TableName.Text
                Case "Table_Ch_Name"
                    Return txt_TableChName.Text
                Case "Index"
                    Return txt_Index.Text
                Case "Effect_Desc"
                    Return rtb_Desc.Text
                Case "Script"
                    Return rtb_Script.Text
                Case "Modified_Classify"
                    Dim s As New StringBuilder
                    gblModifiedClassify = ""
                    For Each c As System.Windows.Forms.Control In flp_ModifiedClassify.Controls
                        If CType(c, System.Windows.Forms.CheckBox).Checked Then
                            s.Append("■").Append(CType(c, System.Windows.Forms.CheckBox).Text).Append(" ")
                            Select Case CType(c, System.Windows.Forms.CheckBox).Name
                                Case "ckb_CreateTable"
                                    gblModifiedClassify = gblModifiedClassify & "1,"
                                Case "ckb_ModifiedColumn"
                                    gblModifiedClassify = gblModifiedClassify & "2,"
                                Case "ckb_ColumnTypeModified"
                                    gblModifiedClassify = gblModifiedClassify & "3,"
                                Case "ckb_ModifiedLenth"
                                    gblModifiedClassify = gblModifiedClassify & "4,"
                                Case "ckb_CreateIndex"
                                    gblModifiedClassify = gblModifiedClassify & "5,"
                                Case "ckb_ModifiedIndex"
                                    gblModifiedClassify = gblModifiedClassify & "6,"
                                Case "ckb_Other"
                                    gblModifiedClassify = gblModifiedClassify & "7,"
                            End Select
                        Else
                            s.Append("□").Append(CType(c, System.Windows.Forms.CheckBox).Text).Append(" ")

                        End If
                    Next
                    If gblModifiedClassify.Length > 0 Then
                        gblModifiedClassify = gblModifiedClassify.Substring(0, gblModifiedClassify.Length - 1)
                    End If
                    Return s.ToString
                Case "Restrict"
                    Dim s As New StringBuilder
                    gblRestrict = ""
                    For Each c As System.Windows.Forms.Control In flp_Restrict.Controls
                        If CType(c, System.Windows.Forms.CheckBox).Checked Then
                            s.Append("■").Append(CType(c, System.Windows.Forms.CheckBox).Text).Append(" ")
                            Select Case CType(c, System.Windows.Forms.CheckBox).Name
                                Case "cbk_Unlimit"
                                    gblRestrict = gblRestrict & "1,"
                                Case "ckb_Synchronize"
                                    gblRestrict = gblRestrict & "2,"
                                Case "ckb_OtherRestrict"
                                    gblRestrict = gblRestrict & "3,"
                            End Select
                        Else
                            s.Append("□").Append(CType(c, System.Windows.Forms.CheckBox).Text).Append(" ")

                        End If
                    Next
                    If gblRestrict.Length > 0 Then
                        gblRestrict = gblRestrict.Substring(0, gblRestrict.Length - 1)
                    End If
                    Return s.ToString
            End Select

            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"取得Value"})
        End Try
        Return ""

    End Function

#End Region

#Region "     清除功能 "



#End Region

#Region "     上傳FTM"

    Private Function UploadFileToFTM(ByVal FilePath As String) As String

        Dim strFilePath As String = ""
        Try
            Dim dataSet As DataSet = New DataSet
            Dim dataTable As DataTable = FileTransferDataFormat.getDataTableWithSchema
            Dim dataRow As DataRow = dataTable.NewRow()
            '使用自己的資料來源取代 New Object 

            dataRow("File_Name") = FilePath  '檔案路徑
            dataRow("Order_Seq") = 1 '顯示順序
            dataRow("Image_Thumb") = Nothing '沒有縮圖的需求給nothing
            dataRow("File_Note") = "testing" '檔案註解
            dataRow("Create_User") = "roger" '上傳人員
            dataRow("Create_Time") = Now '上傳時間
            dataRow("Modified_User") = "roger" '修改人員
            dataRow("Modified_Time") = Now '修改時間
            dataRow("FileByteArray") = FileTransferTool.convertFileToByteArray(FilePath) '將檔案轉成 byte array
            dataRow("FileType") = FileTransferTool.FileType_R '檔案型態 --> T / G /R /O /E / I
            If AppContext.userProfile.userId.Length > 8 Then
                dataRow("FileSub") = AppContext.userProfile.userId.Substring(0, 8)  ' 檔案系統八碼，如果是 EMR 系統，這裡填入八碼病歷號 
            Else
                dataRow("FileSub") = AppContext.userProfile.userId
            End If
            dataRow("FileTime") = Now '指定檔案時間
            dataRow("FID") = 0 '預設給0，後端會再重新給值
            dataTable.Rows.Add(dataRow)
            dataSet.Tables.Add(dataTable)

            Dim client = FtmServiceManager.getInstance
            Dim s() = client.uploadNewFile(dataSet)
            Return s(0)

            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
        End Try
        Return ""
    End Function

#End Region

#Region "     按鍵鎖定、熱鍵功能設定 "

#Region "     主要功能的按鍵鎖定，避免重複Click造成資料或UI出問題 "

#Region "     新增 鎖定功能 "

    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <param name="Sender">按鈕物件</param>
    ''' <param name="e">事件</param>
    ''' <remarks>by Sean.Lin on 2017-04-25</remarks>
    Private Sub btn_Confirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Confirm.Click

        '鎖定螢幕
        Lock(Me)
        Try

            '清除左下方訊息欄
            ClearInfoMsg()

            If CheckBeforeSave() AndAlso (InsertData()) Then

                '左下方顯示 新增 成功
                ShowInfoMsg("CMMCMMB301", "新增")

            End If

            'Error 的最上層，處理例外訊息
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        Finally
            '解除螢幕鎖定
            UnLock(Me)
        End Try

    End Sub

#End Region

#Region "     清除 鎖定功能 "

    ''' <summary>
    ''' 清除
    ''' </summary>
    ''' <param name="Sender">按鈕物件</param>
    ''' <param name="e">事件</param>
    ''' <remarks>by Sean.Lin on 2017-04-25</remarks>
    'Private Sub btn_Clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Clear.Click

    '    '鎖定螢幕
    '    Lock(Me)
    '    Try

    '        '清除左下方訊息欄
    '        ClearInfoMsg()

    '        If (ClearData()) Then

    '            '左下方顯示 清除 成功
    '            ShowInfoMsg("CMMCMMB301", "清除")

    '        End If

    '        'Error 的最上層，處理例外訊息
    '    Catch ex As Exception
    '        ClientExceptionHandler.ProccessException(ex)
    '    Finally
    '        '解除螢幕鎖定
    '        UnLock(Me)
    '    End Try

    'End Sub

#End Region


#End Region

#End Region

#End Region

End Class

