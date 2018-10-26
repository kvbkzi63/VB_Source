Imports System.Threading
Imports System.Configuration
Imports SR = System.Reflection
Imports System.Text
Imports System.Security.Principal
Imports Syscom.Comm.LOG

Public Class ImpersonateUtil
    Private Shared log As LOGDelegate = LOGDelegate.getInstance
    Private Const LOGON32_PROVIDER_DEFAULT As Integer = 0
    Private Const LOGON32_LOGON_INTERACTIVE As Integer = 2
    Private Const LOGON32_LOGON_NETWORK As Integer = 3
    Private Const LOGON32_LOGON_BATCH As Integer = 4
    Private Const LOGON32_LOGON_SERVICE As Integer = 5
    Private Const LOGON32_LOGON_UNLOCK As Integer = 7
    Private Const LOGON32_LOGON_NETWORK_CLEARTEXT As Integer = 8
    Private Const LOGON32_LOGON_NEW_CREDENTIALS As Integer = 9

    Private Shared ImpersonationContext As WindowsImpersonationContext

    Declare Function LogonUserA Lib "advapi32.dll" ( _
                            ByVal lpszUsername As String, _
                            ByVal lpszDomain As String, _
                            ByVal lpszPassword As String, _
                            ByVal dwLogonType As Integer, _
                            ByVal dwLogonProvider As Integer, _
                            ByRef phToken As IntPtr) As Integer

    Declare Auto Function DuplicateToken Lib "advapi32.dll" ( _
                            ByVal ExistingTokenHandle As IntPtr, _
                            ByVal ImpersonationLevel As Integer, _
                            ByRef DuplicateTokenHandle As IntPtr) As Integer
    Declare Auto Function RevertToSelf Lib "advapi32.dll" () As Long
    Declare Auto Function CloseHandle Lib "kernel32.dll" (ByVal handle As IntPtr) As Long

    Declare Function GetUserName Lib "advapi32.dll" Alias _
       "GetUserNameA" (ByVal lpBuffer As String, _
       ByRef nSize As Integer) As Integer

    Public Shared Function GetUserName() As String
        Dim iReturn As Integer
        Dim userName As String
        userName = New String(CChar(" "), 50)
        iReturn = GetUserName(userName, 50)
        GetUserName = userName.Substring(0, userName.IndexOf(Chr(0)))
    End Function
    ' NOTE:
    ' The identity of the process that impersonates a specific user on a thread must have 
    ' "Act as part of the operating system" privilege. If the the Aspnet_wp.exe process runs
    ' under a the ASPNET account, this account does not have the required privileges to 
    ' impersonate a specific user. This information applies only to the .NET Framework 1.0. 
    ' This privilege is not required for the .NET Framework 1.1.
    '
    ' Sample call:
    '
    '    If impersonateValidUser("username", "domain", "password") Then
    '        'Insert your code here.
    '
    '        undoImpersonation()
    '    Else
    '        'Impersonation failed. Include a fail-safe mechanism here.
    '    End If
    '
    Public Shared Function ImpersonateValidUser(ByVal strUserName As String, _
           ByVal strDomain As String, ByVal strPassword As String) As Boolean
        log.fileDebugMsg("Current User = " & GetUserName & "(" & Environment.UserDomainName & "\" & Environment.UserName & ")")
        If strDomain Is Nothing OrElse strDomain = "" Then
            strDomain = Environment.UserDomainName
        End If
        Dim token As IntPtr = IntPtr.Zero
        Dim tokenDuplicate As IntPtr = IntPtr.Zero
        Dim tempWindowsIdentity As WindowsIdentity

        ImpersonateValidUser = False

        If RevertToSelf() <> 0 Then
            If LogonUserA(strUserName, strDomain, _
               strPassword, _
               LOGON32_LOGON_INTERACTIVE, _
               LOGON32_PROVIDER_DEFAULT, token) <> 0 Then
                If DuplicateToken(token, 2, tokenDuplicate) <> 0 Then
                    tempWindowsIdentity = New WindowsIdentity(tokenDuplicate)
                    ImpersonationContext = tempWindowsIdentity.Impersonate()

                    If Not (ImpersonationContext Is Nothing) Then
                        ImpersonateValidUser = True
                    End If
                End If
            End If
        End If

        If Not tokenDuplicate.Equals(IntPtr.Zero) Then
            CloseHandle(tokenDuplicate)
        End If

        If Not token.Equals(IntPtr.Zero) Then
            CloseHandle(token)
        End If
        log.fileDebugMsg("ImpersonateValidUser = " & ImpersonateValidUser & ",and Current User = " & GetUserName & "(" & Environment.UserDomainName & "\" & Environment.UserName & ")")
    End Function

    Public Shared Sub UndoImpersonation()
        log.fileDebugMsg("Before Undo , Current User = " & GetUserName & "(" & Environment.UserDomainName & "\" & Environment.UserName & ")")
        If ImpersonationContext IsNot Nothing Then
            ImpersonationContext.Undo()
        End If
        log.fileDebugMsg("After Undo , Current User = " & GetUserName & "(" & Environment.UserDomainName & "\" & Environment.UserName & ")")
    End Sub

End Class
