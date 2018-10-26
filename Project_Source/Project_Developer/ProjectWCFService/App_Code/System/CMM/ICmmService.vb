Imports System.Data
Imports Syscom.Comm.EXP
Imports System.Reflection

' 注意: 若變更此處的類別名稱 "ICmmService"，也必須更新 Web.config 中 "ICmmService" 的參考。
<ServiceContract()> _
Public Interface ICmmService

#Region "取得印表機名稱"

    <OperationContract()> _
    Function getPrinterName(ByVal id As String, ByVal type As Integer, ByVal con As Object) As String

#End Region

#Region "取得報表ID"

    <OperationContract()> _
    Function getReportID() As String

#End Region

#Region "2013/07/19 基本代碼查詢(CMMSysCodeBS) by Sean.Lin"

    ''' <summary>
    ''' 基本代碼查詢 - 不限系統；CodeType:查詢代碼；回傳 TableName 為 CodeType 的 Dataset;包含 Code_ID,Code_Name,Code_EN_Name,Combine_Name,Combine_EN_Name 
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Sean.Lin on 2013-7-19</remarks>
    <OperationContract()> _
    Function CMMSysCodeBSSysCodeQuery(ByVal CodeType As Integer) As DataSet

    ''' <summary>
    ''' 基本代碼查詢 - 不限系統 - 多筆 ；CodeType:查詢代碼的陣列；回傳 TableName 為 CodeType 的 Dataset;包含 Code_ID,Code_Name,Code_EN_Name,Combine_Name,Combine_EN_Name 
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Sean.Lin on 2013-7-19</remarks>
    <OperationContract()> _
    Function CMMSysCodeBSSysCodeQueryMuti(ByVal CodeType As Integer()) As DataSet

#End Region

#Region " 2014/02/14    基本類別代碼查詢 by Lewis "

    ''' <summary>
    ''' 基本類別代碼查詢 - 不限系統；CodeType:查詢代碼；回傳 TableName 為 SystemName 的 Dataset
    ''' 查詢 Pub_Syscode_Type By TypeId 與 SystemName
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Lewis on 2014-2-13</remarks>
    <OperationContract()> _
    Function CMMSysCodeTypeBSSysCodeTypeQuery(ByVal TypeId As String, ByVal SystemName As String) As DataSet


#End Region

#Region "2013/09/16 院區、部門代碼查詢(CMMSysCode) by Sean.Lin"

    ''' <summary>
    ''' 院區代碼查詢
    ''' </summary>
    ''' <returns>DataSet</returns>    ''' <remarks>by Sean.Lin on 2013-09-16</remarks>
    <OperationContract()> _
    Function CMMSysCodequerySectionCode() As DataSet

    ''' <summary>
    ''' 部門代碼查詢
    ''' </summary>
    ''' <returns>DataSet</returns>    ''' <remarks>by Sean.Lin on 2013-09-16</remarks>
    <OperationContract()> _
    Function CMMSysCodequeryDeptTCodeBySectionCode() As DataSet

#End Region

#Region " 查詢參數檔 - 多筆 "

    ''' <summary>
    ''' 查詢參數檔 - 多筆，回傳一個DS，Table Name 為 傳入的 configName
    ''' </summary>
    ''' <param name="configName" >參數名</param>
    ''' <returns>Dataset</returns>
    ''' <remarks>by Sean.Lin on 2016-05-18</remarks>
    <OperationContract()> _
    Function CMMSysCodeQueryPubConfigMuti(ByVal configName As String(), Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet


#End Region

End Interface
