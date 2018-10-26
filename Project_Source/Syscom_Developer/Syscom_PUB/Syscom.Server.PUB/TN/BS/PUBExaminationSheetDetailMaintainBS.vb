Imports System.Data.SqlClient
Imports System.Text
Imports System.Transactions

Imports Syscom.Server.SQL
Imports Syscom.Server.BO
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
Imports Syscom.Server.SNC
Imports Syscom.Comm.LOG
Imports log4net

''' <summary>
'''  檢核醫令明細維護
''' </summary>
''' <remarks></remarks>
Public Class PUBExaminationSheetDetailMaintainBS

    Private Shared m_Instance As PUBExaminationSheetDetailMaintainBS = Nothing

    Private Enum StrictRuleType
        OrderCode = 0
        DeptCode = 1
        SexId = 2
        DoctCode = 3
    End Enum

    Public Shared ReadOnly Property GetInstance() As PUBExaminationSheetDetailMaintainBS
        Get
            If m_Instance Is Nothing Then
                m_Instance = New PUBExaminationSheetDetailMaintainBS
            End If

            Return m_Instance
        End Get
    End Property

    ''' <summary>
    ''' Get SQL connection.
    ''' </summary>
    ''' <author>Ken</author>
    ''' <date>2009-12-15</date>
    ''' <remarks></remarks>
    Private Function GetSqlConnection() As SqlConnection

        Return SQLConnFactory.getInstance.getPubDBSqlConn
    End Function

    ''' <summary>
    ''' 初始化資料
    ''' </summary>
    ''' <returns></returns>
    ''' <author>Ken</author>
    ''' <date>2009-12-15</date>
    ''' <remarks></remarks>
    Public Function GetInitInfo(ByVal User As String) As DataSet

        Dim _ds As New DataSet

        '取得表單代碼
        Dim _dtSheetCode As DataTable = Me.GetAvalibleSheet(User).Tables("PUB_Sheet").Copy
        _ds.Tables.Add(_dtSheetCode)

        '取得取得檢體
        Dim _dtSpecimen As DataTable = PUBSysCodeBO_E1.getInstance.queryPUBSysCodebyCombobox("46").Tables(0).Copy
        _dtSpecimen.TableName = "Specimen"
        _ds.Tables.Add(_dtSpecimen)

        '取得取得容器
        Dim _dtVessel As DataTable = PUBSysCodeBO_E1.getInstance.queryPUBSysCodebyCombobox("47").Tables(0).Copy
        _dtVessel.TableName = "Vessel"
        _ds.Tables.Add(_dtVessel)

        '取得時間單位
        Dim _dtTimeUnit As DataTable = PUBSysCodeBO_E1.getInstance.queryPUBSysCodebyCombobox("40").Tables(0).Copy
        _dtTimeUnit.TableName = "Time_Unit"
        _ds.Tables.Add(_dtTimeUnit)

        '取得性別代碼
        Dim _dtSexType As DataTable = PUBSysCodeBO_E1.getInstance.queryPUBSyscodeAll("21").Tables(0).Copy
        _dtSexType.TableName = "Sex_Type"
        _ds.Tables.Add(_dtSexType)

        '取得科室代碼
        Dim _dtDeptCode As DataTable = Me.queryPUBDepartmentBySmallDept().Tables(0).Copy 'PUBDepartmentBO_E1.getInstance.queryPUBDepartmentBySmallDept().Tables(0).Copy
        _dtDeptCode.TableName = "Dept_Code"
        _ds.Tables.Add(_dtDeptCode)

        Return _ds
    End Function

    Private Function queryPUBDepartmentBySmallDept() As DataSet
        Dim _ds As New DataSet

        Dim _date As Date = Date.Now

        Dim var1 As New System.Text.StringBuilder
        var1.AppendFormat("SELECT Rtrim(Dept_Code), " & vbCrLf)
        var1.AppendFormat("       Dept_Name " & vbCrLf)
        var1.AppendFormat("FROM   PUB_Department " & vbCrLf)
        var1.AppendFormat("WHERE  ( LEN (Dept_Code )=2 Or LEN (Dept_Code )=3 )  " & vbCrLf)
        var1.AppendFormat("       AND (DC <> 'Y' " & vbCrLf)
        var1.AppendFormat("             OR DC IS NULL) " & vbCrLf)
        var1.AppendFormat("       AND Effect_Date <= '{0}' " & vbCrLf, _date.ToShortDateString)
        var1.AppendFormat("       AND (End_Date >= '{0}' " & vbCrLf, _date.ToShortDateString)
        var1.AppendFormat("             OR End_Date IS NULL) " & vbCrLf)

        Try
            Using _sqlConnection As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
                Dim _dataAdapter As SqlDataAdapter = New SqlDataAdapter(var1.ToString, _sqlConnection)
                _dataAdapter.Fill(_ds, "PUB_Department")
            End Using
        Catch ex As Exception
            Throw ex
        End Try

        Return _ds
    End Function

    Private Function GetAvalibleSheet(ByVal User As String) As DataSet
        Dim var1 As New System.Text.StringBuilder
        var1.Append("SELECT RTRIM(Y.Sheet_Code) AS Sheet_Code, " & vbCrLf)
        var1.Append("       Y.Sheet_Name " & vbCrLf)
        var1.Append("FROM   PUB_Department Z " & vbCrLf)
        var1.Append("       INNER JOIN PUB_Sheet Y " & vbCrLf)
        var1.Append("         ON Z.Dept_Code = Y.Dept_Code " & vbCrLf)
        var1.Append("            AND Z.DC = 'N' " & vbCrLf)
        var1.Append("            AND Y.Dc = 'N' " & vbCrLf)
        var1.Append("            AND Y.Sheet_Type_Id = '1' " & vbCrLf)
        'var1.Append("WHERE  Z.Belong_Dept_Code IN (SELECT CASE " & vbCrLf)
        'var1.Append("                                       WHEN (SELECT A.Dept_Code " & vbCrLf)
        'var1.Append("                                             FROM   PUB_Employee A " & vbCrLf)
        'var1.Append("                                             WHERE  Employee_Code = @Employee_Code) LIKE 'A5%' THEN Z.Belong_Dept_Code " & vbCrLf)
        '2013-12-13 by PauseChen : 增加斗六資訊室人員權限,不然資訊室人員都看不到任何表單
        '                                                          詢問昭華後由PUB_Employee.Professal_Kind_Id='Y306'可以區分是否為資訊室人員
        'If HospUtil.isGeneral = False Then  '斗六分院
        '    var1.Append("                                       WHEN (SELECT A.Professal_Kind_Id " & vbCrLf)
        '    var1.Append("                                             FROM   PUB_Employee A " & vbCrLf)
        '    var1.Append("                                             WHERE  Employee_Code = @Employee_Code) ='Y306' THEN Z.Belong_Dept_Code " & vbCrLf)
        'End If
        'var1.Append("                                       ELSE (SELECT C.Belong_Dept_Code " & vbCrLf)
        'var1.Append("                                             FROM   PUB_Employee B, " & vbCrLf)
        'var1.Append("                                                    PUB_Department C " & vbCrLf)
        'var1.Append("                                             WHERE  B.Dept_Code = C.Dept_Code " & vbCrLf)
        'var1.Append("                                                    AND B.Employee_Code = @Employee_Code) " & vbCrLf)
        'var1.Append("                                     END) " & vbCrLf)

        Dim _ds As New DataSet

        Try
            Using _sqlConnection As SqlConnection = GetSqlConnection()

                Dim _command As New SqlCommand(var1.ToString(), _sqlConnection)
                _command.CommandType = CommandType.Text
                _command.Parameters.AddWithValue("@Employee_Code", User)

                Dim _dataAdapter As SqlDataAdapter = New SqlDataAdapter(_command)
                _dataAdapter.Fill(_ds, "PUB_Sheet")
                '_dataAdapter.FillSchema(_ds, SchemaType.Mapped, "PUB_Sheet")

            End Using
        Catch ex As Exception
            Throw ex
        End Try

        Return _ds
    End Function

    ''' <summary>
    ''' 依據輸入之Sheet Code, 找出此Sheet中所包含之Order.
    ''' </summary>
    ''' <param name="SheetCode">表單代碼</param>
    ''' <returns></returns>
    ''' <author>Ken</author>
    ''' <date>2009-12-15</date>
    ''' <tables>
    ''' PUB_Sheet_Detail
    ''' PUB_Order
    ''' </tables>
    ''' <remarks></remarks>
    Public Function GetOrderListBySheetCode(ByVal SheetCode As String) As DataSet

        Dim var1 As New System.Text.StringBuilder
        var1.Append("SELECT RTRIM(A.Sheet_Code) AS Sheet_Code, " & vbCrLf)
        var1.Append("       RTRIM(A.Order_Code) AS Order_Code, " & vbCrLf)
        var1.Append("       B.Order_En_Name     AS Order_Name, " & vbCrLf)
        var1.Append("       A.Separate_Mark, " & vbCrLf)
        var1.Append("       A.Exclusive_Order_Code, " & vbCrLf)
        var1.Append("       A.Is_Print_Indication, " & vbCrLf)
        var1.Append("       A.Is_InstantlyRpt, " & vbCrLf)
        var1.Append("       A.Is_Limit_Health, " & vbCrLf)
        var1.Append("       A.Is_Print_Order_Note, " & vbCrLf)
        var1.Append("       A.Order_Note, " & vbCrLf)
        var1.Append("       A.Order_Entry_Note, " & vbCrLf)
        var1.Append("       A.Sheet_Detail_Sort_Value AS Sort_Value, " & vbCrLf)
        var1.Append("       C.Is_Scheduled AS Is_Scheduled" & vbCrLf)
        var1.Append("FROM   PUB_Sheet_Detail A " & vbCrLf)
        var1.Append("       INNER JOIN PUB_Order B " & vbCrLf)
        var1.Append("       ON A.Order_Code = B.Order_Code " & vbCrLf)
        var1.Append("       INNER JOIN PUB_Order_Examination C " & vbCrLf)
        var1.Append("       ON A.Order_Code = C.Order_Code " & vbCrLf)
        var1.Append("WHERE  A.Sheet_Code = @Sheet_Code " & vbCrLf)
        var1.Append("       AND A.Dc = 'N' " & vbCrLf)
        var1.Append("       AND B.Dc = 'N' " & vbCrLf)
        var1.Append("ORDER  BY Sheet_Detail_Sort_Value " & vbCrLf)

        Dim var2 As New System.Text.StringBuilder
        var2.Append("SELECT Lis_Sheet_Limit_Cnt, " & vbCrLf)
        var2.Append("       Is_Print_Indication " & vbCrLf)
        var2.Append("FROM   PUB_Sheet " & vbCrLf)
        var2.Append("WHERE  Sheet_Code = @Sheet_Code " & vbCrLf)


        Dim _ds As New DataSet

        Try
            Using _sqlConnection As SqlConnection = GetSqlConnection()

                Dim _command As New SqlCommand(var1.ToString(), _sqlConnection)
                _command.CommandType = CommandType.Text
                _command.Parameters.AddWithValue("@Sheet_Code", SheetCode)

                Dim _dataAdapter As SqlDataAdapter = New SqlDataAdapter(_command)
                _dataAdapter.Fill(_ds, "Order_List")
                '_dataAdapter.FillSchema(_ds, SchemaType.Mapped, "Order_List")

                Dim _command2 As New SqlCommand(var2.ToString(), _sqlConnection)
                _command2.CommandType = CommandType.Text
                _command2.Parameters.AddWithValue("@Sheet_Code", SheetCode)

                Dim _dataAdapter2 As SqlDataAdapter = New SqlDataAdapter(_command2)
                _dataAdapter2.Fill(_ds, "Sheet_Limit_Cnt")

            End Using
        Catch ex As Exception
            Throw ex
        End Try

        Return _ds
    End Function

    ''' <summary>
    ''' 取得Order之詳細資料
    ''' </summary>
    ''' <param name="OrderCode">醫令代碼</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetOrderInfo(ByVal OrderCode As String) As DataSet

        Dim var1 As New System.Text.StringBuilder
        var1.Append("SELECT RTRIM(A.Specimen_Id)     AS Specimen_Id, " & vbCrLf)
        var1.Append("       RTRIM(A.Vessel_Id)       AS Vessel_Id, " & vbCrLf)
        var1.Append("       CASE " & vbCrLf)
        var1.Append("         WHEN A.Control_Value IS NULL THEN 'N' " & vbCrLf)
        var1.Append("         ELSE 'Y' " & vbCrLf)
        var1.Append("       END                      AS As_AddTo_Specimen, " & vbCrLf)
        var1.Append("       A.Control_Value, " & vbCrLf)
        var1.Append("       RTRIM(A.Time_Control_Id) AS Time_Control_Id, " & vbCrLf)
        var1.Append("       A.Is_Default, " & vbCrLf)
        var1.Append("       A.Is_Default_Vessel " & vbCrLf)
        var1.Append("FROM   PUB_Order_Mapping_Specimen A " & vbCrLf)
        var1.Append("       INNER JOIN PUB_Syscode B " & vbCrLf)
        var1.Append("         ON B.Type_Id = 46 " & vbCrLf)
        var1.Append("            AND A.Specimen_Id = B.Code_Id " & vbCrLf)
        var1.Append("       Left JOIN PUB_Syscode C " & vbCrLf)
        var1.Append("         ON C.Type_Id = 47 " & vbCrLf)
        var1.Append("            AND A.Vessel_Id = C.Code_Id " & vbCrLf)
        var1.Append("WHERE  A.Order_Code = CASE " & vbCrLf)
        var1.Append("                        WHEN @Order_Code IS NULL THEN A.Order_Code " & vbCrLf)
        var1.Append("                        ELSE @Order_Code " & vbCrLf)
        var1.Append("                      END " & vbCrLf)
        var1.Append("ORDER  BY A.Specimen_Sort_Value " & vbCrLf)

        Dim var2 As New System.Text.StringBuilder
        var2.Append("SELECT RTRIM(A.Order_Code) AS Order_Code, " & vbCrLf)
        var2.Append("       A.Effect_Date, " & vbCrLf)
        var2.Append("       A.End_Date " & vbCrLf)
        var2.Append("FROM   PUB_Order A " & vbCrLf)
        var2.Append("WHERE  Order_Code = @Order_Code " & vbCrLf)
        var2.Append("       AND Dc = 'N' " & vbCrLf)

        Dim _ds As New DataSet

        Try
            Using _sqlConnection As SqlConnection = GetSqlConnection()

                Dim _command As New SqlCommand(var1.ToString(), _sqlConnection)
                _command.CommandType = CommandType.Text
                _command.Parameters.AddWithValue("@Order_Code", OrderCode)

                Dim _dataAdapter As SqlDataAdapter = New SqlDataAdapter(_command)
                _dataAdapter.Fill(_ds, "PUB_Order_Mapping_Specimen")
                '_dataAdapter.FillSchema(_ds, SchemaType.Mapped, "PUB_Order_Mapping_Specimen")

                Dim _command2 As New SqlCommand(var2.ToString(), _sqlConnection)
                _command2.CommandType = CommandType.Text
                _command2.Parameters.AddWithValue("@Order_Code", OrderCode)

                Dim _dataAdapter2 As SqlDataAdapter = New SqlDataAdapter(_command2)
                _dataAdapter2.Fill(_ds, "PUB_Order")
                '_dataAdapter2.FillSchema(_ds, SchemaType.Mapped, "PUB_Order")

            End Using
        Catch ex As Exception
            Throw ex
        End Try

        '取得Order之Rule
        _ds.Tables.Add(Me.GetRulesByOrderCode(OrderCode).Tables("Rules").Copy)

        Return _ds
    End Function

    ''' <summary>
    ''' 將修改過的資訊寫回資料庫
    ''' </summary>
    ''' <param name="InputData">欲寫入之資料庫</param>
    ''' <returns></returns>
    ''' <author>Ken</author>
    ''' <date>2009-12-20</date>
    ''' <remarks></remarks>
    Public Function WriteBackEditedInfo(ByVal InputData As DataSet, ByVal User As String) As Int32

        Dim _dtSpecimenVessel = InputData.Tables("SpecimenVessel")
        Dim _dtSelectoryOrder = InputData.Tables("SelectoryOrder")
        Dim _dtDuplicateOrder = InputData.Tables("DuplicateOrder")
        Dim _dtSeparatedOrder = InputData.Tables("SeparatedOrder")
        Dim _dtExclusiveOrder = InputData.Tables("ExclusiveOrder")
        Dim _dtOrderInfo = InputData.Tables("OrderInfo")

        Dim _orderInfos = From dr In _dtOrderInfo _
                          Select New With {.SheetCode = dr.Field(Of String)("Sheet_Code"), _
                                           .OrderCode = dr.Field(Of String)("Order_Code"), _
                                           .EffectDate = dr.Field(Of Date)("Effect_Date"), _
                                           .EndDate = dr.Field(Of Date)("End_Date"), _
                                           .LisSheetLimitCnt = dr.Field(Of Int32)("Lis_Sheet_Limit_Cnt"), _
                                           .IsPrintIndicationSheet = dr.Field(Of String)("Is_Print_Indication_Sheet"), _
                                           .IsPrintIndication = dr.Field(Of String)("Is_Print_Indication"),
                                           .IsInstantlyRpt = dr.Field(Of String)("Is_InstantlyRpt"), _
                                           .IsLimitHealth = dr.Field(Of String)("Is_Limit_Health"), _
                                           .IsScheduled = dr.Field(Of String)("Is_Scheduled"), _
                                           .IsPrintOrderNote = dr.Field(Of String)("Is_Print_Order_Note"), _
                                           .SeparateMark = dr.Field(Of Int32)("Separate_Mark"), _
                                           .IsStandalone = dr.Field(Of String)("Is_Standalone"), _
                                           .Note = dr.Field(Of String)("Order_Note"), _
                                           .OrderEntryNote = dr.Field(Of String)("Order_Entry_Note"), _
                                           .SexLimit = dr.Field(Of String)("Sex_Id"), _
                                           .DeptLimit = dr.Field(Of String)("Dept_Code"), _
                                           .DoctLimit = dr.Field(Of String)("Doct_Code"), _
                                           .ExtNo = dr.Field(Of String)("Ext_No")}

        Dim _orderInfo = _orderInfos.First
        Dim _IsScheduled As String = _orderInfo.IsScheduled
        Dim _ExtNo As String = _orderInfo.ExtNo
        Dim _cnt As Int32 = 0
        Using trans As TransactionScope = SQLConnFactory.getInstance.getRequiredTransactionScope

            '==================== Start Transaction ====================

            '========== PUB_Order ==========
            If Not Me.HasMatchedRecord(_orderInfo.OrderCode, _orderInfo.EffectDate, _orderInfo.EndDate) Then

                'if true, 則原來的dc不動
                Dim _isDcNewRecord As Boolean = IIf(_orderInfo.EffectDate > Now.Date, True, False)

                '取得Dc="N"之Order, 新增Order之其它資訊由此Order提供
                Dim _drPubOrder As DataRow = Nothing
                Try
                    Dim _dtPubOrder = Me.GetPubOrderInfo(_orderInfo.OrderCode).Tables("PUB_Order").AsEnumerable
                    Dim _maxEffectDate As Date? = _dtPubOrder.Max(Function(r) r.Field(Of Date)("Effect_Date"))
                    _drPubOrder = _dtPubOrder.Where(Function(r) r.Field(Of Date)("Effect_Date") = _maxEffectDate).Max
                Catch ex As InvalidOperationException
                    'TODO: 若取無資料，則直接新增一筆
                End Try

                'Step 1. Dc掉此Order
                If Not _isDcNewRecord Then _cnt += Me.DcAnOrder(_orderInfo.OrderCode, User)
                _cnt += Me.DcAnOrder(_orderInfo.OrderCode, User)
                'Step 2. 刪除Effect_Date > _orderInfo.EffectDate 之Order
                _cnt += Me.DeleteOrderWitchEffectDateIsAfterInputDate(_orderInfo.EffectDate, _orderInfo.OrderCode)
                'Step 3. Select出 _orderInfo.EffectDate Between Effect_Date And End_Date之Order, 並將其End_Date改為 _orderInfo.EffectDate.AddDate(-1)
                _cnt += Me.SelectWitchNewEffectDateIsBetweenEffectDateAndEndDate(_orderInfo.EffectDate, _orderInfo.OrderCode, User)
                'Setp 4. 新增一筆Order, 其基本資料使用原先所Select出來之
                Dim _dsNewPubOrder As New DataSet
                Dim _dtNewPubOrder As DataTable = PubOrderDataTableFactory.getDataTableWithSchema
                _dtNewPubOrder.ImportRow(_drPubOrder)
                _dtNewPubOrder.Rows(0)("Effect_Date") = _orderInfo.EffectDate
                _dtNewPubOrder.Rows(0)("End_Date") = _orderInfo.EndDate
                _dtNewPubOrder.Rows(0)("Dc") = IIf(_isDcNewRecord, "Y", "N")
                _dtNewPubOrder.Rows(0)("Create_User") = User
                _dtNewPubOrder.Rows(0)("Create_Time") = Now

                If _orderInfo.IsLimitHealth = "Y" Then
                    _dtNewPubOrder.Rows(0)("Insu_Cover_Opd") = "H"
                    _dtNewPubOrder.Rows(0)("Insu_Cover_Emg") = "H"
                    _dtNewPubOrder.Rows(0)("Insu_Cover_Ipd") = "H"
                Else
                    _dtNewPubOrder.Rows(0)("Insu_Cover_Opd") = "Y"
                    _dtNewPubOrder.Rows(0)("Insu_Cover_Emg") = "Y"
                    _dtNewPubOrder.Rows(0)("Insu_Cover_Ipd") = "Y"

                End If
                
                _dsNewPubOrder.Tables.Add(_dtNewPubOrder)
                _cnt += PubOrderBO.GetInstance.insert(_dsNewPubOrder)
            End If
            '========== END PUB_Order ==========

            '==== 若更新健檢註記，則同步更新下面欄位 =====
            If _orderInfo.IsLimitHealth = "Y" Then
                _cnt += UpdateIsLimintHealthByOrderCode(_orderInfo.OrderCode, "H", "H", "H")
            Else
                _cnt += UpdateIsLimintHealthByOrderCode(_orderInfo.OrderCode, "Y", "Y", "Y")
            End If

            '==== Pub_Order_Mapping_Specimen =====
            _cnt += Me.UpdatePubOrderMappingSpecimen(_orderInfo.OrderCode, _dtSpecimenVessel)

            '==== PUB_Order_Examination =====
            _cnt += Me.UpdatePUBOrderExamination(_orderInfo.OrderCode, _dtSpecimenVessel, _IsScheduled)

            '========== PUB_Sheet ============
            _cnt += Me.UpdatePubSheet(_orderInfo.SheetCode, _orderInfo.IsPrintIndicationSheet, _orderInfo.LisSheetLimitCnt, User)

            '========== PUB_Sheet_Detail ===========
            _cnt += Me.ProcessUpdatePubSheetDetail(_orderInfo.SheetCode, _orderInfo.OrderCode, _orderInfo.IsPrintIndication, _orderInfo.IsPrintOrderNote, _orderInfo.Note, _orderInfo.OrderEntryNote, _orderInfo.LisSheetLimitCnt, _
                                                   _dtSelectoryOrder, _dtSeparatedOrder, _dtExclusiveOrder, _orderInfo.SeparateMark, _orderInfo.IsStandalone, _orderInfo.IsInstantlyRpt, _orderInfo.IsLimitHealth, User)

            '========== PUB_Sheet_Group ===========
            _cnt += Me.UpdatePubSheetGroup(_orderInfo.SheetCode)

            '== PUB_Rule_Class, Pub_Rule, PUB_Rule_Detail ==
            _cnt += Me.UpdateOrderRule(_orderInfo.OrderCode, _dtDuplicateOrder, _orderInfo.SexLimit, _orderInfo.DeptLimit, _orderInfo.DoctLimit, _ExtNo, User)

            '==================== End Transaction ====================
            trans.Complete()
        End Using

        Return _cnt
    End Function

#Region "Pub_Order處理"

    Private Function HasMatchedRecord(ByVal OrderCode As String, ByVal EffectDate As Date, ByVal EndDate As Date) As Boolean

        Dim var1 As New System.Text.StringBuilder
        var1.Append("SELECT COUNT(*) AS Cnt " & vbCrLf)
        var1.Append("FROM   PUB_Order " & vbCrLf)
        var1.Append("WHERE  Order_Code = @Order_Code " & vbCrLf)
        var1.Append("       AND Effect_Date = @Effect_Date " & vbCrLf)
        var1.Append("       AND End_Date = @End_Date ")

        Dim _ds As New DataSet
        Try
            Using _sqlConnection As SqlConnection = GetSqlConnection()
                _sqlConnection.Open()

                Dim _command As New SqlCommand(var1.ToString(), _sqlConnection)
                _command.CommandType = CommandType.Text
                _command.CommandType = CommandType.Text
                _command.Parameters.AddWithValue("@Effect_Date", EffectDate)
                _command.Parameters.AddWithValue("@End_Date", EndDate)
                _command.Parameters.AddWithValue("@Order_Code", OrderCode)
                Dim _dataAdapter As SqlDataAdapter = New SqlDataAdapter(_command)
                _dataAdapter.Fill(_ds, "PUB_Order")
                '_dataAdapter.FillSchema(_ds, SchemaType.Mapped, "PUB_Order")

            End Using
        Catch ex As Exception
            Throw ex
        End Try

        Dim _dt As DataTable = _ds.Tables("PUB_Order")

        Return IIf(_dt.Rows(0)(0) = 0, False, True)
    End Function

    ''' <summary>
    ''' 依輸入的Order_Code取得Dc == "N" 之Order
    ''' </summary>
    ''' <param name="OrderCode">醫令碼</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetPubOrderInfo(ByVal OrderCode As String) As DataSet
        Dim var1 As New System.Text.StringBuilder
        var1.Append("SELECT * " & vbCrLf)
        var1.Append("FROM   PUB_Order " & vbCrLf)
        var1.Append("WHERE  Order_Code = @Order_Code " & vbCrLf)
        var1.Append("       AND DC = 'N' ")

        Dim _ds As New DataSet

        Try
            Using _sqlConnection As SqlConnection = GetSqlConnection()

                Dim _command As New SqlCommand(var1.ToString(), _sqlConnection)
                _command.CommandType = CommandType.Text
                _command.Parameters.AddWithValue("@Order_Code", OrderCode)

                Dim _dataAdapter As SqlDataAdapter = New SqlDataAdapter(_command)
                _dataAdapter.Fill(_ds, "PUB_Order")
                '_dataAdapter.FillSchema(_ds, SchemaType.Mapped, "PUB_Order")

            End Using
        Catch ex As Exception
            Throw ex
        End Try

        Return _ds
    End Function

    ''' <summary>
    ''' Dc掉一筆Order
    ''' </summary>
    ''' <param name="OrderCode">醫令代碼</param>
    ''' <param name="User">操作者</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function DcAnOrder(ByVal OrderCode As String, ByVal User As String) As Int32

        Dim var1 As New System.Text.StringBuilder
        var1.Append("UPDATE PUB_Order " & vbCrLf)
        var1.Append("SET    Dc = 'Y', " & vbCrLf)
        var1.Append("       Modified_User = @User, " & vbCrLf)
        var1.Append("       Modified_Time = @Now " & vbCrLf)
        var1.Append("WHERE  Order_Code = @Order_Code  " & vbCrLf)
        var1.Append("       AND Dc = 'N' ")

        Dim _cnt As Int32 = 0
        Try
            Using _sqlConnection As SqlConnection = GetSqlConnection()
                _sqlConnection.Open()

                Dim _command As New SqlCommand(var1.ToString(), _sqlConnection)
                _command.CommandType = CommandType.Text
                '_command.Parameters.AddWithValue("@Effect_Date", OriginalOrder.Field(Of Date)("Effect_Date"))
                '_command.Parameters.AddWithValue("@End_Date", EffectDate.AddDays(-1))
                _command.Parameters.AddWithValue("@Order_Code", OrderCode)
                _command.Parameters.AddWithValue("@User", User)
                _command.Parameters.AddWithValue("@Now", Now.Date)

                _cnt += _command.ExecuteNonQuery()

                _sqlConnection.Close()
            End Using
        Catch ex As Exception
            Throw ex
        End Try

        Return _cnt
    End Function

    ''' <summary>
    ''' 刪除資料庫中，有效日期>=新的有效日期的Order
    ''' </summary>
    ''' <param name="EffectDate">新有效日期</param>
    ''' <param name="OrderCode">醫令碼</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function DeleteOrderWitchEffectDateIsAfterInputDate(ByVal EffectDate As Date, ByVal OrderCode As String) As Int32

        Dim var1 As New System.Text.StringBuilder
        var1.Append("DELETE PUB_Order " & vbCrLf)
        var1.Append("WHERE  Order_Code = @Order_Code " & vbCrLf)
        var1.Append("       AND Effect_Date >= @Effect_Date ")

        Dim _cnt As Int32 = 0
        Try
            Using _sqlConnection As SqlConnection = GetSqlConnection()
                _sqlConnection.Open()

                Dim _command As New SqlCommand(var1.ToString(), _sqlConnection)
                _command.CommandType = CommandType.Text
                _command.Parameters.AddWithValue("@Effect_Date", EffectDate)
                _command.Parameters.AddWithValue("@Order_Code", OrderCode)

                _cnt += _command.ExecuteNonQuery()

                _sqlConnection.Close()
            End Using
        Catch ex As Exception
            Throw ex
        End Try

        Return _cnt
    End Function

    Private Function SelectWitchNewEffectDateIsBetweenEffectDateAndEndDate(ByVal NewEffectDate As Date, ByVal OrderCode As String, ByVal User As String) As Int32

        Dim var1 As New System.Text.StringBuilder
        var1.Append("UPDATE PUB_Order " & vbCrLf)
        var1.Append("SET    End_Date = @End_Date, " & vbCrLf)
        var1.Append("       Modified_User = @User, " & vbCrLf)
        var1.Append("       Modified_Time = @Now " & vbCrLf)
        var1.Append("WHERE  @New_Effect_Date BETWEEN Effect_Date AND End_Date  " & vbCrLf)
        var1.Append("       AND Order_Code = @Order_Code ")

        Dim _cnt As Int32 = 0
        Try
            Using _sqlConnection As SqlConnection = GetSqlConnection()
                _sqlConnection.Open()

                Dim _command As New SqlCommand(var1.ToString(), _sqlConnection)
                _command.CommandType = CommandType.Text
                _command.Parameters.AddWithValue("@New_Effect_Date", NewEffectDate)
                _command.Parameters.AddWithValue("@End_Date", NewEffectDate.AddDays(-1))
                _command.Parameters.AddWithValue("@Order_Code", OrderCode)
                _command.Parameters.AddWithValue("@User", User)
                _command.Parameters.AddWithValue("@Now", Now.Date)
                _cnt += _command.ExecuteNonQuery()

                _sqlConnection.Close()
            End Using
        Catch ex As Exception
            Throw ex
        End Try

        Return _cnt
    End Function
#End Region

#Region "Pub_Order_Mapping_Specimen"

    ''' <summary>
    ''' 更新PUB_Order_Mapping_Specimen之資料
    ''' </summary>
    ''' <param name="OrderCode">醫令代碼</param>
    ''' <param name="SpecimenVessel">欲更新之資料</param>
    ''' <returns></returns>
    ''' <author>Ken</author>
    ''' <last_modified>2009-12-27</last_modified>
    ''' <remarks></remarks>
    Private Function UpdatePubOrderMappingSpecimen(ByVal OrderCode As String, ByVal SpecimenVessel As DataTable) As Int32

        Dim var0 As New System.Text.StringBuilder
        var0.Append("DELETE PUB_Order_Mapping_Specimen " & vbCrLf)
        var0.Append("WHERE  Order_Code = @Order_Code ;" & vbCrLf)

        Dim var1 As New System.Text.StringBuilder
        var1.Append("INSERT INTO PUB_Order_Mapping_Specimen " & vbCrLf)
        var1.Append("            (Order_Code, " & vbCrLf)
        var1.Append("             Specimen_Id, " & vbCrLf)
        var1.Append("             Vessel_Id, " & vbCrLf)
        var1.Append("             Is_Default, " & vbCrLf)
        var1.Append("             Specimen_Sort_Value, " & vbCrLf)
        var1.Append("             Control_Value, " & vbCrLf)
        var1.Append("             Time_Control_Id, " & vbCrLf)
        var1.Append("             Is_Default_Vessel) " & vbCrLf)
        var1.Append("VALUES      (@Order_Code, " & vbCrLf)
        var1.Append("             @Specimen_Id, " & vbCrLf)
        var1.Append("             @Vessel_Id, " & vbCrLf)
        var1.Append("             @Is_Default, " & vbCrLf)
        var1.Append("             @Specimen_Sort_Value, " & vbCrLf)
        var1.Append("             @Control_Value, " & vbCrLf)
        var1.Append("             @Time_Control_Id, " & vbCrLf)
        var1.Append("             @Is_Default_Vessel) " & vbCrLf)

        Dim _cnt As Int32 = 0
        Try
            Using _sqlConnection As SqlConnection = GetSqlConnection()
                _sqlConnection.Open()

                '先刪除此Order_Code下的所有資料
                Dim _command0 As New SqlCommand(var0.ToString(), _sqlConnection)
                _command0.CommandType = CommandType.Text
                _command0.Parameters.AddWithValue("@Order_Code", OrderCode)
                _cnt += _command0.ExecuteNonQuery

                Dim _counter As Int32 = 1
                '新增資料至Table.
                For Each _dr As DataRow In SpecimenVessel.Rows
                    Dim _command As New SqlCommand(var1.ToString(), _sqlConnection)
                    _command.CommandType = CommandType.Text
                    _command.Parameters.AddWithValue("@Order_Code", OrderCode)
                    _command.Parameters.AddWithValue("@Specimen_Id", _dr("Specimen_Id"))
                    _command.Parameters.AddWithValue("@Vessel_Id", _dr("Vessel_Id"))
                    _command.Parameters.AddWithValue("@Is_Default", IIf(IsDBNull(_dr("Is_Default")), "N", _dr("Is_Default")))
                    _command.Parameters.AddWithValue("@Specimen_Sort_Value", _counter)
                    _command.Parameters.AddWithValue("@Control_Value", _dr("Control_Value"))
                    _command.Parameters.AddWithValue("@Time_Control_Id", _dr("Time_Control_Id"))
                    _command.Parameters.AddWithValue("@Is_Default_Vessel", IIf(IsDBNull(_dr("Is_Default_Vessel")), "N", _dr("Is_Default_Vessel")))
                    _cnt += _command.ExecuteNonQuery()
                    _counter += 1
                Next

                _sqlConnection.Close()
            End Using
        Catch ex As Exception
            Throw ex
        End Try

        Return _cnt
    End Function

