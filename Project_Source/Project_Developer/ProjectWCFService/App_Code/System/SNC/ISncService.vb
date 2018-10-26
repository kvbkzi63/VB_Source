Imports System.ServiceModel

' 注意: 您可以使用內容功能表上的 [重新命名] 命令同時變更程式碼和組態檔中的介面名稱 "ISncService"。
<ServiceContract()>
Public Interface ISncService

#Region "20090910 獲取民國年+序列號 add by Yunfei"

    <OperationContract()> _
    Function getTWYearApiSequentialNo(ByVal strVKey As String) As String

#End Region

#Region "20100211 by wang,jie"
    '收案編號
    <OperationContract()> _
    Function getCmmSerialNoTx(ByVal vType As String, ByVal strVKey As String, ByVal vMinNo As String, ByVal vMaxNo As String) As String
#End Region

End Interface
