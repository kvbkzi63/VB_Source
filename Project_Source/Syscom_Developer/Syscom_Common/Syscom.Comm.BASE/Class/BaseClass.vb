'/*
'*****************************************************************************
'*
'*    Page/Class Name:  基底類別
'*              Title:	BaseClass
'*        Description:	基底類別，為所有類別提供基底內容
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Rich, Chuang
'*        Create Date:	2014-01-20
'*      Last Modifier:	Rich, Chuang
'*   Last Modify Date:	2014-01-20
'*
'*****************************************************************************
'*/

'Imports log4net

Public MustInherit Class BaseClass

    Private Shared RecordSwitch As Boolean = True       '是否紀錄 instance
    Private Shared SystemContent As New Hashtable       '用來存放所有 instance 數量的容器

    ''' <summary>
    ''' 若繼承該類別但允許其他呼叫程式直接 New 則不須實作單一實體作法
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub New()
        Try
            If RecordSwitch Then
                If SystemContent.ContainsKey(Me.GetType.Name) Then
                    SystemContent(Me.GetType.Name) += 1
                Else
                    SystemContent.Add(Me.GetType.Name, 1)
                End If
            End If
        Catch ex As Exception
            'log4net.LogManager.GetLogger("File.Syscom.Comm").Error(ex.Message, ex)
        End Try
    End Sub

    ''' <summary>
    ''' 該實體在垃圾回收前執行 instance 數量計算
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub Finalize()
        Try
            If RecordSwitch Then
                If SystemContent.ContainsKey(Me.GetType.Name) Then
                    If SystemContent(Me.GetType.Name) = 1 Then
                        SystemContent.Remove(Me.GetType.Name)
                    Else
                        SystemContent(Me.GetType.Name) -= 1
                    End If
                Else
                    Console.WriteLine(Me.GetType.Name & " Class Not Found")
                End If
            End If
        Catch ex As Exception
            'log4net.LogManager.GetLogger("File.Syscom.Comm").Error(ex.Message, ex)
        End Try
    End Sub

    ''' <summary>
    ''' 設定屬性存取
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Property switchRecord() As Boolean
        Get
            Return RecordSwitch
        End Get
        Set(ByVal value As Boolean)
            RecordSwitch = value
            SystemContent = New Hashtable
        End Set
    End Property

    ''' <summary>
    ''' (暫時)顯示在輸出裡面
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub showInstanceCount()
        Try
            'For Each item In SystemContent
            '    Console.WriteLine(item.Key & ":" & item.Value)
            'Next
        Catch ex As Exception
            'log4net.LogManager.GetLogger("File.Syscom.Comm").Error(ex.Message, ex)
        End Try
    End Sub

    ''' <summary>
    ''' (暫時)取得所有存放 instance 數量的 Hashtable
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getInstanceHashTable() As Hashtable
        Return SystemContent
    End Function

End Class
