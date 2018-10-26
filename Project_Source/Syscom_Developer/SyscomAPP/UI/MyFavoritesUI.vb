Imports Syscom.Comm.Utility
Imports System.Windows.Forms
Imports System.IO
Imports Microsoft.VisualBasic.Devices
Imports System.Data
Imports System.Collections.Generic
Imports Syscom.Client.Servicefactory

Public Class MyFavoritesUI
    Inherits Syscom.Client.UCL.BaseFormUI

    Private ProfilePath As String = "" ' Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), CurrentUserID)
    Private CurrentUserID As String = AppContext.userProfile.userId '目前使用者的ID
    '加入Service
    'Dim PubServiceManager.getInstance As IPcsPubServiceManager = PcsPubServiceManager.getInstance



    Private Sub MyFavoritesUI_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            m_Function_Name = ""
            Chk_List.Items.Clear()
            Txt_UserProfile.Text = ""
            Chk_Default.Checked = False
            Me.Text = "我的最愛"

            Dim ds As DataSet = ArmServiceManager.getInstance.queryProfile(ModForm.SystemNo, AppContext.userProfile.userId)
            Dim strKey As String = ""
            Dim strValue As String = ""

            If ds.Tables(0).Rows.Count > 0 Then
                For Each row As DataRow In ds.Tables(0).Rows
                    strKey = row("Is_Default").ToString.Trim
                    strValue = row("Sub_File_Name").ToString.Trim
                    Chk_List.Items.Add(New KeyValuePair(strKey, strValue))
                Next

            End If
        Catch ex As Exception

        End Try
    End Sub

#Region "   Button click"
    Private Sub Btn_Close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Close.Click
        Me.Close()
    End Sub

    Private Sub Btn_Insert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Insert.Click
        Dim result As DialogResult = MessageBox.Show("請確定畫面上的頁籤要存到我的最愛" & vbCrLf & "是否存檔?", "存檔提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        If result = Windows.Forms.DialogResult.Yes Then
            Try
                If Txt_UserProfile.Text <> "" Then
                    m_Profile_Name = createUserFolder(CurrentUserID) & "\" & Txt_UserProfile.Text
                    m_Function_Name = "add"
                    If Chk_Default.Checked Then
                        m_Default_Flag = "Y"
                    Else
                        m_Default_Flag = ""
                    End If
                    Me.Close()
                Else
                    MessageBox.Show("請輸入存檔名稱", "輸入提示", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Txt_UserProfile.BackColor = System.Drawing.Color.Pink
                End If
                Txt_UserProfile.Text = ""
            Catch ex As Exception
                Exit Sub
            End Try
        End If
    End Sub
    Private Sub Btn_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Delete.Click
        Dim result As DialogResult = MessageBox.Show("是否刪除?", "存檔提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If result = Windows.Forms.DialogResult.Yes Then
            Try
                ArmServiceManager.getInstance.deleteProfile(ModForm.SystemNo, AppContext.userProfile.userId, Txt_UserProfile.Text.Trim)
                If Txt_UserProfile.Text.Trim <> "" Then
                    'File.Delete(createUserFolder(CurrentUserID) & "\" & Txt_UserProfile.Text.Trim)
                    Chk_List.Items.RemoveAt(Chk_List.SelectedIndex)
                    Txt_UserProfile.Text = ""
                Else
                    MessageBox.Show("請點選欲刪除的檔案", "輸入提示", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

            Catch ex As Exception
                Throw ex
            End Try
        End If
    End Sub
    Private Sub Btn_UpDefault_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_UpDefault.Click
        Dim result As DialogResult = MessageBox.Show("是否變更預設", "設定提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        Dim flag As String = "N"
        If result = Windows.Forms.DialogResult.Yes Then
            If Chk_Default.Checked = True Then
                flag = "Y"
            End If
            Try

                If Txt_UserProfile.Text.Trim = "" Then
                    MessageBox.Show("請點選欲設定的檔案", "設定提示", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    ArmServiceManager.getInstance.updateProfileDefault(ModForm.SystemNo, AppContext.userProfile.userId, Txt_UserProfile.Text.Trim, flag)
                    Me.Close()
                End If

            Catch ex As Exception
                Throw ex
            End Try
        End If
    End Sub
#End Region

#Region "   Create User Folder"
    Function createUserFolder(ByVal userID As String) As String
        Dim myComputer As New Computer
        Dim exePath As String = myComputer.FileSystem.SpecialDirectories.MyDocuments
        Dim UserPath As String = exePath & "\" & userID '上一層目錄
        Dim userDefaultPath As String = UserPath & "\Def"
        If Directory.Exists(UserPath) = False Then
            Directory.CreateDirectory(UserPath)
        End If
        If Directory.Exists(userDefaultPath) = False Then
            Directory.CreateDirectory(userDefaultPath)
            m_User_Path = userDefaultPath
        End If
        Return UserPath
    End Function
#End Region

#Region "   屬性"

    Private m_Profile_Name As String = ""
    Public Property Profile_Name() As System.String
        Get
            Return m_Profile_Name
        End Get

        Set(ByVal _value As String)
            m_Profile_Name = _value
        End Set
    End Property
    Private m_Function_Name As String = ""
    Public Property Function_Name() As System.String
        Get
            Return m_Function_Name
        End Get

        Set(ByVal _value As String)
            m_Function_Name = _value
        End Set
    End Property
    Private m_Default_Flag As String = ""
    Public Property Default_Flag() As System.String
        Get
            Return m_Default_Flag
        End Get

        Set(ByVal _value As String)
            m_Default_Flag = _value
        End Set
    End Property
    Private m_User_Path As String = ""
    Public Property User_Path() As System.String
        Get
            Return m_User_Path
        End Get

        Set(ByVal _value As String)
            m_User_Path = _value
        End Set
    End Property
#End Region

#Region "   Chk_List事件"

    Private Sub Chk_List_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Chk_List.MouseDoubleClick
        Try
            Dim objKeyValuePair As KeyValuePair = DirectCast(Chk_List.SelectedItem, KeyValuePair)
            Dim strkey As String = objKeyValuePair.m_objKey.ToString()
            Dim strvalue As String = objKeyValuePair.m_strValue.ToString()
            Txt_UserProfile.Text = strvalue
            If Chk_List.SelectedItem.ToString <> "" Then
                m_Profile_Name = createUserFolder(CurrentUserID) & "\" & Txt_UserProfile.Text
                m_Function_Name = "run"
            End If
            Txt_UserProfile.Text = ""
            Me.Close()
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub Chk_List_MouseClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk_List.MouseClick
        Try
            Dim objKeyValuePair As KeyValuePair = DirectCast(Chk_List.SelectedItem, KeyValuePair)
            Dim strkey As String = objKeyValuePair.m_objKey.ToString()
            Dim strvalue As String = objKeyValuePair.m_strValue.ToString()
            Txt_UserProfile.Text = strvalue
            If strkey = "Y" Then
                Chk_Default.Checked = True
            Else
                Chk_Default.Checked = False
            End If
        Catch ex As Exception
            Exit Sub
        End Try


    End Sub

#End Region

#Region "   Class"

    Public Class KeyValuePair
        Public m_objKey As Object
        Public m_strValue As String

        Public Sub New(ByVal NewKey As Object, ByVal NewValue As String)
            m_objKey = NewKey
            m_strValue = NewValue
        End Sub

        Public Overrides Function ToString() As String
            Return m_strValue
        End Function
    End Class
#End Region


End Class