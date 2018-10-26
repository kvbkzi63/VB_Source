Public Interface IJOBServiceManager_T

    Function QueryJobProjectMaintainData(ByVal Project_ID As String, ByVal Project_Name As String, ByVal Start_Date As String, ByVal End_Date As String, ByVal Project_Manager As String) As DataSet

    Function PRJDoAction(ByVal ds As DataSet) As DataSet

End Interface
