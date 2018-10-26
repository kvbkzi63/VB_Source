'/*
'*****************************************************************************
'*
'*    Page/Class Name:  記錄 App 的設定值
'*              Title:	AppConfigUtil
'*        Description:	記錄 App 的設定值，以處理不同的文字、醫院的系統設定
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Sean.Lin
'*        Create Date:	2013-07-30
'*      Last Modifier:	Sean.Lin
'*   Last Modify Date:	2013-07-30
'*
'*****************************************************************************
'*/

Imports System.Drawing

Public Class AppConfigUtil

#Region " 變數宣告"

    '目前使用者的ID
    Private Shared globalAppLanguage As Language = Language.TraditionalChinese

    '控制項使用的字型與大小
    Private Shared globalControlFont As Font = New Drawing.Font("宋體", 10)

    '全系統使用時間呈現
    Private Shared globalDateFormat As DateFormat = DateFormat.UsDate

    '暫存檔存檔位置
    Private Shared gblSavePathTemp As String = System.Environment.GetFolderPath(Environment.SpecialFolder.Templates) & "\Temp\"

    '永久檔存檔位置
    Private Shared gblSavePathForever As String = System.Environment.GetFolderPath(Environment.SpecialFolder.Templates) & "\Forever\"

    '設定語言種類
    Enum Language
        TraditionalChinese
        SimplifiedChinese
    End Enum

    '設定時間種類
    Enum DateFormat
        TwDate
        UsDate
    End Enum

#End Region

#Region " 屬性設定"

    ''' <summary>
    ''' 阻止外部直接進行新建立的宣告
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub New()
    End Sub

#Region " 取得暫存檔的存檔路徑，固定刪檔"

    ''' <summary>
    ''' 取得暫存檔的存檔路徑，固定刪檔
    ''' </summary>
    ''' <param name="systemCode">系統代碼，EX:Pub</param>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property GetSystemPathTemp(ByVal systemCode As String) As DateFormat
        Get
            Dim returnPath As String = gblSavePathTemp & systemCode

            '判斷Folder，不存在則建立
            If System.IO.Directory.Exists(returnPath) Then
            Else
                System.IO.Directory.CreateDirectory(returnPath)
            End If

            Return returnPath

        End Get
    End Property

#End Region

#Region " 取得永久檔的存檔路徑，不刪檔"

    ''' <summary>
    ''' 取得永久檔的存檔路徑，不刪檔
    ''' <param name="systemCode">系統代碼，EX:Pub</param>
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property GetSystemPathForever(ByVal systemCode As String) As DateFormat
        Get
            Dim returnPath As String = gblSavePathForever & systemCode

            '判斷Folder，不存在則建立
            If System.IO.Directory.Exists(returnPath) Then 
            Else 
                System.IO.Directory.CreateDirectory(returnPath) 
            End If

            Return returnPath

        End Get
    End Property
     
#End Region

    ''' <summary>
    ''' 取得/設定語言種類
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2013-7-30</remarks>
    Public Shared Property AppLanguage() As Language
        Get
            Return globalAppLanguage
        End Get
        Set(ByVal value As Language)
            globalAppLanguage = value
            MessageValueObject.refreshMessageValue()
        End Set
    End Property

    ''' <summary>
    ''' 取得/設定時間種類
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property AppDateFormat() As DateFormat
        Get
            Return globalDateFormat
        End Get
    End Property

    ''' <summary>
    ''' 取得控制項使用的字型
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2013-7-30</remarks>
    Public Shared ReadOnly Property ControlFont() As Font
        Get
            Return globalControlFont
        End Get
    End Property


#End Region


#Region " 主要功能"

#Region " 清除暫存資料夾 "

    ''' <summary>
    ''' 清除暫存資料夾
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2015-12-30</remarks>
    Private Sub CleanTempFolder()

        Try
            '刪除資料夾
            System.IO.Directory.Delete(gblSavePathTemp, True)

            '刪除之後，重新建立Temp的資料夾
            '判斷Folder，不存在則建立
            If System.IO.Directory.Exists(gblSavePathTemp) Then
            Else
                System.IO.Directory.CreateDirectory(gblSavePathTemp)
            End If

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

#End Region



#End Region

End Class

