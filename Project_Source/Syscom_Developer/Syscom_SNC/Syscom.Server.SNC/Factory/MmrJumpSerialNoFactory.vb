Imports Syscom.Server.SQL

Public Class MmrJumpSerialNoFactory : Inherits AbstractFactory

    Private Shared instance As MmrJumpSerialNoFactory

    Private vType As SncType = SncType.typeD
    Private vKey As String = "MMR_PreLend"
    Private vMinNo = 1
    Private vMaxNo = -1
    Private vInc As Integer = 1

    'Public Sub New()
    '    vType = typeD
    '    vKey = "MMR_PreLend"
    '    vMinNo = 1
    '    vMaxNo = -1
    '    'vInc 由外部傳入決定
    'End Sub

    Public Shared Function getInstance() As MmrJumpSerialNoFactory
        If instance Is Nothing Then
            instance = New MmrJumpSerialNoFactory
        End If
        Return instance
    End Function

    Public Overrides Function getSerialNo(ByVal Type As SncType, ByVal Key As String, ByVal MinNo As Integer, ByVal MaxNo As Integer, ByVal Inc As Integer, conn As IDbConnection) As String

        Return SerialNoServiceClient.getInstance.getSerialNo(Type, Key, MinNo, MaxNo, Inc, conn).ToString
    End Function

    Public Overloads Function getSerialNo(Optional ByRef conn As System.Data.IDbConnection = Nothing) As String
        Dim serialNo As Integer = SerialNoServiceClient.getInstance.getSerialNo(vType, vKey, vMinNo, vMaxNo, vInc, conn)
        Return CType(serialNo, String)
    End Function

    ''' <summary>
    ''' 一次取得連續序號
    ''' </summary>
    ''' <param name="Inc">每次增加的數量</param>
    ''' <returns>給連續序號的第一個值</returns>
    ''' <remarks></remarks>
    Public Function getMMRSerialNo(ByRef Inc As Integer, Optional conn As System.Data.IDbConnection = Nothing) As String
        If conn Is Nothing Then
            conn = getSncConnection()
        End If
        vInc = Inc
        Dim serialNo As Integer = getSerialNo(SncType.typeD, vKey, vMinNo, vMaxNo, vInc, conn)
        '由於有最小號限制，所以加此判斷
        If serialNo = vMinNo Then
            serialNo = getSerialNo(vType, vKey, vMinNo, vMaxNo, vInc - 1, conn) ' -1 是減去 vMinNo 第一次被取出
        End If

        serialNo = serialNo - Inc + 1

        Return CType(serialNo, String)
    End Function

    Private Function getSncConnection() As IDbConnection
        Return SQLConnFactory.getInstance.getSerialNoSqlConn
    End Function

End Class
