'*/
'*****************************************************************************
'*
'*    Page/Class Name:	PUBQuerySectionDialog.vb
'*              Title:	科診查詢的視窗
'*        Description:	科診查詢的視窗
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd.
'*            @author:	tima_qin
'*        Create Date:	2010-06-07
'*      Last Modifier:	
'*   Last Modify Date:	
'*
'*****************************************************************************
'*/

Imports Syscom.Client.Servicefactory
Imports System.Windows.Forms
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
Imports Syscom.Comm.LOG
Imports System.Text
Imports Syscom.Client.CMM
Imports System.Text.RegularExpressions
Imports System.Data

Public Class PUBQuerySectionDialog

    Dim objpub As IPubServiceManager = Nothing
    '目前使用者的ID
    Dim currentUserID As String = AppContext.userProfile.userId
    ' Dim log As ILog = LOGDelegate.GetInstance.getFileLogger(Me)
    '獲取維護表名
    Dim tableDB As String = PubDeptSectDataTableFactory.tableName
    'Grid使用的標題
    Dim columnNameGrid() As String = {"診別", "名稱", "英文", "科診別名", "科診英文別名"}
    '獲取維護表字段名
    Dim columnNameDB() As String = PubDeptSectDataTableFactory.columnsName
    '獲取維護表字段長度
    Dim columnsLength() As Integer = PubDeptSectDataTableFactory.columnsLength

    Private frm As PUBDepartmentUI

    '資料集類型定義
    Enum DataSet_Type
        Grid = 0
        DB = 1
    End Enum

    ''' <summary>
    ''' 產生一個空的DataSet
    ''' </summary>
    ''' <param name="type"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function genDS(ByVal type As Integer) As DataSet
        Dim dsTemp As New DataSet
        Select Case type
            Case DataSet_Type.Grid
                '給Grid用Table()
                dsTemp.Tables.Add(tableDB)
                For i As Integer = 0 To columnNameGrid.Length - 1
                    dsTemp.Tables(tableDB).Columns.Add(columnNameGrid(i))
                Next
            Case DataSet_Type.DB
                '給DB用Table()
                dsTemp.Tables.Add(tableDB)
                For i As Integer = 0 To columnNameDB.Length - 1
                    dsTemp.Tables(tableDB).Columns.Add(columnNameDB(i))
                Next
        End Select
        Return dsTemp
    End Function

    Public Sub initialData(ByVal strDeptCode As String, ByRef parentfrm As PUBDepartmentUI)
        Try
            frm = parentfrm
            '初始化對象()
            objpub = PubServiceManager.getInstance

            dgvShowData.DataSource = genDS(DataSet_Type.Grid)

            '設定Grid滿屏()
            dgvShowData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

            queryData(strDeptCode)





        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' 查詢事件
    ''' </summary>
    ''' <remarks>True 查詢成功</remarks>
    Public Sub queryData(ByVal strDeptCode As String)
        Dim dsDB As DataSet
        Dim dsGrid As DataSet = genDS(DataSet_Type.Grid)

        '執行查詢()
        dsDB = objpub.queryPubDeptSect_L(strDeptCode)
        Try
            If dsDB.Tables.Count > 0 Then
                If dsDB.Tables(tableDB).Rows.Count > 0 Then
                    '    '查無資料()
                    '    MessageHandling.showWarnMsg("CMMCMMB000", New String() {})
                    '    'MessageHandling.showWarnByKey("CMMCMMB000")
                    'Else
                    Dim drGrid(dsDB.Tables(tableDB).Rows.Count - 1) As DataRow
                    '將查出的資料塞入Grid中()
                    '{"科別代碼", "診別", "名稱", "英文", "科診別名", "科診英文別名", "停用", "建立者", "建立時間", "修改者", "修改時間"}
                    For i As Integer = 0 To dsDB.Tables(tableDB).Rows.Count - 1
                        drGrid(i) = dsGrid.Tables(tableDB).NewRow()
                        'drGrid(i)("科別代碼") = dsDB.Tables(tableDB).Rows(i)("Dept_Code").ToString.Trim()
                        drGrid(i)("診別") = dsDB.Tables(tableDB).Rows(i)("Section_Id").ToString.Trim()
                        drGrid(i)("名稱") = dsDB.Tables(tableDB).Rows(i)("Section_Name").ToString.Trim()
                        drGrid(i)("英文") = dsDB.Tables(tableDB).Rows(i)("Section_En_Name").ToString.Trim()
                        drGrid(i)("科診別名") = dsDB.Tables(tableDB).Rows(i)("Dept_Alias_Name").ToString.Trim()
                        drGrid(i)("科診英文別名") = dsDB.Tables(tableDB).Rows(i)("Dept_Alias_En_Name").ToString.Trim()
                        'If (dsDB.Tables(tableDB).Rows(i)("DC").Equals("Y")) Then
                        '    drGrid(i)("停用") = "是"
                        'Else
                        '    drGrid(i)("停用") = "否"
                        'End If
                        'drGrid(i)("建立者") = StringUtil.nvl(dsDB.Tables(tableDB).Rows(i)("Create_User"))
                        'If StringUtil.nvl(dsDB.Tables(tableDB).Rows(i)("Create_Time")) <> "" Then
                        '    drGrid(i)("建立時間") = CDate(StringUtil.nvl(dsDB.Tables(tableDB).Rows(i)("Create_Time"))).ToString("yyyy/MM/dd HH:mm:ss")
                        'End If
                        'drGrid(i)("修改者") = StringUtil.nvl(dsDB.Tables(tableDB).Rows(i)("Modified_User"))
                        'strTemp = StringUtil.nvl(dsDB.Tables(tableDB).Rows(i)("Modified_Time"))
                        'If strTemp <> "" Then
                        '    drGrid(i)("修改時間") = CDate(strTemp).ToString("yyyy/MM/dd HH:mm:ss")
                        'End If
                        dsGrid.Tables(tableDB).Rows.Add(drGrid(i))
                    Next
                    '資料邦定到Grid()
                    dgvShowData.DataSource = dsGrid

                End If

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class