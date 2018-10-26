Imports System.ServiceModel

' 注意: 若變更此處的類別名稱 "IRptService"，也必須更新 Web.config 中 "IRptService" 的參考。
<ServiceContract()> _
Public Interface IRptService

    <OperationContract()> _
    Function getPrinterName(ByVal id As String, ByVal type As Integer, ByVal con As Object) As String

    <OperationContract()> _
    Function getReportID() As String

End Interface
