Imports Syscom.Comm.EXP
Imports Syscom.Comm.Utility
Imports Syscom.Comm.Utility.StringUtil
Imports Syscom.Client.CMM
Imports Syscom.Client.CMM.MessageHandling
Imports Syscom.Client.Servicefactory
Imports Syscom.Client.UCL
Imports Syscom.Client.UCL.UCLScreenUtil
Imports System.Windows.Forms
Imports System.Drawing
Imports Syscom.Comm.TableFactory
'============================
'程式說明：共用元件-病歷號,身分證號
'修改日期：2009.04.13
'開發人員：James
'============================

#Region "20090420 add by James ,共用元件 病歷號查詢"

Public Class UCLChartNoUC


#Region "全域變數宣告"

    Private _uclDigitCount As Integer = 8 '預設為病歷號碼長度  可設定uclTextType  設定成身分證號
    Private _uclTxtBoxWidth As Integer = 60 'textbox寬度

    Dim patientColumnDB() As String = PubPatientDataTableFactory.columnsName

    Dim pvtDS As DataSet
    Private _uclTextType = uclTextTypeData.ChartNo
    Private _uclNeedSql As Boolean = True
    Private _uclReadOnly As Boolean = False
    Private _Text As String
    Private _BackColor As Color = System.Drawing.SystemColors.Window
    Private _ForeColor As Color = Color.Black
    Private _doFlag As Boolean = False
    Private _uclNeedCheckId As Boolean = True
    Private _uclNeedCheckIdByPubBP As Boolean = True
    Private _uclIsInteractionChartNo As Boolean = True
    Private _uclIsAutoAppendP As Boolean = True
    Private _uclIsDoReserveChartNo As Boolean = True
    Private _uclIsShowReserveChartNoQuestionMsg As Boolean = False
    Private _uclIsShowReserveChartNoMsg As Boolean = True
    Private _uclIsCanSelectReserveChartNoForMultiChartNo As Boolean = True '多個病歷號時,是否顯示最新的病歷號 (含被合併的)
    Private _uclIsNameInputAutoPopWindow As Boolean = False

    Dim ucl As IUclServiceManager = UclServiceManager.getInstance
    Dim pub As IPubServiceManager = PubServiceManager.getInstance

    'Public mgrChartNo As EventManager = EventManager.getInstance   '宣告EventManager
    'Dim WithEvents pvtReceiveChartNoMgr As EventManager = EventManager.getInstance
    'Dim uclPBD As UCLPatientBasicDataUI

    Public inputType As uclTextTypeData = uclTextTypeData.IdNo
    Public hasBasicData As Boolean = False



    Private PatientReady As Boolean = False
    Public Shadows Event TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Public Shadows Event KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)

    Dim pat As UCLPatientData = UCLPatientData.getInstance

    Dim pat2 As UCLPatientData = New UCLPatientData

    Dim pat3 As UCLPatientData

    Public Event QueryCompleted(ByVal sender As System.Object, ByVal value As Boolean)
    Dim CheckIdNoBP As New CheckIdNoBP
    Private _IsShowTelHome As Boolean = False
    Private _IsShowAddress As Boolean = False
    Private _IsAutoAddZero As Boolean = False

#End Region

