Imports System.IO
Imports System.Reflection
Imports Syscom.Comm.EXP
Imports System.Xml

Public Class XMLUtil

    ''' <summary>
    ''' 阻止外部直接進行新建立的宣告
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub New()
    End Sub

    ''' <summary>
    ''' 將傳入的 XML 轉換成 Dataset
    ''' </summary>
    ''' <param name="xmlStr"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function XmlToDataSet(ByVal xmlStr As String) As System.Data.DataSet
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try
            Dim ds As New System.Data.DataSet
            ds.ReadXml(System.Xml.XmlReader.Create(New StringReader(xmlStr)))
            Return ds
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function

    ''' <summary>
    ''' 將傳入的 Dataset 轉換成 XML
    ''' </summary>
    ''' <param name="ds"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function DataSetToXML(ByVal ds As DataSet) As String
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try
            Return EncodingUtil.uftTobig5(ds.GetXml).Replace("?", "::")
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function

#Region "       設定/取得 Xml Document 屬性"

    ''' <summary>
    ''' 設定 InnerText
    ''' </summary>
    ''' <param name="xNode"></param>
    ''' <param name="NodeName"></param>
    ''' <param name="AttributeName"></param>
    ''' <param name="Value"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function SetXmlInnerText(ByRef xNode As XmlNode, ByVal NodeName As String, _
                                           ByVal AttributeName As String, ByVal Value As String) As XmlNode
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try

            If AttributeName.Length > 0 Then
                Dim path As String = IIf(AttributeName.Length > 0, NodeName & "/" & AttributeName, NodeName)

                Dim node As XmlNode = xNode.SelectSingleNode("//" & path)
                If node IsNot Nothing Then
                    node.InnerText = Value
                End If

                If xNode.Item(NodeName).InnerText.Trim <> node.InnerText.Trim Then
                    xNode.Item(NodeName).InnerText = node.InnerText
                    'xNode.AppendChild(node)
                    'xNode.RemoveChild(node)
                End If
            Else
                If xNode.Item(NodeName) IsNot Nothing Then
                    xNode.Item(NodeName).InnerText = Value
                End If
            End If

            Return xNode
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function

    ''' <summary>
    ''' 取得 InnerText
    ''' </summary>
    ''' <param name="xNode"></param>
    ''' <param name="NodeName"></param>
    ''' <param name="AttributeName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetXmlInnerText(ByRef xNode As XmlNode, ByVal NodeName As String, _
                                           ByVal AttributeName As String) As String
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try

            If AttributeName.Length > 0 Then
                Dim path As String = IIf(AttributeName.Length > 0, NodeName & "/" & AttributeName, NodeName)

                Dim node As XmlNode = xNode.SelectSingleNode("//" & path)
                If node IsNot Nothing Then
                    Return node.InnerText.ToString.Trim
                End If
            Else
                If xNode.Item(NodeName) IsNot Nothing Then
                    Return xNode.Item(NodeName).InnerText.Trim
                End If
            End If

            Return ""

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function

#End Region

End Class
