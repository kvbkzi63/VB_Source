Imports System.Reflection

'/*
'*****************************************************************************
'*
'*    Page/Class Name:  記錄 醫院 的設定值
'*              Title:	HospConfigUtil
'*        Description:	記錄 醫院 的設定值，以處理不同醫院的系統設定
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Rich
'*        Create Date:	2015-01-09
'*      Last Modifier:	
'*   Last Modify Date:	
'*
'*****************************************************************************
'*/

Public Class HospConfigUtil

#Region "醫院相關資料"
    Private Shared _AppName As String
    Private Shared _hospCode As String
    Private Shared _name As String
    Private Shared _engName As String
    Private Shared _shortName As String
    Private Shared _engShortName As String
    Private Shared _tel As String
    Private Shared _engTel As String
    Private Shared _fax As String
    Private Shared _engFax As String
    Private Shared _voiceTel As String
    Private Shared _engVoiceTel As String
    Private Shared _addr As String
    Private Shared _engAddr As String
    Private Shared _principalName As String
    Private Shared _engPrincipalName As String
    Private Shared _principalEmail As String
    Private Shared _engPrincipalEmail As String
    Private Shared _url As String
    Private Shared _engUrl As String
    Private Shared _cityName As String
    Private Shared _areaName As String
    Private Shared _streetName As String
    Private Shared _hospLevel As String
    Private Shared _unifiedBussinessNo As String
    Private Shared _licenseNo As String
    Private Shared _dentalHospLevel As String
    Private Shared _branchCode As String

    ''' <summary>
    ''' 參數列表
    ''' </summary>
    ''' <remarks></remarks>
    Private Shared _dictParameter As Dictionary(Of String, String)

#End Region

#Region "程式中的外部連結"
    Private Shared _ForgetPwd1Web As String
    Private Shared _ForgetPwd2Web As String
    Private Shared _HisProblemWeb As String
    Private Shared _HemProblemWeb As String
    Private Shared _CheckConnectionAP As String
    Private Shared _CancerCenterDownloadWeb As String
    Private Shared _CancerCenterAJCCWeb As String
    Private Shared _CancerCenterLoginWeb As String
    Private Shared _WebSiteSSOWeb As String
    Private Shared _ReportServer101Web As String
    Private Shared _EmrOutcomeWeb As String
    Private Shared _G3PACSWeb As String
    Private Shared _PkgPACSWeb As String
    Private Shared _StarPACSWeb As String
    Private Shared _WebRISWeb As String
    Private Shared _WebViewer2Web As String
    Private Shared _WebViewerWeb As String
    Private Shared _EmrLoginWeb As String
    Private Shared _LeadTools160Web As String
    Private Shared _LeadTools150Web As String
    Private Shared _ShowImageWeb As String
    Private Shared _StarPACSLoginWeb As String
    Private Shared _OhmReportPrintWeb As String
    Private Shared _LoginNhiDoctorWeb As String
    Private Shared _HIVConsentWeb As String
    Private Shared _RoomIodineWeb As String
    Private Shared _Prescription107Web As String
    Private Shared _EmrCallReplyWeb As String
    Private Shared _AdrOrder211Web As String
    Private Shared _KidHealthCareWeb As String
    Private Shared _DissociationWeb As String
    Private Shared _PatientLifeChartWeb As String
    Private Shared _CancelCenterPlanWeb As String
    Private Shared _Operation212Web As String
    Private Shared _CheckInRv211Web As String
    Private Shared _PatientAllergyExplainWeb As String
    Private Shared _SendPack212Web As String
    Private Shared _NhiMedicalQueryWeb As String
    Private Shared _OpRoomQueryWeb As String
    Private Shared _DoctorScheduleWeb As String
    Private Shared _TainanHospitalTransferWeb As String
    Private Shared _AdrOrder21Web As String
    Private Shared _Prescription135Web As String
    Private Shared _Looks135Web As String
    Private Shared _Looks107Web As String
    Private Shared _Icd9cmWeb As String
    Private Shared _OphAutoPlayMusicWeb As String
    Private Shared _ReportServerIPDWeb As String
    Private Shared _cdrWeb As String

#End Region

#Region "報表"

    'TN
    Private Shared _EPHRPT0090301_1 As String
    Private Shared _EPHRPT0090301_2 As String
    Private Shared _HEMRPT0010101_1 As String
    Private Shared _HEMRPT0010101_2 As String
    Private Shared _HEMRPT0010101_3 As String
    Private Shared _HEMRPT0010101_4 As String
    Private Shared _HEMRPT0010101_5 As String
    Private Shared _HEMRPT0010101_6 As String
    Private Shared _HEMRPT0010101_7 As String
    Private Shared _HEMRPT0010101_8 As String
    Private Shared _HEMRPT0010101_9 As String
    Private Shared _HEMRPT0010101_10 As String
    Private Shared _HEMRPT0010101_11 As String
    Private Shared _HEMRPT0010101_12 As String
    Private Shared _HEMRPT0010101_13 As String
    Private Shared _HEMRPT0190101_1 As String
    Private Shared _CNCRPT04102A_1 As String
    Private Shared _INFRPT1320101_1 As String
    Private Shared _OMORPT1040101_1 As String
    Private Shared _OMORPT1040101_2 As String
    Private Shared _OMORPT1040101_3 As String
    Private Shared _OMORPT1040101_4 As String
    Private Shared _OMORPTHIVCharge_1 As String
    Private Shared _OMORPTHIVCharge_2 As String
    Private Shared _OMORPTSmokeBetelExposure_1 As String
    Private Shared _OMORPTSmokeBetelExposure_2 As String
    Private Shared _PIPBcagConsent_1 As String
    Private Shared _OPHRPT0001_1 As String
    Private Shared _OMORPT1230101_1 As String
    Private Shared _OMORPT1230101_2 As String
    Private Shared _OMORPT1230101_3 As String '2013-03-21 by PauseChen : 4.文字說明修正
    Private Shared _OMORPT92501_1 As String
    Private Shared _OMORPT92501_2 As String
    Private Shared _OMORPT92501_3 As String
    Private Shared _OMORPT92501_4 As String
    Private Shared _OMORPT91601_1 As String
    Private Shared _OMORPT91601_2 As String
    Private Shared _OMORPT91701_1 As String
    Private Shared _OMORPT91701_2 As String
    'LA
    Private Shared _CAPRPT004_1 As String
    Private Shared _CAPRPT004_2 As String
    Private Shared _CAPRPT005_1 As String
    Private Shared _CAPRPT008_1 As String
    Private Shared _CAPRPT904_1 As String
    Private Shared _CAPRPT915_1 As String
    Private Shared _CAPRPT916_1 As String
    Private Shared _CAPRPT917_1 As String
    Private Shared _CAPRPT918_1 As String
    Private Shared _CAPRPT919_1 As String
    Private Shared _CAPRPT920_1 As String
    Private Shared _DEPRPT0110301_E2_1 As String
    Private Shared _EMDRPT5012201_1 As String
    Private Shared _EMDRPTORReturn_1 As String
    Private Shared _EMORPT1130101_1 As String
    Private Shared _EMORPT1130102_1 As String
    Private Shared _EMORPT1130301_1 As String
    Private Shared _EMORPT1240101_1 As String
    Private Shared _EMORPT1240101_2 As String
    Private Shared _EMORPT4011201_1 As String
    Private Shared _EMORPT4011801_1 As String
    Private Shared _EMORPT4011801_2 As String
    Private Shared _HDSRPT0020102_1 As String()
    Private Shared _HEMRPT9970101_1 As String
    Private Shared _HEMRPT9980101_1 As String
    Private Shared _HEMRPT9990101_1 As String
    Private Shared _HOCRPT0004113_1 As String
    Private Shared _CNCRPT04102B_1 As String
    Private Shared _CNCRPT04103_1 As String
    Private Shared _DISRPT0080101_1 As String
    Private Shared _IhdRPT9100101_1 As String
    Private Shared _IhdRPT9100101_2 As String
    Private Shared _MMRRPT2010101_1 As String
    Private Shared _OHDRPT4020101_1 As String
    Private Shared _OMORPT1070101_1 As String
    Private Shared _OMORPT1080101_1 As String
    Private Shared _OMORPT1080101_2 As String
    Private Shared _OMORPT1140101_1 As String
    Private Shared _OMORPT1160101_1 As String
    Private Shared _OMORPT1180101_1 As String
    Private Shared _OMORPT1220101_1 As String
    Private Shared _OMORPT1270101_1 As String
    Private Shared _OMORPT1270101_2 As String
    Private Shared _OMORPT1470101_1 As String
    Private Shared _PIPRPT50105002_1 As String
    Private Shared _REFRPT0050201_1 As String
    Private Shared _REGRPT0130301_1 As String
    Private Shared _REGRPT0130301_2 As String
    Private Shared _REGRPT0130301_3 As String
    Private Shared _REGRPT0130301_qrpath As String
    Private Shared _REGRPT0130301_qrfname As String
    Private Shared _INPRPT241002_1 As String
    Private Shared _InpRPT2410131_1 As String
    Private Shared _InpRPT2410131_2 As String
    Private Shared _InpRPT2410131_3 As String
    Private Shared _Iph009120101_1 As String
    Private Shared _STARPT0910301_1 As String

