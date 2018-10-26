'/*
'*****************************************************************************
'*
'*    Page/Class Name:  特殊屬性輸入主程式
'*              Title:	PUBLabIndication
'*        Description:	醫師開單時，系統依檢驗單、檢體及醫令等符合條件進行額外資訊輸入。
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Alan
'*        Create Date:	2016-09-06
'*      Last Modifier:	Brian
'*   Last Modify Date:	2016-09-06
'*
'*****************************************************************************
'*/
Imports System.ServiceModel

Imports Syscom.Comm.EXP
Imports Syscom.Comm.Utility
Imports Syscom.Comm.Utility.StringUtil
Imports Syscom.Comm.Utility.CheckMethodUtil

Imports Syscom.Client.CMM
Imports Syscom.Client.CMM.MessageHandling
Imports Syscom.Client.Servicefactory
Imports Syscom.Client.UCL
Imports Syscom.Client.UCL.UCLScreenUtil
Public Class PUBLabIndication
    Inherits BaseFormUI

#Region "     變數宣告 "
    Dim gblIsCheckSheet As String = ""      '是否需檢核表單特殊屬性
    Dim gblSheetCode As String = ""         '表單代碼
    Dim gblSpecimenCode As String = ""      '檢體代碼
    Dim gblOrderCode As String = ""         '醫令代碼
    Dim gblOrderName As String = ""         '醫令名稱
    Dim gblTqty As Integer = 0              '醫令總量
    Dim gblIdno As String = ""              '病患身分證號
    Dim gblOrderDate As String = ""         '醫令開單日期
    Public gblXmlData As String = ""        '特殊屬性xml字串
    Public gblArrayData() As String         '特殊屬性Array字串


#Region "     使用者宣告　"

#End Region

#Region "     使用的service宣告 "

    '定義使用的service介面
    Dim PUB As IPubServiceManager

#End Region

