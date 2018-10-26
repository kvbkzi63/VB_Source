Imports Syscom.Comm.RPT
Imports Syscom.Server.BO
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.EXP
Imports Syscom.Comm.LOG
Imports System.IO
Imports System.Text
Public Class TestTxtRPT
    Inherits IRPTPrintServer
    ' Private report As OMORPT1260102 = New OMORPT1260102
    Public Sub New()
        printerCondition = "*"
    End Sub
    Protected Overrides Function genReport(ByRef data As System.Data.DataSet) As Object
        Dim dataString = New StringBuilder
        dataString.AppendLine("Microsoft XPS Document Writer;A4;12;11;1;")
        dataString.AppendLine("@@T|標楷體|16|1|0|0|80|10|交班表")
        dataString.AppendLine("@@T|標楷體|12|1|0|0|10|16|健檢日期：2009/12/18")
        dataString.AppendLine("@@T|標楷體|12|1|0|0|10|22|病歷號")
        dataString.AppendLine("@@T|標楷體|12|1|0|0|32|22|姓名")
        dataString.AppendLine("@@T|標楷體|12|1|0|0|50|22|性別")
        dataString.AppendLine("@@T|標楷體|12|1|0|0|65|22|生日")
        dataString.AppendLine("@@T|標楷體|12|1|0|0|87|22|床號")
        dataString.AppendLine("@@T|標楷體|12|1|0|0|112|22|注意事項")
        dataString.AppendLine("@@L|0|1|10|28|200|28")
        dataString.AppendLine("@@T|標楷體|12|0|0|0|10|31|00000012")
        dataString.AppendLine("@@T|標楷體|12|0|0|0|30|31|王大關")
        dataString.AppendLine("@@T|標楷體|12|0|0|0|50|31|男")
        dataString.AppendLine("@@T|標楷體|12|0|0|0|60|31|1949/02/10")
        dataString.AppendLine("@@T|標楷體|12|0|0|0|85|31|11C70")
        dataString.AppendLine("@@T|標楷體|12|0|0|0|10|37|00000013")
        dataString.AppendLine("@@T|標楷體|12|0|0|0|30|37|夏漢民")
        dataString.AppendLine("@@T|標楷體|12|0|0|0|50|37|男")
        dataString.AppendLine("@@T|標楷體|12|0|0|0|60|37|1933/03/05")
        dataString.AppendLine("@@T|標楷體|12|0|0|0|85|37|")
        dataString.AppendLine("@@T|標楷體|12|0|0|0|10|43|00000010")
        dataString.AppendLine("@@T|標楷體|12|0|0|0|30|43|Brian10")
        dataString.AppendLine("@@T|標楷體|12|0|0|0|50|43|男")
        dataString.AppendLine("@@T|標楷體|12|0|0|0|60|43|1963/01/01")
        dataString.AppendLine("@@T|標楷體|12|0|0|0|85|43|11C69")

        Dim reportData As String = dataString.ToString

        Return WriteTxtFile(reportData, "OMORPT0100101") '<---- 與一般報表不同
    End Function

    Protected Overrides Sub printReport(ByRef rpt As Object)
        If rpt Is Nothing Then
            '要先genReport
            Throw New RPTBusinessException("RPTCMMA006")
        Else
            Try
                ' rpt.Visible = False
                PrintOut(rpt, getPrinterName("OMORPT0100101"))
            Catch cmex As CommonException
                Throw cmex
            Catch ex As Exception
                Throw New RPTBusinessException("RPTCMMA003", ex)
            Finally
                FinishWork(rpt)
            End Try
        End If
    End Sub

    Protected Overrides Function queryRPTData(ByRef queryCondition() As Object) As System.Data.DataSet
        Return Nothing
    End Function
End Class