#End Region

#Region "PUB_Order_Examination"

    ''' <summary>
    ''' 更新 PUB_Order_Examination 中的資料
    ''' </summary>
    ''' <param name="OrderCode">醫令代碼</param>
    ''' <param name="SpecimenVessel">檢體/容器之資料</param>
    ''' <returns></returns>
    ''' <date>2010-05-14</date>
    ''' <remarks></remarks>
    Private Function UpdatePUBOrderExamination(ByVal OrderCode As String, ByVal SpecimenVessel As DataTable, ByVal IsSchedule As String) As Int32

        Dim var0 As New System.Text.StringBuilder
        var0.Append("UPDATE PUB_Order_Examination " & vbCrLf)
        var0.Append("SET    Default_Specimen_Id = NULL, " & vbCrLf)
        var0.Append("       Default_Vessel_Id = NULL, " & vbCrLf)
        var0.Append("       Is_Scheduled = 'N' " & vbCrLf)
        var0.Append("WHERE  Order_Code = @Order_Code " & vbCrLf)

        Dim var1 As New System.Text.StringBuilder
        var1.Append("UPDATE PUB_Order_Examination " & vbCrLf)
        var1.Append("SET    Default_Specimen_Id = @Default_Specimen_Id, " & vbCrLf)
        var1.Append("       Default_Vessel_Id = @Default_Vessel_Id, " & vbCrLf)
        var1.Append("       Is_Scheduled = @Is_Scheduled " & vbCrLf)
        var1.Append("WHERE  Order_Code = @Order_Code " & vbCrLf)

        Dim _cnt As Int32 = 0
        Try
            Using _sqlConnection As SqlConnection = GetSqlConnection()
                If _sqlConnection.State <> ConnectionState.Open Then _sqlConnection.Open()

                Dim _command0 As New SqlCommand(var0.ToString(), _sqlConnection)
                _command0.CommandType = CommandType.Text
                _command0.Parameters.AddWithValue("@Order_Code", OrderCode)
                _cnt += _command0.ExecuteNonQuery()

                Dim _dtE = SpecimenVessel.AsEnumerable

                '取出檢體
                Dim _defaultSpecimen As String = _dtE.Where(Function(r) r("Is_Default") = "Y").Select(Function(r) r("Specimen_Id").ToString.TrimEnd).FirstOrDefault
                If _defaultSpecimen Is Nothing Then
                    Return 0 '若無選擇預設容器，則回傳0
                End If

                '取出容器
                Dim _defalultVessel As String = _dtE.Where(Function(r) r("Specimen_Id") = _defaultSpecimen AndAlso r("Is_Default") = "Y").Select(Function(r) r("Vessel_Id").ToString.TrimEnd).FirstOrDefault
                If _defalultVessel Is Nothing Then _defalultVessel = String.Empty

                Dim _command As New SqlCommand(var1.ToString(), _sqlConnection)
                _command.CommandType = CommandType.Text
                _command.Parameters.AddWithValue("@Order_Code", OrderCode)
                _command.Parameters.AddWithValue("@Default_Specimen_Id", _defaultSpecimen)
                _command.Parameters.AddWithValue("@Default_Vessel_Id", _defalultVessel)
                _command.Parameters.AddWithValue("@Is_Scheduled", IsSchedule)
                _cnt += _command.ExecuteNonQuery()

            End Using
        Catch ex As Exception
            Throw ex
        End Try

        Return _cnt
    End Function

