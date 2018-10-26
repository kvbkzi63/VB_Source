'=============================================================================
'========================== 凌群電腦 Syscom ==================================
'=============================================================================
'=======
'======= 程式名稱：TreeView List
'=======
'======= 程式說明：TreeView List
'=======
'======= 建立日期：2011.11.28
'=======
'======= 開發人員：Yaya
'=======
'=============================================================================
'=============================================================================
'=============================================================================

Imports Syscom.Comm.EXP
Imports Syscom.Comm.Utility
Imports Syscom.Comm.LOG
Imports System.Text

Public Class UCLTreeViewAdvUC

#Region "參數設定"

    Private _treeViewName As String = ""
    Private _treeViewSource As DataTable
    Private IsNodeClick As Boolean = False
    Private IsDoubleClick As Boolean = False
    Private selectedItems As Hashtable
    Private g_dtSelectedItems As DataTable
    Private g_dtSelectedItems_temp As DataTable
    Private _IsShowGroupCheckBox As Boolean = False
    Private _treeNodeName As String = ""
    Private LastCheck As Date = DateTime.Now.AddMilliseconds(-500)
    Private LastNode As TreeNode = Nothing

#End Region

#Region "Property"

    ''' <summary>
    ''' TreeView名稱
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property TreeViewName() As String
        Get
            Return _treeViewName
        End Get
        Set(ByVal value As String)
            _treeViewName = value
        End Set
    End Property

    ''' <summary>
    ''' TreeView來源
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property TreeViewSource() As DataTable
        Get
            Return _treeViewSource
        End Get
        Set(ByVal value As DataTable)
            _treeViewSource = value
        End Set
    End Property

    ''' <summary>
    ''' 目前選取的資料
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SelectedResult() As Hashtable
        Get
            Return selectedItems
        End Get
        Set(ByVal value As Hashtable)
            selectedItems = value
        End Set
    End Property

    ''' <summary>
    ''' 目前選取的項目資料
    ''' </summary>
    ''' <value></value>
    ''' <returns>DataTable</returns>
    ''' <remarks></remarks>
    Public Property SelectedItemsResult() As DataTable
        Get
            Return g_dtSelectedItems
        End Get
        Set(ByVal value As DataTable)
            g_dtSelectedItems = value
        End Set
    End Property

    ''' <summary>
    ''' 目前暫時勾選的項目資料(尚未確認)
    ''' </summary>
    ''' <value></value>
    ''' <returns>DataTable</returns>
    ''' <remarks></remarks>
    Public Property SelectedTempItemsResult() As DataTable
        Get
            Return g_dtSelectedItems_temp
        End Get
        Set(ByVal value As DataTable)
            g_dtSelectedItems_temp = value
        End Set
    End Property

    Public Property IsShowGroupCheckBox() As Boolean
        Get
            Return _IsShowGroupCheckBox
        End Get
        Set(ByVal value As Boolean)
            _IsShowGroupCheckBox = value
        End Set
    End Property

#End Region

#Region "自定義Event"

    Public Event SelectedItem(ByVal selectedNode As TreeNode)
    Public Event RemoveItem(ByVal removeNode As TreeNode)
    Public Event NodeClick(ByVal node As TreeNode)
    Public Event BeforeCheck(ByVal selectedNode As TreeNode, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs)

#End Region