#End Region

    Sub New()

        ' 此為設計工具所需的呼叫。
        InitializeComponent()

        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。

    End Sub

    Sub New(ByVal inIsCheckSheet As String, ByVal inSheet_Code As String, ByVal inSpecimen_Code As String, ByVal inOrder_Code As String, ByVal inOrder_Name As String, ByVal inXmlData As String, Optional ByVal inTqty As Integer = 0, Optional ByVal inIdno As String = "", Optional ByVal inOrderDate As String = "")
        gblSheetCode = inSheet_Code
        gblSpecimenCode = inSpecimen_Code
        gblOrderCode = inOrder_Code
        gblOrderName = inOrder_Name
        gblTqty = inTqty
        gblIdno = inIdno
        gblOrderDate = inOrderDate

        Select Case inSheet_Code

            Case "LA", "LV" '細菌檢驗單

                Select Case inSpecimen_Code '檢體代碼

                    Case "13" 'Sputum
                        If inIsCheckSheet = "Y" Then
                            Dim pvtForm As New PUBLabIndication02
                            pvtForm = New PUBLabIndication02()
                            pvtForm.gblXmlData = inXmlData
                            pvtForm.ShowDialog()
                            'gblXmlData = pvtForm.gblXmlData
                            gblArrayData = pvtForm.gblArrayData
                            'MessageBox.Show(pvtForm.gblXmlData)
                        End If

                    Case "21" 'Urine
                        If inIsCheckSheet = "Y" Then
                            Dim pvtForm As New PUBLabIndication01
                            pvtForm = New PUBLabIndication01()
                            pvtForm.gblXmlData = inXmlData
                            pvtForm.ShowDialog()
                            'gblXmlData = pvtForm.gblXmlData
                            gblArrayData = pvtForm.gblArrayData
                            'MessageBox.Show(pvtForm.gblXmlData)
                        End If


                    Case "51" 'Vaginal discharge
                        If inIsCheckSheet = "N" Then
                            If inOrder_Code = "130071" Then
                                Dim pvtForm As New PUBLabIndication05
                                pvtForm = New PUBLabIndication05()
                                pvtForm.gblXmlData = inXmlData
                                pvtForm.ShowDialog()
                                'gblXmlData = pvtForm.gblXmlData
                                gblArrayData = pvtForm.gblArrayData
                                'MessageBox.Show(pvtForm.gblXmlData)
                            End If
                        End If


                    Case "47" 'Stain
                        If inIsCheckSheet = "Y" Then
                            Dim pvtForm As New PUBLabIndication06
                            pvtForm = New PUBLabIndication06()
                            pvtForm.gblXmlData = inXmlData
                            pvtForm.gblOrderCode = inOrder_Code
                            pvtForm.gblOrderName = inOrder_Name
                            pvtForm.ShowDialog()
                            'gblXmlData = pvtForm.gblXmlData
                            gblArrayData = pvtForm.gblArrayData
                            'MessageBox.Show(pvtForm.gblXmlData)
                        End If


                    Case "99" 'Other
                        If inIsCheckSheet = "Y" Then
                            Dim pvtForm As New PUBLabIndication03
                            pvtForm = New PUBLabIndication03()
                            pvtForm.ShowDialog()
                            'gblXmlData = pvtForm.gblXmlData
                            gblArrayData = pvtForm.gblArrayData
                            'MessageBox.Show(pvtForm.gblXmlData)
                        End If

                End Select

                '血液培養(13016)需輸入部位
                If inOrder_Code = "13016" Then
                    Dim pvtForm As New PUBLabIndication09
                    pvtForm = New PUBLabIndication09()
                    pvtForm.gblXmlData = inXmlData
                    pvtForm.gblOrderCode = inOrder_Code
                    pvtForm.gblOrderName = inOrder_Name
                    pvtForm.gblTqty = inTqty
                    pvtForm.ShowDialog()
                    'gblXmlData = pvtForm.gblXmlData
                    gblArrayData = pvtForm.gblArrayData
                    'MessageBox.Show(pvtForm.gblXmlData)
                End If


            Case "LD" '建生特異性過敏原檢驗單
                If inIsCheckSheet = "Y" Then
                    If inOrder_Code = "30022" Then
                        Dim pvtForm As New PUBLabIndication04
                        pvtForm = New PUBLabIndication04()
                        pvtForm.gblXmlData = inXmlData
                        pvtForm.ShowDialog()
                        'gblXmlData = pvtForm.gblXmlData
                        gblArrayData = pvtForm.gblArrayData
                        'MessageBox.Show(pvtForm.gblXmlData)
                    End If
                End If


            Case "LC" '病理細胞申請單
                If inIsCheckSheet = "Y" Then
                    Dim pvtForm As New PUBLabIndication07
                    pvtForm = New PUBLabIndication07()
                    pvtForm.gblXmlData = inXmlData
                    pvtForm.ShowDialog()
                    'gblXmlData = pvtForm.gblXmlData
                    gblArrayData = pvtForm.gblArrayData
                    'MessageBox.Show(pvtForm.gblXmlData)
                End If


            Case "LP" '病理切片申請單
                If inIsCheckSheet = "Y" Then

                    'If gblIdno <> "" Then

                    '    Dim PUB As IPubServiceManager = PubServiceManager.getInstance
                    '    '判斷呼叫該病理切片或大腸鏡特殊屬性
                    '    Dim inDsData As New DataSet
                    '    inDsData = PUB.PUBLabIndication10QureyPUBLabIndication10(gblIdno, gblOrderDate)

                    '    If inDsData IsNot Nothing AndAlso inDsData.Tables IsNot Nothing AndAlso inDsData.Tables(0).Rows.Count > 0 Then
                    '        Dim pvtForm As New PUBLabIndication10
                    '        pvtForm = New PUBLabIndication10(inDsData)
                    '        pvtForm.gblXmlData = inXmlData
                    '        pvtForm.ShowDialog()
                    '        'gblXmlData = pvtForm.gblXmlData
                    '        gblArrayData = pvtForm.gblArrayData
                    '        'MessageBox.Show(pvtForm.gblXmlData)
                    '    Else
                    '        Dim pvtForm As New PUBLabIndication08
                    '        pvtForm = New PUBLabIndication08()
                    '        pvtForm.gblXmlData = inXmlData
                    '        pvtForm.ShowDialog()
                    '        'gblXmlData = pvtForm.gblXmlData
                    '        gblArrayData = pvtForm.gblArrayData
                    '        'MessageBox.Show(pvtForm.gblXmlData)
                    '    End If

                    'Else
                    '    Dim pvtForm As New PUBLabIndication08
                    '    pvtForm = New PUBLabIndication08()
                    '    pvtForm.gblXmlData = inXmlData
                    '    pvtForm.ShowDialog()
                    '    'gblXmlData = pvtForm.gblXmlData
                    '    gblArrayData = pvtForm.gblArrayData
                    '    'MessageBox.Show(pvtForm.gblXmlData)

                    'End If

                    Dim pvtForm As New PUBLabIndication08
                    pvtForm = New PUBLabIndication08()
                    pvtForm.gblXmlData = inXmlData
                    pvtForm.ShowDialog()
                    'gblXmlData = pvtForm.gblXmlData
                    gblArrayData = pvtForm.gblArrayData
                    'MessageBox.Show(pvtForm.gblXmlData)

                End If

            Case Else

        End Select

    End Sub

    Sub New(ByVal inDs As DataSet)

        If inDs IsNot Nothing AndAlso inDs.Tables IsNot Nothing AndAlso inDs.Tables(0).Rows.Count > 0 Then

            For i = 0 To inDs.Tables(0).Rows.Count - 1

                gblSheetCode = inDs.Tables(0).Rows(i).Item("Sheet_Code").ToString.Trim
                gblSpecimenCode = inDs.Tables(0).Rows(i).Item("Specimen_Code").ToString.Trim
                gblOrderCode = inDs.Tables(0).Rows(i).Item("Order_Code").ToString.Trim
                gblOrderName = inDs.Tables(0).Rows(i).Item("Order_Name").ToString.Trim
                gblXmlData = inDs.Tables(0).Rows(i).Item("Indication").ToString.Trim

                Select Case gblSheetCode

                    Case "LA", "LV" '細菌檢驗單

                        Select Case gblSpecimenCode '檢體代碼

                            Case "13" 'Sputum
                                Dim pvtForm As New PUBLabIndication02
                                pvtForm = New PUBLabIndication02()
                                pvtForm.gblXmlData = gblXmlData
                                pvtForm.ShowDialog()
                                gblXmlData = pvtForm.gblXmlData
                                'MessageBox.Show(pvtForm.gblXmlData)

                            Case "21" 'Urine
                                Dim pvtForm As New PUBLabIndication01
                                pvtForm = New PUBLabIndication01()
                                pvtForm.gblXmlData = gblXmlData
                                pvtForm.ShowDialog()
                                gblXmlData = pvtForm.gblXmlData
                                'MessageBox.Show(pvtForm.gblXmlData)

                            Case "51" 'Vaginal discharge
                                If gblOrderCode = "130071" Then
                                    Dim pvtForm As New PUBLabIndication05
                                    pvtForm = New PUBLabIndication05()
                                    pvtForm.gblXmlData = gblXmlData
                                    pvtForm.ShowDialog()
                                    gblXmlData = pvtForm.gblXmlData
                                    'MessageBox.Show(pvtForm.gblXmlData)
                                End If

                            Case "47" 'Stain
                                Dim pvtForm As New PUBLabIndication06
                                pvtForm = New PUBLabIndication06()
                                pvtForm.gblXmlData = gblXmlData
                                pvtForm.gblOrderCode = gblOrderCode
                                pvtForm.ShowDialog()
                                gblXmlData = pvtForm.gblXmlData
                                'MessageBox.Show(pvtForm.gblXmlData)

                            Case "99" 'Other
                                Dim pvtForm As New PUBLabIndication03
                                pvtForm = New PUBLabIndication03()
                                pvtForm.ShowDialog()
                                gblXmlData = pvtForm.gblXmlData
                                'MessageBox.Show(pvtForm.gblXmlData)




                        End Select

                    Case "LD" '建生特異性過敏原檢驗單
                        Dim pvtForm As New PUBLabIndication04
                        pvtForm = New PUBLabIndication04()
                        pvtForm.gblXmlData = gblXmlData
                        pvtForm.ShowDialog()
                        gblXmlData = pvtForm.gblXmlData
                        'MessageBox.Show(pvtForm.gblXmlData)

                    Case "LC" '病理細胞申請單
                        Dim pvtForm As New PUBLabIndication07
                        pvtForm = New PUBLabIndication07()
                        pvtForm.gblXmlData = gblXmlData
                        pvtForm.ShowDialog()
                        gblXmlData = pvtForm.gblXmlData
                        'MessageBox.Show(pvtForm.gblXmlData)

                    Case "LP" '病理切片申請單
                        Dim pvtForm As New PUBLabIndication08
                        pvtForm = New PUBLabIndication08()
                        pvtForm.gblXmlData = gblXmlData
                        pvtForm.ShowDialog()
                        gblXmlData = pvtForm.gblXmlData
                        'MessageBox.Show(pvtForm.gblXmlData)

                    Case Else

                End Select


            Next

        End If

    End Sub

End Class