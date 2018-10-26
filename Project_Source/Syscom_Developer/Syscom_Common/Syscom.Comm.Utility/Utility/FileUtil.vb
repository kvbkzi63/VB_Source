Imports System.Text
Imports System.IO
Imports System.Windows.Forms
Imports Syscom.Comm.Utility.StringUtil

Public Class FileUtil

    ''' <summary>
    ''' 讀取檔案
    ''' </summary>
    ''' <param name="fileName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ReadFileFromFileName(ByVal fileName As String) As String
        Try

            Dim strContent As New StringBuilder

            Dim objReader = New StreamReader(fileName, System.Text.Encoding.Default)
            strContent.Append(objReader.ReadToEnd())
            objReader.Close()

            Return strContent.ToString

        Catch ex As Exception
            Throw ex
        End Try
    End Function

#Region "       檢查檔案"

    ''' <summary>
    ''' 檢查路徑(目錄及檔名)
    ''' </summary>
    ''' <param name="fileName">若無目錄存在, 則建立目錄</param>
    ''' <param name="IsDelete">True: 檔案存在則強制刪除</param>
    ''' <remarks>若無資料夾存在, 則建立資料夾</remarks>
    Public Shared Sub checkFilePath(ByVal fileName As String, Optional ByVal IsDelete As Boolean = True)
        Try

            Dim fileObj As FileInfo
            fileObj = New IO.FileInfo(fileName)

            '假如沒有資料夾，先建立資料夾
            If (Not fileObj.Directory.Exists) Then
                fileObj.Directory.Create()
            End If

            '檔案若已存在，則先刪除
            If fileObj.Exists AndAlso IsDelete Then
                fileObj.Delete()
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' 檢查檔案是否存在
    ''' </summary>
    ''' <param name="fileName"></param>
    ''' <param name="IsDelete"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CheckFileExist(ByVal fileName As String, Optional ByVal IsDelete As Boolean = False) As Boolean
        Try

            Dim result As Boolean = False

            Dim fileObj As FileInfo
            fileObj = New IO.FileInfo(fileName)
 
            If fileObj.Exists Then

                result = True

                If IsDelete Then
                    fileObj.Delete()
                End If

            End If

            Return result

        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

    ''' <summary>
    ''' 寫入檔案
    ''' </summary>
    ''' <param name="strData"></param>
    ''' <param name="fileName"></param>
    ''' <param name="directory"></param>
    ''' <param name="txtEncode"></param>
    ''' <param name="fileExtension"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function WriteFileToFileName(ByRef strData As String, ByVal fileName As String, ByVal directory As String _
                                        , ByVal txtEncode As System.Text.Encoding, Optional ByRef fileExtension As String = "txt") As String
        Try
            Dim fileObj As FileInfo

            Dim fullFileName As String = New StringBuilder().Append(directory).Append("\").Append(fileName).Append(".").Append(fileExtension).ToString

            fileObj = New IO.FileInfo(fullFileName)

            '假如沒有資料夾，先建立資料夾
            If (Not fileObj.Directory.Exists) Then
                fileObj.Directory.Create()
            End If

            Dim objStream As System.IO.StreamWriter = New System.IO.StreamWriter(fileObj.OpenWrite, txtEncode)

            objStream.WriteLine(strData)

            objStream.Flush()
            objStream.Close()
            objStream.Dispose()

            Return fullFileName

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 選擇目錄
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function SelectFileDirectory() As String
        Try

            Dim dialog As New FolderBrowserDialog
            dialog.ShowDialog()

            Return dialog.SelectedPath.ToString.Trim

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 選擇檔案
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function SelectFilePath() As String
        Try

            Dim dialog As New OpenFileDialog
            dialog.ShowDialog()

            Return  dialog.FileName.ToString .Trim 

        Catch ex As Exception
            Throw ex
        End Try
    End Function



#Region "    DataTable轉Txt"

    ''' <summary>
    ''' 程式說明：DataTable轉Txt
    ''' 開發人員：Charles
    ''' 開發日期：2012/05/28
    ''' </summary>
    ''' <param name="SourceTable">來源資料表</param>
    ''' <param name="fileName">檔案名稱(ex:drgInput)</param>
    ''' <param name="directory">路徑名稱(C:\TempFile)</param>
    ''' <remarks></remarks>
    Public Shared Sub DataTableToTxtFile(ByVal SourceTable As DataTable, ByVal fileName As String, ByVal directory As String)
        Try
            If DataSetUtil.IsContainsData(SourceTable) AndAlso SourceTable.Rows.Count > 0 Then
                Dim TempStr As New StringBuilder

                For indexRow As Integer = 0 To SourceTable.Rows.Count - 1
                    For indexCol As Integer = 0 To SourceTable.Columns.Count - 1
                        If indexCol > 0 Then
                            TempStr.Append(",")
                        End If
                        Dim ColumnName As String = SourceTable.Columns(indexCol).ColumnName
                        TempStr.Append(nvl(SourceTable.Rows(indexRow).Item(ColumnName)))
                    Next
                    TempStr.AppendLine()
                Next

                'writeTxtFile(FullPathName, TempStr.ToString, Encoding.Default)
                WriteFileToFileName(TempStr.ToString, fileName, directory, Encoding.Default)
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub


