'Imports Com.Syscom.WinFormsUI.Docking
Imports Syscom.Client.Servicefactory
Imports Syscom.Client.UCL
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
Imports Syscom.Client.CMM
Imports System.Text


Imports System.Runtime.InteropServices
Imports System.Windows.Forms
Imports Syscom.Client.PUB
Imports System.Xml

Public Class PUBIcdRuleCheckUI

    Dim ChartNo As String = ""
    Dim OutpatientSn As String = ""

    Dim OrderCode As String = ""
    Dim OpdVisitDate As String = ""

    Dim pubService As IPubServiceManager = PubServiceManager.getInstance

    Dim currentUserID As String = AppContext.userProfile.userId '目前使用者的ID
    'Dim log As ILog = LOGDelegate.GetInstance.getFileLogger(Me)
    Dim TriggerItemDS, OperationDS As New DataSet
    Dim ReturnDS As DataSet
    Dim IcdCheckRootSelected As String()

    Dim GridDS As New DataSet
    Dim GridSaveDS As New DataSet
    Dim IsRootContainPriorReview As Boolean = False
    Dim IsCheckPUBOrderPriorReview As Boolean = False

    Dim GridHash0 As New Hashtable
    Dim GridHash1 As New Hashtable
    Dim GridHash2 As New Hashtable
    Dim GridHash3 As New Hashtable
    'Dim GridHash4 As New Hashtable

    Dim CurrentCheckedNodeLevel As Integer = 0


    Dim SelectedNode0 As New ArrayList
    Dim SelectedNode1 As New ArrayList
    Dim SelectedNode2 As New ArrayList
    Dim SelectedNode3 As New ArrayList
    Dim DoOrderCheck As Boolean = True
    Dim LastNodeLevel As Integer = 0

    Dim ErrorNodePathList As New ArrayList
    Dim IsBackLastItem As Boolean = False


