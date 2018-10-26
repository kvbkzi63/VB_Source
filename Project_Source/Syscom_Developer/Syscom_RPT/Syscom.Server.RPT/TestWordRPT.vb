Imports Syscom.Comm.RPT
Imports Microsoft.Office.Interop.Word
Imports Syscom.Server.BO
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.EXP
Imports Syscom.Comm.LOG
Public Class TestWordRPT
    Inherits IRPTPrintServer
    ' Private report As OMORPT1260102 = New OMORPT1260102
    Public Sub New()
        printerCondition = "*"
    End Sub
    Protected Overrides Function genReport(ByRef data As System.Data.DataSet) As Object
        Dim wrdApp As Microsoft.Office.Interop.Word.Application = New Microsoft.Office.Interop.Word.Application()
        wrdApp.Visible = False
        Dim wrdDoc As Microsoft.Office.Interop.Word.Document
        wrdDoc = wrdApp.Documents.Add
        With wrdDoc
            .Range.InsertAfter("Printing with Word")
            .Paragraphs.Item(1).Range.Font.Bold = True
            .Paragraphs.Item(1).Range.Font.Size = 14
            .Range.InsertParagraphAfter()
            .Paragraphs.Item(2).Range.Font.Bold = False
            .Paragraphs.Item(2).Range.Font.Size = 12
            .Range.InsertAfter("This is the first line of the test printout")
            .Range.InsertParagraphAfter()
            .Range.InsertAfter("and this is the second line of the test printout")
        End With

        wrdDoc.Select()
        Return wrdApp
    End Function

    Protected Overrides Sub printReport(ByRef rpt As Object)
        If rpt Is Nothing Then
            '要先genReport
            Throw New RPTBusinessException("RPTCMMA006")
        Else
            Try
                rpt.Visible = False
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
