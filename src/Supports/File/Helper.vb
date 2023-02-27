Namespace Global.Core.Supports.FileServices

    Public Class Helper

        Inherits Foundation

        Protected Function currentVerif() As Boolean

            If Me.currentExists() = True Then

                Return True

            End If

            Me.addError("Le fichier <" & Me.current_file_path & "> n'existe pas")

            Return False

        End Function

        Public Function currentExists() As Boolean

            If Me.current_file_path IsNot Nothing Then

                Return exists(Me.current_file_path)

            End If

            Return Nothing

        End Function

        Public Shared Function exists(ByVal file_path As String) As Boolean

            Return System.IO.File.Exists(file_path)

        End Function

        Public Shared Function is_file(file_path) As Boolean

            If exists(file_path) = False Then

                Return Nothing

            ElseIf Dir.is_dir(file_path) = False

                Return True

            End If

            Return False

        End Function

    End Class

End Namespace
