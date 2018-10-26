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

Public Class UCLCensusAddrUC

#Region "全域變數宣告"


    Private _DataSource As DataTable = New DataTable()
    Private _SelectedValue As String = ""
    '  Private _DropDownWidth As Integer = 10
    Private _uclDisplayIndex As String = "0,1"
    Private _uclValueIndex As String = "0"
    Private _uclCboWidth As Integer = 150
    Private _uclXPosition As Integer = 225
    Private _uclYPosition As Integer = 120

    Private _uclShowType = uclShowData.showPostal
    Private _doFlag As Boolean = True

    Dim nameStr As String = ""
    Dim firstInitial As Boolean = True
    Dim pvtCheckFlag = False
    Dim pvtDS As DataSet

    Private _SelectAreaCode As String = ""
    Private _SelectAreaName As String = ""

    Private _SelectPostalCode As String = ""
    Private _SelectPostalName As String = ""
    Private _IsUsePUBAreaCodeN As Boolean = False

#End Region


#Region "屬性設定"


    Public Property IsUsePUBAreaCodeN() As Boolean
        Get
            Return _IsUsePUBAreaCodeN
        End Get
        Set(ByVal value As Boolean)
            _IsUsePUBAreaCodeN = value
        End Set
    End Property


    Public Property SelectAreaCode() As String
        Get
            Return _SelectAreaCode
        End Get
        Set(ByVal value As String)
            _SelectAreaCode = value
        End Set
    End Property


    Public Property SelectAreaName() As String
        Get
            Return _SelectAreaName
        End Get
        Set(ByVal value As String)
            _SelectAreaName = value
        End Set
    End Property


    Public Property SelectPostalCode() As String
        Get
            Return _SelectPostalCode
        End Get
        Set(ByVal value As String)
            _SelectPostalCode = value
        End Set
    End Property


    Public Property SelectPostalName() As String
        Get
            Return _SelectPostalName
        End Get
        Set(ByVal value As String)
            _SelectPostalName = value
        End Set
    End Property


    Public Property TxtAddress() As String
        Get
            Return Txt_Address.Text
        End Get
        Set(ByVal value As String)
            Txt_Address.Text = value
        End Set
    End Property

    Public Property DataSource() As DataTable
        Get
            Return _DataSource
        End Get
        Set(ByVal value As DataTable)
            _DataSource = value
            Cbo_Postal.DataSource = value
            Cbo_Postal.SelectedIndex = 0
            '       Cbo_Area.DropDownWidth = Me.Size.Width
        End Set
    End Property

    Enum uclShowData
        showPostal = 1   '1:顯示郵遞區號代碼
        showArea = 2     '2:顯示戶籍地號代碼

    End Enum


    Public Property doFlag() As Boolean
        Get
            Return _doFlag
        End Get
        Set(ByVal value As Boolean)
            _doFlag = value
        End Set
    End Property


    Public Property uclCboWidth() As Integer
        Get
            Return _uclCboWidth
        End Get
        Set(ByVal value As Integer)

            Cbo_Postal.Width = value
            _uclCboWidth = value
        End Set
    End Property

    Public Property uclShowType() As uclShowData
        Get
            Return _uclShowType
        End Get
        Set(ByVal value As uclShowData)
            _uclShowType = value
        End Set
    End Property
    Public Property SelectedValue() As String
        Get
            Return _SelectedValue
        End Get
        Set(ByVal value As String)
            _SelectedValue = value
            '   Cbo_Postal.SelectedValue = _SelectedValue
            SetCboText(value)
        End Set
    End Property



    '設定要顯示的欄位Index(預設為0,1=>代碼與名稱)
    Public Property uclDisplayIndex() As String
        Get
            Return _uclDisplayIndex
        End Get
        Set(ByVal value As String)
            _uclDisplayIndex = value
            SetComboField(_DataSource, "ShowField", _uclDisplayIndex)
            Cbo_Postal.DisplayMember = "ShowField"
        End Set
    End Property

    '設定要選取值的欄位Index(預設為0=>代碼)
    Public Property uclValueIndex() As String
        Get
            Return _uclValueIndex
        End Get
        Set(ByVal value As String)
            _uclValueIndex = value
            SetComboField(_DataSource, "ValueField", _uclValueIndex)
            Cbo_Postal.ValueMember = "ValueField"

        End Set
    End Property

    Public Property uclXPosition() As Integer
        Get
            Return _uclXPosition
        End Get
        Set(ByVal value As Integer)
            _uclXPosition = value
        End Set
    End Property
    Public Property uclYPosition() As Integer
        Get
            Return _uclYPosition
        End Get
        Set(ByVal value As Integer)
            _uclYPosition = value
        End Set
    End Property


