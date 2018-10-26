'/*
'*****************************************************************************
'*
'*    Page/Class Name:	PUBOrderBO_E2.vb
'*              Title:	醫令項目基本檔維護
'*        Description:	醫令項目基本檔維護
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd.
'*            @author:	ming
'*        Create Date:	2009/07/02
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


Public Class PUBOrderBO_E2
    Inherits PubOrderBO
    Private Shared myInstance As PUBOrderBO_E2

    Public Overloads Shared Function getInstance() As PUBOrderBO_E2
        If myInstance Is Nothing Then
            myInstance = New PUBOrderBO_E2()
        End If
        Return myInstance
    End Function
    ''' <summary>
    ''' 查詢醫令項目基本檔 常用處置維護
    ''' </summary>
    ''' <param name="strOrderCode">醫令代碼</param>
    ''' <param name="strOrderName">醫令名稱</param>
    ''' <param name="strLanguageFlag">語言類型</param>
    ''' <returns>DataSet</returns>
    ''' <remarks>醫令代碼完全匹配;根據語言類型,醫令名稱左匹配</remarks>
    Public Overloads Function queryPUBOrderByCond(ByVal strOrderCode As String, ByVal strOrderName As String, ByVal strLanguageFlag As String) As System.Data.DataSet
        Dim ds As Data.DataSet
        Dim strSql As New StringBuilder
        strSql.Append("Select Order_Code,Order_En_Name,Order_Name ,Order_Type_Id  From ")
        strSql.Append(tableName)
        strSql.Append(" Where (DC<>'Y' or DC is null)   ")
        strSql.Append(" AND '").Append(Now().ToString("yyyy/MM/dd")).Append("' >= Effect_Date ")
        strSql.Append(" AND '").Append(Now().ToString("yyyy/MM/dd")).Append("' <= End_Date ")
        strSql.Append(" And ( Order_Type_Id in ('D','K','I') Or (Order_Type_Id='H' And Treatment_Type_Id not in ('3' , '4')) )")
        If strOrderCode.Trim <> "" Then
            strSql.Append(" AND Order_Code like '").Append(strOrderCode).Append("%' ")
        End If
        If strLanguageFlag.Trim = "1" Then
            If strOrderName.Trim <> "" Then
                strSql.Append(" AND Order_En_Name like '").Append(strOrderName).Append("%' ")
            End If
        Else
            If strOrderName.Trim <> "" Then
                strSql.Append(" AND Order_Name like '").Append(strOrderName).Append("%' ")
            End If
        End If
        strSql.Append(" Order By Order_Code")
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

    ''' <summary>
    ''' 查詢醫令項目基本檔 常用檢驗(查)維護
    ''' </summary>
    ''' <param name="strOrderCode">醫令代碼</param>
    ''' <param name="strOrderName">醫令名稱</param>
    ''' <param name="strLanguageFlag">語言類型</param>
    ''' <returns>DataSet</returns>
    ''' <remarks>醫令代碼完全匹配;根據語言類型,醫令名稱左匹配</remarks>
    Public Overloads Function queryPUBOrderHByCond(ByVal strOrderCode As String, ByVal strOrderName As String, ByVal strLanguageFlag As String) As System.Data.DataSet
        Dim ds As Data.DataSet
        Dim strSql As New StringBuilder
        strSql.Append("Select Order_Code,Order_En_Name,Order_Name From ")
        strSql.Append(tableName)
        strSql.Append(" Where (DC<>'Y' or DC is null)   ")
        strSql.Append(" AND '").Append(Now().ToString("yyyy/MM/dd")).Append("' >= Effect_Date ")
        strSql.Append(" AND '").Append(Now().ToString("yyyy/MM/dd")).Append("' <= End_Date ")
        strSql.Append(" And Order_Type_Id = 'H' and Treatment_Type_Id in ('3' , '4') ")
        If strOrderCode.Trim <> "" Then
            strSql.Append(" AND Order_Code like '").Append(strOrderCode).Append("%' ")
        End If
        If strLanguageFlag.Trim = "1" Then
            If strOrderName.Trim <> "" Then
                strSql.Append(" AND Order_En_Name like '").Append(strOrderName).Append("%' ")
            End If
        Else
            If strOrderName.Trim <> "" Then
                strSql.Append(" AND Order_Name like '").Append(strOrderName).Append("%' ")
            End If
        End If
        strSql.Append(" Order By Order_Code")
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

    '''' <summary>
    '''' 查詢醫令項目基本檔 常用診斷維護
    '''' </summary>
    '''' <param name="strOrderCode">醫令代碼</param>
    '''' <param name="strOrderName">醫令名稱</param>
    '''' <param name="strLanguageFlag">語言類型</param>
    '''' <returns>DataSet</returns>
    '''' <remarks>醫令代碼完全匹配;根據語言類型,醫令名稱左匹配</remarks>
    'Public Overloads Function queryPUBOrderAByCond(ByVal strOrderCode As String, ByVal strOrderName As String, ByVal strLanguageFlag As String) As System.Data.DataSet
    '    Dim ds As Data.DataSet
    '    Dim strSql As New StringBuilder
    '    strSql.Append("Select Order_Code,Order_En_Name,Order_Name From ")
    '    strSql.Append(tableName)
    '    strSql.Append(" Where (DC<>'Y' or DC is null)   ")
    '    strSql.Append(" AND '").Append(Now().ToString("yyyy/MM/dd")).Append("' >= Effect_Date ")
    '    strSql.Append(" AND '").Append(Now().ToString("yyyy/MM/dd")).Append("' <= End_Date ")
    '    'strSql.Append(" And Order_Type_Id = 'H' and Treatment_Type_Id in ('3' , '4') ")
    '    If strOrderCode.Trim <> "" Then
    '        strSql.Append(" AND Order_Code like '").Append(strOrderCode).Append("%' ")
    '    End If
    '    If strLanguageFlag.Trim = "1" Then
    '        If strOrderName.Trim <> "" Then
    '            strSql.Append(" AND Order_En_Name like '").Append(strOrderName).Append("%' ")
    '        End If
    '    Else
    '        If strOrderName.Trim <> "" Then
    '            strSql.Append(" AND Order_Name like '").Append(strOrderName).Append("%' ")
    '        End If
    '    End If
    '    strSql.Append(" Order By Order_Code")
    '    Try
    '        Using sqlConnection As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
    '            Dim adapter As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqlConnection)
    '            ds = New Data.DataSet(tableName)
    '            adapter.Fill(ds, tableName)
    '            adapter.FillSchema(ds, Data.SchemaType.Mapped, tableName)
    '        End Using
    '    Catch ex As Exception
    '        LOGDelegate.GetInstance.getFileLogger(Me).Error(ex.ToString)
    '        Throw ex
    '    End Try
    '    Return ds
    'End Function

    ''' <summary>
    ''' 查詢醫令項目基本檔 常用藥品維護
    ''' </summary>
    ''' <param name="strOrderCode">醫令代碼</param>
    ''' <param name="strOrderName">醫令名稱</param>
    ''' <param name="strLanguageFlag">語言類型</param>
    ''' <returns>DataSet</returns>
    ''' <remarks>醫令代碼完全匹配;根據語言類型,醫令名稱左匹配</remarks>
    Public Overloads Function queryPUBOrderEByCond(ByVal strOrderCode As String, ByVal strOrderName As String, ByVal strLanguageFlag As String) As System.Data.DataSet
        Dim ds As Data.DataSet
        Dim strSql As New StringBuilder
        strSql.Append("Select B.Order_Code,B.Order_En_Name,B.Order_Name,A.Base_Dosage ,A.Usage_Code,A.Frequency_Code,A.Order_Unit1,B.Charge_Unit From  OPH_Pharmacy_Base A Left Join OPH_Property C  ON A.Pharmacy_12_Code=C.Pharmacy_12_Code And C.Property_Id not in ('09' , '10' ,'14' ) , PUB_Order B  ")
        strSql.Append(" Where   (A.DC<>'Y' or A.DC is null) And (B.DC<>'Y' or B.DC is null) And A.Order_Code=B.Order_Code And B.Order_Type_Id='E'  ")
        strSql.Append(" AND '").Append(Now().ToString("yyyy/MM/dd")).Append("' >= B.Effect_Date ")
        strSql.Append(" AND '").Append(Now().ToString("yyyy/MM/dd")).Append("' <= B.End_Date ")
        If strOrderCode.Trim <> "" Then
            strSql.Append(" AND B.Order_Code like '").Append(strOrderCode).Append("%' ")
        End If
        If strLanguageFlag.Trim = "1" Then
            If strOrderName.Trim <> "" Then
                strSql.Append(" AND B.Order_En_Name like '").Append(strOrderName).Append("%' ")
            End If
        Else
            If strOrderName.Trim <> "" Then
                strSql.Append(" AND B.Order_Name like '").Append(strOrderName).Append("%' ")
            End If
        End If
        strSql.Append(" Order By A.Order_Code")
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

    ''' <summary>
    ''' 查詢醫令項目基本檔 常用衛材維護
    ''' </summary>
    ''' <param name="strOrderCode">醫令代碼</param>
    ''' <param name="strOrderName">醫令名稱</param>
    ''' <param name="strLanguageFlag">語言類型</param>
    ''' <returns>DataSet</returns>
    ''' <remarks>醫令代碼完全匹配;根據語言類型,醫令名稱左匹配</remarks>
    Public Overloads Function queryPUBOrderGByCond(ByVal strOrderCode As String, ByVal strOrderName As String, ByVal strLanguageFlag As String) As System.Data.DataSet
        Dim ds As Data.DataSet
        Dim strSql As New StringBuilder
        strSql.Append("Select Order_Code,Order_En_Name,Order_Name From ")
        strSql.Append(tableName)
        strSql.Append(" Where (DC<>'Y' or DC is null)   ")
        strSql.Append(" AND '").Append(Now().ToString("yyyy/MM/dd")).Append("' >= Effect_Date ")
        strSql.Append(" AND '").Append(Now().ToString("yyyy/MM/dd")).Append("' <= End_Date ")
        strSql.Append(" And Order_Type_Id = 'G'  ")
        If strOrderCode.Trim <> "" Then
            strSql.Append(" AND Order_Code like '").Append(strOrderCode).Append("%' ")
        End If
        If strLanguageFlag.Trim = "1" Then
            If strOrderName.Trim <> "" Then
                strSql.Append(" AND Order_En_Name like '").Append(strOrderName).Append("%' ")
            End If
        Else
            If strOrderName.Trim <> "" Then
                strSql.Append(" AND Order_Name like '").Append(strOrderName).Append("%' ")
            End If
        End If
        strSql.Append(" Order By Order_Code")
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
    Public Overloads Function queryPUBOrderJByCond(ByVal strOrderCode As String, ByVal strOrderName As String, ByVal strLanguageFlag As String) As System.Data.DataSet
        Dim ds As Data.DataSet
        Dim strSql As New StringBuilder
        strSql.Append("Select Order_Code,Order_En_Name,Order_Name From ")
        strSql.Append(tableName)
        strSql.Append(" Where (DC<>'Y' or DC is null)   ")
        strSql.Append(" AND '").Append(Now().ToString("yyyy/MM/dd")).Append("' >= Effect_Date ")
        strSql.Append(" AND '").Append(Now().ToString("yyyy/MM/dd")).Append("' <= End_Date ")
        strSql.Append(" And Order_Type_Id = 'J'  ")
        If strOrderCode.Trim <> "" Then
            strSql.Append(" AND Order_Code like '").Append(strOrderCode).Append("%' ")
        End If
        If strLanguageFlag.Trim = "1" Then
            If strOrderName.Trim <> "" Then
                strSql.Append(" AND Order_En_Name like '").Append(strOrderName).Append("%' ")
            End If
        Else
            If strOrderName.Trim <> "" Then
                strSql.Append(" AND Order_Name like '").Append(strOrderName).Append("%' ")
            End If
        End If
        strSql.Append(" Order By Order_Code")
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


