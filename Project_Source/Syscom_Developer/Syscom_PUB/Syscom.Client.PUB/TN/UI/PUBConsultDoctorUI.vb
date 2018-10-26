Imports Com.Syscom.WinFormsUI.Docking
Imports Syscom.Client.Servicefactory
Imports Syscom.Client.UCL
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
Imports Syscom.Client.CMM
Imports System.Text

'Imports nckuh.server.pub

Public Class PUBConsultDoctorUI


    '============================
    '程式說明：續接條件
    '修改日期：2009.11.30
    '修改日期：2009.11.30
    '開發人員：Jen
    '============================

   
    Public Sub New(ByVal initValueData As String)

        ValueData = initValueData

        ' 此為 Windows Form 設計工具所需的呼叫。
        InitializeComponent()

        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。

    End Sub

#Region "########## 宣告物件 ##########"


    Dim pub As IPubServiceManager = Nothing 'WCF
    'Dim pub As PUBDelegate = PUBDelegate.getInstance

    Dim ErrorKeyFlag As Boolean = False

    Dim ComboBoxColumn() As String = {"Code_Id", "Code_Name"}
    Dim ComboBoxColumnType() As Integer = {DataSetUtil.TypeString, DataSetUtil.TypeString}

    Dim DoctorColumn() As String = {"醫師代碼", "科別", "姓名", "員工編號"}
    Dim DoctorColumnType() As Integer = {DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString}

    Dim confirmFlag As Boolean = False

    Private valueDataStr As String = ""

    Public Property ValueData() As String
        Get
            Return valueDataStr
        End Get
        Set(ByVal value As String)
            valueDataStr = value
        End Set
    End Property

#End Region

#Region "########## 啟動載入 ##########"

    Private Sub PUBConsultDoctorUI_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        loadPubServiceManager()

        Me.KeyPreview = True

        ucl_txt_drname.Enabled = False
        ucl_txt_dept.Enabled = False
        ucl_txt_employeecode.Enabled = False


        '-------------------------------
        'textCodeQuer設定
        ucl_tcq_doctor.uclIsShowMsgBox = False
        ucl_tcq_doctor.uclIsTextAutoClear = False
        ucl_tcq_doctor.uclIsReturnDS = True
        '-------------------------------

        ucl_tcq_doctor.Focus()


        ''init first Grid資料
        ''----------------------------------------------
        Dim doctorDS As DataSet = New DataSet
        Dim doctorDT As DataTable = DataSetUtil.GenDataTable("doctor", Nothing, DoctorColumn, DoctorColumnType)

        '轉置資料到grid
        'ValueData parse成醫生

        If ValueData IsNot Nothing AndAlso ValueData.Length > 0 Then
            Dim splitDrValueData() As String = ValueData.Split(",")

            If splitDrValueData IsNot Nothing AndAlso splitDrValueData.Length > 0 Then

                Dim stayDrDT As DataTable = pub.queryRuleDoctorByEmployeeCodes(splitDrValueData)
                'd.Doctor_Code, e.Employee_Name, d.Dept_Code, dept.Dept_Name, d.Employee_Code  
                If DataSetUtil.IsContainsData(stayDrDT) Then
                    Dim empHash As New Hashtable

                    For Each dr As DataRow In stayDrDT.Rows
                        If Not IsDBNull(dr.Item("Employee_Code")) Then
                            Dim empCode As String = CType(dr.Item("Employee_Code"), String).Trim
                            If Not empHash.ContainsKey(empCode) Then
                                empHash.Add(empCode, dr)
                            End If
                        End If
                    Next

                    'splitDrValueData >> grid
                    'DoctorColumn() As String = {"醫師代碼", "科別", "姓名", "員工編號"}
                    'd.Doctor_Code, e.Employee_Name, d.Dept_Code, dept.Dept_Name, d.Employee_Code  ")
                    For i As Integer = 0 To (splitDrValueData.Length - 1)
                        Dim splitinfo As String = splitDrValueData(i).Trim
                        If empHash.ContainsKey(splitinfo) Then
                            Dim dr As DataRow = CType(empHash.Item(splitinfo), DataRow)
                            Dim drdr As DataRow = doctorDT.NewRow
                            If Not IsDBNull(dr.Item("Doctor_Code")) Then
                                drdr.Item(DoctorColumn(0)) = CType(dr.Item("Doctor_Code"), String).Trim
                            End If
                            If Not IsDBNull(dr.Item("Dept_Name")) Then
                                drdr.Item(DoctorColumn(1)) = CType(dr.Item("Dept_Name"), String).Trim
                            End If
                            If Not IsDBNull(dr.Item("Employee_Name")) Then
                                drdr.Item(DoctorColumn(2)) = CType(dr.Item("Employee_Name"), String).Trim
                            End If
                            If Not IsDBNull(dr.Item("Employee_Code")) Then
                                drdr.Item(DoctorColumn(3)) = CType(dr.Item("Employee_Code"), String).Trim
                            End If

                            doctorDT.Rows.Add(drdr)
                        End If
                    Next
                End If
            End If
        End If

        '"檢查類別", "檢查項目", "值域", '"條件關係"}

        ucl_dgv_doctor.uclHeaderText = UCLDataGridViewUC.convertColumnToHeader(DoctorColumn)
        ucl_dgv_doctor.uclColumnWidth = "110,110,110,110"
        ucl_dgv_doctor.uclColumnAlignment = "0"
        'ucl_dgv_checkcond.uclNonVisibleColIndex = "13,14,15,16,17"

        doctorDS.Tables.Add(doctorDT)

        'Hash版
        Dim _hashTable As Hashtable = New Hashtable
        _hashTable.Add(-1, doctorDS)

        ucl_dgv_doctor.Initial(_hashTable)

        'ucl_dgv_doctor.AddNewRow()
        '---------------------------------------------


    End Sub

