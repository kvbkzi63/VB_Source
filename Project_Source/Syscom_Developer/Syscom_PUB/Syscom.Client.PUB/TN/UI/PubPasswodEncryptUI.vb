'/*
'*****************************************************************************
'*
'*    Page/Class Name:  帳號密碼加密作業
'*              Title:	PubPasswodEncryptUI
'*        Description:	帳號密碼加密作業
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Sean.Lin
'*        Create Date:	2015-04-23
'*      Last Modifier:	Sean.Lin
'*   Last Modify Date:	2015-04-23
'*
'*****************************************************************************
'*/

Imports System.ServiceModel

Imports Syscom.Comm.EXP
Imports Syscom.Comm.Utility
Imports Syscom.Comm.Utility.StringUtil
Imports Syscom.Comm.Utility.CheckMethodUtil

Imports Syscom.Client.CMM
Imports Syscom.Client.CMM.MessageHandling
Imports Syscom.Client.Servicefactory
Imports Syscom.Client.UCL
Imports Syscom.Client.UCL.UCLScreenUtil
 

Public Class PubPasswodEncryptUI

#Region "     變數宣告 "

#Region "     使用者宣告　"

    '目前使用者的ID
    Private CurrentUserID As String = AppContext.userProfile.userId

    '目前使用者的院區
    Private CurrentUserSection As String = AppContext.userProfile.userSection

#End Region
     
#Region "     使用的Instance宣告 "

    Private Shared myInstance As PubPasswodEncryptUI
    Public Shared Function GetInstance() As PubPasswodEncryptUI
        If myInstance Is Nothing Then
            myInstance = New PubPasswodEncryptUI
        End If
        Return myInstance
    End Function

#End Region

#End Region

#Region "     屬性設定 "



#End Region

#Region "     主要功能 "

#Region "     按鈕事件 "

#Region "     開啟Excel "

    ''' <summary>
    ''' 開啟Excel
    ''' </summary>
    ''' <returns >Boolean</returns>
    ''' <remarks>by Sean.Lin on 2015-04-23</remarks>
    Private Function OpenData() As Boolean

        Try

            Dim returnBoolean As Boolean = False

            '檔案位置
            Dim filePath As String = ""

            '讀取的檔案DS
            Dim dsLoad As DataSet = Nothing

            '彈出視窗供使用者選擇要頗析之文件
            Dim Dialog_Temp As OpenFileDialog = New OpenFileDialog()
            Dialog_Temp.Title = "欲頗析之文件"

            If (Dialog_Temp.ShowDialog() = DialogResult.OK) Then
                '取得檔案位置
                filePath = Dialog_Temp.FileName
            End If

            If Not filePath = "" Then

                dsLoad = LoadFile(filePath)

                dsLoad = EncryptPassword(dsLoad)

                DataSetUtil.DataSetToExcel(dsLoad, New String() {"員工編號", "加密密碼", "員工密碼", "姓名", "單位", "單位名稱", "職稱"})
                 
            End If



                Return returnBoolean

                '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB911", ex)
        End Try

    End Function

#End Region

#End Region

#End Region

#Region "     內部功能 "

#Region "     初始化設定 "

#Region "     初始化 - 顯示UI "

    ''' <summary>
    ''' 初始化 - 顯示UI
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2015-04-23</remarks>
    Public Sub ShownMe() Handles Me.Shown

        Try

           

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB990", ex)
        End Try

    End Sub

#End Region
     

#End Region

#Region "            讀取檔案"

    ''' <summary>
    ''' 讀取檔案，根據檔名決定為Excel或Access資料庫之資料表。
    ''' 回傳 Table Name 為 Data 的 Dataset
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>By Sean 2015-04-23</remarks>
    Private Function LoadFile(ByVal DataPath As String) As DataSet

        ' pseudo code
        ' Step.1 檢查檔案存在。
        ' Step.2 判斷資料為Access或Excel。
        ' Step.3 讀取資料。

        Try
            '接收讀取到的資料之Dataset
            Dim DS_File As DataSet = New DataSet("Data")

            '檢查檔案是否存在
            If Not System.IO.File.Exists(DataPath) Then
                '檔案不存在
                ShowErrorMsg("CMMCMMB302", "檔案不存在，讀取")

            End If

            Dim Data_Tpye As String = DataPath.ToString.Substring(DataPath.LastIndexOf(".") + 1)

            ' Step.2 判斷資料為Access或Excel。
            '如果為Access
            If Data_Tpye = "pdb" Then

                ' Step.3 讀取資料
                '讀取Access的資料字串
                Dim ReadAccess As String
                ReadAccess = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source= " + DataPath + "; Persist Security Info=True;"

                '讀取資料
                Using adapter As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter("select * from BasicCode", ReadAccess)
                    adapter.Fill(DS_File, "Data")
                    adapter.FillSchema(DS_File, SchemaType.Mapped, "Data")
                End Using

                Return DS_File

                '如果為Excel
            ElseIf Data_Tpye = "xls" Then

                ' Step.3 讀取資料
                '讀取Excel的資料字串
                Dim ReadExcel As String
                ReadExcel = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source= " + DataPath + "; Extended Properties=Excel 8.0;"

                '讀取資料
                Using adapter As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter("select * from [Employee$]", ReadExcel)
                    adapter.Fill(DS_File, "Data")
                    adapter.FillSchema(DS_File, SchemaType.Mapped, "Data")
                End Using


                Return DS_File

            Else
                ShowErrorMsg("CMMCMMB302", "檔案類型不為Excel或Access，讀取")
                Return DS_File
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

