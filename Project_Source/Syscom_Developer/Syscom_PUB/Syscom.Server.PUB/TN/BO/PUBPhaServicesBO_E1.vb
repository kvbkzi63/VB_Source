Imports System.Text
Imports System.Data.SqlClient

Imports Syscom.Server.BO
Imports Syscom.Comm.TableFactory

Imports Syscom.Comm.Utility
Imports Syscom.Server.SQL

Public Class PUBPhaServicesBO_E1
    Inherits PubPhaServicesBO

#Region "########## getInstance ##########"
    Private Shared instance As PUBPhaServicesBO_E1
    Public Overloads Shared Function getInstance() As PUBPhaServicesBO_E1
        If instance Is Nothing Then
            instance = New PUBPhaServicesBO_E1
        End If
        Return instance
    End Function
    Private Sub New()
    End Sub
#End Region

#Region "For OPCAPI用 2009/07/14/ Add By 谷官"

    ''' <summary>
    ''' 將Pha_Services_Type_Id (藥事服務費類別)代入如下求得Order_Code
    ''' Order_Code為下列結果中第一筆的資料
    ''' SELECT Main_Identity_Id, Dept_Code, Pha_Services_Type_Id, Order_Code 
    ''' FROM PUB_Pha_Services 
    ''' WHERE Main_Identity_Id=保險別(身份1) 
    ''' AND (Dept_Code=院內科別代碼 OR Dept_Code=' ') 
    ''' AND Pha_Services_Type_Id =藥事服務費類別
    ''' ORDER BY Main_Identity_Id, Dept_Code,  Pha_Services_Type_Id DESC
    ''' </summary>
    ''' <param name="keyValue">
    ''' KEY = DEPT_CODE(院內科別代碼)
    ''' KEY = MAIN_IDENTITY_ID：保險別(身份1)
    ''' KEY = Pha_Services_Type_Id：藥事服務費類別
    ''' </param>
    ''' <returns></returns>
    ''' <remarks>For OPCAPI用</remarks>
    Public Function getOrderCodeForOPCAPI(ByVal keyValue As DataSet, Optional ByRef conn As IDbConnection = Nothing) As DataTable
        Dim cmdStr As New StringBuilder
        '----------------------------------------------------------------------------
        'Select SQL
        '----------------------------------------------------------------------------
        cmdStr.Append("select top 1")
        cmdStr.Append(vbCrLf + "Main_Identity_Id,")
        cmdStr.Append(vbCrLf + "Dept_Code,")
        cmdStr.Append(vbCrLf + "Pha_Services_Type_Id,")
        cmdStr.Append(vbCrLf + "Order_Code")
        '----------------------------------------------------------------------------
        'From&Join SQL
        '----------------------------------------------------------------------------
        cmdStr.Append(vbCrLf + "from " + tableName)
        '----------------------------------------------------------------------------
        'Where SQL
        '----------------------------------------------------------------------------
        cmdStr.Append(vbCrLf + "where 1=1")
        cmdStr.Append(vbCrLf + "and Main_Identity_Id=@Main_Identity_Id")
        cmdStr.Append(vbCrLf + "and (Dept_Code=@Dept_Code or Dept_Code='')")
        cmdStr.Append(vbCrLf + "and Pha_Services_Type_Id=@Pha_Services_Type_Id")
        '----------------------------------------------------------------------------
        '----------------------------------------------------------------------------
        'Order By SQL
        '----------------------------------------------------------------------------
        cmdStr.Append(vbCrLf + "ORDER BY Main_Identity_Id, Dept_Code DESC, Pha_Services_Type_Id DESC")
        '----------------------------------------------------------------------------
        Try
            Dim paramDT As DataTable = DataSetUtil.GenDataTable("paramDT", New String() {"Main_Identity_Id", "Dept_Code", "Pha_Services_Type_Id"})
            paramDT.Rows.Add(New Object() {StringUtil.nvl(keyValue.Tables(0).Rows(0).Item("MAIN_IDENTITY_ID")), _
                                           StringUtil.nvl(keyValue.Tables(0).Rows(0).Item("DEPT_CODE")), _
                                           StringUtil.nvl(keyValue.Tables(0).Rows(0).Item("Pha_Services_Type_Id"))})

            Return SQLDataUtil.getInstance.execSQL(cmdStr.ToString, paramDT, "select1", Nothing, conn)
            'Using conn As System.Data.SqlClient.SqlConnection = getConnection()
            '    Using sqlCmd As SqlCommand = New SqlCommand
            '        With sqlCmd
            '            .CommandText = cmdStr.ToString
            '            .CommandType = CommandType.Text
            '            .Connection = conn

            '            With keyValue.Tables(0).Rows(0)
            '                sqlCmd.Parameters.AddWithValue("@Main_Identity_Id", .Item("MAIN_IDENTITY_ID").ToString.Trim)
            '                sqlCmd.Parameters.AddWithValue("@Dept_Code", .Item("DEPT_CODE").ToString.Trim)
            '                sqlCmd.Parameters.AddWithValue("@Pha_Services_Type_Id", .Item("Pha_Services_Type_Id").ToString.Trim)
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
