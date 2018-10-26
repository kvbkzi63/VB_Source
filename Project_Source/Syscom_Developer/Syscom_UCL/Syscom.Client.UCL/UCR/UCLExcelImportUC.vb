'/*
'*****************************************************************************
'*
'*    Page/Class Name:  Excel匯入作業
'*              Title:	UCLExcelImportUC
'*        Description:	
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Charles
'*        Create Date:	2016-03-03
'*      Last Modifier:	Charles
'*   Last Modify Date:	2016-03-03
'*
'*****************************************************************************
'*/


Imports Syscom.Comm.EXP
Imports Syscom.Comm.Utility
Imports Syscom.Comm.Utility.StringUtil
Imports Syscom.Comm.Utility.CheckMethodUtil

Imports Syscom.Client.CMM
Imports Syscom.Client.CMM.MessageHandling

Imports Syscom.Client.UCL
Imports Syscom.Client.UCL.UCLScreenUtil



Public Class UCLExcelImportUC

#Region "     變數宣告 "

    '包含第一列資料(通常第一列為Header) True：包含第一列、False：不包含第一列
    Private _includeColumnHeader As Boolean = False
    '要開啟的指定工作表
    Private _SheetIndex As Integer = 1
    '回傳的Table Name
    Private _OutTableName As String = "excelData"

#Region "     使用的Event宣告 "

    '定義使用的Event介面
    Dim WithEvents eventMgr As EventManager = EventManager.getInstance '宣告EventManager

#End Region

#End Region

#Region "     屬性設定 "

    ''' <summary>
    ''' 設定是否包含第一列(通常第一列為Header)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property GetincludeColumnHeaderBool() As Boolean
        Get
            Return _includeColumnHeader
        End Get
        Set(ByVal value As Boolean)
            _includeColumnHeader = value
        End Set
    End Property

    ''' <summary>
    ''' 要開啟的指定工作表(Default:1)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property GetSheetIndex() As String
        Get
            Return _SheetIndex
        End Get
        Set(ByVal value As String)
            _SheetIndex = value
        End Set
    End Property


    ''' <summary>
    ''' 回傳的Table Name(Default :excelData)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property GetOutTableName() As String
        Get
            Return _OutTableName
        End Get
        Set(ByVal value As String)
            _OutTableName = value
        End Set
    End Property


#End Region

#Region "     主要功能 "
 
#Region "     外部參數傳遞 (提供其他UI呼叫、傳入參數) "


    Public Sub PerformClick()

        Btn_Import.PerformClick()

    End Sub

#Region "初始化"
    Sub New()

        ' 此為設計工具所需的呼叫。
        InitializeComponent()
        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。

    End Sub


#End Region


#End Region

#End Region

#Region "     內部功能 "
 

#Region "     事件集合 "



#End Region

#Region "     取得存檔的Dataset資料 "



#End Region

#Region "     按鍵鎖定、熱鍵功能設定 "

#Region "     主要功能的按鍵鎖定，避免重複Click造成資料或UI出問題 "

#Region "     匯入 鎖定功能 "

    ''' <summary>
    ''' 匯入
    ''' </summary>
    ''' <param name="Sender">按鈕物件</param>
    ''' <param name="e">事件</param>
    ''' <remarks>by Charles on 2016-03-03</remarks>
    Private Sub btn_Import_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Import.Click

        '鎖定螢幕
        Lock(Me)
        Try

            '清除左下方訊息欄
            clearInfoMsg()

     
            '開啟Excel匯入資料
            Dim ofDialog As New OpenFileDialog
            '"Word Documents|*.doc|Excel Worksheets|*.xls|PowerPoint Presentations|*.ppt" & "|Office Files|*.doc;*.xls;*.ppt" & "|All Files|*.*"
            'ofDialog.Filter = "CSV (*.csv)|*.csv|Excel 2003 files (*.xls)|*.xls|Excel 2007 files (*.xlsx)|*.xlsx"
            ofDialog.Filter = "Excel Files|*.csv;*.xls;*.xlsx"
            ofDialog.FilterIndex = 0
            ofDialog.RestoreDirectory = True


            If ofDialog.ShowDialog(Me) = DialogResult.OK Then
                Dim filePath As String = ofDialog.FileName

                Dim dsData As DataSet = CmmMethodUtil.ImportExcelDataAndConvertIntoDataSet(filePath, _SheetIndex, _OutTableName, _includeColumnHeader)

                eventMgr.RaiseImportExcel(dsData)
            End If


 
       
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"匯入 鎖定功能"})
        Finally
            '解除螢幕鎖定
            UnLock(Me)
        End Try

    End Sub

#End Region


#End Region

    '#Region "     HotKey設定 "

    '    ''' <summary>
    '    ''' HotKey設定
    '    ''' </summary>
    '    ''' <param name="sender"></param>
    '    ''' <param name="e"></param>
    '    ''' <remarks>by Charles on 2016-03-03</remarks>
    '    Private Sub KeyDownBottuns(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

    '        Try

    '            '鎖定螢幕
    '            Lock(Me)

    '            Select Case e.KeyCode


    '                Case Keys.F2

    '                    '匯入
    '                    If btn_Import.Enabled Then
    '                        btn_Import.PerformClick()
    '                    End If

    '                    'Case Keys.Enter
    '                    'Me.ProcessTabKey(True)

    '            End Select

    '        Catch cmex As CommonException
    '            Throw cmex
    '        Catch ex As Exception
    '            Throw New CommonException("CMMCMMB302", ex, New String() {"HotKey設定"})

    '        Finally

    '            '解除螢幕鎖定
    '            Unlock(Me)

    '        End Try

    '    End Sub

    '    ''' <summary>
    '    '''  HotKey設定
    '    ''' </summary>
    '    ''' <param name="msg"></param>
    '    ''' <param name="keyData"></param>
    '    ''' <returns></returns>
    '    ''' <remarks></remarks>
    '    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
    '        Try
    '            Select Case keyData
    '                '  F2
    '                Case Keys.F2
    '                    '匯入
    '                    If Btn_Import.Enabled Then
    '                        Btn_Import.PerformClick()
    '                    End If

    '            End Select

    '            Return MyBase.ProcessCmdKey(msg, keyData)
    '        Catch cmex As CommonException
    '            Throw cmex
    '        Catch ex As Exception
    '            Throw New CommonException("CMMCMMB302", ex, New String() {"HotKey設定"})

    '        Finally

    '            '解除螢幕鎖定
    '            UnLock(Me)
    '        End Try

    '    End Function

    '#End Region

#End Region

#End Region


End Class
