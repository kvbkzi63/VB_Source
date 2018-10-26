'/*
'*****************************************************************************
'*
'*    Page/Class Name:  病患重大傷病記錄檔
'*              Title:	PUBPatientSevereDiseaseBO_E2
'*        Description:	
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Will,Lin
'*        Create Date:	2015-09-14
'*      Last Modifier:	Will,Lin
'*   Last Modify Date:	2015-09-14
'*
'*****************************************************************************
'*/

Imports System.Data.SqlClient
Imports System.Transactions

Imports Syscom.Comm.Utility
Imports Syscom.Server.SQL
Imports Syscom.Server.BO
Imports System.Text
Imports Syscom.Comm.EXP



Public Class PUBPatientSevereDiseaseBO_E2
    Inherits PubPatientSevereDiseaseBO

#Region "     使用的Instance宣告 "

    Private Shared myInstance As PUBPatientSevereDiseaseBO_E2
    Public Overloads Shared Function GetInstance() As PUBPatientSevereDiseaseBO_E2
        If myInstance Is Nothing Then
            myInstance = New PUBPatientSevereDiseaseBO_E2
        End If
        Return myInstance
    End Function

#End Region

#Region "     查詢 Method "
#Region "20100422 病患重大傷病記錄檔-查詢 add by Runxia"
    ''' <summary>
    ''' 病患重大傷病記錄檔
    ''' </summary>
    ''' <param name="strChartNo">病歷號</param>
    ''' <param name="strIcdCode">ICD代碼</param>
    ''' <param name="dateEffectDate">生效日期</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function queryPubPatientSevereDiseaseByCond_L(ByVal strChartNo As String, ByVal strIcdCode As String, ByVal dateEffectDate As Date, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = conn Is Nothing
        Try
            If connFlag Then
                conn = getConnection()
            End If
            Dim ds As DataSet
            Dim sqlConn As SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim strSql As StringBuilder = New StringBuilder()

            strSql.Append("SELECT A.*,B.Idno,B.Patient_Name,C.Disease_En_Name  FROM  ")
            strSql.Append(" ").Append(tableName + " A")
            strSql.Append(" ").Append("LEFT OUTER JOIN PUB_Patient B ON A.Chart_No=B.Chart_No")
            'strSql.Append(" ").Append("LEFT OUTER JOIN")
            'strSql.Append(" ").Append("(SELECT TOP (1) Disease_En_Name, Icd_Code")
            'strSql.Append(" ").Append("FROM PUB_Disease")
            'strSql.Append(" ").Append("WHERE (Dc = 'N') AND (Disease_Type_Id = '1') and Icd_Code =@Icd_Code) AS C ON ")
            'strSql.Append(" ").Append("A.Icd_Code = C.Icd_Code ")
            strSql.Append(" ").Append("LEFT JOIN PUB_Disease C ON (A.Icd_Code = C.Icd_Code and C.Dc = 'N' AND C.Disease_Type_Id = '1') ")
            strSql.AppendLine("")
            strSql.Append(" ").Append("where 1=1 ")
            If strChartNo <> "" Then
                strSql.Append(" and A.Chart_No = ").Append(" @Chart_No ")
            End If
            If strIcdCode <> "" Then
                strSql.Append(" and A.Icd_Code = ").Append(" @Icd_Code ")
            End If
            If Not dateEffectDate.Equals(System.DateTime.MinValue) Then
                strSql.Append(" ").Append("and A.Effect_Date= @Effect_Date ")
            End If
            command.CommandText = strSql.ToString()
            command.Parameters.AddWithValue("@Chart_No", strChartNo)
            command.Parameters.AddWithValue("@Icd_Code", strIcdCode)
            If Not dateEffectDate.Equals(System.DateTime.MinValue) Then
                command.Parameters.AddWithValue("@Effect_Date", dateEffectDate)
            End If

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, SchemaType.Mapped, tableName)
            End Using
            Return ds
        Catch sqlex As SqlException
            'LOGDelegate.GetInstance.getFileLogger(Me).Error(sqlex.ToString)
            Throw sqlex
        Catch ex As Exception
            'LOGDelegate.GetInstance.getFileLogger(Me).Error(ex.ToString)
            Throw New CommonException("CMMCMMD001", ex)
        Finally
            If connFlag Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try

    End Function
    ''' <summary>
    ''' 由Icd_Code查找對應的診斷英文名
    ''' </summary>
    ''' <param name="strIcdCode">Icd_code</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function queryPubDiseaseEnNameByIcdCode_L(ByVal strIcdCode As String) As DataSet

        Try

            'Dim IcdNoDot As String = Replace(strIcdCode, ".", "")
            Dim ds As DataSet
            Dim sqlConn As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As StringBuilder = New StringBuilder()

            '2017.1.3 by Michelle 修改查詢ICD_code SQL
            'ICD_code加入小數點
            content.AppendLine("select icd_code,Disease_En_Name,Disease_Name ")
            content.AppendLine("from PUB_Disease   where Disease_Type_Id='1' and Dc='N' and (Is_Severe_Disease='Y' or Is_Psy_Severe_Disease='Y') ")
            content.Append("and Icd_Code='").Append(strIcdCode).Append("'")
            content.AppendLine("")
            content.AppendLine("union all")
            content.AppendLine("select icd_code,Disease_En_Name,Disease_Name ")
            content.AppendLine("from PUB_Disease_ICD10  where Disease_Type_Id='1' and Dc='N' and  (Is_Severe_Disease='Y' or Is_Psy_Severe_Disease='Y') ")
            content.Append("and Icd_Code='").Append(strIcdCode).Append("'")
            content.AppendLine("")

            'content.Append(" SELECT  Disease_En_Name")
            'content.Append(" From PUB_Disease ")
            'content.Append(" Where  Dc='N' And Disease_Type_Id = '1' And Icd_Code= '").Append(strIcdCode).Append("'")
            command.CommandText = content.ToString
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, SchemaType.Mapped, tableName)
            End Using
            Return ds
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

