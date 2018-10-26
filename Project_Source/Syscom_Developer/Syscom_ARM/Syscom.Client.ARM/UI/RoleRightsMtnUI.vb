Imports System.Data.SqlClient
Imports System.Text
Imports System.ServiceModel
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
Imports Syscom.Comm.BASE
Imports Syscom.Comm.EXP
Imports Syscom.Client.CMM
Imports Syscom.Client.Servicefactory
Imports System.Windows.Forms

Public Class RoleRightsMtnUI

    Private role_id As String = Nothing
    Private role_name As String = Nothing

    Dim hsm As IArmServiceManager

    '繁體中文的訊息名稱
    Dim CheckMsgTraditional() As String = {"請選擇要歸屬的項目", "請選擇已歸屬的項目", "無可移除的已歸屬項目"}

    '簡體體中文的訊息名稱
    Dim CheckMsgSimple() As String = {"请选择要归属的项目", "请选择已归属的项目", "无可移除的已归属项目"}

    '要顯示的訊息名稱 - 在 initial 時 會根據 AppConfigUtil.AppLanguage 的值去設定，預設繁體中文
    Dim CheckMsg() As String = {}

    Dim gblColumnName As String = "功能名稱,nodeValue,fun_special_flag,rrs_role_id,rrs_rights_id,rrs_rights_type,opd_flag,eis_flag,pcs_flag,可否新增,可否修改,可否刪除,可否查詢,可否儲存,可否列印"

    Dim gblVisiblecolIndex As String = "0, 9, 10, 11, 12, 13, 14"

    Public Sub New(ByVal roleID As String, ByVal roleName As String)

        ' 此為 Windows Form 設計工具所需的呼叫。
        InitializeComponent()

        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。
        role_id = roleID
        role_name = roleName
    End Sub

    Private Sub loadArmServiceManager()
        Try
            hsm = ArmServiceManager.getInstance()
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Sub

    Private Sub RoleRightsMtnUI_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            loadArmServiceManager()

            '設定UI的名稱字樣
            Select Case AppConfigUtil.AppLanguage
                Case AppConfigUtil.Language.TraditionalChinese

                    '設定訊息
                    CheckMsg = CheckMsgTraditional

                    '繁體中文
                    lbl_roleID.Text = "角色代碼"
                    lbl_roleName.Text = "角色名稱"
                    btn_Confirm.Text = "確認"
                    btn_Cancel.Text = "取消"

                Case AppConfigUtil.Language.SimplifiedChinese

                    '設定訊息
                    CheckMsg = CheckMsgSimple

                    '簡體中文
                    lbl_roleID.Text = "角色代码"
                    lbl_roleName.Text = "角色名称"
                    btn_Confirm.Text = "确认"
                    btn_Cancel.Text = "取消"
            End Select

            txt_RoleID.Text = role_id
            txt_roleName.Text = role_name

            Dim dsRR As DataSet = hsm.queryForRoleRightsMaintain(role_id)

            If dsRR.Tables("AllRoleRights").Rows.Count > 0 Then
                tree_Review.TreeViewName = "角色清單"
                tree_Review.SetTreeView(dsRR.Tables("AllRoleRights"), "Parent_Code_Id", "Parent_Code_Name", "Layer_Code_Id", "Layer_Code_Name")
            End If

            If dsRR.Tables(0).Rows.Count > 0 Then
                Dim fun_special_flag As String = ""
                For Each row As DataRow In dsRR.Tables(0).Rows
                    If row("fun_special_flag").ToString.Trim <> "" Then
                        fun_special_flag = "@" & row("fun_special_flag").ToString.Trim
                    Else
                        fun_special_flag = ""
                    End If
                    tree_Review.SelectedNodeItem(row("nodeValue").ToString.Trim & fun_special_flag)
                Next

                '將捲軸回到最上面
                tree_Review.tre_TreeViewAdv.Nodes(0).EnsureVisible()

            End If

            '設定顯示按鈕開啟權限在 Grid上

            If dsRR.Tables.Count >= 2 Then

                '組成要顯示的功能層級資料的Dataset
                Dim dsTemp As New DataSet
                dsTemp.Tables.Add(dsRR.Tables(1).Copy)

                '組成含有CheckBox的HashDatatabl
                Dim _hash As New Hashtable()
                _hash.Add(-1, dsTemp)

                '初始化 btn_Insert_flag
                Dim ckbCell_Insert As New Syscom.Client.UCL.CheckBoxCell
                _hash.Add(9, ckbCell_Insert)

                '初始化 btn_Update_flag
                Dim ckbCell_Update As New Syscom.Client.UCL.CheckBoxCell
                _hash.Add(10, ckbCell_Update)

                '初始化 btn_Delete_flag
                Dim ckbCell_Delete As New Syscom.Client.UCL.CheckBoxCell
                _hash.Add(11, ckbCell_Delete)

                '初始化 btn_Query_flag
                Dim ckbCell_Query As New Syscom.Client.UCL.CheckBoxCell
                _hash.Add(12, ckbCell_Query)

                '初始化 btn_Save_flag
                Dim ckbCell_Save As New Syscom.Client.UCL.CheckBoxCell
                _hash.Add(13, ckbCell_Save)

                '初始化 btn_Print_flag
                Dim ckbCell_Print As New Syscom.Client.UCL.CheckBoxCell
                _hash.Add(14, ckbCell_Print)

                UclDgv_Show.Initial(_hash, gblColumnName, gblVisiblecolIndex)

            End If

        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    Private Sub Confirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Confirm.Click
        Try
            Dim dt As DataTable = tree_Review.GetSelectedItemsResultInDataTable(True)
            Dim dbDT As DataTable = ArmRolerightsDataTableFactory.getDataTable
            dbDT.TableName = role_id

            For Each row As DataRow In dt.Rows
                Dim token() As String = row.Item("Layer_Code_Id").ToString.Trim.Split("@")
                Dim insertRow As DataRow = dbDT.NewRow
                insertRow.Item("rrs_role_id") = role_id
                insertRow.Item("rrs_rights_id") = token(0)
                insertRow.Item("rrs_rights_type") = token(1)
                insertRow.Item("opd_flag") = "Y"
                insertRow.Item("eis_flag") = "Y"
                insertRow.Item("pcs_flag") = "Y"

                insertRow.Item("btnInsert_flag") = "Y"
                insertRow.Item("btnUpdate_flag") = "Y"
                insertRow.Item("btnDelete_flag") = "Y"
                insertRow.Item("btnQuery_flag") = "Y"
                insertRow.Item("btnSave_flag") = "Y"
                insertRow.Item("btnPrint_flag") = "Y"

                dbDT.Rows.Add(insertRow)
            Next

            Dim dsGrid As DataSet = UclDgv_Show.GetDBDS

            Dim drBtn As DataRow()

            For Each drDB As DataRow In dbDT.Rows
                drBtn = dsGrid.Tables(0).Select("rrs_rights_id = '" & drDB.Item("rrs_rights_id").ToString.Trim & "'")
                If drBtn.Count > 0 Then
                    ' "btnInsert_flag", "btnUpdate_flag", "btnDelete_flag", "btnQuery_flag", "btnSave_flag", "btnPrint_flag"
                    drDB.Item("btnInsert_flag") = drBtn(0).Item("btnInsert_flag").ToString
                    drDB.Item("btnUpdate_flag") = drBtn(0).Item("btnUpdate_flag").ToString
                    drDB.Item("btnDelete_flag") = drBtn(0).Item("btnDelete_flag").ToString
                    drDB.Item("btnQuery_flag") = drBtn(0).Item("btnQuery_flag").ToString
                    drDB.Item("btnSave_flag") = drBtn(0).Item("btnSave_flag").ToString
                    drDB.Item("btnPrint_flag") = drBtn(0).Item("btnPrint_flag").ToString
                End If
            Next

            Dim ds As New DataSet
            ds.Tables.Add(dbDT)
            hsm.ConfirmRoleRights(ds)
            Me.Dispose()
            Me.Close()
            MessageHandling.ShowInfoMsg("CMMCMMB905", New String() {})
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Cancel.Click
        Try
            Me.Dispose()
            Me.Close()
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    Private Sub treeAftersSelect(ByVal selectedNode As TreeNode) Handles tree_Review.SelectedItem
        Try
            If Not selectedNode Is Nothing And Not UclDgv_Show.GetDBDS Is Nothing Then
                Dim strNodeName As String() = selectedNode.Name.Split("@")
                Dim strRrsRightsId As String = strNodeName(0)

                '判斷是否可以新增的Flag
                Dim insertflag As Boolean = True

                'Node 為功能層才可對Grid 進行異動
                If strNodeName(1) = "fun" Then
                    Dim dr As DataRow = UclDgv_Show.GetDBDS.Tables(0).NewRow
                    dr.Item("rrs_rights_name") = selectedNode.Text.Split(" - ")(2)
                    dr.Item("rrs_rights_id") = strRrsRightsId
                    dr.Item("btnInsert_flag") = "Y"
                    dr.Item("btnUpdate_flag") = "Y"
                    dr.Item("btnDelete_flag") = "Y"
                    dr.Item("btnQuery_flag") = "Y"
                    dr.Item("btnSave_flag") = "Y"
                    dr.Item("btnPrint_flag") = "Y"

                    '判斷是否已經存在在DS中
                    For i As Integer = 0 To UclDgv_Show.GetDBDS.Tables(0).Rows.Count - 1
                        If UclDgv_Show.GetDBDS.Tables(0).Rows(i).Item("rrs_rights_id").ToString.Trim = strRrsRightsId Then
                            insertflag = False
                            Exit For
                        End If
                    Next

                    If insertflag AndAlso strNodeName(2) = "Y" Then
                        '新增
                        UclDgv_Show.InsertRowDbDsAt(dr, UclDgv_Show.GetDBDS.Tables(0).Rows.Count)
                        UclDgv_Show.InsertRowGridDsAt(dr, UclDgv_Show.GetGridDS.Tables(0).Rows.Count)

                        '將畫面上的Checkbox打勾
                        UclDgv_Show.Rows(UclDgv_Show.GetGridDS.Tables(0).Rows.Count - 1).Cells(9).Value = True
                        UclDgv_Show.Rows(UclDgv_Show.GetGridDS.Tables(0).Rows.Count - 1).Cells(10).Value = True
                        UclDgv_Show.Rows(UclDgv_Show.GetGridDS.Tables(0).Rows.Count - 1).Cells(11).Value = True
                        UclDgv_Show.Rows(UclDgv_Show.GetGridDS.Tables(0).Rows.Count - 1).Cells(12).Value = True
                        UclDgv_Show.Rows(UclDgv_Show.GetGridDS.Tables(0).Rows.Count - 1).Cells(13).Value = True
                        UclDgv_Show.Rows(UclDgv_Show.GetGridDS.Tables(0).Rows.Count - 1).Cells(14).Value = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"點選節點"})
        End Try
    End Sub

    Private Sub treeRemoveItem(ByVal selectedNode As TreeNode) Handles tree_Review.RemoveItem
        Try
            If Not selectedNode Is Nothing And Not UclDgv_Show.GetDBDS Is Nothing Then
                Dim strNodeName As String() = selectedNode.Name.Split("@")
                'Node 為功能層才可對Grid 進行異動
                If strNodeName(1) = "fun" Then
                    Dim strRrsRightsId As String = strNodeName(0)
                    For i As Integer = 0 To UclDgv_Show.GetDBDS.Tables(0).Rows.Count - 1
                        If UclDgv_Show.GetDBDS.Tables(0).Rows(i).Item("rrs_rights_id").ToString.Trim = strRrsRightsId Then
                            UclDgv_Show.GetDBDS.Tables(0).Rows.RemoveAt(i)
                            UclDgv_Show.GetGridDS.Tables(0).Rows.RemoveAt(i)
                            Exit For
                        End If
                    Next
                End If
            End If
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"點選節點"})
        End Try
    End Sub

End Class
