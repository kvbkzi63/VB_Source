Imports System.Data
Imports System.Collections
Imports System.Collections.Generic
Imports System.IO
Imports DocumentFormat
Imports DocumentFormat.OpenXml
Imports DocumentFormat.OpenXml.Wordprocessing
Imports DocumentFormat.OpenXml.Packaging
Imports Syscom.Comm.EXP
Imports A = DocumentFormat.OpenXml.Drawing
Imports DW = DocumentFormat.OpenXml.Drawing.Wordprocessing
Imports PIC = DocumentFormat.OpenXml.Drawing.Pictures
Imports Syscom.Client.Servicefactory
Imports Syscom.Comm.Utility
Imports System.IO.Compression
Imports System.ServiceModel
Imports Syscom.Client.CMM
Imports System.Windows.Forms

Public Class ProjectClientBP

#Region "     宣告Instance"

    Private Shared Instance As ProjectClientBP
    Private appService As New ApplicationServices.ApplicationBase
    Dim path As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\JOB\"

    Private Sub New()

    End Sub

    Public Shared Function getInstance() As ProjectClientBP
        Try
            If Instance Is Nothing Then
                Instance = New ProjectClientBP
            End If
            Return Instance
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

#Region "     宣告列舉"
    Public Enum ActionName
        initialSAAssignJobUI
        InitialJOBEmployeeMaintainUI
        QueryJobProjectMaintainData
        QueryProjectSystem
        QueryJobProjectSystemFunction
        QueryJobList
        QyeryPGJobList
        InsertNewProjectMaintainData
        InsertNewProjectSystem
        InsertNewFunction
        AssignNewJOB
        ApplyDBModified
        UpdateProjectMaintainData
        UpdateProjectSystem
        UpdateProjectFunction
        UpdatePGJobSubmit
        DeleteProject
        DeleteProjectSystem
        DeleteProjectSystemFunction
        ReplyPGSubmit
        InitialSAReplyDialogUI
        QuerySADBModifyRecord
        QueryDBModifyInitialData
        InitialDBAReplyDialogUI
        DBAReplyModify
        CancelJob
        QueryMailGroup
        DeleteMailGroup
        QueryEmployeeListByLevel
        QueryMailGroupDetail
        QueryJobEmployeeMaintainUI
        DeleteMailGroupDetail
        SDConfirm
        SDReject
        QueryServiceRecordList
        QueryUnfinishIssueRecordList
        CreateTempMailGroup
        ImportSystemAndFunctionList
        CancelServiceRecord
        CreateNewServiceRejectRecord
        LoarRejectRecord
        QueryFunctionDataByProjectIDandSystemCode
        QuerySystemDataByProjectID
        QueryTestVerByProjectAndDeployKind
        CreateNewTestVer
        GetMaxTestVersionBeforeCreate
        CreateNewBug
        UpdateVersionDesc
        QueryBugRecord
        QueryBugDetailForModifiy
        InitialJobNoteGrid
        TestVersionClose
        CheckJobStatusBeforeClose
        IssueExtension
        ServerRecordExport
        SAJobTransfer
        ExportTestRecord
        QueryJobForModifiy
    End Enum

#End Region


