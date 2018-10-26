Imports Syscom.Comm.TableFactory

Public Class UCLPatientData
    Dim patientColumnDB() As String =PubPatientDataTableFactory.columnsName


#Region "病患資料變數宣告"

    Private _Is_IPD As String = ""
    Private _Is_EMG As String = ""

    Private _Chart_No As String = ""
    Private _Patient_Name As String = ""
    Private _Patient_Short_Name As String = ""
    Private _Patient_En_Name As String = ""
    Private _Idno_Type_Id As String = ""
    Private _Idno As String = ""
    Private _Birth_Date As String = ""

    Private _Sex_Id As String = ""
    Private _Blood_Type_Id As String = ""
    Private _Education_Id As String = ""
    Private _Marriage_Id As String = ""
    Private _Job_Id As String = ""

    Private _Nationality_Id As String = ""
    Private _Race_Id As String = ""
    Private _Area_Code As String = ""
    Private _Register_Postal_Code As String = ""
    Private _Register_Address As String = ""

    Private _Postal_Code As String = ""
    Private _Address As String = ""
    Private _Tel_Home As String = ""
    Private _Tel_Office As String = ""
    Private _Tel_Mobile As String = ""

    Private _Fax As String = ""
    Private _Email As String = ""
    Private _Postal_Code2 As String = ""
    Private _Address2 As String = ""
    Private _Tel2 As String = ""

    Private _Tel2_Mobile As String = ""
    Private _Email2 As String = ""
    Private _First_Visit_Date As String = ""
    Private _Latest_Visit_Date As String = ""
    Private _Latest_Admission_Date As String = ""

    Private _Latest_Discharge_Date As String = ""
    Private _Ipd_Times As String = ""
    Private _Latest_Xray_Date As String = ""
    Private _Latest_CT_Date As String = ""
    Private _Arrears_Times As String = ""

    Private _Opd_Arrears_Amt As String = ""
    Private _Emg_Arrears_Amt As String = ""
    Private _Ipd_Arrears_Amt As String = ""
    Private _Measure_Time As String = ""
    Private _Latest_Height As String = ""

    Private _Latest_Weight As String = ""
    Private _Mis_Register_Date1 As String = ""
    Private _Mis_Register_Date2 As String = ""
    Private _Mis_Register_Date3 As String = ""
    Private _Mis_Register_Times As String = ""

    Private _Mis_Register_End_Date As String = ""
    Private _Is_Death As String = ""
    Private _Death_Time As String = ""
    Private _Is_Chart_Divide As String = ""
    Private _Is_Chart_Image As String = ""

    Private _Patient_Memo As String = ""
    Private _Is_Employee As String = ""
    Private _Reserve_Chart_No As String = ""
    Private _Latest_LMP_Date As String = ""
    Private _LIS_Blood_Report As String = ""

    Private _LIS_Blood_Report_Time As String = ""
    Private _LIS_BMT_Mark As String = ""

    Private _Student_Id = ""
    Private _Create_User As String = ""
    Private _Create_Time As String = ""
    Private _Modified_User As String = ""
    Private _Modified_Time As String = ""

    Private _Reg_Notify_Id As String = ""

    Private _Register_Dist_Code As String = ""
    Private _Register_Vil_Code As String = ""
    Private _Dist_Code As String = ""
    Private _Vil_Code As String = ""
    Private _Dist_Code2 As String = ""
    Private _Vil_Code2 As String = ""
 
    Private _Visit_Type As Visit = Visit.First_Hos




#End Region
    ' Private ds As DataSet
    Private _PatientDS, _PatientFlagDS, _PatientDisDS, _PatientSevereDisDS As DataSet

