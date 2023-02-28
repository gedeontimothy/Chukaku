Imports System.IO
Namespace Global.Core.Supports

    Public Class File

        Inherits FileServices.Contents

        Protected read_line_current_error As Boolean = False

        Sub New(Optional ByVal path = Nothing)

            If path IsNot Nothing Then

                Me.current_file_path = path

            End If

        End Sub

        Public Function readLineCurrentError() As Boolean

            Return Me.read_line_current_error

        End Function

        Public Function readLines()

            If Me.currentExists() Then

                Try

                    Return System.IO.File.ReadLines(Me.current_file_path)

                Catch ex As System.ArgumentNullException

                    Me.addError("path a la valeur null.")

                Catch ex As System.IO.DirectoryNotFoundException

                    Me.addError("path n'est pas valide (par exemple, il se trouve sur un lecteur non mappé).")

                Catch ex As System.IO.FileNotFoundException

                    Me.addError("Le fichier spécifié par path est introuvable.")

                Catch ex As System.IO.PathTooLongException

                    Me.addError(Global.Helper.out_text("path dépasse la longueur maximale définie par le système.") &
                                Global.Helper.out_text("Par exemple, sur les plateformes Windows, les chemins et les noms de fichiers ne doivent pas dépasser, respectivement, 248 et 260 caractères."))

                Catch ex As System.IO.IOException

                    Me.addError("Une erreur d'E/S s'est produite lors de l'ouverture du fichier.")

                Catch ex As System.Security.SecurityException

                    Me.addError("L'appelant n'a pas l'autorisation requise.")

                Catch ex As System.UnauthorizedAccessException

                    Me.addError("path spécifie un fichier qui est en lecture seule ou cette opération n'est pas prise en charge sur la plateforme actuelle ou path est un répertoire ou l'appelant n'a pas l'autorisation requise.")

                End Try

                Me.read_line_current_error = True

                Return False

            End If

            Return Nothing

        End Function

        Public Function create(Optional ByVal replace As Boolean = True)

            If Me.currentExists() = False Or (Me.currentExists() = True And replace = True) Then

                Try

                    System.IO.File.Create(Me.current_file_path)

                    Return True

                Catch ex As System.UnauthorizedAccessException

                    Me.addError("L'appelant n'a pas l'autorisation requise.ou path a spécifié un fichier qui est en lecture seule.")

                Catch ex As System.ArgumentNullException

                    Me.addError("path a la valeur null.")

                Catch ex As System.ArgumentException

                    Me.addError("path est une chaîne de longueur nulle, ne contient que des espaces blancs ou contient un ou plusieurs caractères non valides comme défini par Public Shared ReadOnly InvalidPathChars As Char().")

                Catch ex As System.IO.PathTooLongException

                    Me.addError(Global.Helper.out_text("Le chemin d'accès, le nom de fichier spécifié ou les deux dépassent la longueur maximale définie par le système.") &
                                Global.Helper.out_text("Par exemple, sur les plateformes Windows, les chemins d'accès et les noms de fichiers ne doivent pas comporter plus de 248 et 260 caractères, respectivement."))

                Catch ex As System.IO.DirectoryNotFoundException

                    Me.addError("Le chemin d'accès spécifié n'est pas valide (il se trouve, par exemple, sur un lecteur non mappé).")

                Catch ex As System.IO.IOException

                    Me.addError("Une erreur d'E/S s'est produite lors de la création du fichier.")

                Catch ex As System.NotSupportedException

                    Me.addError("Le format de path n'est pas valide.")

                End Try

            ElseIf Me.currentExists() = True And replace = False

                Me.addError("Le fichier <" & Me.current_file_path & "> existe déjà.")

                Return False

            End If

            Return Nothing

        End Function

    End Class

End Namespace