#Region "移除CheckBox"

    <DllImport("user32.dll")> _
    Public Shared Function SendMessage(ByVal hWnd As Integer, ByVal Msg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer

    End Function

    Dim TVIF_STATE As Integer = &H8

    Dim TVIS_STATEIMAGEMASK As Integer = &HF000

    Dim TV_FIRST As Integer = &H1100

    Dim TVM_SETITEM As Integer = TV_FIRST + 63

    Dim TVM_SETBKCOLOR As Integer = &H111D


    Private Structure TVITEM

        Public mask As Integer

        Public hItem As Integer

        Public state As Integer

        Public stateMask As Integer

        Public lpszText As String

        Public cchTextMax As Integer

        Public iImage As Integer

        Public iSelectedImage As Integer

        Public cChildren As Integer

        Public lParam As Integer

    End Structure

    Private Structure ColorRef

        Public idx_R As Byte

        Public idx_G As Byte

        Public idx_B As Byte

    End Structure


    Private Function RemoveChk(ByVal node As TreeNode) As Integer

        Try
             
            'Dim n As Integer

            Dim lparam As Integer

            Dim tvItem As New TVITEM
             
            tvItem.hItem = node.Handle

            tvItem.mask = TVIF_STATE

            tvItem.stateMask = TVIS_STATEIMAGEMASK

            tvItem.state = 0

            lparam = Marshal.AllocHGlobal(Marshal.SizeOf(tvItem))

            Marshal.StructureToPtr(tvItem, lparam, False)

            SendMessage(node.TreeView.Handle, TVM_SETITEM, IntPtr.Zero, lparam)

        Catch ex As Exception

        End Try

    End Function


#End Region


    Public Overloads Function ShowDialog() As DataSet
        Try


            MyBase.ShowDialog()

            Return ReturnDS

        Catch ex As Exception
            Return ReturnDS
        End Try

    End Function

    Sub New()

        ' 此為 Windows Form 設計工具所需的呼叫。
        InitializeComponent()

        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。
        'Initial()
    End Sub


    Sub New(ByVal Chart_No As String, ByVal Order_Code As String, ByVal Order_En_Name As String, ByVal Opd_Visit_Date As String, ByVal IcdCheck_RootSelected As String, ByVal ds As DataSet, Optional ByVal CanNotForcedMsg As String = "", Optional ByVal Outpatient_Sn As String = "")

        ' 此為 Windows Form 設計工具所需的呼叫。
        InitializeComponent()

        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。
        ChartNo = Chart_No
        OrderCode = Order_Code
        OpdVisitDate = Opd_Visit_Date
        OutpatientSn = Outpatient_Sn
        'Initial()

        If ds IsNot Nothing Then

            TriggerItemDS.Tables.Add(ds.Tables("Trigger_Item").Copy)
            ds.Tables.Remove("Trigger_Item")
            OperationDS = ds.Copy
        Else
            DoOrderCheck = False
        End If


        Me.Text = "適應症檢核-" & Order_En_Name.Trim

        Label1.Text = Order_En_Name.Trim

        If IcdCheck_RootSelected <> "" Then
            IcdCheckRootSelected = Split(IcdCheck_RootSelected, ",")
        End If

        GridDS.Tables.Add()

        GridDS.Tables(0).Columns.Add("Rule_name")
        GridDS.Tables(0).Columns.Add("ValueData")
        GridDS.Tables(0).Columns.Add("ValueUnitCode")

        GridDS.Tables(0).Columns.Add("Logical_Symbol")
        GridDS.Tables(0).Columns.Add("Limit_Alert_Level")
        GridDS.Tables(0).Columns.Add("Is_Bypass_Check")
        GridDS.Tables(0).Columns.Add("Is_Prior_Review")
        GridDS.Tables(0).Columns.Add("Check_Type")
        GridDS.Tables(0).Columns.Add("Rule_Code")
        GridDS.Tables(0).Columns.Add("ParentNodePath")
        GridDS.Tables(0).Columns.Add("ActionState")



        Dim hash As New Hashtable
        Dim txtCell As New TextBoxCell
        txtCell.MaxLength = 30

        Dim txtCell2 As New TextBoxCell
        txtCell2.MaxLength = 30

        hash.Add(-1, GridDS.Copy)
        hash.Add(1, txtCell)
        hash.Add(2, txtCell2)

        dg1.uclVisibleColIndex = "0,1,2,3"


        dg1.Initial(hash)

        dg1.uclColumnWidth = "120,  70,  70,100"
        dg1.uclHeaderText = "項目,輸入值,單位"

        Label3.Text = ""

        If CanNotForcedMsg <> "" Then
            btn_Force.Enabled = False
            Label3.Text = CanNotForcedMsg
        End If

    End Sub

    Public Function Initial() As Boolean

        Try

            Dim ds As New DataSet

            ds.Tables.Add()
            ds.Tables(0).Columns.Add("Action")
            ds.Tables(0).Columns.Add("Order_Code")
            ds.Tables(0).Columns.Add("OpdVisitDate")
            ds.Tables(0).Columns.Add("ChartNo")

            ds.Tables(0).Rows.Add()

            ds.Tables(0).Rows(0).Item("Action") = "QueryByOrderCode"
            ds.Tables(0).Rows(0).Item("Order_Code") = OrderCode
            ds.Tables(0).Rows(0).Item("OpdVisitDate") = CDate(OpdVisitDate).ToShortDateString
            ds.Tables(0).Rows(0).Item("ChartNo") = ChartNo

            Dim ResultDS As DataSet

            ResultDS = pubService.DoPubAction(ds)

            If ResultDS IsNot Nothing AndAlso ResultDS.Tables.Count > 0 AndAlso ResultDS.Tables(0).Rows.Count > 0 Then

                If ResultDS.Tables.Count > 1 AndAlso ResultDS.Tables(1).Rows.Count > 0 AndAlso ResultDS.Tables(2).Rows.Count > 0 Then


                    For i As Integer = 0 To ResultDS.Tables(1).Rows.Count - 1

                        tr1_View.Nodes.Add(ResultDS.Tables(1).Rows(i).Item("Rule_name").ToString.Trim)
                        tr1_View.Nodes(i).ToolTipText = ResultDS.Tables(1).Rows(i).Item("ExpressionStr").ToString.Trim

                        tr1_View.Nodes(i).Tag = ResultDS.Tables(1).Rows(i).Item("Rule_Code").ToString.Trim & "#" & ResultDS.Tables(1).Rows(i).Item("Logical_Symbol").ToString.Trim & "#" & ResultDS.Tables(1).Rows(i).Item("Limit_Alert_Level").ToString.Trim & "#" & ResultDS.Tables(1).Rows(i).Item("Is_Bypass_Check").ToString.Trim & "#" & ResultDS.Tables(1).Rows(i).Item("Is_Prior_Review").ToString.Trim & "#" & ResultDS.Tables(1).Rows(i).Item("Check_Type").ToString.Trim


                        If ResultDS.Tables(1).Rows(i).Item("Is_Prior_Review").ToString.Trim = "Y" Then
                            IsRootContainPriorReview = True
                        End If

                    Next

                    If CInt(ResultDS.Tables(2).Rows(0).Item(0)) = 0 Then
                        IsCheckPUBOrderPriorReview = True
                    End If


                End If

                If ResultDS.Tables(0).Rows(0).Item("Info_Message") IsNot DBNull.Value Then
                    RichTextBox1.Text = "(若有疑義請聯絡" & ResultDS.Tables(0).Rows(0).Item("Ext_No").ToString.Trim & ")" & vbCrLf & ResultDS.Tables(0).Rows(0).Item("Info_Message").ToString.Trim

                End If



                If IcdCheckRootSelected IsNot Nothing AndAlso IcdCheckRootSelected.Count > 0 Then
                    For i As Integer = 0 To IcdCheckRootSelected.Count - 1
                        For j As Integer = 0 To tr1_View.Nodes.Count - 1
                            If IsNumeric(IcdCheckRootSelected(i)) AndAlso CInt(IcdCheckRootSelected(i)) = j AndAlso tr1_View.Nodes(j).Level = 0 Then
                                tr1_View.Nodes(j).Checked = True
                            End If
                        Next

                        If IcdCheckRootSelected(i).Trim.Contains("@") Then
                            txt_Other.Text = IcdCheckRootSelected(i).Trim.Replace("@", "")
                        End If

                    Next

                End If

                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function



    Private Sub tr_AfterCheck(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tr1_View.AfterCheck


        Try
            ScreenUtil.Lock(Me)
            Dim HasNodes As Boolean = False



            If e.Node.Checked Then
                CurrentCheckedNodeLevel = e.Node.Level

                If Split(e.Node.Tag, "#")(3).Trim <> "Y" Then
                    If Not CheckSingleOrder(Split(e.Node.Tag, "#")(0).Trim) Then
                        '檢核未通過
                        e.Node.BackColor = Drawing.Color.Pink
                        If Not ErrorNodePathList.Contains(e.Node.FullPath) Then
                            ErrorNodePathList.Add(e.Node.FullPath)
                        End If


                        Exit Sub
                    End If
                End If

                '檢核dgv的輸入
                If Not CheckDgvData() Then
                    IsBackLastItem = True
                    e.Node.Checked = False
                    IsBackLastItem = False
                    Exit Sub
                End If

                e.Node.BackColor = Drawing.Color.White

                '檢核通過


                '找Child Rule 如果本身有 就不再產生

                If e.Node.Nodes.Count > 0 Then
                    HasNodes = True
                End If

                Dim ds As New DataSet

                ds.Tables.Add()
                ds.Tables(0).Columns.Add("Action")
                ds.Tables(0).Columns.Add("Rule_Code")
                ds.Tables(0).Columns.Add("OpdVisitDate")
                ds.Tables(0).Columns.Add("ChartNo")

                ds.Tables(0).Rows.Add()

                ds.Tables(0).Rows(0).Item("Action") = "QueryByRuleCode"
                ds.Tables(0).Rows(0).Item("Rule_Code") = Split(e.Node.Tag, "#")(0).Trim
                ds.Tables(0).Rows(0).Item("OpdVisitDate") = CDate(OpdVisitDate).ToShortDateString
                ds.Tables(0).Rows(0).Item("ChartNo") = ChartNo

                Dim ResultDS As DataSet

                ResultDS = pubService.DoPubAction(ds)

                dg1.CurrentCell = Nothing

                For i As Integer = 0 To dg1.Rows.Count - 1
                    dg1.Rows(i).Visible = False
                Next

                If e.Node.Level = 0 Then
                    If SelectedNode0.Contains(e.Node.FullPath) Then
                        SelectedNode0.Remove(e.Node.FullPath)
                    End If
                    SelectedNode0.Add(e.Node.FullPath)

                ElseIf e.Node.Level = 1 Then
                    If SelectedNode1.Contains(e.Node.FullPath) Then
                        SelectedNode1.Remove(e.Node.FullPath)
                    End If
                    SelectedNode1.Add(e.Node.FullPath)

                ElseIf e.Node.Level = 2 Then
                    If SelectedNode2.Contains(e.Node.FullPath) Then
                        SelectedNode2.Remove(e.Node.FullPath)
                    End If
                    SelectedNode2.Add(e.Node.FullPath)

                ElseIf e.Node.Level = 3 Then
                    If SelectedNode3.Contains(e.Node.FullPath) Then
                        SelectedNode3.Remove(e.Node.FullPath)
                    End If
                    SelectedNode3.Add(e.Node.FullPath)

                End If



                '儲存上一個Grid資訊
                If dg1.GetDBDS IsNot Nothing AndAlso dg1.GetDBDS.Tables(0).Rows.Count > 0 Then
                    'e.Node.FullPath

                    If LastNodeLevel = 0 Then

                        If GridHash0.ContainsKey(dg1.GetDBDS.Tables(0).Rows(0).Item("ParentNodePath").ToString.Trim) Then
                            GridHash0.Remove(dg1.GetDBDS.Tables(0).Rows(0).Item("ParentNodePath").ToString.Trim)
                        End If

                        GridHash0.Add(dg1.GetDBDS.Tables(0).Rows(0).Item("ParentNodePath").ToString.Trim, dg1.GetDBDS.Copy)

                    ElseIf LastNodeLevel = 1 Then

                        If GridHash1.ContainsKey(dg1.GetDBDS.Tables(0).Rows(0).Item("ParentNodePath").ToString.Trim) Then
                            GridHash1.Remove(dg1.GetDBDS.Tables(0).Rows(0).Item("ParentNodePath").ToString.Trim)
                        End If

                        GridHash1.Add(dg1.GetDBDS.Tables(0).Rows(0).Item("ParentNodePath").ToString.Trim, dg1.GetDBDS.Copy)


                    ElseIf LastNodeLevel = 2 Then

                        If GridHash2.ContainsKey(dg1.GetDBDS.Tables(0).Rows(0).Item("ParentNodePath").ToString.Trim) Then
                            GridHash2.Remove(dg1.GetDBDS.Tables(0).Rows(0).Item("ParentNodePath").ToString.Trim)
                        End If

                        GridHash2.Add(dg1.GetDBDS.Tables(0).Rows(0).Item("ParentNodePath").ToString.Trim, dg1.GetDBDS.Copy)


                    ElseIf LastNodeLevel = 3 Then

                        If GridHash3.ContainsKey(dg1.GetDBDS.Tables(0).Rows(0).Item("ParentNodePath").ToString.Trim) Then
                            GridHash3.Remove(dg1.GetDBDS.Tables(0).Rows(0).Item("ParentNodePath").ToString.Trim)
                        End If

                        GridHash3.Add(dg1.GetDBDS.Tables(0).Rows(0).Item("ParentNodePath").ToString.Trim, dg1.GetDBDS.Copy)


                    End If

                End If

                '==================取出目前的Grid 資料 可能沒有
                Dim CurrentGridDS As New DataSet

                If e.Node.Level = 0 Then

                    If GridHash0.ContainsKey(e.Node.FullPath) Then
                        CurrentGridDS = CType(GridHash0(e.Node.FullPath), DataSet).Copy
                    End If

                ElseIf e.Node.Level = 1 Then

                    If GridHash1.ContainsKey(e.Node.FullPath) Then
                        CurrentGridDS = CType(GridHash1(e.Node.FullPath), DataSet).Copy
                    End If

                ElseIf e.Node.Level = 2 Then

                    If GridHash2.ContainsKey(e.Node.FullPath) Then
                        CurrentGridDS = CType(GridHash2(e.Node.FullPath), DataSet).Copy
                    End If


                ElseIf e.Node.Level = 3 Then

                    If GridHash3.ContainsKey(e.Node.FullPath) Then
                        CurrentGridDS = CType(GridHash3(e.Node.FullPath), DataSet).Copy
                    End If

                End If



                If CurrentGridDS.Tables.Count > 0 AndAlso CurrentGridDS.Tables(0).Rows.Count > 0 Then

                    GridDS.Tables.Clear()
                    GridDS.Tables.Add(CurrentGridDS.Tables(0).Copy)

                Else

                    '目前的Item還沒有GridView Data 
                    GridDS.Tables(0).Rows.Clear()
                    Dim GridCheckWrongIndex As New ArrayList
                    Dim RulenameList As New ArrayList

                    If ResultDS IsNot Nothing AndAlso ResultDS.Tables.Count > 0 AndAlso ResultDS.Tables(0).Rows.Count > 0 Then

                        For i As Integer = 0 To ResultDS.Tables(0).Rows.Count - 1

                            If ResultDS.Tables(0).Rows(i).Item("Input_Notice_Label") IsNot DBNull.Value AndAlso ResultDS.Tables(0).Rows(i).Item("Input_Notice_Label").ToString.Trim <> "" Then

                                GridDS.Tables(0).Rows.Add()
                                GridDS.Tables(0).Rows(GridDS.Tables(0).Rows.Count - 1).Item("Rule_name") = ResultDS.Tables(0).Rows(i).Item("Rule_name").ToString.Trim
                                GridDS.Tables(0).Rows(GridDS.Tables(0).Rows.Count - 1).Item("ValueData") = ""
                                GridDS.Tables(0).Rows(GridDS.Tables(0).Rows.Count - 1).Item("ValueUnitCode") = ""

                                GridDS.Tables(0).Rows(GridDS.Tables(0).Rows.Count - 1).Item("Logical_Symbol") = ResultDS.Tables(0).Rows(i).Item("Logical_Symbol").ToString.Trim

                                GridDS.Tables(0).Rows(GridDS.Tables(0).Rows.Count - 1).Item("Limit_Alert_Level") = ResultDS.Tables(0).Rows(i).Item("Limit_Alert_Level").ToString.Trim

                                GridDS.Tables(0).Rows(GridDS.Tables(0).Rows.Count - 1).Item("Is_Bypass_Check") = ResultDS.Tables(0).Rows(i).Item("Is_Bypass_Check").ToString.Trim

                                GridDS.Tables(0).Rows(GridDS.Tables(0).Rows.Count - 1).Item("Is_Prior_Review") = ResultDS.Tables(0).Rows(i).Item("Is_Prior_Review").ToString.Trim

                                GridDS.Tables(0).Rows(GridDS.Tables(0).Rows.Count - 1).Item("Check_Type") = ResultDS.Tables(0).Rows(i).Item("Check_Type").ToString.Trim

                                GridDS.Tables(0).Rows(GridDS.Tables(0).Rows.Count - 1).Item("Rule_Code") = ResultDS.Tables(0).Rows(i).Item("Rule_Code").ToString.Trim

                                GridDS.Tables(0).Rows(GridDS.Tables(0).Rows.Count - 1).Item("ParentNodePath") = e.Node.FullPath

                                GridDS.Tables(0).Rows(GridDS.Tables(0).Rows.Count - 1).Item("ActionState") = "Insert"

                                Try


                                    If ResultDS.Tables(0).Rows(i).Item("Is_Bypass_Check").ToString.Trim <> "Y" Then
                                        If Not CheckSingleOrder(ResultDS.Tables(0).Rows(i).Item("Rule_Code").ToString.Trim) Then
                                            '檢核未通過
                                            GridCheckWrongIndex.Add(i.ToString)
                                        End If
                                    End If

                                Catch ex As Exception

                                End Try



                                If Not RulenameList.Contains(ResultDS.Tables(0).Rows(i).Item("Rule_name").ToString.Trim) Then
                                    RulenameList.Add(ResultDS.Tables(0).Rows(i).Item("Rule_name").ToString.Trim)
                                End If


                            Else
                                If Not HasNodes Then
                                    e.Node.Nodes.Add(ResultDS.Tables(0).Rows(i).Item("Rule_name").ToString.Trim)
                                    e.Node.Nodes(i).ToolTipText = ResultDS.Tables(0).Rows(i).Item("Expression_Str").ToString.Trim
                                    e.Node.Nodes(i).Tag = ResultDS.Tables(0).Rows(i).Item("Rule_Code").ToString.Trim & "#" & ResultDS.Tables(0).Rows(i).Item("Logical_Symbol").ToString.Trim & "#" & ResultDS.Tables(0).Rows(i).Item("Limit_Alert_Level").ToString.Trim & "#" & ResultDS.Tables(0).Rows(i).Item("Is_Bypass_Check").ToString.Trim & "#" & ResultDS.Tables(0).Rows(i).Item("Is_Prior_Review").ToString.Trim & "#" & ResultDS.Tables(0).Rows(i).Item("Check_Type").ToString.Trim

                                End If

                            End If

                        Next


                    End If


                    If GridDS.Tables(0).Rows.Count > 0 Then

                        Try
                            For i As Integer = 0 To GridDS.Tables(0).Rows.Count - 1
                                If GridDS.Tables(0).Rows(i).Item("ValueData").ToString.Trim = "" Then
                                    GridDS.Tables(0).Rows(i).Item("ValueData") = "."
                                End If
                            Next
                        Catch ex As Exception

                        End Try


                        dg1.SetDS(GridDS.Copy)

                        If RulenameList.Count > 0 Then
                            ReadGridXML(RulenameList)
                        End If

                        Try
                            For x As Integer = 0 To GridCheckWrongIndex.Count - 1
                                dg1.SetColColor(CInt(GridCheckWrongIndex(x)), Drawing.Color.Pink)
                            Next
                        Catch ex As Exception

                        End Try


                    End If



                    e.Node.ExpandAll()

                    For j As Integer = 0 To e.Node.Nodes.Count - 1

                        If Split(e.Node.Nodes(j).Tag, "#")(3).Trim <> "Y" Then
                            If Not CheckSingleOrder(Split(e.Node.Nodes(j).Tag, "#")(0).Trim) Then
                                e.Node.Nodes(j).BackColor = Drawing.Color.Pink

                                'If Not ErrorNodePathList.Contains(e.Node.Nodes(j).FullPath) Then
                                '    ErrorNodePathList.Add(e.Node.Nodes(j).FullPath)
                                'End If

                                RemoveChk(e.Node.Nodes(j))
                                Continue For
                            End If
                        End If

                        e.Node.Nodes(j).BackColor = Drawing.Color.White

                        '看有沒有Child Node
                        '找Child Rule
                        Dim ds1 As New DataSet

                        ds1.Tables.Add()
                        ds1.Tables(0).Columns.Add("Action")
                        ds1.Tables(0).Columns.Add("Rule_Code")
                        ds1.Tables(0).Columns.Add("OpdVisitDate")
                        ds1.Tables(0).Columns.Add("ChartNo")

                        ds1.Tables(0).Rows.Add()

                        ds1.Tables(0).Rows(0).Item("Action") = "QueryByRuleCode"
                        ds1.Tables(0).Rows(0).Item("Rule_Code") = Split(e.Node.Nodes(j).Tag, "#")(0).Trim
                        ds1.Tables(0).Rows(0).Item("OpdVisitDate") = CDate(OpdVisitDate).ToShortDateString
                        ds.Tables(0).Rows(0).Item("ChartNo") = ChartNo

                        Dim ResultDS1 As DataSet

                        ResultDS1 = pubService.DoPubAction(ds1)

                        If ResultDS1 IsNot Nothing AndAlso ResultDS1.Tables.Count > 0 AndAlso ResultDS1.Tables(0).Rows.Count > 0 Then

                        Else
                            'RemoveChk(e.Node.Nodes(j))
                        End If

                    Next

                End If

                LastNodeLevel = e.Node.Level

            Else

                If IsBackLastItem Then
                    Exit Sub
                End If

                '沒勾
                e.Node.BackColor = Drawing.Color.White
                If ErrorNodePathList.Contains(e.Node.FullPath) Then
                    ErrorNodePathList.Remove(e.Node.FullPath)
                End If
                '儲存上一個Grid資訊
                If dg1.GetDBDS IsNot Nothing AndAlso dg1.GetDBDS.Tables(0).Rows.Count > 0 Then

                    GridDS.Tables(0).Rows.Clear()

                    dg1.SetDS(GridDS.Copy)

                End If

                If e.Node.Level = 0 Then

                    If GridHash0.ContainsKey(e.Node.FullPath) Then
                        GridHash0.Remove(e.Node.FullPath)
                    End If

                    If SelectedNode0.Contains(e.Node.FullPath) Then
                        SelectedNode0.Remove(e.Node.FullPath)
                    End If

                ElseIf e.Node.Level = 1 Then

                    If GridHash1.ContainsKey(e.Node.FullPath) Then
                        GridHash1.Remove(e.Node.FullPath)
                    End If

                    If SelectedNode1.Contains(e.Node.FullPath) Then
                        SelectedNode1.Remove(e.Node.FullPath)
                    End If

                ElseIf e.Node.Level = 2 Then

                    If GridHash2.ContainsKey(e.Node.FullPath) Then
                        GridHash2.Remove(e.Node.FullPath)
                    End If

                    If SelectedNode2.Contains(e.Node.FullPath) Then
                        SelectedNode2.Remove(e.Node.FullPath)
                    End If

                ElseIf e.Node.Level = 3 Then

                    If GridHash3.ContainsKey(e.Node.FullPath) Then
                        GridHash3.Remove(e.Node.FullPath)
                    End If

                    If SelectedNode3.Contains(e.Node.FullPath) Then
                        SelectedNode3.Remove(e.Node.FullPath)
                    End If

                End If

                LastNodeLevel = e.Node.Level

            End If



        Catch ex As Exception

        Finally
            ScreenUtil.UnLock(Me)
        End Try

    End Sub


    Private Sub PUBIcdRuleCheckUI_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode

            Case Keys.F12
                btn_Ok_Click(sender, e)

            Case Keys.F5
                btn_Cancel_Click(sender, e)

            Case Keys.F1
                btn_Force_Click(sender, e)

        End Select


    End Sub


    '(三)	醫令檢核—單一醫令開立時進行檢核

    Public Function CheckSingleOrder(ByVal RuleCode As String) As Boolean


        If Not DoOrderCheck Then
            Return True
        End If

        'TODO PUBRuleBP
        'Dim Check As New PUB.PUBRuleBP 
        'Dim CheckResult As Boolean
        'Dim ErrorDS As DataSet
        ''C:Client
        ''O : O/E/I

        ''TriggerItemDS.WriteXml("SingleOrderCheck(TriggerItemDS).XML")
        ''OperationDS.WriteXml("SingleOrderCheck(OperationDS).XML")

        ''Dim log As ILog = LOGDelegate.GetInstance.getFileLogger("")

        ''log.Debug("單一醫囑檢核前時間:" & Now.ToString)
        'TriggerItemDS.Tables(0).Rows(0).Item("RuleCode") = RuleCode
        'TriggerItemDS.Tables(0).Rows(0).Item("IsCodeExchanged") = "N"


        'CheckResult = Check.RuleTransfer("C", "O", TriggerItemDS, OperationDS)

        ''log.Debug("單一醫囑檢核後時間:" & Now.ToString)


        'If CheckResult Then


        '    Dim MasterMessageDT As DataTable = Check.messageDataSet.Tables("MasterMessage")
        '    Dim RuleInfoDT As DataTable = Check.messageDataSet.Tables("RuleInfo")
        '    Dim FalseMessageDT As DataTable = Check.messageDataSet.Tables("FalseMessage")
        '    Dim FalseConditionDT As DataTable = Check.messageDataSet.Tables("FalseCondition")


        '    'Check.messageDataSet.Tables("MasterMessage").WriteXml("MasterMessage.XML")
        '    'Check.messageDataSet.Tables("RuleInfo").WriteXml("RuleInfo.XML")
        '    'Check.messageDataSet.Tables("FalseMessage").WriteXml("FalseMessage.XML")
        '    'Check.messageDataSet.Tables("FalseCondition").WriteXml("FalseCondition.XML")


        '    If FalseMessageDT.Rows.Count = 0 Then
        '        Console.WriteLine("單一醫令檢核成功")
        '        Return True

        '    End If


        '    Return False

        '    ErrorDS = New DataSet


        '    ErrorDS.Tables.Add()

        '    ErrorDS.Tables(0).TableName = "ShowTable"

        '    ErrorDS.Tables(0).Columns.Add("OrderCode")
        '    ErrorDS.Tables(0).Columns.Add("ValueData")
        '    ErrorDS.Tables(0).Columns.Add("RuleCode")
        '    ErrorDS.Tables(0).Columns.Add("ExpressionStr1")
        '    ErrorDS.Tables(0).Columns.Add("LimitAlertlevel")
        '    ErrorDS.Tables(0).Columns.Add("Message")
        '    ErrorDS.Tables(0).Columns.Add("ItemCode")
        '    ErrorDS.Tables(0).Columns.Add("ExpressionStr2")
        '    ErrorDS.Tables(0).Columns.Add("OrderName")
        '    ErrorDS.Tables(0).Columns.Add("OPHRuleReason")

        '    For i As Integer = 0 To TriggerItemDS.Tables.Count - 1
        '        ErrorDS.Tables.Add(TriggerItemDS.Tables(i).Copy)
        '    Next

        '    For j As Integer = 0 To OperationDS.Tables.Count - 1
        '        ErrorDS.Tables.Add(OperationDS.Tables(j).Copy)
        '    Next

        '    For k As Integer = 0 To Check.messageDataSet.Tables.Count - 1
        '        ErrorDS.Tables.Add(Check.messageDataSet.Tables(k).Copy)
        '    Next




        '    Dim MyQuery = _
        '     From RuleInfo In RuleInfoDT.AsEnumerable() _
        '     From FalseMessage In FalseMessageDT.AsEnumerable() _
        '     Where RuleInfo.Field(Of String)("CheckResult") = "0" And RuleInfo.Field(Of String)("RuleCode") = FalseMessage.Field(Of String)("RuleCode") And _
        '           FalseMessage.Field(Of String)("ParentRuleCode") = "" _
        '     Order By RuleInfo("RuleCode") _
        '     Select New With _
        '     { _
        '         .OrderCode = FalseMessage.Field(Of String)("OrderCode"), _
        '         .ValueData = RuleInfo.Field(Of String)("ValueData"), _
        '         .RuleCode = RuleInfo.Field(Of String)("RuleCode"), _
        '         .ExpressionStr1 = RuleInfo.Field(Of String)("ExpressionStr"), _
        '         .LimitAlertlevel = FalseMessage.Field(Of String)("LimitAlertlevel"), _
        '         .Message = FalseMessage.Field(Of String)("Message"), _
        '         .ItemCode = RuleInfo.Field(Of String)("ItemCode"), _
        '         .ExpressionStr2 = RuleInfo.Field(Of String)("ExpressionStr"), _
        '         .OrderName = FalseMessage.Field(Of String)("OrderName"), _
        '         .OPHRuleReason = FalseMessage.Field(Of String)("OPHRuleReason") _
        '    }

        '    For Each MyQueryRow In MyQuery
        '        Dim MyRow = ErrorDS.Tables(0).NewRow()
        '        MyRow(0) = MyQueryRow.OrderCode
        '        MyRow(1) = MyQueryRow.ValueData
        '        MyRow(2) = MyQueryRow.RuleCode
        '        MyRow(3) = MyQueryRow.ExpressionStr1
        '        MyRow(4) = MyQueryRow.LimitAlertlevel
        '        MyRow(5) = MyQueryRow.Message
        '        MyRow(6) = MyQueryRow.ItemCode
        '        MyRow(7) = MyQueryRow.ExpressionStr2
        '        MyRow(8) = MyQueryRow.OrderName
        '        MyRow(9) = MyQueryRow.OPHRuleReason
        '        ErrorDS.Tables(0).Rows.Add(MyRow)
        '    Next

        '    'Dim MyQuery = _
        '    '    From MasterMessage In MasterMessageDT.AsEnumerable() _
        '    '    From RuleInfo In RuleInfoDT.AsEnumerable() _
        '    '    From FalseMessage In FalseMessageDT.AsEnumerable() _
        '    '    From FalseCondition In FalseConditionDT.AsEnumerable() _
        '    '    Where MasterMessage.Field(Of String)("CheckResult") = "0" And MasterMessage.Field(Of String)("ValueData") = RuleInfo.Field(Of String)("ValueData") And _
        '    '          MasterMessage.Field(Of String)("ItemCode") = RuleInfo.Field(Of String)("ItemCode") And _
        '    '          RuleInfo.Field(Of String)("CheckResult") = "0" And RuleInfo.Field(Of String)("RuleCode") = FalseMessage.Field(Of String)("RuleCode") And _
        '    '          FalseMessage.Field(Of String)("ParentRuleCode") = "" And RuleInfo.Field(Of String)("RuleCode") = FalseCondition.Field(Of String)("RuleCode") _
        '    '    Order By RuleInfo("RuleCode") _
        '    '    Select New With _
        '    '    { _
        '    '        .ValueData = MasterMessage.Field(Of String)("ValueData"), _
        '    '        .RuleCode = RuleInfo.Field(Of String)("RuleCode"), _
        '    '        .ExpressionStr1 = RuleInfo.Field(Of String)("ExpressionStr"), _
        '    '        .LimitAlertlevel = FalseMessage.Field(Of String)("LimitAlertlevel"), _
        '    '        .Message = FalseMessage.Field(Of String)("Message"), _
        '    '        .ItemCode = FalseCondition.Field(Of String)("ItemCode"), _
        '    '        .ExpressionStr2 = FalseCondition.Field(Of String)("ExpressionStr"), _
        '    '        .SeqNo = FalseCondition.Field(Of String)("SeqNo") _
        '    '    }


        '    'For Each MyQueryRow In MyQuery
        '    '    Dim MyRow = ErrorDS.Tables(0).NewRow()
        '    '    MyRow(0) = MyQueryRow.ValueData
        '    '    MyRow(1) = MyQueryRow.RuleCode
        '    '    MyRow(2) = MyQueryRow.ExpressionStr1
        '    '    MyRow(3) = MyQueryRow.LimitAlertlevel
        '    '    MyRow(4) = MyQueryRow.Message
        '    '    MyRow(5) = MyQueryRow.ItemCode
        '    '    MyRow(6) = MyQueryRow.ExpressionStr2
        '    '    MyRow(7) = MyQueryRow.SeqNo
        '    '    ErrorDS.Tables(0).Rows.Add(MyRow)
        '    'Next

        '    ' Order By .Field(Of DateTime)("OrderDate").Month = 8 _
        '    'ErrorDS.WriteXml("ErrorMessage.XML")
        'Else
        '    Check.messageDataSet.Tables("InitialMessage").WriteXml("C:\Log\InitialMessage.XML")
        '    Console.WriteLine("醫令檢核API內部錯誤")
        '    MessageHandling.showInfoMsg("CMMCMMB300", New String() {"醫令檢核API內部錯誤"})

        'End If
        ''log.Debug("單一醫囑檢核後重組SQL時間點:" & Now.ToString)

        ''Return ErrorDS

    End Function



    Private Sub btn_Ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Ok.Click
        Try

            If ErrorNodePathList.Count > 0 Then
                MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {"所選擇的項目檢核未通過，不可確認！"}, "")
                Exit Sub
            End If

            '檢核dgv的輸入
            If Not CheckDgvData() Then
                Exit Sub
            End If


            '儲存最後一個dgv
            '儲存上一個Grid資訊
            If dg1.GetDBDS IsNot Nothing AndAlso dg1.GetDBDS.Tables(0).Rows.Count > 0 Then
                'e.Node.FullPath

                If CurrentCheckedNodeLevel = 0 Then

                    If GridHash0.ContainsKey(dg1.GetDBDS.Tables(0).Rows(0).Item("ParentNodePath").ToString.Trim) Then
                        GridHash0.Remove(dg1.GetDBDS.Tables(0).Rows(0).Item("ParentNodePath").ToString.Trim)
                    End If

                    GridHash0.Add(dg1.GetDBDS.Tables(0).Rows(0).Item("ParentNodePath").ToString.Trim, dg1.GetDBDS.Copy)

                ElseIf CurrentCheckedNodeLevel = 1 Then

                    If GridHash1.ContainsKey(dg1.GetDBDS.Tables(0).Rows(0).Item("ParentNodePath").ToString.Trim) Then
                        GridHash1.Remove(dg1.GetDBDS.Tables(0).Rows(0).Item("ParentNodePath").ToString.Trim)
                    End If

                    GridHash1.Add(dg1.GetDBDS.Tables(0).Rows(0).Item("ParentNodePath").ToString.Trim, dg1.GetDBDS.Copy)

                ElseIf CurrentCheckedNodeLevel = 2 Then

                    If GridHash2.ContainsKey(dg1.GetDBDS.Tables(0).Rows(0).Item("ParentNodePath").ToString.Trim) Then
                        GridHash2.Remove(dg1.GetDBDS.Tables(0).Rows(0).Item("ParentNodePath").ToString.Trim)
                    End If

                    GridHash2.Add(dg1.GetDBDS.Tables(0).Rows(0).Item("ParentNodePath").ToString.Trim, dg1.GetDBDS.Copy)

                ElseIf CurrentCheckedNodeLevel = 3 Then

                    If GridHash3.ContainsKey(dg1.GetDBDS.Tables(0).Rows(0).Item("ParentNodePath").ToString.Trim) Then
                        GridHash3.Remove(dg1.GetDBDS.Tables(0).Rows(0).Item("ParentNodePath").ToString.Trim)
                    End If

                    GridHash3.Add(dg1.GetDBDS.Tables(0).Rows(0).Item("ParentNodePath").ToString.Trim, dg1.GetDBDS.Copy)

                End If

            End If



            ReturnDS = New DataSet

            ReturnDS.Tables.Add("ICD_Data")

            ReturnDS.Tables(0).Columns.Add("ICD_Code")
            ReturnDS.Tables(0).Columns.Add("Rule_Name")
            ReturnDS.Tables(0).Columns.Add("Is_Prior_Review")
            ReturnDS.Tables(0).Columns.Add("Check_Type")

            ReturnDS.Tables.Add("Info")
            ReturnDS.Tables(1).Columns.Add("Is_Prior_Review")
            ReturnDS.Tables(1).Columns.Add("CheckResult")
            ReturnDS.Tables(1).Columns.Add("IcdCheckRootSelected")
            ReturnDS.Tables(1).Columns.Add("IsRootContainPriorReview")
            ReturnDS.Tables(1).Columns.Add("IsCheckPUBOrderPriorReview")
            ReturnDS.Tables(1).Columns.Add("XML")


            ReturnDS.Tables(1).Rows.Add()
            ReturnDS.Tables(1).Rows(0).Item("Is_Prior_Review") = "N"
            ReturnDS.Tables(1).Rows(0).Item("CheckResult") = "0"
            ReturnDS.Tables(1).Rows(0).Item("IcdCheckRootSelected") = ""
            ReturnDS.Tables(1).Rows(0).Item("IsRootContainPriorReview") = IsRootContainPriorReview

            If IsCheckPUBOrderPriorReview Then
                ReturnDS.Tables(1).Rows(0).Item("IsCheckPUBOrderPriorReview") = "Y"

            Else
                ReturnDS.Tables(1).Rows(0).Item("IsCheckPUBOrderPriorReview") = "N"

            End If


            '處理XML
            ReturnDS.Tables(1).Rows(0).Item("XML") = ProcessXML()


            Dim LogicalSymbolList As New ArrayList


            Dim Str As String = ""

            For i As Integer = 0 To tr1_View.Nodes.Count - 1

                If tr1_View.Nodes(i).Checked AndAlso tr1_View.Nodes(i).Level = 0 Then 'root
                    Str = tr1_View.Nodes(i).Tag
                    Console.WriteLine(tr1_View.Nodes(i).Text.Trim)


                    ReturnDS.Tables(0).Rows.Add()

                    ReturnDS.Tables(0).Rows(ReturnDS.Tables(0).Rows.Count - 1).Item("ICD_Code") = ""
                    ReturnDS.Tables(0).Rows(ReturnDS.Tables(0).Rows.Count - 1).Item("Rule_Name") = tr1_View.Nodes(i).Text.Trim

                    If Split(tr1_View.Nodes(i).Tag, "#")(4).Trim = "Y" Then
                        ReturnDS.Tables(1).Rows(0).Item("Is_Prior_Review") = "Y"
                    End If

                    ReturnDS.Tables(0).Rows(ReturnDS.Tables(0).Rows.Count - 1).Item("Is_Prior_Review") = Split(tr1_View.Nodes(i).Tag, "#")(4).Trim
                    ReturnDS.Tables(0).Rows(ReturnDS.Tables(0).Rows.Count - 1).Item("Check_Type") = Split(tr1_View.Nodes(i).Tag, "#")(5).Trim

                    ReturnDS.Tables(1).Rows(0).Item("IcdCheckRootSelected") += i.ToString & ","


                    ReturnDS.Tables(1).Rows(0).Item("CheckResult") = "1"


                End If

            Next

            If txt_Other.Text.Trim <> "" Then
                ReturnDS.Tables(1).Rows(0).Item("IcdCheckRootSelected") += "@@@" & txt_Other.Text.Trim


                ReturnDS.Tables(0).Rows.Add()

                ReturnDS.Tables(0).Rows(ReturnDS.Tables(0).Rows.Count - 1).Item("ICD_Code") = ""
                ReturnDS.Tables(0).Rows(ReturnDS.Tables(0).Rows.Count - 1).Item("Rule_Name") = "@@@" & txt_Other.Text.Trim


            End If




            If ReturnDS.Tables(1).Rows(0).Item("CheckResult") = "0" AndAlso txt_Other.Text.Trim <> "" Then
                ReturnDS.Tables(1).Rows(0).Item("CheckResult") = "1"
            End If

            Me.Close()
        Catch ex As Exception

        End Try
    End Sub


    Private Function ProcessXML() As String
        Try


            '        <?xml version="1.0" encoding="utf-8"?>
            '<IcdCheckResult>
            '  <OrderCode>1234</OrderCode>
            '  <RuleChecked RuleName="CVD(+)腦血管病變--腦梗塞、腦內出血">
            '    <LabData ItemName="檢查日期" ValueData="2010/2/13" ValueUnitCode="" LogicalSymbol="OR" />
            '    <LabData ItemName="TC" ValueData="12.3" ValueUnitCode="mg/dl" LogicalSymbol="OR" />
            '    <LabData ItemName="LDL-C" ValueData="23.4" ValueUnitCode="mg/dl" />
            '    <LabData ItemName="TG" ValueData="53.9" ValueUnitCode="ml" />
            '    <LabData ItemName="TC/HDL-C" ValueData="0.4" ValueUnitCode=""></LabData>
            '    <LabData ItemName="HDL-C" ValueData="40.5" ValueUnitCode="md/dl" />


            '  </RuleChecked>

            '  <RuleChecked RuleName="無心血管疾病者--(1)TC≧200或LDL-C≧130且≧二個危險因子">
            '    <LabData ItemName="非藥物治療起日" ValueData="2010/1/2" ValueUnitCode="" />
            '    <LabData ItemName="非藥物治療迄日" ValueData="2010/2/20" ValueUnitCode="" />
            '    <LabData ItemName="檢查日期" ValueData="2010/1/29" ValueUnitCode="" />
            '    <LabData ItemName="TC" ValueData="20" ValueUnitCode=""></LabData>
            '    <LabData ItemName="LDL-C" ValueData="12" ValueUnitCode="" />
            '    <LabData ItemName="檢查日期" ValueData="2010/1/2" ValueUnitCode="" />
            '    <LabData ItemName="TC" ValueData="2010/1/2" ValueUnitCode=""></LabData>
            '    <LabData ItemName="LDL-C" ValueData="2010/1/2" ValueUnitCode="" />
            '  </RuleChecked>
            '</IcdCheckResult>


            Dim XML As String = "<?xml version=""1.0"" encoding=""utf-8""?>"

            XML += "<IcdCheckResult>"
            XML += "<OrderCode>" & OrderCode & "</OrderCode>"



            If SelectedNode0.Count > 0 OrElse SelectedNode1.Count > 0 OrElse SelectedNode2.Count > 0 OrElse SelectedNode3.Count > 0 OrElse GridHash0.Count > 0 OrElse GridHash1.Count > 0 OrElse GridHash2.Count > 0 OrElse GridHash3.Count > 0 Then



                Dim doc As XmlDocument = New XmlDocument
                doc.AppendChild(doc.CreateXmlDeclaration("1.0", "UTF-8", String.Empty))
                Dim rootNode As XmlElement = CType(doc.AppendChild(doc.CreateElement("IcdCheckResult")), XmlElement)

                Dim OrderCodeElement As XmlElement = Nothing
                Dim OtherElement As XmlElement = Nothing



                OrderCodeElement = CType(rootNode.AppendChild(doc.CreateElement("OrderCode")), XmlElement)
                OrderCodeElement.InnerText = OrderCode




                ProcessLevel3(doc, rootNode)
                ProcessLevel2(doc, rootNode)
                ProcessLevel1(doc, rootNode)
                ProcessLevel0(doc, rootNode)

                If txt_Other.Text.Trim <> "" Then
                    OtherElement = CType(rootNode.AppendChild(doc.CreateElement("Other")), XmlElement)
                    OtherElement.InnerText = txt_Other.Text.Trim
                End If



                Return doc.InnerXml.Trim
            Else

                If txt_Other.Text.Trim <> "" Then

                    Dim doc As XmlDocument = New XmlDocument
                    doc.AppendChild(doc.CreateXmlDeclaration("1.0", "UTF-8", String.Empty))
                    Dim rootNode As XmlElement = CType(doc.AppendChild(doc.CreateElement("IcdCheckResult")), XmlElement)

                    Dim OrderCodeElement As XmlElement = Nothing
                    Dim OtherElement As XmlElement = Nothing



                    OrderCodeElement = CType(rootNode.AppendChild(doc.CreateElement("OrderCode")), XmlElement)
                    OrderCodeElement.InnerText = OrderCode

                    'ProcessLevel3(doc, rootNode)
                    'ProcessLevel2(doc, rootNode)
                    'ProcessLevel1(doc, rootNode)
                    'ProcessLevel0(doc, rootNode)

                    OtherElement = CType(rootNode.AppendChild(doc.CreateElement("Other")), XmlElement)
                    OtherElement.InnerText = txt_Other.Text.Trim

                    Return doc.InnerXml.Trim

                Else
                    Return ""
                End If

            End If

        Catch ex As Exception
            Return ""
        End Try



    End Function


    Private Function ReadGridXML(ByVal ItemNameList As ArrayList) As String
        '        Dim xmlString As String = "<department>" & _
        '        "<employee name=""ABC"" age=""31"" sex=""male""/>" & _
        '         "<employee name=""CDE"" age=""40"" sex=""male""/></department>"
        '        Dim sr As New System.IO.StringReader(xmlString)
        '        Dim doc As New Xml.XmlDocument
        '        doc.Load(sr)
        '        'or just in this case doc.LoadXML(xmlString)
        '        Dim reader As New Xml.XmlNodeReader(doc)
        '        While reader.Read()
        '            Select Case reader.NodeType
        '                Case Xml.XmlNodeType.Element
        '                    If reader.Name = "employee" Then
        '                        MessageBox.Show(reader.GetAttribute("name"))
        '                    End If
        '            End Select
        '        End While


        Try

            If OutpatientSn = "" Then
                Return ""
            End If

            Dim ds As New DataSet

            ds.Tables.Add()
            ds.Tables(0).Columns.Add("Action")
            ds.Tables(0).Columns.Add("Order_Code")
            ds.Tables(0).Columns.Add("OpdVisitDate")
            ds.Tables(0).Columns.Add("OutpatientSn")

            ds.Tables(0).Columns.Add("ChartNo")

            ds.Tables(0).Rows.Add()

            ds.Tables(0).Rows(0).Item("Action") = "QueryIcdGridData"
            ds.Tables(0).Rows(0).Item("Order_Code") = OrderCode
            ds.Tables(0).Rows(0).Item("OpdVisitDate") = CDate(OpdVisitDate).ToShortDateString
            ds.Tables(0).Rows(0).Item("ChartNo") = ChartNo
            ds.Tables(0).Rows(0).Item("OutpatientSn") = OutpatientSn

            ds.Tables.Add()
            ds.Tables(1).Columns.Add("ItemName")

            For i As Integer = 0 To ItemNameList.Count - 1

                ds.Tables(1).Rows.Add()
                ds.Tables(1).Rows(i).Item(0) = ItemNameList(i).ToString.Trim
            Next

            Dim ResultDS As DataSet

            ResultDS = pubService.DoPubAction(ds)

            If ResultDS IsNot Nothing AndAlso ResultDS.Tables.Count > 0 AndAlso ResultDS.Tables(0).Rows.Count > 0 Then
                Dim ValueDataHt As New Hashtable
                Dim ValueUnitCodeHt As New Hashtable

                Dim xmlString As String = ResultDS.Tables(0).Rows(0).Item(0).ToString.Trim

                Dim sr As New System.IO.StringReader(xmlString)
                Dim doc As New Xml.XmlDocument
                doc.Load(sr)
                'or just in this case doc.LoadXML(xmlString)

                For i As Integer = 0 To ItemNameList.Count - 1
                    Dim reader As New Xml.XmlNodeReader(doc)

                    While reader.Read()
                        Select Case reader.NodeType
                            Case Xml.XmlNodeType.Element
                                If reader.Name = "LabData" Then
                                    'MessageBox.Show(reader.GetAttribute("name"))

                                    If reader.GetAttribute("ItemName").Trim = ItemNameList(i).ToString.Trim Then

                                        If Not ValueDataHt.ContainsKey(ItemNameList(i).ToString.Trim) Then

                                            ValueDataHt.Add(ItemNameList(i).ToString.Trim, reader.GetAttribute("ValueData"))
                                        End If

                                        If Not ValueUnitCodeHt.ContainsKey(ItemNameList(i).ToString.Trim) Then
                                            ValueUnitCodeHt.Add(ItemNameList(i).ToString.Trim, reader.GetAttribute("ValueUnitCode"))

                                        End If

                                        Exit While
                                    End If

                                End If
                        End Select
                    End While

                Next


                If dg1.GetDBDS IsNot Nothing AndAlso dg1.GetDBDS.Tables(0).Rows.Count > 0 Then

                    For i As Integer = 0 To dg1.GetDBDS.Tables(0).Rows.Count - 1

                        dg1.GetDBDS.Tables(0).Rows(i).Item("ValueData") = "."
                        dg1.GetGridDS.Tables(0).Rows(i).Item("ValueData") = "."


                        If ValueDataHt.ContainsKey(dg1.GetDBDS.Tables(0).Rows(i).Item("Rule_Name").ToString.Trim) Then

                            dg1.GetDBDS.Tables(0).Rows(i).Item("ValueData") = ValueDataHt(dg1.GetDBDS.Tables(0).Rows(i).Item("Rule_Name").ToString.Trim)
                            dg1.GetGridDS.Tables(0).Rows(i).Item("ValueData") = ValueDataHt(dg1.GetGridDS.Tables(0).Rows(i).Item("Rule_Name").ToString.Trim)

                        End If



                        If ValueUnitCodeHt.ContainsKey(dg1.GetDBDS.Tables(0).Rows(i).Item("Rule_Name").ToString.Trim) Then

                            dg1.GetDBDS.Tables(0).Rows(i).Item("ValueUnitCode") = ValueUnitCodeHt(dg1.GetDBDS.Tables(0).Rows(i).Item("Rule_Name").ToString.Trim)
                            dg1.GetGridDS.Tables(0).Rows(i).Item("ValueUnitCode") = ValueUnitCodeHt(dg1.GetGridDS.Tables(0).Rows(i).Item("Rule_Name").ToString.Trim)

                        End If

                    Next

                End If



            End If



        Catch ex As Exception

        End Try

        '2015-05-26 若前面都沒回傳值，則回傳空字串(解決警告)
        Return String.Empty

    End Function

    Private Sub ProcessLevel3(ByRef doc As XmlDocument, ByRef rootNode As XmlElement)

        Try


            Dim rootNode0, rootNode1, rootNode2, rootNode3 As XmlElement
            Dim LabData As XmlElement


            For i As Integer = 0 To GridHash3.Count - 1

                If CType(GridHash3.Values(i), DataSet).Tables(0).Rows.Count > 0 Then

                    Dim TempDS As DataSet = CType(GridHash3.Values(i), DataSet).Copy

                    rootNode0 = rootNode.AppendChild(doc.CreateElement("RuleChecked"))
                    rootNode0.Attributes.Append(doc.CreateAttribute("RuleName"))
                    rootNode0.Attributes("RuleName").Value = Split(TempDS.Tables(0).Rows(0).Item("ParentNodePath"), "|")(0).Trim

                    rootNode1 = rootNode0.AppendChild(doc.CreateElement("RuleChecked"))
                    rootNode1.Attributes.Append(doc.CreateAttribute("RuleName"))
                    rootNode1.Attributes("RuleName").Value = Split(TempDS.Tables(0).Rows(0).Item("ParentNodePath"), "|")(1).Trim

                    rootNode2 = rootNode1.AppendChild(doc.CreateElement("RuleChecked"))
                    rootNode2.Attributes.Append(doc.CreateAttribute("RuleName"))
                    rootNode2.Attributes("RuleName").Value = Split(TempDS.Tables(0).Rows(0).Item("ParentNodePath"), "|")(2).Trim

                    rootNode3 = rootNode2.AppendChild(doc.CreateElement("RuleChecked"))
                    rootNode3.Attributes.Append(doc.CreateAttribute("RuleName"))
                    rootNode3.Attributes("RuleName").Value = Split(TempDS.Tables(0).Rows(0).Item("ParentNodePath"), "|")(3).Trim

                    If SelectedNode3.Contains(TempDS.Tables(0).Rows(0).Item("ParentNodePath")) Then
                        SelectedNode3.Remove(TempDS.Tables(0).Rows(0).Item("ParentNodePath"))
                    End If

                    For j As Integer = 0 To TempDS.Tables(0).Rows.Count - 1
                        LabData = rootNode3.AppendChild(doc.CreateElement("LabData"))

                        LabData.Attributes.Append(doc.CreateAttribute("ItemName"))
                        LabData.Attributes.Append(doc.CreateAttribute("ValueData"))
                        LabData.Attributes.Append(doc.CreateAttribute("ValueUnitCode"))
                        LabData.Attributes.Append(doc.CreateAttribute("LogicalSymbol"))

                        LabData.Attributes("ItemName").Value = TempDS.Tables(0).Rows(j).Item("Rule_name").ToString.Trim
                        LabData.Attributes("ValueData").Value = TempDS.Tables(0).Rows(j).Item("ValueData").ToString.Trim
                        LabData.Attributes("ValueUnitCode").Value = TempDS.Tables(0).Rows(j).Item("ValueUnitCode").ToString.Trim
                        LabData.Attributes("LogicalSymbol").Value = TempDS.Tables(0).Rows(j).Item("Logical_Symbol").ToString.Trim

                    Next



                End If

            Next


            If SelectedNode3.Count > 0 Then

                For i As Integer = 0 To SelectedNode3.Count - 1

                    rootNode0 = rootNode.AppendChild(doc.CreateElement("RuleChecked"))
                    rootNode0.Attributes.Append(doc.CreateAttribute("RuleName"))
                    rootNode0.Attributes("RuleName").Value = Split(SelectedNode3(i), "|")(0).Trim

                    rootNode1 = rootNode0.AppendChild(doc.CreateElement("RuleChecked"))
                    rootNode1.Attributes.Append(doc.CreateAttribute("RuleName"))
                    rootNode1.Attributes("RuleName").Value = Split(SelectedNode3(i), "|")(1).Trim

                    rootNode2 = rootNode1.AppendChild(doc.CreateElement("RuleChecked"))
                    rootNode2.Attributes.Append(doc.CreateAttribute("RuleName"))
                    rootNode2.Attributes("RuleName").Value = Split(SelectedNode3(i), "|")(2).Trim

                    rootNode3 = rootNode2.AppendChild(doc.CreateElement("RuleChecked"))
                    rootNode3.Attributes.Append(doc.CreateAttribute("RuleName"))
                    rootNode3.Attributes("RuleName").Value = Split(SelectedNode3(i), "|")(3).Trim

                Next

            End If

        Catch ex As Exception
            Console.WriteLine(ex.ToString)
        End Try


    End Sub

    Private Sub ProcessLevel2(ByRef doc As XmlDocument, ByRef rootNode As XmlElement)

        Try

            Dim rootNode0, rootNode1, rootNode2 As XmlElement
            Dim LabData As XmlElement

            For i As Integer = 0 To GridHash2.Count - 1

                If CType(GridHash2.Values(i), DataSet).Tables(0).Rows.Count > 0 Then
                    Dim Found As Boolean = False
                    Dim TempDS As DataSet = CType(GridHash2.Values(i), DataSet).Copy

                    If SelectedNode2.Contains(TempDS.Tables(0).Rows(0).Item("ParentNodePath")) Then
                        SelectedNode2.Remove(TempDS.Tables(0).Rows(0).Item("ParentNodePath"))
                    End If

                    '先判斷有沒有存在的Node
                    For x As Integer = 1 To rootNode.ChildNodes.Count - 1 ' 找rootNode0

                        For y As Integer = 0 To rootNode.ChildNodes(x).ChildNodes.Count - 1 '找rootNode1

                            For z As Integer = 0 To rootNode.ChildNodes(x).ChildNodes(y).ChildNodes.Count - 1 '找rootNode2

                                Try
                                    If rootNode.ChildNodes(x).ChildNodes(y).ChildNodes(z).Attributes("RuleName").Value = Split(TempDS.Tables(0).Rows(0).Item("ParentNodePath"), "|")(2).Trim Then
                                        Found = True
                                        '找到了~要更新
                                        For j As Integer = 0 To TempDS.Tables(0).Rows.Count - 1
                                            LabData = rootNode.ChildNodes(x).ChildNodes(y).ChildNodes(z).AppendChild(doc.CreateElement("LabData"))

                                            LabData.Attributes.Append(doc.CreateAttribute("ItemName"))
                                            LabData.Attributes.Append(doc.CreateAttribute("ValueData"))
                                            LabData.Attributes.Append(doc.CreateAttribute("ValueUnitCode"))
                                            LabData.Attributes.Append(doc.CreateAttribute("LogicalSymbol"))

                                            LabData.Attributes("ItemName").Value = TempDS.Tables(0).Rows(j).Item("Rule_name").ToString.Trim
                                            LabData.Attributes("ValueData").Value = TempDS.Tables(0).Rows(j).Item("ValueData").ToString.Trim
                                            LabData.Attributes("ValueUnitCode").Value = TempDS.Tables(0).Rows(j).Item("ValueUnitCode").ToString.Trim
                                            LabData.Attributes("LogicalSymbol").Value = TempDS.Tables(0).Rows(j).Item("Logical_Symbol").ToString.Trim

                                        Next

                                        Exit For
                                    End If
                                Catch ex As Exception

                                End Try
                            Next

                            If Found Then
                                Exit For
                            End If

                        Next

                        If Found Then
                            Exit For
                        End If
                    Next


                    If Not Found Then
                        '沒找到

                        rootNode0 = rootNode.AppendChild(doc.CreateElement("RuleChecked"))
                        rootNode0.Attributes.Append(doc.CreateAttribute("RuleName"))
                        rootNode0.Attributes("RuleName").Value = Split(TempDS.Tables(0).Rows(0).Item("ParentNodePath"), "|")(0).Trim

                        rootNode1 = rootNode0.AppendChild(doc.CreateElement("RuleChecked"))
                        rootNode1.Attributes.Append(doc.CreateAttribute("RuleName"))
                        rootNode1.Attributes("RuleName").Value = Split(TempDS.Tables(0).Rows(0).Item("ParentNodePath"), "|")(1).Trim

                        rootNode2 = rootNode1.AppendChild(doc.CreateElement("RuleChecked"))
                        rootNode2.Attributes.Append(doc.CreateAttribute("RuleName"))
                        rootNode2.Attributes("RuleName").Value = Split(TempDS.Tables(0).Rows(0).Item("ParentNodePath"), "|")(2).Trim

                        For j As Integer = 0 To TempDS.Tables(0).Rows.Count - 1
                            LabData = rootNode2.AppendChild(doc.CreateElement("LabData"))

                            LabData.Attributes.Append(doc.CreateAttribute("ItemName"))
                            LabData.Attributes.Append(doc.CreateAttribute("ValueData"))
                            LabData.Attributes.Append(doc.CreateAttribute("ValueUnitCode"))
                            LabData.Attributes.Append(doc.CreateAttribute("LogicalSymbol"))

                            LabData.Attributes("ItemName").Value = TempDS.Tables(0).Rows(j).Item("Rule_name").ToString.Trim
                            LabData.Attributes("ValueData").Value = TempDS.Tables(0).Rows(j).Item("ValueData").ToString.Trim
                            LabData.Attributes("ValueUnitCode").Value = TempDS.Tables(0).Rows(j).Item("ValueUnitCode").ToString.Trim
                            LabData.Attributes("LogicalSymbol").Value = TempDS.Tables(0).Rows(j).Item("Logical_Symbol").ToString.Trim

                        Next

                    End If

                End If


            Next

            If SelectedNode2.Count > 0 Then

                For i As Integer = 0 To SelectedNode2.Count - 1


                    Dim Found As Boolean = False

                    For x As Integer = 0 To rootNode.ChildNodes.Count - 1
                        For y As Integer = 0 To rootNode.ChildNodes(x).ChildNodes.Count - 1
                            For z As Integer = 0 To rootNode.ChildNodes(x).ChildNodes(y).ChildNodes.Count - 1

                                Try
                                    If rootNode.ChildNodes(x).Attributes("RuleName").Value.Trim = Split(SelectedNode2(i), "|")(0).Trim AndAlso rootNode.ChildNodes(x).ChildNodes(y).Attributes("RuleName").Value.Trim = Split(SelectedNode2(i), "|")(1).Trim AndAlso rootNode.ChildNodes(x).ChildNodes(y).ChildNodes(z).Attributes("RuleName").Value.Trim = Split(SelectedNode2(i), "|")(2).Trim Then
                                        Found = True
                                        Exit For
                                    End If
                                Catch ex As Exception

                                End Try

                            Next

                            If Found Then
                                Exit For
                            End If
                        Next

                        If Found Then
                            Exit For
                        End If
                    Next


                    If Not Found Then

                        rootNode0 = rootNode.AppendChild(doc.CreateElement("RuleChecked"))
                        rootNode0.Attributes.Append(doc.CreateAttribute("RuleName"))
                        rootNode0.Attributes("RuleName").Value = Split(SelectedNode2(i), "|")(0).Trim

                        rootNode1 = rootNode0.AppendChild(doc.CreateElement("RuleChecked"))
                        rootNode1.Attributes.Append(doc.CreateAttribute("RuleName"))
                        rootNode1.Attributes("RuleName").Value = Split(SelectedNode2(i), "|")(1).Trim

                        rootNode2 = rootNode1.AppendChild(doc.CreateElement("RuleChecked"))
                        rootNode2.Attributes.Append(doc.CreateAttribute("RuleName"))
                        rootNode2.Attributes("RuleName").Value = Split(SelectedNode2(i), "|")(2).Trim


                    End If



                Next

            End If

        Catch ex As Exception
            Console.WriteLine(ex.ToString)
        End Try
    End Sub


    Private Sub ProcessLevel1(ByRef doc As XmlDocument, ByRef rootNode As XmlElement)

        Try


            Dim rootNode0, rootNode1 As XmlElement
            Dim LabData As XmlElement

            For i As Integer = 0 To GridHash1.Count - 1

                If CType(GridHash1.Values(i), DataSet).Tables(0).Rows.Count > 0 Then
                    Dim Found As Boolean = False
                    Dim TempDS As DataSet = CType(GridHash1.Values(i), DataSet).Copy

                    If SelectedNode1.Contains(TempDS.Tables(0).Rows(0).Item("ParentNodePath")) Then
                        SelectedNode1.Remove(TempDS.Tables(0).Rows(0).Item("ParentNodePath"))
                    End If

                    '先判斷有沒有存在的Node
                    For x As Integer = 1 To rootNode.ChildNodes.Count - 1 ' 找rootNode0

                        For y As Integer = 0 To rootNode.ChildNodes(x).ChildNodes.Count - 1 '找rootNode1
                            Try

                                If rootNode.ChildNodes(x).ChildNodes(y).Attributes("RuleName").Value = Split(TempDS.Tables(0).Rows(0).Item("ParentNodePath"), "|")(1).Trim Then

                                    Found = True
                                    '找到了~要更新
                                    For j As Integer = 0 To TempDS.Tables(0).Rows.Count - 1
                                        LabData = rootNode.ChildNodes(x).ChildNodes(y).AppendChild(doc.CreateElement("LabData"))

                                        LabData.Attributes.Append(doc.CreateAttribute("ItemName"))
                                        LabData.Attributes.Append(doc.CreateAttribute("ValueData"))
                                        LabData.Attributes.Append(doc.CreateAttribute("ValueUnitCode"))
                                        LabData.Attributes.Append(doc.CreateAttribute("LogicalSymbol"))

                                        LabData.Attributes("ItemName").Value = TempDS.Tables(0).Rows(j).Item("Rule_name").ToString.Trim
                                        LabData.Attributes("ValueData").Value = TempDS.Tables(0).Rows(j).Item("ValueData").ToString.Trim
                                        LabData.Attributes("ValueUnitCode").Value = TempDS.Tables(0).Rows(j).Item("ValueUnitCode").ToString.Trim
                                        LabData.Attributes("LogicalSymbol").Value = TempDS.Tables(0).Rows(j).Item("Logical_Symbol").ToString.Trim

                                    Next

                                    Exit For

                                End If
                            Catch ex As Exception

                            End Try

                        Next

                        If Found Then
                            Exit For
                        End If

                    Next


                    If Not Found Then
                        '沒找到

                        rootNode0 = rootNode.AppendChild(doc.CreateElement("RuleChecked"))
                        rootNode0.Attributes.Append(doc.CreateAttribute("RuleName"))
                        rootNode0.Attributes("RuleName").Value = Split(TempDS.Tables(0).Rows(0).Item("ParentNodePath"), "|")(0).Trim

                        rootNode1 = rootNode0.AppendChild(doc.CreateElement("RuleChecked"))
                        rootNode1.Attributes.Append(doc.CreateAttribute("RuleName"))
                        rootNode1.Attributes("RuleName").Value = Split(TempDS.Tables(0).Rows(0).Item("ParentNodePath"), "|")(1).Trim


                        For j As Integer = 0 To TempDS.Tables(0).Rows.Count - 1
                            LabData = rootNode1.AppendChild(doc.CreateElement("LabData"))

                            LabData.Attributes.Append(doc.CreateAttribute("ItemName"))
                            LabData.Attributes.Append(doc.CreateAttribute("ValueData"))
                            LabData.Attributes.Append(doc.CreateAttribute("ValueUnitCode"))
                            LabData.Attributes.Append(doc.CreateAttribute("LogicalSymbol"))

                            LabData.Attributes("ItemName").Value = TempDS.Tables(0).Rows(j).Item("Rule_name").ToString.Trim
                            LabData.Attributes("ValueData").Value = TempDS.Tables(0).Rows(j).Item("ValueData").ToString.Trim
                            LabData.Attributes("ValueUnitCode").Value = TempDS.Tables(0).Rows(j).Item("ValueUnitCode").ToString.Trim
                            LabData.Attributes("LogicalSymbol").Value = TempDS.Tables(0).Rows(j).Item("Logical_Symbol").ToString.Trim

                        Next

                    End If

                End If


            Next

            If SelectedNode1.Count > 0 Then

                For i As Integer = 0 To SelectedNode1.Count - 1

                    Dim Found As Boolean = False

                    For x As Integer = 0 To rootNode.ChildNodes.Count - 1
                        For y As Integer = 0 To rootNode.ChildNodes(x).ChildNodes.Count - 1
                            Try

                                If rootNode.ChildNodes(x).Attributes("RuleName").Value.Trim = Split(SelectedNode1(i), "|")(0).Trim AndAlso rootNode.ChildNodes(x).ChildNodes(y).Attributes("RuleName").Value.Trim = Split(SelectedNode1(i), "|")(1).Trim Then
                                    Found = True
                                    Exit For
                                End If
                            Catch ex As Exception

                            End Try

                        Next

                        If Found Then
                            Exit For
                        End If
                    Next

                    If Not Found Then

                        rootNode0 = rootNode.AppendChild(doc.CreateElement("RuleChecked"))
                        rootNode0.Attributes.Append(doc.CreateAttribute("RuleName"))
                        rootNode0.Attributes("RuleName").Value = Split(SelectedNode1(i), "|")(0).Trim

                        rootNode1 = rootNode0.AppendChild(doc.CreateElement("RuleChecked"))
                        rootNode1.Attributes.Append(doc.CreateAttribute("RuleName"))
                        rootNode1.Attributes("RuleName").Value = Split(SelectedNode1(i), "|")(1).Trim


                    End If

                Next

            End If

        Catch ex As Exception
            Console.WriteLine(ex.ToString)
        End Try

    End Sub


    Private Sub ProcessLevel0(ByRef doc As XmlDocument, ByRef rootNode As XmlElement)


        Try

            Dim rootNode0 As XmlElement
            Dim LabData As XmlElement


            For i As Integer = 0 To GridHash0.Count - 1

                If CType(GridHash0.Values(i), DataSet).Tables(0).Rows.Count > 0 Then

                    Dim Found As Boolean = False
                    Dim TempDS As DataSet = CType(GridHash0.Values(i), DataSet).Copy

                    If SelectedNode0.Contains(TempDS.Tables(0).Rows(0).Item("ParentNodePath")) Then
                        SelectedNode0.Remove(TempDS.Tables(0).Rows(0).Item("ParentNodePath"))
                    End If


                    '先判斷有沒有存在的Node
                    For x As Integer = 1 To rootNode.ChildNodes.Count - 1 ' 找rootNode0
                        Try
                            If rootNode.ChildNodes(x).Attributes("RuleName").Value = Split(TempDS.Tables(0).Rows(0).Item("ParentNodePath"), "|")(0).Trim Then

                                Found = True
                                '找到了~要更新
                                For j As Integer = 0 To TempDS.Tables(0).Rows.Count - 1
                                    LabData = rootNode.ChildNodes(x).AppendChild(doc.CreateElement("LabData"))

                                    LabData.Attributes.Append(doc.CreateAttribute("ItemName"))
                                    LabData.Attributes.Append(doc.CreateAttribute("ValueData"))
                                    LabData.Attributes.Append(doc.CreateAttribute("ValueUnitCode"))
                                    LabData.Attributes.Append(doc.CreateAttribute("LogicalSymbol"))

                                    LabData.Attributes("ItemName").Value = TempDS.Tables(0).Rows(j).Item("Rule_name").ToString.Trim
                                    LabData.Attributes("ValueData").Value = TempDS.Tables(0).Rows(j).Item("ValueData").ToString.Trim
                                    LabData.Attributes("ValueUnitCode").Value = TempDS.Tables(0).Rows(j).Item("ValueUnitCode").ToString.Trim
                                    LabData.Attributes("LogicalSymbol").Value = TempDS.Tables(0).Rows(j).Item("Logical_Symbol").ToString.Trim

                                Next

                                Exit For

                            End If
                        Catch ex As Exception

                        End Try

                    Next


                    If Not Found Then
                        '沒找到

                        rootNode0 = rootNode.AppendChild(doc.CreateElement("RuleChecked"))
                        rootNode0.Attributes.Append(doc.CreateAttribute("RuleName"))
                        rootNode0.Attributes("RuleName").Value = Split(TempDS.Tables(0).Rows(0).Item("ParentNodePath"), "|")(0).Trim

                        For j As Integer = 0 To TempDS.Tables(0).Rows.Count - 1
                            LabData = rootNode0.AppendChild(doc.CreateElement("LabData"))

                            LabData.Attributes.Append(doc.CreateAttribute("ItemName"))
                            LabData.Attributes.Append(doc.CreateAttribute("ValueData"))
                            LabData.Attributes.Append(doc.CreateAttribute("ValueUnitCode"))
                            LabData.Attributes.Append(doc.CreateAttribute("LogicalSymbol"))

                            LabData.Attributes("ItemName").Value = TempDS.Tables(0).Rows(j).Item("Rule_name").ToString.Trim
                            LabData.Attributes("ValueData").Value = TempDS.Tables(0).Rows(j).Item("ValueData").ToString.Trim
                            LabData.Attributes("ValueUnitCode").Value = TempDS.Tables(0).Rows(j).Item("ValueUnitCode").ToString.Trim
                            LabData.Attributes("LogicalSymbol").Value = TempDS.Tables(0).Rows(j).Item("Logical_Symbol").ToString.Trim

                        Next
                    End If

                End If

            Next


            If SelectedNode0.Count > 0 Then

                For i As Integer = 0 To SelectedNode0.Count - 1

                    Dim Found As Boolean = False

                    For x As Integer = 1 To rootNode.ChildNodes.Count - 1 '排除第一個ChildNode  即 Order_Code
                        Try
                            If rootNode.ChildNodes(x).Attributes("RuleName").Value.Trim = Split(SelectedNode0(i), "|")(0).Trim Then
                                Found = True
                                Exit For
                            End If
                        Catch ex As Exception

                        End Try
                    Next

                    If Not Found Then
                        rootNode0 = rootNode.AppendChild(doc.CreateElement("RuleChecked"))
                        rootNode0.Attributes.Append(doc.CreateAttribute("RuleName"))
                        rootNode0.Attributes("RuleName").Value = Split(SelectedNode0(i), "|")(0).Trim

                    End If

                Next

            End If

        Catch ex As Exception
            Console.WriteLine(ex.ToString)
        End Try

    End Sub


    Public Function getRuleCheckedElm(ByVal RuleName As String) As XmlDocument
        'Try

        '    Dim RuleCheckedNode As XmlElement
        '    RuleCheckedNode.a()
        '    Return doc
        'Catch ex As Exception
        '    Throw ex
        'End Try

        '2015-05-26 先暫時回傳一個XmlDocument(解決警告)
        Return New XmlDocument
    End Function

    Public Function getLabDataElm(ByVal ItemName As String, ByVal ValueData As String, ByVal ValueUnitCode As String, ByVal LogicalSymbol As String) As XmlElement
        'Try

        '    Dim doc As XmlDocument = New XmlDocument
        '    'doc.AppendChild(doc.CreateXmlDeclaration("1.0", "UTF-8", String.Empty))

        '    Dim LabDataNode As XmlElement = CType(doc.AppendChild(doc.CreateElement("LabData")), XmlElement)



        '    LabDataNode.Attributes.Append(doc.CreateAttribute("ItemName"))
        '    LabDataNode.Attributes("ItemName").Value = ""

        '    LabDataNode.Attributes.Append(doc.CreateAttribute("ValueData"))

        '    LabDataNode.Attributes("ValueData").Value = ""

        '    LabDataNode.Attributes.Append(doc.CreateAttribute("ValueUnitCode"))
        '    LabDataNode.Attributes("ValueUnitCode").Value = "載入個人化設定"


        '    LabDataNode.Attributes.Append(doc.CreateAttribute("LogicalSymbol"))
        '    LabDataNode.Attributes("LogicalSymbol").Value = ""


        '    Return doc
        'Catch ex As Exception
        '    Throw ex
        'End Try

        '2015-05-26 先回傳 Nothing, 以解決警告
        Return Nothing
    End Function

    Private Sub PUBIcdRuleCheckUI_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        Me.KeyPreview = True

        '適應症檢核時是否可填寫其他欄位(2013-08-21曾祥益)
        Dim ds As DataSet = PubServiceManager.getInstance.queryPubConfigWhereConfigNameEquals("PUB_RuleChkOpOther")
        If ds.Tables.Count > 0 AndAlso _
           ds.Tables(0).Rows.Count > 0 AndAlso _
           StringUtil.nvl(ds.Tables(0).Rows(0).Item("Config_Value")).Trim.Equals("Y") Then

            Me.txt_Other.Visible = True
            Me.Label2.Visible = True
            Me.label_Msg.Visible = False
            Me.btnOpenOther.Visible = False
        Else

            Me.txt_Other.Visible = False
            Me.Label2.Visible = False
            Me.label_Msg.Visible = False
            Me.btnOpenOther.Visible = True
        End If
    End Sub

    Private Sub tr_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tr1_View.AfterSelect
        Try


            If e.Node.Checked Then

                '儲存上一個Grid資訊
                If dg1.GetDBDS IsNot Nothing AndAlso dg1.GetDBDS.Tables(0).Rows.Count > 0 Then
                    'e.Node.FullPath

                    If LastNodeLevel = 0 Then

                        If GridHash0.ContainsKey(dg1.GetDBDS.Tables(0).Rows(0).Item("ParentNodePath").ToString.Trim) Then
                            GridHash0.Remove(dg1.GetDBDS.Tables(0).Rows(0).Item("ParentNodePath").ToString.Trim)
                        End If

                        GridHash0.Add(dg1.GetDBDS.Tables(0).Rows(0).Item("ParentNodePath").ToString.Trim, dg1.GetDBDS.Copy)

                    ElseIf LastNodeLevel = 1 Then

                        If GridHash1.ContainsKey(dg1.GetDBDS.Tables(0).Rows(0).Item("ParentNodePath").ToString.Trim) Then
                            GridHash1.Remove(dg1.GetDBDS.Tables(0).Rows(0).Item("ParentNodePath").ToString.Trim)
                        End If

                        GridHash1.Add(dg1.GetDBDS.Tables(0).Rows(0).Item("ParentNodePath").ToString.Trim, dg1.GetDBDS.Copy)


                    ElseIf LastNodeLevel = 2 Then

                        If GridHash2.ContainsKey(dg1.GetDBDS.Tables(0).Rows(0).Item("ParentNodePath").ToString.Trim) Then
                            GridHash2.Remove(dg1.GetDBDS.Tables(0).Rows(0).Item("ParentNodePath").ToString.Trim)
                        End If

                        GridHash2.Add(dg1.GetDBDS.Tables(0).Rows(0).Item("ParentNodePath").ToString.Trim, dg1.GetDBDS.Copy)


                    ElseIf LastNodeLevel = 3 Then

                        If GridHash3.ContainsKey(dg1.GetDBDS.Tables(0).Rows(0).Item("ParentNodePath").ToString.Trim) Then
                            GridHash3.Remove(dg1.GetDBDS.Tables(0).Rows(0).Item("ParentNodePath").ToString.Trim)
                        End If

                        GridHash3.Add(dg1.GetDBDS.Tables(0).Rows(0).Item("ParentNodePath").ToString.Trim, dg1.GetDBDS.Copy)


                    End If

                End If

                '==================取出目前的Grid 資料 可能沒有

                Dim CurrentGridDS As New DataSet

                If e.Node.Level = 0 Then

                    If GridHash0.ContainsKey(e.Node.FullPath) Then
                        CurrentGridDS = CType(GridHash0(e.Node.FullPath), DataSet).Copy
                    End If

                ElseIf e.Node.Level = 1 Then

                    If GridHash1.ContainsKey(e.Node.FullPath) Then
                        CurrentGridDS = CType(GridHash1(e.Node.FullPath), DataSet).Copy
                    End If

                ElseIf e.Node.Level = 2 Then

                    If GridHash2.ContainsKey(e.Node.FullPath) Then
                        CurrentGridDS = CType(GridHash2(e.Node.FullPath), DataSet).Copy
                    End If


                ElseIf e.Node.Level = 3 Then

                    If GridHash3.ContainsKey(e.Node.FullPath) Then
                        CurrentGridDS = CType(GridHash3(e.Node.FullPath), DataSet).Copy
                    End If

                End If

                If CurrentGridDS.Tables.Count > 0 AndAlso CurrentGridDS.Tables(0).Rows.Count > 0 Then
                    Try
                        For i As Integer = 0 To CurrentGridDS.Tables(0).Rows.Count - 1
                            If CurrentGridDS.Tables(0).Rows(i).Item("ValueData").ToString.Trim = "" Then
                                CurrentGridDS.Tables(0).Rows(i).Item("ValueData") = "."
                            End If
                        Next
                    Catch ex As Exception

                    End Try
                    dg1.SetDS(CurrentGridDS.Copy)
                End If

            End If

            'LastNodeLevel = e.Node.Level
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btn_Force_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Force.Click


        ReturnDS = New DataSet

        ReturnDS.Tables.Add("Is_Forced")

        Me.Close()



    End Sub

    Private Sub btn_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Cancel.Click
        ReturnDS = New DataSet

        ReturnDS.Tables.Add("Cancel")

        Me.Close()

    End Sub

    Private Function CheckDgvData() As Boolean

        Dim StarItemHasValue As Boolean = False
        Dim StarItemCount As Integer = 0
        Dim ErrorMsg As String = ""


        If dg1.GetGridDS IsNot Nothing AndAlso dg1.GetGridDS.Tables(0).Rows.Count > 0 Then

            For i As Integer = 0 To dg1.GetGridDS.Tables(0).Rows.Count - 1
                dg1.SetCellColor(0, i, Drawing.Color.White)
                dg1.SetCellColor(1, i, Drawing.Color.White)
            Next


            For i As Integer = 0 To dg1.GetGridDS.Tables(0).Rows.Count - 1

                If dg1.GetGridDS.Tables(0).Rows(i).Item(0).ToString.Length > 0 AndAlso dg1.GetGridDS.Tables(0).Rows(i).Item(0).ToString.Trim.Substring(0, 1) <> "*" Then
                    '一定要填輸入值
                    If dg1.GetGridDS.Tables(0).Rows(i).Item(1) Is DBNull.Value OrElse dg1.GetGridDS.Tables(0).Rows(i).Item(1).ToString.Trim = "" Then
                        dg1.SetCellColor(1, i, Drawing.Color.Pink)
                        ErrorMsg = "項目值輸入不完整，項目開頭 沒有* 則此項目一定要填輸入值 ， 有*的項目 則至少有一個 * 項目有填輸入值"
                    End If

                End If


                If dg1.GetGridDS.Tables(0).Rows(i).Item(0).ToString.Length > 0 AndAlso dg1.GetGridDS.Tables(0).Rows(i).Item(0).ToString.Trim.Substring(0, 1) = "*" Then
                    '至少有一個要填輸入值
                    StarItemCount += 1

                    If dg1.GetGridDS.Tables(0).Rows(i).Item(1) IsNot DBNull.Value AndAlso dg1.GetGridDS.Tables(0).Rows(i).Item(1).ToString.Trim <> "" Then
                        StarItemHasValue = True
                    End If

                End If




            Next

        End If

        If ErrorMsg <> "" Then
            MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {ErrorMsg}, "")
            Return False
        Else

            If StarItemCount > 0 And Not StarItemHasValue Then
                ErrorMsg = "項目值輸入不完整，項目開頭 沒有* 則此項目一定要填輸入值 ， 有*的項目 則至少有一個 * 項目有填輸入值"
                MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {ErrorMsg}, "")
                Return False
            End If

        End If

        Return True



    End Function

    Private Sub btnOpenOther_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpenOther.Click
        'TODO client.omo_pbc.OMOOpPassAllCheckPasswordUI
        'Dim OMOOpPassAllCheckPasswordUI As New nckuh.client.omo_pbc.OMOOpPassAllCheckPasswordUI

        'If OMOOpPassAllCheckPasswordUI.ShowDialog.Equals("Y") Then
        '    Me.txt_Other.Visible = True
        '    Me.Label2.Visible = True
        '    Me.label_Msg.Visible = False
        '    Me.btnOpenOther.Visible = False
        'End If

    End Sub
End Class