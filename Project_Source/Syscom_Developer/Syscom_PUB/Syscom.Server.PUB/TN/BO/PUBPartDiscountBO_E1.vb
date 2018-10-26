Imports System.Data.SqlClient

'
Imports Syscom.Server.BO
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
'
Imports System.Text
Imports Syscom.Server.SQL

Public Class PUBPartDiscountBO_E1
    Inherits PubPartDiscountBO
    Protected tableName1 As String = "PUB_Part_Discount"
    Private Shared instance As PUBPartDiscountBO_E1


    Public Shared Shadows Function getInstance() As PUBPartDiscountBO_E1
        instance = New PUBPartDiscountBO_E1
        Return instance
    End Function

#Region "2010/07/16, Add By 谷官, 復健部分負擔作業(OPCRecoverPartPayUI)"

    ''' <summary>
    ''' 程式說明：取得加收部分負擔金額
    ''' 開發人員：谷官
    ''' 開發日期：2009.09.10
    ''' </summary>
    ''' <returns>加收部分負擔折扣率</returns>
    ''' <使用表單>
    ''' 1.Nick-PUB_Part_Discount
    ''' </使用表單>
    ''' <修改註記>
    ''' 1.2009/07/22, XXX
    ''' </修改註記>
    Public Function getAddPartDiscountRatio(ByVal opdChargeDate As Date, ByVal partCode As String, ByVal disIdentityCode As String) As Decimal
        Dim cmdStr As New StringBuilder

        Try
            cmdStr.AppendLine("select")
            cmdStr.AppendLine("Discount_Ratio")
            cmdStr.AppendLine("from " & Me.tableName1)
            cmdStr.AppendLine("where 1=1")
            cmdStr.AppendLine("and '" & opdChargeDate.ToShortDateString & "' >= Effect_Date and '" & opdChargeDate.ToShortDateString & "' <=End_Date")
            cmdStr.AppendLine("and Part_Code = '" & partCode & "'")
            cmdStr.AppendLine("and Dis_Identity_Code = '" & disIdentityCode & "'")

            '執行SQL
            Dim rtnValue As Object = SQLDataUtil.getInstance.execSQL(cmdStr.ToString, Nothing, "value", Nothing, getConnection)

            If rtnValue IsNot Nothing AndAlso rtnValue IsNot DBNull.Value Then
                Return rtnValue
            Else
                Return CDec(0)
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
End Class
