Imports System.Data.SqlClient
Imports Syscom.Comm.EXP
Imports System.Text
Imports Syscom.Server.SQL
Imports Syscom.Comm.Utility

Imports System.Configuration

Public Class EMRMedicineRecordBO_E1
    'Inherits EmrMedicineRecordBO

#Region "########## getInstance ##########"

    Private Shared instance As EMRMedicineRecordBO_E1

    Public Overloads Shared Function getInstance() As EMRMedicineRecordBO_E1
        If instance Is Nothing Then
            instance = New EMRMedicineRecordBO_E1
        End If
        Return instance
    End Function

    Private Sub New()
    End Sub

    Protected Shadows Function getConnection() As SqlConnection
        Return SQLConnFactory.getInstance.getEmrDBSqlConn()
    End Function

#End Region

#Region "化療藥品檢核"
    ''' <summary>
    ''' 程式功能：化療藥品與相關檢核
    ''' 開發人員：markwu
    ''' 開發時間：2009/11
    ''' </summary>
    ''' <param name="Chart_no">病歷號</param>
    ''' <param name="orderCode">成大碼</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function EMRMedicineRecordRuleQuery(ByVal Chart_no As String, ByVal orderCode As String, ByVal Effect_date As String, ByVal EndDate As String) As DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = "SELECT RTRIM(Tqty) as Tqty,RTRIM(order_Code) as Order_Code " & _
            " From EMR_Medicine_Record Where Chart_No='" + Chart_no + "' and Order_Code in (" + orderCode + ")"
            If Effect_date.Equals("") Or EndDate.Equals("") Then
            Else
                command.CommandText = command.CommandText + " and Effect_Date between '" + Effect_date + "' and '" + EndDate + "'"
            End If


            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet()
                adapter.Fill(ds, "retExamineRecord")
                adapter.FillSchema(ds, SchemaType.Mapped, "retExamineRecord")
            End Using
            Return ds
        Catch ex As Exception
            Throw ex
            Syscom.Server.CMM.LOGDelegate.getInstance.dbErrorMsg(ex.StackTrace, ex)
        End Try
    End Function
#End Region

#Region "麻醉成癮藥品檢核"
    ''' <summary>
    ''' 程式功能：麻醉成癮藥品與相關檢核
    ''' 開發人員：markwu
    ''' 開發時間：2009/11
    ''' </summary>
    ''' <param name="Chart_no">病歷號</param>
    ''' <param name="orderCode">成大碼</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function EMRMedicineRecordRuleQuery(ByVal Chart_no As String, ByVal orderCode As String, ByVal EndDate As Date) As DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = "SELECT sum(Days) as Days" & _
            " From EMR_Medicine_Record Where Chart_No='" + Chart_no + "' and Order_Code = '" + orderCode + "' and Effect_Date between '" + EndDate.ToString("yyyy/MM/dd") + "' and '" + Now.ToString("yyyy/MM/dd") + "'"
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet()
                adapter.Fill(ds, "retExamineRecord")
                adapter.FillSchema(ds, SchemaType.Mapped, "retExamineRecord")
            End Using
            Return ds
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

End Class