#Region "20090730 PUBOrderBO 查詢醫令項目基本檔  Order_Type_Id(醫令類型)=’H’(檢驗檢查) , add by Mark"
    ''' <summary>
    ''' 查詢醫令項目基本檔, Order_Type_Id(醫令類型)=’H’(檢驗檢查)
    ''' </summary>
    ''' <param name="strOrderCode">醫令代碼</param>
    ''' <param name="strOrderName">醫令名稱</param>
    ''' <param name="strLanguageFlag">語言類型</param>
    ''' <returns>DataSet</returns>
    ''' <remarks>醫令代碼完全匹配;根據語言類型,醫令名稱左匹配</remarks>
    Public Overloads Function queryPUBOrderByCond2(ByVal strOrderCode As String, ByVal strOrderName As String, ByVal strLanguageFlag As String) As System.Data.DataSet
        Dim ds As Data.DataSet
        Dim strSql As New StringBuilder
        strSql.Append("Select Order_Code,Order_En_Name,Order_Name From ")
        strSql.Append(tableName)
        strSql.Append(" Where Order_Type_Id='H' AND DC<>'Y'  ")
        strSql.Append(" AND '").Append(Now().ToString("yyyy/MM/dd")).Append("' >= Effect_Date ")
        strSql.Append(" AND '").Append(Now().ToString("yyyy/MM/dd")).Append("' <= End_Date ")
        If strOrderCode.Trim <> "" Then
            strSql.Append(" AND Order_Code like '").Append(strOrderCode).Append("%' ")
        End If
        If strLanguageFlag.Trim = "1" Then
            If strOrderName.Trim <> "" Then
                strSql.Append(" AND Order_En_Name like '").Append(strOrderName).Append("%' ")
            End If
        Else
            If strOrderName.Trim <> "" Then
                strSql.Append(" AND Order_Name like '").Append(strOrderName).Append("%' ")
            End If
        End If
        strSql.Append(" Order By Order_Code")
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
#Region "200910.20 PUBOrderBO 查詢醫令項目基本檔  Order_Type_Id(醫令類型)=’H’(檢驗檢查) , add by Tor"
    ''' <summary>
    ''' 查詢醫令項目基本檔, Order_Type_Id(醫令類型)=’H’(檢驗檢查)
    ''' </summary>
    ''' <param name="strOrderCode">醫令代碼</param>
    ''' <param name="strOrderTime">傳入時間</param>
    ''' <returns>DataSet</returns>
    ''' <remarks>醫令代碼完全匹配;根據語言類型,醫令名稱左匹配</remarks>
    Public Function queryPUBOrderByCond3(ByVal strOrderCode As String, ByVal strOrderTime As String) As System.Data.DataSet
        Dim ds As Data.DataSet
        Dim strSql As New StringBuilder
        'SELECT Order_Name FROM PUB_Order WHERE Order_Code = Order_Code AND Effect_Date <= OR.Order_Time AND End_Date > OR.Order_Time
        strSql.Append("SELECT Order_Name FROM ")
        strSql.Append(tableName)
        strSql.Append(" Where Order_Code= ").Append(strOrderCode)
        strSql.Append(" AND Effect_Date <= '").Append(strOrderTime).Append("' ")
        strSql.Append(" AND End_Date> '").Append(strOrderTime).Append("' ")

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

    ''' <summary>
    ''' 查詢醫令項目基本檔, Order_Type_Id(醫令類型)=’H’(檢驗檢查) Dc = 'N'
    ''' </summary>
    ''' <param name="OutDate">傳入時間</param>
    ''' <returns>DataSet</returns>
    Public Function queryPubOrderDataByDate(ByVal OutDate As String) As DataSet
        Dim ds As Data.DataSet
        Dim strSql As New StringBuilder
        'SELECT Order_Code, Order_Name FROM PUB_Order WHERE Effect_Date<= (傳入轉出日期) AND End_Date > (傳入轉出日期) AND Dc = 'N' AND Order_Type_Id = 'H'
        strSql.Append("SELECT  Order_Code, Order_Name FROM PUB_Order ")
        strSql.Append(" WHERE  Dc = 'N' AND Order_Type_Id = 'H'  ")
        strSql.Append(" AND Effect_Date <= '").Append(OutDate).Append("' ")
        strSql.Append(" AND End_Date > '").Append(OutDate).Append("' ")

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

