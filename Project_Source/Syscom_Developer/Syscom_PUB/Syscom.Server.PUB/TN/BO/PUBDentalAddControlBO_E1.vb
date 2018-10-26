Imports System.Text
Imports System.Data.SqlClient

Imports Syscom.Server.BO
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
Imports Syscom.Server.SQL

Public Class PUBDentalAddControlBO_E1
    Inherits PUBDentalAddControlBO

#Region "For OPCAPI用 2009/07/14/ Add By 谷官"

    ''' <summary>
    ''' 6.	牙科轉診加成
    ''' 若C.Is_Referral_Add = Y且從身份2取得計價身份資訊，牙科轉診加成(Is_Dental_Add) 若 = Y，再尋找如下資料
    ''' SELECT * FROM PUB_Dental_Add_Control DAC 
    ''' WHERE DAC.Dept_Code= C.Dept_Code
    ''' AND DAC.Order_Code = CD.Order_Code
    ''' AND DAC.Doctor_Code = C.Doctor_Code 
    ''' 若查到表示符合牙科轉診加成，則將查詢結果每筆的CD.Order_Code、更新的Main_Identity_Id和門診批價日
    ''' 代入呼叫Commoner類別GetDentalAddRatio (取得牙科轉診加成率) 取得retRatio(牙科轉診加成率)
    ''' UpdateDentalAddRatio = retRatio
    ''' </summary>
    ''' <param name="keyValue">
    ''' Key = Dept_Code：
    ''' Key = Order_Code：
    ''' Key = Doctor_Code：
    ''' </param>
    ''' <returns></returns>
    ''' <remarks>For OPCAPI用</remarks>
    Public Function getCalculateChargeOrderDataForOPCAPI(ByVal keyValue As DataSet, Optional ByRef conn As IDbConnection = Nothing) As DataTable
        Dim cmdStr As New StringBuilder
        '----------------------------------------------------------------------------
        'Select SQL
        '----------------------------------------------------------------------------
        cmdStr.Append("select")
        cmdStr.Append(vbCrLf + "*")
        '----------------------------------------------------------------------------
        'From&Join SQL
        '----------------------------------------------------------------------------
        cmdStr.Append(vbCrLf + "from " + tableName)
        '----------------------------------------------------------------------------
        'Where SQL
        '----------------------------------------------------------------------------
        cmdStr.Append(vbCrLf + "where 1=1")
        cmdStr.Append(vbCrLf + "and Dept_Code=@Dept_Code")
        cmdStr.Append(vbCrLf + "and Order_Code=@Order_Code")
        cmdStr.Append(vbCrLf + "and Doctor_Code=@Doctor_Code")
        '----------------------------------------------------------------------------
        '----------------------------------------------------------------------------
        'Order By SQL
        '----------------------------------------------------------------------------
        '----------------------------------------------------------------------------
        Try
            Dim paramDT As DataTable = DataSetUtil.GenDataTable("paramDT", New String() {"Dept_Code", "Order_Code", "Doctor_Code"})
            paramDT.Rows.Add(New Object() {StringUtil.nvl(keyValue.Tables(0).Rows(0).Item("Dept_Code")), _
                                           StringUtil.nvl(keyValue.Tables(0).Rows(0).Item("Order_Code")), _
                                           StringUtil.nvl(keyValue.Tables(0).Rows(0).Item("Doctor_Code"))})

            Return SQLDataUtil.getInstance.execSQL(cmdStr.ToString, paramDT, "select1", Nothing, conn)
            'Using conn As System.Data.SqlClient.SqlConnection = getConnection()
            '    Using sqlCmd As SqlCommand = New SqlCommand
            '        With sqlCmd
            '            .CommandText = cmdStr.ToString
            '            .CommandType = CommandType.Text
            '            .Connection = conn

            '            With keyValue.Tables(0).Rows(0)
            '                sqlCmd.Parameters.AddWithValue("@Dept_Code", .Item("Dept_Code").ToString.Trim)
            '                sqlCmd.Parameters.AddWithValue("@Order_Code", .Item("Order_Code").ToString.Trim)
            '                sqlCmd.Parameters.AddWithValue("@Doctor_Code", .Item("Doctor_Code").ToString.Trim)
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
End Class
