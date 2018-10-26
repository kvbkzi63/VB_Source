'/*
'*****************************************************************************
'*
'*    Page/Class Name:  資料庫連線實作
'*              Title:	SQLConnFactory
'*        Description:	資料庫連線實作，實作介面 IDbConnFactory
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Rich, Chuang
'*        Create Date:	2014-01-20
'*      Last Modifier:	Rich, Chuang
'*   Last Modify Date:	2014-01-20
'*
'*****************************************************************************
'*/

Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Transactions
Imports Syscom.Comm.BASE
Imports System.Data.OracleClient

Public Class SQLConnFactory
    Implements IDbConnFactory

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
    Public Shared ReadOnly Property getInstance() As SQLConnFactory
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

        Public Shared ReadOnly instance As New SQLConnFactory()
    End Class

#End Region

    ''' <summary>
    ''' 預設指定交易的隔離層級 - 在交易期間無法讀取變動的資料，但可以修改資料
    ''' </summary>
    ''' <remarks></remarks>
    Private Const defaultIsolationLevel As IsolationLevel = IsolationLevel.ReadCommitted

#Region " Oracle連線設定"

    ''' <summary>
    ''' Oracle連線設定 on 2014-01-10 By Lits
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getOracleDBSqlConn() As IDbConnection Implements IDbConnFactory.getOracleDBSqlConn
        Try
            Dim SQLConn As OracleConnection = New OracleConnection(ConfigurationManager.ConnectionStrings("OracleDBConnectionString").ConnectionString)
            Return SQLConn
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

#Region " SyBase連線設定"

    ''' <summary>
    ''' SyBase連線設定 on 2014-01-10 By Lits
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getSyBaseDBSqlConn() As IDbConnection Implements IDbConnFactory.getSyBaseDBSqlConn
        Try
            Dim SQLConn As Sybase.Data.AseClient.AseConnection = New Sybase.Data.AseClient.AseConnection(replaceApplicationName(ConfigurationManager.ConnectionStrings("SyBaseDBConnectionString").ConnectionString))
            Return SQLConn
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

