Imports System.Text
Imports System.Data.SqlClient
Imports Syscom.Server.SQL
Imports Syscom.Server.BO
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
Imports Syscom.Comm.Utility.StringUtil
Imports Syscom.Comm.EXP

Public Class PUBOrderMappingSpecimenBO_E1
    Inherits PubOrderMappingSpecimenBO






#Region "     使用的Instance宣告 "

    Private Shared instance As PUBOrderMappingSpecimenBO_E1
    Dim tableName1 As String = "PUB_Order_Mapping_Specimen"

    Public Overloads Shared Function GetInstance() As PUBOrderMappingSpecimenBO_E1
        If instance Is Nothing Then
            instance = New PUBOrderMappingSpecimenBO_E1
        End If
        Return instance
    End Function

#End Region

    Public Function queryOrderMappingSpecimenByCond(ByVal OrderCode As String, ByVal SpecimenId As String) As DataSet

        Try
            Dim ds As DataSet
            Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = "Select  A.Time_Control_Id,  A.Control_Value   From  PUB_Order_Mapping_Specimen A , PUB_Syscode B Where   A.Order_Code in (" & OrderCode & ") And  A.Specimen_Id='" & SpecimenId & "'  And B.Type_Id='40' And A.Time_Control_Id=B.Code_Id And B.Code_Id <>'7' And B.Dc<>'Y'  Order By A.Time_Control_Id  , A.Control_Value Desc "


            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName1)
                adapter.Fill(ds, tableName1)
                adapter.FillSchema(ds, SchemaType.Mapped, tableName1)
            End Using
            Return ds
        Catch ex As Exception
            Throw ex
        End Try


    End Function

    '檢核是否可以檢體加作,回傳可加作的Order_Code
    Public Function queryCheckOrderMappingSpecimenByCond(ByVal OrderCode As String, ByVal SpecimenId As String) As DataSet

        Try
            Dim ds As DataSet
            Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = "Select Distinct A.Order_Code   From  PUB_Order_Mapping_Specimen A , PUB_Syscode B Where   A.Order_Code in (" & OrderCode & ") And  A.Specimen_Id='" & SpecimenId & "'  And B.Type_Id='40' And A.Time_Control_Id=B.Code_Id And B.Code_Id <>'7' And B.Dc<>'Y'  Order By A.Order_Code "


            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName1)
                adapter.Fill(ds, tableName1)
                adapter.FillSchema(ds, SchemaType.Mapped, tableName1)
            End Using
            Return ds
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    '檢驗檢查 檢體欄位顯示
    Public Function queryOrderMappingSpecimenByCond2(ByVal OrderCode As String) As DataSet

        Try
            Dim ds As DataSet
            Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = "Select  A.* , B.Code_Name as 'Specimen_Name'   From  PUB_Order_Mapping_Specimen A , PUB_Syscode B Where   A.Order_Code ='" & OrderCode & "' And    B.Type_Id='46' And A.Specimen_Id=B.Code_Id And  B.Dc<>'Y'  Order By A.Specimen_Sort_Value  "


            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName1)
                adapter.Fill(ds, tableName1)
                adapter.FillSchema(ds, SchemaType.Mapped, tableName1)
            End Using
            Return ds
        Catch ex As Exception
            Throw ex
        End Try


    End Function






    '檢驗檢查 容器
    Public Function queryOrderMappingSpecimenByCond3(ByVal OrderCode As String, ByVal SpecimenId As String) As DataSet

        Try
            Dim ds As DataSet
            Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = " Select  Vessel_Id  From  PUB_Order_Mapping_Specimen    Where    Order_Code ='" & OrderCode & "' And Specimen_Id ='" & SpecimenId & "' And Is_Default_Vessel ='Y' ;"
            command.CommandText += " Select  Vessel_Id  From  PUB_Order_Mapping_Specimen    Where    Order_Code ='" & OrderCode & "' And Specimen_Id ='" & SpecimenId & "'   "


            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName1)
                adapter.Fill(ds, tableName1)
                adapter.FillSchema(ds, SchemaType.Mapped, tableName1)
            End Using
            Return ds
        Catch ex As Exception
            Throw ex
        End Try


    End Function

    '檢驗檢查 檢體欄位顯示 根據某一個OrderCode 設定檢體ComboBox資料
    Public Function queryOrderMappingSpecimenByCond4(ByVal OrderCode As String) As DataSet

        Try
            Dim ds As DataSet
            Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()

            If Not OrderCode.Trim.Contains("@") Then
                command.CommandText = "Select  Distinct A.Specimen_Id , B.Code_Name as 'Specimen_Name'   From  PUB_Order_Mapping_Specimen A , PUB_Syscode B Where   A.Order_Code ='" & OrderCode & "' And    B.Type_Id='46' And A.Specimen_Id=B.Code_Id And  B.Dc<>'Y'  Order By A.Specimen_Id , B.Code_Name  "

            Else
                '選99-其他 時
                command.CommandText = "Select Code_Id as 'Specimen_Id' , Code_Name as 'Specimen_Name' from PUB_Syscode where Type_Id='46' And Dc<>'Y' And Code_Id not in (Select Specimen_Id From PUB_Order_Mapping_Specimen B Where B.Order_Code ='" & OrderCode.Replace("@", "").Trim & "') Order By Sort_Value  "

            End If
            

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName1)
                adapter.Fill(ds, tableName1)
                adapter.FillSchema(ds, SchemaType.Mapped, tableName1)
            End Using
            Return ds
        Catch ex As Exception
            Throw ex
        End Try


    End Function

End Class
