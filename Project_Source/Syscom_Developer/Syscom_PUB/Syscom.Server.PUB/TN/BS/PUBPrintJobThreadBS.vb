Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports Syscom.Server.SQL
Imports Syscom.Server.BO
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
Imports System.Reflection
Imports System.Threading
Imports Syscom.Comm.Utility.StringUtil

Public Class PUBPrintJobThreadBS

    Private Shared _instance As PUBPrintJobThreadBS = Nothing
    Dim CallPubBO As PUBPrintJobBO_E1

    Public Shared Function GetInstance() As PUBPrintJobThreadBS
        If _instance Is Nothing Then
            _instance = New PUBPrintJobThreadBS
        End If
        Return _instance
    End Function

    ''' <summary>
    ''' 列印報表並更新報表狀態(For BS)
    ''' </summary>
    ''' <param name="printJobDS">列印資料集</param>
    ''' <author>Alan</author>
    ''' <date>2010-11-11</date>    
    ''' <remarks></remarks>
    Public Sub CallPUBReportJobProcess(ByVal printJobDS As DataSet)

        CallPubBO = PUBPrintJobBO_E1.getInstance

        If printJobDS IsNot Nothing AndAlso printJobDS.Tables IsNot Nothing AndAlso _
           printJobDS.Tables(0).Rows.Count > 0 Then
            For i = 0 To printJobDS.Tables(0).Rows.Count - 1

                Dim systype As String = ""

                If printJobDS.Tables(0).Columns.Contains("Sys_Type") Then
                    systype = nvl(printJobDS.Tables(0).Rows(i).Item("Sys_Type"))
                End If

                If Not "".Equals(systype) Then
                    doPrint(printJobDS.Tables(0).Rows(i).Item("Job_ID").ToString.Trim, _
                    "batch", systype)
                Else
                    doPrint(printJobDS.Tables(0).Rows(i).Item("Job_ID").ToString.Trim, _
                                "batch")
                End If


            Next

        End If
    End Sub

    ''' <summary>
    ''' 列印報表並更新報表狀態(For Batch)
    ''' </summary>
    ''' <param name="JobID">JobID</param>
    ''' <param name="UserID">使用者ID</param>
    ''' <param name="sysType">系統類別:OPD、PCS</param>
    ''' <author>Charles</author>
    ''' <date>2015-09-02</date>    
    ''' <remarks></remarks>
    Public Sub PUBReportJobProcess(ByVal JobID As String, ByVal UserID As String, Optional ByVal sysType As String = "OPD")

        doPrint(JobID, UserID)

    End Sub

    ''' <summary>
    ''' 執行多執行續列印
    ''' </summary>
    ''' <param name="JobID">JobID</param>
    ''' <param name="UserID">使用者ID</param>
    ''' <param name="sysType">系統類別:OPD、PCS</param>
    ''' <remarks></remarks>
    Public Sub doPrint(ByVal JobID As String, ByVal UserID As String, Optional ByVal sysType As String = "OPD")
        Try

            '將報表狀態更新為P-處理中
            CallPubBO.setReportStatus(JobID, "P", UserID, "")

            '依Job_Id取得相關資料
            Dim returnData As DataSet
            returnData = CallPubBO.queryPUBPrintJob(JobID, UserID)

            If returnData IsNot Nothing AndAlso returnData.Tables IsNot Nothing AndAlso returnData.Tables(0).Rows.Count > 0 Then
                Dim pvtReportID, pvtCondition As String
                Dim Condition(3) As Object

                '取得ReportID與報表參數
                pvtReportID = returnData.Tables(0).Rows(0).Item("Report_ID").ToString.Trim
                pvtCondition = returnData.Tables(0).Rows(0).Item("Condition_Param").ToString.Trim

                Condition(0) = JobID
                Condition(1) = pvtReportID
                Condition(2) = pvtCondition
                Condition(3) = "batch"


                Dim pvtDllPath As String = Replace(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly.GetName.CodeBase.ToString), "file:\", "")

                Select Case sysType

                    Case "OPD"
                        '呼叫報表程式
                        LoadDLL(pvtDllPath & "\OPD.Server." & pvtReportID.Substring(0, 3).ToUpper & ".dll", _
                                "OPD.Server." & pvtReportID.Substring(0, 3).ToUpper & "." & pvtReportID & "Server", _
                                "batchPrint", Condition)
                    Case "PCS"
                        '呼叫報表程式
                        LoadDLL(pvtDllPath & "\PCS.Server." & pvtReportID.Substring(0, 3).ToUpper & ".dll", _
                                "PCS.Server." & pvtReportID.Substring(0, 3).ToUpper & "." & pvtReportID & "Server", _
                                "batchPrint", Condition)
                    Case "PIP"
                        LoadDLL(pvtDllPath & "\" & sysType & ".Server" & ".dll", _
                                 "PIP.Server" & "." & pvtReportID & "Server", _
                                "batchPrint", Condition)
                    Case "HDS"
                        LoadDLL(pvtDllPath & "\OPD.Server.HDS.dll", _
                            "OPD.Server.HDS." & pvtReportID & "Server", _
                              "batchPrint", Condition)
                    Case Else

                        '呼叫報表程式
                        LoadDLL(pvtDllPath & "\" & sysType & ".Server." & pvtReportID.Substring(0, 3).ToUpper & ".dll", _
                                 sysType & ".Server." & pvtReportID.Substring(0, 3).ToUpper & "." & pvtReportID & "Server", _
                                "batchPrint", Condition)

                End Select


            End If

            '將報表狀態更新為成功         
            CallPubBO.setReportStatus(JobID, "S", UserID, "")

        Catch ex As Exception
            '將報表狀態更新為失敗            
            CallPubBO.setReportStatus(JobID, "F", UserID, ex.ToString.Trim)
        End Try
    End Sub

    Sub LoadDLL(ByVal dllName As String, ByVal ProgramName As String, ByVal MethodName As String, ByVal ParmaArray() As Object)
        Dim asm As Reflection.Assembly
        Dim obj As Object

        Try
            asm = Assembly.LoadFrom(dllName)
            obj = asm.CreateInstance(ProgramName)
            obj.GetType().InvokeMember(MethodName, BindingFlags.InvokeMethod, Nothing, obj, ParmaArray)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Function parseXML(ByVal xmlStr As String) As System.Data.DataSet
        Try
            Return XMLUtil.XmlToDataSet(xmlStr)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function GetPUBSqlConnection() As SqlConnection
        Return SQLConnFactory.getInstance.getPubDBSqlConn
    End Function

End Class
