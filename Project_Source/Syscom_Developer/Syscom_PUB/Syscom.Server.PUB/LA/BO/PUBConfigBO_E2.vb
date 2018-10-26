'/*
'*****************************************************************************
'*
'*    Page/Class Name:	PUBConfigBO_E2.vb
'*              Title:	化療室排班展開天數之查询
'*        Description:	化療室排班展開天數之查询
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd.
'*            @author:	LeonWoo
'*        Create Date:	2009/09/08
'*      Last Modifier:	
'*   Last Modify Date:	
'*
'*****************************************************************************
'*/
Imports System.Data.SqlClient
Imports System.Text
Imports System.Transactions
Imports Syscom.Comm.TableFactory
Imports Syscom.Server.BO
Imports Syscom.Comm.Utility
Imports Syscom.Comm.EXP
Imports Syscom.Server.CMM
Imports Syscom.Server.SQL
Imports System.Reflection
Public Class PUBConfigBO_E2
    Inherits PubConfigBO
    Private Shared myInstance As PUBConfigBO_E2

    Public Overloads Shared Function GetInstance() As PUBConfigBO_E2
        If myInstance Is Nothing Then
            myInstance = New PUBConfigBO_E2()
        End If
        Return myInstance
    End Function
    ''' <summary>
    ''' 取得肺結核資料
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
#Region "20091103   取得肺結核資料 Add by tony"
    Function queryTuberculosis() As DataSet
        Dim ds As Data.DataSet = New DataSet
        Dim strSql As New StringBuilder

        strSql.Append(" ").Append("SELECT  Config_Value FROM  PUB_Config ")

        strSql.Append(" ").Append(" Where 1=1 and Config_Name = 'INF_Tuberculosis' ")
        Try
            Using sqlConnection As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
                Dim adapter As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqlConnection)
                ds = New Data.DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, Data.SchemaType.Mapped, tableName)
            End Using
        Catch ex As Exception
            Dim FunctName As String = String.Format("{0}-{1}:", Me.GetType.Name, MethodBase.GetCurrentMethod.Name)
            LOGDelegate.getInstance.dbDebugMsg(FunctName)
            Throw ex
        End Try
        Return ds
    End Function
#End Region
#Region "20091127 PUBConfigBO_E2 庫別查詢 add by liuye"
    ''' <summary>
    '''  庫別查詢
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function queryConsuDept() As DataSet
        Dim ds As Data.DataSet = New DataSet
        Dim strSql As New StringBuilder
        strSql.Append(" ").Append("SELECT  Config_Value FROM  PUB_Config ")
        strSql.Append(" ").Append(" Where 1=1 and Config_Name in ('OPH_Opd_Cons' ,'OPH_Ipd_Cons' ,'OPH_Emg_Cons') ")
        Try
            Using sqlConnection As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
                Dim adapter As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqlConnection)
                ds = New Data.DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, Data.SchemaType.Mapped, tableName)
            End Using
        Catch ex As Exception
            Dim FunctName As String = String.Format("{0}-{1}:", Me.GetType.Name, MethodBase.GetCurrentMethod.Name)
            LOGDelegate.getInstance.dbDebugMsg(FunctName)
            Throw ex
        End Try
        Return ds
    End Function
#End Region
#Region "20091211   取得血液代碼 Add by tony"
    Function queryBloodSpecimen() As DataSet
        Dim ds As Data.DataSet = New DataSet
        Dim strSql As New StringBuilder

        strSql.Append(" ").Append("SELECT  Config_Value FROM  PUB_Config ")

        strSql.Append(" ").Append(" Where 1=1 and Config_Name = 'PUB_Blood_Specimen' ")
        Try
            Using sqlConnection As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
                Dim adapter As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqlConnection)
                ds = New Data.DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, Data.SchemaType.Mapped, tableName)
            End Using
        Catch ex As Exception
            Dim FunctName As String = String.Format("{0}-{1}:", Me.GetType.Name, MethodBase.GetCurrentMethod.Name)
            LOGDelegate.getInstance.dbDebugMsg(FunctName)
            Throw ex
        End Try
        Return ds
    End Function
#End Region

#Region "20091229  Add by jianhui"
    Function queryURLByName(ByVal strName As String) As DataSet
        Dim ds As Data.DataSet = New DataSet
        Dim strSql As New StringBuilder

        strSql.Append(" ").Append("SELECT  Config_Value FROM  PUB_Config ")

        strSql.Append(" ").Append(" Where 1=1 and Config_Name = '").Append(strName.Trim).Append("' ")
        Try
            Using sqlConnection As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
                Dim adapter As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqlConnection)
                ds = New Data.DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, Data.SchemaType.Mapped, tableName)
            End Using
        Catch ex As Exception
            Dim FunctName As String = String.Format("{0}-{1}:", Me.GetType.Name, MethodBase.GetCurrentMethod.Name)
            LOGDelegate.getInstance.dbDebugMsg(FunctName)
            Throw ex
        End Try
        Return ds
    End Function
#End Region

#Region "20100107 prisendInfo查詢  Add by liuye"
    Function queryprisendInfo() As DataSet
        Dim ds As Data.DataSet = New DataSet
        Dim strSql As New StringBuilder

        strSql.Append(" ").Append("SELECT  Config_Value,Config_Name FROM  PUB_Config ")

        strSql.Append(" ").Append(" Where 1=1 and Config_Name IN ('PRI_Sender_Name','PRI_Sender_Email','PRI_SMTP_Address', 'PRI_SMTP_Port','PRI_SMTP_ID','PRI_SMTP_Password','PRI_O_TEL','PRI_H_TEL' ,'PRI_Drug_Email','PRI_NotDrug_Email','PRI_Drug_TEL')")
        Try
            Using sqlConnection As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
                Dim adapter As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqlConnection)
                ds = New Data.DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, Data.SchemaType.Mapped, tableName)
            End Using
        Catch ex As Exception
            Dim FunctName As String = String.Format("{0}-{1}:", Me.GetType.Name, MethodBase.GetCurrentMethod.Name)
            LOGDelegate.getInstance.dbDebugMsg(FunctName)
            Throw ex
        End Try
        Return ds
    End Function
#End Region

#Region "20100511 語音掛號路徑查詢  Add by pearl"
    Function queryREGVoiceInfo() As DataSet
        Dim ds As Data.DataSet = New DataSet
        Dim strSql As New StringBuilder

        strSql.Append(" ").Append("SELECT  Config_Value,Config_Name FROM  PUB_Config ")

        strSql.Append(" ").Append(" Where 1=1 and Config_Name IN ('REG_Voice_IP','REG_Voice_ID','REG_Voice_PWD','REG_Voice_PATH')")
        Try
            Using sqlConnection As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
                Dim adapter As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqlConnection)
                ds = New Data.DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, Data.SchemaType.Mapped, tableName)
            End Using
        Catch ex As Exception
            Dim FunctName As String = String.Format("{0}-{1}:", Me.GetType.Name, MethodBase.GetCurrentMethod.Name)
            LOGDelegate.getInstance.dbDebugMsg(FunctName)
            Throw ex
        End Try
        Return ds
    End Function
#End Region
End Class