#End Region

#Region "Pub_Sheet"

    Private Function UpdatePubSheet(ByVal SheetCode As String, ByVal IsPrintIndication As String, ByVal LisSheetLimitCnt As Int32, ByVal User As String) As Int32

        Dim var1 As New System.Text.StringBuilder
        var1.Append("UPDATE PUB_Sheet " & vbCrLf)
        var1.Append("SET    Is_Print_Indication = @Is_Print_Indication, " & vbCrLf)
        var1.Append("       Lis_Sheet_Limit_Cnt = @Lis_Sheet_Limit_Cnt, " & vbCrLf)
        var1.Append("       Modified_User = @User, " & vbCrLf)
        var1.Append("       Modified_Time = @Now " & vbCrLf)
        var1.Append("WHERE  Sheet_Code = @Sheet_Code ")

        Dim _cnt As Int32 = 0
        Try
            Using _sqlConnection As SqlConnection = GetSqlConnection()
                _sqlConnection.Open()

                Dim _command As New SqlCommand(var1.ToString(), _sqlConnection)
                _command.CommandType = CommandType.Text
                _command.Parameters.AddWithValue("@Sheet_Code", SheetCode)
                _command.Parameters.AddWithValue("@Is_Print_Indication", IsPrintIndication)
                _command.Parameters.AddWithValue("@Lis_Sheet_Limit_Cnt", LisSheetLimitCnt)
                _command.Parameters.AddWithValue("@User", User)
                _command.Parameters.AddWithValue("@Now", Now)
                _cnt += _command.ExecuteNonQuery()

                _sqlConnection.Close()
            End Using
        Catch ex As Exception
            Throw ex
        End Try

        Return _cnt
    End Function
#End Region