#Region "20091120 PUBOrderBO 查詢醫令項目基本檔 (檢驗檢查) , add by Dashan"
    ''' <summary>
    ''' 查詢醫令項目基本檔,(檢驗檢查) Dc = 'N'  
    ''' </summary>
    ''' <param name="strOrderCode">傳入時間</param>
    ''' <returns>DataSet</returns>
    Public Function queryPubOrderByOrderCode(ByVal strOrderCode As String) As DataSet
        Dim ds As Data.DataSet
        Dim strSql As New StringBuilder

        strSql.Append("SELECT Order_Code, Order_Name FROM PUB_Order ")
        strSql.Append("  WHERE  Dc = 'N'   ")
        strSql.Append("  AND Order_Code =  '").Append(strOrderCode).Append("' ")


        Try
            Using sqlConnection As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
                Dim adapter As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqlConnection)
                ds = New Data.DataSet(tableName)
                adapter.Fill(ds, tableName)
            End Using
        Catch ex As Exception
            Dim FunctName As String = String.Format("{0}-{1}:", Me.GetType.Name, MethodBase.GetCurrentMethod.Name)
            LOGDelegate.getInstance.dbDebugMsg(FunctName)
            Throw ex
        End Try
        Return ds

    End Function

    ''' <summary>
    ''' 查詢醫令項目基本檔,(檢驗檢查) Dc = 'N'  
    ''' </summary>
    ''' <param name="strCollectionTypeId">收案條件類型</param>
    ''' <param name="strCollectionCodeS">代碼起</param>
    ''' <param name="strCollectionCodeE">代碼迄</param>
    ''' <returns>DataSet</returns>
    Public Function queryPubOrderAndDisease(ByVal strCollectionTypeId As String, ByVal strCollectionCodeS As String, ByVal strCollectionCodeE As String, ByVal conn As SqlConnection) As DataSet
        Dim ds As Data.DataSet
        Dim strSql As New StringBuilder

        If strCollectionTypeId = "2" Then
            strSql.Append("SELECT * FROM PUB_Order ")
            strSql.Append("  WHERE  Dc = 'N'   ")
            strSql.Append("  AND Order_Code =  '").Append(strCollectionCodeS).Append("' ")
        Else
            strSql.Append(" ").Append("select A.Icd_Code as Order_Code from  PUB_Disease A ")
            strSql.Append(" ").Append("where A.DC = 'N' and A.Icd_Code Between '" & strCollectionCodeS & "'  ")
            strSql.Append(" ").Append("and '" & strCollectionCodeE & "' ")

        End If

        Try
            Using sqlConnection As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
                Dim adapter As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, conn)
                ds = New Data.DataSet(tableName)
                adapter.Fill(ds, tableName)
            End Using
        Catch ex As Exception
            Dim FunctName As String = String.Format("{0}-{1}:", Me.GetType.Name, MethodBase.GetCurrentMethod.Name)
            LOGDelegate.getInstance.dbDebugMsg(FunctName)
            Throw ex
        End Try
        Return ds

    End Function

