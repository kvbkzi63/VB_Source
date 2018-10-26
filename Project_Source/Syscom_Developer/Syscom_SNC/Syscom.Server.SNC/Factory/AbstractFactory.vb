Public MustInherit Class AbstractFactory

    Public Enum SncType
        typeA   '每天序號由 MinNo 開始，直到 MaxNo。
        typeB   '每月序號由 MinNo 開始，直到 MaxNo。
        typeC   '每年序號由 MinNo 開始，直到 MaxNo。
        typeD   '由 MinNo 開始，直到 MaxNo。
    End Enum

    ''' <summary>
    ''' 取得序號
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public MustOverride Function getSerialNo(ByVal Type As SncType, ByVal Key As String, ByVal MinNo As Integer, ByVal MaxNo As Integer, ByVal Inc As Integer, ByVal conn As IDbConnection) As String

End Class
