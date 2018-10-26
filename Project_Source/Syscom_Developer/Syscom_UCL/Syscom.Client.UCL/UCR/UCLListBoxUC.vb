Imports Syscom.Client.servicefactory
Imports System.Windows.Forms
Imports Syscom.Client.cmm
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
Imports Syscom.Comm.log
Imports System.Text

Public Class UCLListBoxUC


#Region "全域變數宣告"

    Private _uclItemShowFieldIndexStr As String
    Private _uclCodeFieldIndexStr As String
    Private _uclNameFieldIndexStr As String
    Private _uclSeparator = uclSeparatorType.OneSpace_Dash_OneSpace

    Private _uclSelectedItemIndex As String
    Private _uclNonSelectedItemIndex As String = ""
    Private _uclSelectionMode = uclSelectionStyle.One

    Private _Items As System.Windows.Forms.ListBox.ObjectCollection

    Dim ds As DataSet

    Dim SeparatorStr As String
    Dim SeparatorType As uclSeparatorType

#End Region

#Region "屬性設定"

    ''' <summary>
    ''' Grid上的資料顯示連結方式
    ''' </summary>
    ''' <remarks></remarks>
    Enum uclSeparatorType

        OneSpace = 1 ' " "
        OneSpace_Dash_OneSpace = 2  '  " - "

    End Enum

    ''' <summary>
    ''' 設定元件是否可以單選或多選
    ''' </summary>
    ''' <remarks></remarks>
    Enum uclSelectionStyle

        One = 1 ' 單選
        Multi_Simple = 2  '  多選
        Multi_Extend = 3 ' ctrl可控制單多選
    End Enum

    ''' <summary>
    ''' 取得元件內所有項目集合
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Items() As System.Windows.Forms.ListBox.ObjectCollection
        Get
            Return ListBox1.Items
        End Get

    End Property

    ''' <summary>
    ''' 設定顯示的方式
    ''' 1. 中間以空白字串連結
    ''' 2. 中間以'-'連結
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property uclSeparator() As uclSeparatorType
        Get
            Return _uclSeparator
        End Get
        Set(ByVal value As uclSeparatorType)
            _uclSeparator = value
        End Set
    End Property

    ''' <summary>
    ''' 設定元件的選擇模式
    ''' 1=單選, 2=多選,3=ctrl可控制單多選
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property uclSelectionMode() As uclSelectionStyle
        Get
            Return _uclSelectionMode
        End Get
        Set(ByVal value As uclSelectionStyle)
            _uclSelectionMode = value

            If _uclSelectionMode = uclSelectionStyle.One Then
                ListBox1.SelectionMode = SelectionMode.One
            ElseIf _uclSelectionMode = uclSelectionStyle.Multi_Extend Then
                ListBox1.SelectionMode = SelectionMode.MultiExtended
            ElseIf _uclSelectionMode = uclSelectionStyle.Multi_Simple Then
                ListBox1.SelectionMode = SelectionMode.MultiSimple
            Else
                ListBox1.SelectionMode = SelectionMode.None
            End If

        End Set
    End Property

    ''' <summary>
    ''' 設定要顯示在畫面上的欄位是在Ds內的Index 用','號區隔開來，需輸入數字字串
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property uclItemShowFieldIndexStr() As String
        Get
            Return _uclItemShowFieldIndexStr
        End Get
        Set(ByVal value As String)
            _uclItemShowFieldIndexStr = value
        End Set
    End Property

    ''' <summary>
    ''' 設定Value是在哪個欄位的Index
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property uclCodeFieldIndexStr() As String
        Get
            Return _uclCodeFieldIndexStr
        End Get
        Set(ByVal value As String)
            _uclCodeFieldIndexStr = value
        End Set
    End Property

    ''' <summary>
    ''' 設定Name欄位的Index
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property uclNameFieldIndexStr() As String
        Get
            Return _uclNameFieldIndexStr
        End Get
        Set(ByVal value As String)
            _uclNameFieldIndexStr = value
        End Set
    End Property

    ''' <summary>
    ''' 內部用於取得被選取的項目Index
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property uclSelectedItemIndex() As String
        Get
            _uclSelectedItemIndex = ""
            For i As Integer = 0 To ListBox1.SelectedIndices.Count - 1
                If i = ListBox1.SelectedIndices.Count - 1 Then
                    _uclSelectedItemIndex += ListBox1.SelectedIndices(i).ToString()
                Else
                    _uclSelectedItemIndex += ListBox1.SelectedIndices(i).ToString() & ","
                End If

            Next

            Return _uclSelectedItemIndex
        End Get
        Set(ByVal value As String)

            '    _uclNameFieldIndexStr = value
        End Set
    End Property

    ''' <summary>
    ''' 內部用於取得未被選取的項目Index
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property uclNonSelectedItemIndex() As String

        Get

            _uclNonSelectedItemIndex = ""

            For i As Integer = 1 To ListBox1.Items.Count

                If i < ListBox1.Items.Count Then

                    If Not GetItemChecked(i - 1) Then

                        _uclNonSelectedItemIndex += i.ToString() & ","

                    End If

                Else

                    If Not GetItemChecked(i - 1) Then

                        _uclNonSelectedItemIndex += i.ToString()

                    End If

                End If

            Next

            Return _uclNonSelectedItemIndex

        End Get

        Set(ByVal value As String)

            '    _uclNameFieldIndexStr = value

        End Set

    End Property

#End Region

#Region "初始化"
    ''' <summary>
    ''' 初始化設定
    ''' dsSource:來源資料
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Initial(ByVal dsSource As DataSet)
        Try


            ListBox1.Items.Clear()

            Select Case _uclSeparator
                Case uclSeparatorType.OneSpace
                    SeparatorStr = " "
                Case uclSeparatorType.OneSpace_Dash_OneSpace
                    SeparatorStr = " - "
            End Select
            If dsSource IsNot Nothing Then


                ds = dsSource
                processTable(ds)
            End If

        Catch ex As Exception
            Console.WriteLine(ex.ToString)   'Syscom.Client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub
