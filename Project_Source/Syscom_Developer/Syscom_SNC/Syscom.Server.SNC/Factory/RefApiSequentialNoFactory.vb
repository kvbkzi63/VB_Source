Imports System.Transactions
Imports Syscom.Server.SQL
Imports System.Configuration
Imports Syscom.Comm.EXP
Imports System.Data.SqlClient

Public Class RefApiSequentialNoFactory : Inherits AbstractFactory

    Private Shared instance As RefApiSequentialNoFactory

    Private vType As SncType = SncType.typeD
    Private vKey As String = "REFAPI_RefPati"
    Private vMinNo = 1
    Private vMaxNo = -1
    Private vInc As Integer = 1

    'Public Sub New()        
    '    vType = typeD
    '    vKey = "REFAPI_RefPati"
    '    vMinNo = 1
    '    vMaxNo = -1
    'End Sub

    Public Shared Function getInstance() As RefApiSequentialNoFactory
        If instance Is Nothing Then
            instance = New RefApiSequentialNoFactory
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

    Public Function getRefSerialNo(ByVal strVKey As String, conn As System.Data.IDbConnection) As String
        Return CType((Now.Year - 1911), String).PadLeft(3, "0") & _
             getSerialNo(SncType.typeC, strVKey, vMinNo, vMaxNo, vInc, conn).PadLeft(7, "0")
    End Function

    '民國年 + 序列號
    Public Function getTWYearSerialNo(ByVal strVKey As String, Optional conn As System.Data.IDbConnection = Nothing) As String
        Try
            If conn Is Nothing Then
                conn = getSncConnection()
            End If

            Return CType((Now.Year - 1911), String).PadLeft(3, "0") & _
                getSerialNo(SncType.typeC, strVKey, vMinNo, vMaxNo, vInc, conn).PadLeft(7, "0")

        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("SNCCMMA002", ex, New String() {ex.Message})
        End Try

    End Function


    ''' <summary>
    '''  西元年月 + 序列號
    ''' </summary>
    ''' <param name="strVKey"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getUSYearMonthTypeBSerialNo(ByVal strVKey As String, conn As System.Data.IDbConnection) As String
        Return CType((Now.Year), String) & CType((Now.Month), String).PadLeft(2, "0") & _
                getSerialNo(SncType.typeB, strVKey, vMinNo, vMaxNo, vInc, conn).PadLeft(7, "0")
    End Function

    ''' <summary>
    '''  西元年+月+日+指導類別+檔案類型+序號
    ''' </summary>
    ''' <param name="strVKey"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getCNCGEFLUP_SN(ByVal strVKey As String, ByVal strEducationNo As String, ByVal strFilesType As String, conn As System.Data.IDbConnection) As String
        Return CType((Now.Year), String) & CType((Now.Month), String).PadLeft(2, "0") & _
        CType((Now.Day), String).PadLeft(2, "0") & strEducationNo & strFilesType & _
                getSerialNo(SncType.typeB, strVKey, vMinNo, vMaxNo, vInc, conn).PadLeft(7, "0")
    End Function

    '西元年 + 序列號
    Public Function getYearSerialNo(ByVal strVKey As String, conn As System.Data.IDbConnection) As String
        Return strVKey.ToString.Substring(0, 4) & Now.Year.ToString.Substring(2, 2) & _
                getSerialNo(SncType.typeC, strVKey.ToString.Substring(0, 4) & Now.Year.ToString.Substring(2, 2), vMinNo, 999999, vInc, conn).PadLeft(6, "0")
    End Function


    Private Function getSncConnection() As IDbConnection
        Return SQLConnFactory.getInstance.getSerialNoSqlConn
    End Function
End Class
