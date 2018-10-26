'=============================================================================
'========================== 凌群電腦 Syscom ==================================
'=============================================================================
'=======
'======= 程式名稱：公用詢問視窗
'=======
'======= 程式說明：1.公用詢問視窗
'=======
'======= 建立日期：2013-1-9
'=======
'======= 開發人員：Sean.Lin
'=============================================================================
'=============================================================================
'=============================================================================
 
Imports Syscom.Comm.Utility
Imports Syscom.Client.CMM.MessageHandling
 
Public Class UCLQuestionDialogUI

#Region "     命名原則 "

#Region "     元件命名原則 "

    '元件名稱		元件程式命名	範例說明

    'Botton			btn		查詢=>btn_Query

    'CheckBox		chk		限初診=>chk_IsFirstReg

    'CheckedListBox		clb		次專科=>clb_SecondDept

    'ComboBox		cbo		星期=>cbo_Week

    'DataGridView		dgv		查詢結果=>dgv_ShowData

    'DateTimePicker		dtp		生效日期=>dtp_EffectDate

    'GroupBox		grb		身分群組=>grb_Identity

    'Lable			lbl		病患姓名=>lbl_PatientName

    'ListBox		ltb		多醫師=>ltb_MultiDoc

    'Panel			pal		維護區塊=>pal_Mantain

    'RadioButton		rbt		身分=>rbt_Identity

    'RichTextBox		rtb		主訴=>rtb_Subjective

    'Tab Control		tbc		開立醫囑頁籤=>tbc_Order

    'TextBox		txt		病歷號=>txt_ChartNo

    'Tooltip		tip		主訴Tip=>tip_Subjective

    'TreeView		tre		郵遞區號=>tre_PostArea

#End Region

#Region "     程式碼命名原則 Copyright from MSDN [Visual Basic 命名慣例] "

    '1.名稱中的每一個單字以大寫字母做為開頭，例如 FindLastRecord 與 RedrawMyForm 函式與方法名稱以動詞做為開頭，例如 InitNameArray 或 CloseDialog。

    '2.類別 (Class)、結構、模組和屬性 (Property) 名稱會以名詞做為開頭，例如 EmployeeName 或 CarAccessory。

    '3.介面名稱以 "I" 前置字元做為開頭，之後並接著一個名詞或名詞片語 (例如 IComponent)，或是接著可描述介面行為的形容詞 (例如 IPersistable)。 不要使用底線，並且盡量不要使用縮寫，因為縮寫可能導致混淆。

    '4.事件處理常式名稱以名詞為開頭，以描述其後跟隨 "EventHandler" 後置詞的事件類型，例如 "MouseEventHandler"。

    '5.在事件引數類別的名稱中，包含 "EventArgs" 後置詞。

    '6.如果事件擁有「之前」、「之後」的概念，請使用現在式或過去式的後置字元，例如在 "ControlAdd" 或 "ControlAdded" 中。

    '7.對於冗長或常用的詞彙，可使用縮寫以使名稱保持合理的長度，例如使用 "HTML"，而不使用 "Hypertext Markup Language"。 一般來說，變數名稱大於 32 個字元者將會難以在低解析度的螢幕上閱讀。 此外，確認您的縮寫名稱在整個應用軟體中維持一致。 在專案中隨意變換 "HTML" 與 "Hypertext Markup Language" 會造成混淆。

    '8.避免在內部範圍使用與外部範圍相同的名稱。 存取不正確的變數會導致錯誤發生。 若名稱相同的變數與關鍵字產生衝突，則您必須以適當的型別程式庫前置關鍵字來識別之。 例如，如果有一個名為 Date 的變數，則您只能藉由呼叫 DateTime.Date 的方式，使用內建的 Date 函式。

#End Region

