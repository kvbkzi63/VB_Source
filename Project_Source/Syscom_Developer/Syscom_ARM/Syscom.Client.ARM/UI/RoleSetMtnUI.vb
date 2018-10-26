Imports System.ServiceModel
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
Imports Syscom.Comm.Utility.StringUtil
Imports Syscom.Comm.BASE
Imports Syscom.Comm.EXP
Imports Syscom.Client.CMM
Imports Syscom.Client.Servicefactory

Public Class RoleSetMtnUI
    Inherits Syscom.Client.UCL.BaseFormUI

    Dim asm As IArmServiceManager
    Dim dsParam As New DataSet
    Dim dsRoleInfo As New DataSet

    ''' <summary>
    ''' 載入ArmServiceManager的Instance
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub loadArmServiceManager()
        Try
            asm = ArmServiceManager.getInstance
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Sub

    ''' <summary>
    ''' 宣告
    ''' </summary>
    ''' <param name="ds"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal ds As System.Data.DataSet)
        Me.InitializeComponent()
        Me.dsParam = ds
    End Sub

    ''' <summary>
    ''' 載入AnaServiceManager的Instance
    ''' 設定欄位初值
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub RoleSetMtnUI_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            loadArmServiceManager()

            '設定UI的名稱字樣
            Select Case AppConfigUtil.AppLanguage
                Case AppConfigUtil.Language.TraditionalChinese
                    '繁體中文
                    lbl_userID.Text = "使用者代碼"
                    lbl_userName.Text = "使用者名稱"
                    bt_ok.Text = "確定"
                    bt_cancel.Text = "取消"
                Case AppConfigUtil.Language.SimplifiedChinese
                    '簡體中文
                    lbl_userID.Text = "使用者代码"
                    lbl_userName.Text = "使用者名称"
                    bt_ok.Text = "确定"
                    bt_cancel.Text = "取消"
            End Select

            '設定資料
            setFieldInitialValue()
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    ''' <summary>
    ''' 設定欄位初值
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub setFieldInitialValue()
        Try
            txt_userID.Text = dsParam.Tables(0).Rows(0).Item("userid").ToString.Trim
            txt_userName.Text = dsParam.Tables(0).Rows(0).Item("username").ToString.Trim

            '取得角色權限、全部權限、全部權限系統的資料
            dsRoleInfo = asm.RoleBelongQuery(Me.dsParam)

            tree_Review.TreeViewName = "角色清單"
            tree_Review.SetTreeView(dsRoleInfo.Tables(1), "Parent_Code_Id", "Parent_Code_Name", "Layer_Code_Id", "Layer_Code_Name", True)

            If dsRoleInfo.Tables(0).Rows.Count > 0 Then
                For Each row As DataRow In dsRoleInfo.Tables(0).Rows
                    tree_Review.SelectedNodeItem(row.Item("roleID").ToString.Trim)
                Next

                '將捲軸回到最上面
                tree_Review.tre_TreeViewAdv.Nodes(0).EnsureVisible()
            End If
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Sub

    ''' <summary>
    ''' 確定修改資料
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub bt_ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_ok.Click
        Try
            Dim askMsgTraditional As String() = {"是否要修改這筆資料?", "歸屬角色"}
            Dim askMsgSimple As String() = {"是否要修改这笔资料?", "归属角色"}
            Dim askMsg As String() = askMsgTraditional

            '根據語言選擇要顯示的字眼
            Select Case AppConfigUtil.AppLanguage
                Case AppConfigUtil.Language.TraditionalChinese
                    askMsg = askMsgTraditional
                Case AppConfigUtil.Language.SimplifiedChinese
                    askMsg = askMsgSimple
            End Select

            '取得樹狀結構的資料
            Dim dt As DataTable = tree_Review.GetSelectedItemsResultInDataTable(False)
            Dim ds As New DataSet
            dt.Columns("Layer_Code_Id").ColumnName = "Role"
            dt.Columns.Add("Employee_Code")
            dt.Columns.Add("Update_User")
            dt.Columns.Add("Update_Time")

            For Each row As DataRow In dt.Rows
                row.Item("Employee_Code") = txt_userID.Text
                row.Item("Update_User") = AppContext.userProfile.userId
                row.Item("Update_Time") = Now.ToString("yyyy-MM-dd HH:mm:ss")
            Next
            ds.Tables.Add(dt)
            asm.RoleBelongUpdate(dsParam, ds)
            MessageHandling.ShowInfoMsg("CMMCMMB903", New String() {})
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    ''' <summary>
    ''' 取消修改資料
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub bt_cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_cancel.Click
        Try
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

End Class