#Region "Pub_Sheet_Detail"

    ''' <summary>
    ''' 查詢Pub_Sheet_Detail中符合輸入條件之資料
    ''' </summary>
    ''' <param name="SheetCode">表單代碼</param>
    ''' <param name="OrderCode">醫令代碼</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function QuerySheetDetailBySheetAndOrderCode(ByVal SheetCode As String, ByVal OrderCode As String) As DataSet

        Dim var1 As New System.Text.StringBuilder
        var1.Append("SELECT RTRIM(A.Sheet_Code) AS Sheet_Code, " & vbCrLf)
        var1.Append("       RTRIM(A.Order_Code) AS Order_Code, " & vbCrLf)
        var1.Append("       B.Order_Name, " & vbCrLf)
        var1.Append("       A.Separate_Mark, " & vbCrLf)
        var1.Append("       A.Exclusive_Order_Code, " & vbCrLf)
        var1.Append("       A.Is_Print_Indication, " & vbCrLf)
        var1.Append("       A.Is_Print_Order_Note, " & vbCrLf)
        var1.Append("       A.Is_InstantlyRpt, " & vbCrLf)
        var1.Append("       A.Is_Limit_Health, " & vbCrLf)
        var1.Append("       A.Order_Note, " & vbCrLf)
        var1.Append("       A.Dc " & vbCrLf)
        var1.Append("FROM   PUB_Sheet_Detail A " & vbCrLf)
        var1.Append("       INNER JOIN PUB_Order B " & vbCrLf)
        var1.Append("         ON A.Sheet_Code = @Sheet_Code " & vbCrLf)
        var1.Append("            AND A.Order_Code = @Order_Code " & vbCrLf)
        var1.Append("            AND A.Order_Code = B.Order_Code " & vbCrLf)
        var1.Append("            AND B.Dc = 'N' " & vbCrLf)

        Dim _ds As New DataSet

        Try
            Using _sqlConnection As SqlConnection = GetSqlConnection()

                Dim _command As New SqlCommand(var1.ToString(), _sqlConnection)
                _command.CommandType = CommandType.Text
                _command.Parameters.AddWithValue("@Sheet_Code", SheetCode)
                _command.Parameters.AddWithValue("@Order_Code", OrderCode)

                Dim _dataAdapter As SqlDataAdapter = New SqlDataAdapter(_command)
                _dataAdapter.Fill(_ds, "PUB_Sheet_Detail")
                '_dataAdapter.FillSchema(_ds, SchemaType.Mapped, "PUB_Sheet_Detail")
            End Using
        Catch ex As Exception
            Throw ex
        End Try

        Return _ds
    End Function

    ''' <summary>
    ''' 新增一筆Order至Pub_Sheet_Detail
    ''' </summary>
    ''' <param name="InputData">欲新增之資料</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function InsertIntoPubSheetDetail(ByVal InputData As DataSet) As Int32
        'Sheet_Detail_Sort_Value要取最大號+1

        Dim _dtInputData As DataTable = InputData.Tables(0)

        Dim var1 As New System.Text.StringBuilder
        var1.Append("SELECT ISNULL(MAX(Sheet_Detail_Sort_Value), 0) + 1 AS Sheet_Detail_Sort_Value " & vbCrLf)
        var1.Append("FROM   PUB_Sheet_Detail " & vbCrLf)
        var1.Append("WHERE  Sheet_Code = @Sheet_Code " & vbCrLf)

        Dim _cnt As Int32 = 0

        Try
            Using _trans As TransactionScope = SQLConnFactory.getInstance.getRequiredTransactionScope

                Using _sqlConnection As SqlConnection = GetSqlConnection()
                    If _sqlConnection.State <> ConnectionState.Open Then _sqlConnection.Open()

                    For Each _drInputData As DataRow In _dtInputData.Rows

                        '取出Sheet_Code
                        Dim _sheetCode As String = _drInputData("Sheet_Code").ToString

                        Dim _command As New SqlCommand(var1.ToString(), _sqlConnection)
                        _command.CommandType = CommandType.Text
                        _command.Parameters.AddWithValue("@Sheet_Code", _sheetCode)

                        Dim _ds As New DataSet
                        Dim _dataAdapter As SqlDataAdapter = New SqlDataAdapter(_command)
                        _dataAdapter.Fill(_ds, "PUB_Sheet_Detail")

                        '取出新的Sheet_Detail_Sort_Value
                        Dim _newSheetDetailSortValue As Int32 = _ds.Tables("PUB_Sheet_Detail").Rows(0)("Sheet_Detail_Sort_Value")

                        Dim _newDs As New DataSet
                        Dim _newDt As DataTable = PubSheetDetailDataTableFactory.getDataTableWithSchema
                        '填入新的Sheet_Detail_Sort_Value
                        _drInputData("Sheet_Detail_Sort_Value") = _newSheetDetailSortValue
                        _newDt.ImportRow(_drInputData)
                        _newDs.Tables.Add(_newDt)

                        '寫入Table
                        _cnt += PubSheetDetailBO.GetInstance.insert(_newDs, _sqlConnection)

                        'marked on 2011-02-14
                        'Me.UpdateTreatmentTypeIdOfPubOrder(_drInputData("Order_Code").ToString.TrimEnd, "3", String.Empty, _sqlConnection)
                    Next

                    _trans.Complete()
                    _sqlConnection.Close()
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try

        Return _cnt
    End Function

    ''' <summary>
    ''' 將Pub_Sheet_Code中符合條件的資料Dc掉
    ''' </summary>
    ''' <param name="InputData">欲Dc之資料</param>
    ''' <param name="User">操作者</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function UpdateDcOfPubSheetDetail(ByVal InputData As DataSet, ByVal User As String) As Int32

        Dim _dtInputData As DataTable = InputData.Tables(0)

        Dim _cnt As Integer = 0
        Try
            Using _sqlConnection As SqlConnection = GetSqlConnection()
                Using _trans As TransactionScope = SQLConnFactory.getInstance.getRequiredTransactionScope


                    For Each _drInputData As DataRow In _dtInputData.Rows
                        If _sqlConnection.State <> ConnectionState.Open Then _sqlConnection.Open()

                        Dim _sheetCode As String = _drInputData("Sheet_Code").ToString.Trim
                        Dim _orderCode As String = _drInputData("Order_Code").ToString.Trim



                        '刪除Pub_Sheet_Detail的值
                        _cnt += PubSheetDetailBO.GetInstance.delete(_sheetCode, _orderCode, _sqlConnection)

                        '刪除Pub_Order_Examination的值
                        _cnt += PubOrderExaminationBO.GetInstance.delete(_orderCode, _sqlConnection)

                        '將Pub_Order的treatment_Type_Id的欄位值改為NULL
                        _cnt += Me.UpdateTreatmentTypeIdOfPubOrder(_orderCode, "", User, _sqlConnection)
                    Next


                    'For Each _drInputData As DataRow In _dtInputData.Rows
                    '    If _sqlConnection.State <> ConnectionState.Open Then _sqlConnection.Open()

                    '    Dim var1 As New System.Text.StringBuilder
                    '    var1.Append("UPDATE PUB_Sheet_Detail " & vbCrLf)
                    '    var1.Append("SET    Dc = @Dc, " & vbCrLf)

                    '    If _drInputData("Sort_Value").ToString.TrimEnd.Length <> 0 Then
                    '        var1.Append("       Sheet_Detail_Sort_Value = @Sheet_Detail_Sort_Value, " & vbCrLf)
                    '    End If

                    '    var1.Append("       Modified_User = @User, " & vbCrLf)
                    '    var1.Append("       Modified_Time = @Now " & vbCrLf)
                    '    var1.Append("WHERE  Sheet_Code = @Sheet_Code " & vbCrLf)
                    '    var1.Append("       AND Order_Code = @Order_Code " & vbCrLf)

                    '    Dim _sheetCode As String = _drInputData("Sheet_Code").ToString.TrimEnd
                    '    Dim _orderCode As String = _drInputData("Order_Code").ToString.TrimEnd
                    '    Dim _sortValue As String = _drInputData("Sort_Value").ToString.TrimEnd
                    '    Dim _dc As String = _drInputData("Dc").ToString.TrimEnd
                    '    Dim _treatmentTypeId As String = String.Empty
                    '    If _dc.ToUpper = "Y" Then
                    '        _treatmentTypeId = String.Empty
                    '    Else
                    '        If InputData.Tables.Contains("Treatment_Type_Id") Then
                    '            Dim _dtTreatmentTypeId As DataTable = InputData.Tables("Treatment_Type_Id")
                    '            Dim _drTreatmentTypeId As DataRow = _dtTreatmentTypeId.Rows(0)
                    '            _treatmentTypeId = _drTreatmentTypeId("Treatment_Type_Id").ToString.TrimEnd
                    '        End If
                    '    End If

                    '    Dim _command As New SqlCommand(var1.ToString(), _sqlConnection)
                    '    _command.CommandType = CommandType.Text
                    '    _command.Parameters.AddWithValue("@Sheet_Code", _sheetCode)
                    '    _command.Parameters.AddWithValue("@Order_Code", _orderCode)
                    '    _command.Parameters.AddWithValue("@Sheet_Detail_Sort_Value", _sortValue)
                    '    _command.Parameters.AddWithValue("@Dc", _dc)
                    '    _command.Parameters.AddWithValue("@User", User)
                    '    _command.Parameters.AddWithValue("@Now", Now)
                    '    _cnt += _command.ExecuteNonQuery()

                    '    'makred on 2011-02-14
                    '    If _dc.ToUpper = "Y" Then
                    '        PubOrderExaminationBO.GetInstance.delete(_orderCode, _sqlConnection)
                    '    End If
                    '    Me.UpdateTreatmentTypeIdOfPubOrder(_orderCode, _treatmentTypeId, User, _sqlConnection)
                    'Next

                    _trans.Complete()
                    _sqlConnection.Close()
                End Using

            End Using

        Catch ex As Exception
            Throw ex
        End Try

        Return _cnt
    End Function

    ''' <summary>
    ''' 更新PUB_Order中的Treatment_Type_Id
    ''' </summary>
    ''' <param name="OrderCode">醫令代碼</param>
    ''' <param name="TreatmentTypeId">Treatment_Type_Id</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function UpdateTreatmentTypeIdOfPubOrder(ByVal OrderCode As String, ByVal TreatmentTypeId As String, ByVal User As String, ByRef conn As IDbConnection) As Int32

        Dim var1 As New System.Text.StringBuilder
        var1.Append("UPDATE PUB_Order " & vbCrLf)
        var1.Append("SET    Treatment_Type_Id = @Treatment_Type_Id, " & vbCrLf)
        var1.Append("       Modified_User = @User, " & vbCrLf)
        var1.Append("       Modified_Time = @Now " & vbCrLf)
        var1.Append("WHERE  Order_Code = @Order_Code " & vbCrLf)
        var1.Append("       AND Dc = 'N' " & vbCrLf)


        Dim connFlag As Boolean = conn Is Nothing

        Dim _sqlConnection As SqlConnection = conn

        Dim _cnt As Int32 = 0
        Try
            If connFlag Then
                _sqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
            End If
            If _sqlConnection.State <> ConnectionState.Open Then _sqlConnection.Open()

            Dim _command As New SqlCommand(var1.ToString(), _sqlConnection)
            _command.CommandType = CommandType.Text
            _command.Parameters.AddWithValue("@Order_Code", OrderCode)
            _command.Parameters.AddWithValue("@Treatment_Type_Id", TreatmentTypeId)
            _command.Parameters.AddWithValue("@User", User)
            _command.Parameters.AddWithValue("@Now", Now)

            _cnt += _command.ExecuteNonQuery()

        Catch ex As Exception
            Throw ex
        Finally
            If connFlag AndAlso _sqlConnection IsNot Nothing Then
                _sqlConnection.Close()
                _sqlConnection.Dispose()
                _sqlConnection = Nothing
            End If
        End Try

        Return _cnt

    End Function

    Private Function ProcessUpdatePubSheetDetail(ByVal SheetCode As String, _
                                                 ByVal OrderCode As String, _
                                                 ByVal IsPrintIndication As String, _
                                                 ByVal IsPrintOrderNote As String, _
                                                 ByVal OrderNote As String, _
                                                 ByVal OrderEntryNote As String, _
                                                 ByVal LisSheetLimitCnt As Int32, _
                                                 ByVal SelectoryOrders As DataTable, _
                                                 ByVal SeparatedOrders As DataTable, _
                                                 ByVal ExclusiveOrders As DataTable, _
                                                 ByVal SeparateMark As Int32, _
                                                 ByVal IsStandalone As String, _
                                                 ByVal IsInstantlyRpt As String, _
                                                 ByVal IsLimitHealth As String, _
                                                 ByVal User As String) As Int32
        Dim _cnt As Int32 = 0
        Using _sqlConnection As SqlConnection = GetSqlConnection()
            Try
                _sqlConnection.Open()
                '##########################################################################
                '處理拆單醫令
                If SeparatedOrders.Rows.Count = 0 AndAlso IsStandalone = "N" Then
                    _cnt += Me.UpdateSeparateMakrOfPubSheetDetail(SheetCode, _
                                                                  OrderCode, _
                                                                  0, _
                                                                  IsPrintIndication, _
                                                                  IsPrintOrderNote, _
                                                                  OrderNote, _
                                                                  OrderEntryNote, _
                                                                  LisSheetLimitCnt, _
                                                                  IsInstantlyRpt, _
                                                                  IsLimitHealth, _
                                                                  User, _
                                                                  _sqlConnection)
                Else '多筆拆單 or 獨立拆單
                    '依Sheet_Code, Order_Code取出資料,
                    'Separate_Mark取出同Sheet_Code, Order_Code中的Separate_Mark最大號+1
                    _cnt += Me.UpdateSeparateMakrOfPubSheetDetail(SheetCode, _
                                                                  OrderCode, _
                                                                  IsPrintIndication, _
                                                                  IsPrintOrderNote, _
                                                                  OrderNote, _
                                                                  OrderEntryNote, _
                                                                  LisSheetLimitCnt, _
                                                                  IsInstantlyRpt, _
                                                                  IsLimitHealth, _
                                                                  User, _
                                                                  _sqlConnection)


                    Dim _separateMark As Int32 = Me.GetSepareteMark(SheetCode, OrderCode, _sqlConnection)

                    'update其它order之Separate_Mark成新的Separate_Mark
                    For Each _dr As DataRow In SeparatedOrders.Rows
                        _cnt += Me.UpdateSeparateMakrOfPubSheetDetail(_dr.Field(Of String)("Sheet_Code"), _
                                                                      _dr.Field(Of String)("Order_Code"), _
                                                                      _separateMark, _
                                                                      User, _
                                                                      _sqlConnection)
                    Next
                End If

                '若被移出拆單醫令的order只有一筆，則將其Separate_Mark更新為0
                '要先移除SelectoryOrders中，SeparatedOrders存在之Order，再去做check！！
                Dim _exclusiveOrderTmp1 As EnumerableRowCollection(Of String) = ExclusiveOrders.AsEnumerable.Select(Function(r) r("Order_Code").ToString)
                Dim _selectoryOrderTmp1 As EnumerableRowCollection(Of DataRow) = SelectoryOrders.AsEnumerable.Where(Function(r) Not _exclusiveOrderTmp1.Contains(r("Order_Code").ToString))
                '若 r("Separate_Mark") = SeparateMark(所選Order之Seraprate_Makr) 代表自原來的集合中移除
                Dim _separatedOrderCodes = _selectoryOrderTmp1.Where(Function(r) r("Separate_Mark") = SeparateMark).Select(Function(r) r.Field(Of String)("Order_Code"))
                If _separatedOrderCodes.Count = 1 Then
                    _cnt += Me.UpdateSeparateMakrOfPubSheetDetail(SheetCode, _
                                                                  _separatedOrderCodes.FirstOrDefault, _
                                                                  0, _
                                                                  IsPrintIndication, _
                                                                  IsPrintOrderNote, _
                                                                  OrderNote, _
                                                                  LisSheetLimitCnt, _
                                                                  IsInstantlyRpt, _
                                                                  IsLimitHealth, _
                                                                  User, _
                                                                  _sqlConnection)
                End If
                '##########################################################################

                '處理互斥醫令
                'Setp 1. 取出所有與此Order_Code互斥的Order.
                Dim _allExclusiveOrder = ExclusiveOrders.AsEnumerable.Select(Function(r) r.Field(Of String)("Order_Code")).ToList

                'Step 2 把此Sheet中此Order_Code的Exclusive_Order_Code清空, 與清除其它跟此Order_Code的關聯
                Dim _cntUpdated1 As Int32 = 0
                _cntUpdated1 += Me.UpdateExclusiveOrderCodeOfPubSheetDetail(SheetCode, OrderCode, User, _sqlConnection)

                'Step 3.
                'for loop
                '新增Ordeor_Code與Exclusive_Order_Code的關聯
                For Each _OrderCodeX As String In _allExclusiveOrder

                    _cnt += Me.UpdateExclusiveOrderCodeOfPubSheetDetail(SheetCode, OrderCode, _OrderCodeX, User, _sqlConnection)
                    _cnt += Me.UpdateExclusiveOrderCodeOfPubSheetDetail(SheetCode, _OrderCodeX, OrderCode, User, _sqlConnection)
                Next
                '##########################################################################
            Catch ex As Exception
                Throw ex
            Finally
                _sqlConnection.Close()
            End Try
        End Using

        Return _cnt
    End Function

    Private Function GetSepareteMark(ByVal SheetCode As String, ByVal OrderCode As String, ByVal conn As SqlConnection) As Int32

        Dim var1 As New System.Text.StringBuilder
        var1.Append("SELECT Separate_Mark " & vbCrLf)
        var1.Append("FROM   PUB_Sheet_Detail " & vbCrLf)
        var1.Append("WHERE  Sheet_Code = @Sheet_Code " & vbCrLf)
        var1.Append("       AND Order_Code = @Order_Code ")

        Dim _ds As New DataSet

        Try
            Dim _sqlConnection As SqlConnection = conn

            Dim _command As New SqlCommand(var1.ToString(), _sqlConnection)
            _command.CommandType = CommandType.Text
            _command.Parameters.AddWithValue("@Sheet_Code", SheetCode)
            _command.Parameters.AddWithValue("@Order_Code", OrderCode)

            Dim _dataAdapter As SqlDataAdapter = New SqlDataAdapter(_command)
            _dataAdapter.Fill(_ds, "PUB_Sheet_Detail")
            '_dataAdapter.FillSchema(_ds, SchemaType.Mapped, "PUB_Sheet_Detail")
        Catch ex As Exception
            Throw ex
        End Try

        Return _ds.Tables("PUB_Sheet_Detail").Rows(0).Field(Of Int32)("Separate_Mark")
    End Function

    Private Function UpdateSeparateMakrOfPubSheetDetail(ByVal SheetCode As String, _
                                                        ByVal OrderCode As String, _
                                                        ByVal SeparateMark As Int32, _
                                                        ByVal User As String, _
                                                        ByVal conn As SqlConnection) As Int32
        Dim var1 As New System.Text.StringBuilder
        var1.Append("UPDATE PUB_Sheet_Detail " & vbCrLf)
        var1.Append("SET    Separate_Mark = @Separate_Mark, " & vbCrLf)
        var1.Append("       Modified_User = @User, " & vbCrLf)
        var1.Append("       Modified_Time = @Now " & vbCrLf)
        var1.Append("WHERE  Sheet_Code = @Sheet_Code " & vbCrLf)
        var1.Append("       AND Order_Code = @Order_Code ")

        Dim _cnt As Int32 = 0
        Try
            Dim _sqlConnection As SqlConnection = conn
            '_sqlConnection.Open()

            Dim _command As New SqlCommand(var1.ToString(), _sqlConnection)
            _command.CommandType = CommandType.Text
            _command.Parameters.AddWithValue("@Sheet_Code", SheetCode)
            _command.Parameters.AddWithValue("@Order_Code", OrderCode)
            _command.Parameters.AddWithValue("@Separate_Mark", SeparateMark)
            _command.Parameters.AddWithValue("@User", User)
            _command.Parameters.AddWithValue("@Now", Now)
            _cnt += _command.ExecuteNonQuery()

            '_sqlConnection.Close()
        Catch ex As Exception
            Throw ex
        End Try

        Return _cnt
    End Function

    Private Function UpdateSeparateMakrOfPubSheetDetail(ByVal SheetCode As String, _
                                                        ByVal OrderCode As String, _
                                                        ByVal SeparateMark As Int32, _
                                                        ByVal IsPrintIndication As String, _
                                                        ByVal IsPrintOrderNote As String, _
                                                        ByVal Note As String, _
                                                        ByVal OrderEntryNote As String, _
                                                        ByVal LisSheetLimitCnt As Int32, _
                                                        ByVal IsInstantlyRpt As String, _
                                                        ByVal IsLimitHealth As String, _
                                                        ByVal User As String, _
                                                        ByVal conn As SqlConnection) As Int32
        Dim var1 As New System.Text.StringBuilder
        var1.Append("UPDATE PUB_Sheet_Detail " & vbCrLf)
        var1.Append("SET    Is_Print_Indication = @Is_Print_Indication, " & vbCrLf)
        var1.Append("       Order_Note = @Order_Note, " & vbCrLf)
        var1.Append("       Order_Entry_Note = @Order_Entry_Note, " & vbCrLf)
        var1.Append("       Is_Print_Order_Note = @Is_Print_Order_Note, " & vbCrLf)
        var1.Append("       Is_InstantlyRpt = @Is_InstantlyRpt, " & vbCrLf)
        var1.Append("       Is_Limit_Health = @Is_Limit_Health, " & vbCrLf)
        var1.Append("       Separate_Mark = @Separate_Mark, " & vbCrLf)
        var1.Append("       Modified_User = @User, " & vbCrLf)
        var1.Append("       Modified_Time = @Now " & vbCrLf)
        var1.Append("WHERE  Sheet_Code = @Sheet_Code " & vbCrLf)
        var1.Append("       AND Order_Code = @Order_Code ")

        Dim _cnt As Int32 = 0
        Try
            Dim _sqlConnection As SqlConnection = conn
            '_sqlConnection.Open()

            Dim _command As New SqlCommand(var1.ToString(), _sqlConnection)
            _command.CommandType = CommandType.Text
            _command.Parameters.AddWithValue("@Sheet_Code", SheetCode)
            _command.Parameters.AddWithValue("@Order_Code", OrderCode)
            _command.Parameters.AddWithValue("@Separate_Mark", SeparateMark)
            _command.Parameters.AddWithValue("@Is_Print_Indication", IsPrintIndication)
            _command.Parameters.AddWithValue("@Order_Note", Note)
            _command.Parameters.AddWithValue("@Order_Entry_Note", OrderEntryNote)
            _command.Parameters.AddWithValue("@Is_Print_Order_Note", IsPrintOrderNote)
            _command.Parameters.AddWithValue("@Is_InstantlyRpt", IsInstantlyRpt)
            _command.Parameters.AddWithValue("@Is_Limit_Health", IsLimitHealth)
            _command.Parameters.AddWithValue("@Lis_Sheet_Limit_Cnt", LisSheetLimitCnt)
            _command.Parameters.AddWithValue("@User", User)
            _command.Parameters.AddWithValue("@Now", Now)
            _cnt += _command.ExecuteNonQuery()

            '_sqlConnection.Close()

        Catch ex As Exception
            Throw ex
        End Try

        Return _cnt
    End Function

    Private Function UpdateSeparateMakrOfPubSheetDetail(ByVal SheetCode As String, _
                                                        ByVal OrderCode As String, _
                                                        ByVal IsPrintIndication As String, _
                                                        ByVal IsPrintOrderNote As String, _
                                                        ByVal Note As String, _
                                                        ByVal OrderEntryNote As String, _
                                                        ByVal LisSheetLimitCnt As Int32, _
                                                        ByVal IsInstantlyRpt As String, _
                                                        ByVal IsLimitHealth As String, _
                                                        ByVal User As String, _
                                                        ByVal conn As SqlConnection) As Int32
        Dim var1 As New System.Text.StringBuilder
        var1.Append("UPDATE PUB_Sheet_Detail " & vbCrLf)
        var1.Append("SET    Is_Print_Indication = @Is_Print_Indication, " & vbCrLf)
        var1.Append("       Order_Note = @Order_Note, " & vbCrLf)
        var1.Append("       Order_Entry_Note = @Order_Entry_Note, " & vbCrLf)
        var1.Append("       Is_Print_Order_Note = @Is_Print_Order_Note, " & vbCrLf)
        var1.Append("       Is_InstantlyRpt = @Is_InstantlyRpt, " & vbCrLf)
        var1.Append("       Is_Limit_Health = @Is_Limit_Health, " & vbCrLf)
        var1.Append("       Separate_Mark = (SELECT CASE " & vbCrLf)
        var1.Append("                                 WHEN MAX(Separate_Mark) IS NULL THEN 1 " & vbCrLf)
        var1.Append("                                 ELSE MAX(Separate_Mark) + 1 " & vbCrLf)
        var1.Append("                               END " & vbCrLf)
        var1.Append("                        FROM   PUB_Sheet_Detail " & vbCrLf)
        var1.Append("                        WHERE  Sheet_Code = @Sheet_Code), " & vbCrLf)
        var1.Append("       Modified_User = @User, " & vbCrLf)
        var1.Append("       Modified_Time = @Now " & vbCrLf)
        var1.Append("WHERE  Sheet_Code = @Sheet_Code " & vbCrLf)
        var1.Append("       AND Order_Code = @Order_Code ")

        Dim _cnt As Int32 = 0
        Try
            Dim _sqlConnection As SqlConnection = conn
            '_sqlConnection.Open()

            Dim _command As New SqlCommand(var1.ToString(), _sqlConnection)
            _command.CommandType = CommandType.Text
            _command.Parameters.AddWithValue("@Sheet_Code", SheetCode)
            _command.Parameters.AddWithValue("@Order_Code", OrderCode)
            _command.Parameters.AddWithValue("@Is_Print_Indication", IsPrintIndication)
            _command.Parameters.AddWithValue("@Order_Note", Note)
            _command.Parameters.AddWithValue("@Order_Entry_Note", OrderEntryNote)
            _command.Parameters.AddWithValue("@Is_Print_Order_Note", IsPrintOrderNote)
            _command.Parameters.AddWithValue("@Is_InstantlyRpt", IsInstantlyRpt)
            _command.Parameters.AddWithValue("@Is_Limit_Health", IsLimitHealth)
            _command.Parameters.AddWithValue("@Lis_Sheet_Limit_Cnt", LisSheetLimitCnt)
            _command.Parameters.AddWithValue("@User", User)
            _command.Parameters.AddWithValue("@Now", Now)
            _cnt += _command.ExecuteNonQuery()

            '_sqlConnection.Close()

        Catch ex As Exception
            Throw ex
        End Try

        Return _cnt
    End Function

    ''' <summary>
    ''' 在所輸入的Order_Code的資料中的Exclusive_Order_Code裡，新增一個exclusive order code.
    ''' </summary>
    ''' <param name="SheetCode">表單代碼</param>
    ''' <param name="OrderCode">醫令代碼</param>
    ''' <param name="Exclusive_Order_Code">互斥醫令代碼</param>
    ''' <param name="User">操作者</param>
    ''' <param name="conn">sql connection.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function UpdateExclusiveOrderCodeOfPubSheetDetail(ByVal SheetCode As String, ByVal OrderCode As String, ByVal Exclusive_Order_Code As String, ByVal User As String, ByVal conn As SqlConnection) As Int32
        Dim var1 As New System.Text.StringBuilder
        var1.Append("UPDATE PUB_Sheet_Detail " & vbCrLf)
        var1.Append("SET    Exclusive_Order_Code = ( CASE " & vbCrLf)
        var1.Append("                                  WHEN Exclusive_Order_Code IS NULL THEN @Exclusive_Order_Code " & vbCrLf)
        var1.Append("                                  WHEN RTRIM(Exclusive_Order_Code) = '' THEN @Exclusive_Order_Code " & vbCrLf)
        var1.Append("                                  ELSE RTRIM(Exclusive_Order_Code) + ',' + @Exclusive_Order_Code " & vbCrLf)
        var1.Append("                                END ), " & vbCrLf)
        var1.Append("       Modified_User = @User, " & vbCrLf)
        var1.Append("       Modified_Time = @Now " & vbCrLf)
        var1.Append("WHERE  Sheet_Code = @Sheet_Code " & vbCrLf)
        var1.Append("       AND Order_Code = @Order_Code ")

        Dim _cnt As Int32 = 0
        Try
            Dim _sqlConnection As SqlConnection = conn
            '_sqlConnection.Open()

            Dim _command As New SqlCommand(var1.ToString(), _sqlConnection)
            _command.CommandType = CommandType.Text
            _command.Parameters.AddWithValue("@Sheet_Code", SheetCode)
            _command.Parameters.AddWithValue("@Order_Code", OrderCode)
            _command.Parameters.AddWithValue("@Exclusive_Order_Code", Exclusive_Order_Code)
            _command.Parameters.AddWithValue("@User", User)
            _command.Parameters.AddWithValue("@Now", Now)
            _cnt += _command.ExecuteNonQuery()

            '_sqlConnection.Close()
        Catch ex As Exception
            Throw ex
        End Try

        Return _cnt
    End Function

    ''' <summary>
    ''' 把此Sheet中此Order_Code的Exclusive_Order_Code清空, 與清除其它Order跟此Order_Code的關聯
    ''' </summary>
    ''' <param name="SheetCode">表單代碼</param>
    ''' <param name="OrderCode">醫令代碼</param>
    ''' <param name="User">操作者</param>
    ''' <param name="conn">sql connection</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function UpdateExclusiveOrderCodeOfPubSheetDetail(ByVal SheetCode As String, ByVal OrderCode As String, ByVal User As String, ByVal conn As SqlConnection) As Int32
        Dim var1 As New System.Text.StringBuilder
        var1.Append("UPDATE PUB_Sheet_Detail " & vbCrLf)
        var1.Append("SET    Exclusive_Order_Code = ( CASE " & vbCrLf)
        var1.Append("                                  WHEN REPLACE(Exclusive_Order_Code, ' ', '') LIKE '%,' + RTRIM(@Order_code) + '%' THEN REPLACE(REPLACE(Exclusive_Order_Code, ' ', ''), ',' + RTRIM(@Order_code), '') " & vbCrLf)
        var1.Append("                                  WHEN REPLACE(Exclusive_Order_Code, ' ', '') LIKE '%' + RTRIM(@Order_code) + ',%' THEN REPLACE(REPLACE(Exclusive_Order_Code, ' ', ''), RTRIM(@Order_code) + ',', '') " & vbCrLf)
        var1.Append("                                  ELSE NULL " & vbCrLf)
        var1.Append("                                END ), " & vbCrLf)
        var1.Append("       Modified_User = @User, " & vbCrLf)
        var1.Append("       Modified_Time = @Now " & vbCrLf)
        var1.Append("WHERE  Sheet_Code = @Sheet_Code " & vbCrLf)
        var1.Append("       AND Exclusive_Order_Code LIKE '%' + RTRIM(@Order_code) + '%' " & vbCrLf)
        var1.Append("; " & vbCrLf)

        var1.Append("UPDATE PUB_Sheet_Detail " & vbCrLf)
        var1.Append("SET    Exclusive_Order_Code = NULL, " & vbCrLf)
        var1.Append("       Modified_User = @User, " & vbCrLf)
        var1.Append("       Modified_Time = @Now " & vbCrLf)
        var1.Append("WHERE  Sheet_Code = @Sheet_Code " & vbCrLf)
        var1.Append("       AND Order_Code = @Order_Code " & vbCrLf)

        Dim _cnt As Int32 = 0
        Try
            Dim _sqlConnection As SqlConnection = conn

            Dim _command As New SqlCommand(var1.ToString(), _sqlConnection)
            _command.CommandType = CommandType.Text
            _command.Parameters.AddWithValue("@Sheet_Code", SheetCode)
            _command.Parameters.AddWithValue("@Order_Code", OrderCode)
            _command.Parameters.AddWithValue("@User", User)
            _command.Parameters.AddWithValue("@Now", Now)
            _cnt += _command.ExecuteNonQuery()

        Catch ex As Exception
            Throw ex
        End Try

        Return _cnt
    End Function
    Private Function UpdateIsLimintHealthByOrderCode(ByVal OrderCode As String, _
                                                    ByVal inInsuCoverOpd As String, _
                                                    ByVal inInsuCoverEmg As String, _
                                                    ByVal inInsuCoverIpd As String) As Integer

        Dim var0 As New System.Text.StringBuilder
        var0.Append("Update PUB_Order " & vbCrLf)
        var0.Append("Set Insu_Cover_Opd='" & inInsuCoverOpd & "' " & vbCrLf)
        var0.Append("    ,Insu_Cover_Emg='" & inInsuCoverEmg & "' " & vbCrLf)
        var0.Append("    ,Insu_Cover_Ipd='" & inInsuCoverIpd & "' " & vbCrLf)
        var0.Append("Where  Order_Code= '" & OrderCode & "' and " & vbCrLf)
        var0.Append("       Effect_Date <=  GETDATE() and End_Date>=  GETDATE() ")

        Dim _cnt As Int32 = 0
        Try
            Using _sqlConnection As SqlConnection = GetSqlConnection()
                _sqlConnection.Open()

                Dim _command0 As New SqlCommand(var0.ToString(), _sqlConnection)
                _command0.CommandType = CommandType.Text
                _cnt += _command0.ExecuteNonQuery
                _sqlConnection.Close()
            End Using
        Catch ex As Exception
            Throw ex
        End Try

        Return _cnt
    End Function

