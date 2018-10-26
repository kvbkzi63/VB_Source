Imports System.Data.SqlClient
Imports Syscom.Server.BO
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
Imports System.Text
Imports Syscom.Server.SQL
Imports Syscom.Comm.EXP

Public Class PubSheetDisplayBO_E1
    Inherits PubSheetDisplayBO

#Region "########## getInstance ##########"

    Private Shared instance As PubSheetDisplayBO_E1

    Public Overloads Shared Function getInstance() As PubSheetDisplayBO_E1
        If instance Is Nothing Then
            instance = New PubSheetDisplayBO_E1
        End If
        Return instance
    End Function

    Public Sub New()
    End Sub
    


    ''' <summary>
    ''' 表單開單顯示維護查詢
    ''' </summary>
    ''' <param name="Sheet_Type_Id">表單類別</param>
    ''' <param name="Sheet_Main_Display">表單顯示主分類</param>
    ''' <param name="Sheet_Sub_Display">表單顯示次分類</param>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    Public Function QueryPubSheetDisplayByCond(ByVal Sheet_Type_Id As String, ByVal Sheet_Main_Display As String, ByVal Sheet_Sub_Display As String) As System.Data.DataSet
        Dim ds As Data.DataSet


        Dim varname1 As New System.Text.StringBuilder
        varname1.Append(" SELECT b.Code_Name, " & vbCrLf)
        varname1.Append("       a.*, " & vbCrLf)
        varname1.Append("       '' " & vbCrLf)
        varname1.Append(" FROM   PUB_Sheet_Display a " & vbCrLf)
        varname1.Append("       INNER JOIN pub_syscode b " & vbCrLf)
        varname1.Append("               ON b.Type_Id = 55 " & vbCrLf)
        varname1.Append("                  AND a.sheet_type_id = b.Code_Id")
        varname1.Append("                 WHERE 1=1")

        If Sheet_Type_Id.Trim <> "" Then
            varname1.Append(" AND a.Sheet_Type_Id = '").Append(Sheet_Type_Id.Trim).Append("' ")
        End If

        If Sheet_Main_Display.Trim <> "" Then
            varname1.Append(" AND a.Sheet_Main_Display = '").Append(Sheet_Main_Display.Trim).Append("' ")
        End If

        If Sheet_Sub_Display.Trim <> "" Then
            varname1.Append(" AND a.Sheet_Sub_Display = '").Append(Sheet_Sub_Display.Trim).Append("' ")
        End If

        varname1.Append("Order By a.Sheet_Type_Id ,a.Sheet_Main_Display , a.Sheet_Sub_Display ")
       
        Try
            Using sqlConnection As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
                Dim adapter As SqlDataAdapter = New SqlDataAdapter(varname1.ToString, sqlConnection)
                ds = New Data.DataSet(tableName)
                adapter.Fill(ds, tableName)
            End Using
        Catch ex As Exception
            Throw ex

        End Try

        Return ds

    End Function


    Public Function QueryPubSyscodeTypeId55() As System.Data.DataSet
        Dim ds As Data.DataSet


        Dim varname1 As New System.Text.StringBuilder
        varname1.Append(" SELECT b.Code_Name,  a.* FROM   PUB_Sheet_Display a  INNER JOIN pub_syscode b  ON b.Type_Id = 55 AND a.sheet_type_id = b.Code_Id " & vbCrLf)

        Try
            Using sqlConnection As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
                Dim adapter As SqlDataAdapter = New SqlDataAdapter(varname1.ToString, sqlConnection)
                ds = New Data.DataSet(tableName)
                adapter.Fill(ds, tableName)
            End Using
        Catch ex As Exception
            Throw ex

        End Try

        Return ds
    End Function
#End Region

End Class
