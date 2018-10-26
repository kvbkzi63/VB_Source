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


Public Class UCLDistOpenWindowUC

#Region "全域變數宣告"



   
    Dim MyParent As UCLAddressUC
    Dim ShowTreeViewField As uclFieldData
    Dim ShowType = uclShowData.showDist
#End Region

#Region "20090415 add by James ,共用元件  戶籍查詢視窗"


    Sub New()
        ' 此為 Windows Form 設計工具所需的呼叫。
        InitializeComponent()
    End Sub

    Enum uclFieldData
        Code = 1   '1:顯示行政區代碼
        Name = 2     '2:顯示戶籍地號代碼
        CodeAndName = 3     '2:顯示戶籍地號代碼
    End Enum

    Enum uclShowData
        showDist = 1   '1:顯示行政區代碼
        showPostal = 2     '2:顯示戶籍地號代碼
        showArea = 3     '2:顯示戶籍地號代碼
    End Enum

    ''' <summary>
    ''' 戶籍查詢視窗初始化畫面
    ''' </summary>
    ''' <remarks></remarks>''' 
    Sub New(ByVal ds As DataSet, ByVal parent1 As UCLAddressUC, ByVal SecondLevelCount As Integer, ByVal showTreeViewField As uclFieldData, ByVal showType As uclShowData)
        ' 此為 Windows Form 設計工具所需的呼叫。
        InitializeComponent()
        Dim currentCountryCode As String = ""
        Dim currentSecondLevelCode As String = ""

        Try
            MyParent = parent1
            Me.ShowTreeViewField = showTreeViewField
            Me.ShowType = showType
            If ds IsNot Nothing Then

            Dim rootNode(getCountryCount(ds) - 1) As TreeNode
            Dim secondLevelNode(SecondLevelCount) As TreeNode
            Dim leafNode(ds.Tables(0).Rows.Count - 1) As TreeNode

            Dim i As Integer = 0  ' rootNode index
            Dim j As Integer = 0  ' leafNode index
            Dim k As Integer = 0  ' leafNode index

            Dim currentRootIndex As Integer = 0
            Dim currentSecondIndex As Integer = 0

            For Each dr As DataRow In ds.Tables(0).Rows
                ''treeview 第一層
                If dr.Item(7).ToString.Trim() <> currentCountryCode Then

                    rootNode(i) = New TreeNode
                    secondLevelNode(j) = New TreeNode
                    leafNode(k) = New TreeNode


                    TreeView_Area.Nodes.Add(rootNode(i))
                    rootNode(i).Nodes.Add(secondLevelNode(j))
                    secondLevelNode(j).Nodes.Add(leafNode(k))

                    If showTreeViewField = uclFieldData.Name Then
                        rootNode(i).Text = dr.Item(8).ToString.Trim()
                        secondLevelNode(j).Text = dr.Item(10).ToString.Trim()
                        leafNode(k).Text = dr.Item(12).ToString.Trim()

                    ElseIf showTreeViewField = uclFieldData.CodeAndName Then
                        rootNode(i).Text = dr.Item(7).ToString.Trim() & "-" & dr.Item(8).ToString.Trim()
                        secondLevelNode(j).Text = dr.Item(9).ToString.Trim() & "-" & dr.Item(10).ToString.Trim()
                        leafNode(k).Text = dr.Item(11).ToString.Trim() & "-" & dr.Item(12).ToString.Trim()

                    End If


                    rootNode(i).Tag = dr.Item(7).ToString.Trim()
                    secondLevelNode(j).Tag = dr.Item(7).ToString.Trim() & "/" & dr.Item(9).ToString.Trim()
                    leafNode(k).Tag = dr.Item(7).ToString.Trim() & "/" & dr.Item(9).ToString.Trim() & "/" & dr.Item(11).ToString.Trim()

                    currentCountryCode = dr.Item(7).ToString.Trim()
                    currentSecondLevelCode = dr.Item(9).ToString.Trim()
                    currentRootIndex = i
                    currentSecondIndex = j

                    i = i + 1
                    j = j + 1
                    k = k + 1


                Else
                    'treeview 第二層

                    If dr.Item(9).ToString.Trim() <> currentSecondLevelCode Then
                        secondLevelNode(j) = New TreeNode
                        leafNode(k) = New TreeNode

                        secondLevelNode(j).Nodes.Add(leafNode(k))
                        rootNode(currentRootIndex).Nodes.Add(secondLevelNode(j))

                        If showTreeViewField = uclFieldData.Name Then
                            secondLevelNode(j).Text = dr.Item(10).ToString.Trim()
                            leafNode(k).Text = dr.Item(12).ToString.Trim()

                        ElseIf showTreeViewField = uclFieldData.CodeAndName Then
                            secondLevelNode(j).Text = dr.Item(9).ToString.Trim() & "-" & dr.Item(10).ToString.Trim()
                            leafNode(k).Text = dr.Item(11).ToString.Trim() & "-" & dr.Item(12).ToString.Trim()

                        End If


                        secondLevelNode(j).Tag = dr.Item(7).ToString.Trim() & "/" & dr.Item(9).ToString.Trim()
                        leafNode(k).Tag = dr.Item(7).ToString.Trim() & "/" & dr.Item(9).ToString.Trim() & "/" & dr.Item(11).ToString.Trim()


                        currentSecondLevelCode = dr.Item(9).ToString.Trim()
                        currentSecondIndex = j
                        j = j + 1
                        k = k + 1
                    Else
                        leafNode(k) = New TreeNode

                        secondLevelNode(currentSecondIndex).Nodes.Add(leafNode(k))

                        If showTreeViewField = uclFieldData.Name Then
                            leafNode(k).Text = dr.Item(12).ToString.Trim()
                        ElseIf showTreeViewField = uclFieldData.CodeAndName Then
                            leafNode(k).Text = dr.Item(11).ToString.Trim() & "-" & dr.Item(12).ToString.Trim()
                        End If

                        leafNode(k).Tag = dr.Item(7).ToString.Trim() & "/" & dr.Item(9).ToString.Trim() & "/" & dr.Item(11).ToString.Trim()


                        k = k + 1
                    End If


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
            If dr.Item(7).ToString.Trim() <> tempStr Then
                count = count + 1
                tempStr = dr.Item(7).ToString.Trim()
            End If
        Next
        Return count
    End Function



#Region "Event"

    Private Sub TreeView_Area_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TreeView_Area.DoubleClick
        '啟動EventManager的RaiseEvent
        If TreeView_Area.SelectedNode.Parent IsNot Nothing Then
            Dim code1 As String = ""
            Dim code2 As String = ""

            Dim str As String() = Split(TreeView_Area.SelectedNode.FullPath, "/")
            Dim strValue As String() = Split(TreeView_Area.SelectedNode.Tag, "/")

            If strValue.Count = 2 Then

                MyParent.SetCboValue(strValue(1).Trim, "", Me.ShowType)
            ElseIf strValue.Count = 3 Then
                MyParent.SetCboValue(strValue(1).Trim, strValue(2).Trim, Me.ShowType)
            End If

            'MyParent.SetCboValue()
            Me.Close()
        End If

    End Sub

#End Region

#End Region

End Class
