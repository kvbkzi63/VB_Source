'/*
'*****************************************************************************
'*
'*    Page/Class Name:	PUBHospitalBO_E2.vb
'*              Title:	轉診回覆
'*        Description:	轉診回覆
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd.
'*            @author:	ChenYang
'*        Create Date:	2009/10/12
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


Public Class PUBHospitalBO_E2
    Inherits PubHospitalBO
    Public Shared ReadOnly tableName1 As String = "PUB_Hospital"
    Private Shared myInstance As PUBHospitalBO_E2

    Public Overloads Function getInstance() As PUBHospitalBO_E2
        If myInstance Is Nothing Then
            myInstance = New PUBHospitalBO_E2()
        End If
        Return myInstance
    End Function

    Public Function queryPubHospitalByKey_L(ByVal LanguageTypeId As String, ByVal EffectDate As String) As System.Data.DataSet

        Dim ds As Data.DataSet = New DataSet
        Dim strSql As New StringBuilder

        strSql.Append(" ").Append("Select H.Hospital_Name, H.Hospital_Code, H.Address")
        strSql.Append(" ").Append("From ")
        strSql.Append(" ").Append(tableName1).Append(" H ")
        strSql.Append(" ").Append("Where H.Language_Type_Id = '").Append(LanguageTypeId.Trim).Append("' ")
        strSql.Append(" ").Append("AND H.Effect_Date <= '").Append(EffectDate.Trim).Append("' ")
        strSql.Append(" ").Append("AND H.End_Date > '").Append(EffectDate.Trim).Append("' ")

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
#Region "20091012 PUBHospitalBO_E2 根據傳入時間查詢 by Add Tor"
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="strReferralOutDate"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function queryPUBHospitalBOByReferralOutDate_L(ByVal strReferralOutDate As String) As System.Data.DataSet
        Dim strSql As New StringBuilder
        Dim ds As Data.DataSet
        strSql.Append("SELECT H.Hospital_Code FROM PUB_Hospital H WHERE H.Language_Type_Id = '1'  ")

        strSql.Append(" AND H.Effect_Date <= '").Append(strReferralOutDate).Append("' ")
        strSql.Append(" AND H.End_Date > '").Append(strReferralOutDate).Append("' ")
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
#Region "20091012 PUBHospitalBO_E2 查詢信息 by Add Tor"
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function queryPUBHospitalBOForPrint_L() As System.Data.DataSet
        Dim strSql As New StringBuilder
        Dim ds As Data.DataSet
        strSql.Append("select top 1 ")
        strSql.Append("PH.Hospital_Name ")
        strSql.Append(", PH.Hospital_Code ")
        strSql.Append(", PH.Address ")
        strSql.Append(", PH.Telephone ")
        strSql.Append(", PH.Fax ")
        strSql.Append(",REF_Exam_URL = (SELECT top 1 Config_Value FROM PUB_Config where Config_Name = 'REF_Exam_URL')	 ")
        strSql.Append(",REF_E_Mail = (SELECT top 1 Config_Value FROM PUB_Config where Config_Name = 'REF_E_Mail') ")
        strSql.Append("from PUB_Hospital PH ")
        strSql.Append("where PH.Language_Type_Id=1 and  PH.Effect_Date <= GETDATE() and  PH.End_Date >= GETDATE()	 ")

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
