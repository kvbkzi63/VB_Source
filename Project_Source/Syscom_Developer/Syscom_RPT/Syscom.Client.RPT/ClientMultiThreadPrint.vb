Imports Syscom.Client.CMM

Public Class ClientMultiThreadPrint
   
    Public Shared Sub displayError(ByRef msg As String)
        Try
            Dim nw As NotifyWindows = New NotifyWindows("前端報表列印失敗", msg & " 列印失敗於 " & Now.ToString)
            nw.SetDimensions(250, 160)
            nw.WaitTime = 1800000
            nw.Font = New System.Drawing.Font("標楷體", 12.0F)
            nw.Notify()
        Catch ex As Exception
            LOGDelegate.getInstance.fileErrorMsg(ex.Message, ex)
        End Try        
    End Sub

    ''' <summary>
    ''' 多緒列印
    ''' </summary>
    ''' <param name="client">繼承於IRPTPrintClient的子類別</param>
    ''' <param name="ds">資料</param>
    ''' <param name="reportName">給user看的報表名稱，例如檢驗單或是某某某的檢驗單，如果有錯誤將顯示出給user查看</param>
    ''' <remarks></remarks>
    Public Shared Sub threadPrint(ByRef client As IRPTPrintClient, ByRef ds As DataSet, ByRef reportName As String)
        Dim thClass As New PrintingThreadClass(client, ds, reportName)
        Dim th As New Threading.Thread(AddressOf thClass.runPrint)
        th.Start()
    End Sub
    ''' <summary>
    ''' 多緒列印
    ''' </summary>
    ''' <param name="client">繼承於IRPTPrintClient的子類別</param>
    ''' <param name="queryCondition">資料查詢條件</param>
    ''' <param name="reportName">給user看的報表名稱，例如檢驗單或是某某某的檢驗單，如果有錯誤將顯示出給user查看</param>
    ''' <remarks></remarks>
    Public Shared Sub threadPrint(ByRef client As IRPTPrintClient, ByRef queryCondition As Object(), ByRef reportName As String)
        Dim thClass As New PrintingThreadClass(client, queryCondition, reportName)
        Dim th As New Threading.Thread(AddressOf thClass.runPrint)
        th.Start()
    End Sub
    ''' <summary>
    ''' 多緒且多份排序報表列印
    ''' </summary>
    ''' <param name="client">繼承於IRPTPrintClient的子類別</param>
    ''' <param name="obj">資料或查詢條件</param>
    ''' <param name="reportNames">給user看的報表名稱，例如檢驗單或是某某某的檢驗單，如果有錯誤將顯示出給user查看</param>
    ''' <remarks></remarks>
    Public Shared Sub threadPrint(ByRef client As IRPTPrintClient(), ByRef obj As Object(), ByRef reportNames As String())
        Dim thclass As New SortedPrintingThreadClass(client, obj, reportNames)
        Dim th As New Threading.Thread(AddressOf thclass.runPrint)
        th.Start()
    End Sub
    ''' <summary>
    ''' 多緒列印工作類別
    ''' </summary>
    ''' <remarks></remarks>
    Private Class PrintingThreadClass
        Dim _ds As DataSet
        Dim _queryCondition As Object()
        Dim _reportName As String
        Dim _client As IRPTPrintClient
        Sub New(ByRef client As IRPTPrintClient, ByRef ds As DataSet, ByRef reportName As String)
            _client = client
            _ds = ds
            _reportName = reportName
        End Sub
        Sub New(ByRef client As IRPTPrintClient, ByRef queryCondition As Object(), ByRef reportName As String)
            _client = client
            _queryCondition = queryCondition
            _reportName = reportName
        End Sub
        Sub runPrint()
            Try
                If _ds IsNot Nothing Then
                    _client.print(_ds)
                ElseIf _queryCondition IsNot Nothing Then
                    _client.print(_queryCondition)
                Else
                    _client.print(New DataSet)
                End If
            Catch ex As Exception
                '不回吐 ex，沒辦法掌控，只記 Log，或是要求送 NFC 也可以
                LOGDelegate.getInstance.fileErrorMsg(ex.Message, ex)
                displayError(_reportName)
            End Try


        End Sub
    End Class
    ''' <summary>
    ''' 多緒列印工作類別，有排序
    ''' </summary>
    ''' <remarks></remarks>
    Private Class SortedPrintingThreadClass
        Dim _obj As Object()
        Dim _reportNames As String()
        Dim _client As IRPTPrintClient()
        Sub New(ByRef client As IRPTPrintClient(), ByRef obj As Object(), ByRef reportNames As String())
            _client = client
            _reportNames = reportNames
            _obj = obj
        End Sub
        Sub runPrint()
            For i = 0 To _client.Count - 1
                Try
                    If TypeOf (_obj(i)) Is DataSet Then
                        Dim ds = CType(_obj(i), DataSet)
                        _client(i).print(ds)
                    ElseIf TypeOf (_obj(i)) Is Object() Then
                        Dim queryCondition = CType(_obj(i), Object())
                        _client(i).print(queryCondition)
                    Else                        
                        Throw New Exception("多緒且多份排序報表列印，因參數不合規則，產生此例外")
                    End If
                Catch ex As Exception
                    LOGDelegate.getInstance.fileErrorMsg(ex.Message, ex)
                    displayError(_reportNames(i))
                End Try
               
            Next
        End Sub
    End Class
End Class