#End Region

    ''' <summary>
    '''  設定下拉選項值顯示欄位內容與選取值對應欄位
    ''' </summary>
    ''' <remarks></remarks>''' 
    Public Sub SetComboField(ByVal pvtTable As DataTable, ByVal pvtColumnName As String, ByVal pvtCutStr As String)

        Dim pvtColumn As DataColumn = pvtTable.Columns.Add(pvtColumnName)
        Dim pvtArrayList As ArrayList = CutString(pvtCutStr, ",")


        For i = 1 To pvtTable.Rows.Count - 1


            For j = 0 To pvtArrayList.Count - 1

                If j = 0 Then

                    pvtTable.Rows(i).Item(pvtColumnName) = pvtTable.Rows(i).Item(Integer.Parse(pvtArrayList.Item(j).ToString))

                Else

                    pvtTable.Rows(i).Item(pvtColumnName) += "-" & pvtTable.Rows(i).Item(Integer.Parse(pvtArrayList.Item(j).ToString))

                End If

            Next
        Next

    End Sub

    Private Sub setTextBoxFocused()
        Txt_Address.Focus()
        Txt_Address.SelectionStart = Txt_Address.TextLength
    End Sub

    ''' <summary>
    '''  字串處理
    ''' pvtStr:處理的字串
    ''' pvtCutSysbol:處理的符號
    ''' </summary>
    ''' <returns>處理後的字串陣列</returns>
    ''' <remarks></remarks>''' 
    Public Function CutString(ByVal pvtStr As String, ByVal pvtCutSysbol As String) As ArrayList
        Dim pvtListData As ArrayList = New ArrayList()
        Dim pvtCount As Integer = 0
        Dim pvtCutStr As String = ""

        Do
            pvtCount = pvtStr.IndexOf(pvtCutSysbol)
            If (pvtCount > 0) Then
                pvtCutStr = pvtStr.Substring(0, pvtCount)
                pvtStr = pvtStr.Substring(pvtCount + 1)
            Else
                pvtCutStr = pvtStr
            End If
            pvtListData.Add(pvtCutStr)
        Loop While pvtCount > 0

        Return pvtListData
    End Function


    ''' <summary>
    ''' 進行戶籍地與郵遞區號查詢
    ''' </summary>
    ''' <remarks></remarks>''' 
    Private Sub queryAreaPostal()
        Try
            Dim uclACQ As IUclServiceManager = UclServiceManager.getInstance
            If Not IsUsePUBAreaCodeN Then
                pvtDS = uclACQ.queryUclPostalAreaAll()
            Else
                pvtDS = uclACQ.queryUclPostalAreaAllNew()
            End If


        Catch ex As Exception

            Console.WriteLine(ex.ToString)

        End Try
    End Sub


    Public Function GetName()
        Return nameStr
    End Function

    ''' <summary>
    ''' 初始化設定
    ''' </summary>
    ''' <remarks></remarks>''' 
    Public Sub Initial()
        If pvtDS Is Nothing Then
            queryAreaPostal()
        End If
    End Sub

    ''' <summary>
    ''' 初始化設定
    ''' </summary>
    ''' <remarks></remarks>''' 
    Public Sub Initial(ByVal dt As DataTable)
        If pvtDS Is Nothing Then
            pvtDS = New DataSet
            pvtDS.Tables.Add(dt.Copy)
        End If
    End Sub


    ''' <summary>
    ''' 進行戶籍地與郵遞區號查詢
    ''' code:查詢代碼
    ''' </summary>
    ''' <remarks></remarks>''' 
    Public Sub queryAreaCode(ByVal code As String)
        Try



            Dim find As Boolean = False


            If (code.Length = 2) OrElse (code.Length = 4) Then  'IsNumeric(code) AndAlso
                For Each dr As DataRow In pvtDS.Tables(0).Rows
                    If code.Trim = dr.Item(0).ToString().Trim() Then

                        If uclShowType = uclShowData.showArea Then
                            Cbo_Postal.Text = dr.Item(0).ToString().Trim() & " - " & dr.Item(4).ToString().Trim
                            _SelectedValue = dr.Item(0).ToString().Trim()

                        ElseIf uclShowType = uclShowData.showPostal Then
                            Cbo_Postal.Text = dr.Item(3).ToString().Trim() & " - " & dr.Item(4).ToString().Trim
                            _SelectedValue = dr.Item(3).ToString().Trim()
                        End If


                        nameStr = dr.Item(4).ToString().Trim

                        _SelectAreaCode = dr.Item(0).ToString().Trim()
                        _SelectAreaName = dr.Item(4).ToString().Trim

                        _SelectPostalCode = dr.Item(3).ToString().Trim()
                        _SelectPostalName = dr.Item(4).ToString()


                        find = True
                        Exit For
                    End If
                Next

            ElseIf (code.Length = 3) Then 'IsNumeric(code) AndAlso
                For Each dr As DataRow In pvtDS.Tables(0).Rows
                    If code.Trim.Trim = dr.Item(3).ToString().Trim() Then


                        If uclShowType = uclShowData.showArea Then

                            Cbo_Postal.Text = dr.Item(0).ToString().Trim() & " - " & dr.Item(4).ToString().Trim()
                            _SelectedValue = dr.Item(0).ToString().Trim()

                        ElseIf uclShowType = uclShowData.showPostal Then
                            Cbo_Postal.Text = dr.Item(3).ToString().Trim() & " - " & dr.Item(4).ToString().Trim()
                            _SelectedValue = dr.Item(3).ToString().Trim()
                        End If



                        nameStr = dr.Item(4).ToString().Trim

                        _SelectAreaCode = dr.Item(0).ToString().Trim()
                        _SelectAreaName = dr.Item(4).ToString().Trim

                        _SelectPostalCode = dr.Item(3).ToString().Trim()
                        _SelectPostalName = dr.Item(4).ToString()


                        find = True
                        Exit For
                    End If
                Next
            Else
                find = False
            End If
            If Not find Then
                Cbo_Postal.Text = ""
                _SelectedValue = ""

                _SelectAreaCode = ""
                _SelectAreaName = ""

                _SelectPostalCode = ""
                _SelectPostalName = ""
                nameStr = ""

            End If
        Catch ex As Exception
            Console.WriteLine(ex.ToString)
        End Try
    End Sub

    ''' <summary>
    ''' 設定ComboBox的Text
    ''' </summary>
    ''' <remarks></remarks>''' 
    Private Sub SetCboText(ByVal text As String)
        firstInitial = True
        Cbo_Postal.Text = text
    End Sub

#Region "Event"


    Private Sub Cbo_Postal_DropDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cbo_Postal.DropDown

        Try


            If pvtDS Is Nothing Then
                queryAreaPostal()
            End If
            If Cbo_Postal.Items.Count = 0 Then


                '加入一個空白項目
                Cbo_Postal.Items.Add("")

                For i As Integer = 0 To pvtDS.Tables(0).Rows.Count - 1
                    '1:顯示郵遞區號代碼  col(3):Postal_Code ,col(4): Postal_Name
                    If _uclShowType = uclShowData.showPostal Then

                        Cbo_Postal.Items.Add(pvtDS.Tables(0).Rows(i).Item(3).ToString().Trim() & " - " & pvtDS.Tables(0).Rows(i).Item(4).ToString().Trim())

                    ElseIf _uclShowType = uclShowData.showArea Then
                        Cbo_Postal.Items.Add(pvtDS.Tables(0).Rows(i).Item(0).ToString().Trim() & " - " & pvtDS.Tables(0).Rows(i).Item(1).ToString().Trim())

                    End If

                Next

            End If
        Catch ex As Exception
            Console.WriteLine(ex.ToString)
        End Try

    End Sub

    Private Sub Cbo_Postal_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cbo_Postal.SelectedIndexChanged
        Try


            pvtCheckFlag = True
            If _uclShowType = uclShowData.showPostal AndAlso Cbo_Postal.Text.Length > 5 Then
                Txt_Address.Text = Cbo_Postal.Text.Substring(6)

            ElseIf uclShowType = uclShowData.showArea AndAlso Cbo_Postal.Text.Length > 6 Then
                Txt_Address.Text = Cbo_Postal.Text.Substring(7)
            Else
                Txt_Address.Text = ""
            End If

            setTextBoxFocused()
        Catch ex As Exception
            Console.WriteLine(ex.ToString)
        End Try
    End Sub


    Private Sub Cbo_Postal_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cbo_Postal.Enter
        If pvtDS Is Nothing Then
            queryAreaPostal()
        End If

    End Sub

    Private Sub Cbo_Postal_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Cbo_Postal.KeyUp
        Select Case e.KeyCode
            Case Keys.Enter

                Select Case _uclShowType
                    Case uclShowData.showPostal
                        queryAreaCode(Cbo_Postal.Text.Trim())
                    Case uclShowData.showArea
                        queryAreaCode(Cbo_Postal.Text.Trim())
                End Select

        End Select
    End Sub

    Private Sub Cbo_Postal_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cbo_Postal.SelectionChangeCommitted
        Try


            pvtCheckFlag = True

            If _uclShowType = uclShowData.showPostal AndAlso Cbo_Postal.SelectedIndex > 0 Then
                _SelectedValue = pvtDS.Tables(0).Rows(Cbo_Postal.SelectedIndex - 1).Item(3).ToString().Trim()
                nameStr = pvtDS.Tables(0).Rows(Cbo_Postal.SelectedIndex - 1).Item(4).ToString().Trim()


                SelectAreaCode = pvtDS.Tables(0).Rows(Cbo_Postal.SelectedIndex - 1).Item(0).ToString().Trim()
                SelectAreaName = pvtDS.Tables(0).Rows(Cbo_Postal.SelectedIndex - 1).Item(1).ToString().Trim()

                SelectPostalCode = pvtDS.Tables(0).Rows(Cbo_Postal.SelectedIndex - 1).Item(3).ToString().Trim()
                SelectPostalName = pvtDS.Tables(0).Rows(Cbo_Postal.SelectedIndex - 1).Item(4).ToString().Trim()




            ElseIf _uclShowType = uclShowData.showArea AndAlso Cbo_Postal.SelectedIndex > 0 Then
                _SelectedValue = pvtDS.Tables(0).Rows(Cbo_Postal.SelectedIndex - 1).Item(0).ToString().Trim()
                nameStr = pvtDS.Tables(0).Rows(Cbo_Postal.SelectedIndex - 1).Item(1).ToString().Trim()


                SelectAreaCode = pvtDS.Tables(0).Rows(Cbo_Postal.SelectedIndex - 1).Item(0).ToString().Trim()
                SelectAreaName = pvtDS.Tables(0).Rows(Cbo_Postal.SelectedIndex - 1).Item(1).ToString().Trim()

                SelectPostalCode = pvtDS.Tables(0).Rows(Cbo_Postal.SelectedIndex - 1).Item(3).ToString().Trim()
                SelectPostalName = pvtDS.Tables(0).Rows(Cbo_Postal.SelectedIndex - 1).Item(4).ToString().Trim()


            Else
                _SelectedValue = ""
                nameStr = ""
                SelectAreaCode = ""
                SelectAreaName = ""

                SelectPostalCode = ""
                SelectPostalName = ""


            End If
        Catch ex As Exception
            Console.WriteLine(ex.ToString)
        End Try
    End Sub

    Private Sub Cbo_Postal_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cbo_Postal.Leave
        Try


            If doFlag Then

                If (Not pvtCheckFlag OrElse Cbo_Postal.Text.Trim().Length = 3 OrElse Cbo_Postal.Text.Trim().Length = 4) Then


                    Select Case _uclShowType
                        Case uclShowData.showPostal
                            queryAreaCode(Cbo_Postal.Text.Trim())
                        Case uclShowData.showArea
                            queryAreaCode(Cbo_Postal.Text.Trim())
                    End Select


                ElseIf Not pvtCheckFlag Then
                    Cbo_Postal.Text = ""
                    'Txt_Address.Text = ""
                    _SelectedValue = ""
                    nameStr = ""
                    SelectAreaCode = ""
                    SelectAreaName = ""

                    SelectPostalCode = ""
                    SelectPostalName = ""


                End If

            End If

            doFlag = False
        Catch ex As Exception
            Console.WriteLine(ex.ToString)
        End Try
    End Sub


    Private Sub Cbo_Postal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cbo_Postal.TextChanged

        doFlag = True

        If firstInitial Then
            firstInitial = False
            Cbo_Postal_Leave(sender, e)

        End If

    End Sub


    Private Sub UCLCensusAddrUI_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize

        If UCLFormUtil.isResizeable Then
            Me.AutoScaleMode = Windows.Forms.AutoScaleMode.None
        Else
            Me.Height = 26
        End If

    End Sub
#End Region
End Class
