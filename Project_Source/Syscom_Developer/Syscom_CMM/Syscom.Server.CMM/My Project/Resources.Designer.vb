﻿'------------------------------------------------------------------------------
' <auto-generated>
'     這段程式碼是由工具產生的。
'     執行階段版本:4.0.30319.34014
'
'     對這個檔案所做的變更可能會造成錯誤的行為，而且如果重新產生程式碼，
'     變更將會遺失。
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System

Namespace My.Resources
    
    '這個類別是自動產生的，是利用 StronglyTypedResourceBuilder
    '類別透過 ResGen 或 Visual Studio 這類工具。
    '若要加入或移除成員，請編輯您的 .ResX 檔，然後重新執行 ResGen
    '(利用 /str 選項)，或重建您的 VS 專案。
    '''<summary>
    '''  用於查詢當地語系化字串等的強類型資源類別。
    '''</summary>
    <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0"),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(),  _
     Global.Microsoft.VisualBasic.HideModuleNameAttribute()>  _
    Friend Module Resources
        
        Private resourceMan As Global.System.Resources.ResourceManager
        
        Private resourceCulture As Global.System.Globalization.CultureInfo
        
        '''<summary>
        '''  傳回這個類別使用的快取的 ResourceManager 執行個體。
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend ReadOnly Property ResourceManager() As Global.System.Resources.ResourceManager
            Get
                If Object.ReferenceEquals(resourceMan, Nothing) Then
                    Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("Syscom.Server.CMM.Resources", GetType(Resources).Assembly)
                    resourceMan = temp
                End If
                Return resourceMan
            End Get
        End Property
        
        '''<summary>
        '''  覆寫目前執行緒的 CurrentUICulture 屬性，對象是所有
        '''  使用這個強類型資源類別的資源查閱。
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend Property Culture() As Global.System.Globalization.CultureInfo
            Get
                Return resourceCulture
            End Get
            Set
                resourceCulture = value
            End Set
        End Property
        
        '''<summary>
        '''  查詢類似 &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot; ?&gt;
        '''&lt;log4net&gt;
        '''  &lt;appender name=&quot;ConsoleAppender&quot; type=&quot;log4net.Appender.ConsoleAppender&quot;&gt;
        '''    &lt;layout type=&quot;log4net.Layout.PatternLayout&quot;&gt;
        '''      &lt;conversionPattern value=&quot;%date [%thread] %-5level %logger [%ndc] - %message%newline&quot;/&gt;
        '''    &lt;/layout&gt;
        '''  &lt;/appender&gt;
        '''
        '''  &lt;appender name=&quot;SyscomServerLog&quot; type=&quot;log4net.Appender.RollingFileAppender&quot;&gt;
        '''    &lt;file value=&quot;C:\\Log\\syscom-server.log&quot; /&gt;
        '''    &lt;appendToFile value=&quot;true&quot; /&gt;
        '''    &lt;rollingStyle value=&quot;Composite&quot; /&gt;
        '''  [字串的其餘部分已遭截斷]&quot;; 的當地語系化字串。
        '''</summary>
        Friend ReadOnly Property log4net() As String
            Get
                Return ResourceManager.GetString("log4net", resourceCulture)
            End Get
        End Property
    End Module
End Namespace
