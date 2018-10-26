Imports System.ServiceModel
Imports Syscom.Comm.Utility
Imports Syscom.Client.Servicefactory.IccServiceReference
Imports Syscom.Client.Servicefactory.IccService2Reference

Partial Class IccServiceManager

    ''' <summary>
    ''' 查詢 雲端藥歷/關懷用藥 連線記錄
    ''' </summary>
    ''' <param name="Param"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function QueryIccConnectionHistory(Param As Dictionary(Of String, Object)) As DataSet Implements IIccServiceManager_T.QueryIccConnectionHistory
        Dim tempclient As IccService2Client = Nothing

        Try
            tempclient = getIccService2()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.QueryIccConnectionHistory(Param)
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

#Region "上傳資料維護"

    ''' <summary>
    ''' 取得初始化 ICCUploadDataQueryUI 所需資料
    ''' </summary>
    ''' <param name="Param"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function InitialIccUploadDataQueryUI(Param As Dictionary(Of String, Object)) As DataSet Implements IIccServiceManager_T.InitialIccUploadDataQueryUI
        Dim tempclient As IccService2Client = Nothing

        Try
            tempclient = getIccService2()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.InitialIccUploadDataQueryUI(Param)
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

    ''' <summary>
    ''' 查詢上傳檔
    ''' </summary>
    ''' <param name="Param"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function QueryIccUploadData(Param As Dictionary(Of String, Object)) As DataSet Implements IIccServiceManager_T.QueryIccUploadData
        Dim tempclient As IccService2Client = Nothing

        Try
            tempclient = getIccService2()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.QueryIccUploadData(Param)
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

    ''' <summary>
    ''' 查詢上傳檔明細
    ''' </summary>
    ''' <param name="Param"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function QueryIccUploadDataDetail(Param As Dictionary(Of String, Object)) As DataSet Implements IIccServiceManager_T.QueryIccUploadDataDetail
        Dim tempclient As IccService2Client = Nothing

        Try
            tempclient = getIccService2()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.QueryIccUploadDataDetail(Param)
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

    ''' <summary>
    ''' 存檔
    ''' </summary>
    ''' <param name="Param"></param>
    ''' <param name="InputDs"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SaveIccUploadData(Param As Dictionary(Of String, Object), InputDs As DataSet) As DataSet Implements IIccServiceManager_T.SaveIccUploadData
        Dim tempclient As IccService2Client = Nothing

        Try
            tempclient = getIccService2()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.SaveIccUploadData(Param, InputDs)
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

#Region "回饋資料匯入查詢"

    ''' <summary>
    ''' 將回饋檔存入資料庫
    ''' </summary>
    ''' <param name="Param"></param>
    ''' <param name="InputDs"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ImportFeedbackData(Param As Dictionary(Of String, Object), InputDs As DataSet) As Int32 Implements IIccServiceManager_T.ImportFeedbackData
        Dim tempclient As IccService2Client = Nothing

        Try
            tempclient = getIccService2()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.ImportFeedbackData(Param, InputDs)
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

    ''' <summary>
    ''' 查詢當日已匯入次數
    ''' </summary>
    ''' <param name="Import_Date">匯入日期</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function QueryMaxCountOfDay(Import_Date As Date) As Int32 Implements IIccServiceManager_T.QueryMaxCountOfDay
        Dim tempclient As IccService2Client = Nothing

        Try
            tempclient = getIccService2()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.QueryMaxCountOfDay(Import_Date)
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

    ''' <summary>
    ''' 查詢回饋檔資料
    ''' </summary>
    ''' <param name="Param"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function QueryFeedBackData(Param As Dictionary(Of String, Object)) As DataSet Implements IIccServiceManager_T.QueryFeedBackData
        Dim tempclient As IccService2Client = Nothing

        Try
            tempclient = getIccService2()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.QueryFeedBackData(Param)
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

