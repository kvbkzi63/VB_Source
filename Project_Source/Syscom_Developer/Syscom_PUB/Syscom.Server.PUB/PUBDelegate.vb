Imports Syscom.Comm.EXP

Public Class PUBDelegate

#Region "Singleton Design Pattern - Fully Thread Safety"

    ''' <summary>
    ''' ����~�������i��s�إߪ��ŧi
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub New()
    End Sub

    ''' <summary>
    ''' �ݩʨ��o���O����
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property getInstance() As PUBDelegate
        Get
            Threading.Thread.CurrentThread.CurrentCulture = New Globalization.CultureInfo("zh-TW", False)
            Return Nested.instance
        End Get
    End Property

    ''' <summary>
    ''' �_�����O�s��إߪ����O����
    ''' </summary>
    ''' <remarks></remarks>
    Private Class Nested
        Shared Sub New()
        End Sub

        Public Shared ReadOnly instance As New PUBDelegate()
    End Class

#End Region

 

End Class
