
'=============================================================================
'========================== 凌群電腦 Syscom ==================================
'=============================================================================
'=======
'======= 程式名稱：手術除數規則
'=======
'======= 程式說明：手術除數規則
'=======
'======= 建立日期：2016-08-10
'=======
'======= 開發人員：James
'=============================================================================
'=============================================================================
'=============================================================================

Public Class PUBOpRuleBP

    '刀別(除數)
    'A:主刀1(1) / 主刀1(1)+主刀5(1)
    'B:主刀1(1) +副刀2 (2)
    'D:主刀1(1) +副刀2 (2)+副刀3(5) / 主刀1(1)+主刀5(1)+副刀2(2)+副刀3(5)
    'E:主刀1(1) +主刀5(1)+副刀2(3)

    ''' <summary>
    ''' 取得除數,批價方式
    ''' </summary>
    ''' <param name="dt">資料</param>
    ''' <remarks>取得Op_Divisor與Material_Type</remarks>
    Public Shared Sub getOpDivisorAndMaterialType(ByVal Source_Id As String, ByRef dt As DataTable)
        Try

            Dim Op_Item_Column As String = "Op_Item"
            Dim Op_Divisor_Column As String = "Op_Divisor"
            Dim Material_Type_Column As String = "Material_Type"

            If Source_Id = "O" Then
                Op_Item_Column = "Or_Item"
                Op_Divisor_Column = "Or_Divisor"
                Material_Type_Column = "Or_Charge_Kind"

                If Not dt.Columns.Contains("Or_Divisor") Then
                    dt.Columns.Add("Or_Divisor")
                End If

                If Not dt.Columns.Contains("Or_Charge_Kind") Then
                    dt.Columns.Add("Or_Charge_Kind")
                End If

            Else
                If Not dt.Columns.Contains("Op_Divisor") Then
                    dt.Columns.Add("Op_Divisor")
                End If

                If Not dt.Columns.Contains("Material_Type") Then
                    dt.Columns.Add("Material_Type")
                End If
            End If
              
            Dim OpOrderCount As Integer = dt.Select(Op_Item_Column & "='1' Or " & Op_Item_Column & "='2' Or " & Op_Item_Column & "='3' Or " & Op_Item_Column & "='5'").Count

            If (OpOrderCount = 1 AndAlso dt.Select(Op_Item_Column & "='1'").Count = 1) OrElse (OpOrderCount = 2 AndAlso dt.Select(Op_Item_Column & "='1'").Count = 1 AndAlso dt.Select(Op_Item_Column & "='5'").Count = 1) Then
                'A:主刀1(1) / 主刀1(1)+主刀5(1)
                For i As Integer = 0 To dt.Rows.Count - 1
                    If dt.Rows(i).Item(Op_Item_Column) = "1" OrElse dt.Rows(i).Item(Op_Item_Column) = "5" Then
                        dt.Rows(i).Item(Op_Divisor_Column) = "1"
                        dt.Rows(i).Item(Material_Type_Column) = "A"
                    End If
                Next

            ElseIf (OpOrderCount = 2 AndAlso dt.Select(Op_Item_Column & "='1'").Count = 1 AndAlso dt.Select(Op_Item_Column & "='2'").Count = 1) Then
                'B:主刀1(1) +副刀2 (2)

                For i As Integer = 0 To dt.Rows.Count - 1
                    If dt.Rows(i).Item(Op_Item_Column) = "1" Then
                        dt.Rows(i).Item(Op_Divisor_Column) = "1"
                        dt.Rows(i).Item(Material_Type_Column) = "B"

                    ElseIf dt.Rows(i).Item(Op_Item_Column) = "2" Then
                        dt.Rows(i).Item(Op_Divisor_Column) = "2"
                        dt.Rows(i).Item(Material_Type_Column) = "B"
                    End If

                Next

            ElseIf (OpOrderCount = 3 AndAlso dt.Select(Op_Item_Column & "='1'").Count = 1 AndAlso dt.Select(Op_Item_Column & "='2'").Count = 1 AndAlso dt.Select(Op_Item_Column & "='3'").Count = 1) Then

                'D:主刀1(1) +副刀2 (2)+副刀3(5)  
                For i As Integer = 0 To dt.Rows.Count - 1
                    If dt.Rows(i).Item(Op_Item_Column) = "1" Then
                        dt.Rows(i).Item(Op_Divisor_Column) = "1"
                        dt.Rows(i).Item(Material_Type_Column) = "D"
                    ElseIf dt.Rows(i).Item(Op_Item_Column) = "2" Then
                        dt.Rows(i).Item(Op_Divisor_Column) = "2"
                        dt.Rows(i).Item(Material_Type_Column) = "D"
                    ElseIf dt.Rows(i).Item(Op_Item_Column) = "3" Then
                        dt.Rows(i).Item(Op_Divisor_Column) = "5"
                        dt.Rows(i).Item(Material_Type_Column) = "D"
                    End If

                Next

            ElseIf (OpOrderCount = 4 AndAlso dt.Select(Op_Item_Column & "='1'").Count = 1 AndAlso dt.Select(Op_Item_Column & "='5'").Count = 1 AndAlso dt.Select(Op_Item_Column & "='2'").Count = 1 AndAlso dt.Select(Op_Item_Column & "='3'").Count = 1) Then
                'D:主刀1(1)+主刀5(1)+副刀2(2)+副刀3(5)
                For i As Integer = 0 To dt.Rows.Count - 1
                    If dt.Rows(i).Item(Op_Item_Column) = "1" Then
                        dt.Rows(i).Item(Op_Divisor_Column) = "1"
                        dt.Rows(i).Item(Material_Type_Column) = "D"
                    ElseIf dt.Rows(i).Item(Op_Item_Column) = "5" Then
                        dt.Rows(i).Item(Op_Divisor_Column) = "1"
                        dt.Rows(i).Item(Material_Type_Column) = "D"
                    ElseIf dt.Rows(i).Item(Op_Item_Column) = "2" Then
                        dt.Rows(i).Item(Op_Divisor_Column) = "2"
                        dt.Rows(i).Item(Material_Type_Column) = "D"
                    ElseIf dt.Rows(i).Item(Op_Item_Column) = "3" Then
                        dt.Rows(i).Item(Op_Divisor_Column) = "5"
                        dt.Rows(i).Item(Material_Type_Column) = "D"
                    End If

                Next

            ElseIf (OpOrderCount = 3 AndAlso dt.Select(Op_Item_Column & "='1'").Count = 1 AndAlso dt.Select(Op_Item_Column & "='5'").Count = 1 AndAlso dt.Select(Op_Item_Column & "='2'").Count = 1) Then
                'E:主刀1(1) +主刀5(1)+副刀2(3)
                For i As Integer = 0 To dt.Rows.Count - 1
                    If dt.Rows(i).Item(Op_Item_Column) = "1" Then
                        dt.Rows(i).Item(Op_Divisor_Column) = "1"
                        dt.Rows(i).Item(Material_Type_Column) = "E"
                    ElseIf dt.Rows(i).Item(Op_Item_Column) = "5" Then
                        dt.Rows(i).Item(Op_Divisor_Column) = "1"
                        dt.Rows(i).Item(Material_Type_Column) = "E"
                    ElseIf dt.Rows(i).Item(Op_Item_Column) = "2" Then
                        dt.Rows(i).Item(Op_Divisor_Column) = "5"
                        dt.Rows(i).Item(Material_Type_Column) = "E"
                    End If

                Next

            End If

        Catch ex As Exception

        End Try

    End Sub

    ''' <summary>
    ''' 判斷是否手術開立符合規定
    ''' </summary>
    ''' <param name="dt">資料</param>
    ''' <remarks>結果</remarks>
    Public Shared Function IsOpOrdersValid(ByVal Source_Id As String, ByVal dt As DataTable) As Boolean
        Try

            Dim Op_Item_Column As String = "Op_Item"
             
            If Source_Id = "O" Then
                Op_Item_Column = "Or_Item"
            End If

            Dim OpOrderCount As Integer = dt.Select(Op_Item_Column & "='1' Or " & Op_Item_Column & "='2' Or " & Op_Item_Column & "='3' Or " & Op_Item_Column & "='5'").Count

            If (OpOrderCount = 1 AndAlso dt.Select(Op_Item_Column & "='1'").Count = 1) OrElse (OpOrderCount = 2 AndAlso dt.Select(Op_Item_Column & "='1'").Count = 1 AndAlso dt.Select(Op_Item_Column & "='5'").Count = 1) Then
                'A:主刀1(1) / 主刀1(1)+主刀5(1)
                Return True

            ElseIf (OpOrderCount = 2 AndAlso dt.Select(Op_Item_Column & "='1'").Count = 1 AndAlso dt.Select(Op_Item_Column & "='2'").Count = 1) Then
                'B:主刀1(1) +副刀2 (2)
                Return True


            ElseIf (OpOrderCount = 3 AndAlso dt.Select(Op_Item_Column & "='1'").Count = 1 AndAlso dt.Select(Op_Item_Column & "='2'").Count = 1 AndAlso dt.Select(Op_Item_Column & "='3'").Count = 1) Then

                'D:主刀1(1) +副刀2 (2)+副刀3(5)  
                Return True

            ElseIf (OpOrderCount = 4 AndAlso dt.Select(Op_Item_Column & "='1'").Count = 1 AndAlso dt.Select(Op_Item_Column & "='5'").Count = 1 AndAlso dt.Select(Op_Item_Column & "='2'").Count = 1 AndAlso dt.Select(Op_Item_Column & "='3'").Count = 1) Then
                'D:主刀1(1)+主刀5(1)+副刀2(2)+副刀3(5)
                Return True

            ElseIf (OpOrderCount = 3 AndAlso dt.Select(Op_Item_Column & "='1'").Count = 1 AndAlso dt.Select(Op_Item_Column & "='5'").Count = 1 AndAlso dt.Select(Op_Item_Column & "='2'").Count = 1) Then
                'E:主刀1(1) +主刀5(1)+副刀2(3)
                Return True

            ElseIf OpOrderCount > 0 Then
                '有開手術 但不符合以上規定
                Return False

            End If

            Return True
        Catch ex As Exception
            Return True
        End Try

    End Function
     
End Class
