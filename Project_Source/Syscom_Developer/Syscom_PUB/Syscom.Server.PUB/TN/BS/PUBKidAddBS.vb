Imports System.Data.SqlClient
Imports System.Transactions
Imports log4net
Imports Syscom.Comm.Utility

Public Class PUBKidAddBS
    Implements IDisposable

    Dim SystemDate As Date = DateUtil.getSystemDate

#Region "########## getInstance() ##########"

    'Private Shared instance As PUBKidAddBS

    Private Sub New()
    End Sub

    Public Shared Function getInstance() As PUBKidAddBS
        Try
            'If instance Is Nothing Then
            '    instance = New PUBKidAddBS
            'End If
            'Return instance

            Return New PUBKidAddBS

        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

    Private disposedValue As Boolean = False        ' 偵測多餘的呼叫

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: 釋放其他狀態 (Managed 物件)。
            End If

            ' TODO: 釋放您自己的狀態 (Unmanaged 物件)
            ' TODO: 將大型欄位設定為 null。
        End If
        Me.disposedValue = True
    End Sub

#Region " IDisposable Support "
    ' 由 Visual Basic 新增此程式碼以正確實作可處置的模式。
    Public Sub Dispose() Implements IDisposable.Dispose
        ' 請勿變更此程式碼。在以上的 Dispose 置入清除程式碼 (ByVal 視為布林值處置)。
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region


    ''' <summary>
    ''' 初始兒童加成資料
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>Add By Jen</remarks>
    Public Function initPUBKidAddUIInfo(ByVal OrderCode As String, ByVal MainIdentityId As String, ByVal EffectDate As Date) As DataSet

        Dim KidAddInitDS As New DataSet

        'Dim PubOper As PUBDelegate = PUBDelegate.getInstance

        'syscode: 18, 19, 41
        Dim TypeIds() As Integer = {18, 19, 41}
        Dim SyscodeDT As DataTable = PUBSysCodeBO_E1.getInstance.querySyscodeByTypeIds(TypeIds)
        If DataSetUtil.IsContainsData(SyscodeDT) Then
            SyscodeDT.TableName = "pubsyscode"
            KidAddInitDS.Tables.Add(SyscodeDT)
        End If



        '兒童加成目前作用中的..
        'OrderCode, DC = N
        If OrderCode.Length > 0 Then
            Dim KidAddDT As DataTable = PUBKidAddBO_E1.getInstance.queryActiveKidAddData(OrderCode, MainIdentityId, EffectDate)
            If DataSetUtil.IsContainsData(KidAddDT) Then
                KidAddDT.TableName = "kidadd"
                KidAddInitDS.Tables.Add(KidAddDT)
            End If
        End If


        '系統日期
        Dim SystemDateColumn() As String = {"System_Date"}
        Dim SystemDateColumnType() As Integer = {DataSetUtil.TypeDate}
        Dim SystemDateDT As DataTable = DataSetUtil.createDataTable("systemdate", Nothing, SystemDateColumn, SystemDateColumnType)
        Dim dateDR As DataRow = SystemDateDT.NewRow
        dateDR(SystemDateColumn(0)) = SystemDate

        SystemDateDT.Rows.Add(dateDR)

        KidAddInitDS.Tables.Add(SystemDateDT)

        Return KidAddInitDS
    End Function

    ''' <summary>
    ''' 程式說明：孩童加成
    ''' 開發人員：Jen
    ''' 開發日期：2009.09.24
    ''' </summary>
    ''' <param name="Condition">條件</param>
    ''' <returns>DataTable</returns>
    ''' <使用表單>
    ''' 1.Jen-PUB_Kid_Add
    ''' </使用表單>
    ''' <修改註記>
    ''' 1.2009/09/24, XXX
    ''' </修改註記>
    Public Function queryKidAddByCondition(ByVal Condition As DataTable) As DataTable
        Return PUBKidAddBO_E1.getInstance.queryKidAddByCondition(Condition)
    End Function

    ''' <summary>
    '''程式說明：孩童加成查詢
    ''' 開發人員：Immy
    ''' 開發日期：2011.09.07
    ''' </summary>
    ''' <param name="Order_Code"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function QueryAdd(ByVal Order_Code As String) As DataTable
        Dim KidAddQUERYDS As DataTable = PUBKidAddBO_E1.getInstance.QueryAdd(Order_Code)
        Return KidAddQUERYDS
    End Function

    ''' <summary>
    '''程式說明：急件加成查詢
    ''' 開發人員：Immy
    ''' 開發日期：2011.09.07
    ''' </summary>
    ''' <param name="Order_Code"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function QueryAdd_EMG(ByVal Order_Code As String) As DataTable
        Dim EMGAddQUERYDS As DataTable = PUBEmgAddBO_E1.getInstance.QueryAdd_EMG(Order_Code)
        Return EMGAddQUERYDS
    End Function

    ''' <summary>
    '''程式說明：牙科轉診加成查詢
    ''' 開發人員：Immy
    ''' 開發日期：2011.09.07
    ''' </summary>
    ''' <param name="Order_Code"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function QueryAdd_Dental(ByVal Order_Code As String) As DataTable
        Dim DentalAddQUERYDS As DataTable = PUBDentalAddBO_E1.getInstance.QueryAdd_Dental(Order_Code)
        Return DentalAddQUERYDS
    End Function

    ''' <summary>
    '''程式說明：科別加成查詢
    ''' 開發人員：Immy
    ''' 開發日期：2011.09.07
    ''' </summary>
    ''' <param name="Order_Code"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function QueryAdd_Dept(ByVal Order_Code As String) As DataTable
        Dim DeptAddQUERYDS As DataTable = PUBDeptAddBO_E1.getInstance.QueryAdd_Dept(Order_Code)
        Return DeptAddQUERYDS
    End Function
End Class

