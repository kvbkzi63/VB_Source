Imports System.DirectoryServices
Imports System.Text
Imports System.Configuration
Imports System.Data.SqlClient
Imports Syscom.Server.SQL
Imports Syscom.Comm.EXP

Public Class ADEntry

    Enum ADEntrys
        ROLE
        USER
    End Enum

    Public Shared GROUP As String = "GROUP"
    Public Shared USER As String = "USER"
    '用來設定類型
    Public Shared ARM_TYPE As String = "objectClass"
    Public Shared ARM_TYPE_CATEGORY As String = "objectCategory"
    Public Shared ARM_TYPE_ROLE As String = "group"
    Public Shared ARM_TYPE_USER As String = "user"
    '尚有部門 科室等
    Public Shared ARM_PKEY As String = "cn"                                 '名稱
    Public Shared ARM_KEY As String = "samAccountName"                      '使用者登入名稱 (Windows 2000 前版)
    '角色
    Public Shared ARM_ROLE_NAME As String = "description"                   '顯示名稱 => 改成描述
    Public Shared ARM_ROLE_ISVALID As String = "info"                       '注意事項
    Public Shared ARM_ROLE_CREATOR As String = "adminDisplayName"
    Public Shared ARM_ROLE_CREATETIME As String = "whenCreated"
    Public Shared ARM_ROLE_MODIFIER As String = "accountNameHistory"
    Public Shared ARM_ROLE_MODIFYTIME As String = "whenChanged"
    '使用者 共通欄位可合併
    Public Shared ARM_USER_NAME As String = "givenName"                     '從displayName => 改成 givenName
    Public Shared ARM_USER_ISVALID As String = "info"
    Public Shared ARM_USER_CREATOR As String = "adminDisplayName"
    Public Shared ARM_USER_CREATETIME As String = "whenCreated"
    Public Shared ARM_USER_MODIFIER As String = "accountNameHistory"
    Public Shared ARM_USER_MODIFYTIME As String = "whenChanged"
    Public Shared ARM_USER_BIRTHDAY As String = "comment"
    Public Shared ARM_USER_PASSWORD As String = "userPassword"
    Public Shared ARM_USER_LOGINNAME As String = "userPrincipalName"        '使用者登入名稱
    Public Shared ARM_USER_ACCOUNTCONTROL As String = "userAccountControl"  '帳戶選項
    Public Shared ARM_USER_MAIL As String = "mail"                          '電子郵件
    Public Shared ARM_USER_DEPARTMENT As String = "department"              '部門
    Public Shared ARM_USER_DEPARTMENTNUMBER As String = "departmentNumber"
    Public Shared ARM_USER_MEMBEROF As String = "memberof"
    '感興趣的項目
    Public Shared ARM_ROLE_COLUMNS() As String = {ARM_PKEY, ARM_ROLE_NAME, ARM_ROLE_ISVALID, ARM_ROLE_CREATOR, _
                                                  ARM_ROLE_CREATETIME, ARM_ROLE_MODIFIER, ARM_ROLE_MODIFYTIME}
    Public Shared ARM_USER_COLUMNS() As String = {ARM_PKEY, ARM_USER_NAME, ARM_USER_BIRTHDAY, ARM_USER_ISVALID, _
                                                  ARM_USER_MAIL, ARM_USER_DEPARTMENT, ARM_USER_DEPARTMENTNUMBER, _
                                                  ARM_USER_CREATOR, ARM_USER_CREATETIME, ARM_USER_MODIFIER, _
                                                  ARM_USER_MODIFYTIME}
    Public Shared ARM_ROLE_DATA_COL() As DataColumn = {New DataColumn(ARM_PKEY), _
                                                       New DataColumn(ARM_ROLE_NAME), _
                                                       New DataColumn(ARM_ROLE_ISVALID), _
                                                       New DataColumn(ARM_ROLE_CREATOR), _
                                                       New DataColumn(ARM_ROLE_CREATETIME), _
                                                       New DataColumn(ARM_ROLE_MODIFIER), _
                                                       New DataColumn(ARM_ROLE_MODIFYTIME)}

    ''' <summary>
    ''' 設定 AD 實體的屬性
    ''' </summary>
    ''' <param name="de">目錄實體</param>
    ''' <param name="PropertyName">屬性名稱</param>
    ''' <param name="PropertyValue">屬性值</param>
    ''' <remarks></remarks>
    Public Shared Sub SetProperty(ByRef de As DirectoryEntry, ByVal PropertyName As String, ByVal PropertyValue As String)
        Try
            If de.Properties.Contains(PropertyName) Then
                de.Properties(PropertyName).Value = PropertyValue
            Else
                de.Properties(PropertyName).Add(PropertyValue)
            End If
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Sub

    ''' <summary>
    ''' 取得DirectoryEntry
    ''' </summary>
    ''' <param name="entryRoot"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getADEntry(ByVal entryRoot As ADEntrys) As DirectoryEntry
        Dim adsPath As StringBuilder = New StringBuilder(ConfigurationManager.AppSettings.Item("ADSPrePath"))
        If ADEntrys.USER = entryRoot Then
            adsPath.Append(ConfigurationManager.AppSettings.Item("ADSUserPath"))
        ElseIf ADEntrys.ROLE = entryRoot Then
            adsPath.Append(ConfigurationManager.AppSettings.Item("ADSRolePath"))
        Else
            Throw New CommonException("CMMCMMB300", New String() {"輸入錯誤的ADEntry實體"})
        End If
        '回傳預設帳號密碼的DirectoryEntry
        Return New DirectoryEntry(adsPath.ToString, ConfigurationManager.AppSettings.Item("ADAdmin"), ConfigurationManager.AppSettings.Item("ADPassword"), AuthenticationTypes.Secure)
    End Function

End Class
