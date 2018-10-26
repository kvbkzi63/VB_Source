 
Imports System.Text
Imports Syscom.Client.CMM
Imports Syscom.Client.CMM.MessageHandling


Public Class UCLChartNoOpenWindowUC

#Region "全域變數宣告"


    Dim WithEvents mgrChartNo As EventManager = EventManager.getInstance '宣告EventManager

    Dim columnNameGrid() As String = {"病歷號", "姓名", "x", "身分證字號", "合併病歷號"}
    Dim nameStr As String = ""
    Dim UIName As String = ""

    Dim pvtDS As DataSet
    Dim InputType As UCLChartNoUC.uclTextTypeData
    Dim IsShowTelHome As Boolean = False
    Dim IsShowAddress As Boolean = False
    Dim IsCanSelectReserveChartNoForMultiChartNo As Boolean = True

#End Region

#Region "20090418 add by James ,共用元件 病歷號挑選視窗"


    Sub New()
        ' 此為 Windows Form 設計工具所需的呼叫。
        InitializeComponent()
    End Sub

    ''' <summary>
    ''' 初始化設定
    ''' ds:病患資料
    ''' ctlName:元件名稱
    ''' </summary>
    ''' <remarks></remarks>''' 
    Sub New(ByVal ds As DataSet, ByVal ctlName As String, ByVal Type As UCLChartNoUC.uclTextTypeData, Optional ByVal IsShowTelHome As Boolean = False, Optional ByVal IsShowAddress As Boolean = False)

        Try

            InitializeComponent()
            nameStr = ctlName
            pvtDS = ds
            dgvDataView.DataSource = pvtDS.Tables(0)


            InputType = Type
            Me.IsShowTelHome = IsShowTelHome
            Me.IsShowAddress = IsShowAddress

            setShowColumn()

            '     setGridColumnName()

        Catch ex As Exception
            Console.WriteLine(ex.ToString)   'nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    ''' <summary>
    ''' 初始化設定
    ''' ds:病患資料
    ''' ctlName:元件名稱
    ''' </summary>
    ''' <remarks></remarks>''' 
    Sub New(ByVal ds As DataSet, ByVal UIName As String, ByVal ctlName As String, ByVal Type As UCLChartNoUC.uclTextTypeData, Optional ByVal IsShowTelHome As Boolean = False, Optional ByVal IsShowAddress As Boolean = False)

        Try

            InitializeComponent()
            nameStr = ctlName
            pvtDS = ds
            dgvDataView.DataSource = pvtDS.Tables(0)
            Me.UIName = UIName

            InputType = Type
            Me.IsShowTelHome = IsShowTelHome
            Me.IsShowAddress = IsShowAddress

            setShowColumn()

            '     setGridColumnName()

        Catch ex As Exception
            Console.WriteLine(ex.ToString)   'nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub



    Public Sub SetIsCanSelectReserveChartNoForMultiChartNo(ByVal Is_CanSelectReserveChartNoForMultiChartNo As Boolean)
        IsCanSelectReserveChartNoForMultiChartNo = Is_CanSelectReserveChartNoForMultiChartNo
    End Sub

    ''' <summary>
    ''' 設定要顯示的病患基本資料欄位
    ''' </summary>
    Private Sub setShowColumn()

        Try
            For i As Integer = 0 To dgvDataView.Columns.Count - 1
                dgvDataView.Columns(i).Visible = False

            Next

            dgvDataView.Columns("Chart_No").Visible = True
            dgvDataView.Columns("Chart_No").HeaderText = "病歷號"

            dgvDataView.Columns("Patient_Name").Visible = True
            dgvDataView.Columns("Patient_Name").HeaderText = "姓名"

            dgvDataView.Columns("Idno").Visible = True
            dgvDataView.Columns("Idno").HeaderText = "身分證字號"


            dgvDataView.Columns("Birth_Date").Visible = True
            dgvDataView.Columns("Birth_Date").HeaderText = "生日"

            Try
                If IsShowTelHome Then
                    dgvDataView.Columns("Tel_Home").Visible = True
                    dgvDataView.Columns("Tel_Home").HeaderText = "電話(家)"
                End If

                If IsShowAddress Then
                    dgvDataView.Columns("Address").Visible = True
                    dgvDataView.Columns("Address").HeaderText = "地址"
                End If

            Catch ex As Exception

            End Try

            If InputType = UCLChartNoUC.uclTextTypeData.PatientName Then
                'dgvDataView.Columns("Reserve_Chart_No").Visible = False
                'dgvDataView.Columns("Reserve_Chart_No").HeaderText = "合併病歷號"
            Else
                dgvDataView.Columns("Reserve_Chart_No").Visible = True
                dgvDataView.Columns("Reserve_Chart_No").HeaderText = "合併病歷號"

            End If

        Catch ex As Exception
            Console.WriteLine(ex.ToString)   'nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    ''' <summary>
    ''' 設定欄位名稱
    ''' </summary>
    Private Sub setGridColumnName()

        Try
            '將欄位名稱改成中文
            For i As Integer = 0 To columnNameGrid.Length - 1
                dgvDataView.Columns(i).HeaderText = columnNameGrid(i)
            Next

        Catch ex As Exception
            Console.WriteLine(ex.ToString)   'nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try

    End Sub


#Region "Event"

    Private Sub dgvDataView_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDataView.CellDoubleClick
        Try


            '啟動EventManager的RaiseEvent
            Dim chartNo As String = dgvDataView.SelectedRows(0).Cells(0).Value.ToString().Trim()

            If dgvDataView.SelectedRows(0).Cells("Reserve_Chart_No").Value IsNot DBNull.Value AndAlso dgvDataView.SelectedRows(0).Cells("Reserve_Chart_No").Value.ToString.Trim <> "" AndAlso Not IsCanSelectReserveChartNoForMultiChartNo Then
                MessageBox.Show("此病歷號已被合併，不可選擇！")
                Exit Sub
            Else
                Me.Visible = False
            End If

            If mgrChartNo Is Nothing Then
                mgrChartNo = CMM.EventManager.getInstance
            End If
            mgrChartNo.RaiseUclOpenChartNoWindow(nameStr, chartNo)
            mgrChartNo.RaiseUclOpenChartNoWindowNew(UIName, nameStr, chartNo)
            Me.Close()
        Catch ex As Exception
            Console.WriteLine(ex.ToString)   'nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub


#End Region

#End Region


    Private Sub UCLChartNoOpenWindowUI_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode

            Case Keys.F5
                Me.Close()

        End Select

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class
