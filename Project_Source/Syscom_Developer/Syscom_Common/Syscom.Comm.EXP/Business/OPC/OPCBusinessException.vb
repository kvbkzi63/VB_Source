Public Class OPCBusinessException
    Inherits BusinessException
    '此建構式為標準用法，ErrorMessage　會自動取得系統定義檔裡的資訊，亦可直接拿來顯示給使用者看
    Public Sub New(ByRef code As String, Optional ByRef formatArg As String() = Nothing)
        MyBase.New(code, formatArg)
    End Sub
    '此建構式為標準用法，ErrorMessage　會自動取得系統定義檔裡的資訊，ex為原始例外
    Public Sub New(ByRef code As String, ByRef ex As Exception, Optional ByRef formatArg As String() = Nothing)
        MyBase.New(code, ex, formatArg)
    End Sub
    '此建構式為特殊用法，請勿濫用，ErrorCode 取得系統定義檔裡的資訊，但，另外亦使用 ErrorMessage 當作自訂義的訊息供某些邏輯使用
    Public Sub New(ByRef code As String, ByRef msg As String, Optional ByRef formatArg As String() = Nothing)
        MyBase.New(code, msg, formatArg)
    End Sub
    '此建構式為特殊用法，請勿濫用。ErrorCode 取得系統定義檔裡的資訊，但，另外亦使用 ErrorMessage 當作自訂義的訊息供某些邏輯使用，ex為原始例外
    Public Sub New(ByRef code As String, ByRef msg As String, ByRef ex As Exception, Optional ByRef formatArg As String() = Nothing)
        MyBase.New(code, msg, ex, formatArg)
    End Sub
End Class
