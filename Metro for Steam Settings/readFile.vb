Imports System.IO

Public Class readFile
    Public contents As String
    Public Sub New(_file As String)
        If File.Exists(_file) Then
            Dim file As New StreamReader(_file)
            contents = file.ReadToEnd()
            file.Close()
        End If
    End Sub
End Class