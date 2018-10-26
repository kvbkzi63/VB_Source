Imports System.Data.SqlClient
Imports Syscom.Server.SQL
Imports Syscom.Server.CMM
Imports Syscom.Comm.EXP
Imports Syscom.Server.BO
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
Imports System.Text

Public Class PUBSubIdentitySetBO_E1
    Inherits PubSubIdentitySetBO
    Private Shared instance As PUBSubIdentitySetBO_E1

    Protected tableName1 As String = "PUB_Sub_Identity_Set"

 
    Public Shared Shadows Function getInstance() As PUBSubIdentitySetBO_E1
        instance = New PUBSubIdentitySetBO_E1
        Return instance

    End Function

    ''' <summary>
    ''' 查詢計價主身分資料
    ''' </summary>
    ''' <param name="subIdentityCode">身分二代碼</param>
    ''' <returns>查詢結果</returns>
    ''' <author>Ken</author>
    ''' <tables>
    ''' PUB_Sub_Identity
    ''' </tables>
    ''' <remarks></remarks>
    Public Function queryPUBSubIdentitySetMainIdentity(ByVal OrderTime As String, ByVal SubIdentityCode As String) As DataSet
 
        '1 取得計價主身份
        '    讀取身份二代碼計價設定檔(PUB_Sub_Identity_Set)之Main_Identity_Id，條件為Account_Id= ‘++’ and Order_Code = ‘++’and Dc =’N’and 
        '    醫令開立日期>=Effect_Date and醫令開立日期<=End_Date and Sub_Identity_Code = 就醫身份代碼
  
        Try
            Dim returnDS As DataSet
            Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = " Select Main_Identity_Id " & _
                                  " From " & tableName1 & " " & _
                                  " Where Effect_Date <='" & OrderTime & "' And '" & OrderTime & "'<=End_Date And Sub_Identity_Code='" & SubIdentityCode & "' And Account_Id='++' And Order_Code='++'  And DC = 'N' "
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                returnDS = New DataSet(tableName1)
                adapter.Fill(returnDS, tableName1)
                adapter.FillSchema(returnDS, SchemaType.Mapped, tableName1)
            End Using
            Return returnDS
        Catch ex As Exception
            Throw ex
        End Try

 
    End Function

End Class
