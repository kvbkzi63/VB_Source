Imports System.Runtime.CompilerServices

Public Module UCLDataGridViewUIExtension

    ''' <summary>
    ''' 回傳DataGridView中所勾選之Index,
    ''' </summary>
    ''' <param name="uclDgv">UCL DataGridView</param>
    ''' <returns>index array</returns>
    ''' <author>Ken</author>
    ''' <date>2009-12-16</date>
    ''' <remarks>與GetSelectedIndex不同之處為當無勾選項目時，回傳的是空array，不是Null</remarks>
    <Extension()> _
    Public Function SelectedIndex(ByVal uclDgv As Syscom.Client.ucl.UCLDataGridViewUC) As Int32()

        Dim index As Int32() = uclDgv.GetSelectedIndex
        If index Is Nothing Then index = New Int32() {}
        Return index
    End Function

End Module
