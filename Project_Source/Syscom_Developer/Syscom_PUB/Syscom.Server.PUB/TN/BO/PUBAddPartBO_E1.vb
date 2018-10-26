Imports System.Data.SqlClient
Imports System.Text
Imports Syscom.Server.SQL
'
Imports Syscom.Server.BO
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
'


Public Class PUBAddPartBO_E1
    Inherits PubAddPartBO

    'Dim log As ILog = LOGDelegate.GetInstance.getFileLogger(Me)

#Region "########## getInstance ##########"

    Private Shared instance As PUBAddPartBO_E1

    Public Overloads Shared Function getInstance() As PUBAddPartBO_E1
        If instance Is Nothing Then
            instance = New PUBAddPartBO_E1
        End If
        Return instance
    End Function

    Private Sub New()
    End Sub

#End Region

    ''' <summary>
    ''' 藥品加收部負
    ''' </summary>
    ''' <param name="OpdChargeDate">門診批價日</param>
    ''' <param name="MedicalAmt">藥品金額</param>
    ''' <returns></returns>
    ''' <remarks>For OPCAPI用</remarks>
    Public Function getMedicalPartAmt(ByVal OpdChargeDate As Date, ByVal MedicalAmt As Decimal) As DataTable
        Dim rtnValue As DataTable = Nothing
        Try
            Using conn As IDbConnection = SQLConnFactory.getInstance.getPubDBSqlConn
                conn.Open()
                rtnValue = getMedicalPartAmtForOHDBatchByAddRef(OpdChargeDate, MedicalAmt, conn)
                conn.Close()
            End Using

        Catch ex As Exception
            Throw ex
        End Try

        Return rtnValue
    End Function

    Public Function getMedicalPartAmtForOHDBatchByAddRef(ByVal OpdChargeDate As Date, ByVal MedicalAmt As Decimal, ByRef conn As IDbConnection) As DataTable
        Dim cmdStr As New StringBuilder

        'SQL
        cmdStr.Append("select ")
        cmdStr.Append("Add_Part_Amt ")
        cmdStr.Append("from " + tableName)
        cmdStr.Append(" where Effect_Date <= @OpdChargeDate AND End_Date >= @OpdChargeDate ")
        cmdStr.Append("AND Part_Type_Id= '2' ")
        cmdStr.Append("AND Start_Value <= @MedicalAmt AND End_Value >= @MedicalAmt ")

        Try
            '執行SQL
            Dim columnNames As String() = {"OpdChargeDate", "MedicalAmt"}
            Dim columnTypes As Integer() = {DataSetUtil.TypeString, DataSetUtil.TypeDecimal}

            Using paramDT As DataTable = DataSetUtil.GenDataTable("paramDT", Nothing, columnNames, columnTypes)
                paramDT.Rows.Add(New Object() {OpdChargeDate.ToShortDateString, _
                                               MedicalAmt})

                Return SQLDataUtil.getInstance.execSQLForBatch(cmdStr.ToString, paramDT, "select1", Nothing, conn)
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#Region "2009/09/10, Add By 谷官, 復健部分負擔作業(OPCRecoverPartPayUI)"

    ''' <summary>
    ''' 程式說明：取得加收部分負擔金額
    ''' 開發人員：谷官
    ''' 開發日期：2009.09.10
    ''' </summary>
    ''' <param name="outpatientSn">看診號</param>
    ''' <param name="cureCardSn">治療卡號</param>
    ''' <returns>加收部分負擔金額</returns>
    ''' <使用表單>
    ''' 1.Nick-Pub_Add_Part
    ''' </使用表單>
    ''' <修改註記>
    ''' 1.2009/07/22, XXX
    ''' </修改註記>
    Public Function getAddPartAmt(ByVal outpatientSn As String, ByVal cureCardSn As String) As Integer
        Dim cmdStr As New StringBuilder
        '----------------------------------------------------------------------------
        'Select SQL
        '----------------------------------------------------------------------------
        cmdStr.AppendLine("select")
        cmdStr.AppendLine("A.Add_Part_Amt")
        '----------------------------------------------------------------------------
        'From&Join SQL
        '----------------------------------------------------------------------------
        cmdStr.AppendLine("from Pub_Add_Part as A")
        '----------------------------------------------------------------------------
        'Where SQL
        '----------------------------------------------------------------------------
        cmdStr.AppendLine("where 1=1")
        cmdStr.AppendLine("and A.Order_Code = ")
        cmdStr.AppendLine("(select distinct top 1")
        cmdStr.AppendLine("Order_Code")
        cmdStr.AppendLine("from OMO_Order_Record as OOR")
        cmdStr.AppendLine("where 1=1")
        cmdStr.AppendLine("and OOR.Outpatient_Sn = @Outpatient_Sn")
        cmdStr.AppendLine("and OOR.Prescription_Sn = @Prescription_Sn")
        cmdStr.AppendLine("and OOR.Prescription_Type_Id = @Prescription_Type_Id")
        cmdStr.AppendLine("and OOR.Is_Cure = @Is_Cure")
        cmdStr.AppendLine(")")
        '----------------------------------------------------------------------------
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

                        sqlCmd.Parameters.AddWithValue("@Is_Cure", "Y")
                        sqlCmd.Parameters.AddWithValue("@Prescription_Type_Id", "CUR")
                        sqlCmd.Parameters.AddWithValue("@Outpatient_Sn", outpatientSn)
                        sqlCmd.Parameters.AddWithValue("@Prescription_Sn", cureCardSn)

                    End With

                    conn.Open()

                    Dim addPartAmt As Object = sqlCmd.ExecuteScalar

                    If addPartAmt Is Nothing Then
                        Return 0
                    Else
                        Return CInt(addPartAmt)
                    End If

                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    ''' <summary>
    ''' 以implDT找尋Order_Code是何有符合pub_add_part，如果有就回傳金額，如果沒有就是0
    ''' </summary>
    ''' <param name="OpdChargeDate"></param>
    ''' <param name="implDT"></param>
    ''' <param name="conn"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getAddPartAmtForREH(ByVal OpdChargeDate As Date, ByVal implDT As DataTable, ByRef conn As IDbConnection) As Integer
        Dim retAmt As Integer = 0

        Dim orderCodeStr As String = ""
        For i As Integer = 0 To implDT.Rows.Count - 1
            If i = 0 Then
                orderCodeStr = "'" & StringUtil.nvl(implDT.Rows(i).Item("Order_Code")) & "'"
            Else
                orderCodeStr += ",'" & StringUtil.nvl(implDT.Rows(i).Item("Order_Code")) & "'"
            End If
        Next

        If orderCodeStr.Length > 0 Then
            Dim cmdStr As New StringBuilder

            'SQL
            cmdStr.Append("select ")
            cmdStr.Append("Add_Part_Amt ")
            cmdStr.Append("from " + tableName)
            cmdStr.Append(" where Effect_Date <= @OpdChargeDate AND End_Date >= @OpdChargeDate ")
            cmdStr.Append("AND (Part_Type_Id= '3' OR Part_Type_Id= '4') ")
            cmdStr.Append("AND Order_Code in (" & orderCodeStr & ") ")

            Try
                '執行SQL
                Dim columnNames As String() = {"OpdChargeDate"}
                Dim columnTypes As Integer() = {DataSetUtil.TypeString}

                Using paramDT As DataTable = DataSetUtil.GenDataTable("paramDT", Nothing, columnNames, columnTypes)
                    paramDT.Rows.Add(New Object() {OpdChargeDate.ToShortDateString})

                    Using dt As DataTable = SQLDataUtil.getInstance.execSQL(cmdStr.ToString, paramDT, "select1", Nothing, conn)
                        If DataSetUtil.IsContainsData(dt) Then
                            If dt.AsEnumerable.Where(Function(r) r.Field(Of Decimal)("Add_Part_Amt") = 0).Count > 0 Then
                                retAmt = 0
                            Else
                                retAmt = CInt(dt.Rows(0).Item(0))
                            End If
                         End If
                    End Using
                End Using

            Catch ex As Exception
                Throw ex
            End Try
        End If

        Return retAmt
    End Function
#End Region
End Class
