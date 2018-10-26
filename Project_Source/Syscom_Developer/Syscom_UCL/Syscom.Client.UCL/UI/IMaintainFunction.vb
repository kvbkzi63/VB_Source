Public Interface IMaintainFunction
    Function insertData() As Boolean
    Function deleteData() As Boolean
    Function updateData() As Boolean
    Function queryData() As Boolean
    Sub clearData()
    Sub selectedDgvData()
    Sub initialData()
End Interface
