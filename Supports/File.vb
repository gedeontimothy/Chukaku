Imports System.IO
Namespace Global.Core.Supports

    Public Class File

        Private current_file_path As String = Nothing

        Sub New(Optional ByVal path = Nothing)

            If path IsNot Nothing Then

                Me.current_file_path = path

            End If

        End Sub

        Public Function currentExists()

            If Me.current_file_path IsNot Nothing Then

                Return exists(Me.current_file_path)

            End If

            Return Nothing

        End Function

        Private Function currentVerif()

            If currentExists() = True Then

                Return True

            End If

            Helper.out_red("<" & current_file_path & "> File does Not exist !")

            Return False

        End Function

        Public Function getContents(Optional ByVal toText As Boolean = True)

            If currentVerif() = True Then

                If toText = True Then

                    Return System.IO.File.ReadAllText(Me.current_file_path)

                End If

                Return System.IO.File.ReadAllLines(Me.current_file_path)

            End If

            Return Nothing

        End Function

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