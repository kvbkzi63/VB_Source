Imports System
Imports System.Data
Imports System.Threading

Public Class PUBPrintJobBS
    Public pvtPrintDS As New DataSet
    Private Shared _instance As PUBPrintJobBS = Nothing
    Dim CallPubBO As PUBPrintJobBO_E1

    Public Shared Function GetInstance() As PUBPrintJobBS
        If _instance Is Nothing Then
            _instance = New PUBPrintJobBS
        End If
        Return _instance
    End Function

    ''' <summary>
    ''' 報表列印工作檔新增並且檔案上傳
    ''' </summary>
    ''' <param name="ds">存檔資料</param>
    ''' <returns>無</returns>
    ''' <author>Alan</author>
    ''' <date>2015-09-02</date>    
    ''' <remarks></remarks>
    Public Function insertPrintJobData(ByVal ds As System.Data.DataSet) As Integer

        Try
            '1. 先新增資料            
            CallPubBO = PUBPrintJobBO_E1.getInstance
            pvtPrintDS = CallPubBO.insertPrintJobData(ds)

            '2. 呼叫報表列印執行緒
            Dim t As New Thread(AddressOf ThreadProc)
            t.Start()
            'ThreadProc()
            Return 1

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Sub ThreadProc()
        Dim callPubBS As PUBPrintJobThreadBS
        callPubBS = PUBPrintJobThreadBS.GetInstance
        callPubBS.CallPUBReportJobProcess(pvtPrintDS)
    End Sub
End Class

