Imports Syscom.Client.servicefactory
Imports System.Windows.Forms
Imports Syscom.Client.CMM
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
Imports System.Text
Public Class PUBSystemVersionUI
    Inherits Syscom.Client.UCL.BaseFormUI

    Dim gblVersionIndex As Integer = 0
    Dim gblVersion As New DataTable

    Dim objPub As IPubServiceManager = Nothing
    '目前使用者的ID
    Dim currentUserID As String = AppContext.userProfile.userId
    Dim log As LOGDelegate = LOGDelegate.getInstance
    '獲取維護表名
    Dim tableDB As String = "PUB_System_Version"
    'Grid使用的標題
    ' Dim columnNameGrid() As String = {"系統名稱", "提出日期", "功能名稱", "問題描述", "版本號", "更新日期"}
    Dim columnNameGrid() As String = {"系統名稱", "更新說明", "版本號", "更新日期"}
    '獲取維護表字段名
    Dim columnNameDB() As String = New String() {"System_Name", "Problem_Description", "Version_No", "Update_Date"}

    '獲取維護表字段長度
    Dim columnsLength() As Integer = New Integer() {100, 680, 100, 100}

    '資料集類型定義
    Enum DataSet_Type
        Grid = 0
        DB = 1
    End Enum
    '控件類型定義
    Enum Control_Type
        TextBox
        Combobox
        DateTimePicker
    End Enum

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        initialData()
    End Sub

    Public Sub initialData()
        Try
            '初始化對象
            objPub = PubServiceManager.getInstance
            '構建空的Grid
            dgvShowData.DataSource = genDS(DataSet_Type.Grid).Tables(tableDB)

            Dim pvtQueryData As DataSet = Nothing
            Dim dsDB As New DataSet

            '執行查詢
            dsDB = objPub.DynamicQueryByColumn(pvtQueryData)

            cbo_Version_No.DataSource = CType(dsDB.Tables("Version_No"), System.Data.DataTable)
            cbo_Version_No.uclDisplayIndex = "0,1"
            cbo_Version_No.uclValueIndex = "0"

            gblVersion = dsDB.Tables("Version_No").Copy

            cbo_System.DataSource = CType(dsDB.Tables("arm_sub_system"), System.Data.DataTable)
            cbo_System.uclDisplayIndex = "0,1"
            cbo_System.uclValueIndex = "0"

            '設定Grid滿屏
            dgvShowData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
            For i = 0 To columnsLength.Count - 1
                dgvShowData.Columns(i).Width = columnsLength(i)
            Next


            dsDB.Tables("PUB_System_Version").Columns(0).ColumnName = "系統名稱"
            dsDB.Tables("PUB_System_Version").Columns(1).ColumnName = "更新說明"
            dsDB.Tables("PUB_System_Version").Columns(2).ColumnName = "版本號"
            dsDB.Tables("PUB_System_Version").Columns(3).ColumnName = "更新日期"

            dgvShowData.DataSource = dsDB.Tables(tableDB)

            cbo_Version_No.SelectedIndex = 1

            Me.KeyPreview = True '啟用才能觸發快速鍵功能

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' 產生一個空的DataSet
    ''' </summary>
    ''' <param name="type"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function genDS(ByVal type As Integer) As DataSet
        Dim dsTemp As New DataSet
        Select Case type
            Case DataSet_Type.Grid
                '給Grid用Table
                dsTemp.Tables.Add(tableDB)
                For i As Integer = 0 To columnNameGrid.Length - 1
                    dsTemp.Tables(tableDB).Columns.Add(columnNameGrid(i))
                Next
            Case DataSet_Type.DB
                '給DB用Table
                dsTemp.Tables.Add(tableDB)
                For i As Integer = 0 To columnNameDB.Length - 1
                    dsTemp.Tables(tableDB).Columns.Add(columnNameDB(i))
                Next
        End Select
        Return dsTemp
    End Function

    Private Sub btn_Query_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Query.Click
        queryData()
    End Sub

    ''' <summary>
    ''' 查詢事件
    ''' </summary>
    ''' <returns>Boolean</returns>
    ''' <remarks>True 查詢成功</remarks>
    Public Function queryData() As Boolean

        Dim blnReturnFlag As Boolean = True
        Dim dsDB As DataSet
        Dim dsGrid As DataSet = genDS(DataSet_Type.Grid)

        Dim pvtQueryData As New DataSet
        pvtQueryData.Tables.Add("QueryCondition")

        pvtQueryData.Tables(0).Columns.Add("System_Name")
        pvtQueryData.Tables(0).Columns.Add("BringUp_ST_Date")
        pvtQueryData.Tables(0).Columns.Add("BringUp_ED_Date")
        pvtQueryData.Tables(0).Columns.Add("Function_Name")
        pvtQueryData.Tables(0).Columns.Add("Problem_Description")
        pvtQueryData.Tables(0).Columns.Add("Version_No")
        pvtQueryData.Tables(0).Columns.Add("Update_ST_Date")
        pvtQueryData.Tables(0).Columns.Add("Update_ED_Date")

        Dim row1 As DataRow = pvtQueryData.Tables(0).Rows.Add

        row1("System_Name") = cbo_System.SelectedValue.ToString.Trim
        row1("BringUp_ST_Date") = ""
        row1("BringUp_ED_Date") = ""
        row1("Version_No") = cbo_Version_No.SelectedValue.ToString.Trim
        row1("Update_ST_Date") = ""
        row1("Update_ED_Date") = ""

        '執行查詢
        dsDB = objPub.DynamicQueryByColumn(pvtQueryData)
        Try
            If dsDB.Tables.Count > 0 Then
                If dsDB.Tables(tableDB).Rows.Count = 0 Then
                    '查無資料
                    'MessageHandling.showWarnByKey("CMMCMMB000")
                    '********************2010/2/9 Modify By Alan**********************
                    MessageHandling.showWarnMsg("CMMCMMB000", New String() {})
                    dgvShowData.DataSource = genDS(DataSet_Type.Grid).Tables(tableDB)
                Else
                    dsDB.Tables(0).Columns(0).ColumnName = "系統名稱"
                    'dsDB.Tables(0).Columns(1).ColumnName = "提出日期"
                    'dsDB.Tables(0).Columns(2).ColumnName = "功能名稱"
                    dsDB.Tables(0).Columns(1).ColumnName = "更新說明"
                    dsDB.Tables(0).Columns(2).ColumnName = "版本號"
                    dsDB.Tables(0).Columns(3).ColumnName = "更新日期"

                    dgvShowData.DataSource = dsDB.Tables(tableDB)
                End If
                Return blnReturnFlag
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub PUBSystemVersionUI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                btn_Query_Click(sender, e)
        End Select


    End Sub
    
    Private Sub btn_NextVersion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_NextVersion.Click
        If gblVersion IsNot Nothing And gblVersion.Rows.Count > 0 Then

            Dim pvtRowsCount As Integer = gblVersion.Rows.Count

            If gblVersionIndex - 1 >= 0 Then
                cbo_Version_No.SelectedIndex = gblVersionIndex - 1
                btn_Query_Click(sender, e)
            Else
                MessageHandling.ShowErrorMsg("CMMCMMB933", New String() {}, "")
            End If

        End If

    End Sub

    Private Sub btn_PreVersion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_PreVersion.Click
        If gblVersion IsNot Nothing And gblVersion.Rows.Count > 0 Then

            Dim pvtRowsCount As Integer = gblVersion.Rows.Count

            If gblVersionIndex + 1 <= pvtRowsCount - 1 Then
                cbo_Version_No.SelectedIndex = gblVersionIndex + 1
                btn_Query_Click(sender, e)
            Else
                MessageHandling.ShowErrorMsg("CMMCMMB933", New String() {}, "")
            End If

        End If
    End Sub

    Private Sub cbo_Version_No_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_Version_No.SelectedIndexChanged
        gblVersionIndex = cbo_Version_No.SelectedIndex
    End Sub
End Class


