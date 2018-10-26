
Imports System.Text
Imports System.Windows.Forms
Imports Syscom.Client.CMM
Imports Syscom.Client.Servicefactory
Imports Syscom.Comm.Utility

Public Class UCLOpenWindowMultiSelectUI



#Region "全域變數宣告"

    Public pvtQueryTable As Integer
    Public pvtQueryValue As String = ""
    Public keyIndex As Integer = -1
    Public selectedCodeStrArray As String()

    Dim selectedCodeStr As String = ""

    '  Dim uclCheckListBox As UCLCheckListBoxUI
    Dim WithEvents mgr As EventManager = EventManager.getInstance '宣告EventManager
    Dim uclOW As IUclServiceManager = UclServiceManager.getInstance
    Dim ctlName As String = ""
    Dim pvtStateFlag = True
    Dim pvtDS1, pvtDS2 As DataSet
    Public IsCheckDoctorOnDuty As Boolean = False



#End Region



    ''' <summary>
    ''' 初始化視窗資料
    ''' cName:Parent元件名稱
    ''' CodeSt:查詢代碼字串
    ''' tableName:查詢Table名稱
    ''' </summary>
    ''' <remarks></remarks>''' 
    Public Sub Initial(ByVal cName As String, ByVal CodeStr As String(), ByVal tableName As Integer, ByVal uclQueryValue As String)
        Try

            ctlName = cName

            pvtQueryTable = tableName
            If uclQueryValue IsNot Nothing Then
                pvtQueryValue = uclQueryValue
            Else
                pvtQueryValue = ""
            End If

            setInitData()
            selectedCodeStrArray = CodeStr
            'uclCheckListBox = partner

            If selectedCodeStrArray IsNot Nothing AndAlso selectedCodeStrArray.Count > 0 Then


                For i As Integer = 0 To selectedCodeStrArray.Count - 1
                    If i < selectedCodeStrArray.Count - 1 Then
                        selectedCodeStr += "'" & selectedCodeStrArray(i).Replace("'", "''") & "', "
                    Else
                        selectedCodeStr += "'" & selectedCodeStrArray(i) & "'  "
                    End If
                Next


                Select Case tableName
                    Case 1
                        pvtDS2 = uclOW.queryOpenWindow("101", " A.Employee_Code ", selectedCodeStr, " In ", Nothing)

                    Case 6
                        pvtDS2 = uclOW.queryOpenWindow("106", " Dept_Code ", selectedCodeStr, " In ", Nothing)


                    Case 14
                        pvtDS2 = uclOW.queryOpenWindow("114", "A.Order_Code ", selectedCodeStr, " In ", Nothing)


                    Case 18
                        pvtDS2 = uclOW.queryOpenWindow("18", "Code_Id ", selectedCodeStr, " In ", Nothing)


                    Case 19
                        pvtDS2 = uclOW.queryOpenWindow("191", "Class_Code ", selectedCodeStr, " In ", Nothing)

                    Case 22
                        pvtDS2 = uclOW.queryOpenWindow("221", "Code_Id ", selectedCodeStr, " In ", Nothing)

                    Case 23
                        pvtDS2 = uclOW.queryOpenWindow("231", "Code_Id ", selectedCodeStr, " In ", Nothing)

                    Case 24
                        pvtDS2 = uclOW.queryOpenWindow("241", "Code_Id ", selectedCodeStr, " In ", Nothing)

                    Case 25
                        pvtDS2 = uclOW.queryOpenWindow("251", "Code_Id ", selectedCodeStr, " In ", Nothing)

                    Case 26
                        pvtDS2 = uclOW.queryOpenWindow("261", "Code_Id ", selectedCodeStr, " In ", Nothing)

                    Case 31
                        pvtDS2 = uclOW.queryOpenWindow("311", "Dept_Code ", selectedCodeStr, " In ", Nothing)

                    Case 32
                        pvtDS2 = uclOW.queryOpenWindow("321", "Station_no ", selectedCodeStr, " In ", Nothing)


                    Case 20
                        'pvtDS2 = uclOW.queryOpenWindow("201", "Phrase_Code ", selectedCodeStr, " In ", Nothing)
                        QueryProcess()

                    Case 35
                        pvtDS2 = uclOW.queryOpenWindow("351", "Code_Id ", selectedCodeStr, " In ", Nothing)


                    Case 39
                        pvtDS2 = uclOW.queryOpenWindow("391", "Code_Id ", selectedCodeStr, " In ", Nothing)


                End Select
                ' Console.WriteLine(pvtDS2.Tables(0).Rows.Count.ToString())
                dgv2.Initial(pvtDS2)
            Else
                If tableName = 20 Then
                    QueryProcess()
                    pvtDS2 = New DataSet
                    pvtDS2.Tables.Add()
                    pvtDS2.Tables(0).Columns.Add("代碼")
                    pvtDS2.Tables(0).Columns.Add("名稱")

                    dgv2.Initial(pvtDS2)
                End If

            End If

            '  keyIndex = Index
            Me.ShowDialog()
        Catch ex As Exception
            Console.WriteLine(ex.ToString)   'nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    ''' <summary>
    ''' 設定初始化資料
    ''' </summary>
    ''' <remarks></remarks>''' 
    Private Sub setInitData()
        Dim pvtTable As New DataTable
        Dim pvtColumn As DataColumn
        Dim pvtRow As DataRow
        Me.KeyPreview = True '啟用才能觸發快速鍵功能     

        '設定[查詢欄位]下拉選項值
        Try


            If pvtStateFlag = True Then
                Select Case pvtQueryTable
                    Case 1
                        pvtTable.TableName = "PUB_Doctor"

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "Code"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "CodeName"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "A.Doctor_Code"
                        pvtRow("CodeName") = "醫師代碼"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "B.Employee_Name"
                        pvtRow("CodeName") = "醫師姓名"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "A.Employee_Code"
                        pvtRow("CodeName") = "員工編號"
                        pvtTable.Rows.Add(pvtRow)

                    Case 2
                        pvtTable.TableName = "PUB_Zone_Room"

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "Code"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "CodeName"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Room_Code"
                        pvtRow("CodeName") = "診間代碼"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Room_Name"
                        pvtRow("CodeName") = "診間名稱"
                        pvtTable.Rows.Add(pvtRow)

                    Case 3
                        pvtTable.TableName = "PUB_Patient"

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "Code"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "CodeName"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Chart_No"
                        pvtRow("CodeName") = "診間代碼"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Idno"
                        pvtRow("CodeName") = "証號"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Patient_Name"
                        pvtRow("CodeName") = "姓名"
                        pvtTable.Rows.Add(pvtRow)



                    Case 4
                        pvtTable.TableName = "PUB_Disease"

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "Code"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "CodeName"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "A.Icd_Code"
                        pvtRow("CodeName") = "疾病分類碼"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "A.Disease_En_Name"
                        pvtRow("CodeName") = "英文名稱"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "A.Disease_Name"
                        pvtRow("CodeName") = "中文名稱"
                        pvtTable.Rows.Add(pvtRow)

                    Case 5
                        pvtTable.TableName = "PUB_Order_Examination"

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "Code"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "CodeName"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "A.Order_Code"
                        pvtRow("CodeName") = "醫令項目代碼"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "B.Order_En_Name"
                        pvtRow("CodeName") = "英文名稱"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "B.Order_Name"
                        pvtRow("CodeName") = "中文名稱"
                        pvtTable.Rows.Add(pvtRow)

                    Case 6
                        pvtTable.TableName = "PUB_Department"

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "Code"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "CodeName"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Dept_Code"
                        pvtRow("CodeName") = "科別代碼"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Dept_Name"
                        pvtRow("CodeName") = "科別名稱"
                        pvtTable.Rows.Add(pvtRow)

                    Case 7
                        pvtTable.TableName = "PUB_Sheet"

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "Code"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "CodeName"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Sheet_Code"
                        pvtRow("CodeName") = "表單代碼"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Sheet_Name"
                        pvtRow("CodeName") = "表單名稱"
                        pvtTable.Rows.Add(pvtRow)


                    Case 8
                        pvtTable.TableName = "REF_Referral_Hospital"

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "Code"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "CodeName"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "A.Hospital_Code"
                        pvtRow("CodeName") = "醫院代碼"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "A.Hospital_Name"
                        pvtRow("CodeName") = "醫院名稱"
                        pvtTable.Rows.Add(pvtRow)

                    Case 9
                        pvtTable.TableName = "PUB_Order"

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "Code"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "CodeName"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "A.Order_Code"
                        pvtRow("CodeName") = "醫令項目代碼"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "B.Order_En_Name"
                        pvtRow("CodeName") = "英文名稱"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "B.Order_Name"
                        pvtRow("CodeName") = "中文名稱"
                        pvtTable.Rows.Add(pvtRow)


                    Case 10
                        pvtTable.TableName = "SCH_Apparatus"

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "Code"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "CodeName"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Apparatus_Code"
                        pvtRow("CodeName") = "儀器代碼"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Apparatus_Name"
                        pvtRow("CodeName") = "儀器名稱"
                        pvtTable.Rows.Add(pvtRow)

                    Case 14
                        pvtTable.TableName = "PUB_Order"

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "Code"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "CodeName"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "A.Order_Code"
                        pvtRow("CodeName") = "醫令項目代碼"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "A.Order_En_Name"
                        pvtRow("CodeName") = "英文名稱"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "A.Order_Name"
                        pvtRow("CodeName") = "中文名稱"
                        pvtTable.Rows.Add(pvtRow)

                    Case 18
                        pvtTable.TableName = "OPH_Code"

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "Code"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "CodeName"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Code_Id"
                        pvtRow("CodeName") = "代碼"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Code_Name"
                        pvtRow("CodeName") = "中文名稱"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Code_En_Name"
                        pvtRow("CodeName") = "英文名稱"
                        pvtTable.Rows.Add(pvtRow)


                    Case 19
                        pvtTable.TableName = "OPH_Pharmacy_Base"

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "Code"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "CodeName"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Class_Code"
                        pvtRow("CodeName") = "代碼"
                        pvtTable.Rows.Add(pvtRow)


                    Case 20
                        pvtTable.TableName = "OPH_Phrase"

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "Code"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "CodeName"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Class_Code"
                        pvtRow("CodeName") = "代碼"
                        pvtTable.Rows.Add(pvtRow)


                    Case 22
                        pvtTable.TableName = "PUB_Syscode"

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "Code"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "CodeName"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Code_Id"
                        pvtRow("CodeName") = "代碼"
                        pvtTable.Rows.Add(pvtRow)


                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Code_En_Name"
                        pvtRow("CodeName") = "名稱"
                        pvtTable.Rows.Add(pvtRow)

                    Case 23
                        pvtTable.TableName = "PUB_Syscode"

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "Code"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "CodeName"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Code_Id"
                        pvtRow("CodeName") = "代碼"
                        pvtTable.Rows.Add(pvtRow)


                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Code_En_Name"
                        pvtRow("CodeName") = "名稱"
                        pvtTable.Rows.Add(pvtRow)


                    Case 24
                        pvtTable.TableName = "PUB_Syscode"

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "Code"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "CodeName"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Code_Id"
                        pvtRow("CodeName") = "代碼"
                        pvtTable.Rows.Add(pvtRow)


                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Code_En_Name"
                        pvtRow("CodeName") = "名稱"
                        pvtTable.Rows.Add(pvtRow)

                    Case 25
                        pvtTable.TableName = "PUB_Syscode"

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "Code"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "CodeName"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Code_Id"
                        pvtRow("CodeName") = "代碼"
                        pvtTable.Rows.Add(pvtRow)


                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Code_En_Name"
                        pvtRow("CodeName") = "名稱"
                        pvtTable.Rows.Add(pvtRow)


                    Case 26
                        pvtTable.TableName = "PUB_Syscode"

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "Code"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "CodeName"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Code_Id"
                        pvtRow("CodeName") = "代碼"
                        pvtTable.Rows.Add(pvtRow)


                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Code_En_Name"
                        pvtRow("CodeName") = "名稱"
                        pvtTable.Rows.Add(pvtRow)

                    Case 31
                        pvtTable.TableName = "PUB_Department"

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "Code"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "CodeName"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Dept_Code"
                        pvtRow("CodeName") = "代碼"
                        pvtTable.Rows.Add(pvtRow)


                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Dept_Name"
                        pvtRow("CodeName") = "名稱"
                        pvtTable.Rows.Add(pvtRow)


                    Case 32
                        pvtTable.TableName = "INP_Station"

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "Code"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "CodeName"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Station_no"
                        pvtRow("CodeName") = "代碼"
                        pvtTable.Rows.Add(pvtRow)


                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Station_name"
                        pvtRow("CodeName") = "名稱"
                        pvtTable.Rows.Add(pvtRow)

                    Case 35
                        pvtTable.TableName = "PUB_Syscode"

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "Code"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "CodeName"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Code_Id"
                        pvtRow("CodeName") = "代碼"
                        pvtTable.Rows.Add(pvtRow)


                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Code_En_Name"
                        pvtRow("CodeName") = "名稱"
                        pvtTable.Rows.Add(pvtRow)


                    Case 39
                        pvtTable.TableName = "PUB_Syscode"

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "Code"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "CodeName"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Code_Id"
                        pvtRow("CodeName") = "代碼"
                        pvtTable.Rows.Add(pvtRow)


                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Code_En_Name"
                        pvtRow("CodeName") = "名稱"
                        pvtTable.Rows.Add(pvtRow)

                End Select

                Cbo_QueryField.DataSource = pvtTable
                Cbo_QueryField.DisplayMember = "CodeName"
                Cbo_QueryField.ValueMember = "Code"

            End If

        Catch ex As Exception
            Console.WriteLine(ex.ToString)   'nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try

    End Sub


    ''' <summary>
    ''' 設定查詢資料
    ''' queryDS:查詢資料
    ''' </summary>
    ''' <remarks></remarks>''' 
    Public Sub SetQueryData(ByVal queryDS As DataSet)

        Cbo_QueryField.SelectedValue = queryDS.Tables(0).Rows(0).Item(0).ToString.Trim
        Txt_QueryValue.Text = queryDS.Tables(0).Rows(0).Item(1).ToString.Trim

        QueryProcess()

    End Sub

    ''' <summary>
    ''' 資料查詢
    ''' </summary>
    ''' <remarks></remarks>''' 
    Private Sub QueryProcess()

        Dim pvtExeQuery = True

        '取得資料

        Dim uclOW As IUclServiceManager = UclServiceManager.getInstance

        Try


            Select Case pvtQueryTable
                Case 1
                    pvtDS1 = uclOW.queryOpenWindow(pvtQueryTable, Cbo_QueryField.SelectedValue, Txt_QueryValue.Text.Trim & "%", " Like ", Nothing)

                Case 2
                    If pvtQueryValue = "" Then
                        'MessageBox.Show("請輸入診間號")
                        'MessageHandling.showWarn("請輸入診間號")
                        '********************2010/2/9 Modify By Alan**********************
                        MessageHandling.ShowWarnMsg("CMMCMMB300", New String() {"請輸入診間號"})
                        pvtExeQuery = False
                    Else
                        pvtDS1 = uclOW.queryOpenWindow(pvtQueryTable, "Zone_Id︿" & Cbo_QueryField.SelectedValue, pvtQueryValue & "︿" & Txt_QueryValue.Text.Trim & "%", " Like ", Nothing)
                    End If
                Case 3
                    pvtDS1 = uclOW.queryOpenWindow(pvtQueryTable, Cbo_QueryField.SelectedValue, Txt_QueryValue.Text.Trim & "%", " Like ", Nothing)
                Case 4
                    If Cbo_QueryField.SelectedValue = "Icd_Code" AndAlso Txt_QueryValue.Text.Trim.Length < 3 Then
                        'MessageBox.Show("疾病分類碼之條件值至少輸入3碼")
                        'MessageHandling.showWarn("疾病分類碼之條件值至少輸入3碼")
                        '********************2010/2/9 Modify By Alan**********************
                        MessageHandling.ShowWarnMsg("CMMCMMB300", New String() {"疾病分類碼之條件值至少輸入3碼"})
                        pvtExeQuery = False
                    ElseIf Cbo_QueryField.SelectedValue = "Disease_En_Name" AndAlso Txt_QueryValue.Text.Trim.Length < 3 Then
                        'MessageBox.Show("英文名稱之條件值至少輸入3碼")
                        'MessageHandling.showWarn("英文名稱之條件值至少輸入3碼")
                        '********************2010/2/9 Modify By Alan**********************
                        MessageHandling.ShowWarnMsg("CMMCMMB300", New String() {"英文名稱之條件值至少輸入3碼"})
                        pvtExeQuery = False
                    ElseIf Cbo_QueryField.SelectedValue = "Disease_Name" AndAlso Txt_QueryValue.Text.Trim.Length < 3 Then
                        'MessageBox.Show("中文名稱之條件值至少輸入3碼")
                        'MessageHandling.showWarn("中文名稱之條件值至少輸入3碼")
                        '********************2010/2/9 Modify By Alan**********************
                        MessageHandling.ShowWarnMsg("CMMCMMB300", New String() {"中文名稱之條件值至少輸入3碼"})
                        pvtExeQuery = False
                    Else
                        pvtDS1 = uclOW.queryOpenWindow(pvtQueryTable, Cbo_QueryField.SelectedValue, Txt_QueryValue.Text.Trim & "%", " Like ", Nothing)
                    End If


                Case 5
                    pvtDS1 = uclOW.queryOpenWindow(pvtQueryTable, Cbo_QueryField.SelectedValue, Txt_QueryValue.Text.Trim & "%", " Like ", Nothing)
                Case 6
                    pvtDS1 = uclOW.queryOpenWindow(pvtQueryTable, Cbo_QueryField.SelectedValue, Txt_QueryValue.Text.Trim & "%", " Like ", Nothing)

                Case 7
                    pvtDS1 = uclOW.queryOpenWindow(pvtQueryTable, Cbo_QueryField.SelectedValue, Txt_QueryValue.Text.Trim & "%", " Like ", Nothing)

                Case 8
                    pvtDS1 = uclOW.queryOpenWindow(pvtQueryTable, Cbo_QueryField.SelectedValue, Txt_QueryValue.Text.Trim & "%", " Like ", Nothing)

                Case 9
                    If Cbo_QueryField.SelectedValue = "Order_Code" AndAlso Txt_QueryValue.Text.Trim.Length < 3 Then
                        'MessageBox.Show("醫令項目代碼之條件值至少輸入3碼")
                        'MessageHandling.showWarn("醫令項目代碼之條件值至少輸入3碼")
                        '********************2010/2/9 Modify By Alan**********************
                        MessageHandling.ShowWarnMsg("CMMCMMB300", New String() {"醫令項目代碼之條件值至少輸入3碼"})
                        pvtExeQuery = False
                    ElseIf Cbo_QueryField.SelectedValue = "Order_En_Name" AndAlso Txt_QueryValue.Text.Trim.Length < 3 Then
                        'MessageBox.Show("英文名稱之條件值至少輸入3碼")
                        'MessageHandling.showWarn("英文名稱之條件值至少輸入3碼")
                        '********************2010/2/9 Modify By Alan**********************
                        MessageHandling.ShowWarnMsg("CMMCMMB300", New String() {"英文名稱之條件值至少輸入3碼"})
                        pvtExeQuery = False
                    ElseIf Cbo_QueryField.SelectedValue = "Order_Name" AndAlso Txt_QueryValue.Text.Trim.Length < 3 Then
                        ' MessageBox.Show("中文名稱之條件值至少輸入3碼")
                        'MessageHandling.showWarn("中文名稱之條件值至少輸入3碼")
                        '********************2010/2/9 Modify By Alan**********************
                        MessageHandling.ShowWarnMsg("CMMCMMB300", New String() {"中文名稱之條件值至少輸入3碼"})
                        pvtExeQuery = False
                    Else
                        pvtDS1 = uclOW.queryOpenWindow(pvtQueryTable, Cbo_QueryField.SelectedValue, Txt_QueryValue.Text.Trim & "%", " Like ", Nothing)
                    End If



                Case 10
                    pvtDS1 = uclOW.queryOpenWindow(pvtQueryTable, Cbo_QueryField.SelectedValue, Txt_QueryValue.Text.Trim & "%", " Like ", Nothing)


                Case 13
                    If pvtQueryValue = "" Then
                        'MessageBox.Show("請輸入科別")
                        'MessageHandling.showWarn("請輸入科別")
                        '********************2010/2/9 Modify By Alan**********************
                        MessageHandling.ShowWarnMsg("CMMCMMB300", New String() {"請輸入科別"})
                        pvtExeQuery = False
                    Else
                        pvtDS1 = uclOW.queryOpenWindow(pvtQueryTable, "Dept_Code︿" & Cbo_QueryField.SelectedValue, pvtQueryValue & "︿" & Txt_QueryValue.Text.Trim & "%", " Like ", Nothing)
                    End If

                Case 14
                    If pvtQueryValue = "" Then
                        'MessageBox.Show("請輸入醫令類別")
                        'MessageHandling.showWarn("請輸入醫令類別")
                        '********************2010/2/9 Modify By Alan**********************
                        MessageHandling.ShowWarnMsg("CMMCMMB300", New String() {"請輸入醫令類別"})
                        pvtExeQuery = False
                    Else
                        pvtDS1 = uclOW.queryOpenWindow(pvtQueryTable, Cbo_QueryField.SelectedValue & "︿A.Order_Type_Id", Txt_QueryValue.Text.Trim & "︿" & pvtQueryValue & "", " Like ", Nothing)
                    End If



                Case 18
                    pvtDS1 = uclOW.queryOpenWindow(18, Cbo_QueryField.SelectedValue, Txt_QueryValue.Text.Trim & "%", " Like ", Nothing)

                Case 19
                    pvtDS1 = uclOW.queryOpenWindow(191, Cbo_QueryField.SelectedValue, Txt_QueryValue.Text.Trim & "%", " Like ", Nothing)

                Case 20

                    If pvtQueryValue <> "" Then
                        pvtDS1 = uclOW.queryOpenWindow(201, Cbo_QueryField.SelectedValue, Txt_QueryValue.Text.Trim & "%", " Like ", Nothing)
                    Else
                        Dim OtherQueryConditionDS As New DataSet
                        OtherQueryConditionDS.Tables.Add(pvtQueryValue.Trim)
                        pvtDS1 = uclOW.queryOpenWindow(201, Cbo_QueryField.SelectedValue, Txt_QueryValue.Text.Trim & "%", " Like ", OtherQueryConditionDS)
                    End If



                Case 22
                    pvtDS1 = uclOW.queryOpenWindow(221, Cbo_QueryField.SelectedValue, Txt_QueryValue.Text.Trim & "%", " Like ", Nothing)

                Case 23
                    pvtDS1 = uclOW.queryOpenWindow(231, Cbo_QueryField.SelectedValue, Txt_QueryValue.Text.Trim & "%", " Like ", Nothing)

                Case 24
                    pvtDS1 = uclOW.queryOpenWindow(241, Cbo_QueryField.SelectedValue, Txt_QueryValue.Text.Trim & "%", " Like ", Nothing)

                Case 25
                    pvtDS1 = uclOW.queryOpenWindow(251, Cbo_QueryField.SelectedValue, Txt_QueryValue.Text.Trim & "%", " Like ", Nothing)
                Case 26
                    pvtDS1 = uclOW.queryOpenWindow(261, Cbo_QueryField.SelectedValue, Txt_QueryValue.Text.Trim & "%", " Like ", Nothing)

                Case 31
                    pvtDS1 = uclOW.queryOpenWindow(311, Cbo_QueryField.SelectedValue, Txt_QueryValue.Text.Trim & "%", " Like ", Nothing)

                Case 32
                    pvtDS1 = uclOW.queryOpenWindow(321, Cbo_QueryField.SelectedValue, Txt_QueryValue.Text.Trim & "%", " Like ", Nothing)

                Case 35
                    pvtDS1 = uclOW.queryOpenWindow(351, Cbo_QueryField.SelectedValue, Txt_QueryValue.Text.Trim & "%", " Like ", Nothing)

                Case 39
                    pvtDS1 = uclOW.queryOpenWindow(391, Cbo_QueryField.SelectedValue, Txt_QueryValue.Text.Trim & "%", " Like ", Nothing)

            End Select

            If pvtExeQuery = True Then
                If pvtDS1 IsNot Nothing AndAlso pvtDS1.Tables.Count > 0 Then
                    dgv1.Initial(pvtDS1)
                End If
            End If
        Catch ex As Exception
            Console.WriteLine(ex.ToString)   'nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub


#Region "Event"


    Public Sub Btn_Query_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Query.Click

        Try

            ScreenUtil.Lock(Me)

            If Txt_QueryValue.Text.Contains("'") Then
                Txt_QueryValue.Text.Replace("'", "''")
            End If
            QueryProcess()


        Catch ex As Exception
            '  nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
        Finally
            ScreenUtil.UnLock(Me)
        End Try




    End Sub

    '醫生檢核
    Private Function CheckLoginDr(ByVal EmpCode As String) As Boolean

        Try

            'Dim omoService As IOmoServiceManager = OmoServiceManager.getInstance

            'Dim dataDS As New DataSet
            'Dim CheckLoginDrDS As DataSet

            'dataDS.Tables.Add()
            'dataDS.Tables(0).Columns.Add("EmpCode")

            'dataDS.Tables(0).Columns.Add("Phase")

            'Dim row As DataRow
            'row = dataDS.Tables(0).Rows.Add()

            'row("EmpCode") = EmpCode

            'row("Phase") = "ProcessLoginDr"



            'CheckLoginDrDS = omoService.initialOrderTables(dataDS)

            'If CheckLoginDrDS IsNot Nothing AndAlso CheckLoginDrDS.Tables(0).Rows(0).Item(0).ToString.Trim = "1" Then

            '    '檢核通過
            '    Return True
            'Else
            '    Return False
            'End If

            Return True
        Catch ex As Exception
            Return False
        End Try


    End Function


    Private Sub dgv1_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv1.CellDoubleClick
        Dim exist As Boolean = False
        Try


            If pvtDS2 Is Nothing Then
                pvtDS2 = pvtDS1.Clone
                pvtDS2.Tables.Add()
                dgv2.Initial(pvtDS2)
            End If

            Select Case pvtQueryTable
                Case 1
                    For i As Integer = 0 To pvtDS2.Tables(0).Rows.Count - 1
                        If pvtDS2.Tables(0).Rows(i).Item(3).ToString = pvtDS1.Tables(0).Rows(e.RowIndex).Item(3).ToString Then
                            exist = True
                        End If
                    Next



                    If Not exist Then

                        If IsCheckDoctorOnDuty Then

                            If CheckLoginDr(pvtDS1.Tables(0).Rows(e.RowIndex).Item(3).ToString) Then

                                '檢核OK
                                pvtDS2.Tables(0).Rows.Add(pvtDS1.Tables(0).Rows(e.RowIndex).ItemArray)

                            Else

                                '檢核未通過
                                MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {"此醫師非在職!!"}, "")

                                Exit Sub

                            End If
                        Else

                            '不檢核
                            pvtDS2.Tables(0).Rows.Add(pvtDS1.Tables(0).Rows(e.RowIndex).ItemArray)
                        End If



                    End If

                Case 6
                    For i As Integer = 0 To pvtDS2.Tables(0).Rows.Count - 1
                        If pvtDS2.Tables(0).Rows(i).Item(0).ToString = pvtDS1.Tables(0).Rows(e.RowIndex).Item(0).ToString Then
                            exist = True
                        End If
                    Next

                    If Not exist Then
                        pvtDS2.Tables(0).Rows.Add(pvtDS1.Tables(0).Rows(e.RowIndex).ItemArray)
                    End If

                Case 14
                    For i As Integer = 0 To pvtDS2.Tables(0).Rows.Count - 1
                        If pvtDS2.Tables(0).Rows(i).Item(0).ToString = pvtDS1.Tables(0).Rows(e.RowIndex).Item(0).ToString Then
                            exist = True
                        End If
                    Next

                    If Not exist Then
                        pvtDS2.Tables(0).Rows.Add(pvtDS1.Tables(0).Rows(e.RowIndex).ItemArray)
                    End If


                Case 18
                    For i As Integer = 0 To pvtDS2.Tables(0).Rows.Count - 1
                        If pvtDS2.Tables(0).Rows(i).Item(0).ToString = pvtDS1.Tables(0).Rows(e.RowIndex).Item(0).ToString Then
                            exist = True
                        End If
                    Next

                    If Not exist Then
                        pvtDS2.Tables(0).Rows.Add(pvtDS1.Tables(0).Rows(e.RowIndex).ItemArray)
                    End If


                Case 19
                    For i As Integer = 0 To pvtDS2.Tables(0).Rows.Count - 1
                        If pvtDS2.Tables(0).Rows(i).Item(0).ToString = pvtDS1.Tables(0).Rows(e.RowIndex).Item(0).ToString Then
                            exist = True
                        End If
                    Next

                    If Not exist Then
                        pvtDS2.Tables(0).Rows.Add(pvtDS1.Tables(0).Rows(e.RowIndex).ItemArray)
                    End If


                Case 20
                    For i As Integer = 0 To pvtDS2.Tables(0).Rows.Count - 1
                        If pvtDS2.Tables(0).Rows(i).Item(0).ToString = pvtDS1.Tables(0).Rows(e.RowIndex).Item(0).ToString Then
                            exist = True
                        End If
                    Next

                    If Not exist Then
                        pvtDS2.Tables(0).Rows.Add(pvtDS1.Tables(0).Rows(e.RowIndex).ItemArray)
                    End If



                Case 22
                    For i As Integer = 0 To pvtDS2.Tables(0).Rows.Count - 1
                        If pvtDS2.Tables(0).Rows(i).Item(0).ToString = pvtDS1.Tables(0).Rows(e.RowIndex).Item(0).ToString Then
                            exist = True
                        End If
                    Next

                    If Not exist Then
                        pvtDS2.Tables(0).Rows.Add(pvtDS1.Tables(0).Rows(e.RowIndex).ItemArray)
                    End If

                Case 23
                    For i As Integer = 0 To pvtDS2.Tables(0).Rows.Count - 1
                        If pvtDS2.Tables(0).Rows(i).Item(0).ToString = pvtDS1.Tables(0).Rows(e.RowIndex).Item(0).ToString Then
                            exist = True
                        End If
                    Next

                    If Not exist Then
                        pvtDS2.Tables(0).Rows.Add(pvtDS1.Tables(0).Rows(e.RowIndex).ItemArray)
                    End If

                Case 24
                    For i As Integer = 0 To pvtDS2.Tables(0).Rows.Count - 1
                        If pvtDS2.Tables(0).Rows(i).Item(0).ToString = pvtDS1.Tables(0).Rows(e.RowIndex).Item(0).ToString Then
                            exist = True
                        End If
                    Next

                    If Not exist Then
                        pvtDS2.Tables(0).Rows.Add(pvtDS1.Tables(0).Rows(e.RowIndex).ItemArray)
                    End If


                Case 25
                    For i As Integer = 0 To pvtDS2.Tables(0).Rows.Count - 1
                        If pvtDS2.Tables(0).Rows(i).Item(0).ToString = pvtDS1.Tables(0).Rows(e.RowIndex).Item(0).ToString Then
                            exist = True
                        End If
                    Next

                    If Not exist Then
                        pvtDS2.Tables(0).Rows.Add(pvtDS1.Tables(0).Rows(e.RowIndex).ItemArray)
                    End If

                Case 26
                    For i As Integer = 0 To pvtDS2.Tables(0).Rows.Count - 1
                        If pvtDS2.Tables(0).Rows(i).Item(0).ToString = pvtDS1.Tables(0).Rows(e.RowIndex).Item(0).ToString Then
                            exist = True
                        End If
                    Next

                    If Not exist Then
                        pvtDS2.Tables(0).Rows.Add(pvtDS1.Tables(0).Rows(e.RowIndex).ItemArray)
                    End If


                Case 31
                    For i As Integer = 0 To pvtDS2.Tables(0).Rows.Count - 1
                        If pvtDS2.Tables(0).Rows(i).Item(0).ToString = pvtDS1.Tables(0).Rows(e.RowIndex).Item(0).ToString Then
                            exist = True
                        End If
                    Next

                    If Not exist Then
                        pvtDS2.Tables(0).Rows.Add(pvtDS1.Tables(0).Rows(e.RowIndex).ItemArray)
                    End If


                Case 32
                    For i As Integer = 0 To pvtDS2.Tables(0).Rows.Count - 1
                        If pvtDS2.Tables(0).Rows(i).Item(0).ToString = pvtDS1.Tables(0).Rows(e.RowIndex).Item(0).ToString Then
                            exist = True
                        End If
                    Next

                    If Not exist Then
                        pvtDS2.Tables(0).Rows.Add(pvtDS1.Tables(0).Rows(e.RowIndex).ItemArray)
                    End If

                Case 35
                    For i As Integer = 0 To pvtDS2.Tables(0).Rows.Count - 1
                        If pvtDS2.Tables(0).Rows(i).Item(0).ToString = pvtDS1.Tables(0).Rows(e.RowIndex).Item(0).ToString Then
                            exist = True
                        End If
                    Next

                    If Not exist Then
                        pvtDS2.Tables(0).Rows.Add(pvtDS1.Tables(0).Rows(e.RowIndex).ItemArray)
                    End If

                Case 39
                    For i As Integer = 0 To pvtDS2.Tables(0).Rows.Count - 1
                        If pvtDS2.Tables(0).Rows(i).Item(0).ToString = pvtDS1.Tables(0).Rows(e.RowIndex).Item(0).ToString Then
                            exist = True
                        End If
                    Next

                    If Not exist Then
                        pvtDS2.Tables(0).Rows.Add(pvtDS1.Tables(0).Rows(e.RowIndex).ItemArray)
                    End If

            End Select
        Catch ex As Exception
            Console.WriteLine(ex.ToString)   'nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub


    Private Sub btn_Ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Ok.Click
        Try

            If dgv2.GetSelectedRowsIndex() <> "" Then
                Dim selectedIndex As String() = Split(dgv2.GetSelectedRowsIndex(), ",")

                '要倒著刪,否則會錯
                For i As Integer = selectedIndex.Count - 1 To 0 Step -1
                    pvtDS2.Tables(0).Rows.RemoveAt(CInt(selectedIndex(i)))
                Next

            End If

            If mgr Is Nothing Then
                mgr = EventManager.getInstance
            End If

            mgr.RaiseUclOpenWindowMultiSelectValue(ctlName, pvtDS2)


            Me.Close()
        Catch ex As Exception
            Console.WriteLine(ex.ToString)   'nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
            MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {ex.ToString}, "")
            Me.Close()
        End Try
    End Sub


    Private Sub btn_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Cancel.Click
        Me.Close()
    End Sub

    Private Sub UCLOpenWindowMultiSelectUI_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If pvtQueryTable = 1 Then
            Me.Text = "片語資料"
        End If
         

    End Sub

    Private Sub UCLOpenWindowMultiSelectUI_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                Btn_Query_Click(sender, e)
            Case Keys.F5
                Me.Close()
            Case Keys.F12
                btn_Ok_Click(sender, e)
        End Select
    End Sub

    Public Sub SetDisableQuery()

        Label1.Text = "選用區"
        Cbo_QueryField.Visible = False
        Txt_QueryValue.Visible = False
        Btn_Query.Visible = False

    End Sub



#End Region

End Class
