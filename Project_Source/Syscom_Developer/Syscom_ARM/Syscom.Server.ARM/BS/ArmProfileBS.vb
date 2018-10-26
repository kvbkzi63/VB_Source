Imports Syscom.Server.CMM
Imports Syscom.Comm.EXP

Public Class ArmProfileBS
    '宣告Log
    Dim log As LOGDelegate = LOGDelegate.getInstance
    Public Function insertProfileBS(ByVal ds As DataSet) As String
        Dim pk_System_No As String = ds.Tables(0).Rows(0).Item("System_No").ToString
        Dim pk_Employee_Code As String = ds.Tables(0).Rows(0).Item("Employee_Code").ToString
        Dim pk_Sub_File_Name As String = ds.Tables(0).Rows(0).Item("Sub_File_Name").ToString
        Dim is_Default As String = ds.Tables(0).Rows(0).Item("Is_Default").ToString
        Dim bo As New ArmProfileBO_E1
        Try
            If is_Default = "Y" Then
                bo.updateProfile(pk_System_No, pk_Employee_Code)
            End If
            Dim retDS As DataSet = bo.queryByPK(pk_System_No, pk_Employee_Code, pk_Sub_File_Name)
            If retDS.Tables(0).Rows.Count > 0 Then
                bo.delete(pk_System_No, pk_Employee_Code, pk_Sub_File_Name)
                bo.insert(ds)
                Return ""
            Else
                bo.insert(ds)
                Return "0"
            End If
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function
End Class