#End Region

#Region "20091211 PUBOrderBO 特殊屬性主檔維護 查詢醫令項目基本檔  add by Mark Zhang"
    ''' <summary>
    ''' 查詢醫令項目基本檔
    ''' </summary>
    ''' <param name="strOrderCode">醫令代碼</param>
    ''' <returns>DataSet</returns>
    Public Overloads Function queryPUBOrderByCode(ByVal strOrderCode As String) As System.Data.DataSet
        Dim ds As Data.DataSet
        Dim strSql As New StringBuilder
        strSql.Append(" Select Order_Code,Order_En_Name,Order_Name From ").Append(tableName)
        strSql.Append(" Where  DC<>'Y'  ")
        strSql.Append(" AND '").Append(Now().ToString("yyyy/MM/dd")).Append("' >= Effect_Date ")
        strSql.Append(" AND '").Append(Now().ToString("yyyy/MM/dd")).Append("' <= End_Date ")
        strSql.Append(" AND Order_Code = '").Append(strOrderCode).Append("'")
        strSql.Append(" Order By Order_Code")
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
#Region "20100330 PUBOrderBO 門診健檢套餐報價作業 查詢醫令項目基本檔  add by tony"

    Public Overloads Function queryPUBOrderForPackage(ByVal strOrderCode As String, ByVal strOrderName As String, ByVal strOrderEnName As String, ByVal strAccountId As String, ByVal strOrderTypeId As String, ByVal strQuotationDate As String) As System.Data.DataSet
        Dim ds As Data.DataSet
        Dim strSql As New StringBuilder
        strSql.Append(" ").Append(" select A.Order_Code as Order_Code,                                                                     ")
        strSql.Append(" ").Append(" A.Order_Name as Order_Name,                                                                            ")
        strSql.Append(" ").Append(" B.Exam_Detail_Desc as Exam,                                                                            ")
        strSql.Append(" ").Append(" C.Price as Price,                                                                                      ")
        strSql.Append(" ").Append(" D.Price as Price1,                                                                                     ")
        strSql.Append(" ").Append(" E.Default_Body_Site_Code as Default_Body_Site_Code,                                                    ")
        strSql.Append(" ").Append(" E.Default_Specimen_Id as Default_Specimen_Id,                                                          ")
        strSql.Append(" ").Append(" case when F.Discount_Ratio  <= '' then 1 else F.Discount_Ratio  end as Discount_Ratio from PUB_Order A ")
        strSql.Append(" ").Append(" left outer join OHM_Exam_Content B on A.Order_Code=B.Order_Code                                        ")
        strSql.Append(" ").Append(" left outer join PUB_Order_Price C on A.Order_Code=C.Order_Code                                         ")
        strSql.Append(" ").Append(" and '").Append(strQuotationDate).Append("'").Append("between C.Effect_Date and C.End_Date")
        strSql.Append(" ").Append("  and C.Main_Identity_Id = '1' and C.Dc = 'N'                                                           ")
        strSql.Append(" ").Append("  left outer join PUB_Order_Price D on A.Order_Code=D.Order_Code                                        ")
        strSql.Append(" ").Append("  and '").Append(strQuotationDate).Append("'").Append("between C.Effect_Date and C.End_Date")
        strSql.Append(" ").Append("  and D.Dc = 'N'                                                                                        ")
        strSql.Append(" ").Append("  left outer join PUB_Order_Examination E on A.Order_Code=E.Order_Code                                  ")
        strSql.Append(" ").Append("  left outer join OHM_Bottom_Dis_Set F on                                                               ")
        strSql.Append(" ").Append("   (A.Order_Code= F.Order_Code or  A.Account_Id=F.Account_Id or  A.Order_Type_Id=F.Order_Type_Id)       ")
        strSql.Append(" ").Append("  where 1=1                                                                                             ")
        If strOrderCode <> "" Then
            strSql.Append(" ").Append(" and A .Order_Code like '").Append(strOrderCode).Append("%' ")
        End If
        If strOrderName <> "" Then
            strSql.Append(" ").Append(" AND A.Order_Name like '%").Append(strOrderName).Append("%' ")
        End If
        If strOrderEnName <> "" Then
            strSql.Append(" ").Append(" AND A.Order_En_Name like '%").Append(strOrderEnName).Append("%' ")
        End If
        If strAccountId <> "" Then
            strSql.Append(" ").Append("and A.Account_Id ='").Append(strAccountId).Append("'")
        End If
        If strOrderTypeId <> "" Then
            strSql.Append(" ").Append(" AND A.Order_Type_Id ='").Append(strOrderTypeId).Append("'")
        End If
        strSql.Append(" ").Append("  and '").Append(strQuotationDate).Append("'").Append("between A.Effect_Date and A.End_Date and A.Dc = 'N'")
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

#Region "2010/06/02 add Johsn"
    ''' <summary>
    ''' 查詢醫令項目基本檔,(檢驗檢查) Dc = 'N'  
    ''' </summary>
    ''' <param name="strOrderCode">醫令項目碼</param>
    ''' <returns>DataSet</returns>
    Public Function queryPubOrderByOrderCode2(ByVal strOrderCode As String) As DataSet
        Dim ds As Data.DataSet
        Dim strSql As New StringBuilder

        strSql.Append("SELECT Order_Code, Order_Name, Order_Type_Id FROM PUB_Order ")
        strSql.Append("  WHERE  Dc = 'N'   ")
        strSql.Append("  AND Order_Code =  @Order_Code ")

        Try
            Using sqlConnection As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
                Dim command As SqlCommand = sqlConnection.CreateCommand()
                command.CommandText = strSql.ToString
                command.Parameters.AddWithValue("@Order_Code", strOrderCode)
                Dim adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New Data.DataSet(tableName)
                adapter.Fill(ds, tableName)
            End Using
        Catch ex As Exception
            Dim FunctName As String = String.Format("{0}-{1}:", Me.GetType.Name, MethodBase.GetCurrentMethod.Name)
            LOGDelegate.getInstance.dbDebugMsg(FunctName)
            Throw ex
        End Try
        Return ds

    End Function