#Region "病患資料屬性設定"


    Enum Visit

        First_Hos = 1 '院初診
        First_Belong_Dep = 2 '大分科初診
        First_Dep = 3  '小分科初診
        NonFirst = 4 '複診
        Transfer = 5 '轉診
    End Enum

    Public Property PatientDS() As DataSet
        Get
            Return _PatientDS
        End Get
        Set(ByVal value As DataSet)
            _PatientDS = value
        End Set
    End Property


    Public Property PatientFlagDS() As DataSet
        Get
            Return _PatientFlagDS
        End Get
        Set(ByVal value As DataSet)
            _PatientFlagDS = value
        End Set
    End Property

    Public Property PatientDisDS() As DataSet
        Get
            Return _PatientDisDS
        End Get
        Set(ByVal value As DataSet)
            _PatientDisDS = value
        End Set
    End Property



    Public Property PatientSevereDisDS() As DataSet
        Get
            Return _PatientSevereDisDS
        End Get
        Set(ByVal value As DataSet)
            _PatientSevereDisDS = value
        End Set
    End Property

    Public Property Is_IPD() As String
        Get
            Return _Is_IPD
        End Get
        Set(ByVal value As String)
            _Is_IPD = value
        End Set
    End Property

    Public Property Is_EMG() As String
        Get
            Return _Is_EMG
        End Get
        Set(ByVal value As String)
            _Is_EMG = value
        End Set
    End Property


    Public Property Visit_Type() As Visit
        Get
            Return _Visit_Type
        End Get
        Set(ByVal value As Visit)
            _Visit_Type = value
        End Set
    End Property

    Public Property Chart_No() As String
        Get
            Return _Chart_No
        End Get
        Set(ByVal value As String)
            _Chart_No = value
        End Set
    End Property

    Public Property Patient_Name() As String
        Get
            Return _Patient_Name
        End Get
        Set(ByVal value As String)
            _Patient_Name = value
        End Set
    End Property

    Public Property Patient_Short_Name() As String
        Get
            Return _Patient_Short_Name
        End Get
        Set(ByVal value As String)
            _Patient_Short_Name = value
        End Set
    End Property

    Public Property Patient_En_Name() As String
        Get
            Return _Patient_En_Name
        End Get
        Set(ByVal value As String)
            _Patient_En_Name = value
        End Set
    End Property

    Public Property Idno_Type_Id() As String
        Get
            Return _Idno_Type_Id
        End Get
        Set(ByVal value As String)
            _Idno_Type_Id = value
        End Set
    End Property

    Public Property Idno() As String
        Get
            Return _Idno
        End Get
        Set(ByVal value As String)
            _Idno = value
        End Set
    End Property

    Public Property Birth_Date() As String
        Get
            Return _Birth_Date
        End Get
        Set(ByVal value As String)
            _Birth_Date = value
        End Set
    End Property

    Public Property Sex_Id() As String
        Get
            Return _Sex_Id
        End Get
        Set(ByVal value As String)
            _Sex_Id = value
        End Set
    End Property

    Public Property Blood_Type_Id() As String
        Get
            Return _Blood_Type_Id
        End Get
        Set(ByVal value As String)
            _Blood_Type_Id = value
        End Set
    End Property

    Public Property Education_Id() As String
        Get
            Return _Education_Id
        End Get
        Set(ByVal value As String)
            _Education_Id = value
        End Set
    End Property

    Public Property Marriage_Id() As String
        Get
            Return _Marriage_Id
        End Get
        Set(ByVal value As String)
            _Marriage_Id = value
        End Set
    End Property

    Public Property Job_Id() As String
        Get
            Return _Job_Id
        End Get
        Set(ByVal value As String)
            _Job_Id = value
        End Set
    End Property

    Public Property Nationality_Id() As String
        Get
            Return _Nationality_Id
        End Get
        Set(ByVal value As String)
            _Nationality_Id = value
        End Set
    End Property

    Public Property Race_Id() As String
        Get
            Return _Race_Id
        End Get
        Set(ByVal value As String)
            _Race_Id = value
        End Set
    End Property

    Public Property Area_Code() As String
        Get
            Return _Area_Code
        End Get
        Set(ByVal value As String)
            _Area_Code = value
        End Set
    End Property

    Public Property Register_Postal_Code() As String
        Get
            Return _Register_Postal_Code
        End Get
        Set(ByVal value As String)
            _Register_Postal_Code = value
        End Set
    End Property

    Public Property Register_Address() As String
        Get
            Return _Register_Address
        End Get
        Set(ByVal value As String)
            _Register_Address = value
        End Set
    End Property

    Public Property Postal_Code() As String
        Get
            Return _Postal_Code
        End Get
        Set(ByVal value As String)
            _Postal_Code = value
        End Set
    End Property

    Public Property Address() As String
        Get
            Return _Address
        End Get
        Set(ByVal value As String)
            _Address = value
        End Set
    End Property

    Public Property Tel_Home() As String
        Get
            Return _Tel_Home
        End Get
        Set(ByVal value As String)
            _Tel_Home = value
        End Set
    End Property

    Public Property Tel_Office() As String
        Get
            Return _Tel_Office
        End Get
        Set(ByVal value As String)
            _Tel_Office = value
        End Set
    End Property

    Public Property Tel_Mobile() As String
        Get
            Return _Tel_Mobile
        End Get
        Set(ByVal value As String)
            _Tel_Mobile = value
        End Set
    End Property

    Public Property Fax() As String
        Get
            Return _Fax
        End Get
        Set(ByVal value As String)
            _Fax = value
        End Set
    End Property

    Public Property Email() As String
        Get
            Return _Email
        End Get
        Set(ByVal value As String)
            _Email = value
        End Set
    End Property

    Public Property Postal_Code2() As String
        Get
            Return _Postal_Code2
        End Get
        Set(ByVal value As String)
            _Postal_Code2 = value
        End Set
    End Property

    Public Property Address2() As String
        Get
            Return _Address2
        End Get
        Set(ByVal value As String)
            _Address2 = value
        End Set
    End Property

    Public Property Tel2() As String
        Get
            Return _Tel2
        End Get
        Set(ByVal value As String)
            _Tel2 = value
        End Set
    End Property

    Public Property Tel2_Mobile() As String
        Get
            Return _Tel2_Mobile
        End Get
        Set(ByVal value As String)
            _Tel2_Mobile = value
        End Set
    End Property

    Public Property Email2() As String
        Get
            Return _Email2
        End Get
        Set(ByVal value As String)
            _Email2 = value
        End Set
    End Property

    Public Property First_Visit_Date() As String
        Get
            Return _First_Visit_Date
        End Get
        Set(ByVal value As String)
            _First_Visit_Date = value
        End Set
    End Property

    Public Property Latest_Visit_Date() As String
        Get
            Return _Latest_Visit_Date
        End Get
        Set(ByVal value As String)
            _Latest_Visit_Date = value
        End Set
    End Property

    Public Property Latest_Admission_Date() As String
        Get
            Return _Latest_Admission_Date
        End Get
        Set(ByVal value As String)
            _Latest_Admission_Date = value
        End Set
    End Property

    Public Property Latest_Discharge_Date() As String
        Get
            Return _Latest_Discharge_Date
        End Get
        Set(ByVal value As String)
            _Latest_Discharge_Date = value
        End Set
    End Property

    Public Property Ipd_Times() As String
        Get
            Return _Ipd_Times
        End Get
        Set(ByVal value As String)
            _Ipd_Times = value
        End Set
    End Property

    Public Property Latest_Xray_Date() As String
        Get
            Return _Latest_Xray_Date
        End Get
        Set(ByVal value As String)
            _Latest_Xray_Date = value
        End Set
    End Property

    Public Property Latest_CT_Date() As String
        Get
            Return _Latest_CT_Date
        End Get
        Set(ByVal value As String)
            _Latest_CT_Date = value
        End Set
    End Property

    Public Property Arrears_Times() As String
        Get
            Return _Arrears_Times
        End Get
        Set(ByVal value As String)
            _Arrears_Times = value
        End Set
    End Property

    Public Property Opd_Arrears_Amt() As String
        Get
            Return _Opd_Arrears_Amt
        End Get
        Set(ByVal value As String)
            _Opd_Arrears_Amt = value
        End Set
    End Property

    Public Property Emg_Arrears_Amt() As String
        Get
            Return _Emg_Arrears_Amt
        End Get
        Set(ByVal value As String)
            _Emg_Arrears_Amt = value
        End Set
    End Property

    Public Property Ipd_Arrears_Amt() As String
        Get
            Return _Ipd_Arrears_Amt
        End Get
        Set(ByVal value As String)
            _Ipd_Arrears_Amt = value
        End Set
    End Property

    Public Property Measure_Time() As String
        Get
            Return _Measure_Time
        End Get
        Set(ByVal value As String)
            _Measure_Time = value
        End Set
    End Property


    Public Property Latest_Height() As String
        Get
            Return _Latest_Height
        End Get
        Set(ByVal value As String)
            _Latest_Height = value
        End Set
    End Property

    Public Property Latest_Weight() As String
        Get
            Return _Latest_Weight
        End Get
        Set(ByVal value As String)
            _Latest_Weight = value
        End Set
    End Property

    Public Property Mis_Register_Date1() As String
        Get
            Return _Mis_Register_Date1
        End Get
        Set(ByVal value As String)
            _Mis_Register_Date1 = value
        End Set
    End Property

    Public Property Mis_Register_Date2() As String
        Get
            Return _Mis_Register_Date2
        End Get
        Set(ByVal value As String)
            _Mis_Register_Date2 = value
        End Set
    End Property

    Public Property Mis_Register_Date3() As String
        Get
            Return _Mis_Register_Date3
        End Get
        Set(ByVal value As String)
            _Mis_Register_Date3 = value
        End Set
    End Property

    Public Property Mis_Register_Times() As String
        Get
            Return _Mis_Register_Times
        End Get
        Set(ByVal value As String)
            _Mis_Register_Times = value
        End Set
    End Property

    Public Property Mis_Register_End_Date() As String
        Get
            Return _Mis_Register_End_Date
        End Get
        Set(ByVal value As String)
            _Mis_Register_End_Date = value
        End Set
    End Property

    Public Property Is_Death() As String
        Get
            Return _Is_Death
        End Get
        Set(ByVal value As String)
            _Is_Death = value
        End Set
    End Property

    Public Property Death_Time() As String
        Get
            Return _Death_Time
        End Get
        Set(ByVal value As String)
            _Death_Time = value
        End Set
    End Property

    Public Property Is_Chart_Divide() As String
        Get
            Return _Is_Chart_Divide
        End Get
        Set(ByVal value As String)
            _Is_Chart_Divide = value
        End Set
    End Property

    Public Property Is_Chart_Image() As String
        Get
            Return _Is_Chart_Image
        End Get
        Set(ByVal value As String)
            _Is_Chart_Image = value
        End Set
    End Property

    Public Property Patient_Memo() As String
        Get
            Return _Patient_Memo
        End Get
        Set(ByVal value As String)
            _Patient_Memo = value
        End Set
    End Property

    Public Property Is_Employee() As String
        Get
            Return _Is_Employee
        End Get
        Set(ByVal value As String)
            _Is_Employee = value
        End Set
    End Property


    Public Property Reserve_Chart_No() As String
        Get
            Return _Reserve_Chart_No
        End Get
        Set(ByVal value As String)
            _Reserve_Chart_No = value
        End Set
    End Property
    Public Property Latest_LMP_Date() As String
        Get
            Return _Latest_LMP_Date
        End Get
        Set(ByVal value As String)
            _Latest_LMP_Date = value
        End Set
    End Property


    Public Property LIS_Blood_Report() As String
        Get
            Return _LIS_Blood_Report
        End Get
        Set(ByVal value As String)
            _LIS_Blood_Report = value
        End Set
    End Property


    Public Property LIS_Blood_Report_Time() As String
        Get
            Return _LIS_Blood_Report_Time
        End Get
        Set(ByVal value As String)
            _LIS_Blood_Report_Time = value
        End Set
    End Property

    Public Property LIS_BMT_Mark() As String
        Get
            Return _LIS_BMT_Mark
        End Get
        Set(ByVal value As String)
            _LIS_BMT_Mark = value
        End Set
    End Property


    Public Property Student_Id() As String
        Get
            Return _Student_Id
        End Get
        Set(ByVal value As String)
            _Student_Id = value
        End Set
    End Property


    Public Property Create_User() As String
        Get
            Return _Create_User
        End Get
        Set(ByVal value As String)
            _Create_User = value
        End Set
    End Property

    Public Property Create_Time() As String
        Get
            Return _Create_Time
        End Get
        Set(ByVal value As String)
            _Create_Time = value
        End Set
    End Property

    Public Property Modified_User() As String
        Get
            Return _Modified_User
        End Get
        Set(ByVal value As String)
            _Modified_User = value
        End Set
    End Property

    Public Property Modified_Time() As String
        Get
            Return _Modified_Time
        End Get
        Set(ByVal value As String)
            _Modified_Time = value
        End Set
    End Property


    Public Property Reg_Notify_Id() As String
        Get
            Return _Reg_Notify_Id
        End Get
        Set(ByVal value As String)
            _Reg_Notify_Id = value
        End Set
    End Property
 

    Public Property Register_Dist_Code() As String
        Get
            Return _Register_Dist_Code
        End Get
        Set(ByVal value As String)
            _Register_Dist_Code = value
        End Set
    End Property

    Public Property Register_Vil_Code() As String
        Get
            Return _Register_Vil_Code
        End Get
        Set(ByVal value As String)
            _Register_Vil_Code = value
        End Set
    End Property

    Public Property Dist_Code() As String
        Get
            Return _Dist_Code
        End Get
        Set(ByVal value As String)
            _Dist_Code = value
        End Set
    End Property

    Public Property Vil_Code() As String
        Get
            Return _Vil_Code
        End Get
        Set(ByVal value As String)
            _Vil_Code = value
        End Set
    End Property

    Public Property Dist_Code2() As String
        Get
            Return _Dist_Code2
        End Get
        Set(ByVal value As String)
            _Dist_Code2 = value
        End Set
    End Property

    Public Property Vil_Code2() As String
        Get
            Return _Vil_Code2
        End Get
        Set(ByVal value As String)
            _Vil_Code2 = value
        End Set
    End Property