#Region "回饋資料(用藥重複)匯入查詢"

    ''' <summary>
    ''' 將回饋檔(用藥重複)存入資料庫
    ''' </summary>
    ''' <param name="Param"></param>
    ''' <param name="InputDs"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ImportFeedbackDuporderData(Param As Dictionary(Of String, Object), InputDs As DataSet) As Int32 Implements IIccServiceManager_T.ImportFeedbackDuporderData
        Dim tempclient As IccService2Client = Nothing

        Try
            tempclient = getIccService2()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.ImportFeedbackDuporderData(Param, InputDs)
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

    ''' <summary>
    ''' 查詢回饋檔(用藥重複)資料
    ''' </summary>
    ''' <param name="Param"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function QueryFeedBackDuporderData(Param As Dictionary(Of String, Object)) As DataSet Implements IIccServiceManager_T.QueryFeedBackDuporderData
        Dim tempclient As IccService2Client = Nothing

        Try
            tempclient = getIccService2()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.QueryFeedBackDuporderData(Param)
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

#Region "24小時上傳比率"

    ''' <summary>
    ''' 查詢24小時上傳比率
    ''' </summary>
    ''' <param name="Param"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Query24HourUploadedRate(Param As Dictionary(Of String, Object)) As DataSet Implements IIccServiceManager_T.Query24HourUploadedRate
        Dim tempclient As IccService2Client = Nothing

        Try
            tempclient = getIccService2()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.Query24HourUploadedRate(Param)
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

    ''' <summary>
    ''' 取得24小時未上傳資料
    ''' </summary>
    ''' <param name="Param"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Query24UnuploadData(Param As Dictionary(Of String, Object)) As DataSet Implements IIccServiceManager_T.Query24UnuploadData
        Dim tempclient As IccService2Client = Nothing

        Try
            tempclient = getIccService2()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.Query24UnuploadData(Param)
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

#Region "20090929 add by Rich, ICCCardBS"

    Public Function deleteGetTreatmentNeedHPC(ByVal Card_Sn As String) As Integer Implements IIccServiceManager.deleteGetTreatmentNeedHPC
        Dim instance As IccServiceClient = Nothing
        Try
            instance = getIccService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.deleteGetTreatmentNeedHPC(Card_Sn)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function deleteGetTreatmentNoNeedHPC(ByVal Card_Sn As String) As Integer Implements IIccServiceManager.deleteGetTreatmentNoNeedHPC
        Dim instance As IccServiceClient = Nothing
        Try
            instance = getIccService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.deleteGetTreatmentNoNeedHPC(Card_Sn)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function deleteUnGetSeqNumber(ByVal pk_Card_Sn As String) As Integer Implements IIccServiceManager.deleteUnGetSeqNumber
        Dim instance As IccServiceClient = Nothing
        Try
            instance = getIccService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.deleteUnGetSeqNumber(pk_Card_Sn)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function deleteUpdateICCard(ByVal pk_Card_Sn As String) As Integer Implements IIccServiceManager.deleteUpdateICCard
        Dim instance As IccServiceClient = Nothing
        Try
            instance = getIccService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.deleteUpdateICCard(pk_Card_Sn)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function deleteWriteNewBorn(ByVal pk_Card_Sn As String) As Integer Implements IIccServiceManager.deleteWriteNewBorn
        Dim instance As IccServiceClient = Nothing
        Try
            instance = getIccService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.deleteWriteNewBorn(pk_Card_Sn)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function insertGetCriticalIllness(ByVal Card_Sn As String, ByVal retRetain As String, ByVal rethospitalMark As String, ByVal retValueList As System.Data.DataSet) As Integer Implements IIccServiceManager.insertGetCriticalIllness
        Dim instance As IccServiceClient = Nothing
        Try
            instance = getIccService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.insertGetCriticalIllness(Card_Sn, retRetain, rethospitalMark, retValueList)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function insertGetInoculateData(ByVal Card_Sn As String, ByVal retValueList As System.Data.DataSet) As Integer Implements IIccServiceManager.insertGetInoculateData
        Dim instance As IccServiceClient = Nothing
        Try
            instance = getIccService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.insertGetInoculateData(Card_Sn, retValueList)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function insertGetLastSeqNum(ByVal Card_Sn As String, ByVal retLastSeqNum As String) As Integer Implements IIccServiceManager.insertGetLastSeqNum
        Dim instance As IccServiceClient = Nothing
        Try
            instance = getIccService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.insertGetLastSeqNum(Card_Sn, retLastSeqNum)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function insertGetRegisterBasic(ByVal retValue As System.Data.DataSet) As Integer Implements IIccServiceManager.insertGetRegisterBasic
        Dim instance As IccServiceClient = Nothing
        Try
            instance = getIccService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.insertGetRegisterBasic(retValue)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function insertGetRegisterPregnant(ByVal Card_Sn As String, ByVal retValueList As System.Data.DataSet) As Integer Implements IIccServiceManager.insertGetRegisterPregnant
        Dim instance As IccServiceClient = Nothing
        Try
            instance = getIccService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.insertGetRegisterPregnant(Card_Sn, retValueList)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function insertGetRegisterPrevent(ByVal Card_Sn As String, ByVal retValueList As System.Data.DataSet) As Integer Implements IIccServiceManager.insertGetRegisterPrevent
        Dim instance As IccServiceClient = Nothing
        Try
            instance = getIccService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.insertGetRegisterPrevent(Card_Sn, retValueList)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function insertGetTreatmentNeedHPC(ByVal Card_Sn As String, ByVal retTreatmentValueList As System.Data.DataSet, ByVal retIllnessValueList As System.Data.DataSet) As Integer Implements IIccServiceManager.insertGetTreatmentNeedHPC
        Dim instance As IccServiceClient = Nothing
        Try
            instance = getIccService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.insertGetTreatmentNeedHPC(Card_Sn, retTreatmentValueList, retIllnessValueList)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function insertGetTreatmentNoNeedHPC(ByVal Card_Sn As String, ByVal retTreatmentValueList As System.Data.DataSet, ByVal retIllnessValueList As System.Data.DataSet) As Integer Implements IIccServiceManager.insertGetTreatmentNoNeedHPC
        Dim instance As IccServiceClient = Nothing
        Try
            instance = getIccService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.insertGetTreatmentNoNeedHPC(Card_Sn, retTreatmentValueList, retIllnessValueList)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function insertReadPrescriptAllergic(ByVal Card_Sn As String, ByVal retValueList As System.Data.DataSet) As Integer Implements IIccServiceManager.insertReadPrescriptAllergic
        Dim instance As IccServiceClient = Nothing
        Try
            instance = getIccService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.insertReadPrescriptAllergic(Card_Sn, retValueList)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function insertReadPrescriptHVE(ByVal Card_Sn As String, ByVal retValueList As System.Data.DataSet) As Integer Implements IIccServiceManager.insertReadPrescriptHVE
        Dim instance As IccServiceClient = Nothing
        Try
            instance = getIccService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.insertReadPrescriptHVE(Card_Sn, retValueList)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function insertReadPrescriptLongTerm(ByVal Card_Sn As String, ByVal retValueList As System.Data.DataSet) As Integer Implements IIccServiceManager.insertReadPrescriptLongTerm
        Dim instance As IccServiceClient = Nothing
        Try
            instance = getIccService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.insertReadPrescriptLongTerm(Card_Sn, retValueList)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function insertReadPrescriptMain(ByVal Card_Sn As String, ByVal retValueList As System.Data.DataSet) As Integer Implements IIccServiceManager.insertReadPrescriptMain
        Dim instance As IccServiceClient = Nothing
        Try
            instance = getIccService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.insertReadPrescriptMain(Card_Sn, retValueList)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function queryGetCriticalIllness(ByVal Card_Sn As String) As System.Data.DataSet Implements IIccServiceManager.queryGetCriticalIllness
        Dim instance As IccServiceClient = Nothing
        Try
            instance = getIccService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryGetCriticalIllness(Card_Sn)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function queryGetInoculateData(ByVal Card_Sn As String) As System.Data.DataSet Implements IIccServiceManager.queryGetInoculateData
        Dim instance As IccServiceClient = Nothing
        Try
            instance = getIccService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryGetInoculateData(Card_Sn)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function queryGetLastSeqNum(ByVal Card_Sn As String) As System.Data.DataSet Implements IIccServiceManager.queryGetLastSeqNum
        Dim instance As IccServiceClient = Nothing
        Try
            instance = getIccService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryGetLastSeqNum(Card_Sn)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function queryGetRegisterBasic(ByVal Card_Sn As String) As System.Data.DataSet Implements IIccServiceManager.queryGetRegisterBasic
        Dim instance As IccServiceClient = Nothing
        Try
            instance = getIccService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryGetRegisterBasic(Card_Sn)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function queryGetRegisterPregnant(ByVal Card_Sn As String) As System.Data.DataSet Implements IIccServiceManager.queryGetRegisterPregnant
        Dim instance As IccServiceClient = Nothing
        Try
            instance = getIccService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryGetRegisterPregnant(Card_Sn)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function queryGetRegisterPrevent(ByVal Card_Sn As String) As System.Data.DataSet Implements IIccServiceManager.queryGetRegisterPrevent
        Dim instance As IccServiceClient = Nothing
        Try
            instance = getIccService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryGetRegisterPrevent(Card_Sn)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function queryGetTreatmentNeedHPC(ByVal Card_Sn As String) As System.Data.DataSet Implements IIccServiceManager.queryGetTreatmentNeedHPC
        Dim instance As IccServiceClient = Nothing
        Try
            instance = getIccService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryGetTreatmentNeedHPC(Card_Sn)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function queryGetTreatmentNoNeedHPC(ByVal Card_Sn As String) As System.Data.DataSet Implements IIccServiceManager.queryGetTreatmentNoNeedHPC
        Dim instance As IccServiceClient = Nothing
        Try
            instance = getIccService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryGetTreatmentNoNeedHPC(Card_Sn)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function queryReadPrescriptAllergic(ByVal Card_Sn As String) As System.Data.DataSet Implements IIccServiceManager.queryReadPrescriptAllergic
        Dim instance As IccServiceClient = Nothing
        Try
            instance = getIccService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryReadPrescriptAllergic(Card_Sn)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function queryReadPrescriptHVE(ByVal Card_Sn As String) As System.Data.DataSet Implements IIccServiceManager.queryReadPrescriptHVE
        Dim instance As IccServiceClient = Nothing
        Try
            instance = getIccService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryReadPrescriptHVE(Card_Sn)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function queryReadPrescriptLongTerm(ByVal Card_Sn As String) As System.Data.DataSet Implements IIccServiceManager.queryReadPrescriptLongTerm
        Dim instance As IccServiceClient = Nothing
        Try
            instance = getIccService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryReadPrescriptLongTerm(Card_Sn)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function queryReadPrescriptMain(ByVal Card_Sn As String) As System.Data.DataSet Implements IIccServiceManager.queryReadPrescriptMain
        Dim instance As IccServiceClient = Nothing
        Try
            instance = getIccService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryReadPrescriptMain(Card_Sn)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function updateGetCriticalIllness(ByVal Card_Sn As String, ByVal retRetain As String, ByVal rethospitalMark As String, ByVal retValueList As System.Data.DataSet) As Integer Implements IIccServiceManager.updateGetCriticalIllness
        Dim instance As IccServiceClient = Nothing
        Try
            instance = getIccService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.updateGetCriticalIllness(Card_Sn, retRetain, rethospitalMark, retValueList)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function updateGetInoculateData(ByVal Card_Sn As String, ByVal retValueList As System.Data.DataSet) As Integer Implements IIccServiceManager.updateGetInoculateData
        Dim instance As IccServiceClient = Nothing
        Try
            instance = getIccService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.updateGetInoculateData(Card_Sn, retValueList)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function updateGetLastSeqNum(ByVal Card_Sn As String, ByVal retLastSeqNum As String) As Integer Implements IIccServiceManager.updateGetLastSeqNum
        Dim instance As IccServiceClient = Nothing
        Try
            instance = getIccService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.updateGetLastSeqNum(Card_Sn, retLastSeqNum)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function updateGetRegisterBasic(ByVal retValue As System.Data.DataSet) As Integer Implements IIccServiceManager.updateGetRegisterBasic
        Dim instance As IccServiceClient = Nothing
        Try
            instance = getIccService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.updateGetRegisterBasic(retValue)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function updateGetRegisterPregnant(ByVal Card_Sn As String, ByVal retValueList As System.Data.DataSet) As Integer Implements IIccServiceManager.updateGetRegisterPregnant
        Dim instance As IccServiceClient = Nothing
        Try
            instance = getIccService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.updateGetRegisterPregnant(Card_Sn, retValueList)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function updateGetRegisterPrevent(ByVal Card_Sn As String, ByVal retValueList As System.Data.DataSet) As Integer Implements IIccServiceManager.updateGetRegisterPrevent
        Dim instance As IccServiceClient = Nothing
        Try
            instance = getIccService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.updateGetRegisterPrevent(Card_Sn, retValueList)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function updateGetTreatmentNeedHPC(ByVal Card_Sn As String, ByVal retTreatmentValueList As System.Data.DataSet, ByVal retIllnessValueList As System.Data.DataSet) As Integer Implements IIccServiceManager.updateGetTreatmentNeedHPC
        Dim instance As IccServiceClient = Nothing
        Try
            instance = getIccService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.updateGetTreatmentNeedHPC(Card_Sn, retTreatmentValueList, retIllnessValueList)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function updateGetTreatmentNoNeedHPC(ByVal Card_Sn As String, ByVal retTreatmentValueList As System.Data.DataSet, ByVal retIllnessValueList As System.Data.DataSet) As Integer Implements IIccServiceManager.updateGetTreatmentNoNeedHPC
        Dim instance As IccServiceClient = Nothing
        Try
            instance = getIccService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.updateGetTreatmentNoNeedHPC(Card_Sn, retTreatmentValueList, retIllnessValueList)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function updateReadPrescriptAllergic(ByVal Card_Sn As String, ByVal retValueList As System.Data.DataSet) As Integer Implements IIccServiceManager.updateReadPrescriptAllergic
        Dim instance As IccServiceClient = Nothing
        Try
            instance = getIccService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.updateReadPrescriptAllergic(Card_Sn, retValueList)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function updateReadPrescriptHVE(ByVal Card_Sn As String, ByVal retValueList As System.Data.DataSet) As Integer Implements IIccServiceManager.updateReadPrescriptHVE
        Dim instance As IccServiceClient = Nothing
        Try
            instance = getIccService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.updateReadPrescriptHVE(Card_Sn, retValueList)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function updateReadPrescriptLongTerm(ByVal Card_Sn As String, ByVal retValueList As System.Data.DataSet) As Integer Implements IIccServiceManager.updateReadPrescriptLongTerm
        Dim instance As IccServiceClient = Nothing
        Try
            instance = getIccService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.updateReadPrescriptLongTerm(Card_Sn, retValueList)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function updateReadPrescriptMain(ByVal Card_Sn As String, ByVal retValueList As System.Data.DataSet) As Integer Implements IIccServiceManager.updateReadPrescriptMain
        Dim instance As IccServiceClient = Nothing
        Try
            instance = getIccService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.updateReadPrescriptMain(Card_Sn, retValueList)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function deleteGetBasicData(ByVal Card_Sn As String) As Integer Implements IIccServiceManager.deleteGetBasicData
        Dim instance As IccService2Client = Nothing
        Try
            instance = getIccService2()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.deleteGetBasicData(Card_Sn)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function deleteReadPrescription(ByVal Card_Sn As String) As Integer Implements IIccServiceManager.deleteReadPrescription
        Dim instance As IccService2Client = Nothing
        Try
            instance = getIccService2()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.deleteReadPrescription(Card_Sn)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function deleteWriteAllergicMedicines(ByVal pk_Card_Sn As String) As Integer Implements IIccServiceManager.deleteWriteAllergicMedicines
        Dim instance As IccService2Client = Nothing
        Try
            instance = getIccService2()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.deleteWriteAllergicMedicines(pk_Card_Sn)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function deleteWriteEmergentTel(ByVal pk_Card_Sn As String) As Integer Implements IIccServiceManager.deleteWriteEmergentTel
        Dim instance As IccService2Client = Nothing
        Try
            instance = getIccService2()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.deleteWriteEmergentTel(pk_Card_Sn)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function deleteWriteHealthInsurance(ByVal pk_Card_Sn As String) As Integer Implements IIccServiceManager.deleteWriteHealthInsurance
        Dim instance As IccService2Client = Nothing
        Try
            instance = getIccService2()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.deleteWriteHealthInsurance(pk_Card_Sn)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function deleteWriteInoculateData(ByVal pk_Card_Sn As String) As Integer Implements IIccServiceManager.deleteWriteInoculateData
        Dim instance As IccService2Client = Nothing
        Try
            instance = getIccService2()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.deleteWriteInoculateData(pk_Card_Sn)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function deleteWriteMultiPrescript(ByVal pk_Card_Sn As String) As Integer Implements IIccServiceManager.deleteWriteMultiPrescript
        Dim instance As IccService2Client = Nothing
        Try
            instance = getIccService2()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.deleteWriteMultiPrescript(pk_Card_Sn)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function deleteWritePredeliveryCheckup(ByVal pk_Card_Sn As String) As Integer Implements IIccServiceManager.deleteWritePredeliveryCheckup
        Dim instance As IccService2Client = Nothing
        Try
            instance = getIccService2()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.deleteWritePredeliveryCheckup(pk_Card_Sn)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function deleteWritePrescription(ByVal pk_Card_Sn As String) As Integer Implements IIccServiceManager.deleteWritePrescription
        Dim instance As IccService2Client = Nothing
        Try
            instance = getIccService2()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.deleteWritePrescription(pk_Card_Sn)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function deleteWriteTreatmentCode(ByVal pk_Card_Sn As String) As Integer Implements IIccServiceManager.deleteWriteTreatmentCode
        Dim instance As IccService2Client = Nothing
        Try
            instance = getIccService2()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.deleteWriteTreatmentCode(pk_Card_Sn)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function deleteWriteTreatmentData(ByVal pk_Card_Sn As String) As Integer Implements IIccServiceManager.deleteWriteTreatmentData
        Dim instance As IccService2Client = Nothing
        Try
            instance = getIccService2()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.deleteWriteTreatmentData(pk_Card_Sn)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function deleteWriteTreatmentFee(ByVal pk_Card_Sn As String) As Integer Implements IIccServiceManager.deleteWriteTreatmentFee
        Dim instance As IccService2Client = Nothing
        Try
            instance = getIccService2()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.deleteWriteTreatmentFee(pk_Card_Sn)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function insertGetBasicData(ByVal Card_Sn As String, ByVal retValue As System.Data.DataSet) As Integer Implements IIccServiceManager.insertGetBasicData
        Dim instance As IccService2Client = Nothing
        Try
            instance = getIccService2()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.insertGetBasicData(Card_Sn, retValue)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function insertGetBasicData2(ByVal Card_Sn As String, ByVal retValue As System.Data.DataSet) As Integer Implements IIccServiceManager.insertGetBasicData2
        Dim instance As IccService2Client = Nothing
        Try
            instance = getIccService2()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.insertGetBasicData2(Card_Sn, retValue)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function insertGetCumulativeData(ByVal Card_Sn As String, ByVal retValueList As System.Data.DataSet) As Integer Implements IIccServiceManager.insertGetCumulativeData
        Dim instance As IccService2Client = Nothing
        Try
            instance = getIccService2()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.insertGetCumulativeData(Card_Sn, retValueList)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function insertGetCumulativeFee(ByVal Card_Sn As String, ByVal retOutpatientFeeToatl As String, ByVal retHospitalFeeToatl As String) As Integer Implements IIccServiceManager.insertGetCumulativeFee
        Dim instance As IccService2Client = Nothing
        Try
            instance = getIccService2()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.insertGetCumulativeFee(Card_Sn, retOutpatientFeeToatl, retHospitalFeeToatl)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function insertGetEmergentTel(ByVal Card_Sn As String, ByVal retEmergentTel As String) As Integer Implements IIccServiceManager.insertGetEmergentTel
        Dim instance As IccService2Client = Nothing
        Try
            instance = getIccService2()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.insertGetEmergentTel(Card_Sn, retEmergentTel)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function insertGetOrganDonate(ByVal Card_Sn As String, ByVal retOrganDonateMark As String) As Integer Implements IIccServiceManager.insertGetOrganDonate
        Dim instance As IccService2Client = Nothing
        Try
            instance = getIccService2()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.insertGetOrganDonate(Card_Sn, retOrganDonateMark)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function insertGetRegisterBasic2(ByVal Card_Sn As String, ByVal retValue As System.Data.DataSet) As Integer Implements IIccServiceManager.insertGetRegisterBasic2
        Dim instance As IccService2Client = Nothing
        Try
            instance = getIccService2()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.insertGetRegisterBasic2(Card_Sn, retValue)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function insertReadPrescription(ByVal Card_Sn As String, ByVal retMainValueList As System.Data.DataSet, ByVal retLongTermValueList As System.Data.DataSet, ByVal retHVEValueList As System.Data.DataSet, ByVal retAllergicValueList As System.Data.DataSet) As Integer Implements IIccServiceManager.insertReadPrescription
        Dim instance As IccService2Client = Nothing
        Try
            instance = getIccService2()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.insertReadPrescription(Card_Sn, retMainValueList, retLongTermValueList, retHVEValueList, retAllergicValueList)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function queryGetBasicData(ByVal Card_Sn As String) As System.Data.DataSet Implements IIccServiceManager.queryGetBasicData
        Dim instance As IccService2Client = Nothing
        Try
            instance = getIccService2()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryGetBasicData(Card_Sn)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function queryGetCumulativeData(ByVal Card_Sn As String) As System.Data.DataSet Implements IIccServiceManager.queryGetCumulativeData
        Dim instance As IccService2Client = Nothing
        Try
            instance = getIccService2()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryGetCumulativeData(Card_Sn)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function queryGetCumulativeFee(ByVal Card_Sn As String) As System.Data.DataSet Implements IIccServiceManager.queryGetCumulativeFee
        Dim instance As IccService2Client = Nothing
        Try
            instance = getIccService2()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryGetCumulativeFee(Card_Sn)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function queryGetEmergentTel(ByVal Card_Sn As String) As System.Data.DataSet Implements IIccServiceManager.queryGetEmergentTel
        Dim instance As IccService2Client = Nothing
        Try
            instance = getIccService2()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryGetEmergentTel(Card_Sn)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function queryGetOrganDonate(ByVal Card_Sn As String) As System.Data.DataSet Implements IIccServiceManager.queryGetOrganDonate
        Dim instance As IccService2Client = Nothing
        Try
            instance = getIccService2()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryGetOrganDonate(Card_Sn)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function queryGetRegisterBasic2(ByVal Card_Sn As String) As System.Data.DataSet Implements IIccServiceManager.queryGetRegisterBasic2
        Dim instance As IccService2Client = Nothing
        Try
            instance = getIccService2()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryGetRegisterBasic2(Card_Sn)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function queryReadPrescription(ByVal Card_Sn As String) As System.Data.DataSet Implements IIccServiceManager.queryReadPrescription
        Dim instance As IccService2Client = Nothing
        Try
            instance = getIccService2()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryReadPrescription(Card_Sn)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function updateGetBasicData(ByVal Card_Sn As String, ByVal retValue As System.Data.DataSet) As Integer Implements IIccServiceManager.updateGetBasicData
        Dim instance As IccService2Client = Nothing
        Try
            instance = getIccService2()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.updateGetBasicData(Card_Sn, retValue)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function updateGetBasicData2(ByVal Card_Sn As String, ByVal retValue As System.Data.DataSet) As Integer Implements IIccServiceManager.updateGetBasicData2
        Dim instance As IccService2Client = Nothing
        Try
            instance = getIccService2()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.updateGetBasicData2(Card_Sn, retValue)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function updateGetCumulativeData(ByVal Card_Sn As String, ByVal retValueList As System.Data.DataSet) As Integer Implements IIccServiceManager.updateGetCumulativeData
        Dim instance As IccService2Client = Nothing
        Try
            instance = getIccService2()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.updateGetCumulativeData(Card_Sn, retValueList)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function updateGetCumulativeFee(ByVal Card_Sn As String, ByVal retOutpatientFeeToatl As String, ByVal retHospitalFeeToatl As String) As Integer Implements IIccServiceManager.updateGetCumulativeFee
        Dim instance As IccService2Client = Nothing
        Try
            instance = getIccService2()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.updateGetCumulativeFee(Card_Sn, retOutpatientFeeToatl, retHospitalFeeToatl)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function updateGetEmergentTel(ByVal Card_Sn As String, ByVal retEmergentTel As String) As Integer Implements IIccServiceManager.updateGetEmergentTel
        Dim instance As IccService2Client = Nothing
        Try
            instance = getIccService2()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.updateGetEmergentTel(Card_Sn, retEmergentTel)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function updateGetOrganDonate(ByVal Card_Sn As String, ByVal retOrganDonateMark As String) As Integer Implements IIccServiceManager.updateGetOrganDonate
        Dim instance As IccService2Client = Nothing
        Try
            instance = getIccService2()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.updateGetOrganDonate(Card_Sn, retOrganDonateMark)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function updateGetRegisterBasic2(ByVal Card_Sn As String, ByVal retValue As System.Data.DataSet) As Integer Implements IIccServiceManager.updateGetRegisterBasic2
        Dim instance As IccService2Client = Nothing
        Try
            instance = getIccService2()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.updateGetRegisterBasic2(Card_Sn, retValue)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function updateReadPrescription(ByVal Card_Sn As String, ByVal retMainValueList As System.Data.DataSet, ByVal retLongTermValueList As System.Data.DataSet, ByVal retHVEValueList As System.Data.DataSet, ByVal retAllergicValueList As System.Data.DataSet) As Integer Implements IIccServiceManager.updateReadPrescription
        Dim instance As IccService2Client = Nothing
        Try
            instance = getIccService2()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.updateReadPrescription(Card_Sn, retMainValueList, retLongTermValueList, retHVEValueList, retAllergicValueList)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function deleteWriteOrganDonate(ByVal pk_Card_Sn As String) As Integer Implements IIccServiceManager.deleteWriteOrganDonate
        Dim instance As IccService2Client = Nothing
        Try
            instance = getIccService2()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.deleteWriteOrganDonate(pk_Card_Sn)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

#End Region

#Region "20090929 add by Rich, ICCUploadBS"

    Public Function insertInsertHealth(ByVal seqNumber As String, ByVal uploadType As String, ByVal sourceType1 As String, ByVal srcSeq As String, ByVal medicalRecNo As String, ByVal mb1Value As System.Data.DataSet, ByVal mb2ValueList As System.Data.DataSet, ByVal createUser As String, ByVal createTime As Date, ByVal errorCodeMessage As String) As Integer Implements IIccServiceManager.insertInsertHealth
        Dim instance As IccServiceClient = Nothing
        Try
            instance = getIccService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.insertInsertHealth(seqNumber, uploadType, sourceType1, srcSeq, medicalRecNo, mb1Value, mb2ValueList, createUser, createTime, errorCodeMessage)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function insertInsertInoculate(ByVal seqNumber As String, ByVal uploadType As String, ByVal sourceType1 As String, ByVal srcSeq As String, ByVal medicalRecNo As String, ByVal fBabyStool As Boolean, ByVal mb1Value As System.Data.DataSet, ByVal mb2ValueList As System.Data.DataSet, ByVal createUser As String, ByVal createTime As Date, ByVal treatmentTime As Date) As Integer Implements IIccServiceManager.insertInsertInoculate
        Dim instance As IccServiceClient = Nothing
        Try
            instance = getIccService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.insertInsertInoculate(seqNumber, uploadType, sourceType1, srcSeq, medicalRecNo, fBabyStool, mb1Value, mb2ValueList, createUser, createTime, treatmentTime)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function queryField_Length_Verify(ByVal totalID As String) As System.Data.DataSet Implements IIccServiceManager.queryField_Length_Verify
        Dim instance As IccServiceClient = Nothing
        Try
            instance = getIccService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryField_Length_Verify(totalID)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function queryGetMustUploadField(ByVal treatmentCategoryId As String, ByVal dataType As String) As System.Data.DataSet Implements IIccServiceManager.queryGetMustUploadField
        Dim instance As IccServiceClient = Nothing
        Try
            instance = getIccService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryGetMustUploadField(treatmentCategoryId, dataType)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function queryInteract_Verify1() As System.Data.DataSet Implements IIccServiceManager.queryInteract_Verify1
        Dim instance As IccServiceClient = Nothing
        Try
            instance = getIccService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryInteract_Verify1
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function queryInteract_Verify2() As System.Data.DataSet Implements IIccServiceManager.queryInteract_Verify2
        Dim instance As IccServiceClient = Nothing
        Try
            instance = getIccService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryInteract_Verify2
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function queryInteract_Verify3() As System.Data.DataSet Implements IIccServiceManager.queryInteract_Verify3
        Dim instance As IccServiceClient = Nothing
        Try
            instance = getIccService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryInteract_Verify3
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function queryInteract_Verify4() As System.Data.DataSet Implements IIccServiceManager.queryInteract_Verify4
        Dim instance As IccServiceClient = Nothing
        Try
            instance = getIccService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryInteract_Verify4
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function queryMust_Field_Verify(ByVal mb1ValueA01 As String, ByVal mb1ValueA23 As String) As System.Data.DataSet Implements IIccServiceManager.queryMust_Field_Verify
        Dim instance As IccServiceClient = Nothing
        Try
            instance = getIccService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryMust_Field_Verify(mb1ValueA01, mb1ValueA23)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function querySelf_Verify(ByVal totalID As String) As System.Data.DataSet Implements IIccServiceManager.querySelf_Verify
        Dim instance As IccServiceClient = Nothing
        Try
            instance = getIccService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.querySelf_Verify(totalID)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function queryUpload(ByVal healthSnListStr As String, ByVal inoculationSnListStr As String, ByVal uploadTypeId As String, ByVal fBatch As Boolean, ByVal user As String, ByVal Config_Name_Path As String, ByVal Config_Name_Mail As String) As System.Data.DataSet Implements IIccServiceManager.queryUpload
        Dim instance As IccServiceClient = Nothing
        Try
            instance = getIccService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryUpload(healthSnListStr, inoculationSnListStr, uploadTypeId, fBatch, user, Config_Name_Path, Config_Name_Mail)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function updateUpload(ByVal ds As System.Data.DataSet, ByVal user As String) As Integer Implements IIccServiceManager.updateUpload
        Dim instance As IccServiceClient = Nothing
        Try
            instance = getIccService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.updateUpload(ds, user)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function updateUpload2(ByVal ds As System.Data.DataSet, ByVal UPLOAD_DATE As String, ByVal user As String) As Integer Implements IIccServiceManager.updateUpload2
        Dim instance As IccServiceClient = Nothing
        Try
            instance = getIccService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.updateUpload2(ds, UPLOAD_DATE, user)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function queryOnlineCheck(ByVal ID As String) As System.Data.DataSet Implements IIccServiceManager.queryOnlineCheck
        Dim instance As IccServiceClient = Nothing
        Try
            instance = getIccService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryOnlineCheck(ID)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

#End Region

#Region "更新處方簽章"

    Public Function UpdateICCOrderUploadForPrescriptionSignA79(ByVal ds As DataSet) As String Implements IIccServiceManager.UpdateICCOrderUploadForPrescriptionSignA79
        Dim instance As IccService2Client = Nothing
        Try
            instance = getIccService2()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.UpdateICCOrderUploadForPrescriptionSignA79(ds)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function UpdateICCBacterinUploadForPrescriptionSignA79(ByVal ds As DataSet) As String Implements IIccServiceManager.UpdateICCBacterinUploadForPrescriptionSignA79
        Dim instance As IccService2Client = Nothing
        Try
            instance = getIccService2()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.UpdateICCBacterinUploadForPrescriptionSignA79(ds)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

#End Region

#Region "2010/10/20, add by 谷官, 取得醫療院所代碼Config"

    ''' <summary>
    ''' 取得醫療院所代碼Config
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getConfigDataForICCUpload() As DataTable Implements IIccServiceManager.getConfigDataForICCUpload
        Dim instance As IccService2Client = Nothing
        Try
            instance = getIccService2()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.getConfigDataForICCUpload()
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

#End Region

#Region "2015/09/17 病人雲端藥歷(ICC_Cloud_Drug_Patient) by ChenYu.Guo"

#Region "     查詢病人雲端藥歷筆數 "
    ''' <summary>
    ''' 查詢病人雲端藥歷筆數
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by ChenYu.Guo on 2015-09-17</remarks>
    Public Function ICCCloudDrugPatientQueryCountByChartNo(ByVal chartNo As String) As Integer Implements IIccServiceManager.ICCCloudDrugPatientQueryCountByChartNo

        Dim tempclient As IccServiceClient = Nothing

        Try
            tempclient = getIccService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.ICCCloudDrugPatientQueryCountByChartNo(chartNo)
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

#Region "     查詢雲端藥歷有效病人 "
    ''' <summary>
    ''' 查詢雲端藥歷有效病人
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by ChenYu.Guo on 2015-09-18</remarks>
    Public Function ICCCloudDrugPatientQueryEffectivePatient() As DataSet Implements IIccServiceManager.ICCCloudDrugPatientQueryEffectivePatient

        Dim tempclient As IccServiceClient = Nothing

        Try
            tempclient = getIccService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.ICCCloudDrugPatientQueryEffectivePatient()
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

#End Region

#Region "2015/09/17 雲端藥歷檔(ICC_Cloud_Drugs) by ChenYu.Guo"

#Region "     指定顯示欄位查詢 "
    ''' <summary>
    ''' 指定顯示欄位查詢
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by ChenYu.Guo on 2015-09-17</remarks>
    Public Function ICCCloudDrugsQueryAssignColumnsByIdNo(ByVal idNo As String) As DataSet Implements IIccServiceManager.ICCCloudDrugsQueryAssignColumnsByIdNo

        Dim tempclient As IccServiceClient = Nothing

        Try
            tempclient = getIccService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.ICCCloudDrugsQueryAssignColumnsByIdNo(idNo)
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

#End Region

#Region "2015/10/27 IC卡必要欄位檢核維護作業(ICC_Must_Field_Verify) by Eddie,Lu"

#Region "     刪除 "
    ''' <summary>
    ''' 刪除
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-27</remarks>
    Public Function ICCMustFieldVerifydeleteByPk(ByVal pkCode As String) As Integer Implements IIccServiceManager.ICCMustFieldVerifydeleteByPk

        Dim tempclient As IccServiceClient = Nothing

        Try
            tempclient = getIccService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.ICCMustFieldVerifydeleteByPk(pkCode)
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


#Region "     新增 "
    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-27</remarks>
    Public Function ICCMustFieldVerifyinsert(ByVal ds As System.Data.DataSet) As Integer Implements IIccServiceManager.ICCMustFieldVerifyinsert

        Dim tempclient As IccServiceClient = Nothing

        Try
            tempclient = getIccService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.ICCMustFieldVerifyinsert(ds)
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


#Region "     修改 "
    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-27</remarks>
    Public Function ICCMustFieldVerifyupdate(ByVal ds As System.Data.DataSet) As Integer Implements IIccServiceManager.ICCMustFieldVerifyupdate

        Dim tempclient As IccServiceClient = Nothing

        Try
            tempclient = getIccService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.ICCMustFieldVerifyupdate(ds)
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


#Region "     查詢全部 "
    ''' <summary>
    ''' 查詢全部
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-27</remarks>
    Public Function ICCMustFieldVerifyqueryAll() As System.Data.DataSet Implements IIccServiceManager.ICCMustFieldVerifyqueryAll

        Dim tempclient As IccServiceClient = Nothing

        Try
            tempclient = getIccService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.ICCMustFieldVerifyqueryAll()
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


#Region "     序號查詢 "
    ''' <summary>
    ''' 序號查詢
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-27</remarks>
    Public Function ICCMustFieldVerifyqueryByPK(ByRef pk_Serial_Sn As System.String) As System.Data.DataSet Implements IIccServiceManager.ICCMustFieldVerifyqueryByPK

        Dim tempclient As IccServiceClient = Nothing

        Try
            tempclient = getIccService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.ICCMustFieldVerifyqueryByPK(pk_Serial_Sn)
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

#Region "     序號查詢(顯示是,否) "
    ''' <summary>
    ''' 序號查詢
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-27</remarks>
    Public Function ICCMustFieldVerifyqueryByPKYNShow(ByRef pk_Serial_Sn As System.String) As System.Data.DataSet Implements IIccServiceManager.ICCMustFieldVerifyqueryByPKYNShow

        Dim tempclient As IccServiceClient = Nothing

        Try
            tempclient = getIccService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.ICCMustFieldVerifyqueryByPKYNShow(pk_Serial_Sn)
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

#Region "     查詢全部(顯示是,否) "
    ''' <summary>
    ''' 序號查詢
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-27</remarks>
    Public Function ICCMustFieldVerifyqueryAllYNShow() As System.Data.DataSet Implements IIccServiceManager.ICCMustFieldVerifyqueryAllYNShow

        Dim tempclient As IccServiceClient = Nothing

        Try
            tempclient = getIccService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.ICCMustFieldVerifyqueryAllYNShow()
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

#End Region

#Region "2015/10/27 IC卡欄位長度範圍檢核維護作業(ICC_Field_Length_Verify) by Eddie,Lu"

#Region "     刪除 "
    ''' <summary>
    ''' 刪除
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-27</remarks>
    Public Function ICCFieldLengthVerifydelete(ByVal pkCode As String) As Integer Implements IIccServiceManager.ICCFieldLengthVerifydelete

        Dim tempclient As IccServiceClient = Nothing

        Try
            tempclient = getIccService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.ICCFieldLengthVerifydelete(pkCode)
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


#Region "     ID查詢 "
    ''' <summary>
    ''' ID查詢
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-27</remarks>
    Public Function ICCFieldLengthVerifyqueryByPK(ByRef pk_ID As System.String) As System.Data.DataSet Implements IIccServiceManager.ICCFieldLengthVerifyqueryByPK

        Dim tempclient As IccServiceClient = Nothing

        Try
            tempclient = getIccService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.ICCFieldLengthVerifyqueryByPK(pk_ID)
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


#Region "     新增 "
    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-27</remarks>
    Public Function ICCFieldLengthVerifyinsert(ByVal ds As System.Data.DataSet) As Integer Implements IIccServiceManager.ICCFieldLengthVerifyinsert

        Dim tempclient As IccServiceClient = Nothing

        Try
            tempclient = getIccService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.ICCFieldLengthVerifyinsert(ds)
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


#Region "     修改 "
    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-27</remarks>
    Public Function ICCFieldLengthVerifyupdate(ByVal ds As System.Data.DataSet) As Integer Implements IIccServiceManager.ICCFieldLengthVerifyupdate

        Dim tempclient As IccServiceClient = Nothing

        Try
            tempclient = getIccService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.ICCFieldLengthVerifyupdate(ds)
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


#Region "     查詢全部 "
    ''' <summary>
    ''' 查詢全部
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-27</remarks>
    Public Function ICCFieldLengthVerifyqueryAll() As System.Data.DataSet Implements IIccServiceManager.ICCFieldLengthVerifyqueryAll

        Dim tempclient As IccServiceClient = Nothing

        Try
            tempclient = getIccService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.ICCFieldLengthVerifyqueryAll()
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


#End Region

#Region "2015/10/28 IC卡線上檢核維護作業(ICC_Online_Check) by Eddie,Lu"

#Region "     刪除 "
    ''' <summary>
    ''' 刪除
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-28</remarks>
    Public Function ICCOnlineCheckdelete(ByVal pk_ID As String) As Integer Implements IIccServiceManager.ICCOnlineCheckdelete

        Dim tempclient As IccServiceClient = Nothing

        Try
            tempclient = getIccService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.ICCOnlineCheckdelete(pk_ID)
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


#Region "     ID查詢 "
    ''' <summary>
    ''' ID查詢
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-28</remarks>
    Public Function ICCOnlineCheckqueryByPK(ByRef pk_ID As String) As System.Data.DataSet Implements IIccServiceManager.ICCOnlineCheckqueryByPK

        Dim tempclient As IccServiceClient = Nothing

        Try
            tempclient = getIccService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.ICCOnlineCheckqueryByPK(pk_ID)
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


#Region "     查詢全部(顯示是,否) "
    ''' <summary>
    ''' 查詢全部(顯示是,否)
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-28</remarks>
    Public Function ICCOnlineCheckqueryAllYNShow() As System.Data.DataSet Implements IIccServiceManager.ICCOnlineCheckqueryAllYNShow

        Dim tempclient As IccServiceClient = Nothing

        Try
            tempclient = getIccService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.ICCOnlineCheckqueryAllYNShow()
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


#Region "     ID查詢(顯示是,否) "
    ''' <summary>
    ''' ID查詢(顯示是,否)
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-28</remarks>
    Public Function ICCOnlineCheckqueryByPKYNShow(ByRef pk_ID As String) As System.Data.DataSet Implements IIccServiceManager.ICCOnlineCheckqueryByPKYNShow

        Dim tempclient As IccServiceClient = Nothing

        Try
            tempclient = getIccService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.ICCOnlineCheckqueryByPKYNShow(pk_ID)
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


#Region "     新增 "
    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-28</remarks>
    Public Function ICCOnlineCheckinsert(ByVal ds As System.Data.DataSet) As Integer Implements IIccServiceManager.ICCOnlineCheckinsert

        Dim tempclient As IccServiceClient = Nothing

        Try
            tempclient = getIccService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.ICCOnlineCheckinsert(ds)
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


#Region "     修改 "
    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-28</remarks>
    Public Function ICCOnlineCheckupdate(ByVal ds As System.Data.DataSet) As Integer Implements IIccServiceManager.ICCOnlineCheckupdate

        Dim tempclient As IccServiceClient = Nothing

        Try
            tempclient = getIccService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.ICCOnlineCheckupdate(ds)
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


#Region "     查詢全部 "
    ''' <summary>
    ''' 查詢全部
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-28</remarks>
    Public Function ICCOnlineCheckqueryAll() As System.Data.DataSet Implements IIccServiceManager.ICCOnlineCheckqueryAll

        Dim tempclient As IccServiceClient = Nothing

        Try
            tempclient = getIccService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.ICCOnlineCheckqueryAll()
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


#End Region

#Region "2015/10/28 IC卡欄位自身檢核維護作業(ICC_Self_Verify) by Eddie,Lu"

#Region "     刪除 "
    ''' <summary>
    ''' 刪除
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-28</remarks>
    Public Function ICCSelfVerifydelete(ByVal pk_ID As String) As Integer Implements IIccServiceManager.ICCSelfVerifydelete

        Dim tempclient As IccServiceClient = Nothing

        Try
            tempclient = getIccService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.ICCSelfVerifydelete(pk_ID)
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


#Region "     ID查詢 "
    ''' <summary>
    ''' ID查詢
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-28</remarks>
    Public Function ICCSelfVerifyqueryByPK(ByRef pk_ID As String) As System.Data.DataSet Implements IIccServiceManager.ICCSelfVerifyqueryByPK

        Dim tempclient As IccServiceClient = Nothing

        Try
            tempclient = getIccService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.ICCSelfVerifyqueryByPK(pk_ID)
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


#Region "     查詢全部(顯示是,否) "
    ''' <summary>
    ''' 查詢全部(顯示是,否)
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-28</remarks>
    Public Function ICCSelfVerifyqueryAllYNShow() As System.Data.DataSet Implements IIccServiceManager.ICCSelfVerifyqueryAllYNShow

        Dim tempclient As IccServiceClient = Nothing

        Try
            tempclient = getIccService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.ICCSelfVerifyqueryAllYNShow()
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


#Region "     ID查詢(顯示是,否) "
    ''' <summary>
    ''' ID查詢(顯示是,否)
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-28</remarks>
    Public Function ICCSelfVerifyqueryByPKYNShow(ByRef pk_ID As String) As System.Data.DataSet Implements IIccServiceManager.ICCSelfVerifyqueryByPKYNShow

        Dim tempclient As IccServiceClient = Nothing

        Try
            tempclient = getIccService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.ICCSelfVerifyqueryByPKYNShow(pk_ID)
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


#Region "     新增 "
    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-28</remarks>
    Public Function ICCSelfVerifyinsert(ByVal ds As System.Data.DataSet) As Integer Implements IIccServiceManager.ICCSelfVerifyinsert

        Dim tempclient As IccServiceClient = Nothing

        Try
            tempclient = getIccService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.ICCSelfVerifyinsert(ds)
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


#Region "     修改 "
    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-28</remarks>
    Public Function ICCSelfVerifyupdate(ByVal ds As System.Data.DataSet) As Integer Implements IIccServiceManager.ICCSelfVerifyupdate

        Dim tempclient As IccServiceClient = Nothing

        Try
            tempclient = getIccService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.ICCSelfVerifyupdate(ds)
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


#Region "     查詢全部 "
    ''' <summary>
    ''' 查詢全部
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-28</remarks>
    Public Function ICCSelfVerifyqueryAll() As System.Data.DataSet Implements IIccServiceManager.ICCSelfVerifyqueryAll

        Dim tempclient As IccServiceClient = Nothing

        Try
            tempclient = getIccService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.ICCSelfVerifyqueryAll()
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


#End Region

#Region "2015/10/30 IC卡交叉檢核1維護作業(ICC_Interact_Verify1) by Eddie,Lu"

#Region "     刪除 "
    ''' <summary>
    ''' 刪除
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-30</remarks>
    Public Function ICCInteractVerify1delete(ByRef pk_Serial_Sn As String) As Integer Implements IIccServiceManager.ICCInteractVerify1delete

        Dim tempclient As IccServiceClient = Nothing

        Try
            tempclient = getIccService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.ICCInteractVerify1delete(pk_Serial_Sn)
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


#Region "     序號查詢 "
    ''' <summary>
    ''' 序號查詢
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-30</remarks>
    Public Function ICCInteractVerify1queryByPK(ByRef pk_Serial_Sn As String) As DataSet Implements IIccServiceManager.ICCInteractVerify1queryByPK

        Dim tempclient As IccServiceClient = Nothing

        Try
            tempclient = getIccService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.ICCInteractVerify1queryByPK(pk_Serial_Sn)
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


#Region "     查詢全部(顯示是否) "
    ''' <summary>
    ''' 查詢全部(顯示是否)
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-30</remarks>
    Public Function ICCInteractVerify1queryAllYNShow() As DataSet Implements IIccServiceManager.ICCInteractVerify1queryAllYNShow

        Dim tempclient As IccServiceClient = Nothing

        Try
            tempclient = getIccService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.ICCInteractVerify1queryAllYNShow()
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


#Region "     序號查詢(顯示是否) "
    ''' <summary>
    ''' 序號查詢(顯示是否)
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-30</remarks>
    Public Function ICCInteractVerify1queryByPKYNShow(ByRef pk_Serial_Sn As String) As DataSet Implements IIccServiceManager.ICCInteractVerify1queryByPKYNShow

        Dim tempclient As IccServiceClient = Nothing

        Try
            tempclient = getIccService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.ICCInteractVerify1queryByPKYNShow(pk_Serial_Sn)
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


#Region "     新增 "
    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-30</remarks>
    Public Function ICCInteractVerify1insert(ByVal ds As System.Data.DataSet) As Integer Implements IIccServiceManager.ICCInteractVerify1insert

        Dim tempclient As IccServiceClient = Nothing

        Try
            tempclient = getIccService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.ICCInteractVerify1insert(ds)
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


#Region "     修改 "
    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-30</remarks>
    Public Function ICCInteractVerify1update(ByVal ds As System.Data.DataSet) As Integer Implements IIccServiceManager.ICCInteractVerify1update

        Dim tempclient As IccServiceClient = Nothing

        Try
            tempclient = getIccService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.ICCInteractVerify1update(ds)
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


#Region "     查詢全部 "
    ''' <summary>
    ''' 查詢全部
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-30</remarks>
    Public Function ICCInteractVerify1queryAll() As System.Data.DataSet Implements IIccServiceManager.ICCInteractVerify1queryAll

        Dim tempclient As IccServiceClient = Nothing

        Try
            tempclient = getIccService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.ICCInteractVerify1queryAll()
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


#End Region

#Region "2015/10/30 IC卡交叉檢核2維護作業(ICC_Interact_Verify2) by Eddie,Lu"

#Region "     刪除 "
    ''' <summary>
    ''' 刪除
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-30</remarks>
    Public Function ICCInteractVerify2delete(ByRef pk_Serial_Sn As String) As Integer Implements IIccServiceManager.ICCInteractVerify2delete

        Dim tempclient As IccServiceClient = Nothing

        Try
            tempclient = getIccService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.ICCInteractVerify2delete(pk_Serial_Sn)
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


#Region "     序號查詢 "
    ''' <summary>
    ''' 序號查詢
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-30</remarks>
    Public Function ICCInteractVerify2queryByPK(ByRef pk_Serial_Sn As String) As DataSet Implements IIccServiceManager.ICCInteractVerify2queryByPK

        Dim tempclient As IccServiceClient = Nothing

        Try
            tempclient = getIccService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.ICCInteractVerify2queryByPK(pk_Serial_Sn)
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


#Region "     查詢全部(顯示是否) "
    ''' <summary>
    ''' 查詢全部(顯示是否)
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-30</remarks>
    Public Function ICCInteractVerify2queryAllYNShow() As DataSet Implements IIccServiceManager.ICCInteractVerify2queryAllYNShow

        Dim tempclient As IccServiceClient = Nothing

        Try
            tempclient = getIccService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.ICCInteractVerify2queryAllYNShow()
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


#Region "     序號查詢(顯示是否) "
    ''' <summary>
    ''' 序號查詢(顯示是否)
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-30</remarks>
    Public Function ICCInteractVerify2queryByPKYNShow(ByRef pk_Serial_Sn As String) As DataSet Implements IIccServiceManager.ICCInteractVerify2queryByPKYNShow

        Dim tempclient As IccServiceClient = Nothing

        Try
            tempclient = getIccService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.ICCInteractVerify2queryByPKYNShow(pk_Serial_Sn)
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


#Region "     新增 "
    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-30</remarks>
    Public Function ICCInteractVerify2insert(ByVal ds As System.Data.DataSet) As Integer Implements IIccServiceManager.ICCInteractVerify2insert

        Dim tempclient As IccServiceClient = Nothing

        Try
            tempclient = getIccService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.ICCInteractVerify2insert(ds)
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


#Region "     修改 "
    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-30</remarks>
    Public Function ICCInteractVerify2update(ByVal ds As System.Data.DataSet) As Integer Implements IIccServiceManager.ICCInteractVerify2update

        Dim tempclient As IccServiceClient = Nothing

        Try
            tempclient = getIccService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.ICCInteractVerify2update(ds)
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


#Region "     查詢全部 "
    ''' <summary>
    ''' 查詢全部
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-30</remarks>
    Public Function ICCInteractVerify2queryAll() As System.Data.DataSet Implements IIccServiceManager.ICCInteractVerify2queryAll

        Dim tempclient As IccServiceClient = Nothing

        Try
            tempclient = getIccService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.ICCInteractVerify2queryAll()
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


#End Region

#Region "2015/10/30 IC卡交叉檢核3維護作業(ICC_Interact_Verify3) by Eddie,Lu"

#Region "     刪除 "
    ''' <summary>
    ''' 刪除
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-30</remarks>
    Public Function ICCInteractVerify3delete(ByRef pk_Serial_Sn As String) As Integer Implements IIccServiceManager.ICCInteractVerify3delete

        Dim tempclient As IccServiceClient = Nothing

        Try
            tempclient = getIccService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.ICCInteractVerify3delete(pk_Serial_Sn)
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


#Region "     序號查詢 "
    ''' <summary>
    ''' 序號查詢
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-30</remarks>
    Public Function ICCInteractVerify3queryByPK(ByRef pk_Serial_Sn As String) As DataSet Implements IIccServiceManager.ICCInteractVerify3queryByPK

        Dim tempclient As IccServiceClient = Nothing

        Try
            tempclient = getIccService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.ICCInteractVerify3queryByPK(pk_Serial_Sn)
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


#Region "     新增 "
    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-30</remarks>
    Public Function ICCInteractVerify3insert(ByVal ds As System.Data.DataSet) As Integer Implements IIccServiceManager.ICCInteractVerify3insert

        Dim tempclient As IccServiceClient = Nothing

        Try
            tempclient = getIccService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.ICCInteractVerify3insert(ds)
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


#Region "     修改 "
    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-30</remarks>
    Public Function ICCInteractVerify3update(ByVal ds As System.Data.DataSet) As Integer Implements IIccServiceManager.ICCInteractVerify3update

        Dim tempclient As IccServiceClient = Nothing

        Try
            tempclient = getIccService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.ICCInteractVerify3update(ds)
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


#Region "     查詢全部 "
    ''' <summary>
    ''' 查詢全部
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-30</remarks>
    Public Function ICCInteractVerify3queryAll() As System.Data.DataSet Implements IIccServiceManager.ICCInteractVerify3queryAll

        Dim tempclient As IccServiceClient = Nothing

        Try
            tempclient = getIccService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.ICCInteractVerify3queryAll()
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


#End Region

#Region "2015/10/30 IC卡交叉檢核4維護作業(ICC_Interact_Verify4) by Eddie,Lu"

#Region "     刪除 "
    ''' <summary>
    ''' 刪除
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-30</remarks>
    Public Function ICCInteractVerify4delete(ByRef pk_Serial_Sn As String) As Integer Implements IIccServiceManager.ICCInteractVerify4delete

        Dim tempclient As IccServiceClient = Nothing

        Try
            tempclient = getIccService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.ICCInteractVerify4delete(pk_Serial_Sn)
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


#Region "     序號查詢 "
    ''' <summary>
    ''' 序號查詢
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-30</remarks>
    Public Function ICCInteractVerify4queryByPK(ByRef pk_Serial_Sn As String) As DataSet Implements IIccServiceManager.ICCInteractVerify4queryByPK

        Dim tempclient As IccServiceClient = Nothing

        Try
            tempclient = getIccService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.ICCInteractVerify4queryByPK(pk_Serial_Sn)
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


#Region "     查詢全部(顯示是否) "
    ''' <summary>
    ''' 查詢全部(顯示是否)
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-30</remarks>
    Public Function ICCInteractVerify4queryAllYNShow() As DataSet Implements IIccServiceManager.ICCInteractVerify4queryAllYNShow

        Dim tempclient As IccServiceClient = Nothing

        Try
            tempclient = getIccService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.ICCInteractVerify4queryAllYNShow()
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


#Region "     序號查詢(顯示是否) "
    ''' <summary>
    ''' 序號查詢(顯示是否)
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-30</remarks>
    Public Function ICCInteractVerify4queryByPKYNShow(ByRef pk_Serial_Sn As String) As DataSet Implements IIccServiceManager.ICCInteractVerify4queryByPKYNShow

        Dim tempclient As IccServiceClient = Nothing

        Try
            tempclient = getIccService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.ICCInteractVerify4queryByPKYNShow(pk_Serial_Sn)
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


#Region "     新增 "
    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-30</remarks>
    Public Function ICCInteractVerify4insert(ByVal ds As System.Data.DataSet) As Integer Implements IIccServiceManager.ICCInteractVerify4insert

        Dim tempclient As IccServiceClient = Nothing

        Try
            tempclient = getIccService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.ICCInteractVerify4insert(ds)
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


#Region "     修改 "
    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-30</remarks>
    Public Function ICCInteractVerify4update(ByVal ds As System.Data.DataSet) As Integer Implements IIccServiceManager.ICCInteractVerify4update

        Dim tempclient As IccServiceClient = Nothing

        Try
            tempclient = getIccService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.ICCInteractVerify4update(ds)
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


#Region "     查詢全部 "
    ''' <summary>
    ''' 查詢全部
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-30</remarks>
    Public Function ICCInteractVerify4queryAll() As System.Data.DataSet Implements IIccServiceManager.ICCInteractVerify4queryAll

        Dim tempclient As IccServiceClient = Nothing

        Try
            tempclient = getIccService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.ICCInteractVerify4queryAll()
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


#End Region

#Region "2015/10/30 健保卡上傳維護(ICCUploadDataMaintainBS) by Sean.Lin"

#Region "     作廢上傳資料 "
    ''' <summary>
    ''' 作廢上傳資料
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Sean.Lin on 2015-10-30</remarks>
    Public Function ICCUploadDataMaintainBSCancelData(ByVal ds As DataSet) As Integer Implements IIccServiceManager.ICCUploadDataMaintainBSCancelData

        Dim tempclient As IccServiceClient = Nothing

        Try
            tempclient = getIccService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.ICCUploadDataMaintainBSCancelData(ds)
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


#End Region

#Region "取得各類名稱"

    ''' <summary>
    ''' 取得診斷名稱
    ''' </summary>
    ''' <param name="IcdCode">診斷碼</param>
    ''' <param name="IsGetEngName">True:英文, False:中文</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetIcdName(IcdCode As String, IsGetEngName As Boolean) As String Implements IIccServiceManager_T.GetIcdName
        Dim tempclient As IccServiceClient = Nothing

        Try
            tempclient = getIccService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.GetIcdName(IcdCode, IsGetEngName)
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

    ''' <summary>
    ''' 取得醫院名稱
    ''' </summary>
    ''' <param name="HospCode">醫療院所代碼</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetHospName(HospCode As String) As String Implements IIccServiceManager_T.GetHospName
        Dim tempclient As IccServiceClient = Nothing

        Try
            tempclient = getIccService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.GetHospName(HospCode)
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

    ''' <summary>
    ''' 取得治療項目名稱
    ''' </summary>
    ''' <param name="TreatmentCode">治療項代碼</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetTreatmentName(TreatmentCode As String) As String Implements IIccServiceManager_T.GetTreatmentName
        Dim tempclient As IccServiceClient = Nothing

        Try
            tempclient = getIccService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.GetTreatmentName(TreatmentCode)
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

#Region "2016/11/08 DNR註記新增與更新 Will Lin"
#Region "     DNR註記新增與更新 "
    ''' <summary>
    ''' 作廢上傳資料
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Sean.Lin on 2015-10-30</remarks>
    Public Function ProcessPatientOrganDonate(ByVal ChartNo As String, ByVal DNRKindId As String, ByVal LoginUser As String) As Int32 Implements IIccServiceManager.ProcessPatientOrganDonate

        Dim tempclient As IccServiceClient = Nothing

        Try
            tempclient = getIccService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.ProcessPatientOrganDonate(ChartNo, DNRKindId, LoginUser)
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


#End Region
End Class
