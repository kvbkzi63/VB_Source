'/*
'*****************************************************************************
'*
'*    Page/Class Name:  資料庫連線介面
'*              Title:	IDbConnFactory
'*        Description:	資料庫連線介面，為不同資料庫提供一致性實作連線函式
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Rich, Chuang
'*        Create Date:	2014-01-20
'*      Last Modifier:	Rich, Chuang
'*   Last Modify Date:	2014-01-20
'*
'*****************************************************************************
'*/

Imports System.Transactions

Public Interface IDbConnFactory
    ''' <summary>
    ''' Oracle連線設定 on 2015-08-12 By Lits  
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetOracleDBSqlConn() As IDbConnection

    ''' <summary>
    ''' SyBase連線設定 on 2014-01-10 By Lits  
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetSyBaseDBSqlConn() As IDbConnection

    ''' <summary>
    ''' SyBase連線設定 on 2014-03-17 By Lewis  
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetSyBaseDBSqlConn2() As IDbConnection

    ''' <summary>
    ''' NIS連線設定
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetNisDBSqlConn() As IDbConnection

    ''' <summary>
    ''' 權限連線設定
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetArmDBSqlConn() As IDbConnection


    ''' <summary>
    ''' 門診連線設定
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2014-10-14</remarks>
    Function GetOpdDBSqlConn() As IDbConnection

    ''' <summary>
    ''' 急診連線設定
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2014-10-14</remarks>
    Function GetEisDBSqlConn() As IDbConnection

    ''' <summary>
    ''' 住院連線設定
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2014-10-14</remarks>
    Function GetPcsDBSqlConn() As IDbConnection

    ''' <summary>
    ''' 高聯醫叫號機連線設定
    ''' </summary>
    ''' <remarks>by James on 2015-09-01</remarks>
    Function GetKmuhOpdSqlConn() As IDbConnection

    ''' <summary>
    ''' 電子病歷連線設定
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetEmrDBSqlConn() As IDbConnection

    ''' <summary>
    ''' TTAS連線設定  
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>2015-08-28 Add By Sean</remarks>
    Function GetTtasDBSqlConn() As IDbConnection

    ''' <summary>
    ''' 共用連線設定  2010-06-25 Add By Alan
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetPubDBSqlConn() As IDbConnection

    ''' <summary>
    ''' 備份連線設定  2010-06-25 Add By Alan
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetBKDBSqlConn() As IDbConnection

    ''' <summary>
    ''' 序號機線設定
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetSerialNoSqlConn() As IDbConnection

    ''' <summary>
    ''' 電子表單(EFS)
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetEfsDBSqlConn() As IDbConnection

    ''' <summary>
    ''' 電子病歷(CDR)
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetCdrDBSqlConn() As IDbConnection

    ''' <summary>
    ''' 歷史資料庫連線設定
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetHistoryDBSqlConn() As IDbConnection

    ''' <summary>
    ''' LIS連線設定
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetLisDBSqlConn() As IDbConnection

    ''' <summary>
    ''' CMR連線設定
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetCmrDBSqlConn() As IDbConnection

    ''' <summary>
    ''' 取得指定交易的隔離層級
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetDefaultIsolationLevel() As IsolationLevel

    ''' <summary>
    ''' 交易是範圍所需的，如果已經存在環境交易，則會使用環境交易，否則會在進入範圍前建立新的交易。這是預設值。
    ''' </summary>
    ''' <param name="iLevel">預設為 ReadCommitted ，當正在讀取資料來避免 Dirty 讀取時，會使用共用鎖定，但是在交易結束之前，資料可以變更，這將會產生非重複讀取或虛設資料。 </param>
    ''' <returns></returns>
    ''' <remarks>TransactionScope 中 TransactionOptions.IsolationLevel 的設定值為 Serializable，會大量提高鎖定的資料量與時間</remarks>
    Function GetRequiredTransactionScope(Optional ByRef iLevel As IsolationLevel = IsolationLevel.ReadCommitted) As TransactionScope

    ''' <summary>
    ''' 新交易一定會針對範圍而建立。
    ''' </summary>
    ''' <param name="iLevel">預設為 ReadCommitted ，當正在讀取資料來避免 Dirty 讀取時，會使用共用鎖定，但是在交易結束之前，資料可以變更，這將會產生非重複讀取或虛設資料。 </param>
    ''' <returns></returns>
    ''' <remarks>TransactionScope 中 TransactionOptions.IsolationLevel 的設定值為 Serializable，會大量提高鎖定的資料量與時間</remarks>
    Function GetRequiresNewTransactionScope(Optional ByRef iLevel As IsolationLevel = IsolationLevel.ReadCommitted) As TransactionScope

    ''' <summary>
    ''' 當建立範圍時會隱藏環境交易內容，範圍內的所有作業都是在不使用環境交易內容的情況下完成。 
    ''' </summary>
    ''' <param name="iLevel">預設為 ReadCommitted ，當正在讀取資料來避免 Dirty 讀取時，會使用共用鎖定，但是在交易結束之前，資料可以變更，這將會產生非重複讀取或虛設資料。 </param>
    ''' <returns></returns>
    ''' <remarks>TransactionScope 中 TransactionOptions.IsolationLevel 的設定值為 Serializable，會大量提高鎖定的資料量與時間</remarks>
    Function GetSuppressTransactionScope(Optional ByRef iLevel As IsolationLevel = IsolationLevel.ReadCommitted) As TransactionScope

End Interface
