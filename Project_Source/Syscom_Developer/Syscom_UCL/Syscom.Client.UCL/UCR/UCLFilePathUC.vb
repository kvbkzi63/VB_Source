'/*
'*****************************************************************************
'*
'*    Page/Class Name:  檔案路徑元件
'*              Title:	UCLFilePathUC
'*        Description:	
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Charles
'*        Create Date:	2016-03-04
'*      Last Modifier:	Charles
'*   Last Modify Date:	2016-03-04
'*
'*****************************************************************************
'*/


Imports Syscom.Comm.EXP
Imports Syscom.Comm.Utility
Imports Syscom.Comm.Utility.StringUtil
Imports Syscom.Comm.Utility.CheckMethodUtil

Imports Syscom.Client.CMM
Imports Syscom.Client.CMM.MessageHandling
Imports Syscom.Client.Servicefactory
Imports Syscom.Client.UCL
Imports Syscom.Client.UCL.UCLScreenUtil


Public Class UCLFilePathUC


#Region "     變數宣告 "

 
    Private _uclFilterFlag = FilterFlag.AllFile      '檔案的篩檢字串

    ''' <summary>
    ''' 檔案的篩檢字串
    ''' </summary>
    ''' <remarks></remarks>
    Enum FilterFlag
        AllFile = 1              '1:*
        Excel = 2                '2:Excel
        Word = 3               '3:Word
        XML = 4                  '4:XML
        Txt = 5                  '5:txt
        Pdf = 6                 '6:Pdf

    End Enum


#End Region

#Region "     屬性設定 "

    ''' <summary>
    ''' 取得/設定 輸入的路徑
    ''' </summary>
    ''' <returns>String</returns>
    ''' <remarks></remarks>
    Public Property FilePath() As String

        Get
            Return txt_Path.Text
        End Get
        Set(ByVal value As String)
            If (value.Trim.Length = 0) Then
                Clear()
            Else
                txt_Path.Text = value

            End If

        End Set
    End Property

    ''' <summary>
    ''' 檔案的篩檢字串
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property uclFilterFlag() As FilterFlag
        Get
            Return _uclFilterFlag
        End Get
        Set(ByVal value As FilterFlag)
            _uclFilterFlag = value
        End Set
    End Property



#End Region

#Region "     主要功能 "

#Region "     外部參數傳遞 (提供其他UI呼叫、傳入參數) "


#Region "初始化"
    Sub New()

        ' 此為設計工具所需的呼叫。
        InitializeComponent()
        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。

    End Sub

#End Region


#Region "     清除 "

    ''' <summary>
    ''' 清除
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Clear()
        txt_Path.Text = ""
        '_gblFilePath = ""
    End Sub

#End Region

#End Region

#End Region


#Region "     內部功能 "

#Region "     初始化設定 "



#End Region

#Region "     事件集合 "



#End Region

#Region "     按鍵鎖定、熱鍵功能設定 "

#Region "     檔案路徑 鎖定功能 "

    ''' <summary>
    ''' 開啟檔案室窗
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Btn_Path_Click(sender As Object, e As EventArgs) Handles Btn_Path.Click
        '鎖定螢幕
        Lock(Me)
        Try

            '清除左下方訊息欄
            ClearInfoMsg()

            '開啟檔案路徑
            Dim ofDialog As New OpenFileDialog
            '"Word Documents|*.doc|Excel Worksheets|*.xls|PowerPoint Presentations|*.ppt" & "|Office Files|*.doc;*.xls;*.ppt" & "|All Files|*.*"
            'ofDialog.Filter = "CSV (*.csv)|*.csv|Excel 2003 files (*.xls)|*.xls|Excel 2007 files (*.xlsx)|*.xlsx"
    
            ofDialog.Filter = GetFilterStr() '
            ofDialog.FilterIndex = 0
            ofDialog.RestoreDirectory = True


            If ofDialog.ShowDialog(Me) = DialogResult.OK Then

                txt_Path.Text = ofDialog.FileName

            End If


        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"檔案路徑 鎖定功能"})
        Finally
            '解除螢幕鎖定
            UnLock(Me)
        End Try
    End Sub


#End Region

#Region "    取得檔案格式"

    ''' <summary>
    ''' 取得檔案格式
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetFilterStr() As String
        Dim RtnFilterStr As String = ""
 
        Select Case _uclFilterFlag

            Case 1
                'AllFile = 1              '1:*
                RtnFilterStr = "所有檔案 (*.*)|*.*"

            Case 2
                'Excel = 2                '2:Excel
                RtnFilterStr = "CSV (*.csv)|*.csv|Excel 2003 files (*.xls)|*.xls|Excel 2007 files (*.xlsx)|*.xlsx"

            Case 3
                'Word = 3               '3:Word
                RtnFilterStr = "Word (*.docx)|*.docx)|Word 97-2003 文件 (*.doc)|*.doc"

            Case 4
                'Xml = 4                  '4:XML
                RtnFilterStr = "XML (*.xml)|*.xml"

            Case 5
                'Txt = 5                  '5:txt
                RtnFilterStr = "Txt (*.txt)|*.txt"

            Case 6
                'Pdf = 6                 '6:Pdf
                RtnFilterStr = "Pdf (*.pdf)|*.pdf"


            Case Else
                RtnFilterStr = "所有檔案 (*.*)|*.*"

        End Select

        Return RtnFilterStr
    End Function

#End Region


#End Region

#End Region



End Class
