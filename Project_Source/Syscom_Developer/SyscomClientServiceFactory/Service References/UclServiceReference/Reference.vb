﻿'------------------------------------------------------------------------------
' <auto-generated>
'     這段程式碼是由工具產生的。
'     執行階段版本:4.0.30319.34209
'
'     對這個檔案所做的變更可能會造成錯誤的行為，而且如果重新產生程式碼，
'     變更將會遺失。
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On


Namespace UclServiceReference
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ServiceModel.ServiceContractAttribute(ConfigurationName:="UclServiceReference.IUclService")>  _
    Public Interface IUclService
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IUclService/queryOpenWindow", ReplyAction:="http://tempuri.org/IUclService/queryOpenWindowResponse")>  _
        Function queryOpenWindow(ByVal prmQueryTable As Integer, ByVal prmCondField As String, ByVal prmCondValue As String, ByVal prmCondType As String, ByVal OtherQueryConditionDS As System.Data.DataSet) As System.Data.DataSet
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IUclService/queryUclPostalAreaAll", ReplyAction:="http://tempuri.org/IUclService/queryUclPostalAreaAllResponse")>  _
        Function queryUclPostalAreaAll() As System.Data.DataSet
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IUclService/queryUclPostalAreaAllNew", ReplyAction:="http://tempuri.org/IUclService/queryUclPostalAreaAllNewResponse")>  _
        Function queryUclPostalAreaAllNew() As System.Data.DataSet
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IUclService/queryUclPUBAreaCodeGovVilCodeName", ReplyAction:="http://tempuri.org/IUclService/queryUclPUBAreaCodeGovVilCodeNameResponse")>  _
        Function queryUclPUBAreaCodeGovVilCodeName(ByVal code1 As String, ByVal code2 As String, ByVal type As String) As System.Data.DataSet
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IUclService/queryUclIdentityInitial", ReplyAction:="http://tempuri.org/IUclService/queryUclIdentityInitialResponse")>  _
        Function queryUclIdentityInitial() As System.Data.DataSet
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IUclService/queryUclIdentityInitial2", ReplyAction:="http://tempuri.org/IUclService/queryUclIdentityInitial2Response")>  _
        Function queryUclIdentityInitial2(ByVal inSourceType As String) As System.Data.DataSet
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IUclService/queryUclChartNoByKey", ReplyAction:="http://tempuri.org/IUclService/queryUclChartNoByKeyResponse")>  _
        Function queryUclChartNoByKey(ByVal codeNo As String, ByVal codeType As String) As System.Data.DataSet
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IUclService/queryOMOOrderDiagnosis", ReplyAction:="http://tempuri.org/IUclService/queryOMOOrderDiagnosisResponse")>  _
        Function queryOMOOrderDiagnosis(ByVal code As String, ByVal codeName As String, ByVal DiseaseTypeId As String, ByVal IsSevereDisease As String) As System.Data.DataSet
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IUclService/queryOPHPharmacyBase", ReplyAction:="http://tempuri.org/IUclService/queryOPHPharmacyBaseResponse")>  _
        Function queryOPHPharmacyBase(ByVal code As String, ByVal codeName As String, ByVal DrugType As String, ByVal IsEqualMatch As String) As System.Data.DataSet
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IUclService/DoUclAction", ReplyAction:="http://tempuri.org/IUclService/DoUclActionResponse")>  _
        Function DoUclAction(ByVal ds As System.Data.DataSet) As System.Data.DataSet
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IUclService/queryPUBOrder", ReplyAction:="http://tempuri.org/IUclService/queryPUBOrderResponse")>  _
        Function queryPUBOrder(ByVal OrderCode As String, ByVal OrderEnName As String, ByVal OrderTypeId As String, ByVal BasicDateStr As String) As System.Data.DataSet
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IUclService/querySMTPData", ReplyAction:="http://tempuri.org/IUclService/querySMTPDataResponse")>  _
        Function querySMTPData() As System.Data.DataSet
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IUclService/UclHintDataBOinsert", ReplyAction:="http://tempuri.org/IUclService/UclHintDataBOinsertResponse")>  _
        Function UclHintDataBOinsert(ByVal ds As System.Data.DataSet) As Integer
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IUclService/UclHintDataBOqueryByPK", ReplyAction:="http://tempuri.org/IUclService/UclHintDataBOqueryByPKResponse")>  _
        Function UclHintDataBOqueryByPK(ByRef pk_UI_Name As String, ByRef pk_Serial As Integer) As System.Data.DataSet
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IUclService/UclHintDataBOdelete", ReplyAction:="http://tempuri.org/IUclService/UclHintDataBOdeleteResponse")>  _
        Function UclHintDataBOdelete(ByRef pk_UI_Name As String, ByRef pk_Serial As Integer) As Integer
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IUclService/UclHintDataBOupdate", ReplyAction:="http://tempuri.org/IUclService/UclHintDataBOupdateResponse")>  _
        Function UclHintDataBOupdate(ByVal ds As System.Data.DataSet) As Integer
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IUclService/UclHintDataBOqueryData", ReplyAction:="http://tempuri.org/IUclService/UclHintDataBOqueryDataResponse")>  _
        Function UclHintDataBOqueryData(ByVal UIName As String) As System.Data.DataSet
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IUclService/UclHintDataBOqueryDataAll", ReplyAction:="http://tempuri.org/IUclService/UclHintDataBOqueryDataAllResponse")>  _
        Function UclHintDataBOqueryDataAll() As System.Data.DataSet
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IUclService/queryOMOPhraseForUCL", ReplyAction:="http://tempuri.org/IUclService/queryOMOPhraseForUCLResponse")>  _
        Function queryOMOPhraseForUCL(ByVal UserTypeId As String, ByVal DoctorDeptCode As String, ByVal PhraseTypeId As String, ByVal PhraseKeyStr As String) As System.Data.DataSet
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IUclService/queryOMOOrderFavorInit", ReplyAction:="http://tempuri.org/IUclService/queryOMOOrderFavorInitResponse")>  _
        Function queryOMOOrderFavorInit(ByVal queryData As System.Data.DataSet) As System.Data.DataSet
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IUclService/queryOMOOrderFavorByCond3", ReplyAction:="http://tempuri.org/IUclService/queryOMOOrderFavorByCond3Response")>  _
        Function queryOMOOrderFavorByCond3(ByVal SourceType As String, ByVal FavorId As String, ByVal FavorTypeId As String, ByVal DoctorDeptCode As String, ByVal FavorCategory As String, ByVal OrderCode As String, ByVal OrderName As String, ByVal DrugType As String, ByVal PharmacyQueryFlag() As String, ByVal ChartNo As String, ByVal OutpatientSn As String, ByVal IsChoiceDcOrder As String) As System.Data.DataSet
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IUclService/querySTAPackageDataByCategory", ReplyAction:="http://tempuri.org/IUclService/querySTAPackageDataByCategoryResponse")>  _
        Function querySTAPackageDataByCategory(ByVal inCategory As String, ByVal inStation As String, ByVal inCategoryStr As String, ByVal inQueryStr As String) As System.Data.DataSet
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IUclService/queryOMOOrderFavorSheetDept2", ReplyAction:="http://tempuri.org/IUclService/queryOMOOrderFavorSheetDept2Response")>  _
        Function queryOMOOrderFavorSheetDept2(ByVal SourceType As String, ByVal FavorTypeId As String, ByVal inHospCode As String) As System.Data.DataSet
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IUclService/queryOMOOrderFavorSheetDetailByLabGroup", ReplyAction:="http://tempuri.org/IUclService/queryOMOOrderFavorSheetDetailByLabGroupResponse")>  _
        Function queryOMOOrderFavorSheetDetailByLabGroup(ByVal SourceType As String, ByVal SheetCode As String, ByVal SheetGroup As String, ByVal ChartNo As String, ByVal OutpatientSn As String, ByVal inQueryStr As String, ByVal IsChoiceDcOrder As String) As System.Data.DataSet
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IUclService/queryOMOOrderFavorSheetDetailByExamGroup", ReplyAction:="http://tempuri.org/IUclService/queryOMOOrderFavorSheetDetailByExamGroupResponse")>  _
        Function queryOMOOrderFavorSheetDetailByExamGroup(ByVal SourceType As String, ByVal SheetCode As String, ByVal SheetGroup As String, ByVal ChartNo As String, ByVal OutpatientSn As String, ByVal inQueryStr As String, ByVal IsChoiceDcOrder As String) As System.Data.DataSet
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IUclService/queryOMOOrderFavorSheetDetailByExamGroupForKMUH", ReplyAction:="http://tempuri.org/IUclService/queryOMOOrderFavorSheetDetailByExamGroupForKMUHRes"& _ 
            "ponse")>  _
        Function queryOMOOrderFavorSheetDetailByExamGroupForKMUH(ByVal SourceType As String, ByVal SheetCode As String, ByVal SheetGroup As String, ByVal ChartNo As String, ByVal OutpatientSn As String, ByVal inQueryStr As String, ByVal IsChoiceDcOrder As String) As System.Data.DataSet
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IUclService/queryOMOFavorCategory2", ReplyAction:="http://tempuri.org/IUclService/queryOMOFavorCategory2Response")>  _
        Function queryOMOFavorCategory2(ByVal SourceType As String, ByVal FavorId As String, ByVal FavorTypeId As String, ByVal DoctorDeptCode As String, ByVal IsChoiceDcOrder As String) As System.Data.DataSet
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IUclService/querySTAPackageDataCategory", ReplyAction:="http://tempuri.org/IUclService/querySTAPackageDataCategoryResponse")>  _
        Function querySTAPackageDataCategory(ByVal inCategory As String, ByVal inStation As String) As System.Data.DataSet
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IUclService/queryOMOOrderFavorSheetDetailByLab2", ReplyAction:="http://tempuri.org/IUclService/queryOMOOrderFavorSheetDetailByLab2Response")>  _
        Function queryOMOOrderFavorSheetDetailByLab2(ByVal SourceType As String, ByVal SheetCode As String, ByVal IsChoiceDcOrder As String) As System.Data.DataSet
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IUclService/queryOMOOrderFavorSheetDetailByExam2", ReplyAction:="http://tempuri.org/IUclService/queryOMOOrderFavorSheetDetailByExam2Response")>  _
        Function queryOMOOrderFavorSheetDetailByExam2(ByVal SourceType As String, ByVal SheetCode As String, ByVal IsChoiceDcOrder As String) As System.Data.DataSet
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IUclService/queryOMOOrderFavorDetailOrder3", ReplyAction:="http://tempuri.org/IUclService/queryOMOOrderFavorDetailOrder3Response")>  _
        Function queryOMOOrderFavorDetailOrder3(ByVal SourceType As String, ByVal OrderTypeId As String, ByVal DrugType As String, ByVal FavorId As String, ByVal DoctorDeptCode As String, ByVal PackageCode As String, ByVal ChartNo As String, ByVal OutpatientSn As String, ByVal IsChoiceDcOrder As String) As System.Data.DataSet
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IUclService/queryOPHPharmacyByCond3", ReplyAction:="http://tempuri.org/IUclService/queryOPHPharmacyByCond3Response")>  _
        Function queryOPHPharmacyByCond3(ByVal SourceType As String, ByVal OrderCode As String, ByVal OrderName As String, ByVal DrugType As String, ByVal PharmacyQueryFlag() As String, ByVal IsChoiceDcOrder As String) As System.Data.DataSet
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IUclService/queryPUBOrderByLanguage3", ReplyAction:="http://tempuri.org/IUclService/queryPUBOrderByLanguage3Response")>  _
        Function queryPUBOrderByLanguage3(ByVal SourceType As String, ByVal OrderCode As String, ByVal OrderName As String, ByVal OrderTypeId As String, ByVal FavorCategory As String, ByVal Specimen As String, ByVal Body_Site As String, ByVal Chinese_Flag As String, ByVal ChartNo As String, ByVal OutpatientSn As String, ByVal IsChoiceDcOrder As String) As System.Data.DataSet
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IUclService/queryPUBDiseaseByFavor2", ReplyAction:="http://tempuri.org/IUclService/queryPUBDiseaseByFavor2Response")>  _
        Function queryPUBDiseaseByFavor2(ByVal SourceType As String, ByVal code As String, ByVal codeEnName As String, ByVal codeName As String, ByVal DiseaseTypeId As String, ByVal IsSevereDisease As String) As System.Data.DataSet
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IUclService/queryPUBExamItemByOrder", ReplyAction:="http://tempuri.org/IUclService/queryPUBExamItemByOrderResponse")>  _
        Function queryPUBExamItemByOrder(ByVal inOrderCode As String) As System.Data.DataSet
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IUclService/queryPUBOrderOwnAndNhiPrice", ReplyAction:="http://tempuri.org/IUclService/queryPUBOrderOwnAndNhiPriceResponse")>  _
        Function queryPUBOrderOwnAndNhiPrice(ByVal OrderCode As String) As System.Data.DataSet
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IUclService/queryOMODiagFavorInit", ReplyAction:="http://tempuri.org/IUclService/queryOMODiagFavorInitResponse")>  _
        Function queryOMODiagFavorInit(ByVal SourceTypeId As String, ByVal DiagType As String, ByVal DoctorCode As String, ByVal DeptCode As String, ByVal DiagCode As String, ByVal DiagDesc As String) As System.Data.DataSet
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IUclService/queryPUBInsuSubDept", ReplyAction:="http://tempuri.org/IUclService/queryPUBInsuSubDeptResponse")>  _
        Function queryPUBInsuSubDept(ByVal SourceTypeId As String, ByVal DiagType As String, ByVal InsuDeptCode As String) As System.Data.DataSet
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IUclService/queryDiagCategory", ReplyAction:="http://tempuri.org/IUclService/queryDiagCategoryResponse")>  _
        Function queryDiagCategory(ByVal DiagType As String, ByVal DiagCode As String, ByVal DiagDesc As String) As System.Data.DataSet
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IUclService/queryICD10Category", ReplyAction:="http://tempuri.org/IUclService/queryICD10CategoryResponse")>  _
        Function queryICD10Category(ByVal SourceTypeId As String, ByVal DiagType As String, ByVal IsInsu As String) As System.Data.DataSet
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IUclService/queryICDDetail", ReplyAction:="http://tempuri.org/IUclService/queryICDDetailResponse")>  _
        Function queryICDDetail(ByVal SelType As String, ByVal SourceTypeId As String, ByVal DiagType As String, ByVal FavorId As String, ByVal DoctorDeptCode As String, ByVal FavorCategory As String, ByVal ICDCode As String, ByVal ICD10ChapterId As String, ByVal InsuDeptCode As String, ByVal InsuSubDeptCode As String, ByVal DiagCode As String, ByVal DiagDesc As String) As System.Data.DataSet
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IUclService/QueryPrintCondition", ReplyAction:="http://tempuri.org/IUclService/QueryPrintConditionResponse")>  _
        Function QueryPrintCondition(ByVal Param As System.Collections.Generic.Dictionary(Of String, Object)) As System.Data.DataSet
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IUclService/GetLoginUserPrintCond", ReplyAction:="http://tempuri.org/IUclService/GetLoginUserPrintCondResponse")>  _
        Function GetLoginUserPrintCond(ByVal Param As System.Collections.Generic.Dictionary(Of String, Object)) As System.Data.DataTable
    End Interface
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")>  _
    Public Interface IUclServiceChannel
        Inherits UclServiceReference.IUclService, System.ServiceModel.IClientChannel
    End Interface
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")>  _
    Partial Public Class UclServiceClient
        Inherits System.ServiceModel.ClientBase(Of UclServiceReference.IUclService)
        Implements UclServiceReference.IUclService
        
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
        
        Public Function queryOpenWindow(ByVal prmQueryTable As Integer, ByVal prmCondField As String, ByVal prmCondValue As String, ByVal prmCondType As String, ByVal OtherQueryConditionDS As System.Data.DataSet) As System.Data.DataSet Implements UclServiceReference.IUclService.queryOpenWindow
            Return MyBase.Channel.queryOpenWindow(prmQueryTable, prmCondField, prmCondValue, prmCondType, OtherQueryConditionDS)
        End Function
        
        Public Function queryUclPostalAreaAll() As System.Data.DataSet Implements UclServiceReference.IUclService.queryUclPostalAreaAll
            Return MyBase.Channel.queryUclPostalAreaAll
        End Function
        
        Public Function queryUclPostalAreaAllNew() As System.Data.DataSet Implements UclServiceReference.IUclService.queryUclPostalAreaAllNew
            Return MyBase.Channel.queryUclPostalAreaAllNew
        End Function
        
        Public Function queryUclPUBAreaCodeGovVilCodeName(ByVal code1 As String, ByVal code2 As String, ByVal type As String) As System.Data.DataSet Implements UclServiceReference.IUclService.queryUclPUBAreaCodeGovVilCodeName
            Return MyBase.Channel.queryUclPUBAreaCodeGovVilCodeName(code1, code2, type)
        End Function
        
        Public Function queryUclIdentityInitial() As System.Data.DataSet Implements UclServiceReference.IUclService.queryUclIdentityInitial
            Return MyBase.Channel.queryUclIdentityInitial
        End Function
        
        Public Function queryUclIdentityInitial2(ByVal inSourceType As String) As System.Data.DataSet Implements UclServiceReference.IUclService.queryUclIdentityInitial2
            Return MyBase.Channel.queryUclIdentityInitial2(inSourceType)
        End Function
        
        Public Function queryUclChartNoByKey(ByVal codeNo As String, ByVal codeType As String) As System.Data.DataSet Implements UclServiceReference.IUclService.queryUclChartNoByKey
            Return MyBase.Channel.queryUclChartNoByKey(codeNo, codeType)
        End Function
        
        Public Function queryOMOOrderDiagnosis(ByVal code As String, ByVal codeName As String, ByVal DiseaseTypeId As String, ByVal IsSevereDisease As String) As System.Data.DataSet Implements UclServiceReference.IUclService.queryOMOOrderDiagnosis
            Return MyBase.Channel.queryOMOOrderDiagnosis(code, codeName, DiseaseTypeId, IsSevereDisease)
        End Function
        
        Public Function queryOPHPharmacyBase(ByVal code As String, ByVal codeName As String, ByVal DrugType As String, ByVal IsEqualMatch As String) As System.Data.DataSet Implements UclServiceReference.IUclService.queryOPHPharmacyBase
            Return MyBase.Channel.queryOPHPharmacyBase(code, codeName, DrugType, IsEqualMatch)
        End Function
        
        Public Function DoUclAction(ByVal ds As System.Data.DataSet) As System.Data.DataSet Implements UclServiceReference.IUclService.DoUclAction
            Return MyBase.Channel.DoUclAction(ds)
        End Function
        
        Public Function queryPUBOrder(ByVal OrderCode As String, ByVal OrderEnName As String, ByVal OrderTypeId As String, ByVal BasicDateStr As String) As System.Data.DataSet Implements UclServiceReference.IUclService.queryPUBOrder
            Return MyBase.Channel.queryPUBOrder(OrderCode, OrderEnName, OrderTypeId, BasicDateStr)
        End Function
        
        Public Function querySMTPData() As System.Data.DataSet Implements UclServiceReference.IUclService.querySMTPData
            Return MyBase.Channel.querySMTPData
        End Function
        
        Public Function UclHintDataBOinsert(ByVal ds As System.Data.DataSet) As Integer Implements UclServiceReference.IUclService.UclHintDataBOinsert
            Return MyBase.Channel.UclHintDataBOinsert(ds)
        End Function
        
        Public Function UclHintDataBOqueryByPK(ByRef pk_UI_Name As String, ByRef pk_Serial As Integer) As System.Data.DataSet Implements UclServiceReference.IUclService.UclHintDataBOqueryByPK
            Return MyBase.Channel.UclHintDataBOqueryByPK(pk_UI_Name, pk_Serial)
        End Function
        
        Public Function UclHintDataBOdelete(ByRef pk_UI_Name As String, ByRef pk_Serial As Integer) As Integer Implements UclServiceReference.IUclService.UclHintDataBOdelete
            Return MyBase.Channel.UclHintDataBOdelete(pk_UI_Name, pk_Serial)
        End Function
        
        Public Function UclHintDataBOupdate(ByVal ds As System.Data.DataSet) As Integer Implements UclServiceReference.IUclService.UclHintDataBOupdate
            Return MyBase.Channel.UclHintDataBOupdate(ds)
        End Function
        
        Public Function UclHintDataBOqueryData(ByVal UIName As String) As System.Data.DataSet Implements UclServiceReference.IUclService.UclHintDataBOqueryData
            Return MyBase.Channel.UclHintDataBOqueryData(UIName)
        End Function
        
        Public Function UclHintDataBOqueryDataAll() As System.Data.DataSet Implements UclServiceReference.IUclService.UclHintDataBOqueryDataAll
            Return MyBase.Channel.UclHintDataBOqueryDataAll
        End Function
        
        Public Function queryOMOPhraseForUCL(ByVal UserTypeId As String, ByVal DoctorDeptCode As String, ByVal PhraseTypeId As String, ByVal PhraseKeyStr As String) As System.Data.DataSet Implements UclServiceReference.IUclService.queryOMOPhraseForUCL
            Return MyBase.Channel.queryOMOPhraseForUCL(UserTypeId, DoctorDeptCode, PhraseTypeId, PhraseKeyStr)
        End Function
        
        Public Function queryOMOOrderFavorInit(ByVal queryData As System.Data.DataSet) As System.Data.DataSet Implements UclServiceReference.IUclService.queryOMOOrderFavorInit
            Return MyBase.Channel.queryOMOOrderFavorInit(queryData)
        End Function
        
        Public Function queryOMOOrderFavorByCond3(ByVal SourceType As String, ByVal FavorId As String, ByVal FavorTypeId As String, ByVal DoctorDeptCode As String, ByVal FavorCategory As String, ByVal OrderCode As String, ByVal OrderName As String, ByVal DrugType As String, ByVal PharmacyQueryFlag() As String, ByVal ChartNo As String, ByVal OutpatientSn As String, ByVal IsChoiceDcOrder As String) As System.Data.DataSet Implements UclServiceReference.IUclService.queryOMOOrderFavorByCond3
            Return MyBase.Channel.queryOMOOrderFavorByCond3(SourceType, FavorId, FavorTypeId, DoctorDeptCode, FavorCategory, OrderCode, OrderName, DrugType, PharmacyQueryFlag, ChartNo, OutpatientSn, IsChoiceDcOrder)
        End Function
        
        Public Function querySTAPackageDataByCategory(ByVal inCategory As String, ByVal inStation As String, ByVal inCategoryStr As String, ByVal inQueryStr As String) As System.Data.DataSet Implements UclServiceReference.IUclService.querySTAPackageDataByCategory
            Return MyBase.Channel.querySTAPackageDataByCategory(inCategory, inStation, inCategoryStr, inQueryStr)
        End Function
        
        Public Function queryOMOOrderFavorSheetDept2(ByVal SourceType As String, ByVal FavorTypeId As String, ByVal inHospCode As String) As System.Data.DataSet Implements UclServiceReference.IUclService.queryOMOOrderFavorSheetDept2
            Return MyBase.Channel.queryOMOOrderFavorSheetDept2(SourceType, FavorTypeId, inHospCode)
        End Function
        
        Public Function queryOMOOrderFavorSheetDetailByLabGroup(ByVal SourceType As String, ByVal SheetCode As String, ByVal SheetGroup As String, ByVal ChartNo As String, ByVal OutpatientSn As String, ByVal inQueryStr As String, ByVal IsChoiceDcOrder As String) As System.Data.DataSet Implements UclServiceReference.IUclService.queryOMOOrderFavorSheetDetailByLabGroup
            Return MyBase.Channel.queryOMOOrderFavorSheetDetailByLabGroup(SourceType, SheetCode, SheetGroup, ChartNo, OutpatientSn, inQueryStr, IsChoiceDcOrder)
        End Function
        
        Public Function queryOMOOrderFavorSheetDetailByExamGroup(ByVal SourceType As String, ByVal SheetCode As String, ByVal SheetGroup As String, ByVal ChartNo As String, ByVal OutpatientSn As String, ByVal inQueryStr As String, ByVal IsChoiceDcOrder As String) As System.Data.DataSet Implements UclServiceReference.IUclService.queryOMOOrderFavorSheetDetailByExamGroup
            Return MyBase.Channel.queryOMOOrderFavorSheetDetailByExamGroup(SourceType, SheetCode, SheetGroup, ChartNo, OutpatientSn, inQueryStr, IsChoiceDcOrder)
        End Function
        
        Public Function queryOMOOrderFavorSheetDetailByExamGroupForKMUH(ByVal SourceType As String, ByVal SheetCode As String, ByVal SheetGroup As String, ByVal ChartNo As String, ByVal OutpatientSn As String, ByVal inQueryStr As String, ByVal IsChoiceDcOrder As String) As System.Data.DataSet Implements UclServiceReference.IUclService.queryOMOOrderFavorSheetDetailByExamGroupForKMUH
            Return MyBase.Channel.queryOMOOrderFavorSheetDetailByExamGroupForKMUH(SourceType, SheetCode, SheetGroup, ChartNo, OutpatientSn, inQueryStr, IsChoiceDcOrder)
        End Function
        
        Public Function queryOMOFavorCategory2(ByVal SourceType As String, ByVal FavorId As String, ByVal FavorTypeId As String, ByVal DoctorDeptCode As String, ByVal IsChoiceDcOrder As String) As System.Data.DataSet Implements UclServiceReference.IUclService.queryOMOFavorCategory2
            Return MyBase.Channel.queryOMOFavorCategory2(SourceType, FavorId, FavorTypeId, DoctorDeptCode, IsChoiceDcOrder)
        End Function
        
        Public Function querySTAPackageDataCategory(ByVal inCategory As String, ByVal inStation As String) As System.Data.DataSet Implements UclServiceReference.IUclService.querySTAPackageDataCategory
            Return MyBase.Channel.querySTAPackageDataCategory(inCategory, inStation)
        End Function
        
        Public Function queryOMOOrderFavorSheetDetailByLab2(ByVal SourceType As String, ByVal SheetCode As String, ByVal IsChoiceDcOrder As String) As System.Data.DataSet Implements UclServiceReference.IUclService.queryOMOOrderFavorSheetDetailByLab2
            Return MyBase.Channel.queryOMOOrderFavorSheetDetailByLab2(SourceType, SheetCode, IsChoiceDcOrder)
        End Function
        
        Public Function queryOMOOrderFavorSheetDetailByExam2(ByVal SourceType As String, ByVal SheetCode As String, ByVal IsChoiceDcOrder As String) As System.Data.DataSet Implements UclServiceReference.IUclService.queryOMOOrderFavorSheetDetailByExam2
            Return MyBase.Channel.queryOMOOrderFavorSheetDetailByExam2(SourceType, SheetCode, IsChoiceDcOrder)
        End Function
        
        Public Function queryOMOOrderFavorDetailOrder3(ByVal SourceType As String, ByVal OrderTypeId As String, ByVal DrugType As String, ByVal FavorId As String, ByVal DoctorDeptCode As String, ByVal PackageCode As String, ByVal ChartNo As String, ByVal OutpatientSn As String, ByVal IsChoiceDcOrder As String) As System.Data.DataSet Implements UclServiceReference.IUclService.queryOMOOrderFavorDetailOrder3
            Return MyBase.Channel.queryOMOOrderFavorDetailOrder3(SourceType, OrderTypeId, DrugType, FavorId, DoctorDeptCode, PackageCode, ChartNo, OutpatientSn, IsChoiceDcOrder)
        End Function
        
        Public Function queryOPHPharmacyByCond3(ByVal SourceType As String, ByVal OrderCode As String, ByVal OrderName As String, ByVal DrugType As String, ByVal PharmacyQueryFlag() As String, ByVal IsChoiceDcOrder As String) As System.Data.DataSet Implements UclServiceReference.IUclService.queryOPHPharmacyByCond3
            Return MyBase.Channel.queryOPHPharmacyByCond3(SourceType, OrderCode, OrderName, DrugType, PharmacyQueryFlag, IsChoiceDcOrder)
        End Function
        
        Public Function queryPUBOrderByLanguage3(ByVal SourceType As String, ByVal OrderCode As String, ByVal OrderName As String, ByVal OrderTypeId As String, ByVal FavorCategory As String, ByVal Specimen As String, ByVal Body_Site As String, ByVal Chinese_Flag As String, ByVal ChartNo As String, ByVal OutpatientSn As String, ByVal IsChoiceDcOrder As String) As System.Data.DataSet Implements UclServiceReference.IUclService.queryPUBOrderByLanguage3
            Return MyBase.Channel.queryPUBOrderByLanguage3(SourceType, OrderCode, OrderName, OrderTypeId, FavorCategory, Specimen, Body_Site, Chinese_Flag, ChartNo, OutpatientSn, IsChoiceDcOrder)
        End Function
        
        Public Function queryPUBDiseaseByFavor2(ByVal SourceType As String, ByVal code As String, ByVal codeEnName As String, ByVal codeName As String, ByVal DiseaseTypeId As String, ByVal IsSevereDisease As String) As System.Data.DataSet Implements UclServiceReference.IUclService.queryPUBDiseaseByFavor2
            Return MyBase.Channel.queryPUBDiseaseByFavor2(SourceType, code, codeEnName, codeName, DiseaseTypeId, IsSevereDisease)
        End Function
        
        Public Function queryPUBExamItemByOrder(ByVal inOrderCode As String) As System.Data.DataSet Implements UclServiceReference.IUclService.queryPUBExamItemByOrder
            Return MyBase.Channel.queryPUBExamItemByOrder(inOrderCode)
        End Function
        
        Public Function queryPUBOrderOwnAndNhiPrice(ByVal OrderCode As String) As System.Data.DataSet Implements UclServiceReference.IUclService.queryPUBOrderOwnAndNhiPrice
            Return MyBase.Channel.queryPUBOrderOwnAndNhiPrice(OrderCode)
        End Function
        
        Public Function queryOMODiagFavorInit(ByVal SourceTypeId As String, ByVal DiagType As String, ByVal DoctorCode As String, ByVal DeptCode As String, ByVal DiagCode As String, ByVal DiagDesc As String) As System.Data.DataSet Implements UclServiceReference.IUclService.queryOMODiagFavorInit
            Return MyBase.Channel.queryOMODiagFavorInit(SourceTypeId, DiagType, DoctorCode, DeptCode, DiagCode, DiagDesc)
        End Function
        
        Public Function queryPUBInsuSubDept(ByVal SourceTypeId As String, ByVal DiagType As String, ByVal InsuDeptCode As String) As System.Data.DataSet Implements UclServiceReference.IUclService.queryPUBInsuSubDept
            Return MyBase.Channel.queryPUBInsuSubDept(SourceTypeId, DiagType, InsuDeptCode)
        End Function
        
        Public Function queryDiagCategory(ByVal DiagType As String, ByVal DiagCode As String, ByVal DiagDesc As String) As System.Data.DataSet Implements UclServiceReference.IUclService.queryDiagCategory
            Return MyBase.Channel.queryDiagCategory(DiagType, DiagCode, DiagDesc)
        End Function
        
        Public Function queryICD10Category(ByVal SourceTypeId As String, ByVal DiagType As String, ByVal IsInsu As String) As System.Data.DataSet Implements UclServiceReference.IUclService.queryICD10Category
            Return MyBase.Channel.queryICD10Category(SourceTypeId, DiagType, IsInsu)
        End Function
        
        Public Function queryICDDetail(ByVal SelType As String, ByVal SourceTypeId As String, ByVal DiagType As String, ByVal FavorId As String, ByVal DoctorDeptCode As String, ByVal FavorCategory As String, ByVal ICDCode As String, ByVal ICD10ChapterId As String, ByVal InsuDeptCode As String, ByVal InsuSubDeptCode As String, ByVal DiagCode As String, ByVal DiagDesc As String) As System.Data.DataSet Implements UclServiceReference.IUclService.queryICDDetail
            Return MyBase.Channel.queryICDDetail(SelType, SourceTypeId, DiagType, FavorId, DoctorDeptCode, FavorCategory, ICDCode, ICD10ChapterId, InsuDeptCode, InsuSubDeptCode, DiagCode, DiagDesc)
        End Function
        
        Public Function QueryPrintCondition(ByVal Param As System.Collections.Generic.Dictionary(Of String, Object)) As System.Data.DataSet Implements UclServiceReference.IUclService.QueryPrintCondition
            Return MyBase.Channel.QueryPrintCondition(Param)
        End Function
        
        Public Function GetLoginUserPrintCond(ByVal Param As System.Collections.Generic.Dictionary(Of String, Object)) As System.Data.DataTable Implements UclServiceReference.IUclService.GetLoginUserPrintCond
            Return MyBase.Channel.GetLoginUserPrintCond(Param)
        End Function
    End Class
End Namespace
