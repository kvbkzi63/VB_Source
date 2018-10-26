' 注意: 您可以使用操作功能表上的 [重新命名] 命令同時變更程式碼和組態檔中的介面名稱 "IService"。

Imports System.Data
Imports System.ServiceModel


<ServiceContract()>
Public Interface IJOBService


#Region " 專案維護作業 "

    ''' <summary>
    ''' 專案維護作業(查詢專案清單)
    ''' </summary>
    ''' <returns>Dataset</returns>
    ''' <remarks>by Will.Lin on 2017-04-14</remarks>
    <OperationContract()>
    Function QueryJobProjectMaintainData(ByVal Project_ID As String, ByVal Project_Name As String, ByVal Start_Date As String, ByVal End_Date As String, ByVal Project_Manager As String) As DataSet

    ''' <summary>
    ''' 專案維護作業(PRJDoAction)
    ''' </summary>
    ''' <returns>Dataset</returns>
    ''' <remarks>by Will.Lin on 2017-04-14</remarks>
    <OperationContract()>
    Function PRJDoAction(ByVal ds As DataSet) As DataSet

#End Region


End Interface



