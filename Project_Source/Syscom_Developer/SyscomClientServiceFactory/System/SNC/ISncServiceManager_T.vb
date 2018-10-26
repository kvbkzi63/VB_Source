Public Interface ISncServiceManager_T

#Region "20090910 獲取民國年+序列號 add by Yunfei"

    Function getTWYearApiSequentialNo(ByVal strVKey As String) As String

#End Region

#Region "20100211 add by wangjie"
    '收案編號
    Function getCmmSerialNoTx(ByVal vType As String, ByVal strVKey As String, ByVal vMinNo As String, ByVal vMaxNo As String) As String
#End Region

End Interface