#Region "     凌群程式規範原則 "

    '1.變數小寫開頭，之後為大寫開頭區隔每個字。Ex: caseNo     (Camel 命名法)

    '2.函式大寫開頭，之後為大寫開頭區隔每個字。Ex: FindIndex  (Pascal 命名法)

    '3.元件命名原則 txt_CaseNo

    '4.表單大小為980*680，新細明體，字型大小12，按鈕大小為90 * 28 (超過可自行放大)

    '5.Function 的 Summary 如下

    '''' <summary>
    '''' 儲存
    '''' </summary>
    '''' <param name="ds">輸入的Dataset</param>
    '''' <returns >Boolean</returns>
    '''' <remarks>by Sean on 2011-10-26</remarks>

    '6.Sub 的 Summary 如下
    '''' <summary>
    '''' 儲存鎖定功能
    '''' </summary>
    '''' <param name="sender"></param>
    '''' <param name="e"></param>
    '''' <returns >Boolean</returns>
    '''' <remarks>by Sean on 2011-10-26</remarks>

#End Region

#End Region

#Region "     變數宣告 "
    Enum CallType As Integer
        Question
        TextBox
    End Enum
#End Region

#Region "     屬性設定 "



#End Region

#Region "     主要功能 "

#Region "     初始化"

    Public Sub New()

        ' 設計工具需要此呼叫。
        InitializeComponent()

        ' 在 InitializeComponent() 呼叫之後加入所有初始設定。

    End Sub

    ''' <summary>
    ''' 初始化
    ''' </summary>
    ''' <param name="Type">呼叫型態</param>
    ''' <param name="FormTitle">表單標題</param>
    Public Sub New(Type As CallType, ByVal FormTitle As String)

        ' 設計工具需要此呼叫。
        InitializeComponent()

        ' 在 InitializeComponent() 呼叫之後加入所有初始設定。

        Select Case Type
            Case CallType.TextBox
                Rtb_Data.Enabled = True
                Rtb_Data.ReadOnly = False
        End Select
        Me.Text = FormTitle

    End Sub

#End Region

#Region "     按鈕事件 "

#Region "     確定 "

    ''' <summary>
    ''' 確定
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2012-12-5</remarks>
    Private Sub ConfirmData() Handles btn_Confirm.Click


        Try
            '鎖定螢幕
            UCLScreenUtil.Lock(Me)

            Me.DialogResult = Windows.Forms.DialogResult.OK


            Me.Close()


        Catch ex As Exception

            Me.DialogResult = False
 
            ShowErrorMsg("CMMCMMB302", "確定", ex.Message)


        Finally

            '解除螢幕鎖定
            UCLScreenUtil.UnLock(Me)

        End Try



    End Sub

#End Region

#Region "     離開 "

    ''' <summary>
    ''' 離開
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2012-12-5</remarks>
    Private Sub ExitData() Handles BTN_Cancel.Click

        Try

            Me.DialogResult = Windows.Forms.DialogResult.Cancel

            Me.Close()

        Catch ex As Exception

            ShowErrorMsg("CMMCMMB302", "離開", ex.Message)

            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        End Try

    End Sub

#End Region

#End Region

#Region "     回傳事件"

    Public Overloads Function ShowDialog() As String
        MyBase.ShowDialog()
        Return Rtb_Data.Text
    End Function


#End Region

#Region "     外部參數傳遞 (提供其他UI呼叫、傳入參數) "

#Region "     設定顯示的資料 "

    ''' <summary>
    ''' 設定顯示的資料
    ''' </summary>
    ''' <param name="Data" >要顯示的資料</param>
    ''' <remarks>by Sean.Lin on 2013-1-9</remarks>
    Public Sub SetData(ByVal Data As System.Text.StringBuilder)

        Try

            Rtb_Data.Text = Data.ToString

        Catch ex As Exception

            ShowErrorMsg("CMMCMMB302", "設定顯示的資料", ex.Message)

        End Try

    End Sub

#End Region



#End Region

#End Region

#Region "     內部功能 "

#End Region

End Class

