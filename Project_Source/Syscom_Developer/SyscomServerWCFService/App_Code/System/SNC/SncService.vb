Imports Syscom.Comm.EXP
Imports Syscom.Server.SNC
Imports Syscom.Server.CMM

' 注意: 您可以使用內容功能表上的 [重新命名] 命令同時變更程式碼、svc 和組態檔中的類別名稱 "SncService"。
Public Class SncService
    Implements ISncService

#Region "20090910 獲取民國年+序列號 add by Yunfei"

    Function getTWYearApiSequentialNo(ByVal strVKey As String) As String Implements ISncService.getTWYearApiSequentialNo
        Try
            Dim oper As SNCDelegate = SNCDelegate.getInstance
            Return oper.getTWYearApiSequentialNo(strVKey)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function

#End Region

#Region "20100211 add by wangjie"
    '收案編號
    Function getCmmSerialNoTx(ByVal vType As String, ByVal strVKey As String, ByVal vMinNo As String, ByVal vMaxNo As String) As String Implements ISncService.getCmmSerialNoTx
        Try
            Dim oper As SNCDelegate = SNCDelegate.getInstance
            Return oper.getCmmSerialNoTx(vType, strVKey, vMinNo, vMaxNo, Nothing)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function
#End Region

End Class
