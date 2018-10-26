'/*
'*****************************************************************************
'*
'*    Page/Class Name:  公式集合
'*              Title:	FormulaUtil
'*        Description:	集合所有常見公式
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Sean.Lin
'*        Create Date:	2013-08-06
'*      Last Modifier:	Sean.Lin
'*   Last Modify Date:	2013-08-06
'*
'*****************************************************************************
'*/

Imports System.Reflection
Imports Syscom.Comm.EXP

Public Class FormulaUtil

    ''' <summary>
    ''' 阻止外部直接進行新建立的宣告
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub New()
    End Sub

    ''' <summary>
    ''' 計算BMI值 -  傳入身高(公分)、體重(公斤)(計算至小數點第一位，餘以四捨五入計)
    ''' </summary>
    ''' <param name="Height" >身高 - 公分</param>
    ''' <param name="Weight" >體重 - 公斤</param>
    ''' <returns>String</returns>
    ''' <remarks>by Sean.Lin on 2013-8-6</remarks>
    Public Shared Function CalculateBMI_CM(ByVal Height As Decimal, ByVal Weight As Decimal) As Decimal
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try
            Return CalculateBMI_M(Height / 100, Weight)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function

    ''' <summary>
    ''' 計算BMI值 -  傳入身高(公尺)、體重(公斤)(計算至小數點第一位，餘以四捨五入計)
    ''' </summary>
    ''' <param name="Height" >身高 - 公尺</param>
    ''' <param name="Weight" >體重 - 公斤</param>
    ''' <returns>String</returns>
    ''' <remarks>by Sean.Lin on 2013-8-6</remarks>
    Public Shared Function CalculateBMI_M(ByVal Height As Decimal, ByVal Weight As Decimal) As Decimal
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try
            If Height > 0 Then
                Dim BMI As Decimal = Weight / (Height * Height)
                Return Format(BMI, "0#.##")
            Else
                Return 0
            End If
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function

    ''' <summary>
    ''' 計算體重值 -  傳入性別、臀圍(公分)、上臂圍(公分) (計算至小數點第一位，餘以四捨五入計)
    ''' </summary>
    ''' <param name="Sex">性別</param>
    ''' <param name="Hips">臀圍 </param>
    ''' <param name="Upperarm">上臂圍</param>
    ''' <returns>Decimal</returns>
    ''' <remarks>by Jimmy.Hsiao on 2016-6-24</remarks>
    Public Shared Function CalculateKG(ByVal Sex As String, ByVal Hips As Decimal, ByVal Upperarm As Decimal) As Decimal
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try
            Dim KG As Decimal = 0
            If Sex = "M" Then
                KG = -72.4104 + 1.1228 * Hips + 1.1268 * Upperarm
                Return Format(KG, "0#.##")
            ElseIf Sex = "F" Then
                KG = -51.3536 + 0.8203 * Hips + 1.0831 * Upperarm
                Return Format(KG, "0#.##")
            Else
                Return 0
            End If

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function

End Class

