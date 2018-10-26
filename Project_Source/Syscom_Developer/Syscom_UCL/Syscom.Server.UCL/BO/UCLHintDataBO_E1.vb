'=============================================================================
'========================== 凌群電腦 Syscom ==================================
'=============================================================================
'=======
'======= 程式名稱：給藥確認提示說明作業
'=======
'======= 程式說明：1.給藥確認提示說明作業
'=======
'======= 建立日期：2013-2-23
'=======
'======= 開發人員：Sean.Lin
'=============================================================================
'=============================================================================
'=============================================================================

Imports Syscom.Server.BO
Imports Syscom.Comm.EXP
Imports Syscom.Comm.Utility
Imports System.Data.SqlClient
Imports System.Transactions

Public Class UclHintDataBO_E1
    Inherits UclHintDataBO

#Region "     變數宣告 "
 

#End Region

#Region "     新增 Method "

#End Region

#Region "     修改 Method "

#End Region

#Region "     刪除 Method "

#End Region

#Region "     查詢 Method "

#Region "     查詢提示資料 "

    ''' <summary>
    ''' 查詢提示資料
    ''' </summary>
    ''' <param name="UIName" >作業的名稱(UI Name)</param>
    ''' <returns>Dataset</returns>
    ''' <remarks>by Sean.Lin on 2013-2-23</remarks>
    Public Function queryData(ByVal UIName As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim ds As DataSet

            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()


            Dim varname1 As New System.Text.StringBuilder
            varname1.Append("SELECT          UI_Name, " & vbCrLf)
            varname1.Append("                Serial, " & vbCrLf)
            varname1.Append("                UI_Name_CH, " & vbCrLf)
            varname1.Append("                Question_Data, " & vbCrLf)
            varname1.Append("                Answer_Data, " & vbCrLf)
            varname1.Append("                Sort_Value, " & vbCrLf)
            varname1.Append("                DC, " & vbCrLf)
            varname1.Append("                Create_User, " & vbCrLf)
            varname1.Append("                Create_Time, " & vbCrLf)
            varname1.Append("                Modified_User, " & vbCrLf)
            varname1.Append("                Modified_Time " & vbCrLf)
            varname1.Append("FROM   UCL_Hint_Data " & vbCrLf)
            varname1.Append("WHERE  UI_Name = @UI_Name " & vbCrLf)
            varname1.Append("       AND DC = 'N' " & vbCrLf)
            varname1.Append("ORDER  BY Sort_Value ")


            command.CommandText = varname1.ToString


            command.Parameters.AddWithValue("@UI_Name", UIName)

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("UCL_Hint_Data")
                adapter.Fill(ds, "UCL_Hint_Data")
            End Using

            Return ds

        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB911", ex)
        Finally
            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try

    End Function

#End Region

#Region "     查詢提示資料全部 "

    ''' <summary>
    ''' 查詢提示資料全部
    ''' </summary> 
    ''' <returns>Dataset</returns>
    ''' <remarks>by Sean.Lin on 2013-2-23</remarks>
    Public Function queryDataAll(Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim ds As DataSet

            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()


            Dim varname1 As New System.Text.StringBuilder
            varname1.Append("SELECT          UI_Name, " & vbCrLf)
            varname1.Append("                Serial, " & vbCrLf)
            varname1.Append("                UI_Name_CH, " & vbCrLf)
            varname1.Append("                Question_Data, " & vbCrLf)
            varname1.Append("                Answer_Data, " & vbCrLf)
            varname1.Append("                Sort_Value, " & vbCrLf)
            varname1.Append("                DC, " & vbCrLf)
            varname1.Append("                Create_User, " & vbCrLf)
            varname1.Append("                Create_Time, " & vbCrLf)
            varname1.Append("                Modified_User, " & vbCrLf)
            varname1.Append("                Modified_Time " & vbCrLf)
            varname1.Append("FROM   UCL_Hint_Data " & vbCrLf)
            varname1.Append("WHERE  DC = 'N' " & vbCrLf)
            varname1.Append("ORDER  BY UI_Name,Sort_Value ")


            command.CommandText = varname1.ToString



            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("UCL_Hint_Data")
                adapter.Fill(ds, "UCL_Hint_Data")
            End Using

            Return ds
        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB911", ex)
        Finally
            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try

    End Function

#End Region

#Region "     以ＰＫ查詢資料 Shadows BO - MaintainForm 必須要按照順序 "

    ''' <summary>
    '''以ＰＫ查詢資料 Shadows BO - MaintainForm 必須要按照順序
    ''' </summary>
    ''' <remarks></remarks>
    Public Shadows Function queryByPK(ByRef pk_UI_Name As System.String, ByRef pk_Serial As System.Int32, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()


            Dim varname1 As New System.Text.StringBuilder
            varname1.Append("SELECT          UI_Name, " & vbCrLf)
            varname1.Append("                Serial, " & vbCrLf)
            varname1.Append("                UI_Name_CH, " & vbCrLf)
            varname1.Append("                Question_Data, " & vbCrLf)
            varname1.Append("                Answer_Data, " & vbCrLf)
            varname1.Append("                Sort_Value, " & vbCrLf)
            varname1.Append("                DC, " & vbCrLf)
            varname1.Append("                Create_User, " & vbCrLf)
            varname1.Append("                Create_Time, " & vbCrLf)
            varname1.Append("                Modified_User, " & vbCrLf)
            varname1.Append("                Modified_Time " & vbCrLf)
            varname1.Append("FROM   UCL_Hint_Data " & vbCrLf)
            varname1.Append("WHERE   UI_Name=@UI_Name and Serial=@Serial      " & vbCrLf)
            varname1.Append("ORDER  BY Sort_Value ")



            command.CommandText = varname1.ToString

            command.Parameters.AddWithValue("@UI_Name", pk_UI_Name)
            command.Parameters.AddWithValue("@Serial", pk_Serial)
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, SchemaType.Mapped, tableName)
            End Using
            Return ds
        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB911", ex)
        Finally
            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function

#End Region


#End Region


End Class