#Region " SyBase連線設定 SybaseDB 主機2 "

    ''' <summary>
    ''' SyBase連線設定 on 2014-03-17 By Lewis
    ''' SybaseDB 主機2
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getSyBaseDBSqlConn2() As IDbConnection Implements IDbConnFactory.getSyBaseDBSqlConn2
        Try
            Dim SQLConn As Sybase.Data.AseClient.AseConnection = New Sybase.Data.AseClient.AseConnection(replaceApplicationName(ConfigurationManager.ConnectionStrings("SyBaseDBConnectionString2").ConnectionString))
            Return SQLConn
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region
     
#Region " NIS連線設定"

    ''' <summary>
    ''' NIS連線設定
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getNisDBSqlConn() As IDbConnection Implements IDbConnFactory.getNisDBSqlConn
        Try
            Dim SQLConn As SqlConnection = New SqlClient.SqlConnection(replaceApplicationName(ConfigurationManager.ConnectionStrings("NisDBConnectionString").ConnectionString))
            Return SQLConn
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region
     
#Region " 權限連線設定"

    ''' <summary>
    ''' 權限連線設定
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getArmDBSqlConn() As IDbConnection Implements IDbConnFactory.getArmDBSqlConn
        Try
            Dim SQLConn As SqlConnection = New SqlClient.SqlConnection(replaceApplicationName(ConfigurationManager.ConnectionStrings("ArmDBConnectionString").ConnectionString))
            Return SQLConn
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

#Region " 門診連線設定"
     
    ''' <summary>
    ''' 門診連線設定
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2014-10-14</remarks>
    Public Function getOpdDBSqlConn() As IDbConnection Implements IDbConnFactory.getOpdDBSqlConn
        Try
            Dim SQLConn As SqlConnection = New SqlClient.SqlConnection(replaceApplicationName(ConfigurationManager.ConnectionStrings("OpdDBConnectionString").ConnectionString))
            Return SQLConn
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

#Region " 急診連線設定"

    ''' <summary>
    ''' 急診連線設定
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2014-10-14</remarks>
    Public Function getEisDBSqlConn() As IDbConnection Implements IDbConnFactory.getEisDBSqlConn
        Try
            Dim SQLConn As SqlConnection = New SqlClient.SqlConnection(replaceApplicationName(ConfigurationManager.ConnectionStrings("EisDBConnectionString").ConnectionString))
            Return SQLConn
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

#Region " 住院連線設定"

    ''' <summary>
    ''' 住院連線設定
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2014-10-14</remarks>
    Public Function getPcsDBSqlConn() As IDbConnection Implements IDbConnFactory.getPcsDBSqlConn
        Try
            Dim SQLConn As SqlConnection = New SqlClient.SqlConnection(replaceApplicationName(ConfigurationManager.ConnectionStrings("PcsDBConnectionString").ConnectionString))
            Return SQLConn
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

#Region "高聯醫叫號機連線設定"

    ''' <summary>
    ''' 住院連線設定
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2014-10-14</remarks>
    Public Function getKmuhOpdDBSqlConn() As IDbConnection Implements IDbConnFactory.GetKmuhOpdSqlConn
        Try
            Dim SQLConn As SqlConnection = New SqlClient.SqlConnection(replaceApplicationName(ConfigurationManager.ConnectionStrings("KmuhOpdDBConnectionString").ConnectionString))
            Return SQLConn
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

#Region " 電子病歷連線設定"

    ''' <summary>
    ''' 電子病歷連線設定
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getEmrDBSqlConn() As IDbConnection Implements IDbConnFactory.getEmrDBSqlConn
        Try
            Dim SQLConn As SqlConnection = New SqlClient.SqlConnection(replaceApplicationName(ConfigurationManager.ConnectionStrings("EmrDBConnectionString").ConnectionString))
            Return SQLConn
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

#Region " CMR連線設定"

    ''' <summary>
    ''' CMR連線設定
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getCmrDBSqlConn() As IDbConnection Implements IDbConnFactory.GetCmrDBSqlConn
        Try
            Dim SQLConn As SqlConnection = New SqlClient.SqlConnection(replaceApplicationName(ConfigurationManager.ConnectionStrings("CmrDBConnectionString").ConnectionString))
            Return SQLConn
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

#Region " TTAS連線設定"

    ''' <summary>
    ''' TTAS連線設定  
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>2015-08-28 Add By Sean</remarks>
    Public Function getTtasDBSqlConn() As IDbConnection Implements IDbConnFactory.getTtasDBSqlConn
        Try
            Dim SQLConn As SqlConnection = New SqlClient.SqlConnection(replaceApplicationName(ConfigurationManager.ConnectionStrings("TtasDBConnectionString").ConnectionString))
            Return SQLConn
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

#Region " 共用連線設定"

    ''' <summary>
    ''' 共用連線設定  2010-06-25 Add By Alan
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getPubDBSqlConn() As IDbConnection Implements IDbConnFactory.getPubDBSqlConn
        Try
            Dim SQLConn As SqlConnection = New SqlClient.SqlConnection(replaceApplicationName(ConfigurationManager.ConnectionStrings("PubDBConnectionString").ConnectionString))
            Return SQLConn
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

#Region " 備份連線設定"

    ''' <summary>
    ''' 備份連線設定  2010-06-25 Add By Alan
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getBKDBSqlConn() As IDbConnection Implements IDbConnFactory.getBKDBSqlConn
        Try
            Dim SQLConn As SqlConnection = New SqlClient.SqlConnection(replaceApplicationName(ConfigurationManager.ConnectionStrings("BKDBConnectionString").ConnectionString))
            Return SQLConn
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

#Region " 序號機線設定"

    ''' <summary>
    ''' 序號機線設定
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getSerialNoSqlConn() As IDbConnection Implements IDbConnFactory.getSerialNoSqlConn
        Try
            Dim SQLConn As SqlConnection = New SqlClient.SqlConnection(replaceApplicationName(ConfigurationManager.ConnectionStrings("SerialNoConnectionString").ConnectionString))
            Return SQLConn
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

#Region "電子表單連線設定(EFS)，CDR電子病歷系統連線設定"
    ''' <summary>
    ''' 電子表單連線設定(EFS)
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2014-10-14</remarks>
    Public Function getEfsDBSqlConn() As IDbConnection Implements IDbConnFactory.GetEfsDBSqlConn
        Try
            Dim SQLConn As SqlConnection = New SqlClient.SqlConnection(replaceApplicationName(ConfigurationManager.ConnectionStrings("EfsDBConnectionString").ConnectionString))
            Return SQLConn
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    '電子病歷系統連線設定(CDR)
    Public Function getCdrDBSqlConn() As IDbConnection Implements IDbConnFactory.GetCdrDBSqlConn
        Try
            Dim SQLConn As SqlConnection = New SqlClient.SqlConnection(replaceApplicationName(ConfigurationManager.ConnectionStrings("CdrDBConnectionString").ConnectionString))
            Return SQLConn
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

#Region " 歷史資料庫連線設定"

    ''' <summary>
    ''' 歷史資料庫連線設定
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getHistoryDBSqlConn() As IDbConnection Implements IDbConnFactory.GetHistoryDBSqlConn
        Try
            Dim SQLConn As SqlConnection = New SqlClient.SqlConnection(replaceApplicationName(ConfigurationManager.ConnectionStrings("HistoryDBConnectionString").ConnectionString))
            Return SQLConn
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

#Region " LIS連線設定"

    ''' <summary>
    ''' LIS連線設定
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getLisDBSqlConn() As IDbConnection Implements IDbConnFactory.GetLisDBSqlConn
        Try
            Dim SQLConn As SqlConnection = New SqlClient.SqlConnection(replaceApplicationName(ConfigurationManager.ConnectionStrings("LisDBConnectionString").ConnectionString))
            Return SQLConn
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

#Region " 交易相關"

    ''' <summary>
    ''' 取得指定交易的隔離層級
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getDefaultIsolationLevel() As IsolationLevel Implements IDbConnFactory.getDefaultIsolationLevel
        Return defaultIsolationLevel
    End Function

    ''' <summary>
    ''' 交易是範圍所需的，如果已經存在環境交易，則會使用環境交易，否則會在進入範圍前建立新的交易。這是預設值。
    ''' </summary>
    ''' <param name="iLevel">預設為 ReadCommitted ，當正在讀取資料來避免 Dirty 讀取時，會使用共用鎖定，但是在交易結束之前，資料可以變更，這將會產生非重複讀取或虛設資料。 </param>
    ''' <returns></returns>
    ''' <remarks>TransactionScope 中 TransactionOptions.IsolationLevel 的設定值為 Serializable，會大量提高鎖定的資料量與時間</remarks>
    Public Function getRequiredTransactionScope(Optional ByRef iLevel As IsolationLevel = defaultIsolationLevel) As TransactionScope Implements IDbConnFactory.getRequiredTransactionScope
        Dim tos As New TransactionOptions()
        tos.IsolationLevel = iLevel
        tos.Timeout = New TimeSpan(0, 0, 90)
        Return New TransactionScope(TransactionScopeOption.Required, tos)
    End Function

    ''' <summary>
    ''' 新交易一定會針對範圍而建立。
    ''' </summary>
    ''' <param name="iLevel">預設為 ReadCommitted ，當正在讀取資料來避免 Dirty 讀取時，會使用共用鎖定，但是在交易結束之前，資料可以變更，這將會產生非重複讀取或虛設資料。 </param>
    ''' <returns></returns>
    ''' <remarks>TransactionScope 中 TransactionOptions.IsolationLevel 的設定值為 Serializable，會大量提高鎖定的資料量與時間</remarks>
    Public Function getRequiresNewTransactionScope(Optional ByRef iLevel As IsolationLevel = defaultIsolationLevel) As TransactionScope Implements IDbConnFactory.getRequiresNewTransactionScope
        Dim tos As New TransactionOptions()
        tos.IsolationLevel = iLevel
        tos.Timeout = New TimeSpan(0, 0, 90)
        Return New TransactionScope(TransactionScopeOption.RequiresNew, tos)
    End Function

    ''' <summary>
    ''' 當建立範圍時會隱藏環境交易內容，範圍內的所有作業都是在不使用環境交易內容的情況下完成。 
    ''' </summary>
    ''' <param name="iLevel">預設為 ReadCommitted ，當正在讀取資料來避免 Dirty 讀取時，會使用共用鎖定，但是在交易結束之前，資料可以變更，這將會產生非重複讀取或虛設資料。 </param>
    ''' <returns></returns>
    ''' <remarks>TransactionScope 中 TransactionOptions.IsolationLevel 的設定值為 Serializable，會大量提高鎖定的資料量與時間</remarks>
    Public Function getSuppressTransactionScope(Optional ByRef iLevel As IsolationLevel = defaultIsolationLevel) As TransactionScope Implements IDbConnFactory.getSuppressTransactionScope
        Dim tos As New TransactionOptions()
        tos.IsolationLevel = iLevel
        tos.Timeout = New TimeSpan(0, 0, 90)
        Return New TransactionScope(TransactionScopeOption.Suppress, tos)
    End Function


#End Region

    ''' <summary>
    ''' 置換應用程式名稱
    ''' </summary>
    ''' <param name="src"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function replaceApplicationName(ByVal src As String) As String
        If src.Contains("Application Name=_OPDAPI") Then
            Return src.Replace("_OPDAPI", ("_OPDAPI" & getCallerName()))
        ElseIf src.Contains("Application Name=_REFAPI") Then
            Return src.Replace("_REFAPI", ("_REFAPI" & getCallerName()))
        ElseIf src.Contains("Application Name=_PRIAPI") Then
            Return src.Replace("_PRIAPI", ("_PRIAPI" & getCallerName()))
        ElseIf src.Contains("Application Name=_EPDAPI") Then
            Return src.Replace("_EPDAPI", ("_EPDAPI" & getCallerName()))
        Else
            Return src
        End If
    End Function

    ''' <summary>
    ''' 取得呼叫程式名稱
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function getCallerName() As String
        Try
            Dim st As StackTrace = New StackTrace()
            Dim sf As StackFrame = st.GetFrame(4)
            Dim mb As Reflection.MethodBase = sf.GetMethod()

            Dim displayLevel = ConfigurationManager.AppSettings.Item("SQLStringApplicationName")
            Select Case (displayLevel)
                Case "2"
                    Return "^" & mb.Module.Name & "." & mb.ReflectedType.Name '& "." & mb.Name
                Case "3"
                    Return "^" & mb.Module.Name & "." & mb.ReflectedType.Name & "." & mb.Name
                Case Else
                    Return "^" & mb.Module.Name '& "." & mb.ReflectedType.Name & "." & mb.Name
            End Select
        Catch ex As Exception
            Return ""
        End Try
    End Function

End Class

