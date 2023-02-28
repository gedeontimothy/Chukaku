Imports System.IO

Namespace Global.Core.Supports

    Public Class Dir

        Sub New()

        End Sub

        Public Shared Function scanDir(ByVal path As String)

            Return Directory.GetDirectories(path)

        End Function

        Public Shared Function root(Optional ByVal path As String = Nothing) As String

            If path IsNot Nothing Then

                path = "\" & path

            End If

            Return Directory.GetCurrentDirectory & path

        End Function
        Public Shared Function exists(ByVal path As String) As Boolean

            Return System.IO.Directory.Exists(path)

        End Function

        Public Shared Function dirFiles(ByVal path As String)

            Return System.IO.Directory.GetFiles(path)

        End Function

        Public Shared Function isDir(path)

            If Dir.exists(path) = False Then

                Return Nothing

            End If

            Return System.IO.File.GetAttributes(path) = System.IO.FileAttributes.Directory

        End Function

    End Class

End Namespace