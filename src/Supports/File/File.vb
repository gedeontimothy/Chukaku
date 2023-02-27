Imports System.IO
Namespace Global.Core.Supports

    Public Class File

        Inherits FileServices.Contents

        Sub New(Optional ByVal path = Nothing)

            If path IsNot Nothing Then

                Me.current_file_path = path

            End If

        End Sub

    End Class

End Namespace