#Region "     外部函數"

    Public Function GetRTFFID(ByVal control As RichTextBox) As String


        Try
            Dim _pathRTF As String = path & "Reply"
            Dim dir = New DirectoryInfo(_pathRTF)
            If dir.Exists = False Then
                dir.Create()
            End If
            Dim filePath As String = _pathRTF & Convert.ToString("\" & Now.ToString("yyyyMMddHHmmss") & ".rtf")
            Using outputFile As New StreamWriter(filePath, True)
                outputFile.WriteLine(control.Rtf)
            End Using

            Return UploadFileToFTM(filePath)

            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB912", ex)
        End Try
    End Function

    Public Function GetActionDS(ByVal v As ActionName) As DataSet
        Dim returnDS As New DataSet
        returnDS.Tables.Add(New DataTable("Action"))
        returnDS.Tables(0).Columns.Add("Action")

        Try
            Select Case v
                '==============================專案維護檔==========================
                Case ActionName.QueryJobProjectMaintainData
                    returnDS.Tables(0).Columns.Add("Project_ID")
                    returnDS.Tables(0).Columns.Add("Project_Name")
                    returnDS.Tables(0).Columns.Add("Start_Date")
                    returnDS.Tables(0).Columns.Add("End_Date")
                    returnDS.Tables(0).Columns.Add("Project_Manager")
                Case ActionName.InsertNewProjectMaintainData, ActionName.UpdateProjectMaintainData
                    returnDS.Tables(0).Columns.Add("Project_ID")
                    returnDS.Tables(0).Columns.Add("Project_Name")
                    returnDS.Tables(0).Columns.Add("Start_Date")
                    returnDS.Tables(0).Columns.Add("End_Date")
                    returnDS.Tables(0).Columns.Add("Project_Manager")
                    returnDS.Tables(0).Columns.Add("Create_User")
                    returnDS.Tables(0).Columns.Add("Modified_User")
                    returnDS.Tables(0).Columns.Add("Project_Status")
                Case ActionName.QueryProjectSystem, ActionName.QueryJobProjectSystemFunction
                    returnDS.Tables(0).Columns.Add("Project_ID")
                    returnDS.Tables(0).Columns.Add("System_Code")
                Case ActionName.InsertNewProjectSystem, ActionName.UpdateProjectSystem
                    returnDS.Tables(0).Columns.Add("Project_ID")
                    returnDS.Tables(0).Columns.Add("System_Code")
                    returnDS.Tables(0).Columns.Add("System_Name")
                    returnDS.Tables(0).Columns.Add("SA_Employee_Code")
                    returnDS.Tables(0).Columns.Add("Create_User")
                    returnDS.Tables(0).Columns.Add("Modified_User")
                Case ActionName.DeleteProject
                    returnDS.Tables(0).Columns.Add("Project_ID")
                Case ActionName.DeleteProjectSystem
                    returnDS.Tables(0).Columns.Add("Project_ID")
                    returnDS.Tables(0).Columns.Add("System_Code")
                Case ActionName.DeleteProjectSystemFunction
                    returnDS.Tables(0).Columns.Add("Project_ID")
                    returnDS.Tables(0).Columns.Add("System_Code")
                    returnDS.Tables(0).Columns.Add("Function_Code")
                Case ActionName.InsertNewFunction, ActionName.UpdateProjectFunction
                    returnDS.Tables(0).Columns.Add("Project_ID")
                    returnDS.Tables(0).Columns.Add("System_Code")
                    returnDS.Tables(0).Columns.Add("Function_Code")
                    returnDS.Tables(0).Columns.Add("Function_Name")
                    returnDS.Tables(0).Columns.Add("Create_User")
                    returnDS.Tables(0).Columns.Add("Modified_User")
                    returnDS.Tables(0).Columns.Add("Dc")
                    '派工作業
                Case ActionName.initialSAAssignJobUI
                    returnDS.Tables(0).Columns.Add("Employee_Code")
                    returnDS.Tables(0).Rows.Add("initialSAAssignJobUI", AppContext.userProfile.userId)
                Case ActionName.AssignNewJOB
                    returnDS.Tables(0).Columns.Add("PG_Employee_Code")
                    returnDS.Tables(0).Columns.Add("Project_ID")
                    returnDS.Tables(0).Columns.Add("System_Code")
                    returnDS.Tables(0).Columns.Add("Function_Code")
                    returnDS.Tables(0).Columns.Add("Issue_Classify")
                    returnDS.Tables(0).Columns.Add("Issue_Deadline")
                    returnDS.Tables(0).Columns.Add("Issue_Desc")
                    returnDS.Tables(0).Columns.Add("Create_User")
                    returnDS.Tables(0).Columns.Add("FID")
                    returnDS.Tables(0).Columns.Add("EMail")
                    returnDS.Tables(0).Columns.Add("CCUser")
                    returnDS.Tables(0).Columns.Add("PG_Name")
                    returnDS.Tables(0).Columns.Add("RTF_FID")
                    returnDS.Tables(0).Columns.Add("Mail_Subject")
                    returnDS.Tables(0).Columns.Add("Mail_Group_Id")
                    returnDS.Tables(0).Columns.Add("Test_Report_Flag")
                    returnDS.Tables(0).Columns.Add("Assign_Source")
                    returnDS.Tables(0).Columns.Add("SD_Employee_Code")
                    returnDS.Tables(0).Columns.Add("SD_Note")
                    returnDS.Tables(0).Columns.Add("Job_Code")
                    returnDS.Tables(0).Columns.Add("Estimate_Cost")
                    returnDS.Tables(0).Columns.Add("Issue_Id")
                    returnDS.Tables(0).Columns.Add("Assign_Date")
                    returnDS.Tables(0).Columns.Add("Hospital_Code")
                    returnDS.Tables(0).Columns.Add("Target")
                    returnDS.Tables(0).Columns.Add("Job_Special_Status")

                    For Each c As String In Project.Comm.JOB.JobSaAssignRecordDataTableFactory.columnsName
                        If returnDS.Tables(0).Columns.Contains(c) Then Continue For
                        returnDS.Tables(0).Columns.Add(c)
                    Next

                Case ActionName.QueryJobList
                    returnDS.Tables(0).Columns.Add("AssignDateS")
                    returnDS.Tables(0).Columns.Add("AssignDateE")
                    returnDS.Tables(0).Columns.Add("PG_Employee_Code")
                    returnDS.Tables(0).Columns.Add("Project_ID")
                    returnDS.Tables(0).Columns.Add("System_Code")
                    returnDS.Tables(0).Columns.Add("Create_User")
                    returnDS.Tables(0).Columns.Add("Nrs_Level_Id")
                    returnDS.Tables(0).Columns.Add("SD_Confirm")
                    returnDS.Tables(0).Columns.Add("Status")
                    returnDS.Tables(0).Columns.Add("Cancel")
                    returnDS.Tables(0).Columns.Add("Main_SD_Employee_Code")
                Case ActionName.QyeryPGJobList
                    returnDS.Tables(0).Columns.Add("Employee_Code")
                    returnDS.Tables(0).Columns.Add("Status")
                    returnDS.Tables(0).Columns.Add("AssignDateS")
                    returnDS.Tables(0).Columns.Add("AssignDateE")
                Case ActionName.UpdatePGJobSubmit
                    returnDS.Tables(0).Columns.Add("JOB_Code")
                    returnDS.Tables(0).Columns.Add("Modified_User")
                    returnDS.Tables(0).Columns.Add("CCUser")
                    returnDS.Tables(0).Columns.Add("PG_Name")
                    returnDS.Tables(0).Columns.Add("Issue_Desc")
                    returnDS.Tables(0).Columns.Add("FID")
                    returnDS.Tables(0).Columns.Add("System_Code")
                    returnDS.Tables(0).Columns.Add("Issue_Cost_Time")
                    returnDS.Tables(0).Columns.Add("Issue_Level")
                    returnDS.Tables(0).Columns.Add("ChangeSet_No")
                    returnDS.Tables(0).Columns.Add("ChangeSet_Note")
                Case ActionName.ReplyPGSubmit
                    returnDS.Tables(0).Columns.Add("JOB_Code")
                    returnDS.Tables(0).Columns.Add("Modified_User")
                    returnDS.Tables(0).Columns.Add("Result")
                    returnDS.Tables(0).Columns.Add("Reply_Note")
                    returnDS.Tables(0).Columns.Add("FID")
                    returnDS.Tables(0).Columns.Add("SA_Reply_ATT_FID")
                Case ActionName.InitialSAReplyDialogUI
                    returnDS.Tables(0).Columns.Add("JOB_Code")
                Case ActionName.ApplyDBModified
                    returnDS.Tables(0).Columns.Add("Project_ID")
                    returnDS.Tables(0).Columns.Add("System")
                    returnDS.Tables(0).Columns.Add("Table_Name")
                    returnDS.Tables(0).Columns.Add("Table_Ch_Name")
                    returnDS.Tables(0).Columns.Add("DB_Name")
                    returnDS.Tables(0).Columns.Add("Index")
                    returnDS.Tables(0).Columns.Add("Restrict")
                    returnDS.Tables(0).Columns.Add("Modified_Classify")
                    returnDS.Tables(0).Columns.Add("Sql_Script")
                    returnDS.Tables(0).Columns.Add("DBA_Employee_Code")
                    returnDS.Tables(0).Columns.Add("Create_User")
                    returnDS.Tables(0).Columns.Add("Create_User_Name")
                    returnDS.Tables(0).Columns.Add("FID")
                Case ActionName.QuerySADBModifyRecord
                    returnDS.Tables(0).Columns.Add("DBA_Employee_Code")
                    returnDS.Tables(0).Columns.Add("Project_ID")
                    returnDS.Tables(0).Columns.Add("Query_Condition")
                Case ActionName.DBAReplyModify
                    returnDS.Tables(0).Columns.Add("Project_ID")
                    returnDS.Tables(0).Columns.Add("Seq_No")
                    returnDS.Tables(0).Columns.Add("Reject_Reason")
                    returnDS.Tables(0).Columns.Add("Modified_User")
                Case ActionName.CancelJob
                    returnDS.Tables(0).Columns.Add("Job_Code")
                    returnDS.Tables(0).Columns.Add("Cancel_Reason")
                    returnDS.Tables(0).Columns.Add("Modified_User")
                    returnDS.Tables(0).Columns.Add("Cancel_Source")

                Case ActionName.QueryMailGroup, ActionName.DeleteMailGroup
                    returnDS.Tables(0).Columns.Add("Group_ID")
                    returnDS.Tables(0).Columns.Add("Belong_Employee_Code")
                Case ActionName.QueryMailGroupDetail, ActionName.DeleteMailGroupDetail
                    returnDS.Tables(0).Columns.Add("Group_ID")
                    returnDS.Tables(0).Columns.Add("Belong_Employee_Code")
                    returnDS.Tables(0).Columns.Add("Employee_Code")
                Case ActionName.QueryEmployeeListByLevel
                    '填入 1 =PG  2=SA
                    returnDS.Tables(0).Columns.Add("Level")
                Case ActionName.SDConfirm
                    returnDS.Tables(0).Columns.Add("Job_Code")
                    returnDS.Tables(0).Columns.Add("FID")
                    returnDS.Tables(0).Columns.Add("SD_Note")
                    returnDS.Tables(0).Columns.Add("Project_ID")
                    returnDS.Tables(0).Columns.Add("System_Code")
                    returnDS.Tables(0).Columns.Add("Function_Code")
                    returnDS.Tables(0).Columns.Add("PG_Employee_Code")
                    returnDS.Tables(0).Columns.Add("PG_Name")
                    returnDS.Tables(0).Columns.Add("Issue_Classify")
                    returnDS.Tables(0).Columns.Add("Issue_Deadline")
                    returnDS.Tables(0).Columns.Add("Issue_Desc")
                    returnDS.Tables(0).Columns.Add("Assign_Source")
                    returnDS.Tables(0).Columns.Add("Estimate_Cost")
                    returnDS.Tables(0).Columns.Add("SD_Estimate_Cost")
                    returnDS.Tables(0).Columns.Add("SD_Cost_Time")
                    returnDS.Tables(0).Columns.Add("SD_Issue_Deadline")
                Case ActionName.InitialJOBEmployeeMaintainUI
                Case ActionName.QueryJobEmployeeMaintainUI
                    returnDS.Tables(0).Columns.Add("Employee_Code")
                    returnDS.Tables(0).Columns.Add("Employee_En_Name")
                    returnDS.Tables(0).Columns.Add("Employee_Name")
                Case ActionName.QueryServiceRecordList
                    returnDS.Tables(0).Columns.Add("Project_ID")
                    returnDS.Tables(0).Columns.Add("System_Code")
                    returnDS.Tables(0).Columns.Add("Function_Code")
                    returnDS.Tables(0).Columns.Add("Issue_Status")
                    returnDS.Tables(0).Columns.Add("SDate")
                    returnDS.Tables(0).Columns.Add("EDate")
                    returnDS.Tables(0).Columns.Add("Processing_Employee_Code")
                    returnDS.Tables(0).Columns.Add("Hospital_Code")
                    returnDS.Tables(0).Columns.Add("Job_Code")

                Case ActionName.QueryUnfinishIssueRecordList
                    returnDS.Tables(0).Columns.Add("Start_Date")
                Case ActionName.CreateTempMailGroup
                    returnDS.Tables(0).Columns.Add("Employee_Code")
                    returnDS.Tables(0).Columns.Add("MailList")
                Case ActionName.CancelServiceRecord
                    returnDS.Tables(0).Columns.Add("Issue_Id")
                    returnDS.Tables(0).Columns.Add("Cancel_Reason")
                    returnDS.Tables(0).Columns.Add("Cancel_User")
                Case ActionName.LoarRejectRecord
                    returnDS.Tables(0).Columns.Add("Issue_Id")
                Case ActionName.CreateNewServiceRejectRecord
                    For Each c As String In Project.Comm.JOB.JobServiceReplyRecordDataTableFactory.columnsName
                        If returnDS.Tables(0).Columns.Contains(c) Then Continue For
                        returnDS.Tables(0).Columns.Add(c)
                    Next
                Case ActionName.QueryFunctionDataByProjectIDandSystemCode, ActionName.QuerySystemDataByProjectID
                    returnDS.Tables(0).Columns.Add("Project_ID")
                    returnDS.Tables(0).Columns.Add("System_Code")
                Case ActionName.QueryTestVerByProjectAndDeployKind, ActionName.GetMaxTestVersionBeforeCreate
                    returnDS.Tables(0).Columns.Add("Project_ID")
                    returnDS.Tables(0).Columns.Add("Deploy_Kind")
                    returnDS.Tables(0).Columns.Add("Hospital_Code")
                Case ActionName.CreateNewTestVer
                    For Each c As String In Project.Comm.JOB.JobQaTestRecordDataTableFactory.columnsName
                        If returnDS.Tables(0).Columns.Contains(c) Then Continue For
                        returnDS.Tables(0).Columns.Add(c)
                    Next
                Case ActionName.CreateNewBug
                    returnDS.Tables(0).Columns.Add("Project_Id")
                    For Each c As String In Project.Comm.JOB.JobQaBugRecordDataTableFactory.columnsName
                        If returnDS.Tables(0).Columns.Contains(c) Then Continue For
                        returnDS.Tables(0).Columns.Add(c)
                    Next
                    returnDS.Tables.Add(Project.Comm.JOB.JobQaAttachedFilesDataTableFactory.getDataTableWithNoPK)
                Case ActionName.UpdateVersionDesc
                    returnDS.Tables(0).Columns.Add("Version_Desc")
                    returnDS.Tables(0).Columns.Add("Modified_User")
                    returnDS.Tables(0).Columns.Add("Version_Id")
                Case ActionName.QueryBugRecord
                    returnDS.Tables(0).Columns.Add("Version_Id")
                    returnDS.Tables(0).Columns.Add("Create_User")
                    returnDS.Tables(0).Columns.Add("Test_Result")
                    returnDS.Tables(0).Columns.Add("Hospital_Code")
                    returnDS.Tables(0).Columns.Add("Project_Id")
                    returnDS.Tables(0).Columns.Add("Deploy_Kind")
                Case ActionName.QueryBugDetailForModifiy, ActionName.InitialJobNoteGrid
                    returnDS.Tables(0).Columns.Add("Bug_Id")
                    returnDS.Tables(0).Columns.Add("Version_Id")
                Case ActionName.TestVersionClose, ActionName.CheckJobStatusBeforeClose
                    returnDS.Tables(0).Columns.Add("Version_Id")
                Case ActionName.IssueExtension
                    returnDS.Tables(0).Columns.Add("JOB_Code")
                    returnDS.Tables(0).Columns.Add("Issue_Deadline")
                Case ActionName.ServerRecordExport
                    returnDS.Tables(0).Columns.Add("Project_Id")
                Case ActionName.SAJobTransfer
                    returnDS.Tables(0).Columns.Add("JOB_Code")
                    returnDS.Tables(0).Columns.Add("PG_Employee_Code")
                    returnDS.Tables(0).Columns.Add("Reason")
                    returnDS.Tables(0).Columns.Add("Modified_User")
                    returnDS.Tables(0).Columns.Add("Source")
                    returnDS.Tables(0).Columns.Add("FID")
                Case ActionName.ExportTestRecord
                    returnDS.Tables(0).Columns.Add("Project_Id")
                    returnDS.Tables(0).Columns.Add("Deploy_Kind")
                    returnDS.Tables(0).Columns.Add("Test_Version_Condition") '↑查詢條件↓顯示欄位
                    returnDS.Tables(0).Columns.Add("BUG_ID")
                    returnDS.Tables(0).Columns.Add("Test_Version", System.Type.GetType("System.Boolean"))
                    returnDS.Tables(0).Columns.Add("System_Name", System.Type.GetType("System.Boolean"))
                    returnDS.Tables(0).Columns.Add("Function_Name", System.Type.GetType("System.Boolean"))
                    returnDS.Tables(0).Columns.Add("Status", System.Type.GetType("System.Boolean"))
                    returnDS.Tables(0).Columns.Add("Issue_Subject", System.Type.GetType("System.Boolean"))
                    returnDS.Tables(0).Columns.Add("Issue_Desc", System.Type.GetType("System.Boolean"))
                    returnDS.Tables(0).Columns.Add("Issue_Classify", System.Type.GetType("System.Boolean"))
                    returnDS.Tables(0).Columns.Add("Issue_Level", System.Type.GetType("System.Boolean"))
                    returnDS.Tables(0).Columns.Add("Test_Employee_Name", System.Type.GetType("System.Boolean"))
                    returnDS.Tables(0).Columns.Add("Hospital_Code")
                Case ActionName.QueryJobForModifiy
                    returnDS.Tables(0).Columns.Add("Job_Code")
                Case Else
            End Select
        Catch ex As Exception

        End Try

        Return returnDS
    End Function


    ''' <summary>
    ''' 匯出Word
    ''' </summary>
    ''' <param name="docName">範本文件名稱</param>
    ''' <param name="SaveFilePath">存檔路徑(含檔名、副檔名)</param>
    ''' <param name="key">傳入替換的Key值</param>
    ''' <returns></returns>
    Public Function ExportWordByKeyAndValue(ByVal docName As String, ByVal SaveFilePath As String, ByVal key As Dictionary(Of String, String)) As String
        Dim sourceTemp As String = Environment.CurrentDirectory & "\TempDoc\" & docName


        Try

            Dim fileInfo As New FileInfo(SaveFilePath)

            If fileInfo.Exists Then
                fileInfo.Delete()
            End If

            File.Copy(sourceTemp, SaveFilePath)



            Using wordDoc As WordprocessingDocument = WordprocessingDocument.Open(SaveFilePath, True)
                Dim docTxt As String = Nothing
                Using sr As StreamReader = New StreamReader(wordDoc.MainDocumentPart.GetStream)
                    docTxt = sr.ReadToEnd
                End Using

                ReplaceKeyValue(docTxt, key)

                Using sw As StreamWriter = New StreamWriter(wordDoc.MainDocumentPart.GetStream(FileMode.Create))
                    sw.Write(docTxt)
                End Using


            End Using

            'InsertAPicture(SaveFilePath, "C:\Users\Will\Desktop\555.bmp")
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"匯出Word"})
        End Try
        Return True
    End Function

    Private Sub ReplaceKeyValue(ByRef str As String, ByVal key As Dictionary(Of String, String))
        Try

            For Each k As String In key.Keys
                str = str.Replace("[$" & k & "$]", key(k))
            Next

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"替換字串"})
        End Try
    End Sub

    ''' <summary>
    ''' 插入圖片在文件尾部
    ''' </summary>
    ''' <param name="document">文件路徑</param>
    ''' <param name="fileName"></param>
    Public Sub InsertAPicture(ByVal document As String, ByVal fileName As String)
        Using wordprocessingDocument As WordprocessingDocument = WordprocessingDocument.Open(document, True)
            Dim mainPart As MainDocumentPart = wordprocessingDocument.MainDocumentPart

            Dim imagePart As ImagePart = mainPart.AddImagePart(ImagePartType.Jpeg)

            Using stream As New FileStream(fileName, FileMode.Open)
                imagePart.FeedData(stream)
            End Using

            AddImageToBody(wordprocessingDocument, mainPart.GetIdOfPart(imagePart))
        End Using
    End Sub

    Private Sub AddImageToBody(ByVal wordDoc As WordprocessingDocument, ByVal relationshipId As String)
        ' Define the reference of the image.
        Dim element = New Drawing(
                              New DW.Inline(
                          New DW.Extent() With {.Cx = 2990000L, .Cy = 2992000L},
                          New DW.EffectExtent() With {.LeftEdge = 0L, .TopEdge = 0L, .RightEdge = 0L, .BottomEdge = 0L},
                          New DW.DocProperties() With {.Id = CType(1UI, UInt32Value), .Name = "Picture1"},
                          New DW.NonVisualGraphicFrameDrawingProperties(
                              New A.GraphicFrameLocks() With {.NoChangeAspect = True}
                              ),
                          New A.Graphic(New A.GraphicData(
                                        New PIC.Picture(
                                            New PIC.NonVisualPictureProperties(
                                                New PIC.NonVisualDrawingProperties() With {.Id = 0UI, .Name = "Koala.jpg"},
                                                New PIC.NonVisualPictureDrawingProperties()
                                                ),
                                            New PIC.BlipFill(
                                                New A.Blip(
                                                    New A.BlipExtensionList(
                                                        New A.BlipExtension() With {.Uri = "{28A0092B-C50C-407E-A947-70E740481C1C}"})
                                                    ) With {.Embed = relationshipId, .CompressionState = A.BlipCompressionValues.Print},
                                                New A.Stretch(
                                                    New A.FillRectangle()
                                                    )
                                                ),
                                            New PIC.ShapeProperties(
                                                New A.Transform2D(
                                                    New A.Offset() With {.X = 0L, .Y = 0L},
                                                    New A.Extents() With {.Cx = 990000L, .Cy = 792000L}),
                                                New A.PresetGeometry(
                                                    New A.AdjustValueList()
                                                    ) With {.Preset = A.ShapeTypeValues.Rectangle}
                                                )
                                            )
                                        ) With {.Uri = "http://schemas.openxmlformats.org/drawingml/2006/picture"}
                                    )
                                ) With {.DistanceFromTop = 0UI,
                                        .DistanceFromBottom = 0UI,
                                        .DistanceFromLeft = 0UI,
                                        .DistanceFromRight = 0UI}
                            )

        ' Append the reference to body, the element should be in a Run.
        wordDoc.MainDocumentPart.Document.Body.AppendChild(New Paragraph(New Run(element)))
    End Sub


    Public Function LoadFileByFID(ByVal FID As String, Optional ByVal FileName As String = "") As String
        Try
            Dim client = FtmServiceManager.getInstance
            'Step.1 下載檔案
            Dim obj As Object = client.downloadFile(FID)
            'Step.3 取得檔案副檔名
            Dim DataType As String = FID.Split(".")(1)
            '(0) 檔案資料byte() , (1) client端的預設檔名
            '不滿意預設路徑或檔名，請自行修改後傳入　FileTransferTool.convertByteArrayToFile
            FileTransferTool.convertByteArrayToFile(obj(0), obj(1))
            Dim folder As New DirectoryInfo(appService.Info.DirectoryPath & "\JOB\DownLoad")
            '判斷Folder，先砍掉再重新下載以免太多垃圾
            If folder.Exists Then folder.Delete(True)
            folder.Create()

            Dim FilePath As String = Environment.CurrentDirectory & "\JOB\DownLoad\" & IIf(FileName <> "", FileName, FID.Trim) & "." & DataType.Trim

            Using fs As FileStream = File.Create(FilePath)
                fs.Write(obj(0), 0, obj(0).Length)
            End Using
            Return FilePath
        Catch ex As Exception

        End Try
        Return ""
    End Function

    ''' <summary>
    ''' 取得下拉選單的DataSet
    ''' </summary>
    ''' <param name="ConfigName"></param>
    ''' <returns></returns>
    Public Function GetComboBoxDataTableByConfigName(ByVal ConfigName As String, ByVal DTName As String) As DataTable
        Dim retDt As New DataTable(DTName)
        retDt.Columns.Add("Code_Id")
        retDt.Columns.Add("Code_Name")
        Try
            Dim configValue As String = PubServiceManager.getInstance.GetPubConfigValue(ConfigName)
            For Each s As String In configValue.Split(",")
                Dim dr As DataRow = retDt.NewRow
                dr("Code_Id") = s.Split("-")(0)
                dr("Code_Name") = s.Split("-")(1)
                retDt.Rows.Add(dr)
            Next


        Catch ex As Exception
            Throw ex
        End Try
        Return retDt
    End Function


#Region "     打包附件項目"

    Public Function ProcessAttachments(ByVal path As String()) As String
        Try
            Dim attachments As New List(Of Byte())
            Dim _pathSpec As String = Me.path & "SPEC"
            If path.Length > 0 Then
                Dim dir As New DirectoryInfo(Me.path & "SPEC")
                If dir.Exists Then
                    dir.Delete(True)
                End If
                dir.Create()
                For Each s In path
                    Dim FileName As String = s.Split("\")(s.Split("\").Length - 1)
                    CopyFiles(s, _pathSpec & "\" & FileName)
                Next
                Return UploadFileToFTM(CompressFile(New DirectoryInfo(_pathSpec)))
            End If


        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
        End Try
        Return Nothing
    End Function

    Private Function CopyFiles(ByVal Spath As String, ByVal Dpath As String) As Boolean
        Try
            System.IO.File.Copy(Spath, Dpath, True)

        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
        End Try
        Return True
    End Function

#Region "文件壓縮"

    Public Function CompressFile(directorySelected As DirectoryInfo) As String
        Dim fileFullName As String = directorySelected.FullName & ".zip"
        '如果檔案存在，就問是否要刪除
        Dim fileinfo As New FileInfo(fileFullName)
        If fileinfo.Exists = False Then
            ZipFile.CreateFromDirectory(directorySelected.FullName, fileFullName)
            directorySelected.Delete(True)
        Else

            fileinfo.Delete()
            ZipFile.CreateFromDirectory(directorySelected.FullName, fileFullName)
            directorySelected.Delete(True)
        End If
        Return fileFullName
    End Function

#End Region

#Region "上傳檔案"
    Dim WithEvents pvtReceiveMgr As EventManager = EventManager.getInstance

    Public Function UploadFileToFTM(ByVal FilePath As String) As String
        Dim strFilePath As String = ""
        Try
            pvtReceiveMgr.RaiseUclWaitingForm("WaitingStart", "上傳中，請稍後‧‧‧")
            Dim dataSet As DataSet = New DataSet
            Dim dataTable As DataTable = FileTransferDataFormat.getDataTableWithSchema
            Dim dataRow As DataRow = dataTable.NewRow()
            '使用自己的資料來源取代 New Object 

            dataRow("File_Name") = FilePath  '檔案路徑
            dataRow("Order_Seq") = 1 '顯示順序
            dataRow("Image_Thumb") = Nothing '沒有縮圖的需求給nothing
            dataRow("File_Note") = "testing" '檔案註解
            dataRow("Create_User") = "roger" '上傳人員
            dataRow("Create_Time") = Now '上傳時間
            dataRow("Modified_User") = "roger" '修改人員
            dataRow("Modified_Time") = Now '修改時間
            dataRow("FileByteArray") = FileTransferTool.convertFileToByteArray(FilePath) '將檔案轉成 byte array
            dataRow("FileType") = FileTransferTool.FileType_R '檔案型態 --> T / G /R /O /E / I
            If AppContext.userProfile.userId.Length > 8 Then
                dataRow("FileSub") = AppContext.userProfile.userId.Substring(0, 8)  ' 檔案系統八碼，如果是 EMR 系統，這裡填入八碼病歷號 
            Else
                dataRow("FileSub") = AppContext.userProfile.userId
            End If
            dataRow("FileTime") = Now '指定檔案時間
            dataRow("FID") = 0 '預設給0，後端會再重新給值
            dataTable.Rows.Add(dataRow)
            dataSet.Tables.Add(dataTable)

            Dim client = FtmServiceManager.getInstance
            Dim s() = client.uploadNewFile(dataSet)
            pvtReceiveMgr.RaiseUclWaitingForm("WaitingEnd", "")
            Return s(0)

            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw ex
        Finally
            pvtReceiveMgr.RaiseUclWaitingForm("WaitingEnd", "")
        End Try
        Return ""
    End Function
#End Region

#End Region

#End Region

#Region "     內部函數"


#End Region

End Class