#End Region

    ''' <summary>
    ''' 列舉醫院清單設定
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum hospConfigList
        none             '預設
        Tw_Kmuh          '高雄聯合醫院
        Tw_Taci          '衛福部臺中醫院
        Tw_Tnhosp        '衛福部台南醫院
        Tw_KLUHOSP       '衛福部基隆醫院
        Tw_PUZIHOSP      '衛福部朴子醫院
        Tw_SINYINGHOSP   '衛福部新營醫院
        Tw_FYHOSP        '衛福部豐原醫院
        Tw_HWAHOSP       '衛福部花蓮醫院
        Tw_YLHOSP        '衛福部玉里醫院
        Tw_CHESTHOSP     '衛福部胸腔醫院
        Tw_HENGTHOSP     '衛福部恆春旅遊醫院
        Tw_PEHHOSP       '衛福部澎湖醫院
        Tw_TAOYUANPC     '衛福部桃園療養院
        Tw_CWHHOSP       '衛福部彰化醫院
        Tw_CHISANHOSP    '衛福部旗山醫院
        Tw_KMNHOSP       '衛福部金門醫院
        Tw_PCHHOSP       '衛福部屏東醫院
        Tw_TTTHOSP       '衛福部台東醫院
        Tw_NTOHOSP       '衛福部南投醫院
        Tw_TSAOTUNPC     '衛福部草屯療養院
        Tw_BALIPC        '衛福部八里療養院
        Tw_CNPC          '衛福部嘉南療養院
        Tw_LSLPC         '衛福部樂生療養院
        Tw_MILHOSP       '衛福部苗栗醫院
        Tw_TPEHOSP       '衛福部臺北醫院
    End Enum

    '當前的院區設定
    Private Shared _hospConfig As hospConfigList = hospConfigList.none

    Private Shared _hospConfigUtil As New HospConfigUtil

    ''' <summary>
    ''' 阻止外部直接宣告
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub New()
        initialHospConfig()
    End Sub

#Region " 屬性 "

#Region " 取得所設定之醫院 "

    ''' <summary>
    ''' 取得所設定之醫院
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property HospConfig As hospConfigList
        Get
            Return _hospConfig
        End Get
    End Property

#End Region

#Region " 取得所設定之 CDR 病歷網址 "

    ''' <summary>
    ''' 取得所設定之 CDR 病歷網址
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property CDRWeb As String
        Get
            Return _cdrWeb
        End Get
    End Property

#End Region

#End Region

