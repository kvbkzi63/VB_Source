' 注意: 若變更此處的類別名稱 "IFtmService"，也必須更新 Web.config 中 "IFtmService" 的參考。
<ServiceContract()> _
Public Interface IFtmService

    ''' <summary>
    ''' 上傳檔案
    ''' </summary>
    ''' <param name="data">上傳檔案資料</param>
    ''' <param name="fileVersionData">檔案版本資訊</param>
    ''' <returns>FID</returns>
    ''' <remarks></remarks>
    <OperationContract()> _
    Function uploadNewFile(ByRef data As Data.DataSet, Optional ByRef fileVersionData As Data.DataSet = Nothing) As String()

    ''' <summary>
    ''' 下載檔案
    ''' </summary>
    ''' <param name="FID">FID</param>
    ''' <param name="old_file_name">是否使用上傳時的原擋名</param>
    ''' <returns>(0) 檔案資料byte() , (1) client端的預設檔名</returns>
    ''' <remarks></remarks>
    <OperationContract()> _
    Function downloadFile(ByRef FID As String, Optional ByRef old_file_name As Boolean = False) As Object()

    ''' <summary>
    ''' 一次下載多個檔案
    ''' </summary>
    ''' <param name="FIDs">FIDs</param>
    ''' <param name="old_file_name">是否使用上傳時的原擋名</param>
    ''' <returns>Hashtable 以 FID 當 key </returns>
    ''' <remarks></remarks>
    <OperationContract()> _
    Function downloadFiles(ByRef FIDs As String(), Optional ByRef old_file_name As Boolean = False) As Hashtable

    ''' <summary>
    ''' 取得縮圖
    ''' </summary>
    ''' <param name="FID">FID</param>
    ''' <returns>縮圖的byte array</returns>
    ''' <remarks></remarks>
    <OperationContract()> _
    Function getImageThumb(ByRef FID As String) As Byte()

    <OperationContract()> _
    Sub doMyReport(ByRef FID As Integer)

    <OperationContract()> _
    Function uploadNewFilePath(ByVal inUNCPathTag As String, ByVal inAccessIDTag As String, ByVal inAccessPWTag As String, _
                                  ByRef data As System.Data.DataSet, Optional ByRef fileVersionData As System.Data.DataSet = Nothing) As String()

    <OperationContract()> _
    Function downloadFilePath(ByRef FID As String, ByVal inUNCPathTag As String, ByVal inAccessIDTag As String, _
                                 ByVal inAccessPWTag As String, ByVal inExtensionName As String, Optional ByRef old_file_name As Boolean = False) As Object()

End Interface
