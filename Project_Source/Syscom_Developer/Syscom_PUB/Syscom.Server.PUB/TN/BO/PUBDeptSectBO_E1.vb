Imports System.Data.SqlClient
Imports Syscom.Server.SQL
Imports Syscom.Server.CMM
Imports Syscom.Comm.EXP
Imports Syscom.Server.BO
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
Imports System.Text
Public Class PUBDeptSectBO_E1
    Inherits PubDeptSectBO

#Region "########## getInstance ##########"
    Private Shared instance As PUBDeptSectBO_E1
    Public Overloads Shared Function getInstance() As PUBDeptSectBO_E1
        If instance Is Nothing Then
            instance = New PUBDeptSectBO_E1
        End If
        Return instance
    End Function
#End Region

    ''' <summary>
    ''' 科診名稱維護查詢
    ''' </summary>
    ''' <param name="strDeptCode">科別代碼</param>
    ''' <param name="strSectId">診別代碼</param>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    Public Function queryPubDeptSectByCond(ByVal strDeptCode As String, ByVal strSectId As String) As System.Data.DataSet
        Dim ds As Data.DataSet
        Dim strSql As New StringBuilder
        strSql.Append(" Select * ")
        strSql.Append(" ,Health_Opd_Dept_Name =(SELECT Insu_Dept_Code_Name FROM PUB_Insu_Dept WHERE Insu_Dept_Code=PUB_Dept_Sect.Health_Opd_Dept_Code AND DC ='N') ")
        strSql.Append(" ,Health_Ipd_Dept_Name =(SELECT Insu_Dept_Code_Name FROM PUB_Insu_Dept WHERE Insu_Dept_Code=PUB_Dept_Sect.Health_Ipd_Dept_Code AND DC ='N') ")
        strSql.Append(" From ").Append(tableName)
        strSql.Append(" Where 1=1  ")
        If strDeptCode.Trim <> "" Then
            strSql.Append(" AND Dept_Code = '").Append(strDeptCode.Trim).Append("' ")
        End If
        If strSectId.Trim <> "" Then
            strSql.Append(" AND Section_Id = '").Append(strSectId.Trim).Append("' ")
        End If
        strSql.Append("Order By Dept_Code ")
        Try
            Using sqlConnection As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
                Dim adapter As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqlConnection)
                ds = New Data.DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, Data.SchemaType.Mapped, tableName)
            End Using
        Catch ex As Exception
            Throw ex

        End Try

        Return ds

    End Function

End Class
