
Public Interface IMaintainMultichoiceFunction
    Function SaveData() As Boolean
    Function DeleteData() As Boolean
    Function QueryData() As Boolean
    Sub ClearData()
    Sub SelectedDgvData()
    Sub InitialData()
End Interface
