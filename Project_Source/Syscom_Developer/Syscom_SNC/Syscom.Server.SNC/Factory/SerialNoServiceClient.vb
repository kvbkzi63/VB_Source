Imports System.Data.SqlClient
Imports Syscom.Comm.EXP
Imports Syscom.Server.SQL

Public Class SerialNoServiceClient

#Region "Singleton Design Pattern - Fully Thread Safety"

    ''' <summary>
    ''' 阻止外部直接進行新建立的宣告
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub New()
    End Sub

    ''' <summary>
    ''' 屬性取得類別實體
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property getInstance() As SerialNoServiceClient
        Get
            Return Nested.instance
        End Get
    End Property

    ''' <summary>
    ''' 巢狀類別存放建立的類別實體
    ''' </summary>
    ''' <remarks></remarks>
    Private Class Nested
        Shared Sub New()
        End Sub

        Public Shared ReadOnly instance As New SerialNoServiceClient()
    End Class

#End Region

    ''' <summary>
    ''' 取得序號
    ''' </summary>
    ''' <param name="vType">A:日循環 B:月循環 C:年循環 D:不循環直到最大號 </param>
    ''' <param name="vKey">識別系統與資訊的值</param>
    ''' <param name="vMinNo">最小號，default 給 1</param>
    ''' <param name="vMaxNo">建議給99999999，沒有限制最大號給 -1</param>
    ''' <param name="vInc">兩次號碼之間增加的數值</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getSerialNo(ByVal vType As AbstractFactory.SncType, ByVal vKey As String, ByVal vMinNo As Integer, ByVal vMaxNo As Integer, ByVal vInc As Integer, Optional ByVal conn As IDbConnection = Nothing) As Integer
        Try
            Dim ds As DataSet

            If conn Is Nothing Then
                conn = getSncConnection()
            End If

            Dim command As SqlCommand = New SqlCommand("GetSequence", conn)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@vType", SqlDbType.Char, 1)
            command.Parameters.Add("@vKey", SqlDbType.Char, 20)
            command.Parameters.Add("@vMinNo", SqlDbType.Int)
            command.Parameters.Add("@vMaxNo", SqlDbType.Int)
            command.Parameters.Add("@vInc", SqlDbType.Int)

            Select Case vType
                Case AbstractFactory.SncType.typeA
                    command.Parameters("@vType").Value = "A"
                Case AbstractFactory.SncType.typeB
                    command.Parameters("@vType").Value = "B"
                Case AbstractFactory.SncType.typeC
                    command.Parameters("@vType").Value = "C"
                Case AbstractFactory.SncType.typeD
                    command.Parameters("@vType").Value = "D"
                Case Else
                    command.Parameters("@vType").Value = "D"
            End Select

            command.Parameters("@vKey").Value = vKey
            command.Parameters("@vMinNo").Value = vMinNo
            command.Parameters("@vMaxNo").Value = vMaxNo
            command.Parameters("@vInc").Value = vInc

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("SerialNo")
                adapter.Fill(ds, "SerialNo")
                'adapter.FillSchema(ds, SchemaType.Mapped, "SerialNo")
            End Using

            Dim serialNo As Integer = CInt(ds.Tables(0).Rows(0).Item(0))
            Dim msg As String = CStr(ds.Tables(0).Rows(0).Item(1)).Trim

            If serialNo < 0 Then
                Throw New CommonException("SNCCMMA002", New String() {msg})
            End If

            Return serialNo
        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("SNCCMMA002", ex, New String() {ex.Message})
        End Try
    End Function

    Private Function getSncConnection() As IDbConnection
        Return SQLConnFactory.getInstance.getSerialNoSqlConn
    End Function

    'vSection傳入如:9150  8211,  vSourceKind: O->門診  I->住院    E->急診   H->健
    Public Function getRequestNo(ByVal vSection As String, ByVal vSourceKind As String) As String
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlConnection = getSncConnection()
            Dim command As SqlCommand = New SqlCommand("GetRequestNo", sqlConn)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@vKey", SqlDbType.VarChar, 20)
            command.Parameters("@vKey").Value = vSection
            command.Parameters.Add("@vSystem", SqlDbType.VarChar, 1)
            command.Parameters("@vSystem").Value = vSourceKind


            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("temp")
                adapter.Fill(ds, "temp")
                adapter.FillSchema(ds, SchemaType.Mapped, "temp")
            End Using

            Dim serialNo As String = ds.Tables(0).Rows(0).Item(0)

            Dim msg As String = ds.Tables(0).Rows(0).Item(1)

            If Mid(serialNo, 1, 3) = "ERR" Then
                Throw New CommonException("SNCCMMA001", New String() {msg})
            End If

            Return serialNo
        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("SNCCMMA001", ex, New String() {ex.Message})
        End Try
    End Function

End Class