#End Region

#Region "    Txt檔轉DataTalbe"

    ''' <summary>
    ''' 程式說明：Txt檔轉DataTalbe
    ''' 開發人員：Charles
    ''' 開發日期：2012/05/28
    ''' </summary>
    ''' <param name="AppendHeaderStr">首行插入字串</param>
    ''' <param name="SourceStr">來源字串</param>
    ''' <param name="AppendEndStr">插入尾行字串</param>
    ''' <param name="SourceDt">來源資料表</param>
    ''' <returns>DataTable</returns>
    ''' <remarks></remarks>
    Public Shared Function TxtToDataTable(ByVal AppendHeaderStr As String, ByVal SourceStr As String, ByVal AppendEndStr As String, ByVal SourceDt As DataTable) As DataTable
        Try
            Dim StrArray() As String = SourceStr.Split(vbCrLf)
            Dim Mylist As New List(Of Array)
            If StrArray.Count > 0 Then
                For i As Integer = 1 To StrArray.Count - 1
                    If Not "".Equals(StrArray(i).Trim) Then
                        Dim NewStr As String = StrArray(i)
                        If AppendHeaderStr.Length > 0 Then
                            NewStr = AppendHeaderStr & "," & NewStr
                        End If
                        If AppendEndStr.Length > 0 Then
                            NewStr = NewStr & "," & AppendEndStr
                        End If

                        Mylist.Add(NewStr.Split(","))
                    End If


                Next

                Return TxtToDataTable(Mylist, SourceDt)
            Else
                Return SourceDt
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Function


    ''' <summary>
    ''' 程式說明：Txt檔轉DataTalbe
    ''' 開發人員：Charles
    ''' 開發日期：2012/05/28
    ''' </summary>
    ''' <param name="SourceList">來源資料List</param>
    ''' <param name="SourceDt">來源資料表</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function TxtToDataTable(ByVal SourceList As List(Of Array), ByVal SourceDt As DataTable) As DataTable
        Try
            Dim RtnTable As DataTable = SourceDt.Clone

            If SourceList.Count > 0 Then
                For i As Integer = 0 To SourceList.Count - 1
                    Dim MyNewRow As DataRow = RtnTable.NewRow
                    MyNewRow.ItemArray = SourceList(i)

                    RtnTable.Rows.Add(MyNewRow)
                Next
            End If

            Return RtnTable
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

#Region "    健保局單機版(DRG)"

    ''' <summary>
    ''' 呼叫健保局單機版(DRG)
    ''' </summary>
    ''' <param name="DrgsPath">單機版路徑(C:\Program Files (x86)\P_DRGService\DRG.exe)</param>
    ''' <param name="InputFullName">輸入檔案(C:\TempFile\drgInput.txt)</param>
    ''' <param name="OutputFullName">輸出檔案(C:\TempFile\drgOutput.txt)</param>
    ''' <remarks></remarks>
    Public Shared Sub DoDRGExe(ByVal DrgsPath As String, ByVal InputFullName As String, ByVal OutputFullName As String, Optional ByVal WaitFlag As Boolean = False)
        Try

            Using process = New Process
                'process.Start("C:\Program Files (x86)\P_DRGService\DRG.exe", "C:\TempFile\drgInput.txt C:\TempFile\drgOutput.txt Y")

                '是否等待程式執行結束
                If WaitFlag = True Then
                    process.Start(DrgsPath, InputFullName & " " & OutputFullName & " Y").WaitForExit()

                Else
                    process.Start(DrgsPath, InputFullName & " " & OutputFullName & " Y")
                End If

            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

End Class
