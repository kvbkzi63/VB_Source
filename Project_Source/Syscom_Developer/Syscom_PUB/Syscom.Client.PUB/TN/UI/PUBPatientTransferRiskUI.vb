'/*
'*****************************************************************************
'*
'*    Page/Class Name:  病患運送等級修改作業
'*              Title:	PUBPatientTransferRiskUI
'*        Description:	
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Will.Lin
'*        Create Date:	2017-03-21
'*      Last Modifier:	Will.Lin
'*   Last Modify Date:	2017-03-21
'*
'*****************************************************************************
'*/

Imports System.ServiceModel

Imports Syscom.Comm.EXP
Imports Syscom.Comm.Utility
Imports Syscom.Comm.Utility.StringUtil
Imports Syscom.Comm.Utility.CheckMethodUtil
Imports Syscom.Comm.TableFactory
Imports Syscom.Client.CMM
Imports Syscom.Client.CMM.MessageHandling
Imports Syscom.Client.Servicefactory
Imports Syscom.Client.UCL
Imports Syscom.Client.UCL.UCLScreenUtil
Imports System.Text

Public Class PUBPatientTransferRiskUI
    Inherits BaseFormUI
#Region "     變數宣告 "

#Region "     使用者宣告　"

    '目前使用者的ID
    Private CurrentUserID As String = AppContext.userProfile.userId

    '目前使用者的院區
    Private CurrentUserSection As String = AppContext.userProfile.userSection

    Private m_PatientData As DataTable = Nothing
    Private m_insertData As DataSet = Nothing
    Private m_OutpatientSn As String = ""
    Private m_ChartNo As String = ""
    Private m_SrcSystem As String = ""
#End Region

#Region "     使用的service宣告 "

    '定義使用的service介面
    Dim Pub As IPubServiceManager

#End Region

#Region "     使用的Instance宣告 "

    Private Shared myInstance As PUBPatientTransferRiskUI
    Public Shared Function GetInstance() As PUBPatientTransferRiskUI
        If myInstance Is Nothing Then
            myInstance = New PUBPatientTransferRiskUI
        End If
        Return myInstance
    End Function

#End Region

#Region "     使用的Event宣告 "

    '定義使用的Event介面
    Dim WithEvents eventMgr As EventManager

#End Region

#End Region

#Region "     屬性設定 "



#End Region

#Region "     主要功能 "

#Region "     按鈕事件 "

#Region "     新增 "

    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns >Boolean</returns>
    ''' <remarks>by Will.Lin on 2017-03-21</remarks>
    Private Function InsertData() As Boolean

        Try

            Return Pub.InsertIntoPUBPatientTransferRisk(GetInsertData()) > 0


            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB912", ex)
        End Try

    End Function

#End Region

#Region "     查詢 "

    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <returns >Boolean</returns>
    ''' <remarks>by Will.Lin on 2017-03-21</remarks>
    Private Function QueryData() As Boolean

        Try

            Dim returnBoolean As Boolean = False

            Return returnBoolean

            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB911", ex)
        End Try

    End Function

#End Region

#End Region

#Region "     外部參數傳遞 (提供其他UI呼叫、傳入參數) "

    Public Sub New(ByVal outpatientSn As String, ByVal chartNo As String, ByVal srcSystem As String)

        ' 設計工具需要此呼叫。
        InitializeComponent()

        ' 在 InitializeComponent() 呼叫之後加入所有初始設定。

        m_OutpatientSn = outpatientSn
        m_ChartNo = chartNo
        m_SrcSystem = srcSystem
    End Sub


    Public Sub New()

        ' 設計工具需要此呼叫。
        InitializeComponent()

        ' 在 InitializeComponent() 呼叫之後加入所有初始設定。



    End Sub

#End Region

#End Region

#Region "     內部功能 "

#Region "     初始化設定 "

#Region "     初始化 - 顯示UI "

    ''' <summary>
    ''' 初始化 - 顯示UI
    ''' </summary>
    ''' <remarks>by Will.Lin on 2017-03-21</remarks>
    Public Sub ShownMe() Handles Me.Shown

        Try

            '載入服務管理員
            LoadServiceManager()

            '載入事件管理員
            LoadEventManager()

            If m_PatientData IsNot Nothing Then m_PatientData.Clear()

            If SetPatientData(Pub.Find_PatientData(m_ChartNo)) Then
                MessageHandling.ShowWarnMsg("CMMCMMB300", "查無病患資料")
            End If

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB990", ex)
        End Try

    End Sub

#End Region

#Region "     載入服務管理員 "

    ''' <summary>
    ''' 載入ServiceManager的Instance
    ''' </summary>
    ''' <remarks>by Will.Lin on 2017-03-21</remarks>
    Private Sub LoadServiceManager()

        Try

            Pub = PubServiceManager.getInstance()

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB991", ex)
        End Try


    End Sub

#End Region

#Region "     載入事件管理員(EventManager) "

    ''' <summary>
    ''' 載入EventManager的Instance
    ''' </summary>
    ''' <remarks>by Will.Lin on 2017-3-21</remarks>
    Private Sub LoadEventManager()

        Try

            eventMgr = EventManager.getInstance()

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB992", ex)
        End Try

    End Sub

#End Region