#Region "Event"

    ''' <summary>
    ''' checkbox勾選前事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>by yaya on 2102-4-5</remarks>
    Private Sub tre_TreeViewAdv_BeforeCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles tre_TreeViewAdv.BeforeCheck
        Try
            RaiseEvent BeforeCheck(e.Node, e)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {TreeViewName & "勾選(前)"})
        Finally
            If IsDoubleClick Then
                IsDoubleClick = False
            End If
        End Try
    End Sub

    ''' <summary>
    ''' 判斷treeview勾選狀況
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tre_TreeViewAdv_AfterCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tre_TreeViewAdv.AfterCheck
        Try
            Dim doChildChange As Boolean = False
            If e.Node.Checked = True Then
                e.Node.Expand()
                e.Node.EnsureVisible()
            End If

            If _treeNodeName.Equals("") Then
                _treeNodeName = e.Node.Name
            End If

            If e.Node.Parent IsNot Nothing AndAlso e.Node.Checked = False AndAlso e.Node.Parent.Nodes.Find(_treeNodeName, True).Count > 0 Then
                e.Node.Parent.Checked = False
            End If

            If e.Node.Name = _treeNodeName Then
                doChildChange = True
            Else
                If e.Node.Nodes.Count > 0 AndAlso e.Node.Nodes.Find(_treeNodeName, True).Count > 0 Then
                    doChildChange = False
                Else
                    doChildChange = True
                End If
            End If

            If doChildChange Then
                For Each node As TreeNode In e.Node.Nodes
                    node.Checked = e.Node.Checked
                Next
            End If

            If e.Node.Nodes.Count = 0 Then
                If e.Node.Checked Then
                    RaiseEvent SelectedItem(e.Node)
                Else
                    RaiseEvent RemoveItem(e.Node)
                End If
            End If

            If e.Node.Name.Equals(_treeNodeName) Then
                _treeNodeName = ""
            End If
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {TreeViewName & "勾選(後)"})
        End Try
    End Sub

    ''' <summary>
    ''' 點選最底層的資料
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tre_TreeViewAdv_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tre_TreeViewAdv.AfterSelect
        Try
            If IsNodeClick Then
                Dim lastNode As TreeNode = DirectCast(e.Node, TreeNode)
                'Nothing 表示到達最底層
                If lastNode.LastNode Is Nothing Then
                    RaiseEvent NodeClick(lastNode)
                End If
            End If
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {TreeViewName & "選取內容"})
        End Try
    End Sub

    ''' <summary>
    ''' 點選樹狀結構節點
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tre_TreeViewAdv_NodeMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles tre_TreeViewAdv.NodeMouseClick
        Dim NowCheck As Date = DateTime.Now
        If LastNode Is Nothing Then
            LastNode = e.Node
            IsDoubleClick = False
        ElseIf LastNode.Equals(e.Node) Then
            If (NowCheck - LastCheck).Seconds = 0 AndAlso (NowCheck - LastCheck).Milliseconds <= SystemInformation.DoubleClickTime Then
                If e.Node.Nodes.Count = 0 Then
                    If e.Node.Checked Then
                        RaiseEvent RemoveItem(e.Node)
                    Else
                        RaiseEvent SelectedItem(e.Node)
                    End If
                End If
                IsDoubleClick = True
            End If
        Else
            LastNode = e.Node
            IsDoubleClick = False
        End If
        LastCheck = NowCheck
    End Sub

#End Region