#Region " 增加 加密的密碼，並顯示在畫面上 "

    ''' <summary>
    ''' 增加 加密的密碼，並顯示在畫面上
    ''' </summary>
    ''' <remarks>By Sean 2015-04-23</remarks>
    Private Function EncryptPassword(ByVal dsLoad As DataSet) As DataSet

        ' pseudo code
        ' Step.1 讀取DS中的密碼欄
        ' Step.2 加密，並寫入DS。
        ' Step.3 顯示在畫面上。



        Try

            If CheckHasValue(dsLoad, "Data") Then

                For Each dr As DataRow In dsLoad.Tables("Data").Rows
                    'ds 欄位 員工編號	加密密碼	員工密碼
                    If nvl(dr.Item("員工密碼")) <> "" Then

                        dr.Item("加密密碼") = PassWordUtil.Encrypt(nvl(dr.Item("員工密碼")), PassWordUtil.getPrimaryKey)

                    End If

                Next

                dgv_Show.Initial(dsLoad, "", "", "")

            Else
                ShowWarnMsg("CMMCMMB300", "沒有資料可加密!")
            End If

            Return dsLoad

        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

#Region "     按鍵鎖定、熱鍵功能設定 "

#Region "     主要功能的按鍵鎖定，避免重複Click造成資料或UI出問題 "

#Region "     開啟Excel 鎖定功能 "

    ''' <summary>
    ''' 開啟Excel
    ''' </summary>
    ''' <param name="Sender">按鈕物件</param>
    ''' <param name="e">事件</param>
    ''' <remarks>by Sean.Lin on 2015-04-23</remarks>
    Private Sub Btn_Open_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Open.Click

        '鎖定螢幕
        Lock(Me)
        Try

            '清除左下方訊息欄
            ClearInfoMsg()

            If (OpenData()) Then

                '左下方顯示 查詢 成功
                ShowInfoMsg("CMMCMMB301", "開啟Excel")

            End If

            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"開啟Excel 鎖定功能"})
        Finally
            '解除螢幕鎖定
            UnLock(Me)
        End Try

    End Sub

#End Region


#End Region

#Region "     HotKey設定 "

    ''' <summary>
    ''' HotKey設定
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>by Sean.Lin on 2015-04-23</remarks>
    Private Sub KeyDownBottuns(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        Try

            '鎖定螢幕
            Lock(Me)

            Select Case e.KeyCode


                Case Keys.F1

                    '開啟Excel
                    If Btn_Open.Enabled Then
                        Btn_Open.PerformClick()
                    End If

                    'Case Keys.Enter
                    'Me.ProcessTabKey(True)

            End Select

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"HotKey設定"})

        Finally

            '解除螢幕鎖定
            Unlock(Me)

        End Try

    End Sub

#End Region

#End Region

#End Region

End Class

