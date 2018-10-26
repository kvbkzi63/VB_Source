Imports System.Configuration
Imports System.ServiceModel
Imports JOBClientServiceFactory
Imports JOBClientServiceFactory.JOBServiceReference

Partial Class JOBServiceManager


#Region "TN"


    ''' <summary>
    ''' 查詢專案清單(依據傳入條件)
    ''' </summary>
    ''' <param name="Project_ID">專案代號</param>
    ''' <param name="Project_Name">專案名稱</param>
    ''' <param name="Start_Date">專案起日</param>
    ''' <param name="End_Date">專案迄日</param>
    ''' <param name="Project_Manager">PM</param>
    ''' <returns></returns>
    Public Function QueryJobProjectMaintainData(ByVal Project_ID As String, ByVal Project_Name As String, ByVal Start_Date As String, ByVal End_Date As String, ByVal Project_Manager As String) As DataSet Implements IJOBServiceManager.QueryJobProjectMaintainData
        Dim _client As JOBServiceClient = Nothing

        Try
            _client = getJOBService()
            Using scope As OperationContextScope = New OperationContextScope(_client.InnerChannel)
                Return _client.QueryJobProjectMaintainData(Project_ID, Project_Name, Start_Date, End_Date, Project_Manager)
            End Using ' before close
        Catch fex As FaultException
            Throw fex
        Catch ex As Exception
            Throw ex
        Finally
            If _client IsNot Nothing Then
                If _client.State = ServiceModel.CommunicationState.Opened Then
                    _client.Close()
                ElseIf Not (_client.State = ServiceModel.CommunicationState.Opened) Then
                    _client.Abort()
                End If
            End If
        End Try
    End Function


    ''' <summary>
    ''' 查詢專案清單(PRJDoAction)
    ''' </summary>
    ''' <param name="ds">傳入相關參數(Action必須放在第0個Table)</param>
    ''' <returns></returns>
    Public Function PRJDoAction(ByVal ds As DataSet) As DataSet Implements IJOBServiceManager.PRJDoAction
        Dim _client As JOBServiceClient = Nothing

        Try
            _client = getJOBService()
            Using scope As OperationContextScope = New OperationContextScope(_client.InnerChannel)
                Return _client.PRJDoAction(ds)
            End Using ' before close
        Catch fex As FaultException
            Throw fex
        Catch ex As Exception
            Throw ex
        Finally
            If _client IsNot Nothing Then
                If _client.State = ServiceModel.CommunicationState.Opened Then
                    _client.Close()
                ElseIf Not (_client.State = ServiceModel.CommunicationState.Opened) Then
                    _client.Abort()
                End If
            End If
        End Try
    End Function

#End Region


End Class

