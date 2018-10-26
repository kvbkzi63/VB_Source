Imports Syscom.Comm.EXP

Public Class RPTDelegate

#Region "Singleton Design Pattern - Fully Thread Safety"

    ''' <summary>
    ''' 阻止外部直接進行新建立的宣告
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub New()
    End Sub

    ''' <summary>
    ''' 屬性取得類別實體
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property getInstance() As RPTDelegate
        Get
            Threading.Thread.CurrentThread.CurrentCulture = New Globalization.CultureInfo("zh-TW", False)
            Return Nested.instance
        End Get
    End Property

    ''' <summary>
    ''' 巢狀類別存放建立的類別實體
    ''' </summary>
    ''' <remarks></remarks>
    Private Class Nested
        Shared Sub New()
        End Sub

        Public Shared ReadOnly instance As New RPTDelegate()
    End Class

#End Region

    ''' <summary>
    ''' 取得印表機名稱
    ''' </summary>
    ''' <param name="id"></param>
    ''' <param name="type"></param>
    ''' <param name="con"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getPrinterName(ByRef id As String, ByRef type As Integer, ByRef con As Object) As String
        Try
            Return PrinterSelectBO.getInstance.getPrinterName(id, type, con)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    Public Function getReportInfo(ByVal repprtID As String, ByVal printerType As String, ByVal printerCond As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim bo As New PUBPrintConfigBO_E1
        Try
            Return bo.getReportInfo(repprtID, printerType, printerCond)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
