Imports System.Collections.Generic
Imports System.Data
Imports System.IO
Imports System.IO.Compression
Imports System.Text
Imports System.Windows.Forms
Imports JOBClientServiceFactory
Imports Project.Client.JOB.ProjectClientBP
Imports Syscom.Comm.EXP
Imports Syscom.Comm.Utility
Imports System.Drawing
Imports Syscom.Client.CMM
Imports Syscom.Client.Servicefactory
Imports System.ServiceModel
Imports System.Collections
Imports Syscom.Comm.Utility.ScreenUtil


Public Class JobSAJobListConfirmUI
    Inherits JobSAJobListUI
    Dim WithEvents pvtReceiveMgr As EventManager = EventManager.getInstance


#Region "     內部函數"
#End Region



    ''' <summary>
    ''' 初始化畫面  
    ''' </summary>
    ''' <remarks>by Will.Lin on 2017-4-14</remarks>
    Public Overrides Sub initialDataSpecial()

        Try

            '設定不清除查詢控制項
            gblCleanConditionFlag = 1

            '不自動點選第一筆 
            gblClickFirstRowFlag = False

            '點選主旨會顯示完整的工作內容
            gblShowJobDetail = True

            '專案的下拉選單是否增加空白行
            'true 顯示空白
            'False 不顯示
            gblProjectCboEmptyRow = True
            '設定預設查詢天數
            gblDefaultQueryDays = -60

            '設定自動下載檔案
            gblOpenDownloadFile = True

            '預設指定路徑
            gblDefaultDownloadPath = System.Environment.SpecialFolder.Desktop & "/Temp/Download"

            '預設勾選SD 覆核
            ckb_IsSDConfirm.Checked = True

            '移除DB申請與Mail群組頁籤
            TabControl1.TabPages.Remove(tp_DBModified)
            TabControl1.TabPages.Remove(tp_MailSetting)

            'SendMail.UserName = "134201"
            'SendMail.PassWord = "134201"
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB990", ex)
        End Try

    End Sub


End Class