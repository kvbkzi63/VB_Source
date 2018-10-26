Imports System.Transactions
Imports Syscom.Server.SQL

Public Class CmmSerialNoFactory
    Inherits AbstractFactory

#Region "Singleton Design Pattern - Fully Thread Safety"

    ''' <summary>
    ''' 阻止外部直接進行新建立的宣告
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub New()
    End Sub

    ''' <summary>
    ''' 屬性取得類別實體
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property getInstance() As CmmSerialNoFactory
        Get
            Return Nested.instance
        End Get
    End Property

    ''' <summary>
    ''' 巢狀類別存放建立的類別實體
    ''' </summary>
    ''' <remarks></remarks>
    Private Class Nested
        Shared Sub New()
        End Sub

        Public Shared ReadOnly instance As New CmmSerialNoFactory()
    End Class

#End Region

    ''' <summary>
    ''' 取得序號
    ''' </summary>
    ''' <param name="Type">A:日循環 B:月循環 C:年循環 D:不循環直到最大號 </param>
    ''' <param name="Key">識別系統與資訊的值</param>
    ''' <param name="MinNo">最小號，default 給 1</param>
    ''' <param name="MaxNo">建議給99999999，沒有限制最大號給 -1</param>
    ''' <param name="Inc">兩次號碼之間增加的數值</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides Function getSerialNo(ByVal Type As SncType, ByVal Key As String, ByVal MinNo As Integer, ByVal MaxNo As Integer, ByVal Inc As Integer, ByVal conn As IDbConnection) As String
        Return CStr(SerialNoServiceClient.getInstance.getSerialNo(Type, Key, MinNo, MaxNo, Inc, conn))
    End Function

End Class

