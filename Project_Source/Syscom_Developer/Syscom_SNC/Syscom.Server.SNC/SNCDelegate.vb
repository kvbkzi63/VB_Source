Imports System.Transactions
Imports Syscom.Server.SQL

Public Class SNCDelegate

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
    Public Shared ReadOnly Property getInstance() As SNCDelegate
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

        Public Shared ReadOnly instance As New SNCDelegate()
    End Class

#End Region

#Region "執行失敗不跳號處理，使用 Required ==> SQLConnFactory.getInstance.getRequiredTransactionScope "

    ''' <summary>
    ''' 加入交易，代表執行失敗不跳號處理
    ''' </summary>
    ''' <param name="Type">A:日循環 B:月循環 C:年循環 D:不循環直到最大號 </param>
    ''' <param name="Key">識別系統與資訊的值</param>
    ''' <param name="MinNo">最小號，default 給 1</param>
    ''' <param name="MaxNo">建議給99999999，沒有限制最大號給 -1</param>
    ''' <returns>序號</returns>
    ''' <remarks></remarks>
    Public Function getCmmSerialNoTx(ByVal Type As AbstractFactory.SncType, ByVal Key As String, ByVal MinNo As Integer, ByVal MaxNo As Integer, ByVal conn As IDbConnection, Optional ByVal Inc As Integer = 1) As String
        Dim serialNo = ""
        Using Scope As TransactionScope = SQLConnFactory.getInstance.getRequiredTransactionScope
            serialNo = CmmSerialNoFactory.getInstance.getSerialNo(Type, Key, MinNo, MaxNo, Inc, conn)
            Scope.Complete()
        End Using
        Return serialNo
    End Function

#End Region

#Region "執行失敗仍跳號處理，使用 RequiresNew ==> SQLConnFactory.getInstance.getRequiresNewTransactionScope "

    ''' <summary>
    ''' 執行失敗仍會跳號處理
    ''' </summary>
    ''' <param name="Type">A:日循環 B:月循環 C:年循環 D:不循環直到最大號 </param>
    ''' <param name="Key">識別系統與資訊的值</param>
    ''' <param name="MinNo">最小號，default 給 1</param>
    ''' <param name="MaxNo">建議給99999999，沒有限制最大號給 -1</param>
    ''' <returns>序號</returns>
    ''' <remarks></remarks>
    Public Function getCmmSerialNo(ByVal Type As AbstractFactory.SncType, ByVal Key As String, ByVal MinNo As Integer, ByVal MaxNo As Integer, Optional ByVal Inc As Integer = 1) As String
        Dim serialNo As String = ""
        Using Scope As TransactionScope = SQLConnFactory.getInstance.getRequiresNewTransactionScope
            serialNo = CmmSerialNoFactory.getInstance.getSerialNo(Type, Key, MinNo, MaxNo, Inc, Nothing)
            Scope.Complete()
        End Using
        Return serialNo
    End Function

    ''' <summary>
    ''' 取得檔案編號 FID
    ''' </summary>
    ''' <returns>流水號</returns>
    ''' <remarks></remarks>
    Public Function getFileSerialNo() As String
        Return "FID" & CStr(getCmmSerialNo(AbstractFactory.SncType.typeD, "FID", 1, -1)).PadLeft(5, "0")
    End Function

    ''' <summary>
    ''' 取得報表編號 RID
    ''' </summary>
    ''' <returns>流水號</returns>
    ''' <remarks></remarks>
    Public Function getReportSerialNo() As String
        Return "RID" & CStr(getCmmSerialNo(AbstractFactory.SncType.typeD, "RID", 1, -1)).PadLeft(8, "0")
    End Function

#Region "20110917 取得檢驗單號  add by cww"
    ''' <summary>
    ''' 取得檢驗單號
    ''' </summary>
    ''' <param name="vSectionName"></param> --I:住院  O:門診   E:急診   H:健檢
    ''' <param name="vSoureKind"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getRequestNo(ByVal vSectionName As String, ByVal vSoureKind As String) As String
        Dim serialNo = ""
        Using Scope As TransactionScope = SQLConnFactory.getInstance.getRequiresNewTransactionScope
            serialNo = RequestNoFactory.getInstance.getSerialNo(vSectionName, vSoureKind)
            Scope.Complete()
        End Using
        Return serialNo

    End Function
#End Region

#End Region

#Region "20090910 獲取民國年+序列號 add by Yunfei"

    ''' <summary>
    ''' REF API sequential number generator.
    ''' Fail 會跳號
    ''' </summary>
    ''' <param name="strVKey">標定 Label,表標示</param>
    ''' <returns></returns>
    ''' <remarks>獲取民國年 + 序列號</remarks>
    Public Function getTWYearApiSequentialNo(ByVal strVKey As String) As String
        Dim serialNo = ""
        Using Scope As TransactionScope = Syscom.Server.SQL.SQLConnFactory.getInstance.getRequiresNewTransactionScope()
            serialNo = RefApiSequentialNoFactory.getInstance.getTWYearSerialNo(strVKey)
            Scope.Complete()
        End Using
        Return serialNo
    End Function
#End Region

    ''' <summary>
    ''' MMR 系統一次取得連續序號
    ''' </summary>
    ''' <param name="Inc">每次增加的數量</param>
    ''' <returns>給連續序號的第一個值</returns>
    ''' <remarks></remarks>
    Public Function getMmrSerialNo(ByVal Inc As Integer) As String
        Dim seralNo = ""
        Using scope As TransactionScope = Syscom.Server.SQL.SQLConnFactory.getInstance.getRequiresNewTransactionScope
            seralNo = MmrJumpSerialNoFactory.getInstance.getMMRSerialNo(Inc)
            scope.Complete()
        End Using
        Return seralNo
    End Function

#Region "20110802 Sch_Update_Record 用之流水序號"

    ''' <summary>
    ''' 取得Sch_Update_Record 用之流水序號
    ''' </summary>
    ''' <returns>serial number</returns>
    ''' <remarks></remarks>
    ''' <author>Ken</author>
    Public Function getSchUpdateRecordSn() As Int32
        Try

            Dim serialNo As Int32 = 0

            Using Scope As TransactionScope = SQLConnFactory.getInstance.getRequiresNewTransactionScope

                serialNo = SchUpdateRecordSnFactory.getInstance.getSerialNo()

                Scope.Complete()
            End Using

            Return serialNo

        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

#Region "2116/04/26 Order_Rule用序號機"

    ''' <summary>
    ''' "重覆醫令"用序號機
    ''' </summary>
    ''' <returns>組好之Rule Code</returns>
    ''' <remarks></remarks>
    Public Function getOrderRuleORD() As String
        Dim serialNo = ""
        Using Scope As TransactionScope = Syscom.Server.SQL.SQLConnFactory.getInstance.getRequiresNewTransactionScope
            serialNo = PubRuleOrdSerialNoFactory.getInstance.getSerialNo()
            Scope.Complete()
        End Using
        Return serialNo

    End Function
#End Region

End Class