#Region "外部呼叫"

    ''' <summary>
    ''' 取得勾選項目(HashTable)
    ''' </summary>
    ''' <param name="IncludeRootNode">是否包含根節點</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetSelectedItemsResultInHashTable(ByVal IncludeRootNode As Boolean) As Hashtable
        Try
            selectedItems = New Hashtable
            getSelectedNodesForHashTable(tre_TreeViewAdv.Nodes, IncludeRootNode)
            Return selectedItems
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {TreeViewName & "取得勾選項目(HashTable)"})
        End Try
    End Function

    ''' <summary>
    ''' 取得勾選項目(DataTable)
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetSelectedItemsResultInDataTable(ByVal IncludeRootNode As Boolean) As DataTable
        Try
            g_dtSelectedItems = New DataTable
            g_dtSelectedItems.Columns.Add("Parent_Code_Id")
            g_dtSelectedItems.Columns.Add("Parent_Code_Name")
            g_dtSelectedItems.Columns.Add("Layer_Code_Id")
            g_dtSelectedItems.Columns.Add("Layer_Code_Name")
            getSelectedNodesForDataTable(tre_TreeViewAdv.Nodes, IncludeRootNode)
            Return g_dtSelectedItems
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {TreeViewName & "取得勾選項目(DataTable)"})
        End Try
    End Function

    ''' <summary>
    ''' 根據填入的DataTable資料產生TreeView
    ''' </summary>
    ''' <param name="datasource">資料集</param>
    ''' <param name="parentFieldName">父類別欄位名稱</param>
    ''' <param name="parentFieldText">父類別的值</param>
    ''' <param name="nodeFieldName">節點的欄位名稱</param>
    ''' <param name="nodeFieldText">節點顯示的欄位名稱</param>
    ''' <param name="isCheckBox">是否要顯示CheckBox</param>
    ''' <remarks></remarks>
    Public Sub SetTreeView(ByVal datasource As DataTable, ByVal parentFieldName As String, ByVal parentFieldText As String, _
                             ByVal nodeFieldName As String, ByVal nodeFieldText As String, Optional ByVal isCheckBox As Boolean = True)
        Try
            If isCheckBox Then
                IsNodeClick = False
            Else
                IsNodeClick = True
            End If
            If IsShowGroupCheckBox Then
                chk_Group.Checked = False
                pal_Condition.Visible = True
            Else
                chk_Group.Checked = False
                pal_Condition.Visible = False
            End If
            ClearAllNodes()
            If datasource IsNot Nothing Then
                _treeViewSource = datasource
                CreateTreeView(parentFieldName, parentFieldText, nodeFieldName, nodeFieldText, isCheckBox)
            End If
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {TreeViewName & "畫面初始化"})
        End Try
    End Sub

    ''' <summary>
    ''' 取消選取項目
    ''' </summary>
    ''' <param name="nodeValue">節點名稱</param>
    ''' <param name="searchAllChildren">是否要搜尋所有的子節點</param>
    ''' <remarks></remarks>
    Public Sub UnSelectedItem(ByVal nodeValue As String, Optional ByVal searchAllChildren As Boolean = True)
        Try
            For Each node As TreeNode In tre_TreeViewAdv.Nodes.Find(nodeValue, searchAllChildren)
                node.Checked = False
            Next
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {TreeViewName & "取消選取項目"})
        End Try
    End Sub

    ''' <summary>
    ''' 選取項目
    ''' </summary>
    ''' <param name="nodeValue">節點名稱</param>
    ''' <param name="searchAllChildren">是否要搜尋所有的子節點</param>
    ''' <remarks></remarks>
    Public Sub SelectedNodeItem(ByVal nodeValue As String, Optional ByVal searchAllChildren As Boolean = True)
        Try
            For Each node As TreeNode In tre_TreeViewAdv.Nodes.Find(nodeValue, searchAllChildren)
                node.Checked = True
            Next
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {TreeViewName & "取消選取項目"})
        End Try
    End Sub

    ''' <summary>
    ''' 選取項目
    ''' </summary>
    ''' <param name="fullPath">完整路徑</param>
    ''' <remarks></remarks>
    Public Sub SelectedNodeItemForPath(ByVal fullPath As String)
        Try
            For Each node As TreeNode In tre_TreeViewAdv.Nodes
                Dim Path As String = node.Tag
                Dim Target_Node As TreeNode = node

                While Target_Node.FirstNode IsNot Nothing Or Target_Node.NextNode IsNot Nothing Or (Target_Node.Parent IsNot Nothing AndAlso Target_Node.Parent.NextNode IsNot Nothing)
                    If Target_Node.FirstNode IsNot Nothing Then
                        Path &= "/" & Target_Node.FirstNode.Tag
                        Target_Node = Target_Node.FirstNode
                    End If
                    If Target_Node.FirstNode Is Nothing Then
                        If Path = fullPath Then
                            Target_Node.Checked = True
                            Exit Sub
                        Else
                            If Target_Node.NextNode IsNot Nothing Then
                                Target_Node = Target_Node.NextNode
                                Path = Path.Substring(0, Path.LastIndexOf("/") + 1) & Target_Node.Tag
                            Else
                                If Target_Node.Parent IsNot Nothing AndAlso Target_Node.Parent.NextNode IsNot Nothing Then
                                    Target_Node = Target_Node.Parent.NextNode
                                    Path = node.Tag & "/" & Target_Node.Tag
                                End If
                            End If
                        End If
                    End If
                End While

                If Path = fullPath Then
                    Target_Node.Checked = True
                    Exit Sub
                End If
            Next
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {TreeViewName & "取消選取項目"})
        End Try
    End Sub

    ''' <summary>
    ''' 清除全部勾選的資料
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ClearAllChecked()
        Try
            Dim node As TreeNodeCollection = tre_TreeViewAdv.Nodes
            For i As Integer = 0 To node.Count - 1
                DirectCast(node(i), TreeNode).Checked = False
            Next
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {TreeViewName & "清除"})
        End Try
    End Sub

    ''' <summary>
    ''' 清除TreeView節點資料
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ClearAllNodes()
        Try
            tre_TreeViewAdv.Nodes.Clear()
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {TreeViewName & "清除"})
        End Try
    End Sub

    ''' <summary>
    ''' 收合所有樹狀節點
    ''' </summary>
    ''' <remarks>by yaya on 2012-04-01</remarks>
    Public Sub CollapseAll()
        Try
            If tre_TreeViewAdv IsNot Nothing Then tre_TreeViewAdv.CollapseAll()
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {TreeViewName & "收合所有樹狀節點"})
        End Try
    End Sub

    ''' <summary>
    ''' 展開所有樹狀節點
    ''' </summary>
    ''' <remarks>by yaya on 2012-04-01</remarks>
    Public Sub ExpandAll()
        Try
            If tre_TreeViewAdv IsNot Nothing Then tre_TreeViewAdv.ExpandAll()
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {TreeViewName & "收合所有樹狀節點"})
        End Try
    End Sub

    ''' <summary>
    ''' 清除選取的項目資料
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ClearSelectedItemsResult()
        Try
            If SelectedItemsResult IsNot Nothing Then
                SelectedItemsResult.Clear()
                SelectedItemsResult = Nothing
            End If
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {TreeViewName & "清除選取的項目資料"})
        End Try
    End Sub

    ''' <summary>
    ''' 清除選取的項目資料(尚未確認)
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ClearSelectedTempItemsResult()
        Try
            If SelectedTempItemsResult IsNot Nothing Then
                SelectedTempItemsResult.Clear()
                SelectedTempItemsResult = Nothing
            End If
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {TreeViewName & "清除選取的項目資料(尚未確認)"})
        End Try
    End Sub

#End Region

#Region "Find By Text"

    Public Sub ExpandNodeByTop()
        tre_TreeViewAdv.Nodes(0).Expand()

    End Sub
    ''' <summary>
    ''' 搜尋項目資料(TreeView 文字)
    ''' </summary>
    ''' <param name="txt"></param>
    ''' <remarks></remarks>
    Public Sub search_TxtName(ByVal txt As String)

        ClearBackColor()
        FindByText(txt)

    End Sub

    Private Sub FindByText(ByVal txt As String)
        Dim nodes As TreeNodeCollection = tre_TreeViewAdv.Nodes
        Dim n As TreeNode
        For Each n In nodes
            FindRecursive(n, txt)
        Next
    End Sub

    Private Sub FindRecursive(ByVal tNode As TreeNode, ByVal txt As String)

        Dim tn As TreeNode
        For Each tn In tNode.Nodes

            ' if the text properties match, color the item
            If tn.Text = txt Then
                tn.BackColor = Color.Yellow
                tNode.Expand()
                If tNode.Parent.Name <> "" Then
                    tNode.Parent.Expand()
                End If
            End If

            FindRecursive(tn, txt)
        Next

    End Sub