#End Region

#Region "外部函數"


    ''' <summary>
    ''' 取得未選取的項目代碼
    ''' </summary>
    ''' <returns>項目代碼陣列</returns>
    ''' <remarks></remarks>''' 
    Public Function GetNonSelectedItemCodes() As String()
        Try

            If _uclCodeFieldIndexStr.Trim() <> "" Then


                Dim codeIndex As String() = Split(Me.uclCodeFieldIndexStr, ",")
                Dim nonSelectedIndex As String() = Split(Me.uclNonSelectedItemIndex, ",")
                Dim temp As String = ""

                If nonSelectedIndex.Length > 0 AndAlso uclNonSelectedItemIndex <> "" Then
                    Dim str(nonSelectedIndex.Length - 1) As String

                    For i As Integer = 0 To nonSelectedIndex.Length - 1
                        For j As Integer = 0 To codeIndex.Length - 1

                            If j < codeIndex.Length - 1 Then
                                temp += ds.Tables(0).Rows(CType(nonSelectedIndex(i), Integer) - 1).Item(CType(codeIndex(j), Integer)).ToString().Trim() & ","
                            Else
                                temp += ds.Tables(0).Rows(CType(nonSelectedIndex(i), Integer) - 1).Item(CType(codeIndex(j), Integer)).ToString().Trim()
                            End If
                        Next
                        str(i) = temp
                        temp = ""
                    Next
                    Return str
                End If

            End If
            Return Nothing
        Catch ex As Exception
            Console.WriteLine(ex.ToString)   'Syscom.Client.cmm.ClientExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try

    End Function


    ''' <summary>
    ''' 取得未選取的項目名稱
    ''' </summary>
    ''' <returns>項目名稱陣列</returns>
    ''' <remarks></remarks>''' 
    Public Function GetNonSelectedItemNames() As String()
        Try
            If _uclNameFieldIndexStr.Trim() <> "" Then


                Dim nameIndex As String() = Split(Me.uclNameFieldIndexStr, ",")
                Dim nonSelectedIndex As String() = Split(Me.uclNonSelectedItemIndex, ",")
                Dim temp As String = ""

                If nonSelectedIndex.Length > 0 AndAlso uclNonSelectedItemIndex <> "" Then
                    Dim str(nonSelectedIndex.Length - 1) As String

                    For i As Integer = 0 To nonSelectedIndex.Length - 1
                        For j As Integer = 0 To nameIndex.Length - 1
                            If j < nameIndex.Length - 1 Then
                                temp += ds.Tables(0).Rows(CType(nonSelectedIndex(i), Integer) - 1).Item(CType(nameIndex(j), Integer)).ToString().Trim() & ","
                            Else
                                temp += ds.Tables(0).Rows(CType(nonSelectedIndex(i), Integer) - 1).Item(CType(nameIndex(j), Integer)).ToString().Trim()
                            End If
                        Next
                        str(i) = temp
                        temp = ""
                    Next
                    Return str
                End If


            End If
            Return Nothing
        Catch ex As Exception
            Console.WriteLine(ex.ToString)   'Syscom.Client.cmm.ClientExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try

    End Function



    ''' <summary>
    ''' 取得選取的項目代碼
    ''' </summary>
    ''' <returns>項目代碼陣列</returns>
    ''' <remarks></remarks>''' 
    Public Function GetSelectedItemCodes() As String()
        Try
            If _uclCodeFieldIndexStr.Trim() <> "" Then


                Dim codeIndex As String() = Split(_uclCodeFieldIndexStr, ",")
                Dim selectedIndex As String() = Split(Me.uclSelectedItemIndex, ",")
                Dim temp As String = ""
                If selectedIndex.Length > 0 AndAlso _uclSelectedItemIndex <> "" Then
                    Dim str(selectedIndex.Length - 1) As String

                    For i As Integer = 0 To selectedIndex.Length - 1
                        For j As Integer = 0 To codeIndex.Length - 1
                            If j < codeIndex.Length - 1 Then
                                temp += ds.Tables(0).Rows(CType(selectedIndex(i), Integer)).Item(CType(codeIndex(j), Integer)).ToString().Trim() & ","
                            Else
                                temp += ds.Tables(0).Rows(CType(selectedIndex(i), Integer)).Item(CType(codeIndex(j), Integer)).ToString().Trim()
                            End If
                        Next
                        str(i) = temp
                        temp = ""
                    Next
                    Return str
                End If

            End If
            Return Nothing
        Catch ex As Exception
            Console.WriteLine(ex.ToString)   'Syscom.Client.cmm.ClientExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function


    ''' <summary>
    ''' 取得選取的項目代碼
    ''' </summary>
    ''' <returns>項目代碼陣列</returns>
    ''' <remarks></remarks>''' 
    Public Function GetAllItemCodes() As String()
        Try
            If _uclCodeFieldIndexStr.Trim() <> "" Then


                Dim codeIndex As String() = Split(_uclCodeFieldIndexStr, ",")
                'Dim selectedIndex As String() = Split(Me.uclSelectedItemIndex, ",")
                Dim temp As String = ""

                Dim str(ds.Tables(0).Rows.Count - 1) As String

                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    For j As Integer = 0 To codeIndex.Length - 1
                        If j < codeIndex.Length - 1 Then
                            temp += ds.Tables(0).Rows(i).Item(CType(codeIndex(j), Integer)).ToString().Trim() & ","
                        Else
                            temp += ds.Tables(0).Rows(i).Item(CType(codeIndex(j), Integer)).ToString().Trim()
                        End If
                    Next
                    str(i) = temp
                    temp = ""
                Next
                Return str


            End If
            Return Nothing
        Catch ex As Exception
            Console.WriteLine(ex.ToString)   'Syscom.Client.cmm.ClientExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' 取得選取的項目名稱
    ''' </summary>
    ''' <returns>項目名稱陣列</returns>
    ''' <remarks></remarks>''' 
    Public Function GetSelectedItemNames() As String()
        Try
            If _uclNameFieldIndexStr.Trim() <> "" Then
                Dim nameIndex As String() = Split(_uclNameFieldIndexStr, ",")
                Dim selectedIndex As String() = Split(Me.uclSelectedItemIndex, ",")
                Dim temp As String = ""
                If selectedIndex.Length > 0 AndAlso _uclSelectedItemIndex <> "" Then
                    Dim str(selectedIndex.Length - 1) As String

                    For i As Integer = 0 To selectedIndex.Length - 1
                        For j As Integer = 0 To nameIndex.Length - 1
                            If j < nameIndex.Length - 1 Then
                                temp += ds.Tables(0).Rows(CType(selectedIndex(i), Integer)).Item(CType(nameIndex(j), Integer)).ToString().Trim() & ","
                            Else
                                temp += ds.Tables(0).Rows(CType(selectedIndex(i), Integer)).Item(CType(nameIndex(j), Integer)).ToString().Trim()
                            End If
                        Next
                        str(i) = temp
                        temp = ""
                    Next
                    Return str
                End If

            End If
            Return Nothing
        Catch ex As Exception
            Console.WriteLine(ex.ToString)   'Syscom.Client.cmm.ClientExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' 取消所有所取的項目
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ClearSelected()
        ListBox1.ClearSelected()
    End Sub

    ''' <summary>
    ''' 刪除某一個項目
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub RemoveItemAt(ByVal ItemIndex As Integer)
        If ItemIndex >= 0 AndAlso ItemIndex <= ListBox1.Items.Count - 1 Then
            ListBox1.Items.RemoveAt(ItemIndex)
            ds.Tables(0).Rows.RemoveAt(ItemIndex)
        End If
    End Sub

    ''' <summary>
    ''' 取得Item是否有勾選
    ''' </summary>
    ''' <returns>True:勾 , False:沒勾</returns>
    ''' <remarks></remarks>''' 
    Public Function GetItemChecked(ByVal index As Integer) As Boolean


        Return ListBox1.SelectedIndices.Contains(index)
    End Function

