Imports System.IO
Namespace Global.Core.Supports

    Public Class File

        Private current_file_path As String

        Sub New(Optional ByVal path = Nothing)

            If path IsNot Nothing Then

                Me.current_file_path = path

            End If

        End Sub

        Public Shared Function exists(ByVal file_path As String) As Boolean

            Return System.IO.File.Exists(file_path)

        End Function

        Public Shared Function is_file(file_path)

            If exists(file_path) = False Then

                Return Nothing

            ElseIf Dir.is_dir(file_path) = False

                Return True

            End If

            Return False

        End Function

    End Class

End Namespace