#End Region

#Region "PUB_Sheet_Group"

    ''' <summary>
    ''' 新增Sheet_Group之資料
    ''' </summary>
    ''' <param name="SheetCode">表單代碼</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function UpdatePubSheetGroup(ByVal SheetCode As String) As Int32
        Dim var1 As New System.Text.StringBuilder
        var1.Append("DELETE PUB_Sheet_Group " & vbCrLf)
        var1.Append("WHERE  Sheet_Code = @Sheet_Code ; " & vbCrLf)
        var1.Append("INSERT INTO PUB_Sheet_Group " & vbCrLf)
        var1.Append("SELECT DISTINCT C.Specimen_Id      AS Sheet_Group, " & vbCrLf)
        var1.Append("                A.Sheet_Code, " & vbCrLf)
        var1.Append("                C.Order_Code, " & vbCrLf)
        var1.Append("                RTRIM(D.Code_Name) AS Sheet_Group_Name, " & vbCrLf)
        var1.Append("                'N'                AS Is_Custom_Group " & vbCrLf)
        var1.Append("FROM   PUB_Sheet A " & vbCrLf)
        var1.Append("       INNER JOIN PUB_Sheet_Detail B " & vbCrLf)
        var1.Append("         ON A.Sheet_Code = B.Sheet_Code " & vbCrLf)
        var1.Append("       INNER JOIN PUB_Order_Mapping_Specimen C " & vbCrLf)
        var1.Append("         ON B.Order_Code = C.Order_Code " & vbCrLf)
        var1.Append("       INNER JOIN PUB_Syscode D " & vbCrLf)
        var1.Append("         ON D.Type_Id = 46 " & vbCrLf)
        var1.Append("            AND C.Specimen_Id = D.Code_Id " & vbCrLf)
        var1.Append("WHERE  A.Sheet_Code = @Sheet_Code ")

        Dim _cnt As Int32 = 0
        Using _sqlConnection As SqlConnection = GetSqlConnection()
            Try
                _sqlConnection.Open()

                Dim _command As New SqlCommand(var1.ToString(), _sqlConnection)
                _command.CommandType = CommandType.Text
                _command.Parameters.AddWithValue("@Sheet_Code", SheetCode)

                _cnt += _command.ExecuteNonQuery()

            Catch ex As Exception
                Throw ex
            Finally
                _sqlConnection.Close()
            End Try
        End Using

        Return _cnt
    End Function
#End Region

