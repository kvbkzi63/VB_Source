'/*
'*****************************************************************************
'*
'*    Page/Class Name:  看診目的基本檔維護作業
'*              Title:	PubMedicalTypeBO_E1
'*        Description:	
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Eddie,Lu
'*        Create Date:	2015-11-11
'*      Last Modifier:	Eddie,Lu
'*   Last Modify Date:	2015-11-11
'*
'*****************************************************************************
'*/

Imports System.Data.SqlClient
Imports System.Transactions
Imports System.Text

Imports Syscom.Comm.Utility
Imports Syscom.Comm.EXP
Imports Syscom.Server.SQL
Imports Syscom.Server.BO


Public Class PubMedicalTypeBO_E1
    Inherits PubMedicalTypeBO

#Region "     使用的Instance宣告 "

    Private Shared myInstance As PubMedicalTypeBO_E1
    Public Overloads Function GetInstance() As PubMedicalTypeBO_E1
        If myInstance Is Nothing Then
            myInstance = New PubMedicalTypeBO_E1
        End If
        Return myInstance
    End Function

#End Region

#Region "     查詢 Method "

#Region " 看診目的基本檔維護作業 "

    ''' <summary>
    ''' 看診目的基本檔維護作業
    ''' </summary>
    ''' <param name="medicalTypeId" >看診目的</param>
    ''' <param name="medicalTypeName" >看診目的名稱</param>
    ''' <param name="medicalTypeCtrlId" >看診目的管控分類</param>
    ''' <param name="disIdentityCode" >預設優待身分</param>
    ''' <param name="Contract_Code1" >預設合約機構1</param>
    ''' <param name="Contract_Code2" >預設合約機構2</param>
    ''' <param name="partCode" >預設卡號</param>
    ''' <param name="cardSn" >預設IC卡就醫類別</param>
    ''' <param name="caseTypeId" >預設案件分類</param>
    ''' <param name="pedSort" >兒科排序</param>
    ''' <param name="surSort" >外科排序</param>
    ''' <param name="medSort" >內科排序</param>
    ''' <param name="entSort" >耳鼻喉科排序</param>
    ''' <param name="uroSort" >泌尿科排序</param>
    ''' <param name="rehSort" >復健科排序</param>
    ''' <param name="ipdSort" >住院排序</param>
    ''' <param name="opdSort" >門診排序</param>
    ''' <param name="emgSort" >急診排序</param>
    ''' <returns>Dataset</returns>
    ''' <remarks>by Eddie,Lu on 2015-11-11</remarks>
    Public Function query(ByRef medicalTypeId As String, ByRef medicalTypeName As String, ByRef medicalTypeCtrlId As String, ByRef disIdentityCode As String, ByRef Contract_Code1 As String, ByRef Contract_Code2 As String, ByRef partCode As String, ByRef cardSn As String, ByRef icMedicalTypeId As String, ByRef caseTypeId As String, ByVal pedSort As Integer, ByVal surSort As Integer, ByVal medSort As Integer, ByVal entSort As Integer, ByVal uroSort As Integer, ByRef rehSort As Integer, ByVal ipdSort As Integer, ByVal opdSort As Integer, ByVal emgSort As Integer, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim ds As DataSet

            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As New StringBuilder
            content.AppendLine("select   ")
            content.AppendLine(" Medical_Type_Id , Medical_Type_Name , Medical_Type_Ctrl_Id , Dis_Identity_Code , Contract_Code1 ,  ")
            content.AppendLine(" Contract_Code2 , Part_Code , Card_Sn , IC_Medical_Type_Id , Case_Type_Id ,  ")
            content.AppendLine(" Dc , Create_User , Right('0000'+ltrim(dbo.AdToRocDate (Create_Time)),9) AS  'Create_Time' , Modified_User , Right('0000'+ltrim(dbo.AdToRocDate (Modified_Time)),9) AS   'Modified_Time' ,  ")
            content.AppendLine(" PED_Sort , SUR_Sort , MED_Sort , ENT_Sort , URO_Sort ,  ")
            content.AppendLine(" REH_Sort , IPD_Sort , Is_Register_Fee , Is_Examine , Is_Pha_Services ,  ")
            content.AppendLine(" OPD_Sort , EMG_Sort                from " & tableName)
            content.AppendLine(" where 1 = 1 ")

            '有值則追加條件
            If medicalTypeId <> "" Then
                content.AppendLine("   and Medical_Type_Id=@Medical_Type_Id            ")
            End If
            If medicalTypeName <> "" Then
                content.AppendLine("   and Medical_Type_Name=@Medical_Type_Name            ")
            End If
            If medicalTypeCtrlId <> "" Then
                content.AppendLine("   and Medical_Type_Ctrl_Id=@Medical_Type_Ctrl_Id            ")
            End If
            If disIdentityCode <> "" Then
                content.AppendLine("   and Dis_Identity_Code=@Dis_Identity_Code            ")
            End If
            If Contract_Code1 <> "" Then
                content.AppendLine("   and Contract_Code1=@Contract_Code1            ")
            End If
            If Contract_Code2 <> "" Then
                content.AppendLine("   and Contract_Code2=@Contract_Code2            ")
            End If
            If partCode <> "" Then
                content.AppendLine("   and Part_Code=@Part_Code            ")
            End If
            If cardSn <> "" Then
                content.AppendLine("   and Card_Sn=@Card_Sn            ")
            End If
            If icMedicalTypeId <> "" Then
                content.AppendLine("   and IC_Medical_Type_Id=@IC_Medical_Type_Id            ")
            End If
            If caseTypeId <> "" Then
                content.AppendLine("   and Case_Type_Id=@Case_Type_Id            ")
            End If
            'If dc <> "" Then
            '    content.AppendLine("   and Dc=@Dc            ")
            'End If
            If pedSort <> 9999 Then
                content.AppendLine("   and PED_Sort=@PED_Sort            ")
            End If
            If surSort <> 9999 Then
                content.AppendLine("   and SUR_Sort=@SUR_Sort            ")
            End If
            If medSort <> 9999 Then
                content.AppendLine("   and MED_Sort=@MED_Sort            ")
            End If
            If entSort <> 9999 Then
                content.AppendLine("   and ENT_Sort=@ENT_Sort            ")
            End If
            If uroSort <> 9999 Then
                content.AppendLine("   and URO_Sort=@URO_Sort            ")
            End If
            If rehSort <> 9999 Then
                content.AppendLine("   and REH_Sort=@REH_Sort            ")
            End If
            If ipdSort <> 9999 Then
                content.AppendLine("   and IPD_Sort=@IPD_Sort            ")
            End If
            'If isRegisterFee <> "" Then
            '    content.AppendLine("   and Is_Register_Fee=@Is_Register_Fee            ")
            'End If
            'If isExamine <> "" Then
            '    content.AppendLine("   and Is_Examine=@Is_Examine            ")
            'End If
            'If isPhaServices <> "" Then
            '    content.AppendLine("   and Is_Pha_Services=@Is_Pha_Services            ")
            'End If
            If opdSort <> 9999 Then
                content.AppendLine("   and OPD_Sort=@OPD_Sort            ")
            End If
            If emgSort <> 9999 Then
                content.AppendLine("   and EMG_Sort=@EMG_Sort            ")
            End If



            command.CommandText = content.ToString

            command.Parameters.AddWithValue("@Medical_Type_Id", medicalTypeId)
            '有值則追加條件
            command.Parameters.AddWithValue("@Medical_Type_Name", medicalTypeName)
            command.Parameters.AddWithValue("@Medical_Type_Ctrl_Id", medicalTypeCtrlId)
            command.Parameters.AddWithValue("@Dis_Identity_Code", disIdentityCode)
            command.Parameters.AddWithValue("@Contract_Code1", Contract_Code1)
            command.Parameters.AddWithValue("@Contract_Code2", Contract_Code2)
            command.Parameters.AddWithValue("@Part_Code", partCode)
            command.Parameters.AddWithValue("@Card_Sn", cardSn)
            command.Parameters.AddWithValue("@IC_Medical_Type_Id", icMedicalTypeId)
            command.Parameters.AddWithValue("@Case_Type_Id", caseTypeId)
            '    command.Parameters.AddWithValue("@Dc", dc)
            command.Parameters.AddWithValue("@PED_Sort", pedSort)
            command.Parameters.AddWithValue("@SUR_Sort", surSort)
            command.Parameters.AddWithValue("@MED_Sort", medSort)
            command.Parameters.AddWithValue("@ENT_Sort", entSort)
            command.Parameters.AddWithValue("@URO_Sort", uroSort)
            command.Parameters.AddWithValue("@REH_Sort", rehSort)
            command.Parameters.AddWithValue("@IPD_Sort", ipdSort)
            '    command.Parameters.AddWithValue("@Is_Register_Fee", )
            '    command.Parameters.AddWithValue("@Is_Examine", )
            '    command.Parameters.AddWithValue("@Is_Pha_Services", )
            command.Parameters.AddWithValue("@OPD_Sort", opdSort)
            command.Parameters.AddWithValue("@EMG_Sort", emgSort)

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
            End Using

            Return ds

        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"查詢"})
        Finally

            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If

        End Try

    End Function

#End Region

#Region " 取得Syscode "

    ''' <summary>
    ''' 取得Syscode
    ''' </summary>
    ''' <returns>Dataset</returns>
    ''' <remarks>by Eddie,Lu on 2015-11-11</remarks>
    Public Function queryCboData(Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim ds As DataSet

            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If


            '取得syscode
            ds = Syscom.Server.CMM.CMMDelegate.getInstance.CMMSysCodeBSSysCodeQueryMuti(New Integer() {"20", "102", "504"}, conn)

            Dim dtPubDisIdentity As DataTable = queryPubDisIdentity().Tables(0).Copy
            ds.Tables.Add(dtPubDisIdentity)

            Dim dtPubContract As DataTable = queryPubContract().Tables(0).Copy
            ds.Tables.Add(dtPubContract)

            Dim dtPubPart As DataTable = queryPubPart().Tables(0).Copy
            ds.Tables.Add(dtPubPart)


            Return ds

        Catch sqlex As SQLException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"查詢"})
        Finally

            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If

        End Try

    End Function

