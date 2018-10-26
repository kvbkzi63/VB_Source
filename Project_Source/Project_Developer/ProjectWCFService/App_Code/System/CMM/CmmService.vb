' 注意: 若變更此處的類別名稱 "CmmService"，也必須更新 Web.config 與關聯之 .svc 檔案中 "CmmService" 的參考。
Imports System.Data
Imports Syscom.Comm.EXP
Imports Syscom.Comm.LOG
Imports Syscom.Server.CMM
Imports System.Reflection

Public Class CmmService
    Implements ICmmService

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
    Public Function getPrinterName(ByVal id As String, ByVal type As Integer, ByVal con As Object) As String Implements ICmmService.getPrinterName
        Try
            Return Syscom.Server.CMM.CMMDelegate.getInstance.getPrinterName(id, type, con)
        
        Catch cmex As CommonException

            Throw ServerExceptionHandler.ProccessException(cmex)

        Catch ex As Exception

            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))

        End Try

    End Function

#End Region

#Region "取得報表ID"
    Function getReportID() As String Implements ICmmService.getReportID
        Try
            Return Syscom.Server.SNC.SNCDelegate.getInstance.getReportSerialNo

        Catch cmex As CommonException

            Throw ServerExceptionHandler.ProccessException(cmex)

        Catch ex As Exception

            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))

        End Try

    End Function

#End Region

#Region "2013/07/19 基本代碼查詢(CMMSysCodeBS) by Sean.Lin"

#Region "     基本代碼查詢 - 不限系統 "
    ''' <summary>
    ''' 基本代碼查詢 - 不限系統；CodeType:查詢代碼；回傳 TableName 為 CodeType 的 Dataset;包含 Code_ID,Code_Name,Code_EN_Name,Combine_Name,Combine_EN_Name 
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Sean.Lin on 2013-7-19</remarks>
    Public Function CMMSysCodeBSSysCodeQuery(ByVal CodeType As Integer) As DataSet Implements ICmmService.CMMSysCodeBSSysCodeQuery

        Try

            Dim tempDelegate As CMMDelegate = CMMDelegate.getInstance

            Return tempDelegate.CMMSysCodeBSSysCodeQuery(CodeType)

        Catch cmex As CommonException

            Throw ServerExceptionHandler.ProccessException(cmex)

        Catch ex As Exception

            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))

        End Try

    End Function

#End Region


#Region "     基本代碼查詢 - 不限系統 - 多筆 "

    ''' <summary>
    ''' 基本代碼查詢 - 不限系統 - 多筆 ；CodeType:查詢代碼的陣列；回傳 TableName 為 CodeType 的 Dataset;包含 Code_ID,Code_Name,Code_EN_Name,Combine_Name,Combine_EN_Name 
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Sean.Lin on 2013-7-19</remarks>
    Public Function CMMSysCodeBSSysCodeQueryMuti(ByVal CodeType As Integer()) As DataSet Implements ICmmService.CMMSysCodeBSSysCodeQueryMuti

        Try

            Dim tempDelegate As CMMDelegate = CMMDelegate.getInstance

            Return tempDelegate.CMMSysCodeBSSysCodeQueryMuti(CodeType)

        Catch cmex As CommonException

            Throw ServerExceptionHandler.ProccessException(cmex)

        Catch ex As Exception

            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))

        End Try

    End Function

#End Region


#End Region

#Region " 2014/02/14    基本類別代碼查詢 by Lewis "
    ''' <summary>
    ''' 基本類別代碼查詢 - 不限系統；CodeType:查詢代碼；回傳 TableName 為 SystemName 的 Dataset
    ''' 查詢 Pub_Syscode_Type By TypeId 與 SystemName
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Lewis on 2014-2-13</remarks>
    Public Function CMMSysCodeTypeBSSysCodeTypeQuery(ByVal TypeId As String, ByVal SystemName As String) As DataSet Implements ICmmService.CMMSysCodeTypeBSSysCodeTypeQuery

        Try

            Dim tempDelegate As CMMDelegate = CMMDelegate.getInstance

            Return tempDelegate.CMMSysCodeTypeBSSysCodeTypeQuery(TypeId, SystemName)

        Catch cmex As CommonException

            Throw ServerExceptionHandler.ProccessException(cmex)

        Catch ex As Exception

            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))

        End Try

    End Function

#End Region

#Region "2013/09/16 院區、部門代碼查詢(CMMSysCode) by Sean.Lin"

#Region "     院區代碼查詢 "
    ''' <summary>
    ''' 院區代碼查詢
    ''' </summary>
    ''' <returns>DataSet</returns>    ''' <remarks>by Sean.Lin on 2013-09-16</remarks>
    Public Function CMMSysCodequerySectionCode() As DataSet Implements ICmmService.CMMSysCodequerySectionCode

        Try

            Dim tempDelegate As CMMDelegate = CMMDelegate.getInstance

            Return tempDelegate.CMMSysCodequerySectionCode()

        Catch cmex As CommonException

            Throw ServerExceptionHandler.ProccessException(cmex)

        Catch ex As Exception

            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))

        End Try

    End Function

#End Region


#Region "     部門代碼查詢 "
    ''' <summary>
    ''' 部門代碼查詢
    ''' </summary>
    ''' <returns>DataSet</returns>    ''' <remarks>by Sean.Lin on 2013-09-16</remarks>
    Public Function CMMSysCodequeryDeptTCodeBySectionCode() As DataSet Implements ICmmService.CMMSysCodequeryDeptTCodeBySectionCode

        Try

            Dim tempDelegate As CMMDelegate = CMMDelegate.getInstance

            Return tempDelegate.CMMSysCodequeryDeptTCodeBySectionCode()

        Catch cmex As CommonException

            Throw ServerExceptionHandler.ProccessException(cmex)

        Catch ex As Exception

            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))

        End Try

    End Function

#End Region


#End Region

#Region "2016/05/23 查詢參數檔 By Steven,Lin"

#Region " 查詢參數檔 - 多筆 "

    ''' <summary>
    ''' 查詢參數檔 - 多筆，回傳一個DS，Table Name 為 傳入的 configName
    ''' </summary>
    ''' <param name="configName" >參數名</param>
    ''' <returns>Dataset</returns>
    ''' <remarks>by Sean.Lin on 2016-05-18</remarks>
    Public Function CMMSysCodeQueryPubConfigMuti(ByVal configName As String(), Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet Implements ICmmService.CMMSysCodeQueryPubConfigMuti

        Try

            Dim tempDelegate As CMMDelegate = CMMDelegate.getInstance

            Return tempDelegate.CMMSysCodeQueryPubConfigMuti(configName)

        Catch cmex As CommonException

            Throw ServerExceptionHandler.ProccessException(cmex)

        Catch ex As Exception

            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))

        End Try

    End Function


#End Region

#End Region

End Class
