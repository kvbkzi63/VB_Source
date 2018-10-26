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


Public Class UCLAreaOpenWindowUC

#Region "全域變數宣告"



    Dim WithEvents mgr As EventManager = EventManager.getInstance '宣告EventManager
    Dim nameStr As String = ""
#End Region

#Region "20090415 add by James ,共用元件  戶籍查詢視窗"


    Sub New()
        ' 此為 Windows Form 設計工具所需的呼叫。
        InitializeComponent()
    End Sub

    ''' <summary>
    ''' 戶籍查詢視窗初始化畫面
    ''' </summary>
    ''' <remarks></remarks>''' 
    Sub New(ByVal ds As DataSet, ByVal ctlName As String)
        ' 此為 Windows Form 設計工具所需的呼叫。
        InitializeComponent()
        Dim currentCountryCode As String = ""

        Try
            nameStr = ctlName
            If ds IsNot Nothing Then

                Dim rootNode(getCountryCount(ds) - 1) As TreeNode
                Dim leafNode(ds.Tables(0).Rows.Count - 1) As TreeNode

                Dim i As Integer = 0  ' rootNode index
                Dim j As Integer = 0  ' leafNode index
                Dim currentRootIndex As Integer = 0

                For Each dr As DataRow In ds.Tables(0).Rows
                    ''treeview 第一層
                    If dr.Item(2).ToString.Trim() <> currentCountryCode Then

                        rootNode(i) = New TreeNode
                        leafNode(j) = New TreeNode

                        rootNode(i).Text = dr.Item(2).ToString.Trim() '& "-" & dr.Item(6).ToString.Trim()
                        TreeView_Area.Nodes.Add(rootNode(i))

                        leafNode(j).Text = dr.Item(0).ToString.Trim() & "-" & dr.Item(4).ToString.Trim()
                        rootNode(i).Nodes.Add(leafNode(j))
                        currentCountryCode = dr.Item(2).ToString.Trim()
                        currentRootIndex = i
                        i = i + 1
                        j = j + 1

                        'treeview 第二層
                    Else
                        leafNode(j) = New TreeNode
                        leafNode(j).Text = dr.Item(0).ToString.Trim() & "-" & dr.Item(4).ToString.Trim()
                        rootNode(currentRootIndex).Nodes.Add(leafNode(j))

                    End If
                Next

                '自動展開
                'TreeView_Area.ExpandAll()
            End If
        Catch ex As Exception
            Console.WriteLine(ex.ToString)   'nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try

    End Sub


    ''' <summary>
    '''  '取得縣市數
    ''' </summary>
    ''' <returns>縣市數</returns>
    ''' <remarks></remarks>''' 
    Private Function getCountryCount(ByVal ds As DataSet) As Integer
        Dim count As Integer = 0
        Dim tempStr As String = ""
        For Each dr As DataRow In ds.Tables(0).Rows
            If dr.Item(2).ToString.Trim() <> tempStr Then
                count = count + 1
                tempStr = dr.Item(2).ToString.Trim()
            End If
        Next
        Return count
    End Function



#Region "Event"

    Private Sub TreeView_Area_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TreeView_Area.DoubleClick
        '啟動EventManager的RaiseEvent
        If TreeView_Area.SelectedNode.Parent IsNot Nothing Then
            If mgr Is Nothing Then
                mgr = EventManager.getInstance
            End If
            mgr.RaiseUclOpenAreaWindow(nameStr, TreeView_Area.SelectedNode.Text)
            Me.Close()
        End If

    End Sub

#End Region

#End Region

End Class
