'/*
'*****************************************************************************
'*
'*    Page/Class Name:  JobQaAttachedFilesBO_E1
'*              Title:	JobQaAttachedFilesBO_E1
'*        Description:	
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Will.Lin
'*        Create Date:	2017-10-01
'*      Last Modifier:	Will.Lin
'*   Last Modify Date:	2017-10-01
'*
'*****************************************************************************
'*/

Imports System.Data.SqlClient
Imports System.Transactions
Imports System.Text

Imports Syscom.Comm.Utility
Imports Syscom.Comm.EXP
Imports Syscom.Server.SQL


Public Class JobQaAttachedFilesBO_E1
    Inherits JobQaAttachedFilesBO

#Region "     使用的Instance宣告 "

    Private Shared myInstance As JobQaAttachedFilesBO_E1
    Public Overloads Shared Function GetInstance() As JobQaAttachedFilesBO_E1
        If myInstance Is Nothing Then
            myInstance = New JobQaAttachedFilesBO_E1
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

