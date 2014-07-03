Imports System.IO
Imports System.Text.RegularExpressions

Public Class skinList
    Public skinsDirectory As New ArrayList
    Public skinsLabel As New ArrayList
    Public count As Int16 = 0
    Public Sub New(path As String)
        Dim dirInfo = New DirectoryInfo(path + "\skins").GetDirectories
        Dim skinPathRgx = New Regex("Metro For Steam", RegexOptions.IgnoreCase)
        Dim versionRgx = New Regex("[0-9]\.[0-9](\.[0-9]|)")
        For Each folder In dirInfo
            Dim temppath = folder.Name.ToString()

            Dim menufile = path + "\skins\" + temppath + "\resource\menus\steam.menu"

            If File.Exists(menufile) Then
                Dim menufileb = New readFile(menufile)
                Dim menufile_contents = menufileb.contents
                If skinPathRgx.IsMatch(menufile_contents) Then
                    Dim version_match = versionRgx.Match(menufile_contents)
                    If versionRgx.IsMatch(menufile_contents) Then
                        skinsDirectory.Add(temppath)
                        skinsLabel.Add(temppath + " [" + version_match.ToString + "]")
                        count += 1
                    End If
                End If
            End If
        Next
    End Sub
End Class
