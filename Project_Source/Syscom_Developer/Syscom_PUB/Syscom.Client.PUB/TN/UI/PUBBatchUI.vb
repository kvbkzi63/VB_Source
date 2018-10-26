Imports Syscom.Client.UCL
Imports Syscom.Comm.EXP
Imports Syscom.Comm.BASE
Imports System.Xml
Imports System.IO
Imports Syscom.Client.Servicefactory
Imports Syscom.Comm.Utility.StringUtil

Public Class PUBBatchUI
    Inherits BaseFormUI

#Region "     變數宣告 "

    Private _gblBatchUrl As String = ""

#Region "     使用的service宣告 "

    '定義使用的service介面

    Dim Pub As IPubServiceManager

#End Region

#End Region


#Region "     載入服務管理員 "

    ''' <summary>
    ''' 載入ServiceManager的Instance
    ''' </summary>
    ''' <remarks>by Charles on 2016-04-20</remarks>
    Private Sub LoadServiceManager()

        Try
 

            Pub = PubServiceManager.getInstance
 
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB991", ex)
        End Try


    End Sub

#End Region


#Region "    初始化資料"

    ''' <summary>
    ''' 初始化資料
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub initialData()
        Try
            ' PubConfig
            Using PubDs As DataSet = Pub.PubConfigQueryByConfigName("PCSBatch")
                If PubDs.Tables.Count > 0 AndAlso PubDs.Tables(0).Rows.Count > 0 Then

                    _gblBatchUrl = nvl(PubDs.Tables(0).Rows(0).Item("Config_Value"))
                Else
                    Syscom.Client.CMM.MessageHandling.ShowInfoMsg("PUBConfig-PCSBatch未設定")
                End If
            End Using

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB931", ex)
        End Try

    End Sub

#End Region


    Private Sub PUBBatchUI_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Try

            LoadServiceManager()

            initialData()

            SuppressScriptErrorsOnly(WebBrowser1)
             
            WebBrowser1.Navigate(_gblBatchUrl)

        Catch ex As Exception
            Throw New CommonException("CMMCMMB990", ex)
        End Try
    End Sub

    ' Hides script errors without hiding other dialog boxes.
    Private Sub SuppressScriptErrorsOnly(ByVal browser As WebBrowser)

        ' Ensure that ScriptErrorsSuppressed is set to false.
        browser.ScriptErrorsSuppressed = False

        ' Handle DocumentCompleted to gain access to the Document object.
        AddHandler browser.DocumentCompleted, _
            AddressOf browser_DocumentCompleted

    End Sub

    Private Sub browser_DocumentCompleted(ByVal sender As Object, _
    ByVal e As WebBrowserDocumentCompletedEventArgs)

        AddHandler CType(sender, WebBrowser).Document.Window.Error, _
            AddressOf Window_Error

    End Sub

    Private Sub Window_Error(ByVal sender As Object, _
        ByVal e As HtmlElementErrorEventArgs)

        ' Ignore the error and suppress the error dialog box. 
        e.Handled = True

    End Sub
     

End Class