#End Region

#Region "2012/06/26 add Prince"
    ''' <summary>
    ''' 查詢醫令項目基本檔,(檢驗檢查) Dc = 'N'  
    ''' </summary>
    ''' <param name="strOrderCode">醫令項目碼</param>
    ''' <returns>DataSet</returns>
    Public Function queryPubOrderByOrderCode3_L(ByVal strOrderCode As String) As DataSet
        Dim ds As Data.DataSet
        Dim strSql As New StringBuilder

        strSql.Append("SELECT order_code, " & vbCrLf)
        strSql.Append("       order_name " & vbCrLf)
        strSql.Append("FROM   pub_order " & vbCrLf)
        strSql.Append("WHERE  order_code = @Order_Code " & vbCrLf)
        strSql.Append("       AND CONVERT(VARCHAR(10), Getdate(), 120) BETWEEN effect_date AND end_date " & vbCrLf)
        strSql.Append("       AND Dc = 'N' ")

        Try
            Using sqlConnection As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
                Dim command As SqlCommand = sqlConnection.CreateCommand()
                command.CommandText = strSql.ToString
                command.Parameters.AddWithValue("@Order_Code", strOrderCode)
                Dim adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New Data.DataSet(tableName)
                adapter.Fill(ds, tableName)
            End Using
        Catch ex As Exception
            Dim FunctName As String = String.Format("{0}-{1}:", Me.GetType.Name, MethodBase.GetCurrentMethod.Name)
            LOGDelegate.getInstance.dbDebugMsg(FunctName)
            Throw ex
        End Try
        Return ds

    End Function
#End Region

#Region "20160628 PUBOrderBO 取得手術法 by Remote"

    ''' <summary>
    ''' 查詢醫令項目基本檔  Dc = 'N'  
    ''' </summary>
    ''' <param name="inParam"></param>
    ''' <returns>DataSet</returns>
    Public Function PUBOrderOrderName(ByVal inParam() As String) As DataSet
        Dim ds As Data.DataSet
        Dim strSql As New StringBuilder
        ' Select Order_Name From PUB_Order where DC='N' And Order_Code= @ Material_No
        strSql.Append(" Select Order_Code, Order_Name From PUB_Order ")
        strSql.Append("  WHERE  Dc = 'N'   ")
        strSql.Append("  AND Order_Code = '" & inParam(0) & "'")


        Try
            Using sqlConnection As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
                Dim adapter As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqlConnection)
                ds = New Data.DataSet(tableName)
                adapter.Fill(ds, tableName)
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