#End Region

#Region "########## 共用函式 ##########"

    ''' <summary>
    ''' 取得clientservice
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub loadPubServiceManager()
        Try
            pub = PubServiceManager.getInstance
        Catch ex As Exception
            'MessageHandling.showInfoByKey("CMMCMMB001")
            MessageHandling.showWarnMsg("CMMCMMB001", New String() {})
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' 欄位檢查
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function checkColumn() As Boolean
        Dim comp As Object = Nothing
        Dim allPass As Boolean = True


        If allPass Then
            cleanFieldsColor()
        Else
            ErrorKeyFlag = True
            comp.Focus()
        End If

        Return allPass
    End Function



    ''' <summary>
    ''' 先將需要檢查欄位的back color設為default
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub cleanFieldsColor()
        Try
            '先將需要檢查欄位的back color設為default
            'UclComboBoxUILender.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
            'UclComboBoxUILendType.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
            'UclComboBoxUILendReason.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
            'UclComboBoxUILendDept.BackColor = ScreenUtil.BACK_COLOR_DEFAULT

            ErrorKeyFlag = False
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '----------------------------------------------------------------------------
    '用對話視窗方式開啟，不執行資料庫動作(存DataSet)
    '----------------------------------------------------------------------------
    ''' <summary>
    ''' 用dialog方式開啟,有確認= true
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ShowAndPrepareReturnData() As Boolean

        Me.ShowDialog()

        Return confirmFlag

    End Function

    Private Sub addDoctor()
        'if checked
        'ucl_tcq_doctor.Text = CType(ds.Tables(0).Rows(0).Item(0), String).Trim
        'ucl_txt_drname.Text = CType(ds.Tables(0).Rows(0).Item(1), String).Trim
        'ucl_txt_dept.Text = CType(ds.Tables(0).Rows(0).Item(2), String).Trim
        'ucl_txt_employeecode.Text = CType(ds.Tables(0).Rows(0).Item(3), String).Trim

        'DoctorColumn() As String = {"醫師代碼", "科別", "姓名", "員工編號"}
        If ucl_tcq_doctor.Text.Trim.Length > 0 AndAlso ucl_txt_drname.Text.Trim.Length > 0 AndAlso ucl_txt_dept.Text.Trim.Length > 0 AndAlso ucl_txt_employeecode.Text.Trim.Length > 0 Then
            Dim drds As DataSet = ucl_dgv_doctor.GetDBDS.Copy
            If DataSetUtil.IsContainsData(drds) Then
                Dim dr As DataRow = drds.Tables("doctor").NewRow
                dr.Item(DoctorColumn(0)) = ucl_tcq_doctor.Text.Trim
                dr.Item(DoctorColumn(1)) = ucl_txt_drname.Text.Trim
                dr.Item(DoctorColumn(2)) = ucl_txt_dept.Text.Trim
                dr.Item(DoctorColumn(3)) = ucl_txt_employeecode.Text.Trim

                drds.Tables(0).Rows.Add(dr)

                ucl_dgv_doctor.Visible = False
                ucl_dgv_doctor.SetDS(drds)
                ucl_dgv_doctor.Visible = True
            Else
                drds = New DataSet
                Dim drdt As DataTable = DataSetUtil.GenDataTable("doctor", Nothing, DoctorColumn, DoctorColumnType)
                Dim dr As DataRow = drdt.NewRow
                dr.Item(DoctorColumn(0)) = ucl_tcq_doctor.Text.Trim
                dr.Item(DoctorColumn(1)) = ucl_txt_drname.Text.Trim
                dr.Item(DoctorColumn(2)) = ucl_txt_dept.Text.Trim
                dr.Item(DoctorColumn(3)) = ucl_txt_employeecode.Text.Trim

                drdt.Rows.Add(dr)

                drds.Tables.Add(drdt)

                ucl_dgv_doctor.Visible = False
                ucl_dgv_doctor.SetDS(drds)
                ucl_dgv_doctor.Visible = True
            End If
        Else
            MessageHandling.showErrorMsg("HEMCMMC021", New String() {"醫師資料欄位"}, "")
            ucl_tcq_doctor.Focus()
        End If



    End Sub

    Private Function confirm() As Boolean

        Dim drStr As StringBuilder = New StringBuilder
        Dim drds As DataSet = ucl_dgv_doctor.GetDBDS

        If DataSetUtil.IsContainsData(drds) Then
            For Each dr As DataRow In drds.Tables("doctor").Rows
                If Not IsDBNull(dr.Item(DoctorColumn(3))) Then
                    drStr.Append(CType(dr.Item(DoctorColumn(3)), String).Trim).Append(",")
                End If
            Next
        End If

        If drStr.Length > 0 Then
            drStr.Remove(drStr.Length - 1, 1)
        End If

        ValueData = drStr.ToString

        confirmFlag = True
        Me.Dispose()

    End Function

    Private Sub clear()
        ucl_tcq_doctor.Text = ""
        ucl_txt_drname.Text = ""
        ucl_txt_dept.Text = ""
        ucl_txt_employeecode.Text = ""

        ucl_dgv_doctor.ClearDS()

        ucl_tcq_doctor.Focus()
    End Sub