#Region "屬性設定"

    ''' <summary>
    ''' Patient 屬性
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum PatientData_Item
        Chart_No
        Patient_Name
        Patient_En_Name
        Patient_Short_Name
        Idno_Type_Id
        Idno
        Birth_Date
        Sex_Id
        Blood_Type_Id
        Education_Id
        Marriage_Id
        Job_Id
        Nationality_Id
        Race_Id
        Area_Code
        Register_Postal_Code
        Register_Address
        Postal_Code
        Address
        Tel_Home
        Tel_Office
        Tel_Mobile
        Fax
        Email
        Postal_Code2
        Address2
        Tel2
        Tel2_Mobile
        Email2
        First_Visit_Date
        Latest_Visit_Date
        Latest_Admission_Date
        Latest_Discharge_Date
        Ipd_Times
        Latest_Xray_Date
        Latest_CT_Date
        Arrears_Times
        Opd_Arrears_Amt
        Emg_Arrears_Amt
        Ipd_Arrears_Amt
        Measure_Time
        Latest_Height
        Latest_Weight
        Mis_Register_Date1
        Mis_Register_Date2
        Mis_Register_Date3
        Mis_Register_Times
        Mis_Register_End_Date
        Is_Death
        Death_Date
        Is_Chart_Divide
        Is_Chart_Image
        Patient_Memo
        Is_Employee
        Create_User
        Create_Time
        Modified_User
        Modified_Time
        Reserve_Chart_No
        Latest_LMP_Date
        LIS_Blood_Report
        LIS_Blood_Report_Time
        LIS_BMT_Mark
        LIS_MBT_Product_Limit
        Studentid
        Is_IPD
        Is_EMG
        Reg_Notify_Id
        Register_Dist_Code
        Register_Vil_Code
        Dist_Code
        Vil_Code
        Dist_Code2
        Vil_Code2
    End Enum

    ''' <summary>
    ''' 資料類型(病歷號,身分證號,姓名)
    ''' </summary>
    ''' <remarks></remarks>
    Enum uclTextTypeData

        ChartNo                        '病歷號 
        IdNo                            '身分證號 
        PatientName                     '姓名
    End Enum

    ''' <summary>
    ''' 是否自動補0  (預設False)
    ''' </summary>
    ''' <returns>Boolean</returns>
    ''' <remarks></remarks>
    Public Property IsAutoAddZero() As Boolean
        Get
            Return _IsAutoAddZero
        End Get
        Set(ByVal value As Boolean)
            _IsAutoAddZero = value
        End Set
    End Property

    ''' <summary>
    ''' 是否顯示地址
    ''' </summary>
    ''' <returns>Boolean</returns>
    ''' <remarks></remarks>
    Public Property IsShowAddress() As Boolean
        Get
            Return _IsShowAddress
        End Get
        Set(ByVal value As Boolean)
            _IsShowAddress = value
        End Set
    End Property

    ''' <summary>
    ''' 是否顯示電話
    ''' </summary>
    ''' <returns>Boolean</returns>
    ''' <remarks></remarks>
    Public Property IsShowTelHome() As Boolean
        Get
            Return _IsShowTelHome
        End Get
        Set(ByVal value As Boolean)
            _IsShowTelHome = value
        End Set
    End Property

    ''' <summary>
    ''' Value 變更註記
    ''' </summary>
    ''' <value></value>
    ''' <returns>Boolean</returns>
    ''' <remarks></remarks>
    Public Property doFlag() As Boolean
        Get
            Return _doFlag
        End Get
        Set(ByVal value As Boolean)
            _doFlag = value
        End Set
    End Property

    ''' <summary>
    ''' 自動跳出輸入姓名Window
    ''' </summary>
    ''' <value></value>
    ''' <returns>Boolean</returns>
    ''' <remarks></remarks>
    Public Property uclIsNameInputAutoPopWindow() As Boolean
        Get
            Return _uclIsNameInputAutoPopWindow
        End Get
        Set(ByVal value As Boolean)
            _uclIsNameInputAutoPopWindow = value
        End Set
    End Property
    ''' <summary>
    ''' 多病歷號的時候顯示最新的
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Public Property uclIsCanSelectReserveChartNoForMultiChartNo() As Boolean
        Get
            Return _uclIsCanSelectReserveChartNoForMultiChartNo
        End Get
        Set(ByVal value As Boolean)
            _uclIsCanSelectReserveChartNoForMultiChartNo = value
        End Set
    End Property

    ''' <summary>
    ''' 是否詢問合併病歷號 
    ''' </summary>
    ''' <returns>Boolean</returns>
    ''' <remarks></remarks>
    Public Property uclIsShowReserveChartNoQuestionMsg() As Boolean
        Get
            Return _uclIsShowReserveChartNoQuestionMsg
        End Get
        Set(ByVal value As Boolean)
            _uclIsShowReserveChartNoQuestionMsg = value
        End Set
    End Property

    ''' <summary>
    ''' 是否顯示合併病歷號訊息
    ''' </summary>
    ''' <returns>Boolean</returns>
    ''' <remarks></remarks>
    Public Property uclIsShowReserveChartNoMsg() As Boolean
        Get
            Return _uclIsShowReserveChartNoMsg
        End Get
        Set(ByVal value As Boolean)
            _uclIsShowReserveChartNoMsg = value
        End Set
    End Property

    ''' <summary>
    ''' 是否進行合併病歷號動作
    ''' </summary>
    ''' <returns>Boolean</returns>
    ''' <remarks></remarks>
    Public Property uclIsDoReserveChartNo() As Boolean
        Get
            Return _uclIsDoReserveChartNo
        End Get
        Set(ByVal value As Boolean)
            _uclIsDoReserveChartNo = value
        End Set
    End Property

    ''' <summary>
    ''' 是否共用其他病歷號元件資料
    ''' </summary>
    ''' <returns>Boolean</returns>
    ''' <remarks></remarks>
    Public Property uclIsInteractionChartNo() As Boolean
        Get
            Return _uclIsInteractionChartNo
        End Get
        Set(ByVal value As Boolean)
            _uclIsInteractionChartNo = value
        End Set
    End Property

    ''' <summary>
    ''' 身分證是否自動補P
    ''' </summary>
    ''' <returns>Boolean</returns>
    ''' <remarks></remarks>
    Public Property uclIsAutoAppendP() As Boolean
        Get
            Return _uclIsAutoAppendP
        End Get
        Set(ByVal value As Boolean)
            _uclIsAutoAppendP = value
        End Set
    End Property

    ''' <summary>
    ''' 需要檢核身分證
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property uclNeedCheckIdByPubBP() As Boolean
        Get
            Return _uclNeedCheckIdByPubBP
        End Get
        Set(ByVal value As Boolean)
            _uclNeedCheckIdByPubBP = value
        End Set
    End Property

    ''' <summary>
    ''' 檢驗身分證號
    ''' </summary>
    ''' <returns>Boolean</returns>
    ''' <remarks></remarks>
    Public Property uclNeedCheckId() As Boolean
        Get
            Return _uclNeedCheckId
        End Get
        Set(ByVal value As Boolean)
            _uclNeedCheckId = value
        End Set
    End Property


    Public Overrides Property BackColor() As Color
        Get
            Return MaskedTextBox1.BackColor
        End Get
        Set(ByVal value As Color)
            MaskedTextBox1.BackColor = value
        End Set
    End Property

    Public Overrides Property ForeColor() As Color
        Get
            Return MaskedTextBox1.ForeColor
        End Get
        Set(ByVal value As Color)
            MaskedTextBox1.ForeColor = value
        End Set
    End Property

    Public Overrides Property Text() As String
        Get
            Return MaskedTextBox1.Text
        End Get
        Set(ByVal value As String)
            MaskedTextBox1.Text = value
        End Set
    End Property

    ''' <summary>
    ''' 是否唯讀
    ''' </summary>
    ''' <returns>Boolean</returns>
    ''' <remarks></remarks>
    Public Property uclReadOnly() As Boolean
        Get
            Return MaskedTextBox1.ReadOnly
        End Get
        Set(ByVal value As Boolean)
            MaskedTextBox1.ReadOnly = value
        End Set
    End Property

    Public Property uclNeedSql() As Boolean
        Get
            Return _uclNeedSql
        End Get
        Set(ByVal value As Boolean)
            _uclNeedSql = value
        End Set
    End Property


    Public Property uclTextType() As uclTextTypeData
        Get
            Return _uclTextType
        End Get
        Set(ByVal value As uclTextTypeData)
            _uclTextType = value
        End Set
    End Property


    Public Property uclDigitCount() As Integer
        Get

            Return _uclDigitCount
        End Get
        Set(ByVal value As Integer)
            _uclDigitCount = value

        End Set
    End Property

    Public Property uclTxtBoxWidth() As Integer
        Get
            _uclTxtBoxWidth = MaskedTextBox1.Width
            Return _uclTxtBoxWidth
        End Get
        Set(ByVal value As Integer)
            _uclTxtBoxWidth = value
            MaskedTextBox1.Width = _uclTxtBoxWidth

        End Set
    End Property


#End Region

