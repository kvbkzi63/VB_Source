' 注意: 您可以使用操作功能表上的 [重新命名] 命令同時變更程式碼、svc 和組態檔中的類別名稱 "Service"。
Imports System.Data
Imports System.Data.SqlClient
Imports Project.Server.JOB
Imports Syscom.Comm.EXP

Public Class JOBService
    Implements IJOBService

    Public Sub New()
    End Sub



#Region "2014/10/21 專案維護作業"


#Region " 專案維護作業 "

    ''' <summary>
    ''' 專案維護作業(查詢專案清單)
    ''' </summary>
    ''' <returns>Dataset</returns>
    ''' <remarks>by Will.Lin on 2017-04-14</remarks>
    Public Function QueryJobProjectMaintainData(ByVal Project_ID As String, ByVal Project_Name As String, ByVal Start_Date As String, ByVal End_Date As String, ByVal Project_Manager As String) As DataSet Implements IJOBService.QueryJobProjectMaintainData

        Dim rtnDs As DataSet = Nothing

        Try

            Dim tempDelegate As JOBDelegate = JOBDelegate.getInstance

            rtnDs = tempDelegate.QueryJobProjectMaintainData(Project_ID, Project_Name, Start_Date, End_Date, Project_Manager)

        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {" 專案維護作業(查詢專案清單)"})
        End Try

        Return rtnDs

    End Function

#End Region

#Region " 專案維護作業 "

    ''' <summary>
    ''' 專案維護作業(查詢專案清單)
    ''' </summary>
    ''' <returns>Dataset</returns>
    ''' <remarks>by Will.Lin on 2017-04-14</remarks>
    Public Function PRJDoAction(ByVal ds As DataSet) As DataSet Implements IJOBService.PRJDoAction

        Dim rtnDs As DataSet = Nothing

        Try

            Dim tempDelegate As JOBDelegate = JOBDelegate.getInstance

            rtnDs = tempDelegate.PRJDoAction(ds)

        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {" 專案維護作業(查詢專案清單)"})
        End Try

        Return rtnDs

    End Function

#End Region
#End Region
End Class
