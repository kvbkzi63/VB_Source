'/*
'*****************************************************************************
'*
'*    Page/Class Name:  多選作業
'*              Title:	UclMutiGridUI
'*        Description:	多選作業
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Sean.Lin
'*        Create Date:	2015-11-05
'*      Last Modifier:	Sean.Lin
'*   Last Modify Date:	2015-11-05
'*
'*****************************************************************************
'*/
 
Imports Syscom.Comm.EXP
Imports Syscom.Comm.Utility
Imports Syscom.Comm.Utility.StringUtil
Imports Syscom.Comm.Utility.CheckMethodUtil

Imports Syscom.Client.CMM
Imports Syscom.Client.CMM.MessageHandling
Imports Syscom.Client.Servicefactory
Imports Syscom.Client.UCL
Imports Syscom.Client.UCL.UCLScreenUtil
 

Public Class UclMutiGridUI

#Region "     變數宣告 "

#Region "     使用者宣告　"

    '目前使用者的ID
    Private CurrentUserID As String = AppContext.userProfile.userId
 
#End Region
 
#Region "     使用的Instance宣告 "

    Private Shared myInstance As UclMutiGridUI
    Public Shared Function GetInstance() As UclMutiGridUI
        If myInstance Is Nothing Then
            myInstance = New UclMutiGridUI
        End If
        Return myInstance
    End Function

#End Region

    '只有當呼叫Grid 單筆模式才會設定為True
    '主要作為確認前檢核用
    Private gblGridIsSingle As Boolean = False
    Private gblGridDs As DataSet = Nothing

#End Region

#Region "     屬性設定 "



#End Region

#Region "     主要功能 "
    ''' <summary>
    ''' Show Events
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Sub Form_Show(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Shown
        Dim ds As DataSet = gblGridDs
        If CheckHasTable(ds, "CNC_CureDisable_Record") Then
            For Each dr As DataRow In ds.Tables("CNC_CureDisable_Record").Rows
                '勾選已存在資料
                For i = 0 To dgv_Show.Rows.Count - 1
                    If dr.Item("BodyPartsNo").ToString.Trim.Equals(nvl(dgv_Show.Rows(i).Cells(1).Value, "").ToString.Trim) Then
                        CType(dgv_Show.Rows(i).Cells(0), DataGridViewCheckBoxCell).Value = True
                    End If
                Next


            Next
        End If

    End Sub
#Region "     按鈕功能 "

#Region " 確定 "

    ''' <summary>
    ''' 確定
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2015-11-05</remarks>
    Private Sub btn_Confirm_Click(sender As Object, e As EventArgs) Handles btn_Confirm.Click

        '鎖定螢幕
        Lock(Me)
        Try

            If gblGridIsSingle = True Then

                If dgv_Show.CurrentCellAddress.Y <> -1 Then
                    DialogResult = Windows.Forms.DialogResult.OK
                Else
                    ShowWarnMsg("CMMCMMB300", "沒有點選資料列，不可確認，請取消!")
                    Exit Sub
                End If

            Else
                DialogResult = Windows.Forms.DialogResult.OK
            End If


            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FormatException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"確定"})
        Finally
            '解除螢幕鎖定
            UnLock(Me)
        End Try

    End Sub

#End Region

#Region " 取消 "

    ''' <summary>
    ''' 取消
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2015-11-05</remarks>
    Private Sub btn_Cancel_Click(sender As Object, e As EventArgs) Handles btn_Cancel.Click
        Me.Close()
    End Sub

#End Region

#End Region

#Region "     外部參數傳遞 (提供其他UI呼叫、傳入參數) "

#Region "     顯示UI - ShowDialog "

    ''' <summary>
    ''' 顯示UI - ShowDialog
    ''' </summary>
    ''' <param name="UIName">要顯示的作業名稱</param>
    ''' <param name="dt">要顯示的資料 HashTable </param>
    ''' <param name="ColumnText" >要顯示的欄位名稱 EX:"XXX,OOO" </param>
    ''' <param name="ColumnVisibleIndex" >要顯示的欄位index EX:"1,3,4,5"</param>
    ''' <param name="ColumnWidth" >要顯示的欄位寬度 EX:"80,80,150"</param> 
    ''' <param name="isMutiSelect">True:可複選； False:單選</param> 
    ''' <remarks>by Sean.Lin on 2015-11-05</remarks>
    Public Shadows Function ShowDialog(ByVal UIName As String, ByVal dt As DataTable, ByVal columnText As String, ByVal columnVisibleIndex As String, ByVal columnWidth As String, ByVal isMutiSelect As Boolean) As DialogResult

        Try

            Dim ds As New DataSet

            ds.Tables.Add(dt.Copy)

            'ShowDialog
            Return ShowDialog(UIName, ds, columnText, columnVisibleIndex, columnWidth, isMutiSelect)


        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"顯示UI - ShowDialog"})
        End Try

    End Function

