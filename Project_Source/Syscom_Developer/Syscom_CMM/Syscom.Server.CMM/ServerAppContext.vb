Imports Syscom.Server.BO
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
Imports Syscom.Comm.LOG
Imports Syscom.Comm.EXP
Imports System.ServiceModel

Public Class ServerAppContext

    ''' <summary>
    ''' 阻止外部直接宣告
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub New()

    End Sub

    Public Shared ReadOnly Property userProfile() As ServerUserProfile
        Get
            Return getUserProfileFromClient()
        End Get
    End Property

    Public Shared Sub setUserProfile(ByRef user As ServerUserProfile)
        System.Runtime.Remoting.Messaging.CallContext.SetData("userProfile", user)
    End Sub

    Public Shared Function getUserProfileFromClient() As ServerUserProfile
        Try
            Dim user = System.Runtime.Remoting.Messaging.CallContext.GetData("userProfile")
            If user IsNot Nothing AndAlso TypeOf (user) Is ServerUserProfile Then
                'LOGDelegate.getInstance.dbDebugMsg("get userProfile from CallContext userID:" & CType(user, ServerUserProfile).userId)
                Return CType(user, ServerUserProfile)
            Else
                user = New ServerUserProfile
                Dim headers = OperationContext.Current.IncomingMessageHeaders
                Dim userID = IIf(StringUtil.nvl(headers.GetHeader(Of String)("userID", "kmuh")) = "", user.getUserId, StringUtil.nvl(headers.GetHeader(Of String)("userID", "kmuh")))
                Dim userName = IIf(StringUtil.nvl(headers.GetHeader(Of String)("userName", "kmuh")) = "", user.getUserName, StringUtil.nvl(headers.GetHeader(Of String)("userName", "kmuh")))
                Dim userPw = IIf(StringUtil.nvl(headers.GetHeader(Of String)("userPw", "kmuh")) = "", user.getUserPw, StringUtil.nvl(headers.GetHeader(Of String)("userPw", "kmuh")))
                Dim userIP = IIf(StringUtil.nvl(headers.GetHeader(Of String)("userIP", "kmuh")) = "", user.userIP, StringUtil.nvl(headers.GetHeader(Of String)("userIP", "kmuh")))
                Dim userMemberOf = IIf(StringUtil.nvl(headers.GetHeader(Of String)("userMemberOf", "kmuh")) = "", user.getUserMemberOf, StringUtil.nvl(headers.GetHeader(Of String)("userMemberOf", "kmuh")))
                Dim userDeptCode = IIf(StringUtil.nvl(headers.GetHeader(Of String)("userDeptCode", "kmuh")) = "", user.getUserDeptCode, StringUtil.nvl(headers.GetHeader(Of String)("userDeptCode", "kmuh")))
                Dim userDeptName = IIf(StringUtil.nvl(headers.GetHeader(Of String)("userDeptName", "kmuh")) = "", user.getUserDeptName, StringUtil.nvl(headers.GetHeader(Of String)("userDeptName", "kmuh")))
                'for 高聯醫 醫師所屬科
                Dim userdrDeptCode = IIf(StringUtil.nvl(headers.GetHeader(Of String)("drDeptCode", "kmuh")) = "", user.getUserDeptCode, StringUtil.nvl(headers.GetHeader(Of String)("drDeptCode", "kmuh")))
                Dim userdrDeptName = IIf(StringUtil.nvl(headers.GetHeader(Of String)("drDeptName", "kmuh")) = "", user.getUserDeptName, StringUtil.nvl(headers.GetHeader(Of String)("drDeptName", "kmuh")))
                user.setUserdrDeptName(userdrDeptName)
                user.setUserdrDeptName(userdrDeptName)

                user.setUserId(userID)
                user.setUserName(userName)
                user.setUserPw(userPw)
                user.userIP = userIP
                user.setUserMemberOf(userMemberOf)
                user.setUserDeptCode(userDeptCode)
                user.setUserDeptName(userDeptName)

                setUserProfile(user)
                'LOGDelegate.getInstance.dbDebugMsg("get userProfile from New ServerUserProfile userID:" & user.userId)
                Return user
            End If
            'Catch cmex As CommonException
            '    Throw cmex
        Catch ex As Exception
            'Throw New CommonException("CMMCMMD001", ex)
            Dim userUnknown = New ServerUserProfile
            userUnknown.setUserId("Unknown")
            userUnknown.setUserName("Unknown")
            userUnknown.setUserPw("Unknown")
            userUnknown.userIP = "Unknown"
            userUnknown.setUserMemberOf("Unknown")
            userUnknown.setUserDeptCode("Unknown")
            userUnknown.setUserDeptName("Unknown")
            userUnknown.setUserDrDeptCode("Unknown")
            userUnknown.setUserDrDeptName("Unknown")

            setUserProfile(userUnknown)
            Return userUnknown
        End Try
    End Function

End Class
