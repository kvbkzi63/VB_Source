Public Interface IFtmServiceManager_T

    Function uploadNewFile(ByRef data As DataSet, Optional ByRef fileVersionData As DataSet = Nothing) As String()
    
    Function getImageThumb(ByRef FID As String) As Byte()

    Function downloadFile(ByRef FID As String, Optional ByRef old_file_name As Boolean = False) As Object()

    Function uploadNewFilePath(ByVal inUNCPathTag As String, ByVal inAccessIDTag As String, ByVal inAccessPWTag As String, _
                                  ByRef data As System.Data.DataSet, Optional ByRef fileVersionData As System.Data.DataSet = Nothing) As String()

    Function downloadFilePath(ByRef FID As String, ByVal inUNCPathTag As String, ByVal inAccessIDTag As String, _
                                 ByVal inAccessPWTag As String, ByVal inExtensionName As String, Optional ByRef old_file_name As Boolean = False) As Object()

End Interface
