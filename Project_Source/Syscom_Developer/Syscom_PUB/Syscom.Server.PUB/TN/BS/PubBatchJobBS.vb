Imports System.Data.SqlClient
Imports System.Text
Imports System.ServiceModel
Imports System.Data
Imports Syscom.Comm.Utility
Imports Syscom.Comm.EXP
Imports Syscom.Server.SQL
Imports Syscom.Server.CMM
Imports Syscom.Server.BO
Imports Syscom.Comm.TableFactory
Imports System.Linq
Imports Syscom.Comm.Utility.StringUtil

Public Class PubBatchJobBS
 
    Private Shared myInstance As PubBatchJobBS
    Public Shared Function GetInstance() As PubBatchJobBS
        If myInstance Is Nothing Then
            myInstance = New PubBatchJobBS()
        End If
        Return myInstance
    End Function

#Region " 新增"

    ''' <summary>
    '''新增批次排程程式
    ''' </summary>
    ''' <param name="strFunFunctionNo">排程程式名稱</param>
    ''' <param name="paramList">排程參數</param>
    ''' <param name="strPrepareExeTime">預計執行時間</param>
    ''' <param name="strCreateUser"></param>
    ''' <returns>新增筆數</returns>
    ''' <remarks></remarks>
    Public Function insertBatchJob(ByVal strFunFunctionNo As String, ByVal paramList As List(Of String), ByVal strPrepareExeTime As String, strCreateUser As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
        
          
            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            strFunFunctionNo = nvl(strFunFunctionNo)
            strCreateUser = nvl(strCreateUser)

            If "".Equals(strFunFunctionNo) Then
                Return 0
            End If

            If paramList.Count = 0 Then
                Return 0
            End If

            If Not IsDate(strPrepareExeTime) Then
                Return 0
            End If

            If "".Equals(strCreateUser) Then
                Return 0
            End If

            Dim strConditionParam As New StringBuilder
            strConditionParam.Append("<InputData>")
            For i As Integer = 0 To paramList.Count - 1
                strConditionParam.Append("<ParamValue").Append((i + 1).ToString).Append(">")
                strConditionParam.Append(nvl(paramList(i)))
                strConditionParam.Append("</ParamValue").Append((i + 1).ToString).Append(">")
            Next
            strConditionParam.Append("</InputData>")


            Dim InsertDs As New DataSet
            InsertDs.Tables.Add(PubBatchJobDataTableFactory.getDataTableWithNoPK)
            Dim MyNewRow As DataRow = InsertDs.Tables(PubBatchJobDataTableFactory.tableName).NewRow

            MyNewRow("Fun_Function_No") = strFunFunctionNo
            MyNewRow("Condition_Param") = strConditionParam.ToString

            MyNewRow("Prepare_Exe_Time") = strPrepareExeTime
            MyNewRow("Create_User") = strCreateUser
            MyNewRow("Modified_User") = strCreateUser
 
            InsertDs.Tables(PubBatchJobDataTableFactory.tableName).Rows.Add(MyNewRow)


            Return PubBatchJobBO.GetInstance.insert(InsertDs, conn)


        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB912", ex)
        Finally
            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function
     
#End Region
 

#Region " 取得所屬資料庫的連線"

    ''' <summary>
    '''取得表格 PUB_Batch_Job 在所屬資料庫的連線
    ''' </summary>
    ''' <returns>資料庫連線</returns>
    ''' <remarks></remarks>
    Public Function getConnection() As IDbConnection
        Return SQLConnFactory.getInstance.getPUBDBSqlConn
    End Function
#End Region
 


End Class
