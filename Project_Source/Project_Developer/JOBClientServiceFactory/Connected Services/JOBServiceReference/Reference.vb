﻿'------------------------------------------------------------------------------
' <auto-generated>
'     這段程式碼是由工具產生的。
'     執行階段版本:4.0.30319.42000
'
'     對這個檔案所做的變更可能會造成錯誤的行為，而且如果重新產生程式碼，
'     變更將會遺失。
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On


Namespace JOBServiceReference
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ServiceModel.ServiceContractAttribute(ConfigurationName:="JOBServiceReference.IJOBService")>  _
    Public Interface IJOBService
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IJOBService/QueryJobProjectMaintainData", ReplyAction:="http://tempuri.org/IJOBService/QueryJobProjectMaintainDataResponse")>  _
        Function QueryJobProjectMaintainData(ByVal Project_ID As String, ByVal Project_Name As String, ByVal Start_Date As String, ByVal End_Date As String, ByVal Project_Manager As String) As System.Data.DataSet
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IJOBService/QueryJobProjectMaintainData", ReplyAction:="http://tempuri.org/IJOBService/QueryJobProjectMaintainDataResponse")>  _
        Function QueryJobProjectMaintainDataAsync(ByVal Project_ID As String, ByVal Project_Name As String, ByVal Start_Date As String, ByVal End_Date As String, ByVal Project_Manager As String) As System.Threading.Tasks.Task(Of System.Data.DataSet)
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IJOBService/PRJDoAction", ReplyAction:="http://tempuri.org/IJOBService/PRJDoActionResponse")>  _
        Function PRJDoAction(ByVal ds As System.Data.DataSet) As System.Data.DataSet
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IJOBService/PRJDoAction", ReplyAction:="http://tempuri.org/IJOBService/PRJDoActionResponse")>  _
        Function PRJDoActionAsync(ByVal ds As System.Data.DataSet) As System.Threading.Tasks.Task(Of System.Data.DataSet)
    End Interface
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")>  _
    Public Interface IJOBServiceChannel
        Inherits JOBServiceReference.IJOBService, System.ServiceModel.IClientChannel
    End Interface
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")>  _
    Partial Public Class JOBServiceClient
        Inherits System.ServiceModel.ClientBase(Of JOBServiceReference.IJOBService)
        Implements JOBServiceReference.IJOBService
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal endpointConfigurationName As String)
            MyBase.New(endpointConfigurationName)
        End Sub
        
        Public Sub New(ByVal endpointConfigurationName As String, ByVal remoteAddress As String)
            MyBase.New(endpointConfigurationName, remoteAddress)
        End Sub
        
        Public Sub New(ByVal endpointConfigurationName As String, ByVal remoteAddress As System.ServiceModel.EndpointAddress)
            MyBase.New(endpointConfigurationName, remoteAddress)
        End Sub
        
        Public Sub New(ByVal binding As System.ServiceModel.Channels.Binding, ByVal remoteAddress As System.ServiceModel.EndpointAddress)
            MyBase.New(binding, remoteAddress)
        End Sub
        
        Public Function QueryJobProjectMaintainData(ByVal Project_ID As String, ByVal Project_Name As String, ByVal Start_Date As String, ByVal End_Date As String, ByVal Project_Manager As String) As System.Data.DataSet Implements JOBServiceReference.IJOBService.QueryJobProjectMaintainData
            Return MyBase.Channel.QueryJobProjectMaintainData(Project_ID, Project_Name, Start_Date, End_Date, Project_Manager)
        End Function
        
        Public Function QueryJobProjectMaintainDataAsync(ByVal Project_ID As String, ByVal Project_Name As String, ByVal Start_Date As String, ByVal End_Date As String, ByVal Project_Manager As String) As System.Threading.Tasks.Task(Of System.Data.DataSet) Implements JOBServiceReference.IJOBService.QueryJobProjectMaintainDataAsync
            Return MyBase.Channel.QueryJobProjectMaintainDataAsync(Project_ID, Project_Name, Start_Date, End_Date, Project_Manager)
        End Function
        
        Public Function PRJDoAction(ByVal ds As System.Data.DataSet) As System.Data.DataSet Implements JOBServiceReference.IJOBService.PRJDoAction
            Return MyBase.Channel.PRJDoAction(ds)
        End Function
        
        Public Function PRJDoActionAsync(ByVal ds As System.Data.DataSet) As System.Threading.Tasks.Task(Of System.Data.DataSet) Implements JOBServiceReference.IJOBService.PRJDoActionAsync
            Return MyBase.Channel.PRJDoActionAsync(ds)
        End Function
    End Class
End Namespace
