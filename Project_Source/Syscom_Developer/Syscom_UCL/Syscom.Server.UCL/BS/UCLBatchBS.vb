'/*
'*****************************************************************************
'*
'*    Page/Class Name:  Batch作業處理
'*              Title:	UCLBatchBS
'*        Description:	
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Charles
'*        Create Date:	2016-03-11
'*      Last Modifier:	Charles
'*   Last Modify Date:	2016-03-11
'*
'*****************************************************************************
'*/

Imports System.Data.SqlClient
Imports System.Transactions
Imports System.Text

Imports Syscom.Comm.Utility
Imports Syscom.Comm.EXP
Imports Syscom.Server.SQL


Public Class UCLBatchBS

#Region "     使用的Instance宣告 "

    Private Shared myInstance As UCLBatchBS
    Public Shared Function GetInstance() As UCLBatchBS
        If myInstance Is Nothing Then
            myInstance = New UCLBatchBS
        End If
        Return myInstance
    End Function

#End Region

#Region "    2016/03/11 Btach Rerun Charles"

    ''' <summary>
    ''' 執行BatchRerun
    ''' </summary>
    ''' <param name="RerunData"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function RerunTask(ByVal RerunData As DataSet) As DataSet

        'Try



        Return New DataSet
        'Catch sqlex As SqlException
        '    Throw New SQLDatabaseException(sqlex)
        'Catch cmex As CommonException
        '    Throw cmex
        'Catch ex As Exception
        '    Throw New CommonException("CMMCMMD001", ex)
        'End Try
    End Function

    Private Function StartProcess(ByVal vstrExe As String, ByVal vstrParam As String, ByVal vintWaitSec As Integer) As String
        Try
            Dim process1 As System.Diagnostics.Process = New System.Diagnostics.Process()
            process1.StartInfo.UseShellExecute = False
            process1.StartInfo.CreateNoWindow = True
            process1.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden
            process1.StartInfo.RedirectStandardError = True
            process1.StartInfo.RedirectStandardOutput = True
            process1.StartInfo.ErrorDialog = False
            process1.StartInfo.FileName = vstrExe
            process1.StartInfo.Arguments = vstrParam
            'mstrOutput = ""
            'AddHandler process1.OutputDataReceived, AddressOf SortOutputHandler
            process1.Start()
            process1.BeginOutputReadLine()
            Dim sRes As String = process1.StandardError.ReadToEnd
            process1.WaitForExit(1000 * vintWaitSec)

            'process1.Kill()

            'If sRes <> "" Then
            '    Return mstrOutput & "<br><Font color =red>錯誤!!</font>" & sRes
            'Else
            '    Return mstrOutput
            'End If
            Return ""
        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)

        End Try

    End Function

    'Sub SortOutputHandler(ByVal sendingProcess As Object, _
    ' ByVal outLine As System.Diagnostics.DataReceivedEventArgs)
    '    Try
    '        ' Collect the sort command output.
    '        If Not String.IsNullOrEmpty(outLine.Data) Then

    '            ' Add the text to the collected output.
    '            mstrOutput = mstrOutput & outLine.Data
    '        End If
    '    Catch ex As Exception

    '    End Try

    'End Sub

#End Region


End Class