#Region "外部函數"
    Sub New()

        ' 此為 Windows Form 設計工具所需的呼叫。
        InitializeComponent()

    End Sub

    ''' <summary>
    ''' 設定共用病患資料
    ''' </summary>
    ''' <remarks></remarks>''' 
    Public Sub SetCommonPatientData(ByRef CommonPatientData As UCLPatientData)
        pat3 = CommonPatientData
    End Sub

    ''' <summary>
    ''' 進行病患查詢
    ''' code:查詢的病歷號代碼  
    ''' </summary>
    ''' <returns>有找到 True , 沒找到 False</returns>
    ''' <remarks></remarks>''' 
    Public Function QueryPatientByKey(ByVal code As String) As Boolean

        Dim IsFound As Boolean = False
        PatientReady = False
        If Not doFlag Then
            Exit Function
        End If

        Try
            Dim reChartNo As String = ""
            code.Replace("'", "''")
            pvtDS = ucl.queryUclChartNoByKey(code, getInputType(uclTextTypeData.ChartNo))

            If pvtDS.Tables(0).Rows.Count > 0 Then

                IsFound = True
                pat.SetDB(pvtDS.Copy)
                pat2.SetDB(pvtDS.Copy)
                If pat3 IsNot Nothing Then
                    pat3.SetDB(pvtDS.Copy)
                End If

                QueryAdditionPatData(code)
                PatientReady = True
                Dim msg As String


                If pat3 IsNot Nothing Then
                    reChartNo = pat3.Reserve_Chart_No
                Else
                    If uclIsInteractionChartNo Then
                        reChartNo = pat.Reserve_Chart_No  'getPatientData(PatientData_Item.Reserve_Chart_No).Trim()
                    Else
                        reChartNo = pat2.Reserve_Chart_No  'getPatientData(PatientData_Item.Reserve_Chart_No).Trim()
                    End If
                End If


                If reChartNo.Length > 0 AndAlso uclIsDoReserveChartNo Then

                    If uclIsShowReserveChartNoQuestionMsg Then
                        msg = "此病歷號已經合併，合併後的病歷號是 " & reChartNo & "，是否直接帶入查詢？"
                        If MsgBox(msg, MsgBoxStyle.YesNo, "訊息") = MsgBoxResult.Yes Then
                            '  MessageBox.Show(reChartNo)

                            QueryPatientByKey(reChartNo)
                            If _uclTextType = uclTextTypeData.ChartNo Then
                                If pat3 IsNot Nothing Then
                                    MaskedTextBox1.Text = pat3.Chart_No.Trim()
                                Else
                                    If uclIsInteractionChartNo Then
                                        MaskedTextBox1.Text = pat.Chart_No.Trim()
                                    Else
                                        MaskedTextBox1.Text = pat2.Chart_No.Trim()
                                    End If
                                End If

                            End If

                            '  Console.WriteLine(getPatientData(PatientData_Item.Chart_No).Trim())
                            ' Console.WriteLine(getPatientData(PatientData_Item.Patient_Name).Trim())
                        Else
                            ' MessageBox.Show("no merge")
                            '20121109 : disable focus , kevin ou
                            'MaskedTextBox1.Focus()
                            'MaskedTextBox1.SelectionStart = MaskedTextBox1.Text.Length
                        End If
                    Else
                        '不顯示詢問Msg ,直接進行合併
                        QueryPatientByKey(reChartNo)
                        If _uclTextType = uclTextTypeData.ChartNo Then
                            If pat3 IsNot Nothing Then
                                MaskedTextBox1.Text = pat3.Chart_No.Trim()
                            Else
                                If uclIsInteractionChartNo Then
                                    MaskedTextBox1.Text = pat.Chart_No.Trim()
                                Else
                                    MaskedTextBox1.Text = pat2.Chart_No.Trim()
                                End If
                            End If

                        End If
                        If uclIsShowReserveChartNoMsg Then
                            'MessageBox.Show("此病歷號已經合併，合併後的病歷號是 " & reChartNo)
                            MessageHandling.ShowWarnMsg("CMMCMMB300", New String() {"此病歷號已經合併，合併後的病歷號是 " & reChartNo})
                        End If

                    End If


                ElseIf 1 = 2 AndAlso reChartNo.Length > 0 AndAlso Not uclIsDoReserveChartNo Then
                    '20121109 : 修改訊息
                    'msg = "此病歷號已經被合併，合併後的病歷號是 " & reChartNo & "，是：直接帶入查詢 ； 否：以被合併之病歷號查詢"
                    msg = "此病歷號已經被合併，合併後的病歷號是 " & reChartNo & "，是：以被合併之病歷號查詢 ； 否：直接帶入查詢"
                    If MsgBox(msg, MsgBoxStyle.YesNo, "訊息") = MsgBoxResult.Yes Then
                        '  MessageBox.Show(reChartNo)

                        QueryPatientByKey(reChartNo)
                        If _uclTextType = uclTextTypeData.ChartNo Then
                            If pat3 IsNot Nothing Then
                                MaskedTextBox1.Text = pat3.Chart_No.Trim()
                            Else
                                If uclIsInteractionChartNo Then
                                    MaskedTextBox1.Text = pat.Chart_No.Trim()
                                Else
                                    MaskedTextBox1.Text = pat2.Chart_No.Trim()
                                End If
                            End If


                        End If

                    End If

                End If

                RaiseEvent QueryCompleted(Me, True)
            Else

                IsFound = False
                ' Dim s(0) As String
                pat.Clear()
                pat2.Clear()
                If pat3 IsNot Nothing Then
                    pat3.Clear()
                End If
                MaskedTextBox1.Clear()
                RaiseEvent QueryCompleted(Me, False)
                'MessageBox.Show("無此病患基本資料")
                MessageHandling.ShowWarnMsg("CMMCMMB300", New String() {"無此病患基本資料！"})
                ' SetTextBoxFocused()
                PatientReady = False

                ' MessageHandling.show(
                '  MessageHandling.showInfo(ResourceUtil.getString("PUBCMMB002"))
                '  MessageHandling.showQuestionByKey(ResourceUtil.getString("PUBCMMB001", s))

            End If

            ' doFlag = False  讓外面去操作
            _uclTextType = inputType

            Return IsFound
        Catch ex As Exception
            Console.WriteLine(ex.ToString)   'nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try
    End Function

    ''' <summary>
    ''' 清除病人資料
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ClearPatientData()

        If pat3 IsNot Nothing Then
            pat3.Clear()
            MaskedTextBox1.Clear()
            PatientReady = False
        Else
            If uclIsInteractionChartNo Then
                pat.Clear()
                MaskedTextBox1.Clear()
                PatientReady = False
            Else
                pat2.Clear()
                MaskedTextBox1.Clear()
                PatientReady = False
            End If

        End If

    End Sub

    ''' <summary>
    ''' 是否病人資料已準備
    ''' </summary>
    ''' <returns>Boolean</returns>
    ''' <remarks></remarks>
    Public Function IsPatientReady() As Boolean
        Return PatientReady
    End Function

    ''' <summary>
    ''' 取得病患基本資料物件
    ''' </summary>
    ''' <returns>none</returns>
    ''' <remarks></remarks>''' 
    Public Function GetPatientObj() As UCLPatientData

        If pat3 IsNot Nothing Then
            Return pat3 '部份共用元件
        Else
            If uclIsInteractionChartNo Then
                Return pat '互動元件
            Else
                Return pat2 '獨立元件
            End If
        End If



    End Function



    ''' <summary>
    ''' 清除病患基本資料物件
    ''' </summary>
    ''' <remarks></remarks>''' 
    Public Sub ClearPatientObj()
        If pat3 IsNot Nothing Then
            pat3.Clear()
        Else
            If uclIsInteractionChartNo Then
                pat.Clear()
            Else
                pat2.Clear()
            End If
        End If


    End Sub

    ''' <summary>
    ''' 設定要查詢的代碼
    ''' code:查詢代碼 , Type:查詢的型態 
    ''' </summary>
    ''' <returns>none</returns>
    ''' <remarks></remarks>''' 
    Public Function SetTextToQuery(ByVal code As String, ByVal Type As uclTextTypeData) As Boolean
        Try

            Dim IsFound As Boolean = False

            doFlag = True
            If Type = uclTextTypeData.ChartNo AndAlso code.Trim <> "" Then

                If IsAutoAddZero Then
                    For i As Integer = code.Trim().Length To _uclDigitCount - 1
                        code = "0" & code.Trim()
                    Next
                End If

                inputType = uclTextTypeData.ChartNo
                IsFound = QueryPatientByKey(code)



            ElseIf Type = uclTextTypeData.IdNo AndAlso code.Trim <> "" Then

                inputType = uclTextTypeData.IdNo
                If checkId(code) Then
                    IsFound = idNoInput(code)
                End If

            End If

            MaskedTextBox1.Text = code
            doFlag = False

            Return IsFound

        Catch ex As Exception
            Console.WriteLine(ex.ToString)   'nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try
    End Function

#End Region

#Region "內部函數"

    ''' <summary>
    ''' 身分證輸入
    ''' code:身分證號
    ''' </summary>
    ''' <returns>none</returns>
    ''' <remarks></remarks>''' 
    Private Function idNoInput(ByVal code As String) As Boolean
        Try
            Dim currentForm As Form = Form.ActiveForm
            If currentForm IsNot Nothing AndAlso currentForm.Name.Equals("UCLChartNoOpenWindowUI") Then
                Return True
            End If
            Dim IsFound As Boolean = False
            inputType = _uclTextType
            If _uclNeedSql AndAlso doFlag Then
                Try
                    If code.Trim.Length < 6 Then
                        'MessageBox.Show("身分證號查詢至少輸入前6碼！")
                        MessageHandling.ShowWarnMsg("CMMCMMB300", New String() {"身分證號查詢至少輸入前6碼！"})
                        IsFound = False
                        Return IsFound
                    End If
                Catch ex As Exception

                End Try

                pvtDS = ucl.queryUclChartNoByKey(code, getInputType(uclTextTypeData.IdNo))
                '      MessageBox.Show(pvtDS.Tables(0).Rows.Count.ToString())

                'If Not uclIsCanSelectReserveChartNoForMultiChartNo Then
                '    '不顯示被合併的病歷號
                '    If pvtDS IsNot Nothing AndAlso pvtDS.Tables.Count > 0 Then
                '        For i As Integer = pvtDS.Tables(0).Rows.Count - 1 To 0 Step -1
                '            If pvtDS.Tables(0).Rows(i).Item("Reserve_Chart_No") IsNot DBNull.Value AndAlso pvtDS.Tables(0).Rows(i).Item("Reserve_Chart_No").ToString.Trim <> "" Then
                '                pvtDS.Tables(0).Rows.RemoveAt(i)
                '            End If
                '        Next
                '    End If
                'End If

                If pvtDS.Tables(0).Rows.Count = 1 Then
                    IsFound = QueryPatientByKey(pvtDS.Tables(0).Rows(0).Item("Chart_No").ToString().Trim())

                ElseIf pvtDS.Tables(0).Rows.Count > 1 Then
                    If pvtDS Is Nothing Then
                        pvtDS = ucl.queryUclChartNoByKey(code, getInputType(uclTextTypeData.IdNo))
                    End If

                    Dim chartNoWindow As UCLChartNoOpenWindowUC = New UCLChartNoOpenWindowUC(pvtDS, Me.ParentForm.Name, Me.Name, Me.uclTextType, IsShowTelHome, IsShowAddress)
                    '   pvtAreaList.Location = New Point(MousePosition.X, MousePosition.Y)
                    chartNoWindow.KeyPreview = True
                    chartNoWindow.SetIsCanSelectReserveChartNoForMultiChartNo(uclIsCanSelectReserveChartNoForMultiChartNo)

                    chartNoWindow.ShowDialog()
                    IsFound = True
                ElseIf pvtDS.Tables(0).Rows.Count = 0 Then
                    PatientReady = False
                    pat.Clear()
                    pat2.Clear()
                    If pat3 IsNot Nothing Then
                        pat3.Clear()
                    End If
                    RaiseEvent QueryCompleted(Me, False)
                    'MessageBox.Show("無此病患基本資料")
                    MessageHandling.ShowWarnMsg("CMMCMMB300", New String() {"無此病患基本資料！"})
                    IsFound = False
                End If
            End If
            Return IsFound
        Catch ex As Exception
            Console.WriteLine(ex.ToString)   'nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try
    End Function
    ''' <summary>
    ''' 姓名輸入
    ''' name:姓名
    ''' </summary>
    ''' <returns>none</returns>
    ''' <remarks></remarks>''' 
    Private Function PatientNameInput(ByVal name As String) As Boolean
        Try
            Dim currentForm As Form = Form.ActiveForm
            If currentForm IsNot Nothing AndAlso currentForm.Name.Equals("UCLChartNoOpenWindowUI") Then
                Return True
            End If
            Dim IsFound As Boolean = False
            inputType = _uclTextType
            If _uclNeedSql AndAlso doFlag Then



                pvtDS = ucl.queryUclChartNoByKey(name, getInputType(uclTextTypeData.PatientName))
                '      MessageBox.Show(pvtDS.Tables(0).Rows.Count.ToString())

                'If Not uclIsCanSelectReserveChartNoForMultiChartNo Then
                '    '不顯示被合併的病歷號
                '    If pvtDS IsNot Nothing AndAlso pvtDS.Tables.Count > 0 Then
                '        For i As Integer = pvtDS.Tables(0).Rows.Count - 1 To 0 Step -1
                '            If pvtDS.Tables(0).Rows(i).Item("Reserve_Chart_No") IsNot DBNull.Value AndAlso pvtDS.Tables(0).Rows(i).Item("Reserve_Chart_No").ToString.Trim <> "" Then
                '                pvtDS.Tables(0).Rows.RemoveAt(i)
                '            End If
                '        Next
                '    End If
                'End If

                If pvtDS.Tables(0).Rows.Count = 1 Then


                    If Not uclIsNameInputAutoPopWindow Then
                        IsFound = QueryPatientByKey(pvtDS.Tables(0).Rows(0).Item("Chart_No").ToString().Trim())

                    Else
                        If pvtDS Is Nothing Then
                            pvtDS = ucl.queryUclChartNoByKey(name, getInputType(uclTextTypeData.PatientName))
                        End If

                        Dim chartNoWindow As UCLChartNoOpenWindowUC = New UCLChartNoOpenWindowUC(pvtDS, Me.ParentForm.Name, Me.Name, Me.uclTextType, IsShowTelHome, IsShowAddress)
                        '   pvtAreaList.Location = New Point(MousePosition.X, MousePosition.Y)
                        chartNoWindow.KeyPreview = True
                        chartNoWindow.SetIsCanSelectReserveChartNoForMultiChartNo(uclIsCanSelectReserveChartNoForMultiChartNo)

                        chartNoWindow.ShowDialog()
                        IsFound = True
                    End If


                ElseIf pvtDS.Tables(0).Rows.Count > 1 Then


                    If pvtDS Is Nothing Then
                        pvtDS = ucl.queryUclChartNoByKey(name, getInputType(uclTextTypeData.PatientName))
                    End If

                    Dim chartNoWindow As UCLChartNoOpenWindowUC = New UCLChartNoOpenWindowUC(pvtDS, Me.ParentForm.Name, Me.Name, Me.uclTextType, IsShowTelHome, IsShowAddress)
                    '   pvtAreaList.Location = New Point(MousePosition.X, MousePosition.Y)
                    chartNoWindow.KeyPreview = True
                    chartNoWindow.SetIsCanSelectReserveChartNoForMultiChartNo(uclIsCanSelectReserveChartNoForMultiChartNo)

                    chartNoWindow.ShowDialog()
                    IsFound = True
                ElseIf pvtDS.Tables(0).Rows.Count = 0 Then
                    PatientReady = False
                    pat.Clear()
                    pat2.Clear()
                    If pat3 IsNot Nothing Then
                        pat3.Clear()
                    End If
                    RaiseEvent QueryCompleted(Me, False)
                    'MessageBox.Show("無此病患基本資料")
                    MessageHandling.ShowWarnMsg("CMMCMMB300", New String() {"無此病患基本資料！"})
                    IsFound = False
                    doFlag = False
                End If
            End If
            Return IsFound
        Catch ex As Exception
            Console.WriteLine(ex.ToString)   'nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try
    End Function

    ''' <summary>
    ''' 取得輸入的型式(病歷號,身分證號)
    ''' </summary>
    ''' <returns>輸入的型式</returns>
    ''' <remarks></remarks>''' 
    Private Function getInputType(ByVal type As uclTextTypeData) As String
        Select Case type
            Case uclTextTypeData.ChartNo
                Return "ChartNo"
            Case uclTextTypeData.IdNo
                Return "IdNo"
            Case uclTextTypeData.PatientName
                Return "PatientName"
        End Select
        Return Nothing
    End Function

    ''' <summary>
    ''' 查詢病患額外的資料  PubPatientFlag ,PubPatientDisability  ,PubPatientSevereDisease  
    ''' chartNo:病歷號
    ''' </summary>
    ''' <remarks></remarks>''' 
    Private Sub QueryAdditionPatData(ByVal chartNo As String)
        Try
            If pat3 IsNot Nothing Then
                pat3.PatientFlagDS = pub.queryPubPatientFlagByKey(chartNo)
                pat3.PatientSevereDisDS = pub.queryPubPatientSevereDiseaseByKey(chartNo)
                pat3.PatientDisDS = pub.queryPubPatientDisabilityByKey(chartNo)
            Else
                If uclIsInteractionChartNo Then
                    pat.PatientFlagDS = pub.queryPubPatientFlagByKey(chartNo)
                    pat.PatientSevereDisDS = pub.queryPubPatientSevereDiseaseByKey(chartNo)
                    pat.PatientDisDS = pub.queryPubPatientDisabilityByKey(chartNo)

                Else
                    pat2.PatientFlagDS = pub.queryPubPatientFlagByKey(chartNo)
                    pat2.PatientSevereDisDS = pub.queryPubPatientSevereDiseaseByKey(chartNo)
                    pat2.PatientDisDS = pub.queryPubPatientDisabilityByKey(chartNo)

                End If
            End If


        Catch ex As Exception
            Console.WriteLine(ex.ToString)   'nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    ''' <summary>
    ''' 身分證號檢驗 
    ''' id:身分證號
    ''' </summary>
    ''' <returns>True:身分證合格  False:身分證號不合格</returns>
    ''' <remarks></remarks>''' 
    Private Function checkId(ByVal id As String) As Boolean
        Try


            '如果不檢核ID
            If Not uclNeedCheckId Then
                Return True
            End If

            Dim idvalue As Integer, checkvalue As Integer

            If id.Trim.Length <> 10 Then
                Return True
            End If

            If Char.IsLetter(id, 0) AndAlso IsNumeric(id.Trim.Substring(1, 9)) Then

            Else
                Return True
            End If

            idvalue = Int(getCountyCode(Microsoft.VisualBasic.Left(id, 1)) / 10)
            idvalue = idvalue + (getCountyCode(Microsoft.VisualBasic.Left(id, 1)) Mod 10) * 9


            For i = 2 To 9
                idvalue = idvalue + Mid(id, i, 1) * (10 - i)
            Next

            checkvalue = (10 - (idvalue Mod 10)) Mod 10

            If (checkvalue = Microsoft.VisualBasic.Right(id, 1)) Then
                Return True
            Else
                pat.Clear()
                pat2.Clear()
                If pat3 IsNot Nothing Then
                    pat3.Clear()
                End If
                Return False
            End If
        Catch ex As Exception
            Console.WriteLine(ex.ToString)   'nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try
    End Function

    ''' <summary>
    ''' 取得地區號 身分證驗證用
    ''' country:身分證號字母
    ''' </summary>
    ''' <returns>地區號</returns>
    ''' <remarks></remarks>''' 
    Private Function getCountyCode(ByVal county As String) As Integer
        Select Case UCase(county)
            Case "A" : getCountyCode = 10
            Case "B" : getCountyCode = 11
            Case "C" : getCountyCode = 12
            Case "D" : getCountyCode = 13
            Case "E" : getCountyCode = 14
            Case "F" : getCountyCode = 15
            Case "G" : getCountyCode = 16
            Case "H" : getCountyCode = 17
            Case "J" : getCountyCode = 18
            Case "K" : getCountyCode = 19
            Case "L" : getCountyCode = 20
            Case "M" : getCountyCode = 21
            Case "N" : getCountyCode = 22
            Case "P" : getCountyCode = 23
            Case "Q" : getCountyCode = 24
            Case "R" : getCountyCode = 25
            Case "S" : getCountyCode = 26
            Case "T" : getCountyCode = 27
            Case "U" : getCountyCode = 28
            Case "V" : getCountyCode = 29
            Case "W" : getCountyCode = 32
            Case "X" : getCountyCode = 30
            Case "Y" : getCountyCode = 31
            Case "Z" : getCountyCode = 33
            Case "I" : getCountyCode = 34
            Case "O" : getCountyCode = 35
        End Select
    End Function

    Private Sub SetTextBoxFocused()
        MaskedTextBox1.Focus()
        MaskedTextBox1.SelectionStart = 0
    End Sub

    ''' <summary>
    ''' 錯誤顏色設定
    ''' </summary>
    ''' <remarks></remarks>''' 
    Private Sub setErrorColor()
        'MaskedTextBox1.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
    End Sub

    ''' <summary>
    ''' 預設顏色設定
    ''' </summary>
    ''' <remarks></remarks>''' 
    Private Sub setDefaultColor()
        Me.BackColor = System.Drawing.SystemColors.Window
        '   MaskedTextBox1.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
    End Sub

#End Region

#Region "Event 事件處理"

#Region "外部事件"
    '2013-07-26 Add by 嚴崑銘，供外部程式觸發指定事件
    Public Sub DoEventHandler(ByVal EventName As String)
        Select Case EventName.ToLower()
            Case "leave"
                Me.UCLChartNoUI_Leave(MaskedTextBox1, New EventArgs())
            Case "enter"
                Me.UCLChartNoUI_Enter(MaskedTextBox1, New EventArgs())
        End Select
    End Sub

#End Region

#Region "內部事件"

    ''' <summary>
    ''' UCLChartNoUI_Enter
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub UCLChartNoUI_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Enter, MaskedTextBox1.Enter

        If Not doFlag Then
            Exit Sub
        End If

        Select Case _uclTextType


            Case uclTextTypeData.ChartNo  '病歷號輸入
                If _uclDigitCount < 1 Then
                    _uclDigitCount = 8
                End If

                'If _uclTxtBoxWidth < 0 Then
                '    MaskedTextBox1.Width = 60
                'End If

                'For i As Integer = 0 To _uclDigitCount - 1
                '    MaskedTextBox1.Mask = MaskedTextBox1.Mask & "A"
                'Next


            Case uclTextTypeData.IdNo  '身分證輸入
                If uclNeedCheckId Then
                    'MaskedTextBox1.Mask = ">L000000000"
                End If


        End Select
    End Sub

    ''' <summary>
    ''' MaskedTextBox1_TextChanged
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MaskedTextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MaskedTextBox1.TextChanged
        RaiseEvent TextChanged(sender, e)
        doFlag = True
        Me.BackColor = System.Drawing.SystemColors.Window
        'setDefaultColor()
    End Sub

    ''' <summary>
    ''' MaskedTextBox1_Click
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MaskedTextBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MaskedTextBox1.Click
        If MaskedTextBox1.Text = "" Then
            MaskedTextBox1.Focus()

            MaskedTextBox1.SelectionStart = 0
        End If
    End Sub

    ''' <summary>
    ''' Cbo_Postal_KeyUp
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cbo_Postal_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MaskedTextBox1.KeyUp
        Try


            Select Case e.KeyCode
                Case Keys.Enter
                    Dim msg As String = ""

                    If MaskedTextBox1.Text.Trim() = "" Then

                        RaiseEvent KeyUp(sender, e)
                        Exit Sub
                    End If

                    'If MaskedTextBox1.Text.Trim().Contains(" ") Then
                    '    pat.Clear()
                    '    MessageBox.Show("輸入值中不可含空白")
                    '    MaskedTextBox1.Focus()
                    '    RaiseEvent KeyUp(sender, e)
                    '    Exit Sub
                    'End If

                    Select Case _uclTextType
                        Case uclTextTypeData.ChartNo

                            If IsAutoAddZero Then
                                For i As Integer = MaskedTextBox1.Text.Trim().Length To _uclDigitCount - 1
                                    MaskedTextBox1.Text = "0" & MaskedTextBox1.Text.Trim()
                                Next
                            Else
                                Try
                                    If IsNumeric(MaskedTextBox1.Text) Then
                                        '去除病歷號前置0
                                        Dim pvtIsZero As Boolean = True
                                        Dim pvtChartNo As String = MaskedTextBox1.Text.Trim

                                        Do
                                            If pvtChartNo.Substring(0, 1) = "0" Then
                                                pvtChartNo = pvtChartNo.Substring(1)
                                            Else
                                                pvtIsZero = False
                                            End If
                                        Loop Until (pvtIsZero = False)

                                        MaskedTextBox1.Text = pvtChartNo

                                    End If
                                Catch ex As Exception
                                End Try
                            End If

                            inputType = uclTextTypeData.ChartNo
                            QueryPatientByKey(MaskedTextBox1.Text)

                        Case uclTextTypeData.IdNo

                            inputType = uclTextTypeData.IdNo
                            If MaskedTextBox1.Text.Trim() <> "" Then
                                If checkId(MaskedTextBox1.Text) Then
                                    idNoInput(MaskedTextBox1.Text)
                                Else

                                    If pat3 IsNot Nothing Then
                                        pat3.Clear()
                                    Else
                                        pat.Clear()
                                        pat2.Clear()
                                    End If
                                    'MessageBox.Show(MaskedTextBox1.Text & " : 無效的身份證號碼")
                                    MessageHandling.ShowWarnMsg("CMMCMMB300", New String() {MaskedTextBox1.Text & " : 無效的身份證號碼"})
                                    setErrorColor()
                                End If

                                If uclNeedCheckIdByPubBP Then
                                    Dim outIdno As String = ""
                                    CheckIdNoBP.CheckIdNo(MaskedTextBox1.Text.Trim, outIdno, 1, uclIsAutoAppendP)
                                    MaskedTextBox1.Text = outIdno
                                End If

                            End If
                        Case uclTextTypeData.PatientName

                            inputType = uclTextTypeData.PatientName
                            If MaskedTextBox1.Text.Trim() <> "" Then
                                'If checkId(MaskedTextBox1.Text) Then
                                PatientNameInput(MaskedTextBox1.Text)
                            Else

                                If pat3 IsNot Nothing Then
                                    pat3.Clear()
                                Else
                                    pat.Clear()
                                    pat2.Clear()
                                End If

                                'MessageBox.Show(MaskedTextBox1.Text & " : 無效的姓名")
                                MessageHandling.ShowWarnMsg("CMMCMMB300", New String() {MaskedTextBox1.Text & " : 無效的姓名"})
                                setErrorColor()
                            End If
                            'End If

                    End Select


                    If pvtDS IsNot Nothing Then
                        '  Dim pa As New Patient

                    End If
            End Select


            RaiseEvent KeyUp(sender, e)
        Catch ex As Exception
            Console.WriteLine(ex.ToString)   'nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    ''' <summary>
    ''' UCLChartNoUI_Leave
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub UCLChartNoUI_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MaskedTextBox1.Leave

        Try
             
            If doFlag Then
                MaskedTextBox1.Text = MaskedTextBox1.Text.Trim.ToUpper
                Dim msg As String = ""

                'If MaskedTextBox1.Text.Trim().Contains(" ") Then
                '    MessageBox.Show("輸入值中不可含空白")
                '    MaskedTextBox1.Focus()
                '    Exit Sub
                'End If
                 
                If MaskedTextBox1.Text.Trim() <> "" Then
                     
                    Select Case _uclTextType
                        Case uclTextTypeData.ChartNo

                            If MaskedTextBox1.Text.Trim().Contains("'") Then
                                'MessageBox.Show("病歷號輸入格式錯誤")
                                MessageHandling.ShowWarnMsg("CMMCMMB300", New String() {"病歷號輸入格式錯誤！"})
                                MaskedTextBox1.Focus()
                                Exit Sub
                            End If

                            If IsAutoAddZero Then
                                For i As Integer = MaskedTextBox1.Text.Trim().Length To _uclDigitCount - 1
                                    MaskedTextBox1.Text = "0" & MaskedTextBox1.Text.Trim()
                                Next

                            Else
                                Try
                                    If IsNumeric(MaskedTextBox1.Text) Then
                                        '去除病歷號前置0
                                        Dim pvtIsZero As Boolean = True
                                        Dim pvtChartNo As String = MaskedTextBox1.Text.Trim

                                        Do
                                            If pvtChartNo.Substring(0, 1) = "0" Then
                                                pvtChartNo = pvtChartNo.Substring(1)
                                            Else
                                                pvtIsZero = False
                                            End If
                                        Loop Until (pvtIsZero = False)

                                        MaskedTextBox1.Text = pvtChartNo

                                    End If
                                Catch ex As Exception
                                End Try
                            End If

                            inputType = uclTextTypeData.ChartNo
                            QueryPatientByKey(MaskedTextBox1.Text)

                        Case uclTextTypeData.IdNo

                            inputType = uclTextTypeData.IdNo
                            If checkId(MaskedTextBox1.Text) Then
                                idNoInput(MaskedTextBox1.Text)
                            Else

                                If pat3 IsNot Nothing Then
                                    pat3.Clear()
                                Else
                                    pat.Clear()
                                    pat2.Clear()
                                End If

                                'MessageBox.Show(MaskedTextBox1.Text & " : 無效的身份證號碼")
                                MessageHandling.ShowWarnMsg("CMMCMMB300", New String() {MaskedTextBox1.Text & " : 無效的身份證號碼！"})
                                PatientReady = False
                                setErrorColor()
                                SetTextBoxFocused()
                            End If

                            If uclNeedCheckIdByPubBP Then
                                Dim outIdno As String = ""
                                CheckIdNoBP.CheckIdNo(MaskedTextBox1.Text.Trim, outIdno, 1, uclIsAutoAppendP)
                                MaskedTextBox1.Text = outIdno
                            End If

                        Case uclTextTypeData.PatientName


                            inputType = uclTextTypeData.PatientName

                            PatientNameInput(MaskedTextBox1.Text)


                    End Select


                    If pvtDS IsNot Nothing Then
                        '  Dim pa As New Patient

                    End If

                    '  MsgBox("， ？"
                    '  此病歷號已經合併  合併後的病歷號是  是否直接帶入查詢
                    '   MessageBox.Show(pvtDS.Tables(0).Rows.Count.ToString())
                End If
            End If


            ' doFlag = False
        Catch ex As Exception
            Console.WriteLine(ex.ToString)   'nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    ''' <summary>
    ''' UCLChartNoUI_Resize
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub UCLChartNoUI_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize

        If UCLFormUtil.isResizeable Then
            Me.AutoScaleMode = Windows.Forms.AutoScaleMode.None
        Else
            Me.Height = 27
        End If

    End Sub

#End Region

#End Region

End Class


Public Class CheckIdNoBP

    Dim pub As IPubServiceManager = PubServiceManager.getInstance


    ''' <summary>
    ''' 檢查證號
    ''' </summary>
    ''' <param name="strIdNo1">輸入身分證</param>
    ''' <param name="outputIdNo">輸出身分證</param>
    ''' <param name="chkFlag">檢核碼</param>
    ''' <returns>成功0 不成功其他代碼</returns>
    ''' <remarks></remarks>
    Public Function CheckIdNo(ByVal strIdNo1 As String, ByRef outputIdNo As String, Optional ByVal chkFlag As Integer = 0, Optional ByVal IsAutoAppendP As Boolean = True) As Integer

        Try
            Dim strIdNo As String = strIdNo1.Trim

            If strIdNo.Length = 0 OrElse (strIdNo.Length >= 11 AndAlso strIdNo.Substring(10, 1).ToUpper.Trim = "P") Then
                outputIdNo = strIdNo
                Return 0

            End If

            If strIdNo.Length = 10 AndAlso Asc(strIdNo.Substring(0, 1).ToUpper) >= 65 AndAlso Asc(strIdNo.Substring(0, 1).ToUpper) <= 90 AndAlso _
              (strIdNo.Substring(1, 1) = "1" OrElse strIdNo.Substring(1, 1) = "2") AndAlso IsNumeric(strIdNo.Substring(2, 8)) Then


                Dim ds As DataSet = New DataSet

                If chkFlag <> 0 Then
                    'chkFlag：0不檢查(預設)； >0要檢查
                    ds = pub.queryPubPatientByIdno(strIdNo)
                End If


                If ds IsNot Nothing AndAlso ds.Tables(0).Rows.Count > 0 Then

                    'outputIdNo = strIdNo + 第11碼填 'P’ (中間補空白)
                    'Return 88(統號與目前病歷號重複)

                    outputIdNo = strIdNo '& "P"

                    Return 88

                Else

                    If checkId(strIdNo) Then

                        outputIdNo = strIdNo
                        Return 0 ' (統號OK)
                    Else
                        If IsAutoAppendP Then
                            outputIdNo = strIdNo & "P"
                        Else
                            outputIdNo = strIdNo
                        End If

                        Return 99 ' (統號不合邏輯)

                    End If

                End If
                 
            Else

                If strIdNo.Trim.Length < 10 Then

                    For i As Integer = strIdNo.Trim.Length To 9
                        strIdNo = strIdNo & " "
                    Next

                End If

                If IsAutoAppendP Then
                    outputIdNo = strIdNo & "P"
                Else
                    outputIdNo = strIdNo
                End If
                 
                Return 77 ' (不為統號)

            End If

        Catch ex As Exception

            Return -1
        End Try
         
    End Function

    ''' <summary>
    ''' 身分證號檢驗 
    ''' id:身分證號
    ''' </summary>
    ''' <returns>True:身分證合格  False:身分證號不合格</returns>
    ''' <remarks></remarks>''' 
    Private Function checkId(ByVal id As String) As Boolean
        Try

            Dim idvalue As Integer, checkvalue As Integer

            If id.Trim.Length <> 10 Then
                Return False
            End If


            idvalue = Int(getCountyCode(Microsoft.VisualBasic.Left(id, 1)) / 10)
            idvalue = idvalue + (getCountyCode(Microsoft.VisualBasic.Left(id, 1)) Mod 10) * 9


            For i = 2 To 9
                idvalue = idvalue + Mid(id, i, 1) * (10 - i)
            Next

            checkvalue = (10 - (idvalue Mod 10)) Mod 10

            If (checkvalue = Microsoft.VisualBasic.Right(id, 1)) Then
                Return True
            Else

                Return False
            End If
        Catch ex As Exception
            Console.WriteLine(ex.ToString)   'nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try
    End Function

    ''' <summary>
    ''' 取得地區號 身分證驗證用
    ''' country:身分證號字母
    ''' </summary>
    ''' <returns>地區號</returns>
    ''' <remarks></remarks>''' 
    Private Function getCountyCode(ByVal county As String) As Integer
        Select Case UCase(county)
            Case "A" : getCountyCode = 10
            Case "B" : getCountyCode = 11
            Case "C" : getCountyCode = 12
            Case "D" : getCountyCode = 13
            Case "E" : getCountyCode = 14
            Case "F" : getCountyCode = 15
            Case "G" : getCountyCode = 16
            Case "H" : getCountyCode = 17
            Case "J" : getCountyCode = 18
            Case "K" : getCountyCode = 19
            Case "L" : getCountyCode = 20
            Case "M" : getCountyCode = 21
            Case "N" : getCountyCode = 22
            Case "P" : getCountyCode = 23
            Case "Q" : getCountyCode = 24
            Case "R" : getCountyCode = 25
            Case "S" : getCountyCode = 26
            Case "T" : getCountyCode = 27
            Case "U" : getCountyCode = 28
            Case "V" : getCountyCode = 29
            Case "W" : getCountyCode = 32
            Case "X" : getCountyCode = 30
            Case "Y" : getCountyCode = 31
            Case "Z" : getCountyCode = 33
            Case "I" : getCountyCode = 34
            Case "O" : getCountyCode = 35
        End Select
    End Function

End Class

#End Region
