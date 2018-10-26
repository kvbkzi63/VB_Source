Imports System.Data.SqlClient
Public Class PubDiseaseIcd10DataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2017/1/19 下午 05:37:06
    Public Shared ReadOnly tableName As String = "PUB_Disease_ICD10"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Effect_Date", "Icd_Code", "Disease_Type_Id", "Disease_En_Name", "Disease_Name", _
             "Disease_En_Short_Name", "Disease_Short_Name", "Disease_Hosp_Name", "Majorcare_Code", "Limit_Sex_Id", _
             "Infection_Type_Id", "Limit_Age", "Age_Start_Year", "Age_Start_Month", "Age_Start_Day", _
             "Age_End_Year", "Age_End_Month", "Age_End_Day", "Is_Exclude_Labdiscount", "Is_Chronic_Disease", _
             "Is_Severe_Disease", "Is_Psy_Severe_Disease", "Is_Rare_Diseases", "Is_AIDS", "Is_Major_P", _
             "Is_Minor_P", "Is_Mcc", "Is_Cc", "Main_Diagnosis_Id", "Is_Opd", _
             "Is_Emg", "Is_Ipd", "Pip_Type_Id", "Is_Occ_Injury", "Is_Pre5_Diagnosis", _
             "Is_Hem_Original_Disease", "Dc", "End_Date", "Is_Or", "Is_Drg", _
             "Is_Detail", "ICD10_Chapter_Id", "Severe_Disase_Id", "Rare_Disease_Id", "Chronic_Disease_Id", _
             "Create_User", "Create_Time", "Modified_User", "Modified_Time", "Icd_Code_Nodot", _
             "Is_End_Flag"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.DateTime", "System.String", "System.String", "System.String", "System.String", _
             "System.String", "System.String", "System.String", "System.String", "System.String", _
             "System.String", "System.String", "System.Int32", "System.Int32", "System.Int32", _
             "System.Int32", "System.Int32", "System.Int32", "System.String", "System.String", _
             "System.String", "System.String", "System.String", "System.String", "System.String", _
             "System.String", "System.String", "System.String", "System.String", "System.String", _
             "System.String", "System.String", "System.String", "System.String", "System.String", _
             "System.String", "System.String", "System.DateTime", "System.String", "System.String", _
             "System.String", "System.String", "System.String", "System.String", "System.String", _
             "System.String", "System.DateTime", "System.String", "System.DateTime", "System.String", _
             "System.String"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             -1, 10, 5, 300, 300, _
             100, 100, 300, 2, 5, _
             5, 10, -1, -1, -1, _
             -1, -1, -1, 1, 1, _
             1, 1, 1, 1, 1, _
             1, 1, 1, 5, 1, _
             1, 1, 5, 1, 1, _
             1, 1, -1, 1, 1, _
             1, 5, 5, 5, 5, _
             10, -1, 10, -1, 10, _
             1}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub example()
        Dim dataSet As DataSet = New DataSet
        Dim dataTable As DataTable = PubDiseaseIcd10DataTableFactory.getDataTableWithSchema
        Dim dataRow As DataRow = dataTable.NewRow()
        '使用自己的資料來源取代 New Object 
        dataRow("Effect_Date") = New Object
        dataRow("Icd_Code") = New Object
        dataRow("Disease_Type_Id") = New Object
        dataRow("Disease_En_Name") = New Object
        dataRow("Disease_Name") = New Object
        dataRow("Disease_En_Short_Name") = New Object
        dataRow("Disease_Short_Name") = New Object
        dataRow("Disease_Hosp_Name") = New Object
        dataRow("Majorcare_Code") = New Object
        dataRow("Limit_Sex_Id") = New Object
        dataRow("Infection_Type_Id") = New Object
        dataRow("Limit_Age") = New Object
        dataRow("Age_Start_Year") = New Object
        dataRow("Age_Start_Month") = New Object
        dataRow("Age_Start_Day") = New Object
        dataRow("Age_End_Year") = New Object
        dataRow("Age_End_Month") = New Object
        dataRow("Age_End_Day") = New Object
        dataRow("Is_Exclude_Labdiscount") = New Object
        dataRow("Is_Chronic_Disease") = New Object
        dataRow("Is_Severe_Disease") = New Object
        dataRow("Is_Psy_Severe_Disease") = New Object
        dataRow("Is_Rare_Diseases") = New Object
        dataRow("Is_AIDS") = New Object
        dataRow("Is_Major_P") = New Object
        dataRow("Is_Minor_P") = New Object
        dataRow("Is_Mcc") = New Object
        dataRow("Is_Cc") = New Object
        dataRow("Main_Diagnosis_Id") = New Object
        dataRow("Is_Opd") = New Object
        dataRow("Is_Emg") = New Object
        dataRow("Is_Ipd") = New Object
        dataRow("Pip_Type_Id") = New Object
        dataRow("Is_Occ_Injury") = New Object
        dataRow("Is_Pre5_Diagnosis") = New Object
        dataRow("Is_Hem_Original_Disease") = New Object
        dataRow("Dc") = New Object
        dataRow("End_Date") = New Object
        dataRow("Is_Or") = New Object
        dataRow("Is_Drg") = New Object
        dataRow("Is_Detail") = New Object
        dataRow("ICD10_Chapter_Id") = New Object
        dataRow("Severe_Disase_Id") = New Object
        dataRow("Rare_Disease_Id") = New Object
        dataRow("Chronic_Disease_Id") = New Object
        dataRow("Create_User") = New Object
        dataRow("Create_Time") = New Object
        dataRow("Modified_User") = New Object
        dataRow("Modified_Time") = New Object
        dataRow("Icd_Code_Nodot") = New Object
        dataRow("Is_End_Flag") = New Object
        dataTable.Rows.Add(dataRow)
        dataSet.Tables.Add(dataTable)
    End Sub

    ''' <summary>
    '''取得資料庫表格的 DataTable
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Function getDataTable() As DataTable
        Try
            Dim dt As DataTable = New DataTable(tableName)
            dt.Columns.Add("Effect_Date")
            dt.Columns.Add("Icd_Code")
            dt.Columns.Add("Disease_Type_Id")
            dt.Columns.Add("Disease_En_Name")
            dt.Columns.Add("Disease_Name")
            dt.Columns.Add("Disease_En_Short_Name")
            dt.Columns.Add("Disease_Short_Name")
            dt.Columns.Add("Disease_Hosp_Name")
            dt.Columns.Add("Majorcare_Code")
            dt.Columns.Add("Limit_Sex_Id")
            dt.Columns.Add("Infection_Type_Id")
            dt.Columns.Add("Limit_Age")
            dt.Columns.Add("Age_Start_Year")
            dt.Columns.Add("Age_Start_Month")
            dt.Columns.Add("Age_Start_Day")
            dt.Columns.Add("Age_End_Year")
            dt.Columns.Add("Age_End_Month")
            dt.Columns.Add("Age_End_Day")
            dt.Columns.Add("Is_Exclude_Labdiscount")
            dt.Columns.Add("Is_Chronic_Disease")
            dt.Columns.Add("Is_Severe_Disease")
            dt.Columns.Add("Is_Psy_Severe_Disease")
            dt.Columns.Add("Is_Rare_Diseases")
            dt.Columns.Add("Is_AIDS")
            dt.Columns.Add("Is_Major_P")
            dt.Columns.Add("Is_Minor_P")
            dt.Columns.Add("Is_Mcc")
            dt.Columns.Add("Is_Cc")
            dt.Columns.Add("Main_Diagnosis_Id")
            dt.Columns.Add("Is_Opd")
            dt.Columns.Add("Is_Emg")
            dt.Columns.Add("Is_Ipd")
            dt.Columns.Add("Pip_Type_Id")
            dt.Columns.Add("Is_Occ_Injury")
            dt.Columns.Add("Is_Pre5_Diagnosis")
            dt.Columns.Add("Is_Hem_Original_Disease")
            dt.Columns.Add("Dc")
            dt.Columns.Add("End_Date")
            dt.Columns.Add("Is_Or")
            dt.Columns.Add("Is_Drg")
            dt.Columns.Add("Is_Detail")
            dt.Columns.Add("ICD10_Chapter_Id")
            dt.Columns.Add("Severe_Disase_Id")
            dt.Columns.Add("Rare_Disease_Id")
            dt.Columns.Add("Chronic_Disease_Id")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            dt.Columns.Add("Icd_Code_Nodot")
            dt.Columns.Add("Is_End_Flag")
            Dim pkColArray(2) As DataColumn
            pkColArray(0) = dt.Columns("Effect_Date")
            pkColArray(1) = dt.Columns("Icd_Code")
            pkColArray(2) = dt.Columns("Disease_Type_Id")
            dt.PrimaryKey = pkColArray
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    '''取得資料庫表格的 DataTable 加上各欄位的資料型態
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Function getDataTableWithSchema() As DataTable
        Try
            Dim dt As DataTable = New DataTable(tableName)
            dt.Columns.Add("Effect_Date")
            dt.Columns("Effect_Date").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Icd_Code")
            dt.Columns("Icd_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Disease_Type_Id")
            dt.Columns("Disease_Type_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Disease_En_Name")
            dt.Columns("Disease_En_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Disease_Name")
            dt.Columns("Disease_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Disease_En_Short_Name")
            dt.Columns("Disease_En_Short_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Disease_Short_Name")
            dt.Columns("Disease_Short_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Disease_Hosp_Name")
            dt.Columns("Disease_Hosp_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Majorcare_Code")
            dt.Columns("Majorcare_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Limit_Sex_Id")
            dt.Columns("Limit_Sex_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Infection_Type_Id")
            dt.Columns("Infection_Type_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Limit_Age")
            dt.Columns("Limit_Age").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Age_Start_Year")
            dt.Columns("Age_Start_Year").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Age_Start_Month")
            dt.Columns("Age_Start_Month").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Age_Start_Day")
            dt.Columns("Age_Start_Day").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Age_End_Year")
            dt.Columns("Age_End_Year").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Age_End_Month")
            dt.Columns("Age_End_Month").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Age_End_Day")
            dt.Columns("Age_End_Day").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Is_Exclude_Labdiscount")
            dt.Columns("Is_Exclude_Labdiscount").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Chronic_Disease")
            dt.Columns("Is_Chronic_Disease").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Severe_Disease")
            dt.Columns("Is_Severe_Disease").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Psy_Severe_Disease")
            dt.Columns("Is_Psy_Severe_Disease").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Rare_Diseases")
            dt.Columns("Is_Rare_Diseases").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_AIDS")
            dt.Columns("Is_AIDS").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Major_P")
            dt.Columns("Is_Major_P").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Minor_P")
            dt.Columns("Is_Minor_P").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Mcc")
            dt.Columns("Is_Mcc").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Cc")
            dt.Columns("Is_Cc").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Main_Diagnosis_Id")
            dt.Columns("Main_Diagnosis_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Opd")
            dt.Columns("Is_Opd").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Emg")
            dt.Columns("Is_Emg").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Ipd")
            dt.Columns("Is_Ipd").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Pip_Type_Id")
            dt.Columns("Pip_Type_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Occ_Injury")
            dt.Columns("Is_Occ_Injury").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Pre5_Diagnosis")
            dt.Columns("Is_Pre5_Diagnosis").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Hem_Original_Disease")
            dt.Columns("Is_Hem_Original_Disease").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Dc")
            dt.Columns("Dc").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("End_Date")
            dt.Columns("End_Date").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Is_Or")
            dt.Columns("Is_Or").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Drg")
            dt.Columns("Is_Drg").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Detail")
            dt.Columns("Is_Detail").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("ICD10_Chapter_Id")
            dt.Columns("ICD10_Chapter_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Severe_Disase_Id")
            dt.Columns("Severe_Disase_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Rare_Disease_Id")
            dt.Columns("Rare_Disease_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Chronic_Disease_Id")
            dt.Columns("Chronic_Disease_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_User")
            dt.Columns("Create_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_Time")
            dt.Columns("Create_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Modified_User")
            dt.Columns("Modified_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Modified_Time")
            dt.Columns("Modified_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Icd_Code_Nodot")
            dt.Columns("Icd_Code_Nodot").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_End_Flag")
            dt.Columns("Is_End_Flag").DataType = System.Type.GetType("System.String")
            Dim pkColArray(2) As DataColumn
            pkColArray(0) = dt.Columns("Effect_Date")
            pkColArray(1) = dt.Columns("Icd_Code")
            pkColArray(2) = dt.Columns("Disease_Type_Id")
            dt.PrimaryKey = pkColArray
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    '''取得資料庫表格的 DataTable - 不指定PK
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Function getDataTableWithNoPK() As DataTable
        Try
            Dim dt As DataTable = New DataTable(tableName)
            dt.Columns.Add("Effect_Date")
            dt.Columns.Add("Icd_Code")
            dt.Columns.Add("Disease_Type_Id")
            dt.Columns.Add("Disease_En_Name")
            dt.Columns.Add("Disease_Name")
            dt.Columns.Add("Disease_En_Short_Name")
            dt.Columns.Add("Disease_Short_Name")
            dt.Columns.Add("Disease_Hosp_Name")
            dt.Columns.Add("Majorcare_Code")
            dt.Columns.Add("Limit_Sex_Id")
            dt.Columns.Add("Infection_Type_Id")
            dt.Columns.Add("Limit_Age")
            dt.Columns.Add("Age_Start_Year")
            dt.Columns.Add("Age_Start_Month")
            dt.Columns.Add("Age_Start_Day")
            dt.Columns.Add("Age_End_Year")
            dt.Columns.Add("Age_End_Month")
            dt.Columns.Add("Age_End_Day")
            dt.Columns.Add("Is_Exclude_Labdiscount")
            dt.Columns.Add("Is_Chronic_Disease")
            dt.Columns.Add("Is_Severe_Disease")
            dt.Columns.Add("Is_Psy_Severe_Disease")
            dt.Columns.Add("Is_Rare_Diseases")
            dt.Columns.Add("Is_AIDS")
            dt.Columns.Add("Is_Major_P")
            dt.Columns.Add("Is_Minor_P")
            dt.Columns.Add("Is_Mcc")
            dt.Columns.Add("Is_Cc")
            dt.Columns.Add("Main_Diagnosis_Id")
            dt.Columns.Add("Is_Opd")
            dt.Columns.Add("Is_Emg")
            dt.Columns.Add("Is_Ipd")
            dt.Columns.Add("Pip_Type_Id")
            dt.Columns.Add("Is_Occ_Injury")
            dt.Columns.Add("Is_Pre5_Diagnosis")
            dt.Columns.Add("Is_Hem_Original_Disease")
            dt.Columns.Add("Dc")
            dt.Columns.Add("End_Date")
            dt.Columns.Add("Is_Or")
            dt.Columns.Add("Is_Drg")
            dt.Columns.Add("Is_Detail")
            dt.Columns.Add("ICD10_Chapter_Id")
            dt.Columns.Add("Severe_Disase_Id")
            dt.Columns.Add("Rare_Disease_Id")
            dt.Columns.Add("Chronic_Disease_Id")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            dt.Columns.Add("Icd_Code_Nodot")
            dt.Columns.Add("Is_End_Flag")
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    '''取得資料庫表格的 DataSet
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Function getDataSet() As DataSet
        Try
            Dim ds As DataSet = New DataSet

            Dim dt As Datatable = getDataTable()

            ds.Tables.Add(dt)

            Return ds
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    '''取得資料庫表格的 DataSet 加上各欄位的資料型態
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Function getDataSetWithSchema() As DataSet
        Try
            Dim ds As DataSet = New DataSet

            Dim dt As Datatable = getDataTableWithSchema()

            ds.Tables.Add(dt)

            Return ds
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    '''取得資料庫表格的 DataSet - 不指定PK
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Function getDataSetWithNoPK() As DataSet
        Try
            Dim ds As DataSet = New DataSet

            Dim dt As Datatable = getDataTableWithNoPK()

            ds.Tables.Add(dt)

            Return ds
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Class PUBDiseaseICD10Pt
        Private m_Effect_Date As String = "Effect_Date"
        Public ReadOnly Property Effect_Date() As System.String
            Get
                Return m_Effect_Date
            End Get
        End Property

        Private m_Icd_Code As String = "Icd_Code"
        Public ReadOnly Property Icd_Code() As System.String
            Get
                Return m_Icd_Code
            End Get
        End Property

        Private m_Disease_Type_Id As String = "Disease_Type_Id"
        Public ReadOnly Property Disease_Type_Id() As System.String
            Get
                Return m_Disease_Type_Id
            End Get
        End Property

        Private m_Disease_En_Name As String = "Disease_En_Name"
        Public ReadOnly Property Disease_En_Name() As System.String
            Get
                Return m_Disease_En_Name
            End Get
        End Property

        Private m_Disease_Name As String = "Disease_Name"
        Public ReadOnly Property Disease_Name() As System.String
            Get
                Return m_Disease_Name
            End Get
        End Property

        Private m_Disease_En_Short_Name As String = "Disease_En_Short_Name"
        Public ReadOnly Property Disease_En_Short_Name() As System.String
            Get
                Return m_Disease_En_Short_Name
            End Get
        End Property

        Private m_Disease_Short_Name As String = "Disease_Short_Name"
        Public ReadOnly Property Disease_Short_Name() As System.String
            Get
                Return m_Disease_Short_Name
            End Get
        End Property

        Private m_Disease_Hosp_Name As String = "Disease_Hosp_Name"
        Public ReadOnly Property Disease_Hosp_Name() As System.String
            Get
                Return m_Disease_Hosp_Name
            End Get
        End Property

        Private m_Majorcare_Code As String = "Majorcare_Code"
        Public ReadOnly Property Majorcare_Code() As System.String
            Get
                Return m_Majorcare_Code
            End Get
        End Property

        Private m_Limit_Sex_Id As String = "Limit_Sex_Id"
        Public ReadOnly Property Limit_Sex_Id() As System.String
            Get
                Return m_Limit_Sex_Id
            End Get
        End Property

        Private m_Infection_Type_Id As String = "Infection_Type_Id"
        Public ReadOnly Property Infection_Type_Id() As System.String
            Get
                Return m_Infection_Type_Id
            End Get
        End Property

        Private m_Limit_Age As String = "Limit_Age"
        Public ReadOnly Property Limit_Age() As System.String
            Get
                Return m_Limit_Age
            End Get
        End Property

        Private m_Age_Start_Year As String = "Age_Start_Year"
        Public ReadOnly Property Age_Start_Year() As System.String
            Get
                Return m_Age_Start_Year
            End Get
        End Property

        Private m_Age_Start_Month As String = "Age_Start_Month"
        Public ReadOnly Property Age_Start_Month() As System.String
            Get
                Return m_Age_Start_Month
            End Get
        End Property

        Private m_Age_Start_Day As String = "Age_Start_Day"
        Public ReadOnly Property Age_Start_Day() As System.String
            Get
                Return m_Age_Start_Day
            End Get
        End Property

        Private m_Age_End_Year As String = "Age_End_Year"
        Public ReadOnly Property Age_End_Year() As System.String
            Get
                Return m_Age_End_Year
            End Get
        End Property

        Private m_Age_End_Month As String = "Age_End_Month"
        Public ReadOnly Property Age_End_Month() As System.String
            Get
                Return m_Age_End_Month
            End Get
        End Property

        Private m_Age_End_Day As String = "Age_End_Day"
        Public ReadOnly Property Age_End_Day() As System.String
            Get
                Return m_Age_End_Day
            End Get
        End Property

        Private m_Is_Exclude_Labdiscount As String = "Is_Exclude_Labdiscount"
        Public ReadOnly Property Is_Exclude_Labdiscount() As System.String
            Get
                Return m_Is_Exclude_Labdiscount
            End Get
        End Property

        Private m_Is_Chronic_Disease As String = "Is_Chronic_Disease"
        Public ReadOnly Property Is_Chronic_Disease() As System.String
            Get
                Return m_Is_Chronic_Disease
            End Get
        End Property

        Private m_Is_Severe_Disease As String = "Is_Severe_Disease"
        Public ReadOnly Property Is_Severe_Disease() As System.String
            Get
                Return m_Is_Severe_Disease
            End Get
        End Property

        Private m_Is_Psy_Severe_Disease As String = "Is_Psy_Severe_Disease"
        Public ReadOnly Property Is_Psy_Severe_Disease() As System.String
            Get
                Return m_Is_Psy_Severe_Disease
            End Get
        End Property

        Private m_Is_Rare_Diseases As String = "Is_Rare_Diseases"
        Public ReadOnly Property Is_Rare_Diseases() As System.String
            Get
                Return m_Is_Rare_Diseases
            End Get
        End Property

        Private m_Is_AIDS As String = "Is_AIDS"
        Public ReadOnly Property Is_AIDS() As System.String
            Get
                Return m_Is_AIDS
            End Get
        End Property

        Private m_Is_Major_P As String = "Is_Major_P"
        Public ReadOnly Property Is_Major_P() As System.String
            Get
                Return m_Is_Major_P
            End Get
        End Property

        Private m_Is_Minor_P As String = "Is_Minor_P"
        Public ReadOnly Property Is_Minor_P() As System.String
            Get
                Return m_Is_Minor_P
            End Get
        End Property

        Private m_Is_Mcc As String = "Is_Mcc"
        Public ReadOnly Property Is_Mcc() As System.String
            Get
                Return m_Is_Mcc
            End Get
        End Property

        Private m_Is_Cc As String = "Is_Cc"
        Public ReadOnly Property Is_Cc() As System.String
            Get
                Return m_Is_Cc
            End Get
        End Property

        Private m_Main_Diagnosis_Id As String = "Main_Diagnosis_Id"
        Public ReadOnly Property Main_Diagnosis_Id() As System.String
            Get
                Return m_Main_Diagnosis_Id
            End Get
        End Property

        Private m_Is_Opd As String = "Is_Opd"
        Public ReadOnly Property Is_Opd() As System.String
            Get
                Return m_Is_Opd
            End Get
        End Property

        Private m_Is_Emg As String = "Is_Emg"
        Public ReadOnly Property Is_Emg() As System.String
            Get
                Return m_Is_Emg
            End Get
        End Property

        Private m_Is_Ipd As String = "Is_Ipd"
        Public ReadOnly Property Is_Ipd() As System.String
            Get
                Return m_Is_Ipd
            End Get
        End Property

        Private m_Pip_Type_Id As String = "Pip_Type_Id"
        Public ReadOnly Property Pip_Type_Id() As System.String
            Get
                Return m_Pip_Type_Id
            End Get
        End Property

        Private m_Is_Occ_Injury As String = "Is_Occ_Injury"
        Public ReadOnly Property Is_Occ_Injury() As System.String
            Get
                Return m_Is_Occ_Injury
            End Get
        End Property

        Private m_Is_Pre5_Diagnosis As String = "Is_Pre5_Diagnosis"
        Public ReadOnly Property Is_Pre5_Diagnosis() As System.String
            Get
                Return m_Is_Pre5_Diagnosis
            End Get
        End Property

        Private m_Is_Hem_Original_Disease As String = "Is_Hem_Original_Disease"
        Public ReadOnly Property Is_Hem_Original_Disease() As System.String
            Get
                Return m_Is_Hem_Original_Disease
            End Get
        End Property

        Private m_Dc As String = "Dc"
        Public ReadOnly Property Dc() As System.String
            Get
                Return m_Dc
            End Get
        End Property

        Private m_End_Date As String = "End_Date"
        Public ReadOnly Property End_Date() As System.String
            Get
                Return m_End_Date
            End Get
        End Property

        Private m_Is_Or As String = "Is_Or"
        Public ReadOnly Property Is_Or() As System.String
            Get
                Return m_Is_Or
            End Get
        End Property

        Private m_Is_Drg As String = "Is_Drg"
        Public ReadOnly Property Is_Drg() As System.String
            Get
                Return m_Is_Drg
            End Get
        End Property

        Private m_Is_Detail As String = "Is_Detail"
        Public ReadOnly Property Is_Detail() As System.String
            Get
                Return m_Is_Detail
            End Get
        End Property

        Private m_ICD10_Chapter_Id As String = "ICD10_Chapter_Id"
        Public ReadOnly Property ICD10_Chapter_Id() As System.String
            Get
                Return m_ICD10_Chapter_Id
            End Get
        End Property

        Private m_Severe_Disase_Id As String = "Severe_Disase_Id"
        Public ReadOnly Property Severe_Disase_Id() As System.String
            Get
                Return m_Severe_Disase_Id
            End Get
        End Property

        Private m_Rare_Disease_Id As String = "Rare_Disease_Id"
        Public ReadOnly Property Rare_Disease_Id() As System.String
            Get
                Return m_Rare_Disease_Id
            End Get
        End Property

        Private m_Chronic_Disease_Id As String = "Chronic_Disease_Id"
        Public ReadOnly Property Chronic_Disease_Id() As System.String
            Get
                Return m_Chronic_Disease_Id
            End Get
        End Property

        Private m_Create_User As String = "Create_User"
        Public ReadOnly Property Create_User() As System.String
            Get
                Return m_Create_User
            End Get
        End Property

        Private m_Create_Time As String = "Create_Time"
        Public ReadOnly Property Create_Time() As System.String
            Get
                Return m_Create_Time
            End Get
        End Property

        Private m_Modified_User As String = "Modified_User"
        Public ReadOnly Property Modified_User() As System.String
            Get
                Return m_Modified_User
            End Get
        End Property

        Private m_Modified_Time As String = "Modified_Time"
        Public ReadOnly Property Modified_Time() As System.String
            Get
                Return m_Modified_Time
            End Get
        End Property

        Private m_Icd_Code_Nodot As String = "Icd_Code_Nodot"
        Public ReadOnly Property Icd_Code_Nodot() As System.String
            Get
                Return m_Icd_Code_Nodot
            End Get
        End Property

        Private m_Is_End_Flag As String = "Is_End_Flag"
        Public ReadOnly Property Is_End_Flag() As System.String
            Get
                Return m_Is_End_Flag
            End Get
        End Property

    End Class

End Class
