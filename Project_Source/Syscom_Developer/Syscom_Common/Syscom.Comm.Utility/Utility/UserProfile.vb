Imports System.Net
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.IO
Imports System.Security
Imports System.Security.Cryptography

Public Class UserProfile

    Private id As String = "HZyYPc8Hp2U=" 'unknown 加密
    Public Property userId() As String
        Get
            Return Decrypt(id)
        End Get
        Set(ByVal value As String)
            id = Encrypt(value)
        End Set
    End Property

    '加密是因為會傳輸到後端去
    Private pw As String = "HZyYPc8Hp2U=" 'unknown 加密
    Public Property userPw() As String
        Get
            Return Decrypt(pw)
        End Get
        Set(ByVal value As String)
            pw = Encrypt(value)
        End Set
    End Property

    Private name As String = "unknown" 'unknown 加密
    Public Property userName() As String
        Get
            '2016/02/01 Sean
            '調整姓名不加密，避免亂碼
            'Return Decrypt(name)
            Return name
        End Get
        Set(ByVal value As String)

            '2016/02/01 Sean
            '調整姓名不加密，避免亂碼
            'name = Encrypt(value)
            name = value
        End Set
    End Property

    Protected ip As String = "unknown"
    'Server 需要被複寫，所以開成 Overridable
    Public Overridable Property userIP() As String
        Get
            Dim IpAddress As String = ""
            For Each nic As System.Net.NetworkInformation.NetworkInterface In System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces()
                If IpAddress <> "" Then
                    Exit For
                End If
                For Each ipInfo As System.Net.NetworkInformation.IPAddressInformation In nic.GetIPProperties().UnicastAddresses
                    If ipInfo.IsDnsEligible = True AndAlso System.Net.IPAddress.IsLoopback(ipInfo.Address) = False AndAlso ipInfo.Address.AddressFamily <> Net.Sockets.AddressFamily.InterNetworkV6 Then
                        IpAddress = ipInfo.Address.ToString.Trim
                        Exit For
                    End If
                Next
            Next
            Return IpAddress
        End Get
        Set(ByVal value As String)
            'ip = value  client  端使用不需要 set
        End Set
    End Property

    Private memberof As String = "HZyYPc8Hp2U=" 'unknown 加密
    Public Property userMemberOf() As String
        Get
            Return Decrypt(memberof)
        End Get
        Set(ByVal value As String)
            memberof = Encrypt(value)
        End Set
    End Property

    Private deptcode As String = "HZyYPc8Hp2U=" 'unknown 加密
    Public Property userDeptCode() As String
        Get
            Return Decrypt(deptcode)
        End Get
        Set(ByVal value As String)
            deptcode = Encrypt(value)
        End Set
    End Property

    Private deptname As String = "HZyYPc8Hp2U=" 'unknown 加密
    Public Property userDeptName() As String
        Get
            Return Decrypt(deptname)
        End Get
        Set(ByVal value As String)
            deptname = Encrypt(value)
        End Set
    End Property

    'add on 20161020 By Lits 醫師所屬科別-------------------------------
    Private drDeptCode As String = "" 'unknown 加密
    Public Property userDrDeptCode() As String
        Get
            Return drDeptCode
        End Get
        Set(ByVal value As String)
            drDeptCode = value
        End Set
    End Property

    Private DrDeptName As String = "" 'unknown 加密
    Public Property userDrDeptName() As String
        Get
            Return drDeptName
        End Get
        Set(ByVal value As String)
            DrDeptName = value
        End Set
    End Property
    '-------------------------------------------------------------------

    Private drLevel As String = "HZyYPc8Hp2U=" 'unknown 加密
    Public Property userDrLevel() As String
        Get
            Return Decrypt(drLevel)
        End Get
        Set(ByVal value As String)
            drLevel = Encrypt(value)
        End Set
    End Property

    Private dutyId As String = "" 'unknown 加密 '20110913 add by bella
    Public Property userDutyId() As String
        Get
            Return Decrypt(dutyId)
        End Get
        Set(ByVal value As String)
            dutyId = Encrypt(value)
        End Set
    End Property

    Private balanceDate As String = "" 'unknown 加密 '20110913 add by bella
    Public Property userBalanceDate() As String
        Get
            Return Decrypt(balanceDate)
        End Get
        Set(ByVal value As String)
            balanceDate = Encrypt(value)
        End Set
    End Property

    Private onStationNo As String = "" 'unknown 加密 '20120424 add by Lits
    Public Property userOnStationNo() As String
        Get
            Return onStationNo
        End Get
        Set(ByVal value As String)
            onStationNo = value
        End Set
    End Property

    Private onTermNo As String = "" 'unknown 加密 '20120518 add by Lits
    Public Property userOnTermNo() As String
        Get
            Return onTermNo
        End Get
        Set(ByVal value As String)
            onTermNo = value
        End Set
    End Property

    Private sourcetypeid As String = "" 'unknown 加密 '20130112 add by Rich
    Public Property systemSourceTypeId() As String
        Get
            Return sourcetypeid
        End Get
        Set(ByVal value As String)
            sourcetypeid = value
        End Set
    End Property


    Public Property isUseIcCard() As Boolean = False    'IC Card

    Public Property appIdleTime() As Integer = 15    '系統閒置時間(分鐘 )

    '************************************************************************
    '登入院區 Add By Sean 20130805
    '************************************************************************
    '登入院區
    Private Section As String = "HZyYPc8Hp2U=" 'unknown 加密
    Public Property userSection() As String
        Get
            Return Decrypt(Section)
        End Get
        Set(ByVal value As String)
            Section = Encrypt(value)
        End Set
    End Property

    Private aid As String = "HZyYPc8Hp2U=" 'unknown 加密
    Public Property agentId() As String
        Get
            Return Decrypt(aid)
        End Get
        Set(ByVal value As String)
            aid = Encrypt(value)
        End Set
    End Property

    Private aname As String = "HZyYPc8Hp2U=" 'unknown 加密
    Public Property agentName() As String
        Get
            Return Decrypt(aname)
        End Get
        Set(ByVal value As String)
            aname = Encrypt(value)
        End Set
    End Property

    Private nrsLevelId As String = "HZyYPc8Hp2U=" 'unknown 加密
    Public Property userNrsLevelId() As String
        Get
            Return Decrypt(nrsLevelId)
        End Get
        Set(ByVal value As String)
            nrsLevelId = Encrypt(value)
        End Set
    End Property

    '************************************************************************

    Private ReadOnly key As String = "b1D8q0F1" '八碼
    Private ReadOnly ivs As String = "S9H7E3q2" '八碼

    ''' <summary>
    ''' 字串加密
    ''' </summary>
    ''' <param name="sourceString">明文</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function Encrypt(ByVal sourceString As String) As String
        Dim btKey As Byte() = Encoding.Default.GetBytes(key)
        Dim btIV As Byte() = Encoding.Default.GetBytes(ivs)
        Dim des As New DESCryptoServiceProvider()
        Dim ms As New MemoryStream()
        Try
            Dim inData As Byte() = Encoding.Default.GetBytes(sourceString)
            Dim cs As New CryptoStream(ms, des.CreateEncryptor(btKey, btIV), CryptoStreamMode.Write)
            cs.Write(inData, 0, inData.Length)
            cs.FlushFinalBlock()
            Return Convert.ToBase64String(ms.ToArray())
        Catch
            Return ""
        Finally
            ms.Dispose()
        End Try
    End Function

    ''' <summary>
    ''' 字串解密
    ''' </summary>
    ''' <param name="encryptedString">密文</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function Decrypt(ByVal encryptedString As String) As String
        Dim btKey As Byte() = Encoding.Default.GetBytes(key)
        Dim btIV As Byte() = Encoding.Default.GetBytes(ivs)
        Dim des As New DESCryptoServiceProvider()
        Dim ms As New MemoryStream()
        Try
            Dim inData As Byte() = Convert.FromBase64String(encryptedString)
            Dim cs As New CryptoStream(ms, des.CreateDecryptor(btKey, btIV), CryptoStreamMode.Write)
            cs.Write(inData, 0, inData.Length)
            cs.FlushFinalBlock()
            Return Encoding.Default.GetString(ms.ToArray())
        Catch
            Return ""
        Finally
            ms.Dispose()
        End Try
    End Function

    '************************************************************************
    '底下部分從 Client 端傳送給 Server 端使用的方法，請勿使用
    '************************************************************************
    Public Function getUserId() As String
        Return id
    End Function
    Public Sub setUserId(ByRef value As String)
        id = value
    End Sub
    Public Function getUserPw() As String
        Return pw
    End Function
    Public Sub setUserPw(ByRef value As String)
        pw = value
    End Sub
    Public Function getUserName() As String
        Return name
    End Function
    Public Sub setUserName(ByRef value As String)
        name = value
    End Sub
    Public Function getUserMemberOf() As String
        Return memberof
    End Function
    Public Sub setUserMemberOf(ByRef value As String)
        memberof = value
    End Sub
    'add on 20161020 By Lits 新增醫師所屬科別
    Public Function getUserDrDeptCode() As String
        Return drDeptCode
    End Function
    Public Sub setUserDrDeptCode(ByRef value As String)
        drDeptCode = value
    End Sub
    Public Function getUserDrDeptName() As String
        Return drDeptName
    End Function
    Public Sub setUserDrDeptName(ByRef value As String)
        drDeptName = value
    End Sub

    Public Function getUserDeptCode() As String
        Return deptcode
    End Function
    Public Sub setUserDeptCode(ByRef value As String)
        deptcode = value
    End Sub
    Public Function getUserDeptName() As String
        Return deptname
    End Function
    Public Sub setUserDeptName(ByRef value As String)
        deptname = value
    End Sub
    Public Function getUserDrLevel() As String
        Return drLevel
    End Function
    Public Sub setUserDrLevel(ByRef value As String)
        drLevel = value
    End Sub
    Public Function getUserDutyId() As String   '20110913 add by bella
        Return dutyId
    End Function
    Public Sub setUserDutyId(ByRef value As String)
        dutyId = value
    End Sub
    Public Function getUserBalanceDate() As String  '20110913 add by bella
        Return balanceDate
    End Function
    Public Sub setUserBalanceDate(ByRef value As String)
        balanceDate = value
    End Sub
    Public Function getOnStationNo() As String  '20120424 add by Lits
        Return onStationNo
    End Function
    Public Sub setUserOnStationNo(ByRef value As String)
        onStationNo = value
    End Sub
    Public Function getOnTermNo() As String
        Return onTermNo
    End Function
    Public Sub setUserOnTermNo(ByRef value As String)
        onTermNo = value
    End Sub
    Public Function getSystemSourceTypeId() As String   '20130112 add by Rich
        Return sourcetypeid
    End Function
    Public Sub setSystemSourceTypeId(ByRef value As String)
        sourcetypeid = value
    End Sub
    Public Function getSectionId() As String    '20130805 add by Sean
        Return Section
    End Function
    Public Sub setSectionId(ByRef value As String)
        Section = value
    End Sub
    Public Function getAgentId() As String
        Return aid
    End Function
    Public Sub setAgentId(ByRef value As String)
        aid = value
    End Sub
    Public Function getAgentName() As String
        Return aname
    End Function
    Public Sub setAgentName(ByRef value As String)
        aname = value
    End Sub
    Public Function getNrsLevelId() As String
        Return nrsLevelId
    End Function
    Public Sub setNrsLevelId(ByRef value As String)
        nrsLevelId = value
    End Sub

End Class
