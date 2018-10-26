Imports System.ServiceModel
Imports Syscom.Comm.Utility
Imports Syscom.Client.Servicefactory.SncServiceReference

Partial Public Class SncServiceManager

#Region "20090910 獲取民國年+序列號 add by Yunfei"

    Function getTWYearApiSequentialNo(ByVal strVKey As String) As String Implements ISncServiceManager_T.getTWYearApiSequentialNo
        Dim tempclient As SncServiceClient = Nothing

        Try
            tempclient = getSncService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.getTWYearApiSequentialNo(strVKey)
            End Using ' before close

        Catch ex As Exception
            Throw ex
        Finally
            If tempclient IsNot Nothing Then
                If tempclient.State = ServiceModel.CommunicationState.Opened Then
                    tempclient.Close()
                ElseIf Not (tempclient.State = ServiceModel.CommunicationState.Opened) Then
                    tempclient.Abort()
                End If
            End If
        End Try
    End Function

#End Region

#Region "20100211 add by wangjie"
    ''' <summary>
    ''' 獲取西元年月日+序列號
    ''' </summary>
    ''' <param name="strVKey">vKey值</param>
    ''' <returns>序列號</returns>
    ''' <remarks></remarks>
    Function getCmmSerialNoTx(ByVal vType As String, ByVal strVKey As String, ByVal vMinNo As String, ByVal vMaxNo As String) As String Implements ISncServiceManager.getCmmSerialNoTx
        Dim tempclient As SncServiceClient = Nothing
        Dim strReturn As String = ""

        Try
            tempclient = getSncService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.getCmmSerialNoTx(vType, strVKey, vMinNo, vMaxNo)
            End Using ' before close

        Catch ex As Exception
            Throw ex
        Finally
            If tempclient IsNot Nothing Then
                If tempclient.State = ServiceModel.CommunicationState.Opened Then
                    tempclient.Close()
                ElseIf Not (tempclient.State = ServiceModel.CommunicationState.Opened) Then
                    tempclient.Abort()
                End If
            End If
        End Try

    End Function
#End Region

End Class
