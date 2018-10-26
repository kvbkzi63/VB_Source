'=============================================================================
'========================== 凌群電腦 Syscom ==================================
'=============================================================================
'=======
'======= 程式名稱：給藥確認提示說明控制項
'=======
'======= 程式說明：1.給藥確認提示說明控制項
'=======
'======= 建立日期：2013-2-24
'=======
'======= 開發人員：Sean.Lin
'=============================================================================
'=============================================================================
'=============================================================================

Imports Syscom.Comm.Utility
Imports Syscom.Comm.Utility.DataSetUtil
Imports Syscom.Comm.Utility.CheckMethodUtil

Imports Syscom.Comm.Utility.StringUtil
Imports Syscom.Client.Servicefactory
Imports Syscom.Client.UCL.UCLScreenUtil
Imports System.Text
Imports Syscom.Comm.EXP
Imports Syscom.Client.CMM

Public Class UCLHintUC

#Region "     變數宣告 "

#Region "     使用的service宣告 "

    '定義使用的service介面
    Dim UCL As IUclServiceManager

#End Region

#Region "     UI Name 宣告 - For Sql 查詢的 Key 值　"

    '目前使用者的ID
    Private globalUIName As String = ""

#End Region

#End Region

#Region "     屬性設定 "



#End Region

#Region "     主要功能 "

#Region "     按鈕事件 "

#Region "     查詢 "

    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <returns >Boolean</returns>
    ''' <remarks>by Sean.Lin on 2013-2-24</remarks>
    Private Function QueryData() As Boolean

        Try

            Dim returnBoolean As Boolean = False

            Dim dataStringBuilder As New StringBuilder

            If Not globalUIName = "" Then

                '因原始於DDC 後提出至PcsUcl 所以 Service  在DDC
                Dim ds As DataSet = UCL.UclHintDataBOqueryData(globalUIName)

                If CheckHasValue(ds) Then

                    '組合提示說明
                    For i As Int32 = 0 To ds.Tables(0).Rows.Count - 1

                        dataStringBuilder.AppendLine("Q" & i + 1 & ".")
                        dataStringBuilder.AppendLine(ds.Tables(0).Rows(i).Item("Question_Data"))
                        dataStringBuilder.AppendLine("Ans.")
                        dataStringBuilder.AppendLine(ds.Tables(0).Rows(i).Item("Answer_Data"))
                        dataStringBuilder.AppendLine("")

                    Next

                Else

                    dataStringBuilder.AppendLine("無提示說明")

                End If


            Else

                dataStringBuilder.AppendLine("無 UI Name 請於作業的初始化加入 PcsUclHintUC.ShowMe(UIName) ")

            End If

            '顯示資料
            ShowQuestionDialog(dataStringBuilder, 800, 600)

            Return returnBoolean

        Catch ex As Exception

            Throw New CommonException("CMMCMMB911", ex)

            Return False

        End Try

    End Function

#End Region

#End Region

#Region "     外部參數傳遞 (提供其他UI呼叫、傳入參數) "

#Region "     初始化 - 顯示UI "

    ''' <summary>
    ''' 初始化 - 顯示UI
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2013-2-24</remarks>
    Public Sub ShownMe(ByVal UIName As String)

        Try

            '載入服務管理員
            LoadServiceManager()

            '設定 UI Name
            globalUIName = UIName


        Catch ex As Exception

            Throw New CommonException("CMMCMMB990", ex)

        End Try

    End Sub

#End Region

#End Region

#End Region

#Region "     內部功能 "

#Region "     初始化設定 "

#Region "     載入服務管理員 "

    ''' <summary>
    ''' 載入ServiceManager的Instance
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2013-2-24</remarks>
    Private Sub LoadServiceManager()

        Try

            UCL = UclServiceManager.getInstance()

        Catch ex As Exception

            Throw New CommonException("CMMCMMB991", ex)

        End Try

    End Sub

#End Region

#End Region

#Region "     按鍵鎖定、熱鍵功能設定 "

#Region "     主要功能的按鍵鎖定，避免重複Click造成資料或UI出問題 "

#Region "     查詢 鎖定功能 "

    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="Sender">按鈕物件</param>
    ''' <param name="e">事件</param>
    ''' <remarks>by Sean.Lin on 2013-2-24</remarks>
    Private Sub btn_Query_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Query.Click

        Try
            '鎖定螢幕
            Lock(Me)

            '清除左下方訊息欄
            MessageHandling.ClearInfoMsg()

            If (QueryData()) Then

                '左下方顯示 查詢 成功
                MessageHandling.ShowInfoMsg("CMMCMMB301", "查詢")

            End If

        Catch ex As Exception

            Throw New CommonException("CMMCMMB302", ex, New String() {"查詢 鎖定功能"})

        Finally

            '解除螢幕鎖定
            Unlock(Me)

        End Try

    End Sub

#End Region


#End Region

#Region "     HotKey設定 "

    ''' <summary>
    ''' HotKey設定
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>by Sean.Lin on 2013-2-24</remarks>
    Private Sub KeyDownBottuns(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        Try

            '鎖定螢幕
            Lock(Me)

            Select Case e.KeyCode


                Case Keys.F1

                    '查詢
                    If btn_Query.Enabled Then
                        btn_Query.PerformClick()
                    End If

                    'Case Keys.Enter
                    'Me.ProcessTabKey(True)

            End Select

        Catch ex As Exception

            Throw New CommonException("CMMCMMB302", ex, New String() {"HotKey設定"})
  
        Finally

            '解除螢幕鎖定
            Unlock(Me)

        End Try

    End Sub

#End Region

#End Region

#End Region

End Class

