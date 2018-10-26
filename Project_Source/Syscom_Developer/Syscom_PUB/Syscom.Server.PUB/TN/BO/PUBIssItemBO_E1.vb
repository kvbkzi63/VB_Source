'/*
'*****************************************************************************
'*
'*    Page/Class Name:  ISS
'*              Title:	PUBIssItemBO_E1
'*        Description:	
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Will.Lin
'*        Create Date:	2016-06-18
'*      Last Modifier:	Will.Lin
'*   Last Modify Date:	2016-06-18
'*
'*****************************************************************************
'*/

Imports System.Data.SqlClient
Imports System.Transactions
Imports System.Text

Imports Syscom.Comm.Utility
Imports Syscom.Comm.EXP
Imports Syscom.Server.SQL
Imports Syscom.Server.BO


Public Class PUBIssItemBO_E1
    Inherits PubIssItemBO

#Region "     使用的Instance宣告 "

    Private Shared myInstance As PUBIssItemBO_E1
    Public Overloads Function GetInstance() As PUBIssItemBO_E1
        If myInstance Is Nothing Then
            myInstance = New PUBIssItemBO_E1
        End If
        Return myInstance
    End Function

#End Region

#Region "     變數宣告 "


#End Region

#Region "     新增 Method "

#End Region

#Region "     修改 Method "

#End Region

#Region "     刪除 Method "

#End Region

#Region "     查詢 Method "

#End Region

End Class

