Imports Syscom.Comm.EXP

Public Class CMMDelegate

#Region "Singleton Design Pattern - Fully Thread Safety"

    ''' <summary>
    ''' 阻止外部直接進行新建立的宣告
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub New()
    End Sub

    ''' <summary>
    ''' 屬性取得類別實體
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property getInstance() As CMMDelegate
        Get
            Threading.Thread.CurrentThread.CurrentCulture = New Globalization.CultureInfo("zh-TW", False)
            Return Nested.instance
        End Get
    End Property

    ''' <summary>
    ''' 巢狀類別存放建立的類別實體
    ''' </summary>
    ''' <remarks></remarks>
    Private Class Nested
        Shared Sub New()
        End Sub

        Public Shared ReadOnly instance As New CMMDelegate()
    End Class

#End Region

    Public Function getPrinterName(ByRef id As String, ByRef type As Integer, ByRef con As Object) As String
        Try
            Return PrinterSelectBO.getInstance.getPrinterName(id, type, con)
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

#Region "     基本類別代碼查詢 回傳 TableName 為 SystemName 的 Dataset "

    ''' <summary>
    ''' 基本類別代碼查詢 - 不限系統；CodeType:查詢代碼；回傳 TableName 為 SystemName 的 Dataset
    ''' 查詢 Pub_Syscode_Type By TypeId 與 SystemName
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Lewis on 2014-2-13</remarks>
    Public Function CMMSysCodeTypeBSSysCodeTypeQuery(ByVal TypeId As String, ByVal SystemName As String) As DataSet
        Dim m_CMMSysCodeBS As CMMSysCodeBS = New CMMSysCodeBS
        Try

            Return m_CMMSysCodeBS.SysCodeTypeQuery(TypeId, SystemName)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

#End Region

#Region "2013/07/19 基本代碼查詢(CMMSysCodeBS) by Sean.Lin"

#Region "     基本代碼查詢 - 不限系統；CodeType:查詢代碼；回傳 TableName 為 CodeType 的 Dataset "

    ''' <summary>
    ''' 基本代碼查詢 - 不限系統；CodeType:查詢代碼；回傳 TableName 為 CodeType 的 Dataset
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Sean.Lin on 2013-7-19</remarks>
    Public Function CMMSysCodeBSSysCodeQuery(ByVal CodeType As Integer, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim m_CMMSysCodeBS As CMMSysCodeBS = New CMMSysCodeBS
        Try

            Return m_CMMSysCodeBS.SysCodeQuery(CodeType)
        Catch cmex As CommonException

            Throw cmex

        Catch ex As Exception

            Throw New CommonException("CMMCMMD001", ex)

        End Try

    End Function

#End Region

#Region "     基本代碼查詢 - 不限系統 - 多筆 ；CodeType:查詢代碼的陣列；回傳 TableName 為 CodeType 的 Dataset "

    ''' <summary>
    ''' 基本代碼查詢 - 不限系統 - 多筆 ；CodeType:查詢代碼的陣列；回傳 TableName 為 CodeType 的 Dataset
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Sean.Lin on 2013-7-19</remarks>
    Public Function CMMSysCodeBSSysCodeQueryMuti(ByVal CodeType As Integer(), Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim m_CMMSysCodeBS As CMMSysCodeBS = New CMMSysCodeBS
        Try

            Return m_CMMSysCodeBS.SysCodeQueryMuti(CodeType)
        Catch cmex As CommonException

            Throw cmex

        Catch ex As Exception

            Throw New CommonException("CMMCMMD001", ex)

        End Try

    End Function

#End Region

#End Region

#Region "2013/09/16 院區、部門代碼查詢(CMMSysCode) by Sean.Lin"

#Region "     院區代碼查詢 "

    ''' <summary>
    ''' 院區代碼查詢
    ''' </summary>
    ''' <returns>DataSet</returns>    ''' <remarks>by Sean.Lin on 2013-09-16</remarks>
    Public Function CMMSysCodequerySectionCode() As DataSet

        Dim m_CMMSysCode As CMMSysCodeBS = New CMMSysCodeBS
        Try

            Return m_CMMSysCode.querySectionCode()
        Catch cmex As CommonException

            Throw cmex

        Catch ex As Exception

            Throw New CommonException("CMMCMMD001", ex)

        End Try

    End Function

#End Region

#Region "     部門代碼查詢 "

    ''' <summary>
    ''' 部門代碼查詢
    ''' </summary>
    ''' <returns>DataSet</returns>    ''' <remarks>by Sean.Lin on 2013-09-16</remarks>
    Public Function CMMSysCodequeryDeptTCodeBySectionCode() As DataSet

        Dim m_CMMSysCode As CMMSysCodeBS = New CMMSysCodeBS
        Try

            Return m_CMMSysCode.queryDeptTCodeBySectionCode()
        Catch cmex As CommonException

            Throw cmex

        Catch ex As Exception

            Throw New CommonException("CMMCMMD001", ex)

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
    Public Function CMMSysCodeQueryPubConfigMuti(ByVal configName As String(), Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim m_CMMSysCode As CMMSysCodeBS = New CMMSysCodeBS
        Try

            Return m_CMMSysCode.QueryPubConfigMuti(configName, conn)
        Catch cmex As CommonException

            Throw cmex

        Catch ex As Exception

            Throw New CommonException("CMMCMMD001", ex)

        End Try

    End Function


#End Region

#End Region

End Class