#End Region

#Region "     顯示UI - ShowDialog "

    ''' <summary>
    ''' 顯示UI - ShowDialog
    ''' </summary>
    ''' <param name="UIName">要顯示的作業名稱</param>
    ''' <param name="ht">要顯示的資料 HashTable </param>
    ''' <param name="ColumnText" >要顯示的欄位名稱 EX:"XXX,OOO" </param>
    ''' <param name="ColumnVisibleIndex" >要顯示的欄位index EX:"1,3,4,5"</param>
    ''' <param name="ColumnWidth" >要顯示的欄位寬度 EX:"80,80,150"</param> 
    ''' <param name="isMutiSelect">True:可複選； False:單選</param> 
    ''' <remarks>by Sean.Lin on 2015-11-05</remarks>
    Public Shadows Function ShowDialog(ByVal UIName As String, ByVal ht As Hashtable, ByVal columnText As String, ByVal columnVisibleIndex As String, ByVal columnWidth As String, ByVal isMutiSelect As Boolean) As DialogResult

        Try
            '設定顯示的UI Name
            Me.Text = UIName

            '設定UI的顯示
            dgv_Show.Visible = True
            cbo_Phrase.Visible = False
            rtb_Phrase.Visible = False

            '判斷單複選
            If isMutiSelect = True Then
                '複選
                dgv_Show.MultiSelect = True
                dgv_Show.uclMultiSelectShowCheckBoxHeader = True
                gblGridIsSingle = False
            Else
                '單選
                dgv_Show.MultiSelect = False
                dgv_Show.uclMultiSelectShowCheckBoxHeader = False
                gblGridIsSingle = True
            End If

            '顯示資料
            dgv_Show.Initial(ht, columnText, columnVisibleIndex, columnWidth)

            '清除點選
            If isMutiSelect = True Then
                If dgv_Show.CurrentRow IsNot Nothing Then

                    dgv_Show.CurrentRow.Selected = False

                End If
            End If

            If (Not ht.Item(-1) Is Nothing) AndAlso TypeOf (ht.Item(-1)) Is DataSet Then
                gblGridDs = ht.Item(-1)
            End If

            MyBase.ShowDialog()

            Return DialogResult

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"顯示UI - ShowDialog"})
        End Try

    End Function

#End Region

#Region "     顯示UI - ShowDialog "

    ''' <summary>
    ''' 顯示UI - ShowDialog
    ''' </summary>
    ''' <param name="UIName">要顯示的作業名稱</param>
    ''' <param name="ds">要顯示的資料 Dataset </param>
    ''' <param name="ColumnText" >要顯示的欄位名稱 EX:"XXX,OOO" </param>
    ''' <param name="ColumnVisibleIndex" >要顯示的欄位index EX:"1,3,4,5"</param>
    ''' <param name="ColumnWidth" >要顯示的欄位寬度 EX:"80,80,150"</param> 
    ''' <param name="isMutiSelect">True:可複選； False:單選</param> 
    ''' <remarks>by Sean.Lin on 2015-11-05</remarks>
    Public Shadows Function ShowDialog(ByVal UIName As String, ByVal ds As DataSet, ByVal columnText As String, ByVal columnVisibleIndex As String, ByVal columnWidth As String, ByVal isMutiSelect As Boolean) As DialogResult

        Try

            Dim ht As New Hashtable

            ht.Add(-1, ds)

            'ShowDialog
            Return ShowDialog(UIName, ht, columnText, columnVisibleIndex, columnWidth, isMutiSelect)

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"顯示UI - ShowDialog"})
        End Try

    End Function

#End Region