#Region " 根據醫事機構代碼設定醫院代碼 "

    ''' <summary>
    ''' 根據醫事機構代碼設定醫院代碼
    ''' </summary>
    ''' <param name="HospOrganizationCode" >醫事機構代碼</param>
    ''' <remarks>by Sean.Lin on 2016-04-01</remarks>
    Public Shared Sub SetHospconfigByHospCode(ByVal HospOrganizationCode As String)

        Try
            Select Case HospOrganizationCode

                '基隆醫院
                Case "0111070010"

                    _hospConfig = hospConfigList.Tw_KLUHOSP

                    '台北醫院
                Case "0131060029"

                    _hospConfig = hospConfigList.Tw_TPEHOSP

                    '台中醫院
                Case "0117030010"

                    _hospConfig = hospConfigList.Tw_Taci

                    '台南醫院
                Case "0121050011"

                    _hospConfig = hospConfigList.Tw_Tnhosp

                    '高雄市立聯合醫院
                Case "0102020011"

                    _hospConfig = hospConfigList.Tw_Kmuh

                Case Else

                    Throw New Exception("此醫療組織的代碼不存在!")

            End Select

            initialHospConfig()

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

#End Region

#Region " 根據醫事機構代碼 檢查 醫院代碼 "

    ''' <summary>
    ''' 根據醫事機構代碼 檢查 醫院代碼
    ''' True: 正確 ， False: 錯誤
    ''' </summary>
    ''' <param name="HospOrganizationCode" >醫事機構代碼</param>
    ''' <remarks>by Sean.Lin on 2016-04-01</remarks>
    Public Shared Function CheckHospconfigByHospCode(ByVal HospOrganizationCode As String) As Boolean

        Try
            Select Case HospOrganizationCode

                '基隆醫院
                Case "0111070010"

                    Return IIf(_hospConfig = hospConfigList.Tw_KLUHOSP, True, False)

                    '台北醫院
                Case "0131060029"

                    Return IIf(_hospConfig = hospConfigList.Tw_TPEHOSP, True, False)


                    '台中醫院
                Case "0117030010"

                    Return IIf(_hospConfig = hospConfigList.Tw_Taci, True, False)


                    '台南醫院
                Case "0121050011"

                    Return IIf(_hospConfig = hospConfigList.Tw_Tnhosp, True, False)

                    '高雄市立聯合醫院
                Case "0102020011"

                    Return IIf(_hospConfig = hospConfigList.Tw_Kmuh, True, False)

                Case Else

                    Throw New Exception("此醫療組織的代碼不存在!")

            End Select


        Catch ex As Exception
            Throw ex
        End Try

    End Function

#End Region

#Region "  始化醫院相關設定"

    ''' <summary>
    ''' 初始化醫院相關設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Shared Sub initialHospConfig()
        Try
            Select Case _hospConfig
                Case hospConfigList.Tw_Kmuh
                    '高市聯醫的設定
                    _AppName = "醫療資訊系統"
                    _hospCode = "0102020011"
                    _name = "高雄市立聯合醫院"
                    _engName = "Kaohsiung Municipal United Hospital"
                    _shortName = "高市聯醫"
                    _engShortName = ""
                    _tel = "07-555-2565 "
                    _engTel = "07-555-2565 "
                    _fax = "07-5553984"
                    _engFax = "07-5553984"
                    _voiceTel = "07-5533552"
                    _engVoiceTel = "07-5533552"
                    _addr = "高雄市鼓山區中華一路976號"
                    _engAddr = "No.976, Zhonghua 1st Rd., Gushan Dist., Kaohsiung City 804, Taiwan (R.O.C.)"
                    _principalName = ""
                    _engPrincipalName = ""
                    _principalEmail = ""
                    _engPrincipalEmail = ""
                    _url = "www.kmuh.gov.tw"
                    _engUrl = "www.kmuh.gov.tw"
                    _cityName = ""
                    _areaName = ""
                    _streetName = ""
                    _hospLevel = "請建檔" '"A"
                    _unifiedBussinessNo = "請建檔" '"06476734"
                    _licenseNo = ""
                    _dentalHospLevel = "請建檔" '"E"
                    _branchCode = ""

                    ''程式中的外部連結
                    '_ForgetPwd1Web = "請建檔" '"http://192.168.11.66/iisadmpwd"
                    '_ForgetPwd2Web = "請建檔" '"http://hisweb.hosp.ncku/iisadmpwd/"
                    '_HisProblemWeb = "請建檔" '"http://192.168.64.200/webpage/his/index.asp"
                    '_HemProblemWeb = "請建檔" '"http://192.168.64.200/webpage/hexam/index.asp"
                    '_CheckConnectionAP = "請建檔" '"http://hisweb.hosp.ncku/HISService/opd/nckuhisweb/ArmService.svc"
                    '_CancerCenterDownloadWeb = "請建檔" '"http://192.168.64.30/NckuhCCWs/UI_Cancer/Manage/Download_002.aspx?type=5"
                    '_CancerCenterAJCCWeb = "請建檔" '"http://192.168.64.30/cancercentertools/UI_AJCC/AJCC.aspx"
                    '_CancerCenterLoginWeb = "請建檔" '"http://192.168.64.30/CEMR/LoginPage.aspx"
                    '_WebSiteSSOWeb = "請建檔" '"http://hisweb.hosp.ncku/WebSiteSSO"
                    '_ReportServer101Web = "請建檔" '"http://192.168.11.101/reportserver"
                    '_EmrOutcomeWeb = "請建檔" '"http://hisweb.hosp.ncku/HISService/lis/EMR/EMROutcome.aspx"
                    '_G3PACSWeb = "請建檔" '"http://hisweb.hosp.ncku/WebSiteSSO/G3PACS.aspx"
                    '_PkgPACSWeb = "請建檔" '"http://172.17.2.2/pkg_pacs/external_interface.aspx"
                    '_StarPACSWeb = "請建檔" '"http://172.16.1.15/interface/viewexam.asp"
                    '_WebRISWeb = "請建檔" '"http://172.17.2.13:8080/WEBRIS/outlogin/outlogin.do"
                    '_WebViewer2Web = "請建檔" '"http://192.168.11.100/webviewer2/WebViewerMain.aspx"
                    '_WebViewerWeb = "請建檔" '"http://192.168.11.100/webviewer/WebViewerMain.aspx"
                    '_EmrLoginWeb = "請建檔" '"http://hisweb.hosp.ncku/Emrquery/autologin.aspx"
                    '_LeadTools160Web = "請建檔" '"http://www.leadtools.com/rd/v160/LEADTOOLSPDFRuntime.exe"
                    '_LeadTools150Web = "請建檔" '"http://www.leadtools.com/rd/v150/LEADTOOLSPDFRuntime.exe"
                    '_ShowImageWeb = "請建檔" '"http://hisweb.hosp.ncku/imgURL/showImage.aspx"
                    '_StarPACSLoginWeb = "請建檔" '"http://172.16.1.15/LoginMode0.asp"
                    '_OhmReportPrintWeb = "請建檔" '"http://hisweb.hosp.ncku/HISService/OPD/nckuHisWeb/Aspx/OHMReportPrint.aspx"
                    '_LoginNhiDoctorWeb = "請建檔" '"http://140.116.59.75/nhi/NhiDoctor/loginNhiDoctor.jsp"
                    '_HIVConsentWeb = "請建檔" '"http://140.116.59.75/nhi/Consent/Consent_s1.jsp"
                    '_RoomIodineWeb = "請建檔" '"http://192.168.11.11/hospitalization/inpatient/bed_schedule/room_iodine131.jsp"
                    '_Prescription107Web = "請建檔" '"http://172.19.14.107/newhomepage/massrefer_prescription.asp"
                    '_EmrCallReplyWeb = "請建檔" '"http://hisweb.hosp.ncku/HISService/LIS/EMR/CallReply.aspx"
                    '_AdrOrder211Web = "請建檔" '"http://192.168.11.211/hospitalization/pharmacy/adr_order.jsp"
                    '_KidHealthCareWeb = "請建檔" '"http://192.168.11.98:8080/kid/index_r.jsp"
                    '_DissociationWeb = "請建檔" '"http://192.168.11.98:8080/kid/dissociation.jsp"
                    '_PatientLifeChartWeb = "請建檔" '"http://192.168.64.30/WHOQOL/PatientLifeChart.aspx"
                    '_CancelCenterPlanWeb = "請建檔" '"http://192.168.64.30/Admin/CancerCenter.aspx"
                    '_Operation212Web = "請建檔" '"http://192.168.11.212/ifx/Operation.jsp"
                    '_CheckInRv211Web = "請建檔" '"http://192.168.11.211/ifx/CheckInRv.jsp"
                    '_PatientAllergyExplainWeb = "請建檔" '"http://172.19.14.107/NewHomePage/PUBPatientAllergyNew/explain.html"
                    '_SendPack212Web = "請建檔" '"http://192.168.11.212/SendPack.jsp"
                    '_NhiMedicalQueryWeb = "請建檔" '"http://www.nhi.gov.tw/Query/query3.aspx?menu=20&menu_id=712&WD_ID=828"
                    '_OpRoomQueryWeb = "請建檔" '"http://192.168.11.21/ifx/TransHttp.jsp?Sys=OPD&Target=OPReserv&Para="
                    ''急診
                    '_DoctorScheduleWeb = "請建檔" '"http://192.168.64.200/Internal/sch/pntERsche.jsp"
                    '_TainanHospitalTransferWeb = "請建檔" '"http://web.tnhosp.gov.tw/hfindex.asp"
                    '_AdrOrder21Web = "請建檔" '"http://192.168.11.21/hospitalization/pharmacy/adr_order.jsp"
                    '_Prescription135Web = "請建檔" '"http://140.116.253.135/newhomepage/massrefer_prescription.asp"
                    ''住院
                    '_Icd9cmWeb = "請建檔" '"http://icd9cm.chrisendres.com/"
                    '_OphAutoPlayMusicWeb = "請建檔" '"http://172.19.14.107/NewHomePage/OPHAutoPlayMusic.html"
                    '_ReportServerIPDWeb = "請建檔" '"http://reporting.hosp.ncku/reportserver/"
                    ''新加的部分
                    '_Looks135Web = "請建檔" '"http://140.116.253.135/newhomepage/massrefer_looks.asp"
                    '_Looks107Web = "請建檔" '"http://172.19.14.107/newhomepage/massrefer_looks.asp"


                    '_cdrWeb = "請建檔" 'CDR 病歷的的網址

                Case hospConfigList.Tw_Taci
                    '臺中署立醫院的設定
                    _AppName = "臨床護理資訊系統"
                    _hospCode = "0136010010"
                    _name = "衛生福利部臺中醫院"
                    _engName = "Taichung Hospital,Ministry od Health and Welfare"
                    _shortName = "臺中醫院"
                    _engShortName = ""
                    _tel = "04-22294411"
                    _engTel = "04-22294411"
                    _fax = "04-22229517"
                    _engFax = "04-22229517"
                    _voiceTel = "04-22294411"
                    _engVoiceTel = "04-22294411"
                    _addr = "臺中市40343西區三民路一段199號"
                    _engAddr = "No.199, Sec. 1, Sanmin Rd., West Dist., Taichung City 403, Taiwan (R.O.C.)"
                    _principalName = ""
                    _engPrincipalName = ""
                    _principalEmail = ""
                    _engPrincipalEmail = ""
                    _url = "www.taic.mohw.gov.tw"
                    _engUrl = "www.taic.mohw.gov.tw"
                    _cityName = ""
                    _areaName = ""
                    _streetName = ""
                    _hospLevel = "請建檔" '"A"
                    _unifiedBussinessNo = "請建檔" '"06476734"
                    _licenseNo = ""
                    _dentalHospLevel = "請建檔" '"E"
                    _branchCode = ""
                    '程式中的外部連結


                Case hospConfigList.Tw_Tnhosp
                    '衛生福利部臺南醫院的設定
                    _AppName = "臨床護理資訊系統"
                    _hospCode = "0121050011"
                    _name = "衛生福利部臺南醫院"
                    _engName = "Tainan Hospital,Ministry of Health and Welfare"
                    _shortName = "臺南醫院"
                    _engShortName = ""
                    _tel = "06-2200055"
                    _engTel = "06-2200055"
                    _fax = ""
                    _engFax = ""
                    _voiceTel = "06-2249893~5"
                    _engVoiceTel = "06-2249893~5"
                    _addr = "台南市中西區中山路125號"
                    _engAddr = "No.125, Zhongshan Rd., West Central Dist., Tainan City 700, Taiwan (R.O.C.)"
                    _principalName = ""
                    _engPrincipalName = ""
                    _principalEmail = ""
                    _engPrincipalEmail = ""
                    _url = "www.tnhosp.mohw.gov.tw"
                    _engUrl = "www.tnhosp.mohw.gov.tw"
                    _cityName = ""
                    _areaName = ""
                    _streetName = ""
                    _hospLevel = "請建檔" '"A"
                    _unifiedBussinessNo = "請建檔" '"06476734"
                    _licenseNo = ""
                    _dentalHospLevel = "請建檔" '"E"
                    _branchCode = ""

                Case hospConfigList.Tw_KLUHOSP
                    '衛生福利部基隆醫院的設定檔
                    _AppName = "臨床護理資訊系統"
                    _hospCode = "0111070010"
                    _name = "衛生福利部基隆醫院"
                    _engName = "Keelung Hospital,Ministry od Health and Welfare"
                    _shortName = "基隆醫院"
                    _engShortName = ""
                    _tel = "02-24292525"
                    _engTel = "02-24292525"
                    _fax = "02-24223250"
                    _engFax = ""
                    _voiceTel = "02-24245119"
                    _engVoiceTel = "02-24245119"
                    _addr = "基隆市信二路268號"
                    _engAddr = "No.268, Xin 2nd Rd., Xinyi Dist., Keelung City 20147, Taiwan (R.O.C.)"
                    _principalName = ""
                    _engPrincipalName = ""
                    _principalEmail = ""
                    _engPrincipalEmail = ""
                    _url = "www.kln.mohw.gov.tw"
                    _engUrl = "www.kln.mohw.gov.tw"
                    _cityName = ""
                    _areaName = ""
                    _streetName = ""
                    _hospLevel = "請建檔" '"A"
                    _unifiedBussinessNo = "請建檔" '"06476734"
                    _licenseNo = ""
                    _dentalHospLevel = "請建檔" '"E"
                    _branchCode = ""

                Case hospConfigList.Tw_PUZIHOSP
                    '衛生福利部朴子醫院的設定檔
                    _AppName = "臨床護理資訊系統"
                    _hospCode = "0140010028"
                    _name = "衛生福利部朴子醫院"
                    _engName = "Puzi Hospital,Ministry od Health and Welfare"
                    _shortName = "朴子醫院"
                    _engShortName = ""
                    _tel = "05-3790600"
                    _engTel = "05-3790600"
                    _fax = ""
                    _engFax = ""
                    _voiceTel = "05-3797904"
                    _engVoiceTel = "05-3797904"
                    _addr = "嘉義縣朴子市永和里 42-50 號"
                    _engAddr = "No42-50,Yung Ho Li, Potz City, Chiayi County 613, Taiwan (R.O.C.)"
                    _principalName = ""
                    _engPrincipalName = ""
                    _principalEmail = ""
                    _engPrincipalEmail = ""
                    _url = "www.puzih.mohw.gov.tw"
                    _engUrl = "www.puzih.mohw.gov.tw"
                    _cityName = ""
                    _areaName = ""
                    _streetName = ""
                    _hospLevel = "請建檔" '"A"
                    _unifiedBussinessNo = "請建檔" '"06476734"
                    _licenseNo = ""
                    _dentalHospLevel = "請建檔" '"E"
                    _branchCode = ""

                Case hospConfigList.Tw_SINYINGHOSP
                    '衛生福利部新營醫院的設定檔
                    _AppName = "臨床護理資訊系統"
                    _hospCode = "0141010013"
                    _name = "衛生福利部新營醫院"
                    _engName = "Sinyin Hospital,Ministry od Health and Welfare"
                    _shortName = "新營醫院"
                    _engShortName = ""
                    _tel = "06-6351131-8"
                    _engTel = "06-6351131-8"
                    _fax = ""
                    _engFax = ""
                    _voiceTel = "06-63755"
                    _engVoiceTel = "06-63755"
                    _addr = "臺南市新營區信義街73號"
                    _engAddr = "No.73, Xinyi St., Xinying Dist., Tainan City 730, Taiwan (R.O.C.)"
                    _principalName = ""
                    _engPrincipalName = ""
                    _principalEmail = ""
                    _engPrincipalEmail = ""
                    _url = "www.syh.mohw.gov.tw"
                    _engUrl = "www.syh.mohw.gov.tw"
                    _cityName = ""
                    _areaName = ""
                    _streetName = ""
                    _hospLevel = "請建檔" '"A"
                    _unifiedBussinessNo = "請建檔" '"06476734"
                    _licenseNo = ""
                    _dentalHospLevel = "請建檔" '"E"
                    _branchCode = ""

                Case hospConfigList.Tw_FYHOSP
                    '衛生福利部豐原醫院的設定檔
                    _AppName = "臨床護理資訊系統"
                    _hospCode = "0136010010"
                    _name = "衛生福利部豐原醫院"
                    _engName = "Feng Yuan Hospital,Ministry od Health and Welfare"
                    _shortName = "豐原醫院"
                    _engShortName = ""
                    _tel = "04-25271180"
                    _engTel = "04-25271180"
                    _fax = "04-25284445"
                    _engFax = "04-25284445"
                    _voiceTel = ""
                    _engVoiceTel = ""
                    _addr = "台中市豐原區安康路100號"
                    _engAddr = "NO.100 An-Kan Rd. Fengyuan Dist., Taichung City 42055, Taiwan(R.O.C) "
                    _principalName = ""
                    _engPrincipalName = ""
                    _principalEmail = ""
                    _engPrincipalEmail = ""
                    _url = "www.fyh.mohw.gov.tw"
                    _engUrl = "www.fyh.mohw.gov.tw"
                    _cityName = ""
                    _areaName = ""
                    _streetName = ""
                    _hospLevel = "請建檔" '"A"
                    _unifiedBussinessNo = "請建檔" '"06476734"
                    _licenseNo = ""
                    _dentalHospLevel = "請建檔" '"E"
                    _branchCode = ""

                Case hospConfigList.Tw_HWAHOSP
                    '衛生福利部花蓮醫院的設定檔
                    _AppName = "臨床護理資訊系統"
                    _hospCode = "0145010019"
                    _name = "衛生福利部花蓮醫院"
                    _engName = "Hua-Lien Hospital,Ministry od Health and Welfare"
                    _shortName = "花蓮醫院"
                    _engShortName = ""
                    _tel = "03-8358141"
                    _engTel = "03-8358141"
                    _fax = ""
                    _engFax = ""
                    _voiceTel = "03-8358150"
                    _engVoiceTel = "03-8358150"
                    _addr = "花蓮市中正路600號"
                    _engAddr = "No.600, chungjen Rd. hualien city , HuaLien County 97061, Taiwan (R.O.C.) "
                    _principalName = ""
                    _engPrincipalName = ""
                    _principalEmail = ""
                    _engPrincipalEmail = ""
                    _url = "www.hwln.mohw.gov.tw "
                    _engUrl = "www.hwln.mohw.gov.tw "
                    _cityName = ""
                    _areaName = ""
                    _streetName = ""
                    _hospLevel = "請建檔" '"A"
                    _unifiedBussinessNo = "請建檔" '"06476734"
                    _licenseNo = ""
                    _dentalHospLevel = "請建檔" '"E"
                    _branchCode = ""

                Case hospConfigList.Tw_YLHOSP
                    '衛生福利部玉里醫院的設定檔
                    _AppName = "臨床護理資訊系統"
                    _hospCode = "0145030020"
                    _name = "衛生福利部玉里醫院"
                    _engName = "Yuli Hospital,Ministry od Health and Welfare"
                    _shortName = "玉里醫院"
                    _engShortName = ""
                    _tel = "03-8886141"
                    _engTel = "03-8886141"
                    _fax = "03-8882402"
                    _engFax = "03-8882402"
                    _voiceTel = ""
                    _engVoiceTel = ""
                    _addr = "花蓮縣玉里鎮中華路448號"
                    _engAddr = "No.448, Chunghua Rd., Yuli Township, Hualien County, Taiwan (R.O.C.)"
                    _principalName = ""
                    _engPrincipalName = ""
                    _principalEmail = ""
                    _engPrincipalEmail = ""
                    _url = "www.ttyl.mohw.gov.tw"
                    _engUrl = "www.ttyl.mohw.gov.tw"
                    _cityName = ""
                    _areaName = ""
                    _streetName = ""
                    _hospLevel = "請建檔" '"A"
                    _unifiedBussinessNo = "請建檔" '"06476734"
                    _licenseNo = ""
                    _dentalHospLevel = "請建檔" '"E"
                    _branchCode = ""

                Case hospConfigList.Tw_CHESTHOSP
                    '衛生福利部胸腔醫院的設定檔
                    _AppName = "臨床護理資訊系統"
                    _hospCode = "0141270019"
                    _name = "衛生福利部胸腔醫院"
                    _engName = "Chest Hospital,Ministry od Health and Welfare"
                    _shortName = "胸腔醫院"
                    _engShortName = ""
                    _tel = "06-2705911"
                    _engTel = "06-2705911"
                    _fax = "06-2703400"
                    _engFax = "06-2703400"
                    _voiceTel = "06-2142619"
                    _engVoiceTel = "06-2142619"
                    _addr = "台南市仁德區中山路864號"
                    _engAddr = "No.864, Zhongshan Rd., Rende Dist., Tainan City 71742, Taiwan (R.O.C.) "
                    _principalName = ""
                    _engPrincipalName = ""
                    _principalEmail = ""
                    _engPrincipalEmail = ""
                    _url = "www.ccd.mohw.gov.tw"
                    _engUrl = "www.ccd.mohw.gov.tw"
                    _cityName = ""
                    _areaName = ""
                    _streetName = ""
                    _hospLevel = "請建檔" '"A"
                    _unifiedBussinessNo = "請建檔" '"06476734"
                    _licenseNo = ""
                    _dentalHospLevel = "請建檔" '"E"
                    _branchCode = ""

                Case hospConfigList.Tw_HENGTHOSP
                    '衛生福利部恆春旅遊醫院的設定檔
                    _AppName = "臨床護理資訊系統"
                    _hospCode = "0143040019"
                    _name = "衛生福利部恆春旅遊醫院"
                    _engName = "Hengchun Tourism Hospital,Ministry od Health and Welfare"
                    _shortName = "恆春旅遊醫院"
                    _engShortName = ""
                    _tel = "08-8892704"
                    _engTel = "08-8892704"
                    _fax = "08-8894054"
                    _engFax = "08-8894054"
                    _voiceTel = ""
                    _engVoiceTel = ""
                    _addr = "屏東縣恆春鎮恆南路188號"
                    _engAddr = "No.188, Hengnan Rd., Hengchun Township, Pingtung County 946, Taiwan (R.O.C.)"
                    _principalName = ""
                    _engPrincipalName = ""
                    _principalEmail = ""
                    _engPrincipalEmail = ""
                    _url = "www.pnhb.mohw.gov.tw"
                    _engUrl = "www.pnhb.mohw.gov.tw"
                    _cityName = ""
                    _areaName = ""
                    _streetName = ""
                    _hospLevel = "請建檔" '"A"
                    _unifiedBussinessNo = "請建檔" '"06476734"
                    _licenseNo = ""
                    _dentalHospLevel = "請建檔" '"E"
                    _branchCode = ""

                Case hospConfigList.Tw_PEHHOSP
                    '衛生福利部澎湖醫院的設定檔
                    _AppName = "臨床護理資訊系統"
                    _hospCode = "0144010015"
                    _name = "衛生福利部澎湖醫院"
                    _engName = "Penghu Hospital,Ministry od Health and Welfare"
                    _shortName = "澎湖醫院"
                    _engShortName = ""
                    _tel = "06-9261151"
                    _engTel = "06-9261151"
                    _fax = ""
                    _engFax = ""
                    _voiceTel = ""
                    _engVoiceTel = ""
                    _addr = "澎湖縣馬公市中正路10號"
                    _engAddr = "No.10, Zhongzheng Rd., Magong City, Penghu County 880, Taiwan (R.O.C.)"
                    _principalName = ""
                    _engPrincipalName = ""
                    _principalEmail = ""
                    _engPrincipalEmail = ""
                    _url = "www.pngh.mohw.gov.tw"
                    _engUrl = "www.pngh.mohw.gov.tw"
                    _cityName = ""
                    _areaName = ""
                    _streetName = ""
                    _hospLevel = "請建檔" '"A"
                    _unifiedBussinessNo = "請建檔" '"06476734"
                    _licenseNo = ""
                    _dentalHospLevel = "請建檔" '"E"
                    _branchCode = ""

                Case hospConfigList.Tw_TAOYUANPC
                    '衛生福利部桃園療養院的設定檔
                    _AppName = "臨床護理資訊系統"
                    _hospCode = "0132010023"
                    _name = "衛生福利部桃園療養院"
                    _engName = "Taoyuan Psychiatric Center,Ministry od Health and Welfare"
                    _shortName = "桃園療養院"
                    _engShortName = ""
                    _tel = "03-369-8553"
                    _engTel = "03-369-8553"
                    _fax = ""
                    _engFax = ""
                    _voiceTel = "03-360-6929"
                    _engVoiceTel = "03-360-6929"
                    _addr = "桃園市桃園區龍壽街71號"
                    _engAddr = "No.71, Longshou St., Taoyuan Dist., Taoyuan City 330, Taiwan (R.O.C.)"
                    _principalName = ""
                    _engPrincipalName = ""
                    _principalEmail = ""
                    _engPrincipalEmail = ""
                    _url = "www.typc.mohw.gov.tw"
                    _engUrl = "www.typc.mohw.gov.tw"
                    _cityName = ""
                    _areaName = ""
                    _streetName = ""
                    _hospLevel = "請建檔" '"A"
                    _unifiedBussinessNo = "請建檔" '"06476734"
                    _licenseNo = ""
                    _dentalHospLevel = "請建檔" '"E"
                    _branchCode = ""

                Case hospConfigList.Tw_CWHHOSP
                    '衛生福利部彰化醫院的設定檔
                    _AppName = "臨床護理資訊系統"
                    _hospCode = "0137170515"
                    _name = "衛生福利部彰化醫院"
                    _engName = "Chang-Hua Hospital,Ministry od Health and Welfare"
                    _shortName = "彰化醫院"
                    _engShortName = ""
                    _tel = "04-8298686 "
                    _engTel = "04-8298686 "
                    _fax = ""
                    _engFax = ""
                    _voiceTel = "04-8299399"
                    _engVoiceTel = "04-8299399"
                    _addr = "彰化縣埔心鄉中正路二段80號"
                    _engAddr = "No. 80 Chung Cheng Road Sec. 2 Chiu Kuan Village Puhsin Chang Hua County, Taiwan (R.O.C.)"
                    _principalName = ""
                    _engPrincipalName = ""
                    _principalEmail = ""
                    _engPrincipalEmail = ""
                    _url = "www.chhw.mohw.gov.tw"
                    _engUrl = "www.chhw.mohw.gov.tw"
                    _cityName = ""
                    _areaName = ""
                    _streetName = ""
                    _hospLevel = "請建檔" '"A"
                    _unifiedBussinessNo = "請建檔" '"06476734"
                    _licenseNo = ""
                    _dentalHospLevel = "請建檔" '"E"
                    _branchCode = ""

                Case hospConfigList.Tw_CHISANHOSP
                    '衛生福利部旗山醫院的設定檔
                    _AppName = "臨床護理資訊系統"
                    _hospCode = "0142030019"
                    _name = "衛生福利部旗山醫院"
                    _engName = "Cishan Hospital,Ministry od Health and Welfare"
                    _shortName = "旗山醫院"
                    _engShortName = ""
                    _tel = "07-6613811"
                    _engTel = "07-6613811"
                    _fax = "07-6618638"
                    _engFax = "07-6618638"
                    _voiceTel = ""
                    _engVoiceTel = ""
                    _addr = "高雄市旗山區大德里中學路60號"
                    _engAddr = "No.60, Zhongxue Rd., Cishan District, Kaohsiung City 84247, Taiwan (R.O.C.)"
                    _principalName = ""
                    _engPrincipalName = ""
                    _principalEmail = ""
                    _engPrincipalEmail = ""
                    _url = "www.chis.mohw.gov.tw"
                    _engUrl = "www.chis.mohw.gov.tw"
                    _cityName = ""
                    _areaName = ""
                    _streetName = ""
                    _hospLevel = "請建檔" '"A"
                    _unifiedBussinessNo = "請建檔" '"06476734"
                    _licenseNo = ""
                    _dentalHospLevel = "請建檔" '"E"
                    _branchCode = ""

                Case hospConfigList.Tw_KMNHOSP
                    '衛生福利部金門醫院的設定檔
                    _AppName = "臨床護理資訊系統"
                    _hospCode = "0190030516"
                    _name = "衛生福利金門隆醫院"
                    _engName = "KinMen Hospital,Ministry od Health and Welfare"
                    _shortName = "金門醫院"
                    _engShortName = ""
                    _tel = "082-332546 "
                    _engTel = "082-332546 "
                    _fax = ""
                    _engFax = ""
                    _voiceTel = ""
                    _engVoiceTel = ""
                    _addr = "金門縣金湖鎮新市里復興路2號"
                    _engAddr = "No.2, Fuxing Rd., Jinhu Township, Kinmen County 891, Taiwan (R.O.C.)"
                    _principalName = ""
                    _engPrincipalName = ""
                    _principalEmail = ""
                    _engPrincipalEmail = ""
                    _url = "www.kmhp.mohw.gov.tw"
                    _engUrl = "www.kmhp.mohw.gov.tw"
                    _cityName = ""
                    _areaName = ""
                    _streetName = ""
                    _hospLevel = "請建檔" '"A"
                    _unifiedBussinessNo = "請建檔" '"06476734"
                    _licenseNo = ""
                    _dentalHospLevel = "請建檔" '"E"
                    _branchCode = ""

                Case hospConfigList.Tw_PCHHOSP
                    '衛生福利部屏東醫院的設定檔
                    _AppName = "臨床護理資訊系統"
                    _hospCode = "0143010011"
                    _name = "衛生福利部屏東醫院"
                    _engName = "Pingtung Hospital,Ministry od Health and Welfare"
                    _shortName = "屏東醫院"
                    _engShortName = ""
                    _tel = "08-7363011"
                    _engTel = "08-7363011"
                    _fax = "08-7382685"
                    _engFax = "08-7382685"
                    _voiceTel = "08-7377452"
                    _engVoiceTel = "08-7377452"
                    _addr = "屏東縣屏東市自由路270號"
                    _engAddr = "No.270, Ziyou Rd., Pingtung City, Pingtung County 900, Taiwan (R.O.C.) "
                    _principalName = ""
                    _engPrincipalName = ""
                    _principalEmail = ""
                    _engPrincipalEmail = ""
                    _url = "www.pntn.mohw.gov.tw"
                    _engUrl = "www.pntn.mohw.gov.tw"
                    _cityName = ""
                    _areaName = ""
                    _streetName = ""
                    _hospLevel = "請建檔" '"A"
                    _unifiedBussinessNo = "請建檔" '"06476734"
                    _licenseNo = ""
                    _dentalHospLevel = "請建檔" '"E"
                    _branchCode = ""

                Case hospConfigList.Tw_TTTHOSP
                    '衛生福利部台東醫院的設定檔
                    _AppName = "臨床護理資訊系統"
                    _hospCode = "0146010013"
                    _name = "衛生福利部台東醫院"
                    _engName = "Taitung Hospital,Ministry od Health and Welfare"
                    _shortName = "台東醫院"
                    _engShortName = ""
                    _tel = "089-324112"
                    _engTel = "089-324112"
                    _fax = "089-323891"
                    _engFax = ""
                    _voiceTel = "02-24245119"
                    _engVoiceTel = "02-24245119"
                    _addr = "臺東市五權街1號"
                    _engAddr = "No.1, Wuquan St., Taitung City, Taitung County 950, Taiwan (R.O.C.)"
                    _principalName = ""
                    _engPrincipalName = ""
                    _principalEmail = ""
                    _engPrincipalEmail = ""
                    _url = "www.tait.mohw.gov.tw"
                    _engUrl = "www.tait.mohw.gov.tw"
                    _cityName = ""
                    _areaName = ""
                    _streetName = ""
                    _hospLevel = "請建檔" '"A"
                    _unifiedBussinessNo = "請建檔" '"06476734"
                    _licenseNo = ""
                    _dentalHospLevel = "請建檔" '"E"
                    _branchCode = ""

                Case hospConfigList.Tw_NTOHOSP
                    '衛生福利部南投醫院的設定檔
                    _AppName = "臨床護理資訊系統"
                    _hospCode = "0138010027"
                    _name = "衛生福利部南投醫院"
                    _engName = "Nantou Hospital,Ministry od Health and Welfare"
                    _shortName = "南投醫院"
                    _engShortName = ""
                    _tel = "049-2231150"
                    _engTel = "049-2231150"
                    _fax = "049-2241886"
                    _engFax = "049-2241886"
                    _voiceTel = "049-2238813"
                    _engVoiceTel = "049-2238813"
                    _addr = "南投縣南投市復興路478號"
                    _engAddr = "478 Fuxing Rd., Nantou City, Nantou County 540, Taiwan (R.O.C.) "
                    _principalName = ""
                    _engPrincipalName = ""
                    _principalEmail = ""
                    _engPrincipalEmail = ""
                    _url = "www.nant.mohw.gov.tw"
                    _engUrl = "www.nant.mohw.gov.tw"
                    _cityName = ""
                    _areaName = ""
                    _streetName = ""
                    _hospLevel = "請建檔" '"A"
                    _unifiedBussinessNo = "請建檔" '"06476734"
                    _licenseNo = ""
                    _dentalHospLevel = "請建檔" '"E"
                    _branchCode = ""

                Case hospConfigList.Tw_BALIPC
                    '衛生福利部八里療養院的設定檔
                    _AppName = "臨床護理資訊系統"
                    _hospCode = "0131230012"
                    _name = "衛生福利部八里療養院"
                    _engName = "Bali Psychiatric Center,Ministry od Health and Welfare"
                    _shortName = "八里療養院"
                    _engShortName = ""
                    _tel = "02-26101660"
                    _engTel = "02-26101660"
                    _fax = "02-26105916"
                    _engFax = "02-26105916"
                    _voiceTel = ""
                    _engVoiceTel = ""
                    _addr = "新北市(24936)八里區華富山33號"
                    _engAddr = "No.33, Huafushan, Bali Dist., New Taipei City 24936,, Taiwan (R.O.C.)"
                    _principalName = ""
                    _engPrincipalName = ""
                    _principalEmail = ""
                    _engPrincipalEmail = ""
                    _url = "www.bali.mohw.gov.tw"
                    _engUrl = "www.bali.mohw.gov.tw"
                    _cityName = ""
                    _areaName = ""
                    _streetName = ""
                    _hospLevel = "請建檔" '"A"
                    _unifiedBussinessNo = "請建檔" '"06476734"
                    _licenseNo = ""
                    _dentalHospLevel = "請建檔" '"E"
                    _branchCode = ""

                Case hospConfigList.Tw_TSAOTUNPC
                    '衛生福利部草屯療養院的設定檔
                    _AppName = "臨床護理資訊系統"
                    _hospCode = "0138030010"
                    _name = "衛生福利部草屯療養院"
                    _engName = "TSAOTUN PSYCHIATRIC CENTER,Ministry od Health and Welfare"
                    _shortName = "草屯療養院"
                    _engShortName = ""
                    _tel = "049-2550800"
                    _engTel = "049-2550800"
                    _fax = "049-2564184"
                    _engFax = ""
                    _voiceTel = ""
                    _engVoiceTel = ""
                    _addr = "南投縣草屯鎮御史里14鄰玉屏路161號"
                    _engAddr = "161 Yu-Pin Rd, Caotun Township, NAN-TOU, Taiwan (R.O.C.)"
                    _principalName = ""
                    _engPrincipalName = ""
                    _principalEmail = ""
                    _engPrincipalEmail = ""
                    _url = "www.ttpc.mohw.gov.tw"
                    _engUrl = "www.ttpc.mohw.gov.tw"
                    _cityName = ""
                    _areaName = ""
                    _streetName = ""
                    _hospLevel = "請建檔" '"A"
                    _unifiedBussinessNo = "請建檔" '"06476734"
                    _licenseNo = ""
                    _dentalHospLevel = "請建檔" '"E"
                    _branchCode = ""

                Case hospConfigList.Tw_CNPC
                    '衛生福利部嘉南療養院的設定檔
                    _AppName = "臨床護理資訊系統"
                    _hospCode = "0141270028"
                    _name = "衛生福利部嘉南療養院"
                    _engName = "JIANAN PSYCHIATRIC CENTER,Ministry od Health and Welfare"
                    _shortName = "草屯療養院"
                    _engShortName = ""
                    _tel = "06-2795019"
                    _engTel = "06-2795019"
                    _fax = "06-2796394"
                    _engFax = "06-2796394"
                    _voiceTel = ""
                    _engVoiceTel = ""
                    _addr = "台南市仁德區中山路870巷80號"
                    _engAddr = "71742 No.80, Ln. 870, Zhongshan Rd., Rende Dist., Tainan City 717, Taiwan (R.O.C.)"
                    _principalName = ""
                    _engPrincipalName = ""
                    _principalEmail = ""
                    _engPrincipalEmail = ""
                    _url = "www.cnpc.mohw.gov.tw"
                    _engUrl = "www.cnpc.mohw.gov.tw"
                    _cityName = ""
                    _areaName = ""
                    _streetName = ""
                    _hospLevel = "請建檔" '"A"
                    _unifiedBussinessNo = "請建檔" '"06476734"
                    _licenseNo = ""
                    _dentalHospLevel = "請建檔" '"E"
                    _branchCode = ""

                Case hospConfigList.Tw_LSLPC
                    '衛生福利部樂生療養院的設定檔
                    _AppName = "臨床護理資訊系統"
                    _hospCode = "0131060010"
                    _name = "衛生福利部樂生療養院"
                    _engName = "Lo-Sheng Sanatorium and Hospital,Ministry od Health and Welfare"
                    _shortName = "樂生療養院"
                    _engShortName = ""
                    _tel = "02-82006600"
                    _engTel = "02-82006600"
                    _fax = "02-82001775"
                    _engFax = "02-82001775"
                    _voiceTel = ""
                    _engVoiceTel = ""
                    _addr = "桃園市龜山區萬壽路一段50巷2號"
                    _engAddr = "No.2 Lane 50, Sec. 1,Wanshou Rd., Guishan Shiang District, Taoyuan City 33351,Taiwan(R.O.C)"
                    _principalName = ""
                    _engPrincipalName = ""
                    _principalEmail = ""
                    _engPrincipalEmail = ""
                    _url = "www.lslp.mohw.gov.tw"
                    _engUrl = "www.lslp.mohw.gov.tw"
                    _cityName = ""
                    _areaName = ""
                    _streetName = ""
                    _hospLevel = "請建檔" '"A"
                    _unifiedBussinessNo = "請建檔" '"06476734"
                    _licenseNo = ""
                    _dentalHospLevel = "請建檔" '"E"
                    _branchCode = ""

                Case hospConfigList.Tw_MILHOSP
                    '衛生福利部苗栗醫院的設定檔
                    _AppName = "臨床護理資訊系統"
                    _hospCode = "0135010016"
                    _name = "衛生福利部苗栗醫院"
                    _engName = "Miaoli  General Hospital,Ministry od Health and Welfare"
                    _shortName = "苗栗醫院"
                    _engShortName = ""
                    _tel = "037-261920# 273"
                    _engTel = "037-261920# 273"
                    _fax = ""
                    _engFax = ""
                    _voiceTel = "037-261920# 275"
                    _engVoiceTel = "037-261920# 275"
                    _addr = "苗栗市為公路747號"
                    _engAddr = "747 Wei Gong Road, Miaoli City, Taiwan (R.O.C.)"
                    _principalName = ""
                    _engPrincipalName = ""
                    _principalEmail = ""
                    _engPrincipalEmail = ""
                    _url = "www.mil.mohw.gov.tw"
                    _engUrl = "www.mil.mohw.gov.tw"
                    _cityName = ""
                    _areaName = ""
                    _streetName = ""
                    _hospLevel = "請建檔" '"A"
                    _unifiedBussinessNo = "請建檔" '"06476734"
                    _licenseNo = ""
                    _dentalHospLevel = "請建檔" '"E"
                    _branchCode = ""

                Case hospConfigList.Tw_TPEHOSP
                    '衛生福利部臺北醫院的設定檔
                    _AppName = "臨床護理資訊系統"
                    _hospCode = "0131060029"
                    _name = "衛生福利部臺北醫院"
                    _engName = "Taipei Hospital,  General Hospital,Ministry od Health and Welfare"
                    _shortName = "臺北醫院"
                    _engShortName = ""
                    _tel = "02-22765566"
                    _engTel = "02-22765566"
                    _fax = ""
                    _engFax = ""
                    _voiceTel = ""
                    _engVoiceTel = ""
                    _addr = "新北巿新莊區思源路 127 號"
                    _engAddr = "NO.127, SU-YUAN ROAD, HSIN-CHUANG DISTRICT, NEW TAIPEI CITY, 242-13, TAIWAN(R.O.C.)"
                    _principalName = ""
                    _engPrincipalName = ""
                    _principalEmail = ""
                    _engPrincipalEmail = ""
                    _url = "www.tph.mohw.gov.tw"
                    _engUrl = "www.tph.mohw.gov.tw"
                    _cityName = ""
                    _areaName = ""
                    _streetName = ""
                    _hospLevel = "請建檔" '"A"
                    _unifiedBussinessNo = "請建檔" '"06476734"
                    _licenseNo = ""
                    _dentalHospLevel = "請建檔" '"E"
                    _branchCode = ""

                Case Else
                    '其他醫院的設定檔
                    _AppName = "請建檔"
                    _hospCode = "請建檔"
                    _name = "請建檔"
                    _engName = "請建檔"
                    _shortName = "請建檔"
                    _engShortName = "請建檔"
                    _tel = "請建檔"
                    _engTel = "請建檔"
                    _fax = "請建檔"
                    _engFax = "請建檔"
                    _voiceTel = "請建檔"
                    _engVoiceTel = "請建檔"
                    _addr = "請建檔"
                    _engAddr = "請建檔"
                    _principalName = ""
                    _engPrincipalName = ""
                    _principalEmail = ""
                    _engPrincipalEmail = ""
                    _url = "請建檔"
                    _engUrl = "請建檔"
                    _cityName = ""
                    _areaName = ""
                    _streetName = ""
                    _hospLevel = "請建檔" '"A"
                    _unifiedBussinessNo = "請建檔" '"06476734"
                    _licenseNo = ""
                    _dentalHospLevel = "請建檔" '"E"
                    _branchCode = ""

            End Select
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


#End Region


    ''' <summary>
    ''' 根據 param 取得對應建檔資料
    ''' </summary>
    ''' <param name="param"></param>
    ''' <returns></returns>
    ''' <remarks>ex: 傳入 "ForgetPwd1Web"  回傳 _ForgetPwd1Web 對應設定值</remarks>
    Public Shared Function GetParameterValue(ByVal param) As String

        Dim rtnValue As String = ""

        If _dictParameter Is Nothing Then
            _dictParameter = New Dictionary(Of String, String)
        End If

        If _dictParameter.Count = 0 Then
            Dim _memberInfo() As MemberInfo = _hospConfigUtil.GetType.GetMembers(BindingFlags.Static Or BindingFlags.NonPublic)

            For i As Integer = 0 To _memberInfo.Length - 1
                '.net 4.0

                If TryCast(_memberInfo(i), FieldInfo) IsNot Nothing Then
                    '_EPHRPT0090301_1 =>  EPHRPT0090301_1
                    If Not _dictParameter.ContainsKey(Mid(_memberInfo(i).Name, 1)) Then

                        If TryCast(CType(_memberInfo(i), FieldInfo).GetValue(Nothing), String) IsNot Nothing Then
                            _dictParameter.Add(Mid(_memberInfo(i).Name, 1), CType(_memberInfo(i), FieldInfo).GetValue(Nothing))
                        End If

                    End If
                End If

            Next
        End If

        If _dictParameter.ContainsKey(param) Then
            rtnValue = _dictParameter(param)
        End If


        Return rtnValue

    End Function



#Region "屬性"

    Public Shared Property AppName() As String
        Get
            Return _AppName
        End Get
        Set(ByVal value As String)
            _AppName = value
        End Set
    End Property

    Public Shared Property HospCode() As String
        Get
            Return _hospCode
        End Get
        Set(ByVal value As String)
            _hospCode = value
        End Set
    End Property
    Public Shared Property Name() As String
        Get
            Return _name
        End Get
        Set(ByVal value As String)
            _name = value
        End Set
    End Property
    Public Shared Property EngName() As String
        Get
            Return _engName
        End Get
        Set(ByVal value As String)
            _engName = value
        End Set
    End Property
    Public Shared Property ShortName() As String
        Get
            Return _shortName
        End Get
        Set(ByVal value As String)
            _shortName = value
        End Set
    End Property
    Public Shared Property EngShortName() As String
        Get
            Return _shortName
        End Get
        Set(ByVal value As String)
            _shortName = value
        End Set
    End Property
    Public Shared Property Tel() As String
        Get
            Return _tel
        End Get
        Set(ByVal value As String)
            _tel = value
        End Set
    End Property
    Public Shared Property EngTel() As String
        Get
            Return _engTel
        End Get
        Set(ByVal value As String)
            _engTel = value
        End Set
    End Property
    Public Shared Property Fax() As String
        Get
            Return _fax
        End Get
        Set(ByVal value As String)
            _fax = value
        End Set
    End Property
    Public Shared Property EngFax() As String
        Get
            Return _engFax
        End Get
        Set(ByVal value As String)
            _engFax = value
        End Set
    End Property
    Public Shared Property VoiceTel() As String
        Get
            Return _voiceTel
        End Get
        Set(ByVal value As String)
            _voiceTel = value
        End Set
    End Property
    Public Shared Property EngVoiceTel() As String
        Get
            Return _engVoiceTel
        End Get
        Set(ByVal value As String)
            _engVoiceTel = value
        End Set
    End Property
    Public Shared Property Addr() As String
        Get
            Return _addr
        End Get
        Set(ByVal value As String)
            _addr = value
        End Set
    End Property
    Public Shared Property EngAddr() As String
        Get
            Return _engAddr
        End Get
        Set(ByVal value As String)
            _engAddr = value
        End Set
    End Property
    Public Shared Property PrincipalName() As String
        Get
            Return _principalName
        End Get
        Set(ByVal value As String)
            _principalName = value
        End Set
    End Property
    Public Shared Property EngPrincipalName() As String
        Get
            Return _engPrincipalName
        End Get
        Set(ByVal value As String)
            _engPrincipalName = value
        End Set
    End Property
    Public Shared Property Url() As String
        Get
            Return _url
        End Get
        Set(ByVal value As String)
            _url = value
        End Set
    End Property
    Public Shared Property EngUrl() As String
        Get
            Return _engUrl
        End Get
        Set(ByVal value As String)
            _engUrl = value
        End Set
    End Property
    Public Shared Property CityName() As String
        Get
            Return _cityName
        End Get
        Set(ByVal value As String)
            _cityName = value
        End Set
    End Property
    Public Shared Property AreaName() As String
        Get
            Return _areaName
        End Get
        Set(ByVal value As String)
            _areaName = value
        End Set
    End Property
    Public Shared Property StreetName() As String
        Get
            Return _streetName
        End Get
        Set(ByVal value As String)
            _streetName = value
        End Set
    End Property
    Public Shared Property HospLevel() As String
        Get
            Return _hospLevel
        End Get
        Set(ByVal value As String)
            _hospLevel = value
        End Set
    End Property
    Public Shared Property UnifiedBussinessNo() As String
        Get
            Return _unifiedBussinessNo
        End Get
        Set(ByVal value As String)
            _unifiedBussinessNo = value
        End Set
    End Property
    Public Shared Property LicenseNo() As String
        Get
            Return _licenseNo
        End Get
        Set(ByVal value As String)
            _licenseNo = value
        End Set
    End Property
    Public Shared Property DentalHospLevel() As String
        Get
            Return _dentalHospLevel
        End Get
        Set(ByVal value As String)
            _dentalHospLevel = value
        End Set
    End Property
    Public Shared Property BranchCode() As String
        Get
            Return _branchCode
        End Get
        Set(ByVal value As String)
            _branchCode = value
        End Set
    End Property


#End Region



End Class
