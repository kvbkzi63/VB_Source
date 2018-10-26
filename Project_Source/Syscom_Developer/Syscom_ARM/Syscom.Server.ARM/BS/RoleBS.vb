Imports System.Configuration
Imports System.Transactions
Imports Syscom.Comm.LOG
Imports Syscom.Comm.EXP
Imports Syscom.Server.SQL

Public Class RoleBS

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
    Public Shared ReadOnly Property getInstance() As RoleBS
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

        Public Shared ReadOnly instance As New RoleBS()
    End Class

#End Region

    ''' <summary>
    ''' 取得角色功能設定維護畫面的資料
    ''' </summary>
    ''' <param name="RoleID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function queryForRoleRightsMaintain(ByVal RoleID As String) As DataSet
        Try
            Dim ds As New DataSet
            Dim roleRights As ArmRoleRightsBO_E1 = ArmRoleRightsBO_E1.getInstance
            Using conn As IDbConnection = roleRights.getConnection
                conn.Open()
                ds = roleRights.SelectRoleRights(RoleID, conn)
                Dim dsTemp As DataSet = roleRights.queryAllRoleRights(conn)
                dsTemp.Tables(0).TableName = "AllRoleRights"
                ds.Tables.Add(dsTemp.Tables(0).Copy)
            End Using
            Return ds
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    ''' <summary>
    ''' Role權限的新增與刪除
    ''' </summary>
    ''' <param name="ds"></param>
    ''' <remarks></remarks>
    Public Sub ConfirmRoleRights(ByVal ds As DataSet)
        Try
            Dim roleRights As ArmRoleRightsBO_E1 = ArmRoleRightsBO_E1.getInstance
            Using Scope As TransactionScope = SQLConnFactory.getInstance.getRequiredTransactionScope
                Using PubConn As System.Data.IDbConnection = roleRights.getConnection
                    PubConn.Open()

                    If ds.Tables.Count > 0 Then
                        Dim count As Integer = roleRights.deleteAllRoleRights(ds.Tables(0).TableName, PubConn)
                        count += roleRights.insert(ds, PubConn)
                    End If
                End Using
                Scope.Complete()
            End Using
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Sub

End Class