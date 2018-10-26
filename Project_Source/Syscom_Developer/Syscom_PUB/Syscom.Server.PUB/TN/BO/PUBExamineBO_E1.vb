Imports System.Text
Imports System.Data.SqlClient

Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
Imports Syscom.Server.SQL
Imports Syscom.Server.BO

Public Class PUBExamineBO_E1
    Inherits PubExamineBO

#Region "########## getInstance ##########"
    Private Shared instance As PUBExamineBO_E1
    Public Overloads Shared Function getInstance() As PUBExamineBO_E1
        If instance Is Nothing Then
            instance = New PUBExamineBO_E1
        End If
        Return instance
    End Function
    Private Sub New()
    End Sub
#End Region

#Region "For OPCAPI用 2009/07/15/ Add By Nick"

    ''' <summary>
    ''' 將Examine_Type_Id(診察費類別)代入如下求得Order_Code
    ''' Order_Code為下列結果中第一筆的資料
    ''' SELECT Sub_Identity_Code, Dept_Code,Examine_Type_Id, Order_Code 
    ''' FROM PUB_Examine 
    ''' WHERE Sub_Identity_Code=medicalRecordValue.Sub_Identity_Code 
    ''' AND (Dept_Code=medicalRecordValue.Dept_Code OR Dept_Code='')
    ''' AND Examine_Type_Id = 診察費類別 
    ''' ORDER BY Sub_Identity_Code,Dept_Code,Medical_Type_Id DESC
    ''' </summary>
    ''' <param name="keyValue">
    ''' KEY = Dept_Code(院內科別代碼)
    ''' KEY = Sub_Identity_Code：保險別(身份1)
    ''' KEY = Examine_Type_Id：診察費類別
    ''' </param>
    ''' <returns></returns>
    ''' <remarks>For OPCAPI用</remarks>
    Public Function getOrderCodeForOPCAPI(ByVal keyValue As DataSet, Optional ByRef conn As IDbConnection = Nothing) As DataTable
        Dim cmdStr As New StringBuilder
        '----------------------------------------------------------------------------
        'Select SQL
        '----------------------------------------------------------------------------
        cmdStr.Append("select top 1")
        cmdStr.Append(vbCrLf + "Sub_Identity_Code,")
        cmdStr.Append(vbCrLf + "Dept_Code,")
        cmdStr.Append(vbCrLf + "Section_Id,")
        cmdStr.Append(vbCrLf + "Examine_Type_Id,")
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
        cmdStr.Append(vbCrLf + "and Sub_Identity_Code=@Sub_Identity_Code")
        cmdStr.Append(vbCrLf + "and (Dept_Code=@Dept_Code or Dept_Code='')")
        cmdStr.Append(vbCrLf + "and (Section_Id=@Section_Id or Section_Id='')")
        cmdStr.Append(vbCrLf + "and (First_Reg=@First_Reg or First_Reg='')")
        cmdStr.Append(vbCrLf + "and (Medical_Type_Id=@Medical_Type_Id or Medical_Type_Id='')")
        cmdStr.Append(vbCrLf + "and Examine_Type_Id=@Examine_Type_Id")
        '----------------------------------------------------------------------------
        '----------------------------------------------------------------------------
        'Order By SQL
        '----------------------------------------------------------------------------
        cmdStr.Append(vbCrLf + "ORDER BY Sub_Identity_Code, Medical_Type_Id DESC, First_Reg DESC, Dept_Code DESC, Section_Id DESC,  Examine_Type_Id DESC")
        '----------------------------------------------------------------------------
        Try
            Dim paramDT As DataTable = DataSetUtil.GenDataTable("paramDT", New String() {"Sub_Identity_Code", "Dept_Code", "Section_Id", "Examine_Type_Id", "First_Reg", "Medical_Type_Id"})
            paramDT.Rows.Add(New Object() {StringUtil.nvl(keyValue.Tables(0).Rows(0).Item("Sub_Identity_Code")), _
                                           StringUtil.nvl(keyValue.Tables(0).Rows(0).Item("Dept_Code")), _
                                           StringUtil.nvl(keyValue.Tables(0).Rows(0).Item("Section_Id")), _
                                           StringUtil.nvl(keyValue.Tables(0).Rows(0).Item("Examine_Type_Id")), _
                                           StringUtil.nvl(keyValue.Tables(0).Rows(0).Item("First_Reg")), _
                                           StringUtil.nvl(keyValue.Tables(0).Rows(0).Item("Medical_Type_Id"))})

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
            '                sqlCmd.Parameters.AddWithValue("@Examine_Type_Id", .Item("Examine_Type_Id").ToString.Trim)
            '                sqlCmd.Parameters.AddWithValue("@First_Reg", .Item("First_Reg").ToString.Trim)
            '                sqlCmd.Parameters.AddWithValue("@Medical_Type_Id", .Item("Medical_Type_Id").ToString.Trim)
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
