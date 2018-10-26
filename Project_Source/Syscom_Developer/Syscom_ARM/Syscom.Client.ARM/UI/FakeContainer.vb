Imports System.Reflection
Imports System.Windows.Forms

Public Class FakeContainer

    Private Sub FakeContainer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim MainMenu1 As MainMenu = New MainMenu
        Me.Menu = MainMenu1
        'Dim mi As MenuItem = New MenuItem()
        logout.Name = "logout"
        logout.Text = "登出"
        '   mi.Visible = True
        MainMenu1.MenuItems.Add(logout)
        ARMMenu.Name = "ana"
        ARMMenu.Text = "權限維護"
        MainMenu1.MenuItems.Add(ARMMenu)
        Console.Write("length:")
        Console.WriteLine(funcs.Length)
        menuhandler = New EventHandler(AddressOf Me.menuClcik)
        Dim cmenu As MenuItem
        For j = 0 To UBound(funcs, 2)
            cmenu = New MenuItem()
            cmenu.Text = funcs(0, j)
            cmenu.Name = funcs(1, j)
            AddHandler cmenu.Click, menuhandler
            ARMMenu.MenuItems.Add(cmenu)
            'Console.WriteLine(funcs(i, j))
        Next
    End Sub

    Private Sub menuClcik(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim menu As MenuItem = CType(sender, MenuItem)
        'MsgBox("you click:" + menu.Name + "," + menu.Text)
        Try
            Dim myForm As Form = createForm(menu.Name)
            myForm.MdiParent = Me
            myForm.Show()

            'MsgBox("AB")
            '      MsgBox(myForm.roleId.Text)
            '      myForm.ShowDialog()
            '        MsgBox(myForm.Text)
            ' myForm.MdiParent = Me
            ' \        myForm.ShowDialog()


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        ' myForm.MdiParent = Me
        'Console.WriteLine(menu.Name)
        'Console.WriteLine(menu.Text)

    End Sub

    Private Sub Logout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles logout.Click
        Me.Visible = False
        Me.Owner.Visible = True
        Me.Dispose()
    End Sub

    Private WithEvents logout As MenuItem = New MenuItem()
    Private ARMMenu As MenuItem = New MenuItem()
    Private funcs(,) As String = {{"角色維護", "系統維護", "子系統維護", "作業維護", "部門維護", "科室維護", "功能維護", "使用者維護"}, {"RoleMaintain", "AppSystemMaintainForm", "Ana_SubSys_Form", "task_Form1", "ADAnaDepartmentUI", "ADAnaSectionUI", "AnaFunctionForm", "UserMaintain"}}
    Dim menuhandler As EventHandler


    Private Shared Function createOBjectInstance(ByVal name As String) As Object
        Dim obj As Object
        Try
            If name.LastIndexOf(".") = -1 Then
                name = "Syscom.client.ana." & name
            End If
            obj = Assembly.GetEntryAssembly.CreateInstance(name)
        Catch ex As Exception
            MsgBox(ex.Message)
            obj = Nothing
        End Try
        Return obj
    End Function

    Private Shared Function createForm(ByVal formName As String) As Form
        Return DirectCast(createOBjectInstance(formName), Form)
    End Function

End Class
