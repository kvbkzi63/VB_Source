
'=============================================================================
'========================== 凌群電腦 Syscom ==================================
'=============================================================================
'=======
'======= 程式名稱：Print Condition 選取元件
'=======
'======= 程式說明：秀出登入者與病患所屬的Print Condition供選擇
'=======
'======= 建立日期：2012-06-06
'=======
'======= 開發人員：Ken Chang
'=============================================================================
'=============================================================================
'=============================================================================
Imports Syscom.Client.Servicefactory

Public Class UclPrintConditionUC

#Region "Property"

    Private Property TermCode As String = String.Empty

    Private Property TermCodePrintCond As String = String.Empty

    Private Property StationList As DataTable = Nothing

#End Region

#Region "Event"

#End Region

    ''' <summary>
    ''' 初始化UCL畫面資料
    ''' </summary>
    ''' <param name="ChartNo">病歷號</param>
    ''' <param name="CaseNo">住院號</param>
    ''' <param name="TerminalCode">登入者之Terminal Code</param>
    ''' <remarks></remarks>
    Public Sub InitPrintCondition(ByVal ChartNo As String, ByVal CaseNo As String, ByVal TerminalCode As String)

        Dim _uclService As IUclServiceManager = UclServiceManager.getInstance

        Dim _dic As New Dictionary(Of String, Object)
        _dic.Add("Chart_No", ChartNo)
        _dic.Add("Case_No", CaseNo)
        _dic.Add("Term_Code", TerminalCode)

        Dim _ds As DataSet = Nothing

        Try
            _ds = _uclService.QueryPrintCondition(_dic)
        Catch ex As Exception
            Throw ex
        End Try

        If _ds Is Nothing Then Exit Sub

        Dim _dtTermCode As DataTable = _ds.Tables("Term_Code")
        Dim _dtStationNo As DataTable = _ds.Tables("Station_No")

        StationList = _dtStationNo.Copy

        Me.SetTermCodePrintCond(_dtTermCode)
        Me.SetStationNo(_dtStationNo)

    End Sub

    Public Sub SetValByStationNo(ByVal Station_No As String)
        Try
            rdo_StationNo.Checked = True
            cbo_StationNo.SelectedValue = Station_No
        Catch ex As Exception
        End Try
    End Sub

    Private Sub SetTermCodePrintCond(ByVal InputDt As DataTable)
        If InputDt Is Nothing OrElse InputDt.Rows.Count = 0 Then
            rdo_StationNo.Checked = True
            Exit Sub
        End If
 

        Dim _dr As DataRow = InputDt.Rows(0)

        'Me.rdo_UserTermCode.Text = _dr("Term_Code")
        Me.TermCode = _dr("Term_Code")
        Me.TermCodePrintCond = _dr("Print_Cond")


    End Sub

    Private Sub SetStationNo(ByVal InputDt As DataTable)
        If InputDt Is Nothing Then Exit Sub

        cbo_StationNo.DataSource = InputDt.Copy
        cbo_StationNo.uclDisplayIndex = "0"
        cbo_StationNo.uclValueIndex = "1"

        Dim _dtE As EnumerableRowCollection(Of DataRow) = InputDt.AsEnumerable
        Dim _drDefault = _dtE.Where(Function(r) r("Is_Default") = "Y").FirstOrDefault

        If _drDefault IsNot Nothing Then
            cbo_StationNo.SelectedValue = _drDefault("Station_No")
        End If

    End Sub

    ''' <summary>
    ''' 取得Print Condition
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property SelectedPrintCondition() As String
        Get
            Dim _printCond As String = String.Empty

            If rdo_UserTermCode.Checked Then

                _printCond = Me.TermCodePrintCond

            ElseIf rdo_StationNo.Checked Then

                '_printCond = cbo_StationNo.SelectedValue
                Dim _stationNo As String = cbo_StationNo.SelectedValue

                If StationList IsNot Nothing Then
                    Dim _px = StationList.AsEnumerable.Where(Function(r) r("Station_No").ToString.Trim = _stationNo).Select(Function(r) r("Print_Cond").ToString).FirstOrDefault
                    If _px IsNot Nothing Then
                        _printCond = _px
                    End If
                End If
            Else
                _printCond = String.Empty
            End If

            If _printCond.Trim.Length = 0 Then
                _printCond = "*"
            End If

            Return _printCond
        End Get
    End Property

End Class
