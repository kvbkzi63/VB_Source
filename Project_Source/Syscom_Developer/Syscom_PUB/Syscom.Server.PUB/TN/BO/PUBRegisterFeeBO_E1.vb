Imports System.Text
Imports System.Data.SqlClient

Imports Syscom.Server.BO
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
Imports Syscom.Server.SQL

Public Class PUBRegisterFeeBO_E1
    Inherits PubRegisterFeeBO

#Region "########## getInstance ##########"
    Private Shared instance As PUBRegisterFeeBO_E1
    Public Overloads Shared Function getInstance() As PUBRegisterFeeBO_E1
        If instance Is Nothing Then
            instance = New PUBRegisterFeeBO_E1
        End If
        Return instance
    End Function
    Private Sub New()
    End Sub
#End Region


#Region "For OPCAPI用 2009/07/08/ Add By 谷官"

    ''' <summary>
    ''' 規則2：
    ''' Order_Code為下列結果中第一筆的資料
    ''' SELECT Sub_Identity_Code,Dept_Code,Medical_Type_Id, Order_Code 
    ''' FROM PUB_Register_Fee 
    ''' WHERE Sub_Identity_Code=保險別(身份2) 
    ''' AND (Dept_Code=院內科別代碼 OR Dept_Code=' ') 
    ''' AND (Medical_Type_Id = 就醫類型 OR Medical_Type_Id = ' ') 
    ''' AND Dc=N
    ''' ORDER BY Sub_Identity_Code,Dept_Code,Medical_Type_Id DESC
    ''' 
    ''' 再把Order_Code值代入如下：
    ''' Order_Type_Id值為O.Order_Type_Id
    ''' Account_Id值為O.Account_Id
    ''' SELECT O.Order_Type_Id,O.Account_Id 
    ''' FROM PUB_Order O 
    ''' WHERE O.Dc=N
    ''' AND O.Order_Code = Order_Code
    ''' AND O.Effect_Date ＜＝ 掛號日期
    ''' AND O.End_Date ＞ 掛號日期
    ''' </summary>
    ''' <param name="keyValue">
    ''' Key = Sub_Identity_Code：保險別(身份2)
    ''' Key = Dept_Code：院內科別代碼
    ''' Key = Medical_Type_Id：就醫類型
    ''' Key = REG_DATE：掛號日
    ''' </param>
    ''' <returns></returns>
    ''' <remarks>For OPCAPI用</remarks>
    Public Function getOrderCodeForOPCAPI(ByVal keyValue As DataSet, Optional ByRef conn As IDbConnection = Nothing) As DataTable
        Dim cmdStr As New StringBuilder
        '----------------------------------------------------------------------------
        'Select SQL
        '----------------------------------------------------------------------------
        cmdStr.Append("select Top 1")
        cmdStr.Append(vbCrLf + "Source_Id,")
        cmdStr.Append(vbCrLf + "Sub_Identity_Code,")
        cmdStr.Append(vbCrLf + "Dept_Code,")
        cmdStr.Append(vbCrLf + "Section_Id,")
        cmdStr.Append(vbCrLf + "Medical_Type_Id,")
        cmdStr.Append(vbCrLf + "Order_Code,")
        cmdStr.Append(vbCrLf + "First_Reg")
        '----------------------------------------------------------------------------
        'From&Join SQL
        '----------------------------------------------------------------------------
        cmdStr.Append(vbCrLf + "from " + tableName)
        '----------------------------------------------------------------------------
        'Where SQL
        '----------------------------------------------------------------------------
        cmdStr.Append(vbCrLf + "where 1=1")
        cmdStr.Append(vbCrLf + "and Source_Id=@Source_Id")
        cmdStr.Append(vbCrLf + "and Sub_Identity_Code=@Sub_Identity_Code")
        cmdStr.Append(vbCrLf + "and (Dept_Code=@Dept_Code or Dept_Code='')")
        cmdStr.Append(vbCrLf + "and (Section_Id=@Section_Id or Section_Id='')")
        cmdStr.Append(vbCrLf + "and (First_Reg=@First_Reg or First_Reg='')")
        cmdStr.Append(vbCrLf + "and (Medical_Type_Id=@Medical_Type_Id or Medical_Type_Id='')")
        cmdStr.Append(vbCrLf + "and Dc <> @DcY")
        '----------------------------------------------------------------------------
        '----------------------------------------------------------------------------
        'Order By SQL
        '----------------------------------------------------------------------------
        cmdStr.Append(vbCrLf + "order by Sub_Identity_Code, First_Reg DESC, Dept_Code DESC, Section_Id DESC, Medical_Type_Id DESC")
        '----------------------------------------------------------------------------
        Try
            Dim paramDT As DataTable = DataSetUtil.GenDataTable("paramDT", New String() {"Source_Id", "Sub_Identity_Code", "Dept_Code", "Section_Id", "Medical_Type_Id", "First_Reg", "DcY"})
            paramDT.Rows.Add(New Object() {StringUtil.nvl(keyValue.Tables(0).Rows(0).Item("Source_Id")), _
                                           StringUtil.nvl(keyValue.Tables(0).Rows(0).Item("Sub_Identity_Code")), _
                                           StringUtil.nvl(keyValue.Tables(0).Rows(0).Item("Dept_Code")), _
                                           StringUtil.nvl(keyValue.Tables(0).Rows(0).Item("Section_Id")), _
                                           StringUtil.nvl(keyValue.Tables(0).Rows(0).Item("Medical_Type_Id")), _
                                           StringUtil.nvl(keyValue.Tables(0).Rows(0).Item("First_Reg")), _
                                           "Y"})

            Return SQLDataUtil.getInstance.execSQL(cmdStr.ToString, paramDT, "select1", Nothing, conn)

            'Using conn As System.Data.SqlClient.SqlConnection = getConnection()
            '    Using sqlCmd As SqlCommand = New SqlCommand
            '        With sqlCmd
            '            .CommandText = cmdStr.ToString
            '            .CommandType = CommandType.Text
            '            .Connection = conn

            '            With keyValue.Tables(0).Rows(0)
            '                sqlCmd.Parameters.AddWithValue("@Sub_Identity_Code", .Item("Sub_Identity_Code").ToString.Trim)
            '                sqlCmd.Parameters.AddWithValue("@Dept_Code", .Item("Dept_Code").ToString.Trim)
            '                sqlCmd.Parameters.AddWithValue("@Section_Id", .Item("Section_Id").ToString.Trim)
            '                sqlCmd.Parameters.AddWithValue("@Medical_Type_Id", .Item("Medical_Type_Id").ToString.Trim)
            '                sqlCmd.Parameters.AddWithValue("@First_Reg", .Item("First_Reg").ToString.Trim)
            '                sqlCmd.Parameters.AddWithValue("@DcY", "Y")
            '            End With
            '        End With

            '        conn.Open()

            '        Using da As SqlDataAdapter = New SqlDataAdapter(sqlCmd)
            '            Using dt As DataTable = New DataTable("returnValue")

            '                da.Fill(dt)

            '                Return dt
            '            End Using
            '        End Using

            '    End Using
            'End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region


#Region "2009/07/13 Add By Jen"
    ''' <summary>
    ''' 回傳費用
    ''' </summary>
    ''' <param name="MainIdentityId"></param>
    ''' <param name="DeptCode"></param>
    ''' <param name="MedicalTypeId"></param>
    ''' <param name="RegDate"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function queryRegisterFee(ByVal MainIdentityId As String, ByVal DeptCode As String, ByVal MedicalTypeId As String, ByVal RegDate As Date) As DataSet

        'retFee(回傳費用)
        'SELECT OP.Price, OP.Order_Code 
        'FROM PUB_Register_Fee RF, PUB_Order_Price OP 
        'WHERE RF.Main_Identity_Id=保險別(身份1) 
        'AND RF.Dept_Code=院內科別代碼 
        'AND RF.Medical_Type_Id=就醫類型 
        'AND RF.Dc=N
        'AND RF.Dc= OP.Dc
        'AND RF.Order_Code = OP.Order_Code 
        'AND OP.Main_Identity_Id = 保險別(身份1)
        'AND OP.Effect_Date<=掛號日期
        'AND OP.End_Date > 掛號日期
        '此SQL可找出OP.Price(則為retFee)、OP.Order_Code(醫令項目代碼：取得優待身份折扣時會用到)


        Dim ds As DataSet

        Dim cmdStr As New StringBuilder
        '----------------------------------------------------------------------------
        'Select SQL
        '----------------------------------------------------------------------------
        cmdStr.AppendLine("SELECT ")
        cmdStr.AppendLine("OP.Price, OP.Order_Code ")

        '----------------------------------------------------------------------------
        'From&Join SQL
        '----------------------------------------------------------------------------
        cmdStr.AppendLine("FROM PUB_Register_Fee RF, PUB_Order_Price OP ")
        '----------------------------------------------------------------------------
        'Where SQL
        '----------------------------------------------------------------------------
        cmdStr.AppendLine("WHERE RF.Main_Identity_Id = @MainIdentityId ")
        cmdStr.AppendLine("AND RF.Dept_Code = @DeptCode ")
        cmdStr.AppendLine("AND RF.Medical_Type_Id = @MedicalTypeId ")
        cmdStr.AppendLine("AND RF.Dc <> @CancelY ")
        cmdStr.AppendLine("AND RF.Dc = OP.Dc ")
        cmdStr.AppendLine("AND RF.Order_Code = OP.Order_Code ")
        cmdStr.AppendLine("AND OP.Main_Identity_Id = @MainIdentityId ")
        cmdStr.AppendLine("AND OP.Effect_Date <= @RegDate ")
        cmdStr.AppendLine("AND OP.End_Date > @RegDate ")

        '----------------------------------------------------------------------------
        'Order By SQL
        '----------------------------------------------------------------------------
        '----------------------------------------------------------------------------
        Try
            Using conn As System.Data.SqlClient.SqlConnection = getConnection()
                Using sqlCmd As SqlCommand = New SqlCommand
                    With sqlCmd
                        .CommandText = cmdStr.ToString
                        .CommandType = CommandType.Text
                        .Connection = conn

                        sqlCmd.Parameters.AddWithValue("@RegDate", RegDate)
                        sqlCmd.Parameters.AddWithValue("@MainIdentityId", MainIdentityId)
                        sqlCmd.Parameters.AddWithValue("@MedicalTypeId", MedicalTypeId)
                        sqlCmd.Parameters.AddWithValue("@DeptCode", DeptCode)

                        sqlCmd.Parameters.AddWithValue("@CancelY", "Y")

                    End With

                    conn.Open()

                    Using adapter As SqlDataAdapter = New SqlDataAdapter(sqlCmd)
                        ds = New DataSet(tableName)
                        adapter.Fill(ds, tableName)
                        adapter.FillSchema(ds, SchemaType.Mapped, tableName)
                    End Using
                    Return ds

                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try




    End Function
#End Region

End Class
