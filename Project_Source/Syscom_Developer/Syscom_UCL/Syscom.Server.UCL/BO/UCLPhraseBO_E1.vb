Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports Syscom.Server.SQL


Public Class UCLPhraseBO_E1

    Public Shared ReadOnly Property Instance()
        Get
            Return New UCLPhraseBO_E1
        End Get
    End Property

    ''' <summary>
    ''' 取得SQL連線資訊
    ''' </summary>
    ''' <returns>sql connection</returns>
    ''' <remarks></remarks>
    Private Function GetSqlConnection() As SqlConnection

        Return SQLConnFactory.getInstance.getOpdDBSqlConn
    End Function

    Public Function queryOMOPhraseForUCL(ByVal UserTypeId As String, ByVal DoctorDeptCode As String, ByVal PhraseTypeId As String, ByVal PhraseKeyStr As String) As DataSet

        Dim var1 As New System.Text.StringBuilder
        var1.Append("SELECT * " & vbCrLf)
        var1.Append("FROM   OMO_Phrase " & vbCrLf)
        var1.Append("WHERE  User_Type_Id = @User_Type_Id " & vbCrLf)
        var1.Append("       AND Doctor_Dept_Code = @Doctor_Dept_Code " & vbCrLf)
        var1.Append("       AND Phrase_Type_Id = @Phrase_Type_Id " & vbCrLf)
        var1.Append("       AND Dc = 'N' " & vbCrLf)
        var1.Append("Order By  User_Type_Id ,Doctor_Dept_Code ,Phrase_Type_Id ,	Phrase_Category ,Phrase_No " & vbCrLf)

        Dim _ds As New DataSet

        Try
            Using _sqlConnection As SqlConnection = GetSqlConnection()

                Dim _command As New SqlCommand(var1.ToString(), _sqlConnection)
                _command.CommandType = CommandType.Text
                _command.Parameters.AddWithValue("@User_Type_Id", UserTypeId)
                _command.Parameters.AddWithValue("@Doctor_Dept_Code", DoctorDeptCode)
                _command.Parameters.AddWithValue("@Phrase_Type_Id", PhraseTypeId)

                Dim _dataAdapter As SqlDataAdapter = New SqlDataAdapter(_command)
                _dataAdapter.Fill(_ds, "OMO_Phrase")
                _dataAdapter.FillSchema(_ds, SchemaType.Mapped, "OMO_Phrase")

            End Using
        Catch ex As Exception
            Throw ex
        End Try

        Return _ds
    End Function

End Class