#End Region

    '僅後端用query
#Region " 取得PUB_Dis_Identity資料 "

    ''' <summary>
    ''' 取得PUB_Dis_Identity資料
    ''' </summary>
    ''' <returns>Dataset</returns>
    ''' <remarks>by Eddie,Lu on 2015-11-11</remarks>
    Public Function queryPubDisIdentity(Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim ds As DataSet

            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = "select  Dis_Identity_Code as Code_Id, Dis_Identity_Name as Code_Name  from  PUB_Dis_Identity"

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("PUB_Dis_Identity")
                adapter.Fill(ds, "PUB_Dis_Identity")
            End Using

            Return ds

        Catch sqlex As SQLException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"查詢"})
        Finally

            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If

        End Try

    End Function

#End Region

#Region " 取得PUB_Contract資料 "

    ''' <summary>
    ''' 取得PUB_Contract資料
    ''' </summary>
    ''' <returns>Dataset</returns>
    ''' <remarks>by Eddie,Lu on 2015-11-11</remarks>
    Public Function queryPubContract(Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim ds As DataSet

            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = _
            "select  Contract_Code as Code_Id, Contract_Name as Code_Name   from  PUB_Contract" '& _
            '" where Contract_Type_Id = @Contract_Type_Id"

            'command.Parameters.AddWithValue("@Contract_Type_Id", contractTypeId)

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("PUB_Contract")
                adapter.Fill(ds, "PUB_Contract")
            End Using

            Return ds

        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"查詢"})
        Finally

            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If

        End Try

    End Function

#End Region

#Region " 取得PUB_Part資料 "

    ''' <summary>
    ''' 取得PUB_Part資料
    ''' </summary>
    ''' <returns>Dataset</returns>
    ''' <remarks>by Eddie,Lu on 2015-11-11</remarks>
    Public Function queryPubPart(Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim ds As DataSet

            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = _
            "select  Part_Code as Code_Id, Part_Name as Code_Name   from PUB_Part "

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("PUB_Part")
                adapter.Fill(ds, "PUB_Part")
            End Using

            Return ds

        Catch sqlex As SQLException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"查詢"})
        Finally

            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If

        End Try

    End Function

#End Region


#End Region

End Class

