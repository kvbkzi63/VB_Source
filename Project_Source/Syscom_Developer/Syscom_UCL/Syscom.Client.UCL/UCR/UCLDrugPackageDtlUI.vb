Imports Syscom.Comm.Utility
Imports Syscom.Comm.LOG
Imports Syscom.Client.CMM
Imports System.Text
Imports su = Syscom.Comm.Utility.StringUtil

Public Class UCLDrugPackageDtlUI
    Inherits Com.Syscom.WinFormsUI.Docking.DockContent

    '目前使用者的ID
    Dim currentUserID As String = AppContext.userProfile.userId
    '獲取維護表名
    Dim tableDB As String = "OMO_Favor"
    Dim columnNameGrid() As String = {"藥品名稱", "每次量/總量", "單位", "頻次", "途徑", "天數", "次數"}
    Dim columnWidthGrid() As Integer = {250, 120, 80, 80, 80, 80, 80}
    Dim blnISClose As Boolean = True
    Private ds As DataSet = Nothing
    Property seleDs() As DataSet
        Get
            Return ds
        End Get
        Set(ByVal value As DataSet)
            ds = value
        End Set
    End Property


#Region "產生一個DataSet"
    ''' <summary>
    ''' 產生一個DataSet並包含一個空的Table 給Grid用 或 DB用
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    Function genDS() As DataSet
        Dim dsTemp As New DataSet
        '給Grid用Table
        dsTemp.Tables.Add(tableDB)
        For i As Integer = 0 To columnNameGrid.Length - 1
            dsTemp.Tables(tableDB).Columns.Add(columnNameGrid(i))
        Next
        Return dsTemp
    End Function
#End Region


    Private Sub initDgvShowData(Optional ByVal dsGrid As DataSet = Nothing)
        If IsNothing(dsGrid) Then
            dsGrid = genDS()
        End If

        Dim hashTable As New Hashtable()

        hashTable.Add(-1, dsGrid)
        dgvShowData.Initial(hashTable)

        '設置grid屬性
        dgvShowData.MultiSelect = True
        dgvShowData.uclColumnCheckBox = True

        'dgvShowData.Columns(dgvShowData.Columns.Count - 1).Visible = False

        For i As Integer = 1 To dgvShowData.Columns.Count - 1
            If columnWidthGrid(i - 1) = -1 Then
                dgvShowData.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            Else
                dgvShowData.Columns(i).Width = columnWidthGrid(i - 1)
            End If
        Next
    End Sub

    ''' <summary>
    ''' Grid賦值
    ''' </summary>
    ''' <param name="dsDB"></param>
    ''' <remarks></remarks>
    Private Sub initGridData(ByVal dsDB As DataSet)
        Try
            Dim dsGrid As DataSet = genDS()
            If dsDB.Tables.Count > 0 Then
                If dsDB.Tables(0).Rows.Count > 0 Then
                    Dim drGrid As DataRow
                    '將查出的資料塞入Grid中()
                    For i As Integer = 0 To dsDB.Tables(0).Rows.Count - 1
                        drGrid = dsGrid.Tables(0).NewRow()
                        '{"藥品名稱", "每次量/總量", "單位", "頻次", "途徑", "天數", "次數"}
                        drGrid("藥品名稱") = su.nvl(dsDB.Tables(0).Rows(i)("Package_Content"))
                        drGrid("每次量/總量") = su.nvl(dsDB.Tables(0).Rows(i)("Dosage"))
                        drGrid("單位") = su.nvl(dsDB.Tables(0).Rows(i)("Dosage_Unit"))
                        drGrid("頻次") = su.nvl(dsDB.Tables(0).Rows(i)("Frequency_Code"))
                        drGrid("途徑") = su.nvl(dsDB.Tables(0).Rows(i)("Usage_Code"))
                        drGrid("天數") = su.nvl(dsDB.Tables(0).Rows(i)("Days"))
                        drGrid("次數") = su.nvl(dsDB.Tables(0).Rows(i)("Times"))
                        dsGrid.Tables(0).Rows.Add(drGrid)
                    Next

                    initDgvShowData(dsGrid)
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' 初始化
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub UCLDrugPackageDtlUI_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            ''test data
            'ds = genDS()
            'Dim dr As DataRow
            'For i As Integer = 0 To 10
            '    dr = ds.Tables(tableDB).NewRow()
            '    dr("藥品名稱") = "afdfdasdfdfdfgfdsdfdsdfdgdsfgfdgfdgfdsgfd"
            '    dr("每次量/總量") = (i + 1).ToString
            '    dr("單位") = "TAB"
            '    dr("頻次") = "TID"
            '    dr("途徑") = "ORAL"
            '    dr("天數") = "2"
            '    dr("次數") = "1"
            '    ds.Tables(tableDB).Rows.Add(dr)
            'Next
            '*************
            initDgvShowData()

            If Not IsNothing(ds) Then
                initGridData(ds)
            End If
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    ''' <summary>
    ''' 熱鍵
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub UCLDrugPackageDtlUI_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.F10
                '清除
                btnOK_Click(sender, e)
            Case Keys.Enter
                Me.ProcessTabKey(True)
        End Select
    End Sub

    ''' <summary>
    ''' 完成
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Try
            Dim dt As DataTable = ds.Tables(tableDB).Clone

            If dgvShowData.Rows.Count >= 0 Then

                For i As Integer = 0 To dgvShowData.Rows.Count - 1

                    If dgvShowData.Rows(i).Cells(0).Value = True Then

                        dt.ImportRow(CType(ds.Tables(tableDB).Rows(i), DataRow))

                    End If

                Next

            End If

            ds.Tables.Clear()

            ds.Tables.Add(dt.Copy)
            blnISClose = False
            Me.Close()


        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    Private Sub UCLDrugPackageDtlUI_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        If blnISClose Then
            ds.Tables(0).Rows.Clear()
        End If

    End Sub

    Private Sub dgvShowData_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvShowData.CellClick
        Try
            If e.RowIndex > -1 AndAlso e.ColumnIndex > 0 Then
                Dim value = dgvShowData.Rows(e.RowIndex).Cells(0).Value
                If value = True Then
                    dgvShowData.Rows(e.RowIndex).Cells(0).Value = False
                Else
                    dgvShowData.Rows(e.RowIndex).Cells(0).Value = True
                End If
            End If


        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)

        End Try
    End Sub
End Class