#Region "病歷號查詢(顯示是否)"

    ''' <summary>
    '''以ＰＫ查詢資料
    ''' </summary>
    ''' <remarks></remarks>
    Public Function queryByPKYNShow(ByRef pkChartNo As System.String, ByRef pkIcdCode As System.String, ByRef pkEffectDate As Date) As System.Data.DataSet

        Try
            Dim ds As DataSet
            Dim sqlConn As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As New StringBuilder

            'content.AppendLine("select   ")
            'content.AppendLine(" Chart_No , Icd_Code , Effect_Date , Certificate_Sn , End_Date ,  ")
            'content.AppendLine(" Is_From_Iccard , case Is_From_Iccard when 'Y' then '是' when 'N' then '否' end as Is_From_Iccard_Name ,")
            'content.AppendLine(" Create_User , Create_Time , Modified_User , Modified_Time                 from " & tableName)
            'content.AppendLine("   where Chart_No=@Chart_No ")
            'command.CommandText = content.ToString
            'command.Parameters.AddWithValue("@Chart_No", pk_Chart_No)

            'content.AppendLine("select   ")
            'content.AppendLine(" A.Chart_No , B.Idno , B.Patient_Name ,substring(dbo.AdToRocTime(A.Effect_Date),0,10) As Effect_Date ,A.Icd_Code , ")
            'content.AppendLine("ISNULL(A.Certificate_Sn,'')Certificate_Sn , substring(dbo.AdToRocTime(A.End_Date),0,10) As End_Date ,")
            'content.AppendLine(" A.Is_From_Iccard , case A.Is_From_Iccard when 'Y' then '是' when 'N' then '否' end as Is_From_Iccard_Name ,")
            'content.AppendLine(" A.Create_User ,substring(dbo.AdToRocTime(A.Create_Time),0,10) As Create_Time , A.Modified_User ,substring(dbo.AdToRocTime(A.Modified_Time),0,10) As Modified_Time ")
            'content.AppendLine(" from " & tableName + " A")
            'content.AppendLine(" LEFT OUTER JOIN PUB_Patient B ON A.Chart_No=B.Chart_No")
            'content.AppendLine(" LEFT JOIN PUB_Disease C ON (A.Icd_Code = C.Icd_Code and C.Dc = 'N' AND C.Disease_Type_Id = '1') ")

            content.AppendLine("select ")
            content.AppendLine(" A.Chart_No , B.Idno , B.Patient_Name ,substring(dbo.AdToRocTime(A.Effect_Date),0,10) As Effect_Date ,A.Icd_Code  ")
            content.AppendLine(", case when C.Disease_En_Name is not null then C.Disease_En_Name else D.Disease_En_Name end as Disease_En_Name ")
            content.AppendLine(", case when C.Disease_Name is not null then C.Disease_Name else D.Disease_Name end as Disease_Name ")
            content.AppendLine(", ISNULL(A.Certificate_Sn,'')Certificate_Sn , substring(dbo.AdToRocTime(A.End_Date),0,10) As End_Date ")
            content.AppendLine(", A.Is_From_Iccard , case A.Is_From_Iccard when 'Y' then '是' when 'N' then '否' end as Is_From_Iccard_Name ")
            content.AppendLine(", A.Create_User ,substring(dbo.AdToRocTime(A.Create_Time),0,10) As Create_Time , A.Modified_User ,substring(dbo.AdToRocTime(A.Modified_Time),0,10) As Modified_Time ")
            content.AppendLine("from PUB_Patient_Severe_Disease A")
            content.AppendLine(" LEFT OUTER JOIN PUB_Patient B ON A.Chart_No=B.Chart_No")
            content.AppendLine("Left Join PUB_Disease C")
            content.AppendLine("on (C.Disease_Type_Id='1' and C.Dc='N'and (C.Is_Severe_Disease='Y' or C.Is_Psy_Severe_Disease='Y') and C.Icd_Code_Nodot=REPLACE(A.Icd_Code,'.',''))")
            content.AppendLine("Left Join PUB_Disease_ICD10 D")
            content.AppendLine("on (D.Disease_Type_Id='1' and D.Dc='N' and (D.Is_Severe_Disease='Y' or D.Is_Psy_Severe_Disease='Y') and D.Icd_Code_Nodot=REPLACE(A.Icd_Code,'.',''))")
            content.AppendLine("")
            content.AppendLine("   where 1=1 ")
            content.AppendLine("   and A.Chart_No=@Chart_No ")
            If pkIcdCode <> "" Then
                content.Append(" and A.Icd_Code = ").Append(" @Icd_Code ")
            End If
            If Not pkEffectDate.Equals(System.DateTime.MinValue) Then
                content.Append(" ").Append("and A.Effect_Date= @Effect_Date ")
            End If

            command.CommandText = content.ToString
            command.Parameters.AddWithValue("@Chart_No", pkChartNo)
            command.Parameters.AddWithValue("@Icd_Code", pkIcdCode)
            If Not pkEffectDate.Equals(System.DateTime.MinValue) Then
                command.Parameters.AddWithValue("@Effect_Date", pkEffectDate)
            End If


            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, SchemaType.Mapped, tableName)
            End Using
            Return ds
        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB911", ex)
        End Try
    End Function

#End Region



#End Region

End Class