#End Region


    Private Shared instance As New UCLPatientData

    Public Shared Function getInstance() As UCLPatientData
        Return instance
    End Function


    Public Overloads Sub SetDB(ByVal Patient As DataSet)
        'ds.Reset()
        'ds = dsDB.Copy()
        PatientDS = Patient
        '  Console.WriteLine("Name2=>" & PatientDS.Tables(0).Rows(0).Item(1))
        SetData()

    End Sub

    Public Overloads Sub SetDB(ByVal Patient As DataSet, ByVal PatientFlag As DataSet, ByVal PatientDisDS As DataSet, ByVal PatientSevereDisDS As DataSet)
        'ds.Reset()
        'ds = dsDB.Copy()
        PatientDS = Patient
        ' Console.WriteLine("Name2=>" & PatientDS.Tables(0).Rows(0).Item(1))
        SetData()

    End Sub


    Public Sub Clear()
        PatientDS = Nothing
        PatientFlagDS = Nothing
        PatientDisDS = Nothing
        PatientSevereDisDS = Nothing

        Chart_No = ""
        Patient_Name = ""
        Patient_Short_Name = ""
        Patient_En_Name = ""
        Idno_Type_Id = ""
        Idno = ""
        Birth_Date = ""
        Sex_Id = ""
        Blood_Type_Id = ""
        Education_Id = ""
        Marriage_Id = ""
        Job_Id = ""
        Nationality_Id = ""
        Race_Id = ""
        Area_Code = ""
        Register_Postal_Code = ""
        Register_Address = ""
        Postal_Code = ""
        Address = ""
        Tel_Home = ""
        Tel_Office = ""
        Tel_Mobile = ""
        Fax = ""
        Email = ""
        Postal_Code2 = ""
        Address2 = ""
        Tel2 = ""
        Tel2_Mobile = ""
        Email2 = ""
        First_Visit_Date = ""
        Latest_Visit_Date = ""
        Latest_Admission_Date = ""
        Latest_Discharge_Date = ""
        Ipd_Times = ""
        Latest_Xray_Date = ""
        Latest_CT_Date = ""
        Arrears_Times = ""
        Opd_Arrears_Amt = ""
        Emg_Arrears_Amt = ""
        Ipd_Arrears_Amt = ""
        Measure_Time = ""
        Latest_Height = ""
        Latest_Weight = ""
        Mis_Register_Date1 = ""
        Mis_Register_Date2 = ""
        Mis_Register_Date3 = ""
        Mis_Register_Times = ""
        Mis_Register_End_Date = ""
        Is_Death = ""
        Death_Time = ""
        Is_Chart_Divide = ""
        Is_Chart_Image = ""
        Patient_Memo = ""
        Is_Employee = ""
        Create_User = ""
        Create_Time = ""
        Modified_User = ""
        Modified_Time = ""
        Reserve_Chart_No = ""
        Latest_LMP_Date = ""
        LIS_Blood_Report = ""
        LIS_Blood_Report_Time = ""
        LIS_BMT_Mark = ""

        Student_Id = ""

        Visit_Type = Visit.First_Hos
        Is_IPD = ""
        Is_EMG = ""
        Reg_Notify_Id = ""
        Register_Dist_Code = ""
        Register_Vil_Code = ""
        Dist_Code = ""
        Vil_Code = ""
        Dist_Code2 = ""
        Vil_Code2 = ""

    End Sub

    Public Sub SetData()
        Try


            If PatientDS.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To PatientDS.Tables(0).Columns.Count - 1

                    If PatientDS.Tables(0).Rows(0).Item(i) Is Nothing Then
                        PatientDS.Tables(0).Rows(0).Item(i) = ""
                    End If
                Next


                Chart_No = PatientDS.Tables(0).Rows(0).Item("Chart_No").ToString().Trim()

                Patient_Name = PatientDS.Tables(0).Rows(0).Item("Patient_Name").ToString().Trim()

                Patient_Short_Name = PatientDS.Tables(0).Rows(0).Item("Patient_Short_Name").ToString().Trim()


                Patient_En_Name = PatientDS.Tables(0).Rows(0).Item("Patient_En_Name").ToString().Trim()

                Idno_Type_Id = PatientDS.Tables(0).Rows(0).Item("Idno_Type_Id").ToString().Trim()

                Idno = PatientDS.Tables(0).Rows(0).Item("Idno").ToString().Trim()

                Birth_Date = Syscom.Comm.Utility.DateUtil.transDateToString(PatientDS.Tables(0).Rows(0).Item("Birth_Date"))

                Sex_Id = PatientDS.Tables(0).Rows(0).Item("Sex_Id").ToString().Trim()

                Blood_Type_Id = PatientDS.Tables(0).Rows(0).Item("Blood_Type_Id").ToString().Trim()

                Education_Id = PatientDS.Tables(0).Rows(0).Item("Education_Id").ToString().Trim()

                Marriage_Id = PatientDS.Tables(0).Rows(0).Item("Marriage_Id").ToString().Trim()

                Job_Id = PatientDS.Tables(0).Rows(0).Item("Job_Id").ToString().Trim()

                Nationality_Id = PatientDS.Tables(0).Rows(0).Item("Nationality_Id").ToString().Trim()

                Race_Id = PatientDS.Tables(0).Rows(0).Item("Race_Id").ToString().Trim()

                Area_Code = PatientDS.Tables(0).Rows(0).Item("Area_Code").ToString().Trim()

                Register_Postal_Code = PatientDS.Tables(0).Rows(0).Item("Register_Postal_Code").ToString().Trim()

                Register_Address = PatientDS.Tables(0).Rows(0).Item("Register_Address").ToString().Trim()

                Postal_Code = PatientDS.Tables(0).Rows(0).Item("Postal_Code").ToString().Trim()

                Address = PatientDS.Tables(0).Rows(0).Item("Address").ToString().Trim()

                Tel_Home = PatientDS.Tables(0).Rows(0).Item("Tel_Home").ToString().Trim()

                Tel_Office = PatientDS.Tables(0).Rows(0).Item("Tel_Office").ToString().Trim()

                Tel_Mobile = PatientDS.Tables(0).Rows(0).Item("Tel_Mobile").ToString().Trim()

                Fax = PatientDS.Tables(0).Rows(0).Item("Fax").ToString().Trim()

                Email = PatientDS.Tables(0).Rows(0).Item("Email").ToString().Trim()

                Postal_Code2 = PatientDS.Tables(0).Rows(0).Item("Postal_Code2").ToString().Trim()

                Address2 = PatientDS.Tables(0).Rows(0).Item("Address2").ToString().Trim()

                Tel2 = PatientDS.Tables(0).Rows(0).Item("Tel2").ToString().Trim()

                Tel2_Mobile = PatientDS.Tables(0).Rows(0).Item("Tel2_Mobile").ToString().Trim()

                Email2 = PatientDS.Tables(0).Rows(0).Item("Email2").ToString().Trim()

                First_Visit_Date = PatientDS.Tables(0).Rows(0).Item("First_Visit_Date").ToString().Trim()

                Latest_Visit_Date = PatientDS.Tables(0).Rows(0).Item("Latest_Visit_Date").ToString().Trim()

                Latest_Admission_Date = PatientDS.Tables(0).Rows(0).Item("Latest_Admission_Date").ToString().Trim()

                Latest_Discharge_Date = PatientDS.Tables(0).Rows(0).Item("Latest_Discharge_Date").ToString().Trim()

                Ipd_Times = PatientDS.Tables(0).Rows(0).Item("Ipd_Times").ToString().Trim()

                Latest_Xray_Date = PatientDS.Tables(0).Rows(0).Item("Latest_Xray_Date").ToString().Trim()

                Latest_CT_Date = PatientDS.Tables(0).Rows(0).Item("Latest_CT_Date").ToString().Trim()

                Arrears_Times = PatientDS.Tables(0).Rows(0).Item("Arrears_Times").ToString().Trim()

                Opd_Arrears_Amt = PatientDS.Tables(0).Rows(0).Item("Opd_Arrears_Amt").ToString().Trim()

                Emg_Arrears_Amt = PatientDS.Tables(0).Rows(0).Item("Emg_Arrears_Amt").ToString().Trim()

                Ipd_Arrears_Amt = PatientDS.Tables(0).Rows(0).Item("Ipd_Arrears_Amt").ToString().Trim()

                Measure_Time = PatientDS.Tables(0).Rows(0).Item("Measure_Time").ToString().Trim()

                Latest_Height = PatientDS.Tables(0).Rows(0).Item("Latest_Height").ToString().Trim()

                Latest_Weight = PatientDS.Tables(0).Rows(0).Item("Latest_Weight").ToString().Trim()

                Mis_Register_Date1 = PatientDS.Tables(0).Rows(0).Item("Mis_Register_Date1").ToString().Trim()

                Mis_Register_Date2 = PatientDS.Tables(0).Rows(0).Item("Mis_Register_Date2").ToString().Trim()

                Mis_Register_Date3 = PatientDS.Tables(0).Rows(0).Item("Mis_Register_Date3").ToString().Trim()

                Mis_Register_Times = PatientDS.Tables(0).Rows(0).Item("Mis_Register_Times").ToString().Trim()

                Mis_Register_End_Date = PatientDS.Tables(0).Rows(0).Item("Mis_Register_End_Date").ToString().Trim()

                Is_Death = PatientDS.Tables(0).Rows(0).Item("Is_Death").ToString().Trim()

                Death_Time = PatientDS.Tables(0).Rows(0).Item("Death_Time").ToString().Trim()

                Is_Chart_Divide = PatientDS.Tables(0).Rows(0).Item("Is_Chart_Divide").ToString().Trim()

                Is_Chart_Image = PatientDS.Tables(0).Rows(0).Item("Is_Chart_Image").ToString().Trim()

                Patient_Memo = PatientDS.Tables(0).Rows(0).Item("Patient_Memo").ToString().Trim()

                Is_Employee = PatientDS.Tables(0).Rows(0).Item("Is_Employee").ToString().Trim()

                Reserve_Chart_No = PatientDS.Tables(0).Rows(0).Item("Reserve_Chart_No").ToString().Trim()

                Latest_LMP_Date = PatientDS.Tables(0).Rows(0).Item("Latest_LMP_Date").ToString().Trim()

                LIS_Blood_Report = PatientDS.Tables(0).Rows(0).Item("LIS_Blood_Report").ToString().Trim()

                LIS_Blood_Report_Time = PatientDS.Tables(0).Rows(0).Item("LIS_Blood_Report_Time").ToString().Trim()

                LIS_BMT_Mark = PatientDS.Tables(0).Rows(0).Item("LIS_BMT_Mark").ToString().Trim()


                Student_Id = PatientDS.Tables(0).Rows(0).Item("Student_Id").ToString().Trim()

                Create_User = PatientDS.Tables(0).Rows(0).Item("Create_User").ToString().Trim()

                Create_Time = PatientDS.Tables(0).Rows(0).Item("Create_Time").ToString().Trim()

                Modified_User = PatientDS.Tables(0).Rows(0).Item("Modified_User").ToString().Trim()

                Modified_Time = PatientDS.Tables(0).Rows(0).Item("Modified_Time").ToString().Trim()

                Is_IPD = PatientDS.Tables(0).Rows(0).Item("Is_IPD").ToString().Trim()
                Is_EMG = PatientDS.Tables(0).Rows(0).Item("Is_EMG").ToString().Trim()

                Reg_Notify_Id = PatientDS.Tables(0).Rows(0).Item("Reg_Notify_Id").ToString().Trim()
                Register_Dist_Code = PatientDS.Tables(0).Rows(0).Item("Register_Dist_Code").ToString().Trim()
                Register_Vil_Code = PatientDS.Tables(0).Rows(0).Item("Register_Vil_Code").ToString().Trim()
                Dist_Code = PatientDS.Tables(0).Rows(0).Item("Dist_Code").ToString().Trim()
                Vil_Code = PatientDS.Tables(0).Rows(0).Item("Vil_Code").ToString().Trim()
                Dist_Code2 = PatientDS.Tables(0).Rows(0).Item("Dist_Code2").ToString().Trim()
                Vil_Code2 = PatientDS.Tables(0).Rows(0).Item("Vil_Code2").ToString().Trim()


            End If
        Catch ex As Exception
            Console.WriteLine(ex.ToString)   'nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

End Class
