﻿Imports System.IO
Imports System.Runtime.CompilerServices

Module DirectoryInfoExtension
    <Extension()>
    Function GetDifferentFileList(ByVal sourceDirectoryInfo As DirectoryInfo, ByVal targetDirectoryInfo As DirectoryInfo, Optional ByVal searchPattern As String = "*.*", Optional ByVal searchOption As SearchOption = SearchOption.TopDirectoryOnly) As FileInfo()
        If sourceDirectoryInfo Is Nothing Then
            Throw New ArgumentNullException("sourceDirectoryInfo")
        End If
        If targetDirectoryInfo Is Nothing Then
            Throw New ArgumentNullException("targetDirectoryInfo")
        End If
        If targetDirectoryInfo.FullName = sourceDirectoryInfo.FullName Then
            Return New FileInfo() {}
        End If
        Dim sourceFiles = sourceDirectoryInfo.GetFiles(searchPattern, searchOption)
        Dim destFiles = targetDirectoryInfo.GetFiles(searchPattern, searchOption)
        Dim intersectFiles = sourceFiles.Except(destFiles, New FileInfoEqualityComparer(sourceDirectoryInfo.FullName, targetDirectoryInfo.FullName))
        Return intersectFiles.ToArray
    End Function
End Module

Class FileInfoEqualityComparer
    Implements IEqualityComparer(Of FileInfo)

#Region "Var"
    Private _sourcePath As String
    Private _targetPath As String
    Private _replacePathList() As String
#End Region

#Region "Private Property"
    ''' <summary> 
    ''' Gets or sets the m_source path. 
    ''' </summary> 
    ''' <value>The m_source path.</value> 
    Private Property m_SourcePath() As String
        Get
            Return _sourcePath
        End Get
        Set(ByVal value As String)
            _sourcePath = value
        End Set
    End Property


    ''' <summary> 
    ''' Gets or sets the m_target path. 
    ''' </summary> 
    ''' <value>The m_target path.</value> 
    Private Property m_TargetPath() As String
        Get
            Return _targetPath
        End Get
        Set(ByVal value As String)
            _targetPath = value
        End Set
    End Property

    ''' <summary> 
    ''' Gets or sets the m_replace path list. 
    ''' </summary> 
    ''' <value>The m_replace path list.</value> 
    Private Property m_replacePathList() As String()
        Get
            Return _replacePathList
        End Get
        Set(ByVal value As String())
            _replacePathList = value
        End Set
    End Property
#End Region

#Region "Constructor"

    ''' <summary> 
    ''' Initializes a new instance of the <see cref="FileInfoEqualityComparer" /> class. 
    ''' </summary> 
    ''' <param name="sourcePath">The source path.</param> 
    ''' <param name="targetPath">The target path.</param> 
    Sub New(ByVal sourcePath As String, ByVal targetPath As String)
        With Me
            .m_SourcePath = sourcePath
            .m_TargetPath = targetPath
            InitReplacePathList()
        End With
    End Sub
#End Region

#Region "Private Method"
    ''' <summary> 
    ''' Inits the replace path list. 
    ''' </summary> 
    Private Sub InitReplacePathList()
        m_replacePathList = New String() {m_SourcePath, m_TargetPath}
        If m_SourcePath < m_TargetPath Then
            m_replacePathList = m_replacePathList.Reverse().ToArray
        End If
    End Sub

    ''' <summary> 
    ''' Gets the relatived path. 
    ''' </summary> 
    ''' <param name="path">The path.</param> 
    ''' <returns></returns> 
    Private Function GetRelativedPath(ByVal path As String) As String
        If String.IsNullOrEmpty(path) Then
            Throw New ArgumentNullException("path")
        End If

        For Each p In m_replacePathList
            path = path.Replace(p, "")
        Next
        Return path
    End Function
#End Region

    Public Function Equals1(ByVal x As System.IO.FileInfo, ByVal y As System.IO.FileInfo) As Boolean Implements System.Collections.Generic.IEqualityComparer(Of System.IO.FileInfo).Equals
        Return GetRelativedPath(x.FullName) = GetRelativedPath(y.FullName) AndAlso x.Length = y.Length AndAlso x.LastWriteTime = y.LastWriteTime
    End Function

    Public Function GetHashCode1(ByVal obj As System.IO.FileInfo) As Integer Implements System.Collections.Generic.IEqualityComparer(Of System.IO.FileInfo).GetHashCode
        Return (GetRelativedPath(obj.FullName) & obj.Length.ToString & obj.LastWriteTime.ToShortDateString).GetHashCode
    End Function
End Class