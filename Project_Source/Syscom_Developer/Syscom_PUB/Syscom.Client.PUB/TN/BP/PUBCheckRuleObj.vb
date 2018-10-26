Public Class PUBCheckRuleObj

    Private RuleCode_Renamed As String = ""
    Private SeqNo_Renamed As Integer = 1
    Private Desc_Renamed As String = ""
    Private Item_Renamed As String = ""
    Private Item_Name_Renamed As String = ""

    Private ParaX_Renamed As String = ""
    Private ParaY_Renamed As String = ""
    Private ParaZ_Renamed As String = ""
    Private OperatorCode_Renamed As String = ""
    Private Operator_Name_Renamed As String = ""

    Private ValueData_Renamed As String = ""
    Private Unit_Renamed As String = ""
    Private Unit_Name_Renamed As String = ""

    Private CountO_Renamed As Boolean = True
    Private CountE_Renamed As Boolean = True
    Private CountI_Renamed As Boolean = True
    Private LogicSymbol_Renamed As String = ""
    Private LogicSymbol_Name_Renamed As String = ""

    Private IsByPassCheck_Renamed As Boolean = False
    Private IsPriorReview_Renamed As Boolean = False
    Private InputNoticeLabel_Renamed As String = ""
    Private Level_Renamed As Integer = 0
    Private id_Renamed As Integer = 0
    Private pid_Renamed As Integer = 0

    Dim itemNameHash As New Hashtable
    Dim operNameHash As New Hashtable
    Dim unitNameHash As New Hashtable
    Dim condNameHash As New Hashtable


    Public Sub New(ByVal itemNameHash As Hashtable, ByVal operNameHash As Hashtable, ByVal unitNameHash As Hashtable, ByVal condNameHash As Hashtable, _
                   ByVal RuleCode_Renamed As String, ByVal SeqNo_Renamed As Integer, ByVal Desc_Renamed As String, _
                   ByVal Item_Renamed As String, ByVal paraX_Renamed As String, ByVal paraY_Renamed As String, ByVal paraZ_Renamed As String, _
                   ByVal OperatorCode_Renamed As String, ByVal ValueData_Renamed As String, ByVal Unit_Renamed As String, _
                   ByVal CountO_Renamed As Boolean, ByVal CountE_Renamed As Boolean, ByVal CountI_Renamed As Boolean, _
                   ByVal LogicSymbol_Renamed As String, ByVal IsByPassCheck_Renamed As Boolean, ByVal InputNoticeLabel_Renamed As String, ByVal IsPriorReview_Renamed As Boolean)

        Me.itemNameHash = itemNameHash
        Me.operNameHash = operNameHash
        Me.unitNameHash = unitNameHash
        Me.condNameHash = condNameHash


        Me.RuleCode_Renamed = RuleCode_Renamed
        Me.SeqNo_Renamed = SeqNo_Renamed

        Me.Desc_Renamed = Desc_Renamed
        Me.Item_Renamed = Item_Renamed

        If itemNameHash IsNot Nothing AndAlso itemNameHash.ContainsKey(Item_Renamed) Then
            ItemName = CType(itemNameHash.Item(Item_Renamed), String).Trim
        Else
            ItemName = Item_Renamed
        End If

        Me.ParaX_Renamed = paraX_Renamed
        Me.ParaY_Renamed = paraY_Renamed
        Me.ParaZ_Renamed = paraZ_Renamed
        Me.OperatorCode_Renamed = OperatorCode_Renamed

        If operNameHash IsNot Nothing AndAlso operNameHash.ContainsKey(OperatorCode_Renamed) Then
            OperatorName = CType(operNameHash.Item(OperatorCode_Renamed), String).Trim
        Else
            OperatorName = OperatorCode_Renamed
        End If

        Me.ValueData_Renamed = ValueData_Renamed
        Me.Unit_Renamed = Unit_Renamed

        If unitNameHash IsNot Nothing AndAlso unitNameHash.ContainsKey(Unit_Renamed) Then
            UnitName = CType(unitNameHash.Item(Unit_Renamed), String).Trim
        Else
            UnitName = Unit_Renamed
        End If

        Me.CountO_Renamed = CountO_Renamed
        Me.CountE_Renamed = CountE_Renamed
        Me.CountI_Renamed = CountI_Renamed
        Me.LogicSymbol_Renamed = LogicSymbol_Renamed

        If condNameHash IsNot Nothing AndAlso condNameHash.ContainsKey(LogicSymbol_Renamed) Then
            LogicSymbolName = CType(condNameHash.Item(LogicSymbol_Renamed), String).Trim
        Else
            LogicSymbolName = LogicSymbol_Renamed
        End If

        Me.Level_Renamed = Level_Renamed
        Me.IsByPassCheck_Renamed = IsByPassCheck_Renamed
        Me.InputNoticeLabel_Renamed = InputNoticeLabel_Renamed
        Me.IsPriorReview = IsPriorReview_Renamed
        'Me.id_Renamed = id_Renamed
        'Me.pid_Renamed = pid_Renamed

    End Sub


    Public Property id() As Integer
        Get
            Return id_Renamed
        End Get
        Set(ByVal value As Integer)
            id_Renamed = value
        End Set
    End Property

    Public Property pid() As Integer
        Get
            Return pid_Renamed
        End Get
        Set(ByVal value As Integer)
            pid_Renamed = value
        End Set
    End Property

    Public Property Level() As String
        Get
            Return Level_Renamed
        End Get
        Set(ByVal value As String)
            Level_Renamed = value
        End Set
    End Property

    Public Property RuleCode() As String
        Get
            Return RuleCode_Renamed
        End Get
        Set(ByVal value As String)
            RuleCode_Renamed = value
        End Set
    End Property

    Public Property SeqNo() As Integer
        Get
            Return SeqNo_Renamed
        End Get
        Set(ByVal value As Integer)
            SeqNo_Renamed = value
        End Set
    End Property

    Public Property Desc() As String
        Get
            Return Desc_Renamed
        End Get
        Set(ByVal value As String)
            Desc_Renamed = value
        End Set
    End Property

    Public Property Item() As String
        Get
            Return Item_Renamed
        End Get
        Set(ByVal value As String)
            Item_Renamed = value

            If itemNameHash IsNot Nothing AndAlso itemNameHash.ContainsKey(Item_Renamed) Then
                ItemName = CType(itemNameHash.Item(Item_Renamed), String).Trim
            Else
                ItemName = Item_Renamed
            End If

        End Set
    End Property

    '檢項
    Public Property ItemName() As String
        Get
            Return Item_Name_Renamed
        End Get
        Set(ByVal value As String)
            Item_Name_Renamed = value
        End Set
    End Property

    Public Property ParaX() As String
        Get
            Return ParaX_Renamed
        End Get
        Set(ByVal value As String)
            ParaX_Renamed = value
        End Set
    End Property

    Public Property ParaY() As String
        Get
            Return ParaY_Renamed
        End Get
        Set(ByVal value As String)
            ParaY_Renamed = value
        End Set
    End Property

    Public Property ParaZ() As String
        Get
            Return ParaZ_Renamed
        End Get
        Set(ByVal value As String)
            ParaZ_Renamed = value
        End Set
    End Property

    Public Property OperatorCode() As String
        Get
            Return OperatorCode_Renamed
        End Get
        Set(ByVal value As String)
            OperatorCode_Renamed = value

            If operNameHash IsNot Nothing AndAlso operNameHash.ContainsKey(OperatorCode_Renamed) Then
                OperatorName = CType(operNameHash.Item(OperatorCode_Renamed), String).Trim
            Else
                OperatorName = OperatorCode_Renamed
            End If

        End Set
    End Property

    '純顯示名稱
    Public Property OperatorName() As String
        Get
            Return Operator_Name_Renamed
        End Get
        Set(ByVal value As String)
            Operator_Name_Renamed = value
        End Set
    End Property

    Public Property ValueData() As String
        Get
            Return ValueData_Renamed
        End Get
        Set(ByVal value As String)
            ValueData_Renamed = value
        End Set
    End Property

    Public Property Unit() As String
        Get
            Return Unit_Renamed
        End Get
        Set(ByVal value As String)
            Unit_Renamed = value

            If unitNameHash IsNot Nothing AndAlso unitNameHash.ContainsKey(Unit_Renamed) Then
                UnitName = CType(unitNameHash.Item(Unit_Renamed), String).Trim
            Else
                UnitName = Unit_Renamed
            End If

        End Set
    End Property

    '純顯示名稱
    Public Property UnitName() As String
        Get
            Return Unit_Name_Renamed
        End Get
        Set(ByVal value As String)
            Unit_Name_Renamed = value
        End Set
    End Property

    Public Property CountO() As Boolean
        Get
            Return CountO_Renamed
        End Get
        Set(ByVal value As Boolean)
            CountO_Renamed = value
        End Set
    End Property

    Public Property CountE() As Boolean
        Get
            Return CountE_Renamed
        End Get
        Set(ByVal value As Boolean)
            CountE_Renamed = value
        End Set
    End Property

    Public Property CountI() As Boolean
        Get
            Return CountI_Renamed
        End Get
        Set(ByVal value As Boolean)
            CountI_Renamed = value
        End Set
    End Property

    Public Property LogicSymbol() As String
        Get
            Return LogicSymbol_Renamed
        End Get
        Set(ByVal value As String)
            LogicSymbol_Renamed = value
            If condNameHash IsNot Nothing AndAlso condNameHash.ContainsKey(LogicSymbol_Renamed) Then
                LogicSymbolName = CType(condNameHash.Item(LogicSymbol_Renamed), String).Trim
            Else
                LogicSymbolName = LogicSymbol_Renamed
            End If
        End Set
    End Property

    '純顯示名稱
    Public Property LogicSymbolName() As String
        Get
            Return LogicSymbol_Name_Renamed
        End Get
        Set(ByVal value As String)
            LogicSymbol_Name_Renamed = value
        End Set
    End Property

    Public Property IsByPassCheck() As Boolean
        Get
            Return IsByPassCheck_Renamed
        End Get
        Set(ByVal value As Boolean)
            IsByPassCheck_Renamed = value
        End Set
    End Property
    Public Property IsPriorReview() As Boolean
        Get
            Return IsPriorReview_Renamed
        End Get
        Set(ByVal value As Boolean)
            IsPriorReview_Renamed = value
        End Set
    End Property

    Public Property InputNoticeLabel() As String
        Get
            Return InputNoticeLabel_Renamed
        End Get
        Set(ByVal value As String)
            InputNoticeLabel_Renamed = value
        End Set
    End Property

End Class