#End Region

#Region "Remove BackColor"

    'recursively move through the treeview nodes
    'and reset backcolors to white
    Private Sub ClearBackColor()

        Dim nodes As TreeNodeCollection
        nodes = tre_TreeViewAdv.Nodes
        Dim n As TreeNode

        For Each n In nodes
            ClearRecursive(n)
        Next

    End Sub

    'called by ClearBackColor function
    Private Sub ClearRecursive(ByVal treeNode As TreeNode)

        Dim tn As TreeNode

        For Each tn In treeNode.Nodes
            tn.BackColor = Color.White
            ClearRecursive(tn)
        Next

    End Sub

#End Region

#Region "自定義功能"



#Region "Create TreeView"

    ''' <summary>
    ''' 建立TreeView
    ''' </summary>
    ''' <param name="parentFieldName">父類別欄位名稱</param>
    ''' <param name="parentFieldText">父類別的值</param>
    ''' <param name="nodeFieldName">節點的欄位名稱</param>
    ''' <param name="nodeFieldText">節點顯示的欄位名稱</param>
    ''' <param name="isCheckBox">是否要顯示CheckBox</param>
    ''' <remarks></remarks>
    Private Sub CreateTreeView(ByRef parentFieldName As String, ByRef parentFieldText As String, _
                             ByRef nodeFieldName As String, ByRef nodeFieldText As String, Optional ByRef isCheckBox As Boolean = True)
        Try
            '判斷是否要有checkbox
            tre_TreeViewAdv.CheckBoxes = isCheckBox
            AddNodes(Nothing, parentFieldName, parentFieldText, nodeFieldName, nodeFieldText)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {TreeViewName & "建立 TreeView"})
        End Try
    End Sub

    ''' <summary>
    ''' 加入TreeView節點
    ''' </summary>
    ''' <param name="parentFieldName">父類別欄位名稱</param>
    ''' <param name="parentFieldText">父類別的值</param>
    ''' <param name="nodeFieldName">節點的欄位名稱</param>
    ''' <param name="nodeFieldText">節點顯示的欄位名稱</param>
    ''' <remarks></remarks>
    Private Sub AddNodes(ByRef node As TreeNode, ByRef parentFieldName As String, ByRef parentFieldText As String, ByRef nodeFieldName As String, ByRef nodeFieldText As String)
        Try
            Dim text As String = ""
            Dim value As String = ""
            If node IsNot Nothing Then
                text = node.Text
                value = node.Tag
            End If
            Dim rows() As DataRow = _treeViewSource.Select(parentFieldName & "='" & value & "'")
            For Each row As DataRow In rows
                Dim nNode As New TreeNode
                nNode.Name = StringUtil.nvl(row(nodeFieldName))
                nNode.Text = StringUtil.nvl(row(nodeFieldText))
                nNode.Tag = StringUtil.nvl(row(nodeFieldName))
                nNode.ToolTipText = StringUtil.nvl(row(nodeFieldName))
                If node IsNot Nothing Then
                    node.Nodes.Add(nNode)
                Else
                    tre_TreeViewAdv.Nodes.Add(nNode)
                End If
                AddNodes(nNode, parentFieldName, parentFieldText, nodeFieldName, nodeFieldText)
            Next
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {TreeViewName & "加入 TreeView 節點"})
        End Try
    End Sub

#End Region

#Region "Get TreeView"

    ''' <summary>
    ''' 儲存勾選的 HashTable
    ''' </summary>
    ''' <param name="nodeCollection"></param>
    ''' <remarks></remarks>
    Private Sub getSelectedNodesForHashTable(ByVal nodeCollection As TreeNodeCollection, ByVal IncludeRootNode As Boolean)
        Try
            For Each node As TreeNode In nodeCollection
                If node.Nodes.Count <> 0 Then
                    If IncludeRootNode Then
                        If node.Checked = True Then
                            selectedItems.Add(node.Tag, node.Tag)
                        End If
                    End If
                    getSelectedNodesForHashTable(node.Nodes, IncludeRootNode)
                Else
                    If node.Checked = True Then
                        selectedItems.Add(node.Tag, node.Tag)
                    End If
                End If
            Next
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {TreeViewName & "取得節點資料"})
        End Try
    End Sub

    ''' <summary>
    ''' 儲存勾選的 DataTable
    ''' </summary>
    ''' <param name="nodeCollection"></param>
    ''' <remarks></remarks>
    Private Sub getSelectedNodesForDataTable(ByVal nodeCollection As TreeNodeCollection, ByVal IncludeRootNode As Boolean)
        Try
            For Each node As TreeNode In nodeCollection
                If node.Nodes.Count <> 0 Then
                    If IncludeRootNode Then
                        If node.Checked = True Then
                            If node.Parent Is Nothing Then
                                g_dtSelectedItems.Rows.Add(New String() {"", "", node.Tag, node.Text})
                            Else
                                g_dtSelectedItems.Rows.Add(New String() {node.Parent.Tag, node.Parent.Text, node.Tag, node.Text})
                            End If

                        End If
                    End If
                    getSelectedNodesForDataTable(node.Nodes, IncludeRootNode)
                Else
                    If node.Checked = True Then
                        g_dtSelectedItems.Rows.Add(New String() {node.Parent.Tag, node.Parent.Text, node.Tag, node.Text})
                    End If
                End If
            Next
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {TreeViewName & "取得節點資料"})
        End Try
    End Sub

#End Region

#End Region

End Class