#End Region

#Region "########## 觸發事件 ##########"

    ''' <summary>
    ''' HotKey運作
    ''' Enter:載入ㄧ筆ChartNo
    ''' </summary>
    ''' <remarks></remarks>''' 
    Private Sub PUBConsultDoctorUI_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode
            Case Keys.F5
                clear()
            Case Keys.F12
                confirm()
        End Select
        
    End Sub

    ''' <summary>
    ''' 確認
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn_confirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_confirm.Click
        confirm()
    End Sub

    
    ''' <summary>
    ''' 加入醫師
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn_add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_add.Click
        addDoctor()
    End Sub

    Private Sub btn_clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_clear.Click
        clear()
    End Sub

    '------------------------------------------------------------------------------------------
    '離開TextCodeQuery後查出資料? 查出後動作
    '------------------------------------------------------------------------------------------

    Dim WithEvents pvtReceiveMgr As EventManager = EventManager.getInstance '宣告EventManager
    Dim mainDS, mainDS2 As New DataSet

    'Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    UclTextCodeQueryUI1.uclQueryValue = "ER"
    'End Sub

    Private Sub doUcrOpenWindowValue2(ByVal uclName As String, ByVal ds As DataSet) Handles pvtReceiveMgr.UclOpenWindowValue2

        If uclName IsNot Nothing AndAlso uclName.Equals("PUBConsultDoctorUIucl_tcq_doctor") Then
            If DataSetUtil.IsContainsData(ds) Then
                '確實有醫令,才查詢
                ucl_tcq_doctor.Text = CType(ds.Tables(0).Rows(0).Item(0), String).Trim
                ucl_txt_drname.Text = CType(ds.Tables(0).Rows(0).Item(1), String).Trim
                ucl_txt_dept.Text = CType(ds.Tables(0).Rows(0).Item(2), String).Trim
                ucl_txt_employeecode.Text = CType(ds.Tables(0).Rows(0).Item(3), String).Trim
                'query(False)
            Else
                '不動作
            End If
        End If

    End Sub

    '------------------------------------------------------------------------------------------
    'TextCodeQuery 結束
    '------------------------------------------------------------------------------------------


#End Region




End Class