#Region "     關閉事件管理員(EventManager) "

    ''' <summary>
    ''' 關閉事件管理員(EventManager)
    ''' </summary>
    ''' <remarks>by Will.Lin on 2017-03-21</remarks>
    Private Sub UIDisposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed

        Try

            eventMgr = Nothing

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB993", ex)
        End Try

    End Sub

#End Region

#End Region

#Region "     事件集合 "

    ''' <summary>
    ''' 設定病患資料
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <returns></returns>
    Private Function SetPatientData(ByVal dt As DataTable) As Boolean

        Dim ps As New StringBuilder
        Try
            If Not CheckMethodUtil.CheckHasValue(dt) Then Return True

            If m_PatientData IsNot Nothing Then m_PatientData.Clear()

            m_PatientData = dt.Copy

            ps.Append(dt.Rows(0).Item("Chart_No").ToString.Trim).Append(" ").Append(dt.Rows(0).Item("Patient_Name").ToString.Trim).Append(" ")
            ps.Append(dt.Rows(0).Item("性別").ToString.Trim).Append(" ")

            If IsDate(dt.Rows(0).Item("Birth_Date")) Then
                Dim age As String() = DateUtil.GetAge(dt.Rows(0).Item("Birth_Date").ToString.Trim)
                ps.Append(age(0)).Append("歲").Append(" ")
                ps.Append("(").Append(DateUtil.TransDateToROC(CDate(dt.Rows(0).Item("Birth_Date").ToString.Trim).ToString("yyyy/MM/dd"))).Append(")").Append(" ")
            End If
            lbl_PatientInfo.Text = ps.ToString


            Dim strRiskLevel As String = Pub.QueryPUBPatientTransferRiskLevel(m_ChartNo, m_OutpatientSn)


            Select Case strRiskLevel
                Case "1" '綠燈
                    rbt_G.Checked = True
                Case "2" '黃燈
                    rbt_Y.Checked = True
                Case "3" '紅燈
                    rbt_R.Checked = True
            End Select

            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"SetPatientData"})
        Finally
            ps.Clear()
            ps = Nothing
        End Try
    End Function

    Private Sub InitialUIData()

    End Sub


#End Region

#Region "     取得存檔的Dataset資料 "

    Private Function GetInsertData() As DataSet

        Dim retds As DataSet = PubPatientTransferRiskDataTableFactory.getDataSetWithNoPK
        Dim dr As DataRow = retds.Tables(0).NewRow

        Try

            dr("Chart_No") = m_ChartNo
            dr("Medical_Sn") = m_OutpatientSn

            If rbt_G.Checked Then
                dr("Transfer_Risk_Id") = "1"
            ElseIf rbt_R.Checked Then
                dr("Transfer_Risk_Id") = "3"
            Else
                dr("Transfer_Risk_Id") = "2"
            End If
            dr("Src_System") = m_SrcSystem
            dr("Create_User") = CurrentUserID
            dr("Modified_User") = CurrentUserID

            retds.Tables(0).Rows.Add(dr)
            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"取得存檔的Dataset資料"})
        End Try
        Return retds
    End Function


#End Region

#Region "     按鍵鎖定、熱鍵功能設定 "

#Region "     主要功能的按鍵鎖定，避免重複Click造成資料或UI出問題 "

#Region "     修改 鎖定功能 "

    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <param name="Sender">按鈕物件</param>
    ''' <param name="e">事件</param>
    ''' <remarks>by Will.Lin on 2017-03-21</remarks>
    Private Sub btn_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Save.Click

        '鎖定螢幕
        Lock(Me)
        Try

            '清除左下方訊息欄
            ClearInfoMsg()

            If (InsertData()) Then

                '左下方顯示 新增 成功
                ShowInfoMsg("CMMCMMB301", "新增")

            End If

            'Error 的最上層，處理例外訊息
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        Finally
            '解除螢幕鎖定
            UnLock(Me)
        End Try

    End Sub

#End Region

#Region "     離開 鎖定功能 "

    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="Sender">按鈕物件</param>
    ''' <param name="e">事件</param>
    ''' <remarks>by Will.Lin on 2017-03-21</remarks>
    Private Sub btn_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Exit.Click

        '鎖定螢幕
        Lock(Me)
        Try

            '清除左下方訊息欄
            ClearInfoMsg()

            Me.Close()

            'Error 的最上層，處理例外訊息
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        Finally
            '解除螢幕鎖定
            UnLock(Me)
        End Try

    End Sub

#End Region

#End Region

#Region "     HotKey設定 "

    ''' <summary>
    ''' HotKey設定
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>by Will.Lin on 2017-03-21</remarks>
    Private Sub KeyDownBottuns(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        Try

            '鎖定螢幕
            Lock(Me)

            Select Case e.KeyCode

                Case Keys.F10

                    '如果按下Shift，則為刪除
                    If e.Shift = True Then

                        '刪除
                        If (btn_Save.Enabled) Then

                            btn_Save.PerformClick()

                        End If


                    End If

                Case Keys.Escape

                    '離開
                    If btn_Exit.Enabled Then
                        btn_Exit.PerformClick()
                    End If


            End Select

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"HotKey設定"})

        Finally

            '解除螢幕鎖定
            UnLock(Me)

        End Try

    End Sub

#End Region

#End Region

#End Region

End Class

