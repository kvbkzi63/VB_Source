'/*
'*****************************************************************************
'*
'*    Page/Class Name:  登入者資訊檔
'*              Title:	AppContext
'*        Description:	記錄登入者的相關帳號資訊，使用者ID、密碼、院區等
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Sean.Lin
'*        Create Date:	2013-12-12
'*      Last Modifier:	Syscom
'*   Last Modify Date:	2013-12-12
'*
'*****************************************************************************
'*/

Imports System.Runtime.Remoting.Messaging
Imports System.ServiceModel

Public Class AppContext

    '記錄登入者的資料
    Protected Friend Shared user As UserProfile = New UserProfile

    ''' <summary>
    ''' 阻止外部直接進行新建立的宣告
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub New()
    End Sub

    ''' <summary>
    ''' 取得登入者的個人資料
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Property userProfile() As UserProfile
        Get
            Return user
        End Get
        Set(value As UserProfile)
            user = value
        End Set
    End Property

    '鎖定同一時間僅單一執行緒可存取的物件
    Private Shared ReadOnly lockObject As New Object

    ''' <summary>
    ''' 將 client UserProfile 的內容，放入WCF MessageHeader 裡
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub setUserProfiletoServer()
        Try
            SyncLock lockObject

                Dim userID = user.getUserId
                Dim userName = user.getUserName
                Dim userPw = user.getUserPw
                Dim userIP = user.userIP
                Dim userDrLevel = user.getUserDrLevel
                Dim userDeptCode = user.getUserDeptCode
                Dim userDeptName = user.getUserDeptName
                Dim agentID = user.getAgentId
                Dim agentName = user.getAgentName
                'User 所屬的權限集合
                Dim userMemberOf = user.getUserMemberOf
                Dim userDutyId = user.getUserDutyId
                Dim userOnStation = user.getOnStationNo
                Dim userOnTerm = user.getOnTermNo
                Dim systemSourceTypeId = user.getSystemSourceTypeId

                'ICCard Flag
                Dim isUseIcCard = user.isUseIcCard
                '系統閒置時間
                Dim APPIdleTime As Integer = user.appIdleTime
                '************************************************************************
                'For 登入院區 Add By Sean 20130805
                '************************************************************************
                Dim systemSectionID = user.getSectionId
                '************************************************************************

                'For 高聯醫-醫師所屬科 Add By Lits on 20161020
                '************************************************************************
                Dim drDeptCode = user.getUserDrDeptCode
                Dim drDeptName = user.getUserDrDeptName
                '************************************************************************

                Dim userIDHeader = New MessageHeader(Of String)(userID)
                Dim userNameHeader = New MessageHeader(Of String)(userName)
                Dim agentIDHeader = New MessageHeader(Of String)(agentID)
                Dim agentNameHeader = New MessageHeader(Of String)(agentName)
                Dim userPwHeader = New MessageHeader(Of String)(userPw)
                Dim userIPHeader = New MessageHeader(Of String)(userIP)
                Dim userDrLevelHeader = New MessageHeader(Of String)(userDrLevel)
                Dim userDeptCodeHeader = New MessageHeader(Of String)(userDeptCode)
                Dim useruserDeptNameHeader = New MessageHeader(Of String)(userDeptName)
                Dim useruserMemberOfHeader = New MessageHeader(Of String)(userMemberOf)
                Dim userDutyIdHeader = New MessageHeader(Of String)(userDutyId)
                Dim userOnStationHeader = New MessageHeader(Of String)(userOnStation)
                Dim userOnTermHeader = New MessageHeader(Of String)(userOnTerm)
                Dim systemSourceTypeIdHeader = New MessageHeader(Of String)(systemSourceTypeId)
                Dim isUseIcCardHeader = New MessageHeader(Of Boolean)(isUseIcCard)
                Dim appIdleTimeHeader = New MessageHeader(Of Integer)(appIdleTime) '系統閒置時間
                '************************************************************************
                'For 登入院區 Add By Sean 20130805
                '************************************************************************
                Dim systemSectionIDHeader = New MessageHeader(Of String)(systemSectionID)
                '************************************************************************

                'For 高聯醫-醫師所屬科 Add By Lits on 20161020
                '************************************************************************
                Dim drDeptCodeHeader = New MessageHeader(Of String)(drDeptCode)
                Dim drDeptNameHeader = New MessageHeader(Of String)(drDeptName)
                '************************************************************************

                OperationContext.Current.OutgoingMessageHeaders.Add(userIDHeader.GetUntypedHeader("userID", "kmuh"))
                OperationContext.Current.OutgoingMessageHeaders.Add(userNameHeader.GetUntypedHeader("userName", "kmuh"))
                OperationContext.Current.OutgoingMessageHeaders.Add(agentIDHeader.GetUntypedHeader("agentID", "kmuh"))
                OperationContext.Current.OutgoingMessageHeaders.Add(agentNameHeader.GetUntypedHeader("agentName", "kmuh"))
                OperationContext.Current.OutgoingMessageHeaders.Add(userPwHeader.GetUntypedHeader("userPw", "kmuh"))
                OperationContext.Current.OutgoingMessageHeaders.Add(userIPHeader.GetUntypedHeader("userIP", "kmuh"))
                OperationContext.Current.OutgoingMessageHeaders.Add(userDrLevelHeader.GetUntypedHeader("userDrLevel", "kmuh"))
                OperationContext.Current.OutgoingMessageHeaders.Add(userDeptCodeHeader.GetUntypedHeader("userDeptCode", "kmuh"))
                OperationContext.Current.OutgoingMessageHeaders.Add(useruserDeptNameHeader.GetUntypedHeader("userDeptName", "kmuh"))
                OperationContext.Current.OutgoingMessageHeaders.Add(useruserMemberOfHeader.GetUntypedHeader("userMemberOf", "kmuh"))
                OperationContext.Current.OutgoingMessageHeaders.Add(userDutyIdHeader.GetUntypedHeader("userDutyId", "kmuh"))
                OperationContext.Current.OutgoingMessageHeaders.Add(userOnStationHeader.GetUntypedHeader("userOnStation", "kmuh"))
                OperationContext.Current.OutgoingMessageHeaders.Add(userOnTermHeader.GetUntypedHeader("userOnTerm", "kmuh"))
                OperationContext.Current.OutgoingMessageHeaders.Add(systemSourceTypeIdHeader.GetUntypedHeader("systemSourceTypeId", "kmuh"))

                '************************************************************************
                'For PHMIS 登入院區 Add By Sean 20130805
                '************************************************************************
                OperationContext.Current.OutgoingMessageHeaders.Add(systemSourceTypeIdHeader.GetUntypedHeader("systemSectionID", "kmuh"))
                '************************************************************************

                'For 高聯醫-醫師所屬科 Add By Lits on 20161020
                '************************************************************************
                OperationContext.Current.OutgoingMessageHeaders.Add(systemSourceTypeIdHeader.GetUntypedHeader("drDeptCode", "kmuh"))
                OperationContext.Current.OutgoingMessageHeaders.Add(systemSourceTypeIdHeader.GetUntypedHeader("drDeptName", "kmuh"))
                '************************************************************************

            End SyncLock
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class
