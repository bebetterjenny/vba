Sub sumInEachSheet()

' Add a new sheet to record all the sum
' You can change the sheet name but remember to the change it in the last 2 line!
Sheets.Add(After:=Sheets(Sheets.Count)).Name = "sumInEachSheet"
Dim i As Integer
i = 2


' Declare Current as a worksheet object variable.
Dim Current As Worksheet

' Loop through all of the worksheets in the active workbook.
	For Each Current In Worksheets
    
    Dim lastColNum As Integer
    Dim lastCol As String
    lastColNum = Current.Cells(14, Columns.Count).End(xlToLeft).Column
    lastCol = ConvertToLetter(lastColNum)
    
    Dim lastRow As Integer
    lastRow = Current.Cells(Rows.Count, 2).End(xlUp).Row + 2
    Current.Select

    'change the range to sum: 16 & 85
    Dim calRange As String
    calRange = lastCol & lastRow
    Dim sumRange As String
    sumRange = lastCol & "16:" & lastCol & "85"
    Dim sum As Integer
    sum = WorksheetFunction.sum(Range(sumRange))
    Range(calRange) = sum
    
    
    'change the sheet name if you changed it before
    Sheets("sumInEachSheet").Range("B" & i).Value = Current.Range(calRange)

    
    i = i + 1
    
Next
    
End Sub

Function ConvertToLetter(iCol) As String
   Dim iAlpha As Integer
   Dim iRemainder As Integer
   iAlpha = Int(iCol / 27)
   iRemainder = iCol - (iAlpha * 26)
   If iAlpha > 0 Then
      ConvertToLetter = Chr(iAlpha + 64)
   End If
   If iRemainder > 0 Then
      ConvertToLetter = ConvertToLetter & Chr(iRemainder + 64)
   End If
End Function