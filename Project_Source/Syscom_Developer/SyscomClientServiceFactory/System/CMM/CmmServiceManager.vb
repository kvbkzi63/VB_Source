Imports System.ServiceModel
Imports Syscom.Comm.Utility
Imports Syscom.Comm.EXP
Imports Syscom.Client.Servicefactory.CmmServiceReference
Imports System.Reflection

Partial Class CmmServiceManager

#Region "取得印表機名稱"

    ''' <summary>
    ''' 取得印表機名稱
    ''' Add By Jen
    ''' </summary>
    ''' <param name="id"></param>
    ''' <param name="type"></param>
    ''' <param name="con"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getPrinterName(ByVal id As String, ByVal type As Integer, ByVal con As Object) As String Implements ICmmServiceManager.getPrinterName
        Dim instance As CmmServiceClient = Nothing
        Try
            instance = getCmmService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.getPrinterName(id, type, con)
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

#Region "取得報表ID"


    Public Function getReportID() As String Implements ICmmServiceManager.getReportID
        Dim instance As CmmServiceClient = Nothing
        Try
            instance = getCmmService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.getReportID
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

#Region "2013/07/19 基本代碼查詢(CMMSysCodeBS) by Sean.Lin"

    ''' <summary>
    ''' 基本代碼查詢 - 不限系統；CodeType:查詢代碼；回傳 TableName 為 CodeType 的 Dataset;包含 Code_ID,Code_Name,Code_EN_Name,Combine_Name,Combine_EN_Name 
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Sean.Lin on 2013-7-19</remarks>
    Public Function CMMSysCodeBSSysCodeQuery(ByVal CodeType As Integer) As DataSet Implements ICmmServiceManager_T.CMMSysCodeBSSysCodeQuery
        Dim instance As CmmServiceClient = Nothing
        Try
            instance = getCmmService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.CMMSysCodeBSSysCodeQuery(CodeType)
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

    ''' <summary>
    ''' 基本代碼查詢 - 不限系統 - 多筆 ；CodeType:查詢代碼的陣列；回傳 TableName 為 CodeType 的 Dataset;包含 Code_ID,Code_Name,Code_EN_Name,Combine_Name,Combine_EN_Name 
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Sean.Lin on 2013-7-19</remarks>
    Public Function CMMSysCodeBSSysCodeQueryMuti(ByVal CodeType As Integer()) As DataSet Implements ICmmServiceManager_T.CMMSysCodeBSSysCodeQueryMuti
        Dim instance As CmmServiceClient = Nothing
        Try
            instance = getCmmService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.CMMSysCodeBSSysCodeQueryMuti(CodeType)
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

    ''' <summary>
    ''' 基本類別代碼查詢 - 不限系統；CodeType:查詢代碼；回傳 TableName 為 SystemName 的 Dataset
    ''' 查詢 Pub_Syscode_Type By TypeId 與 SystemName
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Lewis on 2014-2-13</remarks>
    Public Function CMMSysCodeTypeBSSysCodeTypeQuery(ByVal TypeId As String, ByVal SystemName As String) As DataSet Implements ICmmServiceManager_T.CMMSysCodeTypeBSSysCodeTypeQuery
        Dim instance As CmmServiceClient = Nothing
        Try
            instance = getCmmService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.CMMSysCodeTypeBSSysCodeTypeQuery(TypeId, SystemName)
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

#Region "2013/09/16 院區、部門代碼查詢(CMMSysCode) by Sean.Lin"

    ''' <summary>
    ''' 院區代碼查詢
    ''' </summary>
    ''' <returns>DataSet</returns>    ''' <remarks>by Sean.Lin on 2013-09-16</remarks>
    Public Function CMMSysCodequerySectionCode() As DataSet Implements ICmmServiceManager.CMMSysCodequerySectionCode
        Dim instance As CmmServiceClient = Nothing
        Try
            instance = getCmmService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.CMMSysCodequerySectionCode()
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

    ''' <summary>
    ''' 部門代碼查詢
    ''' </summary>
    ''' <returns>DataSet</returns>    ''' <remarks>by Sean.Lin on 2013-09-16</remarks>
    Public Function CMMSysCodequeryDeptTCodeBySectionCode() As DataSet Implements ICmmServiceManager.CMMSysCodequeryDeptTCodeBySectionCode
        Dim instance As CmmServiceClient = Nothing
        Try
            instance = getCmmService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.CMMSysCodequeryDeptTCodeBySectionCode()
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

#Region "2016/05/23 查詢參數檔 By Steven,Lin"

#Region " 查詢參數檔 - 多筆 "

    ''' <summary>
    ''' 查詢參數檔 - 多筆，回傳一個DS，Table Name 為 傳入的 configName
    ''' </summary>
    ''' <param name="configName" >參數名</param>
    ''' <returns>Dataset</returns>
    ''' <remarks>by Sean.Lin on 2016-05-18</remarks>
    Public Function CMMSysCodeQueryPubConfigMuti(ByVal configName As String(), Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet Implements ICmmServiceManager.CMMSysCodeQueryPubConfigMuti

        Dim instance As CmmServiceClient = Nothing
        Try
            instance = getCmmService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.CMMSysCodeQueryPubConfigMuti(configName, conn)
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

#End Region

End Class
