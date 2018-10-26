Imports Syscom.Comm.EXP

Public Class JOBDelegate

    Private Shared Instance As JOBDelegate

    Private Sub New()

    End Sub

    Public Shared Function getInstance() As JOBDelegate
        Try
            If Instance Is Nothing Then
                Instance = New JOBDelegate
            End If
            Return Instance
        Catch ex As Exception
            Throw ex
        End Try
    End Function


#Region " 專案維護作業 "

    ''' <summary>
    ''' 專案維護作業(查詢專案清單)
    ''' </summary>
    ''' <returns>Dataset</returns>
    ''' <remarks>by Will.Lin on 2017-04-14</remarks>
    Public Function QueryJobProjectMaintainData(ByVal Project_ID As String, ByVal Project_Name As String, ByVal Start_Date As String, ByVal End_Date As String, ByVal Project_Manager As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim m_JobProjectMaintainBS As JobDoActionBS = JobDoActionBS.GetInstance
        Try

            'Return m_JobProjectMaintainBS.QueryJobProjectMaintainData(Project_ID, Project_Name, Start_Date, End_Date, Project_Manager, conn)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"專案維護作業(查詢專案清單)"})

        End Try

    End Function


    ''' <summary>
    ''' 專案維護作業(DoAction)
    ''' </summary>
    ''' <returns>Dataset</returns>
    ''' <remarks>by Will.Lin on 2017-04-14</remarks>
    Public Function PRJDoAction(ByVal ds As DataSet) As DataSet

        Dim m_JobProjectMaintainBS As JobDoActionBS = JobDoActionBS.GetInstance
        Try

            Return m_JobProjectMaintainBS.PRJDoAction(ds)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"專案維護作業(DoAction)"})

        End Try

    End Function
#End Region

End Class