#End Region

#Region "內部函數"


    ''' <summary>
    ''' 進行資料查詢
    ''' dsSource:查詢資料
    ''' </summary>
    ''' <returns>none</returns>
    ''' <remarks></remarks>''' 
    Private Function processTable(ByVal dsSource As DataSet) As Boolean
        Try
            Dim itemStr As String = ""
            Dim temp As String = ""
            Dim strArrayShowField As String() = Split(_uclItemShowFieldIndexStr, ",")

            For row As Integer = 0 To dsSource.Tables(0).Rows.Count - 1
                For i As Integer = 0 To strArrayShowField.Length - 1

                    If i < strArrayShowField.Length - 1 AndAlso IsNumeric(strArrayShowField(i)) Then
                        temp = ""
                        temp = dsSource.Tables(0).Rows(row).Item(CType(strArrayShowField(i), Integer)).ToString().Trim()
                        itemStr += temp & SeparatorStr
                    ElseIf IsNumeric(strArrayShowField(i)) Then
                        temp = ""
                        temp = dsSource.Tables(0).Rows(row).Item(CType(strArrayShowField(i), Integer)).ToString().Trim()
                        itemStr += temp
                    End If
                Next
                ListBox1.Items.Add(itemStr)
                itemStr = ""
            Next
        Catch ex As Exception
            Console.WriteLine(ex.ToString)   'Syscom.Client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try
    End Function


#End Region

    '#Region "暫不用"

    '    'ListBox取codes  暫時不用
    '    Public Function GetSelectedItemCodes1() As String()
    '        Dim codeIndexStrs As String() = Split(_uclCodeFieldIndexStr, ",")

    '        If ListBox1.SelectedIndices.Count > 0 Then
    '            Dim str(ListBox1.SelectedIndices.Count - 1) As String
    '            For i As Integer = 0 To ListBox1.SelectedIndices.Count - 1
    '                Dim temp As String = ListBox1.SelectedItems(i)
    '                Dim itemSplit As String() = Split(temp, " ")
    '                temp = ""
    '                For j As Integer = 0 To codeIndexStrs.Length - 1
    '                    If j < codeIndexStrs.Length - 1 Then
    '                        temp += itemSplit(CType(codeIndexStrs(j), Integer)) & ","
    '                    Else
    '                        temp += itemSplit(CType(codeIndexStrs(j), Integer))
    '                    End If
    '                Next
    '                str(i) = temp
    '                temp = ""
    '            Next
    '            Return str
    '        End If
    '        Return Nothing

    '    End Function
    '    'ListBox取name  暫時不用
    '    Public Function GetSelectedItemNames1() As String()
    '        Dim nameIndexStrs As String() = Split(_uclNameFieldIndexStr, ",")

    '        If ListBox1.SelectedIndices.Count > 0 Then
    '            Dim str(ListBox1.SelectedIndices.Count - 1) As String
    '            For i As Integer = 0 To ListBox1.SelectedIndices.Count - 1
    '                Dim temp As String = ListBox1.SelectedItems(i)
    '                Dim itemSplit As String() = Split(temp, " ")
    '                temp = ""
    '                For j As Integer = 0 To nameIndexStrs.Length - 1
    '                    If j < nameIndexStrs.Length - 1 Then
    '                        temp += itemSplit(CType(nameIndexStrs(j), Integer)) & ","
    '                    Else
    '                        temp += itemSplit(CType(nameIndexStrs(j), Integer))
    '                    End If

    '                Next
    '                str(i) = temp
    '                temp = ""
    '            Next
    '            Return str
    '        End If
    '        Return Nothing
    '    End Function

    '#End Region
End Class
