Imports System.Data.SqlClient
Imports System.Transactions

Imports log4net
Imports Syscom.Comm.Utility

Public Class PUBExclusiveDrugSetBS
    Implements IDisposable

    Dim SystemDate As Date = DateUtil.getSystemDate

#Region "########## getInstance() ##########"

    'Private Shared instance As PUBTreatmentControlBS

    Private Sub New()
    End Sub

    Public Shared Function getInstance() As PUBExclusiveDrugSetBS
        Try
            'If instance Is Nothing Then
            '    instance = New PUBTreatmentControlBS
            'End If
            'Return instance

            Return New PUBExclusiveDrugSetBS

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
    ''' 初始排除藥費資料
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>Add By Jen</remarks>
    Public Function initPUBExclusiveDrugSetUIInfo() As DataSet

        Dim OrderInitDS As New DataSet

        'syscode: 40, 511 
        Dim TypeIds() As Integer = {38}
        Dim SyscodeDT As DataTable = PUBSysCodeBO_E1.getInstance.querySyscodeByTypeIds(TypeIds)
        If DataSetUtil.IsContainsData(SyscodeDT) Then
            SyscodeDT.TableName = "pubsyscode"
            OrderInitDS.Tables.Add(SyscodeDT)
        End If

        '系統日期
        Dim SystemDateColumn() As String = {"System_Date"}
        Dim SystemDateColumnType() As Integer = {DataSetUtil.TypeDate}
        Dim SystemDateDT As DataTable = DataSetUtil.createDataTable("systemdate", Nothing, SystemDateColumn, SystemDateColumnType)
        Dim dateDR As DataRow = SystemDateDT.NewRow
        dateDR(SystemDateColumn(0)) = SystemDate

        SystemDateDT.Rows.Add(dateDR)

        OrderInitDS.Tables.Add(SystemDateDT)

        Return OrderInitDS
    End Function

    ''' <summary>
    ''' 查詢排除藥費
    ''' </summary>
    ''' <param name="OrderCode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function queryExclusiveDrugSetData(ByVal OrderCode As String) As DataTable
        If OrderCode IsNot Nothing AndAlso OrderCode.Trim.Length > 0 Then
            Return PUBExcludeDrugSetBO_E1.getInstance.queryExclusiveDrugSetData(OrderCode)
        Else
            Return Nothing
        End If
    End Function


End Class