#Region "PUB_Rule_Class, Pub_Rule, PUB_Rule_Detail"

    ''' <summary>
    ''' 更新檢核Rule資料
    ''' </summary>
    ''' <param name="OrderCode">醫令碼</param>
    ''' <param name="OrderRuleInfo">檢核資料</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function UpdateOrderRule(ByVal OrderCode As String, ByVal OrderRuleInfo As DataTable, ByVal LimitedSexId As String, ByVal LimitedDeptCode As String, ByVal LimitedDoctCode As String, ByVal PhoneNo As String, ByVal User As String) As Int32

        Dim _cnt As Int32 = 0
        Using _sqlConnection As SqlConnection = GetSqlConnection()
            Try
                Using trans As TransactionScope = SQLConnFactory.getInstance.getRequiredTransactionScope


                    _sqlConnection.Open()

                    '1. 刪除包含此Order_Code之rule
                    _cnt += Me.DeleteRules(OrderCode, User, _sqlConnection)

                    '填入Order之Rule
                    If OrderRuleInfo.Rows.Count > 0 Then
                        '若此Order_Code存在重覆醫令，則設定Is_Order_Check為'Y'
                        Me.SetPubOrderIsCheck(OrderCode, "Y", User, _sqlConnection)
                    End If
                    For Each _row As DataRow In OrderRuleInfo.Rows
                        Dim _strictOrderCode As String = _row.Field(Of String)("Order_Code")

                        '2. 在此Rule_Code中重新加入Rule
                        Dim _ruleCode As String = String.Empty

                        '取得新序號
                        Using transSn As TransactionScope = SQLConnFactory.getInstance.getRequiredTransactionScope

                            _ruleCode = Me.GetSerialNoOfRuleCode()
                        End Using

                        _cnt += Me.InsertPUBRuleClass(_ruleCode, User, _sqlConnection)
                        _cnt += Me.InsertPUBRule(_ruleCode, OrderCode, StrictRuleType.OrderCode, _strictOrderCode, PhoneNo, User, _sqlConnection)
                        _cnt += Me.InsertPUBRuleDetail(_ruleCode, OrderCode, StrictRuleType.OrderCode, _strictOrderCode, User, _sqlConnection)

                        '3. 在其它的Order_Code所代表的Rule_Code中加入Rule.
                        Dim _ruleCodeX As String = String.Empty

                        '========  2010-7-13 取消反向的rule ========
                        ''取得新序號
                        'Using transSn As New TransactionScope(TransactionScopeOption.Suppress)
                        '    _ruleCodeX = Me.GetSerialNoOfRuleCode()
                        'End Using
                        '_cnt += Me.InsertPUBRuleClass(_ruleCodeX, User, _sqlConnection)
                        '_cnt += Me.InsertPUBRule(_ruleCodeX, _strictOrderCode, StrictRuleType.OrderCode, OrderCode, User, _sqlConnection)
                        '_cnt += Me.InsertPUBRuleDetail(_ruleCodeX, _strictOrderCode, StrictRuleType.OrderCode, OrderCode, User, _sqlConnection)
                        ''設定Strict OrderCode之Is_Order_Check
                        'Me.SetPubOrderIsCheck(_strictOrderCode, "Y", User, _sqlConnection)
                        '==============================================
                    Next

                    '填入科別之Rule
                    If LimitedDeptCode <> String.Empty Then
                        Dim _ruleCode As String = String.Empty

                        '取得新序號
                        Using transSn As TransactionScope = SQLConnFactory.getInstance.getRequiredTransactionScope
                            _ruleCode = Me.GetSerialNoOfRuleCode()
                        End Using
                        _cnt += Me.InsertPUBRuleClass(_ruleCode, User, _sqlConnection)
                        _cnt += Me.InsertPUBRule(_ruleCode, OrderCode, StrictRuleType.DeptCode, LimitedDeptCode, PhoneNo, User, _sqlConnection)
                        _cnt += Me.InsertPUBRuleDetail(_ruleCode, OrderCode, StrictRuleType.DeptCode, LimitedDeptCode, User, _sqlConnection)

                        Me.SetPubOrderIsCheck(OrderCode, "Y", User, _sqlConnection)
                    End If

                    '填入醫師之Rule
                    If LimitedDoctCode <> String.Empty Then
                        Dim _ruleCode As String = String.Empty

                        '取得新序號
                        Using transSn As TransactionScope = SQLConnFactory.getInstance.getRequiredTransactionScope
                            _ruleCode = Me.GetSerialNoOfRuleCode()
                        End Using

                        _cnt += Me.InsertPUBRuleClass(_ruleCode, User, _sqlConnection)
                        _cnt += Me.InsertPUBRule(_ruleCode, OrderCode, StrictRuleType.DoctCode, LimitedDoctCode, PhoneNo, User, _sqlConnection)
                        _cnt += Me.InsertPUBRuleDetail(_ruleCode, OrderCode, StrictRuleType.DoctCode, LimitedDoctCode, User, _sqlConnection)

                        Me.SetPubOrderIsCheck(OrderCode, "Y", User, _sqlConnection)
                    End If

                    '填入性別之Rule
                    If LimitedSexId <> String.Empty Then
                        Dim _ruleCode As String = String.Empty

                        '取得新序號
                        Using transSn As TransactionScope = SQLConnFactory.getInstance.getRequiredTransactionScope
                            _ruleCode = Me.GetSerialNoOfRuleCode()
                        End Using
                        _cnt += Me.InsertPUBRuleClass(_ruleCode, User, _sqlConnection)
                        _cnt += Me.InsertPUBRule(_ruleCode, OrderCode, StrictRuleType.SexId, LimitedSexId, PhoneNo, User, _sqlConnection)
                        _cnt += Me.InsertPUBRuleDetail(_ruleCode, OrderCode, StrictRuleType.SexId, LimitedSexId, User, _sqlConnection)

                        Me.SetPubOrderIsCheck(OrderCode, "Y", User, _sqlConnection)
                    End If

                    'END Tranansaction
                    trans.Complete()
                End Using
            Catch ex As Exception
                Throw ex
            Finally
                _sqlConnection.Close()
            End Try
        End Using

    End Function

    ''' <summary>
    ''' 由Order_Code取得Rule_Code.
    ''' </summary>
    ''' <param name="OrderCode">醫令代碼</param>
    ''' <returns></returns>
    ''' <author>Ken</author>
    ''' <date>2009-12-28</date>
    ''' <tables>
    ''' PUB_Rule_Class
    ''' PUB_Rule_Detail
    ''' PUB_Rule
    ''' </tables>
    ''' <remarks></remarks>
    Private Function GetRuleCodeByOrderCode(ByVal OrderCode As String) As String()

        Dim var1 As New System.Text.StringBuilder
        var1.Append("SELECT rc.Condition_Rule_Code AS Trigger_Rule_Code, " & vbCrLf)
        var1.Append("       rc.Rule_Code           AS Check_Rule_Code " & vbCrLf)
        var1.Append("FROM   PUB_Rule_Class AS rc " & vbCrLf)
        var1.Append("       INNER JOIN PUB_Rule_Detail AS rd " & vbCrLf)
        var1.Append("         ON ( rc.Condition_Rule_Code = rd.Rule_Code " & vbCrLf)
        var1.Append("              AND rc.Condition_Type = '1' " & vbCrLf)
        var1.Append("              AND rd.Item_Code = 'A00004' " & vbCrLf)
        var1.Append("              AND rd.Value_Data = @Order_Code " & vbCrLf)
        var1.Append("              AND rd.Rule_Code LIKE 'ORD@A00004%' ) " & vbCrLf)
        var1.Append("       INNER JOIN PUB_Rule AS rr " & vbCrLf)
        var1.Append("         ON ( rd.Rule_Code = rr.Rule_Code ) ")

        Dim _ds As New DataSet

        Try
            Using _sqlConnection As SqlConnection = GetSqlConnection()

                Dim _command As New SqlCommand(var1.ToString(), _sqlConnection)
                _command.CommandType = CommandType.Text
                _command.Parameters.AddWithValue("@Order_Code", OrderCode)

                Dim _dataAdapter As SqlDataAdapter = New SqlDataAdapter(_command)
                _dataAdapter.Fill(_ds, "Rule_Code_Info")
                '_dataAdapter.FillSchema(_ds, SchemaType.Mapped, "Rule_Code_Info")

            End Using
        Catch ex As Exception
            Throw ex
        End Try

        Dim _ruleCodes As String() = _ds.Tables("Rule_Code_Info").AsEnumerable.Select(Function(r) r.Field(Of String)("Check_Rule_Code")).ToArray

        Return _ruleCodes
    End Function

    ''' <summary>
    ''' 由Order_Code取得Rule之詳細資料
    ''' </summary>
    ''' <param name="OrderCode">醫令碼</param>
    ''' <returns>此Order之Rule之詳細資料</returns>
    ''' <remarks></remarks>
    Private Function GetRuleCodeInfoByOrderCode(ByVal OrderCode As String) As DataSet

        Dim var1 As New System.Text.StringBuilder
        var1.Append("SELECT rc.Condition_Rule_Code AS Trigger_Rule_Code, " & vbCrLf)
        var1.Append("       rc.Rule_Code           AS Check_Rule_Code, " & vbCrLf)
        var1.Append("       rd.Item_Code, " & vbCrLf)
        var1.Append("       rd.Value_Data, " & vbCrLf)
        var1.Append("       rd.Rule_Maintain_Sn, " & vbCrLf)
        var1.Append("       rr.Valid_Date_E, " & vbCrLf)
        var1.Append("       rr.Valid_Date_S, " & vbCrLf)
        var1.Append("       rr.Rule_Name, " & vbCrLf)
        var1.Append("       rr.Limit_Alert_Level, " & vbCrLf)
        var1.Append("       rr.Check_Identity, " & vbCrLf)
        var1.Append("       rr.Check_Type " & vbCrLf)
        var1.Append("FROM   PUB_Rule_Class AS rc " & vbCrLf)
        var1.Append("       INNER JOIN PUB_Rule_Detail AS rd " & vbCrLf)
        var1.Append("         ON ( rc.Condition_Rule_Code = rd.Rule_Code " & vbCrLf)
        var1.Append("              AND rc.Condition_Type = '1' " & vbCrLf)
        var1.Append("              AND rd.Item_Code = 'A00004' " & vbCrLf)
        var1.Append("              AND rd.Value_Data = @Order_Code " & vbCrLf)
        var1.Append("              AND rd.Rule_Code LIKE 'ORD@A00004%' ) " & vbCrLf)
        var1.Append("       INNER JOIN PUB_Rule AS rr " & vbCrLf)
        var1.Append("         ON ( rd.Rule_Code = rr.Rule_Code ) ")

        Dim _ds As New DataSet

        Try
            Using _sqlConnection As SqlConnection = GetSqlConnection()

                Dim _command As New SqlCommand(var1.ToString(), _sqlConnection)
                _command.CommandType = CommandType.Text
                _command.Parameters.AddWithValue("@Order_Code", OrderCode)

                Dim _dataAdapter As SqlDataAdapter = New SqlDataAdapter(_command)
                _dataAdapter.Fill(_ds, "Rule_Code_Info")
                '_dataAdapter.FillSchema(_ds, SchemaType.Mapped, "Rule_Code_Info")

            End Using
        Catch ex As Exception
            Throw ex
        End Try

        Return _ds
    End Function

    ''' <summary>
    ''' 由Order_Code取得所包含之Rule
    ''' </summary>
    ''' <param name="OrderCode">醫令代碼</param>
    ''' <returns></returns>
    ''' <author>Ken</author>
    ''' <date>2009-12-28</date>
    ''' <remarks></remarks>
    Private Function GetRulesByOrderCode(ByVal OrderCode As String) As DataSet

        Dim _ruleCodes As String() = Me.GetRuleCodeByOrderCode(OrderCode)

        'Dim _ruleCode As String = String.Empty

        'Try
        '    _ruleCode = _ruleCodes.First
        'Catch ex As Exception
        '    _ruleCode = String.Empty
        'End Try

        Dim var1 As New System.Text.StringBuilder
        var1.Append("SELECT RTRIM(A.Rule_Code)  AS Rule_Code, " & vbCrLf)
        var1.Append("       RTRIM(Item_Code)    AS Item_Code, " & vbCrLf)
        var1.Append("       RTRIM(A.Value_Data) AS Value_Data, " & vbCrLf)
        var1.Append("       RTRIM(B.Ext_No) AS Ext_No " & vbCrLf)
        var1.Append("FROM   PUB_Rule_Detail A " & vbCrLf)
        var1.Append("       INNER JOIN PUB_Rule B " & vbCrLf)
        var1.Append("         ON A.Rule_Code = B.Rule_Code " & vbCrLf)
        var1.Append("            AND A.Rule_Code = @Rule_Code ")

        Dim _ds As New DataSet

        Dim _dt As New DataTable
        _dt.TableName = "Rules"
        _dt.Columns.Add("Rule_Code", GetType(String))
        _dt.Columns.Add("Item_Code", GetType(String))
        _dt.Columns.Add("Value_Data", GetType(String))
        _dt.Columns.Add("Ext_No", GetType(String))

        Try
            Using _sqlConnection As SqlConnection = GetSqlConnection()

                For Each _ruleCode As String In _ruleCodes
                    Dim _dsTmp As New DataSet

                    Dim _command As New SqlCommand(var1.ToString(), _sqlConnection)
                    _command.CommandType = CommandType.Text
                    _command.Parameters.AddWithValue("@Rule_Code", _ruleCode)
                    Dim _dataAdapter As SqlDataAdapter = New SqlDataAdapter(_command)
                    _dataAdapter.Fill(_dsTmp, "Rules")

                    Dim _dtTmp As DataTable = _dsTmp.Tables("Rules")
                    If _dt IsNot Nothing Then
                        _dt.Merge(_dtTmp)
                    Else
                        _dt = _dtTmp.Copy
                    End If
                Next

                _ds.Tables.Add(_dt)
            End Using
        Catch ex As Exception
            Throw ex
        End Try

        Return _ds
    End Function

    ''' <summary>
    ''' 由Rule_Code取得所包含之Rule
    ''' </summary>
    ''' <param name="RuleCode">Rule Code</param>
    ''' <returns></returns>
    ''' <author>Ken</author>
    ''' <date>2009-12-28</date>
    ''' <remarks></remarks>
    Private Function GetRulesByRuleCode(ByVal RuleCode As String) As DataSet

        Dim var1 As New System.Text.StringBuilder
        var1.Append("SELECT RTRIM(A.Rule_Code)  AS Rule_Code, " & vbCrLf)
        var1.Append("       RTRIM(Item_Code)    AS Item_Code, " & vbCrLf)
        var1.Append("       RTRIM(A.Value_Data) AS Value_Data " & vbCrLf)
        var1.Append("FROM   PUB_Rule_Detail A " & vbCrLf)
        var1.Append("       INNER JOIN PUB_Rule B " & vbCrLf)
        var1.Append("         ON A.Rule_Code = B.Rule_Code " & vbCrLf)
        var1.Append("            AND A.Rule_Code = @Rule_Code ")

        Dim _ds As New DataSet

        Try
            Using _sqlConnection As SqlConnection = GetSqlConnection()

                Dim _command As New SqlCommand(var1.ToString(), _sqlConnection)
                _command.CommandType = CommandType.Text
                _command.Parameters.AddWithValue("@Rule_Code", RuleCode)

                Dim _dataAdapter As SqlDataAdapter = New SqlDataAdapter(_command)
                _dataAdapter.Fill(_ds, "Rules")
                '_dataAdapter.FillSchema(_ds, SchemaType.Mapped, "Rules")

            End Using
        Catch ex As Exception
            Throw ex
        End Try

        Return _ds
    End Function

    ''' <summary>
    ''' 由序號機取得RuleCode用的流水號
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetSerialNoOfRuleCode() As String

        Return SNCDelegate.getInstance.getOrderRuleORD()
    End Function

    ''' <summary>
    ''' 刪除所有包含輸入之醫令代碼的Rule.
    ''' </summary>
    ''' <param name="OrderCode">醫令代碼</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function DeleteRules(ByVal OrderCode As String, ByVal User As String, ByVal conn As SqlConnection) As Int32

        Dim var1 As New System.Text.StringBuilder
        var1.Append("CREATE TABLE #TMP_RULE_CODE " & vbCrLf)
        var1.Append("  ( " & vbCrLf)
        var1.Append("     Rule_Code NVARCHAR(40) " & vbCrLf)
        var1.Append("  ) " & vbCrLf)

        'var1.Append("INSERT INTO #TMP_RULE_CODE " & vbCrLf)
        'var1.Append("SELECT rc.Rule_Code AS Rule_Code " & vbCrLf)
        'var1.Append("FROM   PUB_Rule_Class AS rc " & vbCrLf)
        'var1.Append("       INNER JOIN PUB_Rule_Detail AS rd " & vbCrLf)
        'var1.Append("         ON ( rd.Rule_Code = rc.Rule_Code " & vbCrLf)
        'var1.Append("               OR rd.Rule_Code = rc.Condition_Rule_Code ) " & vbCrLf)
        'var1.Append("            AND rc.Condition_Type = '1' " & vbCrLf)
        'var1.Append("            AND rd.Value_Data = @Order_Code " & vbCrLf)
        'var1.Append("            AND rd.Rule_Code LIKE 'ORD@A00004%' " & vbCrLf)
        'var1.Append("UNION ALL " & vbCrLf)
        'var1.Append("SELECT rc.Condition_Rule_Code AS Rule_Code " & vbCrLf)
        'var1.Append("FROM   PUB_Rule_Class AS rc " & vbCrLf)
        'var1.Append("       INNER JOIN PUB_Rule_Detail AS rd " & vbCrLf)
        'var1.Append("         ON ( rd.Rule_Code = rc.Rule_Code " & vbCrLf)
        'var1.Append("               OR rd.Rule_Code = rc.Condition_Rule_Code ) " & vbCrLf)
        'var1.Append("            AND rc.Condition_Type = '1' " & vbCrLf)
        'var1.Append("            AND rd.Value_Data = @Order_Code " & vbCrLf)
        'var1.Append("            AND rd.Rule_Code LIKE 'ORD@A00004%' " & vbCrLf)
        var1.Append("INSERT INTO #TMP_RULE_CODE " & vbCrLf)
        var1.Append("SELECT rc.Rule_Code AS Rule_Code " & vbCrLf)
        var1.Append("FROM   PUB_Rule_Class AS rc " & vbCrLf)
        var1.Append("       INNER JOIN PUB_Rule_Detail AS rd " & vbCrLf)
        var1.Append("         ON rd.Rule_Code = rc.Condition_Rule_Code " & vbCrLf)
        var1.Append("            AND rc.Condition_Type = '1' " & vbCrLf)
        var1.Append("            AND rd.Value_Data = @Order_Code " & vbCrLf)
        var1.Append("            AND rd.Rule_Code LIKE 'ORD@A00004%' " & vbCrLf)
        var1.Append("UNION ALL " & vbCrLf)
        var1.Append("SELECT rc.Condition_Rule_Code AS Rule_Code " & vbCrLf)
        var1.Append("FROM   PUB_Rule_Class AS rc " & vbCrLf)
        var1.Append("       INNER JOIN PUB_Rule_Detail AS rd " & vbCrLf)
        var1.Append("         ON rd.Rule_Code = rc.Condition_Rule_Code " & vbCrLf)
        var1.Append("            AND rc.Condition_Type = '1' " & vbCrLf)
        var1.Append("            AND rd.Value_Data = @Order_Code " & vbCrLf)
        var1.Append("            AND rd.Rule_Code LIKE 'ORD@A00004%' " & vbCrLf)

        'var1.Append("UPDATE PUB_Order " & vbCrLf)
        'var1.Append("SET    Is_Order_Check = 'N', " & vbCrLf)
        'var1.Append("       Modified_User = @User, " & vbCrLf)
        'var1.Append("       Modified_Time = @Now " & vbCrLf)
        'var1.Append("WHERE  Order_Code IN(SELECT Value_Data " & vbCrLf)
        'var1.Append("                     FROM   PUB_Rule_Detail " & vbCrLf)
        'var1.Append("                     WHERE  Rule_Code IN (SELECT Rule_Code " & vbCrLf)
        'var1.Append("                                          FROM   #TMP_RULE_CODE) " & vbCrLf)
        'var1.Append("                            AND Item_Code = 'A00005') " & vbCrLf)
        'var1.Append("       AND Dc = 'N' " & vbCrLf)
        'var1.Append("       AND Effect_Date <= @Now " & vbCrLf)
        var1.Append("UPDATE PUB_Order " & vbCrLf)
        var1.Append("SET    Is_Order_Check = 'N', " & vbCrLf)
        var1.Append("       Modified_User = @User, " & vbCrLf)
        var1.Append("       Modified_Time = @Now " & vbCrLf)
        var1.Append("WHERE  Order_Code IN(SELECT Value_Data " & vbCrLf)
        var1.Append("                     FROM   PUB_Rule_Detail " & vbCrLf)
        var1.Append("                     WHERE  Rule_Code IN ( @Order_Code ) " & vbCrLf)
        var1.Append("                            AND Item_Code = 'A00005') " & vbCrLf)
        var1.Append("       AND Dc = 'N' " & vbCrLf)
        var1.Append("       AND Effect_Date <= @Now " & vbCrLf)

        var1.Append("DELETE PUB_Rule_Detail " & vbCrLf)
        var1.Append("WHERE  Rule_Code IN (SELECT Rule_Code " & vbCrLf)
        var1.Append("                     FROM   #TMP_RULE_CODE) " & vbCrLf)

        var1.Append("DELETE PUB_Rule " & vbCrLf)
        var1.Append("WHERE  Rule_Code IN (SELECT Rule_Code " & vbCrLf)
        var1.Append("                     FROM   #TMP_RULE_CODE) " & vbCrLf)

        var1.Append("DELETE PUB_Rule_Class " & vbCrLf)
        var1.Append("WHERE  Rule_Code IN (SELECT Rule_Code " & vbCrLf)
        var1.Append("                     FROM   #TMP_RULE_CODE) " & vbCrLf)

        var1.Append("DROP TABLE #TMP_RULE_CODE " & vbCrLf)

        Dim _cnt As Int32 = 0
        Try
            Dim _sqlConnection As SqlConnection = conn

            Dim _command As New SqlCommand(var1.ToString(), _sqlConnection)
            _command.CommandType = CommandType.Text
            _command.Parameters.AddWithValue("@Order_Code", OrderCode)
            _command.Parameters.AddWithValue("@User", User)
            _command.Parameters.AddWithValue("@Now", Now)
            _cnt += _command.ExecuteNonQuery()

        Catch ex As Exception
            Throw ex
        End Try

        Return _cnt
    End Function

    ''' <summary>
    ''' 新增一筆資料備Pub_Rule_Class
    ''' </summary>
    ''' <param name="OrderRule">order rule.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function InsertPUBRuleClass(ByVal OrderRule As String, ByVal User As String, ByVal conn As SqlConnection) As Int32

        Dim var1 As New System.Text.StringBuilder
        var1.Append("INSERT INTO PUB_Rule_Class " & vbCrLf)
        var1.Append("            ([Rule_Code], " & vbCrLf)
        var1.Append("             [Condition_Type], " & vbCrLf)
        var1.Append("             [Seq_No], " & vbCrLf)
        var1.Append("             [Condition_Rule_Code], " & vbCrLf)
        var1.Append("             [Logical_Symbol], " & vbCrLf)
        var1.Append("             [Create_User], " & vbCrLf)
        var1.Append("             [Create_Time], " & vbCrLf)
        var1.Append("             [Modified_User], " & vbCrLf)
        var1.Append("             [Modified_Time]) " & vbCrLf)
        var1.Append("VALUES      (@Rule_Code, " & vbCrLf)
        var1.Append("             '1', " & vbCrLf)
        var1.Append("             '1', " & vbCrLf)
        var1.Append("             @Rule_Code + '-S1', " & vbCrLf)
        var1.Append("             '', " & vbCrLf)
        var1.Append("             @User, " & vbCrLf)
        var1.Append("             @Now, " & vbCrLf)
        var1.Append("             NULL, " & vbCrLf)
        var1.Append("             NULL) ")

        Dim _cnt As Int32 = 0
        Try
            Dim _sqlConnection As SqlConnection = conn

            Dim _command As New SqlCommand(var1.ToString(), _sqlConnection)
            _command.CommandType = CommandType.Text
            _command.Parameters.AddWithValue("@Rule_Code", OrderRule)
            _command.Parameters.AddWithValue("@User", User)
            _command.Parameters.AddWithValue("@Now", Now)
            _cnt += _command.ExecuteNonQuery()

        Catch ex As Exception
            Throw ex
        End Try

        Return _cnt

    End Function

    ' ''' <summary>
    ' ''' 新增一筆資料至Pub_Rule
    ' ''' </summary>
    ' ''' <param name="OrderRule">rule code</param>
    ' ''' <param name="OrderCode">order code</param>
    ' ''' <param name="StrictOrderCode">strict order code</param>
    ' ''' <param name="LimitedSexId">limited sex id</param>
    ' ''' <param name="LimitedDeptCode">limited dept code</param>
    ' ''' <returns></returns>
    ' ''' <remarks></remarks>
    'Private Function InsertPUBRule(ByVal OrderRule As String, _
    '                               ByVal OrderCode As String, _
    '                               ByVal StrictOrderCode As String, _
    '                               ByVal LimitedSexId As String, _
    '                               ByVal LimitedDeptCode As String, _
    '                               ByVal User As String, _
    '                               ByVal conn As SqlConnection) As Int32

    '    Dim var1 As New System.Text.StringBuilder
    '    var1.Append("INSERT INTO PUB_Rule " & vbCrLf)
    '    var1.Append("            (Rule_Code, " & vbCrLf)
    '    var1.Append("             Rule_Name, " & vbCrLf)
    '    var1.Append("             Check_Type, " & vbCrLf)
    '    var1.Append("             Expression_Str, " & vbCrLf)
    '    var1.Append("             Check_Identity, " & vbCrLf)
    '    var1.Append("             Limit_Alert_Level, " & vbCrLf)
    '    var1.Append("             [Is_Sending_Alert_Mail], " & vbCrLf)
    '    var1.Append("             [Is_Enabled_Client], " & vbCrLf)
    '    var1.Append("             [Is_Enabled_Server], " & vbCrLf)
    '    var1.Append("             [Is_Only_SO], " & vbCrLf)
    '    var1.Append("             [Is_Only_SE], " & vbCrLf)
    '    var1.Append("             [Is_Only_SI], " & vbCrLf)
    '    var1.Append("             [Is_Only_CO], " & vbCrLf)
    '    var1.Append("             [Is_Only_CE], " & vbCrLf)
    '    var1.Append("             [Is_Only_CI], " & vbCrLf)
    '    var1.Append("             True_Message, " & vbCrLf)
    '    var1.Append("             False_Message, " & vbCrLf)
    '    var1.Append("             Valid_Date_S, " & vbCrLf)
    '    var1.Append("             Valid_Date_E, " & vbCrLf)
    '    var1.Append("             Original_Rule_Code, " & vbCrLf)
    '    var1.Append("             Create_User, " & vbCrLf)
    '    var1.Append("             Create_Time) " & vbCrLf)
    '    var1.Append("VALUES      (@Rule_Code, " & vbCrLf)
    '    var1.Append("             '醫令碼(' + @Order_Code + ')檢核條件', " & vbCrLf)
    '    var1.Append("             '2', " & vbCrLf)

    '    If LimitedSexId = String.Empty AndAlso LimitedDeptCode = String.Empty Then
    '        '不限Sex_Id與Dept_Code
    '        var1.Append("             '(Order_Record@Order_Code=True)', " & vbCrLf)
    '    ElseIf LimitedSexId <> String.Empty AndAlso LimitedDeptCode = String.Empty Then
    '        '限制Sex_Id
    '        var1.Append("             '(Order_Record@Order_Code=True)&(Patient@Sex_Id=''' + @Sex_Id + ''')', " & vbCrLf)
    '    ElseIf LimitedSexId = String.Empty AndAlso LimitedDeptCode <> String.Empty Then
    '        '限制Dept_Code
    '        var1.Append("             '(Order_Record@Order_Code=True)&(Medical_Record@Dept_Code=''' + @Dept_Code + ''')', " & vbCrLf)
    '    Else
    '        '限制Sex_Id與Dept_Code
    '        var1.Append("             '(Order_Record@Order_Code=True)&(Patient@Sex_Id=''' + @Sex_Id + ''')&(Medical_Record@Dept_Code=''' + @Dept_Code + ''')', " & vbCrLf)
    '    End If

    '    var1.Append("             '0', " & vbCrLf)
    '    var1.Append("             '2', " & vbCrLf)
    '    var1.Append("             'N', " & vbCrLf)
    '    var1.Append("             'Y', " & vbCrLf)
    '    var1.Append("             'Y', " & vbCrLf)
    '    var1.Append("             'Y', " & vbCrLf)
    '    var1.Append("             'Y', " & vbCrLf)
    '    var1.Append("             'Y', " & vbCrLf)
    '    var1.Append("             'Y', " & vbCrLf)
    '    var1.Append("             'Y', " & vbCrLf)
    '    var1.Append("             'Y', " & vbCrLf)
    '    var1.Append("             'Pass(' + @Rule_Code + ')', " & vbCrLf)

    '    If LimitedSexId = String.Empty AndAlso LimitedDeptCode = String.Empty Then
    '        '不限Sex_Id與Dept_Code
    '        var1.Append("             '醫令碼不可併存(' + @Order_Code + ',' + @Strict_Order_Code + ')', " & vbCrLf)
    '    ElseIf LimitedSexId <> String.Empty AndAlso LimitedDeptCode = String.Empty Then
    '        '限制Sex_Id
    '        var1.Append("             '醫令碼不可併存(' + @Order_Code + ',' + @Strict_Order_Code + ');限性別(' + @Sex_Id + ')', " & vbCrLf)
    '    ElseIf LimitedSexId = String.Empty AndAlso LimitedDeptCode <> String.Empty Then
    '        '限制Dept_Code
    '        var1.Append("             '醫令碼不可併存(' + @Order_Code + ',' + @Strict_Order_Code + ');限科室(' + @Dept_Code + ')', " & vbCrLf)
    '    Else
    '        '限制Sex_Id與Dept_Code
    '        var1.Append("             '醫令碼不可併存(' + @Order_Code + ',' + @Strict_Order_Code + ');限性別(' + @Sex_Id + ');限科室(' + @Dept_Code + ')', " & vbCrLf)
    '    End If

    '    var1.Append("             (SELECT Effect_Date " & vbCrLf)
    '    var1.Append("              FROM   PUB_Order " & vbCrLf)
    '    var1.Append("              WHERE  Order_Code = @Order_Code " & vbCrLf)
    '    var1.Append("                     AND Dc = 'N'), " & vbCrLf)
    '    var1.Append("             (SELECT End_Date " & vbCrLf)
    '    var1.Append("              FROM   PUB_Order " & vbCrLf)
    '    var1.Append("              WHERE  Order_Code = @Order_Code " & vbCrLf)
    '    var1.Append("                     AND Dc = 'N'), " & vbCrLf)
    '    var1.Append("             NULL, " & vbCrLf)
    '    var1.Append("             @User, " & vbCrLf)
    '    var1.Append("             @Now) " & vbCrLf)

    '    var1.Append("INSERT INTO PUB_Rule " & vbCrLf)
    '    var1.Append("            (Rule_Code, " & vbCrLf)
    '    var1.Append("             Rule_Name, " & vbCrLf)
    '    var1.Append("             Check_Type, " & vbCrLf)
    '    var1.Append("             Expression_Str, " & vbCrLf)
    '    var1.Append("             Check_Identity, " & vbCrLf)
    '    var1.Append("             Limit_Alert_Level, " & vbCrLf)
    '    var1.Append("             [Is_Sending_Alert_Mail], " & vbCrLf)
    '    var1.Append("             [Is_Enabled_Client], " & vbCrLf)
    '    var1.Append("             [Is_Enabled_Server], " & vbCrLf)
    '    var1.Append("             [Is_Only_SO], " & vbCrLf)
    '    var1.Append("             [Is_Only_SE], " & vbCrLf)
    '    var1.Append("             [Is_Only_SI], " & vbCrLf)
    '    var1.Append("             [Is_Only_CO], " & vbCrLf)
    '    var1.Append("             [Is_Only_CE], " & vbCrLf)
    '    var1.Append("             [Is_Only_CI], " & vbCrLf)
    '    var1.Append("             True_Message, " & vbCrLf)
    '    var1.Append("             False_Message, " & vbCrLf)
    '    var1.Append("             Valid_Date_S, " & vbCrLf)
    '    var1.Append("             Valid_Date_E, " & vbCrLf)
    '    var1.Append("             Original_Rule_Code, " & vbCrLf)
    '    var1.Append("             Create_User, " & vbCrLf)
    '    var1.Append("             Create_Time) " & vbCrLf)
    '    var1.Append("VALUES      (@Rule_Code + '-S1', " & vbCrLf)
    '    var1.Append("             '醫令碼(' + @Order_Code + ')觸發檢核條件起始條件', " & vbCrLf)
    '    var1.Append("             '2', " & vbCrLf)
    '    var1.Append("             '(Order_Record@Order_Code=''' + @Order_Code + ''')', " & vbCrLf)
    '    var1.Append("             '0', " & vbCrLf)
    '    var1.Append("             '2', " & vbCrLf)
    '    var1.Append("             'N', " & vbCrLf)
    '    var1.Append("             'Y', " & vbCrLf)
    '    var1.Append("             'Y', " & vbCrLf)
    '    var1.Append("             'Y', " & vbCrLf)
    '    var1.Append("             'Y', " & vbCrLf)
    '    var1.Append("             'Y', " & vbCrLf)
    '    var1.Append("             'Y', " & vbCrLf)
    '    var1.Append("             'Y', " & vbCrLf)
    '    var1.Append("             'Y', " & vbCrLf)
    '    var1.Append("             'Pass(' + @Rule_Code + ')', " & vbCrLf)

    '    If LimitedSexId = String.Empty AndAlso LimitedDeptCode = String.Empty Then
    '        '不限Sex_Id與Dept_Code
    '        var1.Append("             '醫令碼不可併存(' + @Order_Code + ',' + @Strict_Order_Code + ')', " & vbCrLf)
    '    ElseIf LimitedSexId <> String.Empty AndAlso LimitedDeptCode = String.Empty Then
    '        '限制Sex_Id
    '        var1.Append("             '醫令碼不可併存(' + @Order_Code + ',' + @Strict_Order_Code + ');限性別(' + @Sex_Id + ')', " & vbCrLf)
    '    ElseIf LimitedSexId = String.Empty AndAlso LimitedDeptCode <> String.Empty Then
    '        '限制Dept_Code
    '        var1.Append("             '醫令碼不可併存(' + @Order_Code + ',' + @Strict_Order_Code + ');限科室(' + @Dept_Code + ')', " & vbCrLf)
    '    Else
    '        '限制Sex_Id與Dept_Code
    '        var1.Append("             '醫令碼不可併存(' + @Order_Code + ',' + @Strict_Order_Code + ');限性別(' + @Sex_Id + ');限科室(' + @Dept_Code + ')', " & vbCrLf)
    '    End If

    '    var1.Append("             (SELECT Effect_Date " & vbCrLf)
    '    var1.Append("              FROM   PUB_Order " & vbCrLf)
    '    var1.Append("              WHERE  Order_Code = @Order_Code " & vbCrLf)
    '    var1.Append("                     AND Dc = 'N'), " & vbCrLf)
    '    var1.Append("             (SELECT End_Date " & vbCrLf)
    '    var1.Append("              FROM   PUB_Order " & vbCrLf)
    '    var1.Append("              WHERE  Order_Code = @Order_Code " & vbCrLf)
    '    var1.Append("                     AND Dc = 'N'), " & vbCrLf)
    '    var1.Append("             NULL, " & vbCrLf)
    '    var1.Append("             @User, " & vbCrLf)
    '    var1.Append("             @Now) " & vbCrLf)

    '    Dim _cnt As Int32 = 0
    '    Try
    '        Dim _sqlConnection As SqlConnection = conn

    '        Using trans As New TransactionScope

    '            Dim _command As New SqlCommand(var1.ToString(), _sqlConnection)
    '            _command.CommandType = CommandType.Text
    '            _command.Parameters.AddWithValue("@Rule_Code", OrderRule)
    '            _command.Parameters.AddWithValue("@Order_Code", OrderCode)
    '            _command.Parameters.AddWithValue("@Strict_Order_Code", StrictOrderCode)
    '            _command.Parameters.AddWithValue("@Sex_Id", LimitedSexId)
    '            _command.Parameters.AddWithValue("@Dept_Code", LimitedDeptCode)
    '            _command.Parameters.AddWithValue("@User", User)
    '            _command.Parameters.AddWithValue("@Now", Now)
    '            _cnt += _command.ExecuteNonQuery()

    '            trans.Complete()
    '        End Using 'End Transaction
    '    Catch ex As Exception
    '        Throw ex
    '    End Try

    '    Return _cnt

    'End Function

    Private Function InsertPUBRule(ByVal OrderRule As String, _
                                   ByVal OrderCode As String, _
                                   ByVal StrictType As StrictRuleType, _
                                   ByVal StrictRule As String, _
                                   ByVal ExtNo As String, _
                                   ByVal User As String, _
                                   ByVal conn As SqlConnection) As Int32
        Dim var1 As New System.Text.StringBuilder
        var1.Append("INSERT INTO PUB_Rule " & vbCrLf)
        var1.Append("            (Rule_Code, " & vbCrLf)
        var1.Append("             Rule_Name, " & vbCrLf)
        var1.Append("             Check_Type, " & vbCrLf)
        var1.Append("             Expression_Str, " & vbCrLf)
        var1.Append("             Check_Identity, " & vbCrLf)
        var1.Append("             Limit_Alert_Level, " & vbCrLf)
        var1.Append("             Is_Sending_Alert_Mail, " & vbCrLf)
        var1.Append("             Is_Enabled_Client, " & vbCrLf)
        var1.Append("             Is_Enabled_Server, " & vbCrLf)
        var1.Append("             Is_Only_SO, " & vbCrLf)
        var1.Append("             Is_Only_SE, " & vbCrLf)
        var1.Append("             Is_Only_SI, " & vbCrLf)
        var1.Append("             Is_Only_CO, " & vbCrLf)
        var1.Append("             Is_Only_CE, " & vbCrLf)
        var1.Append("             Is_Only_CI, " & vbCrLf)
        var1.Append("             True_Message, " & vbCrLf)
        var1.Append("             False_Message, " & vbCrLf)
        var1.Append("             Valid_Date_S, " & vbCrLf)
        var1.Append("             Valid_Date_E, " & vbCrLf)
        var1.Append("             Original_Rule_Code, " & vbCrLf)
        var1.Append("             Ext_No, " & vbCrLf)
        var1.Append("             Create_User, " & vbCrLf)
        var1.Append("             Create_Time) " & vbCrLf)
        var1.Append("VALUES      (@Rule_Code, " & vbCrLf)
        var1.Append("             '醫令碼(' + @Order_Code + ')檢核條件', " & vbCrLf)
        var1.Append("             '2', " & vbCrLf)

        Select Case StrictType
            Case StrictRuleType.OrderCode
                var1.Append("             '(Order_Record@Order_Code=True)', " & vbCrLf)
            Case StrictRuleType.DeptCode
                var1.Append("             '(Medical_Record@Dept_Code=''' + @Strict_Rule + ''')', " & vbCrLf)
            Case StrictRuleType.SexId
                var1.Append("             '(Patient@Sex_Id=''' + @Strict_Rule + ''')', " & vbCrLf)
            Case StrictRuleType.DoctCode
                var1.Append("             '(Order_Record@Order_Doctor_Code=''' + @Strict_Rule + ''')', " & vbCrLf)
            Case Else
                var1.Append("             '', " & vbCrLf)
        End Select

        var1.Append("             '0', " & vbCrLf)
        var1.Append("             '3', " & vbCrLf)  '2011/11/16 修改限制強度為 錯誤(強制中斷) ---高秀玲
        var1.Append("             'N', " & vbCrLf)
        var1.Append("             'Y', " & vbCrLf)
        var1.Append("             'Y', " & vbCrLf)
        var1.Append("             'Y', " & vbCrLf)
        var1.Append("             'Y', " & vbCrLf)
        var1.Append("             'Y', " & vbCrLf)
        var1.Append("             'Y', " & vbCrLf)
        var1.Append("             'Y', " & vbCrLf)
        var1.Append("             'Y', " & vbCrLf)
        var1.Append("             'Pass(' + @Rule_Code + ')', " & vbCrLf)

        Select Case StrictType
            Case StrictRuleType.OrderCode
                var1.Append("             '醫令碼不可併存(' + @Order_Code + ',' + @Strict_Rule + ')', " & vbCrLf)
            Case StrictRuleType.DeptCode
                var1.Append("             '限科室(' + @Strict_Rule + ')', " & vbCrLf)
            Case StrictRuleType.SexId
                var1.Append("             '限性別(' + @Strict_Rule + ')', " & vbCrLf)
            Case StrictRuleType.DoctCode
                var1.Append("             '限醫師(' + @Strict_Rule + ')', " & vbCrLf)
            Case Else
                var1.Append("             '', " & vbCrLf)
        End Select

        var1.Append("             (SELECT Effect_Date " & vbCrLf)
        var1.Append("              FROM   PUB_Order " & vbCrLf)
        var1.Append("              WHERE  Order_Code = @Order_Code " & vbCrLf)
        var1.Append("                     AND Dc = 'N'), " & vbCrLf)
        var1.Append("             (SELECT End_Date " & vbCrLf)
        var1.Append("              FROM   PUB_Order " & vbCrLf)
        var1.Append("              WHERE  Order_Code = @Order_Code " & vbCrLf)
        var1.Append("                     AND Dc = 'N'), " & vbCrLf)
        var1.Append("              NULL, " & vbCrLf)
        var1.Append("             @Ext_No, " & vbCrLf)
        var1.Append("              @User, " & vbCrLf)
        var1.Append("              @Now) " & vbCrLf)

        var1.Append("INSERT INTO PUB_Rule " & vbCrLf)
        var1.Append("            (Rule_Code, " & vbCrLf)
        var1.Append("             Rule_Name, " & vbCrLf)
        var1.Append("             Check_Type, " & vbCrLf)
        var1.Append("             Expression_Str, " & vbCrLf)
        var1.Append("             Check_Identity, " & vbCrLf)
        var1.Append("             Limit_Alert_Level, " & vbCrLf)
        var1.Append("             Is_Sending_Alert_Mail, " & vbCrLf)
        var1.Append("             Is_Enabled_Client, " & vbCrLf)
        var1.Append("             Is_Enabled_Server, " & vbCrLf)
        var1.Append("             Is_Only_SO, " & vbCrLf)
        var1.Append("             Is_Only_SE, " & vbCrLf)
        var1.Append("             Is_Only_SI, " & vbCrLf)
        var1.Append("             Is_Only_CO, " & vbCrLf)
        var1.Append("             Is_Only_CE, " & vbCrLf)
        var1.Append("             Is_Only_CI, " & vbCrLf)
        var1.Append("             True_Message, " & vbCrLf)
        var1.Append("             False_Message, " & vbCrLf)
        var1.Append("             Valid_Date_S, " & vbCrLf)
        var1.Append("             Valid_Date_E, " & vbCrLf)
        var1.Append("             Original_Rule_Code, " & vbCrLf)
        var1.Append("             Ext_No, " & vbCrLf)
        var1.Append("             Create_User, " & vbCrLf)
        var1.Append("             Create_Time) " & vbCrLf)
        var1.Append("VALUES      (@Rule_Code + '-S1', " & vbCrLf)
        var1.Append("             '醫令碼(' + @Order_Code + ')觸發檢核條件起始條件', " & vbCrLf)
        var1.Append("             '2', " & vbCrLf)
        var1.Append("             '(Order_Record@Order_Code=''' + @Order_Code + ''')', " & vbCrLf)
        var1.Append("             '0', " & vbCrLf)
        var1.Append("             '3', " & vbCrLf)  '2011/11/16 修改限制強度為 錯誤(強制中斷) ---高秀玲
        var1.Append("             'N', " & vbCrLf)
        var1.Append("             'Y', " & vbCrLf)
        var1.Append("             'Y', " & vbCrLf)
        var1.Append("             'Y', " & vbCrLf)
        var1.Append("             'Y', " & vbCrLf)
        var1.Append("             'Y', " & vbCrLf)
        var1.Append("             'Y', " & vbCrLf)
        var1.Append("             'Y', " & vbCrLf)
        var1.Append("             'Y', " & vbCrLf)
        var1.Append("             'Pass(' + @Rule_Code + ')', " & vbCrLf)

        Select Case StrictType
            Case StrictRuleType.OrderCode
                var1.Append("             '醫令碼不可併存(' + @Order_Code + ',' + @Strict_Rule + ')', " & vbCrLf)
            Case StrictRuleType.DeptCode
                var1.Append("             '限科室(' + @Strict_Rule + ')', " & vbCrLf)
            Case StrictRuleType.SexId
                var1.Append("             '限性別(' + @Strict_Rule + ')', " & vbCrLf)
            Case StrictRuleType.DoctCode
                var1.Append("             '限醫師(' + @Strict_Rule + ')', " & vbCrLf)
            Case Else
                var1.Append("             '', " & vbCrLf)
        End Select

        var1.Append("             (SELECT Effect_Date " & vbCrLf)
        var1.Append("              FROM   PUB_Order " & vbCrLf)
        var1.Append("              WHERE  Order_Code = @Order_Code " & vbCrLf)
        var1.Append("                     AND Dc = 'N'), " & vbCrLf)
        var1.Append("             (SELECT End_Date " & vbCrLf)
        var1.Append("              FROM   PUB_Order " & vbCrLf)
        var1.Append("              WHERE  Order_Code = @Order_Code " & vbCrLf)
        var1.Append("                     AND Dc = 'N'), " & vbCrLf)
        var1.Append("             NULL, " & vbCrLf)
        var1.Append("             @Ext_No, " & vbCrLf)
        var1.Append("             @User, " & vbCrLf)
        var1.Append("             @Now) " & vbCrLf)

        Dim _cnt As Int32 = 0
        Try
            Dim _sqlConnection As SqlConnection = conn

            Using trans As TransactionScope = SQLConnFactory.getInstance.getRequiredTransactionScope


                Dim _command As New SqlCommand(var1.ToString(), _sqlConnection)
                _command.CommandType = CommandType.Text
                _command.Parameters.AddWithValue("@Rule_Code", OrderRule)
                _command.Parameters.AddWithValue("@Order_Code", OrderCode)
                _command.Parameters.AddWithValue("@Strict_Rule", StrictRule)
                '_command.Parameters.AddWithValue("@Sex_Id", LimitedSexId)
                '_command.Parameters.AddWithValue("@Dept_Code", LimitedDeptCode)
                _command.Parameters.AddWithValue("@Ext_No", ExtNo)
                _command.Parameters.AddWithValue("@User", User)
                _command.Parameters.AddWithValue("@Now", Now)
                _cnt += _command.ExecuteNonQuery()

                trans.Complete()
            End Using 'End Transaction
        Catch ex As Exception
            Throw ex
        End Try

        Return _cnt
    End Function

    ' ''' <summary>
    ' ''' 新增一筆資料至Pub_Rule_Detail
    ' ''' </summary>
    ' ''' <param name="OrderRule">rule code</param>
    ' ''' <param name="OrderCode">order code</param>
    ' ''' <param name="StrictOrderCode">strict order code</param>
    ' ''' <param name="LimitedSexId">lmited sex id</param>
    ' ''' <param name="LimitedDeptCode">limited dept code</param>
    ' ''' <returns></returns>
    ' ''' <remarks></remarks>
    'Private Function InsertPUBRuleDetail(ByVal OrderRule As String, _
    '                                     ByVal OrderCode As String, _
    '                                     ByVal StrictOrderCode As String, _
    '                                     ByVal LimitedSexId As String, _
    '                                     ByVal LimitedDeptCode As String, _
    '                                     ByVal User As String, _
    '                                     ByVal conn As SqlConnection) As Int32
    '    Dim var1 As New System.Text.StringBuilder

    '    If StrictOrderCode <> String.Empty Then
    '        var1.Append("INSERT INTO PUB_Rule_Detail " & vbCrLf)
    '        var1.Append("            (Rule_Code, " & vbCrLf)
    '        var1.Append("             Seq_No, " & vbCrLf)
    '        var1.Append("             Item_Code, " & vbCrLf)
    '        var1.Append("             Item_Param, " & vbCrLf)
    '        var1.Append("             Operator_Code, " & vbCrLf)
    '        var1.Append("             Value_Data, " & vbCrLf)
    '        var1.Append("             Value_Unit, " & vbCrLf)
    '        var1.Append("             Is_Count_O, " & vbCrLf)
    '        var1.Append("             Is_Count_E, " & vbCrLf)
    '        var1.Append("             Is_Count_I, " & vbCrLf)
    '        var1.Append("             Logical_Symbol, " & vbCrLf)
    '        var1.Append("             Create_User, " & vbCrLf)
    '        var1.Append("             Create_Time, " & vbCrLf)
    '        var1.Append("             Rule_Maintain_Sn) " & vbCrLf)
    '        var1.Append("VALUES      (@Rule_Code, " & vbCrLf)
    '        var1.Append("             '1', " & vbCrLf)
    '        var1.Append("             'A00005', " & vbCrLf)
    '        var1.Append("             '', " & vbCrLf)
    '        var1.Append("             '11', " & vbCrLf)
    '        var1.Append("             @Strict_Order_Code, " & vbCrLf) '#################################
    '        var1.Append("             '', " & vbCrLf)
    '        var1.Append("             'Y', " & vbCrLf)
    '        var1.Append("             'Y', " & vbCrLf)
    '        var1.Append("             'Y', " & vbCrLf)
    '        var1.Append("             'AND', " & vbCrLf)
    '        var1.Append("             @User, " & vbCrLf)
    '        var1.Append("             @Now, " & vbCrLf)
    '        var1.Append("             0) " & vbCrLf)
    '    End If

    '    If LimitedSexId <> String.Empty Then
    '        var1.Append("INSERT INTO PUB_Rule_Detail " & vbCrLf)
    '        var1.Append("            (Rule_Code, " & vbCrLf)
    '        var1.Append("             Seq_No, " & vbCrLf)
    '        var1.Append("             Item_Code, " & vbCrLf)
    '        var1.Append("             Item_Param, " & vbCrLf)
    '        var1.Append("             Operator_Code, " & vbCrLf)
    '        var1.Append("             Value_Data, " & vbCrLf)
    '        var1.Append("             Value_Unit, " & vbCrLf)
    '        var1.Append("             Is_Count_O, " & vbCrLf)
    '        var1.Append("             Is_Count_E, " & vbCrLf)
    '        var1.Append("             Is_Count_I, " & vbCrLf)
    '        var1.Append("             Logical_Symbol, " & vbCrLf)
    '        var1.Append("             Create_User, " & vbCrLf)
    '        var1.Append("             Create_Time, " & vbCrLf)
    '        var1.Append("             Rule_Maintain_Sn) " & vbCrLf)
    '        var1.Append("VALUES      (@Rule_Code, " & vbCrLf)
    '        var1.Append("             '2', " & vbCrLf)
    '        var1.Append("             'E00002', " & vbCrLf)
    '        var1.Append("             '', " & vbCrLf)
    '        var1.Append("             '02', " & vbCrLf)
    '        var1.Append("             @Sex_Id, " & vbCrLf)
    '        var1.Append("             '', " & vbCrLf)
    '        var1.Append("             'Y', " & vbCrLf)
    '        var1.Append("             'Y', " & vbCrLf)
    '        var1.Append("             'Y', " & vbCrLf)
    '        var1.Append("             'AND', " & vbCrLf)
    '        var1.Append("             @User, " & vbCrLf)
    '        var1.Append("             @Now, " & vbCrLf)
    '        var1.Append("             0) " & vbCrLf)
    '    End If

    '    If LimitedDeptCode <> String.Empty Then
    '        var1.Append("INSERT INTO PUB_Rule_Detail " & vbCrLf)
    '        var1.Append("            (Rule_Code, " & vbCrLf)
    '        var1.Append("             Seq_No, " & vbCrLf)
    '        var1.Append("             Item_Code, " & vbCrLf)
    '        var1.Append("             Item_Param, " & vbCrLf)
    '        var1.Append("             Operator_Code, " & vbCrLf)
    '        var1.Append("             Value_Data, " & vbCrLf)
    '        var1.Append("             Value_Unit, " & vbCrLf)
    '        var1.Append("             Is_Count_O, " & vbCrLf)
    '        var1.Append("             Is_Count_E, " & vbCrLf)
    '        var1.Append("             Is_Count_I, " & vbCrLf)
    '        var1.Append("             Logical_Symbol, " & vbCrLf)
    '        var1.Append("             Create_User, " & vbCrLf)
    '        var1.Append("             Create_Time, " & vbCrLf)
    '        var1.Append("             Rule_Maintain_Sn) " & vbCrLf)
    '        var1.Append("VALUES      (@Rule_Code, " & vbCrLf)
    '        var1.Append("             '3', " & vbCrLf)
    '        var1.Append("             'D00003', " & vbCrLf)
    '        var1.Append("             '', " & vbCrLf)
    '        var1.Append("             '02', " & vbCrLf)
    '        var1.Append("             @Dept_Code, " & vbCrLf)
    '        var1.Append("             '', " & vbCrLf)
    '        var1.Append("             'Y', " & vbCrLf)
    '        var1.Append("             'Y', " & vbCrLf)
    '        var1.Append("             'Y', " & vbCrLf)
    '        var1.Append("             'AND', " & vbCrLf)
    '        var1.Append("             @User, " & vbCrLf)
    '        var1.Append("             @Now, " & vbCrLf)
    '        var1.Append("             0) " & vbCrLf)
    '    End If

    '    If StrictOrderCode <> String.Empty OrElse LimitedDeptCode <> String.Empty OrElse LimitedSexId <> String.Empty Then
    '        var1.Append("INSERT INTO PUB_Rule_Detail " & vbCrLf)
    '        var1.Append("            (Rule_Code, " & vbCrLf)
    '        var1.Append("             Seq_No, " & vbCrLf)
    '        var1.Append("             Item_Code, " & vbCrLf)
    '        var1.Append("             Item_Param, " & vbCrLf)
    '        var1.Append("             Operator_Code, " & vbCrLf)
    '        var1.Append("             Value_Data, " & vbCrLf)
    '        var1.Append("             Value_Unit, " & vbCrLf)
    '        var1.Append("             Is_Count_O, " & vbCrLf)
    '        var1.Append("             Is_Count_E, " & vbCrLf)
    '        var1.Append("             Is_Count_I, " & vbCrLf)
    '        var1.Append("             Logical_Symbol, " & vbCrLf)
    '        var1.Append("             Create_User, " & vbCrLf)
    '        var1.Append("             Create_Time, " & vbCrLf)
    '        var1.Append("             Rule_Maintain_Sn) " & vbCrLf)
    '        var1.Append("VALUES      (@Rule_Code + '-S1', " & vbCrLf)
    '        var1.Append("             '1', " & vbCrLf)
    '        var1.Append("             'A00004', " & vbCrLf)
    '        var1.Append("             '', " & vbCrLf)
    '        var1.Append("             '02', " & vbCrLf)
    '        var1.Append("             @Order_Code, " & vbCrLf)
    '        var1.Append("             '', " & vbCrLf)
    '        var1.Append("             'Y', " & vbCrLf)
    '        var1.Append("             'Y', " & vbCrLf)
    '        var1.Append("             'Y', " & vbCrLf)
    '        var1.Append("             'OR', " & vbCrLf)
    '        var1.Append("             @User, " & vbCrLf)
    '        var1.Append("             @Now, " & vbCrLf)
    '        var1.Append("             0) ")
    '    End If

    '    Dim _cnt As Int32 = 0
    '    Try
    '        Dim _sqlConnection As SqlConnection = conn

    '        Using trans As New TransactionScope

    '            Dim _command As New SqlCommand(var1.ToString(), _sqlConnection)
    '            _command.CommandType = CommandType.Text
    '            _command.Parameters.AddWithValue("@Rule_Code", OrderRule)
    '            _command.Parameters.AddWithValue("@Order_Code", OrderCode)
    '            _command.Parameters.AddWithValue("@Strict_Order_Code", StrictOrderCode)
    '            _command.Parameters.AddWithValue("@Sex_Id", LimitedSexId)
    '            _command.Parameters.AddWithValue("@Dept_Code", LimitedDeptCode)
    '            _command.Parameters.AddWithValue("@User", User)
    '            _command.Parameters.AddWithValue("@Now", Now)
    '            _cnt += _command.ExecuteNonQuery()

    '            trans.Complete()
    '        End Using 'End Transaction
    '    Catch ex As Exception
    '        Throw ex
    '    End Try

    '    Return _cnt
    'End Function

    Private Function InsertPUBRuleDetail(ByVal OrderRule As String, _
                                         ByVal OrderCode As String, _
                                         ByVal StrictType As StrictRuleType, _
                                         ByVal StrictRule As String, _
                                         ByVal User As String, _
                                         ByVal conn As SqlConnection) As Int32
        Dim var1 As New System.Text.StringBuilder


        Select Case StrictType
            Case StrictRuleType.OrderCode
                var1.Append("INSERT INTO PUB_Rule_Detail " & vbCrLf)
                var1.Append("            (Rule_Code, " & vbCrLf)
                var1.Append("             Seq_No, " & vbCrLf)
                var1.Append("             Item_Code, " & vbCrLf)
                var1.Append("             Item_Param, " & vbCrLf)
                var1.Append("             Operator_Code, " & vbCrLf)
                var1.Append("             Value_Data, " & vbCrLf)
                var1.Append("             Value_Unit, " & vbCrLf)
                var1.Append("             Is_Count_O, " & vbCrLf)
                var1.Append("             Is_Count_E, " & vbCrLf)
                var1.Append("             Is_Count_I, " & vbCrLf)
                var1.Append("             Logical_Symbol, " & vbCrLf)
                var1.Append("             Create_User, " & vbCrLf)
                var1.Append("             Create_Time, " & vbCrLf)
                var1.Append("             Rule_Maintain_Sn) " & vbCrLf)
                var1.Append("VALUES      (@Rule_Code, " & vbCrLf)
                var1.Append("             '1', " & vbCrLf)
                var1.Append("             'A00005', " & vbCrLf)
                var1.Append("             '', " & vbCrLf)
                var1.Append("             '11', " & vbCrLf)
                var1.Append("             @Strict_Rule, " & vbCrLf) '#################################
                var1.Append("             '', " & vbCrLf)
                var1.Append("             'Y', " & vbCrLf)
                var1.Append("             'Y', " & vbCrLf)
                var1.Append("             'Y', " & vbCrLf)
                var1.Append("             'AND', " & vbCrLf)
                var1.Append("             @User, " & vbCrLf)
                var1.Append("             @Now, " & vbCrLf)
                var1.Append("             0) " & vbCrLf)
            Case StrictRuleType.DeptCode
                var1.Append("INSERT INTO PUB_Rule_Detail " & vbCrLf)
                var1.Append("            (Rule_Code, " & vbCrLf)
                var1.Append("             Seq_No, " & vbCrLf)
                var1.Append("             Item_Code, " & vbCrLf)
                var1.Append("             Item_Param, " & vbCrLf)
                var1.Append("             Operator_Code, " & vbCrLf)
                var1.Append("             Value_Data, " & vbCrLf)
                var1.Append("             Value_Unit, " & vbCrLf)
                var1.Append("             Is_Count_O, " & vbCrLf)
                var1.Append("             Is_Count_E, " & vbCrLf)
                var1.Append("             Is_Count_I, " & vbCrLf)
                var1.Append("             Logical_Symbol, " & vbCrLf)
                var1.Append("             Create_User, " & vbCrLf)
                var1.Append("             Create_Time, " & vbCrLf)
                var1.Append("             Rule_Maintain_Sn) " & vbCrLf)
                var1.Append("VALUES      (@Rule_Code, " & vbCrLf)
                var1.Append("             '3', " & vbCrLf)
                var1.Append("             'D00003', " & vbCrLf)
                var1.Append("             '', " & vbCrLf)
                var1.Append("             '02', " & vbCrLf)
                var1.Append("             @Strict_Rule, " & vbCrLf)
                var1.Append("             '', " & vbCrLf)
                var1.Append("             'Y', " & vbCrLf)
                var1.Append("             'Y', " & vbCrLf)
                var1.Append("             'Y', " & vbCrLf)
                var1.Append("             'AND', " & vbCrLf)
                var1.Append("             @User, " & vbCrLf)
                var1.Append("             @Now, " & vbCrLf)
                var1.Append("             0) " & vbCrLf)
            Case StrictRuleType.SexId
                var1.Append("INSERT INTO PUB_Rule_Detail " & vbCrLf)
                var1.Append("            (Rule_Code, " & vbCrLf)
                var1.Append("             Seq_No, " & vbCrLf)
                var1.Append("             Item_Code, " & vbCrLf)
                var1.Append("             Item_Param, " & vbCrLf)
                var1.Append("             Operator_Code, " & vbCrLf)
                var1.Append("             Value_Data, " & vbCrLf)
                var1.Append("             Value_Unit, " & vbCrLf)
                var1.Append("             Is_Count_O, " & vbCrLf)
                var1.Append("             Is_Count_E, " & vbCrLf)
                var1.Append("             Is_Count_I, " & vbCrLf)
                var1.Append("             Logical_Symbol, " & vbCrLf)
                var1.Append("             Create_User, " & vbCrLf)
                var1.Append("             Create_Time, " & vbCrLf)
                var1.Append("             Rule_Maintain_Sn) " & vbCrLf)
                var1.Append("VALUES      (@Rule_Code, " & vbCrLf)
                var1.Append("             '2', " & vbCrLf)
                var1.Append("             'E00002', " & vbCrLf)
                var1.Append("             '', " & vbCrLf)
                var1.Append("             '02', " & vbCrLf)
                var1.Append("             @Strict_Rule, " & vbCrLf)
                var1.Append("             '', " & vbCrLf)
                var1.Append("             'Y', " & vbCrLf)
                var1.Append("             'Y', " & vbCrLf)
                var1.Append("             'Y', " & vbCrLf)
                var1.Append("             'AND', " & vbCrLf)
                var1.Append("             @User, " & vbCrLf)
                var1.Append("             @Now, " & vbCrLf)
                var1.Append("             0) " & vbCrLf)
            Case StrictRuleType.DoctCode
                var1.Append("INSERT INTO PUB_Rule_Detail " & vbCrLf)
                var1.Append("            (Rule_Code, " & vbCrLf)
                var1.Append("             Seq_No, " & vbCrLf)
                var1.Append("             Item_Code, " & vbCrLf)
                var1.Append("             Item_Param, " & vbCrLf)
                var1.Append("             Operator_Code, " & vbCrLf)
                var1.Append("             Value_Data, " & vbCrLf)
                var1.Append("             Value_Unit, " & vbCrLf)
                var1.Append("             Is_Count_O, " & vbCrLf)
                var1.Append("             Is_Count_E, " & vbCrLf)
                var1.Append("             Is_Count_I, " & vbCrLf)
                var1.Append("             Logical_Symbol, " & vbCrLf)
                var1.Append("             Create_User, " & vbCrLf)
                var1.Append("             Create_Time, " & vbCrLf)
                var1.Append("             Rule_Maintain_Sn) " & vbCrLf)
                var1.Append("VALUES      (@Rule_Code, " & vbCrLf)
                var1.Append("             '3', " & vbCrLf)
                var1.Append("             'D00016', " & vbCrLf)
                var1.Append("             '', " & vbCrLf)
                var1.Append("             '02', " & vbCrLf)
                var1.Append("             @Strict_Rule, " & vbCrLf)
                var1.Append("             '', " & vbCrLf)
                var1.Append("             'Y', " & vbCrLf)
                var1.Append("             'Y', " & vbCrLf)
                var1.Append("             'Y', " & vbCrLf)
                var1.Append("             'AND', " & vbCrLf)
                var1.Append("             @User, " & vbCrLf)
                var1.Append("             @Now, " & vbCrLf)
                var1.Append("             0) " & vbCrLf)
            Case Else
                var1.Append("             ''" & vbCrLf)
        End Select

        var1.Append("INSERT INTO PUB_Rule_Detail " & vbCrLf)
        var1.Append("            (Rule_Code, " & vbCrLf)
        var1.Append("             Seq_No, " & vbCrLf)
        var1.Append("             Item_Code, " & vbCrLf)
        var1.Append("             Item_Param, " & vbCrLf)
        var1.Append("             Operator_Code, " & vbCrLf)
        var1.Append("             Value_Data, " & vbCrLf)
        var1.Append("             Value_Unit, " & vbCrLf)
        var1.Append("             Is_Count_O, " & vbCrLf)
        var1.Append("             Is_Count_E, " & vbCrLf)
        var1.Append("             Is_Count_I, " & vbCrLf)
        var1.Append("             Logical_Symbol, " & vbCrLf)
        var1.Append("             Create_User, " & vbCrLf)
        var1.Append("             Create_Time, " & vbCrLf)
        var1.Append("             Rule_Maintain_Sn) " & vbCrLf)
        var1.Append("VALUES      (@Rule_Code + '-S1', " & vbCrLf)
        var1.Append("             '1', " & vbCrLf)
        var1.Append("             'A00004', " & vbCrLf)
        var1.Append("             '', " & vbCrLf)
        var1.Append("             '02', " & vbCrLf)
        var1.Append("             @Order_Code, " & vbCrLf)
        var1.Append("             '', " & vbCrLf)
        var1.Append("             'Y', " & vbCrLf)
        var1.Append("             'Y', " & vbCrLf)
        var1.Append("             'Y', " & vbCrLf)
        var1.Append("             'OR', " & vbCrLf)
        var1.Append("             @User, " & vbCrLf)
        var1.Append("             @Now, " & vbCrLf)
        var1.Append("             0) ")

        Dim _cnt As Int32 = 0
        Try
            Dim _sqlConnection As SqlConnection = conn

            Using trans As TransactionScope = SQLConnFactory.getInstance.getRequiredTransactionScope


                Dim _command As New SqlCommand(var1.ToString(), _sqlConnection)
                _command.CommandType = CommandType.Text
                _command.Parameters.AddWithValue("@Rule_Code", OrderRule)
                _command.Parameters.AddWithValue("@Order_Code", OrderCode)
                _command.Parameters.AddWithValue("@Strict_Rule", StrictRule)
                _command.Parameters.AddWithValue("@User", User)
                _command.Parameters.AddWithValue("@Now", Now)
                _cnt += _command.ExecuteNonQuery()

                trans.Complete()
            End Using 'End Transaction
        Catch ex As Exception
            Throw ex
        End Try

        Return _cnt
    End Function

    Private Function SetPubOrderIsCheck(ByVal OrderCode As String, ByVal IsOrderCheck As String, ByVal User As String, ByVal conn As SqlConnection) As Int32
        Dim var1 As New System.Text.StringBuilder
        var1.Append("UPDATE PUB_Order " & vbCrLf)
        var1.Append("SET    Is_Order_Check = @Is_Order_Check, " & vbCrLf)
        var1.Append("       Modified_User = @User, " & vbCrLf)
        var1.Append("       Modified_Time = @Now " & vbCrLf)
        var1.Append("WHERE  Order_Code = @Order_Code " & vbCrLf)
        var1.Append("       AND Effect_Date < @Now " & vbCrLf)
        var1.Append("       AND Dc = 'N' " & vbCrLf)
        Dim _sqlConnection As SqlConnection = conn
        Dim connFlag As Boolean = conn Is Nothing
        Dim _cnt As Int32 = 0
        Try
            If connFlag Then
                _sqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
                _sqlConnection.Open()
            End If
            If _sqlConnection.State <> ConnectionState.Open Then _sqlConnection.Open()

            Dim _command As New SqlCommand(var1.ToString(), _sqlConnection)
            _command.CommandType = CommandType.Text
            _command.Parameters.AddWithValue("@Order_Code", OrderCode)
            _command.Parameters.AddWithValue("@Is_Order_Check", IsOrderCheck)
            _command.Parameters.AddWithValue("@User", User)
            _command.Parameters.AddWithValue("@Now", Now)
            _cnt += _command.ExecuteNonQuery()

        Catch ex As Exception
            Throw ex
        Finally

            If connFlag AndAlso _sqlConnection IsNot Nothing Then
                _sqlConnection.Close()
                _sqlConnection.Dispose()
                _sqlConnection = Nothing
            End If
        End Try

        Return _cnt
    End Function
#End Region

End Class

