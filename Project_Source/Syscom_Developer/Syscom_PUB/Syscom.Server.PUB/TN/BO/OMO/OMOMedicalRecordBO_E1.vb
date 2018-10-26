Imports System.Data.SqlClient
Imports Syscom.Comm.EXP
Imports System.Text
Imports Syscom.Server.SQL
Imports Syscom.Comm.Utility

''' <summary>
''' 程式說明：
''' 開發人員：
''' 開發日期：
''' </summary>
''' <修改註記>
''' </修改註記>
Public Class OMOMedicalRecordBO_E1
    'Inherits OmoMedicalRecordBO

    Private tableName1 = "OMO_Medical_Record"


    Public Shared ReadOnly Property getInstance()
        Get
            Return New OMOMedicalRecordBO_E1
        End Get
    End Property

    '''' <summary>
    '''' Get SQL connection.
    '''' </summary>
    '''' <returns>sql connection</returns>
    '''' <remarks></remarks>
    Private Function getConnection() As SqlConnection

        Return SQLConnFactory.getInstance.getOpdDBSqlConn
    End Function

#Region "2013/07/22 955236 撈出病人之前看診的紀錄並找出有開立藥品且藥品尚未過期的藥"

    ''' <summary>
    ''' 撈出病人之前看診的紀錄並找出有開立藥品且藥品尚未過期的藥
    ''' </summary>
    ''' <param name="Chart_No"></param>
    ''' <param name="Outpatient_Sn"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function PUBRuleEngineAPI_H50_ChkInteraction_qryOMOTypeE(ByVal Chart_No As String, ByVal Outpatient_Sn As String) As DataSet
        Dim ds As DataSet
        Dim cmdStr As String = ""
        Dim sqlCommand As StringBuilder = New StringBuilder()
        Try
            cmdStr &= "SELECT OMR.Main_Identity_Id, OOR.Outpatient_Sn, OOR.Order_Code, OOR.Is_Force, OOR.Order_Effect_Date, " & vbCrLf
            cmdStr &= "OOR.Order_End_Date, OOR.Prescription_Type_Id, OOR.Prescription_Sn, OMR.Opd_Visit_Date, OMR.Dept_Code, " & vbCrLf
            cmdStr &= "OMR.Section_Id,order_sno = convert(nvarchar(10), isnull(null, '')) " & vbCrLf
            cmdStr &= "FROM OMO_Medical_Record OMR WITH (NOLOCK) " & vbCrLf
            cmdStr &= "INNER JOIN OMO_Order_Record OOR WITH (NOLOCK) ON OMR.Outpatient_Sn = OOR.Outpatient_Sn " & vbCrLf
            cmdStr &= "AND OOR.Order_Type_Id = 'E' " & vbCrLf
            cmdStr &= "AND OOR.Cancel = 'N' " & vbCrLf
            cmdStr &= "AND OOR.Dc = 'N' " & vbCrLf
            cmdStr &= "AND OOR.Order_End_Date >= getdate() " & vbCrLf
            cmdStr &= "WHERE OMR.Chart_No = @ChartNo " & vbCrLf
            cmdStr &= "AND OMR.Outpatient_Sn <> @Outpatient_Sn " & vbCrLf
            cmdStr &= "AND OMR.Patient_Status_Id = '3' " & vbCrLf
            cmdStr &= "AND OMR.Cancel = 'N' " & vbCrLf
            Using conn As System.Data.IDbConnection = getConnection()
                Using command As SqlCommand = New SqlCommand
                    command.Parameters.Add(New SqlParameter("@ChartNo", Chart_No))
                    command.Parameters.Add(New SqlParameter("@Outpatient_Sn", Outpatient_Sn))
                    With command
                        .CommandType = CommandType.Text
                        .Connection = CType(conn, SqlConnection)
                        .CommandText = cmdStr
                    End With
                    Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                        ds = New DataSet()
                        adapter.Fill(ds, "PUBRuleEngineAPI_H50_ChkInteraction_qryOMOTypeE")
                    End Using
                End Using
            End Using
            Return ds
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

End Class
