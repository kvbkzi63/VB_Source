Imports System.Data.SqlClient
Imports System.Text
Imports Syscom.Server.SQL

Public Class OPHRuleItemBO_E1

#Region "########## getInstance ##########"
    Private Shared instance As OPHRuleItemBO_E1
    Public Overloads Shared Function getInstance() As OPHRuleItemBO_E1
        If instance Is Nothing Then
            instance = New OPHRuleItemBO_E1
        End If
        Return instance
    End Function
    Private Sub New()
    End Sub
#End Region

    '''' <summary>
    '''' Get SQL connection.
    '''' </summary>
    '''' <returns>sql connection</returns>
    '''' <remarks></remarks>
    Private Function getConnection() As SqlConnection

        Return SQLConnFactory.getInstance.getOpdDBSqlConn
    End Function

    ''' <summary>
    ''' 程式功能：控管項目維護樹之初始化
    ''' 資料表：markwu-OPH_Pharmacy_Base,markwu-OPH_Rule,markwu_PUB_Syscode,markwu-PUB_Item,markwu-OPH_Rule_Reason
    ''' </summary>
    ''' <param name="Pharmacy_12_code">成大十二碼</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function OPHQueryRuleItem(ByVal Pharmacy_12_code As String) As DataSet
        Try
            'ORI.Litmit_Level沒有這個欄位
            Dim ds As DataSet
            Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = "SELECT  RTRIM(ORI.Rule_Source_Id) as Source_Id,RTRIM(PS.Code_Name) as Source_Name,ORI.Item_Code,RTRIM(PI.Item_Name) as Item_Name" & _
            ", ORI.Rule_Effect_Date,ORI.Rule_End_Date,RTRIM(ORI.Is_Single_Item) as Is_Single_Item, RTRIM(ORI.Is_Email_Notice) as Is_Email_Notice,RTRIM(ORI.Pharmacist_email) as Pharmacist_email,RTRIM(ORI.Is_Rule_Reason) as Is_Rule_Reason " & _
            ", ORR.Rule_Reason_Code as reason ,ORI.Item_NO,RTRIM(OPB.Order_Code) as Order_Code" & _
            " from OPH_Pharmacy_Base as OPB " & _
            " inner join OPH_Rule_Item as ORI on ORI.Pharmacy_12_code=OPB.Pharmacy_12_code " & _
            " inner join PUB_Syscode as PS on PS.Code_Id=ORI.Rule_Source_Id and PS.Type_Id='311' " & _
            " left join PUB_Item as PI on PI.Item_Code=ORI.Item_Code " & _
            " left join OPH_Rule_Reason as ORR on ORI.Pharmacy_12_code=ORR.Pharmacy_12_code and ORI.Rule_Source_Id=ORR.Rule_Source_Id and ORI.Item_No=ORR.Item_code  " & _
            " Where OPB.Pharmacy_12_Code='" + Pharmacy_12_code + "' and OPB.is_Control_Rule='Y' "
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("Query")
                adapter.Fill(ds, "result")
                adapter.FillSchema(ds, SchemaType.Mapped, "result")
            End Using

            Return ds
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    ''' <summary>
    ''' 功能說明：控制項目選取初始化
    ''' 開發人員：markwu
    ''' 開發時間：2009/09/28
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function QPHQueryAllItem()
        Try
            Dim s1 As String() = New String(27) {}
            For i = 0 To 21
                If i < 10 Then
                    s1(i) = "H0000" + i.ToString
                Else
                    s1(i) = "H000" + i.ToString
                End If

            Next
            s1(22) = "A00010"
            s1(23) = "D00002"
            For i = 24 To s1.Length - 1
                s1(i) = "E0000" + (i - 24).ToString
            Next
            Dim source As String = "("

            For i = 0 To s1.Length - 1
                source = source + "'" + s1(i) + "',"
            Next

            source = source.Substring(0, source.Length - 2)
            source = source + "')"


            Dim ds As DataSet
            Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = "SELECT '   ',  PI.Item_Code,RTRIM(PI.Item_Name) as Code_Name " & _
            " from PUB_Item as PI" & _
            " Where PI.Item_Code in" + source
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("Query")
                adapter.Fill(ds, "result")
                adapter.FillSchema(ds, SchemaType.Mapped, "result")
            End Using

            Return ds
        Catch ex As Exception
            Throw ex
        End Try
    End Function


#Region "同類藥檢核"
    ''' <summary>
    ''' 同類藥檢核查詢
    ''' </summary>
    ''' <param name="Phamarcy12code">成大十二碼</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function QuerySameKineMedicine(ByVal Phamarcy12code As String) As DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()

            command.CommandText = "SELECT  RTRIM(OPB.Pharmacy_12_Code) as Pharmacy_12_code ,RTRIM(OPB.Order_Code) as Order_code  from OPH_Pharmacy_Base as OPB where OPB.Class_Code in " & _
            "  (select a.Class_Code from OPH_Pharmacy_Base as A where A.Order_Code ='" + Phamarcy12code + "')"
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("Query")
                adapter.Fill(ds, "result")
                adapter.FillSchema(ds, SchemaType.Mapped, "result")
            End Using

            Return ds
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

End Class