#Region "     顯示UI - ComboBox "

    ''' <summary>
    ''' ComboBox 的片語視窗 
    ''' </summary>
    ''' <param name="UIName">要顯示的作業名稱</param>
    ''' <param name="dsCbo">要顯示的資料的Dataset </param>
    ''' <param name="valuIndex" >要顯示的欄index EX:"O" </param>
    ''' <param name="displayIndex" >要顯示的欄位index EX:"1"</param>
    ''' <remarks>by Sean.Lin on 2015-11-05</remarks>
    Public Shadows Function ShowDialogCbo(ByVal UIName As String, ByVal dsCbo As DataSet, ByVal displayIndex As Int32, ByVal valuIndex As Int32) As DialogResult

        Try
            '設定顯示的UI Name
            Me.Text = UIName

            '顯示資料
            cbo_Phrase.Initial(dsCbo.Tables(0), displayIndex, valuIndex)

            '設定UI的顯示
            dgv_Show.Visible = False
            cbo_Phrase.Visible = True
            rtb_Phrase.Visible = False

            Me.Height = 150
            Me.Width = 490
            Me.cbo_Phrase.Margin = New Padding(40, 20, 40, 10)

            MyBase.ShowDialog()

            Return DialogResult

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"顯示UI - ShowDialog"})
        End Try

    End Function

#End Region

#Region "     顯示UI - Text "

    ''' <summary>
    ''' Text 的片語視窗
    ''' </summary>
    ''' <param name="UIName">要顯示的作業名稱</param>
    ''' <param name="phraseText">要顯示的資料的Dataset </param> 
    ''' <remarks>by Sean.Lin on 2015-11-05</remarks>
    Public Shadows Function ShowDialogText(ByVal UIName As String, ByVal phraseText As String) As DialogResult

        Try
            '設定顯示的UI Name
            Me.Text = UIName

            '顯示資料
            rtb_Phrase.Text = phraseText
            rtb_Phrase.Height = 600
            TableLayoutPanel1.RowStyles(1).Height = 620
            '設定UI的顯示
            dgv_Show.Visible = False
            cbo_Phrase.Visible = False
            rtb_Phrase.Visible = True

            MyBase.ShowDialog()

            Return DialogResult

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"顯示UI - ShowDialog"})
        End Try

    End Function

#End Region

#Region "     取得 被選擇的 DataRow - 單筆Grid使用 "

    ''' <summary>
    ''' 取得 被選擇的 DataRow - 單筆Grid使用
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2016-05-04</remarks>
    Public Function GetSelectedDR() As DataRow

        Try

            If dgv_Show.CurrentCellAddress.Y <> -1 Then
                '有點選，回傳被點選的資料列
                Return dgv_Show.GetDBDS.Tables(0).Rows(dgv_Show.CurrentCellAddress.Y)
            Else
                Return Nothing
            End If

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"取得 被選擇的 DataRow - 單筆Grid使用"})
        End Try

    End Function

#End Region

#Region "     取得 被選擇的 DS "

    ''' <summary>
    ''' 取得 被選擇的 DS
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2015-11-05</remarks>
    Public Function GetSelectedDS() As DataSet

        Try

            '顯示資料  
            Return dgv_Show.GetSelectedDS

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"取得 被選擇的 DS"})
        End Try

    End Function

#End Region

#Region "     取得 未被選擇的 DS "

    ''' <summary>
    ''' 取得 未被選擇的 DS
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2015-11-05</remarks>
    Public Function GetUnSelectedDS() As DataSet

        Try

            '顯示資料  
            Return dgv_Show.GetUnSelectedDS

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"取得 未被選擇的 DS"})
        End Try

    End Function

#End Region

#Region "     取得 Cbo SelectedValue "

    ''' <summary>
    ''' 取得 Cbo SelectedValue
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2015-11-05</remarks>
    Public Function GetSelectedValue() As String

        Try

            '顯示資料  
            Return cbo_Phrase.SelectedValue

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"取得 Cbo SelectedValue"})
        End Try

    End Function

#End Region

#Region "     取得 Cbo SelectedText "

    ''' <summary>
    ''' 取得 Cbo SelectedText
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2015-11-05</remarks>
    Public Function GetSelectedText() As String

        Try

            '顯示資料  
            Return cbo_Phrase.SelectedText

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"取得 Cbo SelectedText"})
        End Try

    End Function

#End Region

#Region "     取得 Cbo SelectedText "

    ''' <summary>
    ''' 取得 Cbo SelectedText
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2015-11-05</remarks>
    Public Function GetRtbText() As String

        Try

            '顯示資料  
            Return rtb_Phrase.Text.ToString

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"取得 Cbo SelectedText"})
        End Try

    End Function

#End Region

#End Region

#End Region

#Region "     內部功能 "

#Region "     初始化設定 "

     

#End Region

#Region "     取得存檔的Dataset資料 "



#End Region

#End Region
 
End Class

