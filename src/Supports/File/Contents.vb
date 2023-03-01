Namespace Global.Chukaku.Supports.FileServices

    Public Class Contents

        Inherits Chukaku.Supports.FileServices.Helper

        Public Function setContentsLines(ByVal lines)

            If Me.currentVerif() = True Then

                Try

                    System.IO.File.WriteAllLines(MyBase.current_file_path, lines)

                    Return True

                Catch ex As System.ArgumentNullException

                    Me.addError("path ou contents est null.")

                Catch ex As System.ArgumentException

                    Me.addError("path est une chaîne de longueur nulle, ne contient que des espaces blancs ou contient un ou plusieurs caractères non valides comme défini par Public Shared ReadOnly InvalidPathChars As Char().")

                Catch ex As System.IO.PathTooLongException

                    Me.addError(Chukaku.Helper.out_text("Le chemin d'accès, le nom de fichier spécifié ou les deux dépassent la longueur maximale définie par le système.") &
                                Chukaku.Helper.out_text("Par exemple, sur les plateformes Windows, les chemins d'accès et les noms de fichiers ne doivent pas comporter plus de 248 et 260 caractères, respectivement."))

                Catch ex As System.IO.DirectoryNotFoundException

                    Me.addError("Le chemin d'accès spécifié n'est pas valide (il se trouve, par exemple, sur un lecteur non mappé).")

                Catch ex As System.IO.IOException

                    Me.addError("Une erreur d'E/S s'est produite lors de l'ouverture du fichier.")

                Catch ex As System.UnauthorizedAccessException

                    Me.addError("path a spécifié un fichier qui est en lecture seule.ou Cette opération n'est pas prise en charge sur la plateforme actuelle.ou path a spécifié un répertoire.ou L'appelant n'a pas l'autorisation requise.")

                Catch ex As System.NotSupportedException

                    Me.addError("Le format de path n'est pas valide.")

                Catch ex As System.Security.SecurityException

                    Me.addError("L'appelant n'a pas l'autorisation requise.")

                End Try

                Return False

            End If

            Return Nothing

        End Function

        Public Function setContents(ByVal contents)

            If Me.currentVerif() = True Then

                Try

                    System.IO.File.WriteAllText(MyBase.current_file_path, contents)

                    Return True

                Catch ex As System.IO.PathTooLongException

                    Me.addError(Chukaku.Helper.out_text("Le chemin d'accès, le nom de fichier spécifié ou les deux dépassent la longueur maximale définie par le système.") &
                        Chukaku.Helper.out_text("Par exemple, sur les plateformes Windows, les chemins d'accès et les noms de fichiers ne doivent pas comporter plus de 248 et 260 caractères, respectivement."), False)

                Catch ex As System.IO.DirectoryNotFoundException

                    Me.addError("Le chemin d'accès spécifié n'est pas valide (il se trouve, par exemple, sur un lecteur non mappé).")

                Catch ex As System.IO.IOException

                    Me.addError("Une erreur d'E/S s'est produite lors de l'ouverture du fichier.")

                Catch ex As System.UnauthorizedAccessException

                    Me.addError(Chukaku.Helper.out_text("Path a spécifié un fichier qui est en lecture seule.ou Cette opération n'est pas prise en charge sur") &
                                Chukaku.Helper.out_text("la plateforme actuelle.ou path a spécifié un répertoire.ou L'appelant n'a pas l'autorisation requise."), False)

                Catch ex As System.NotSupportedException

                    Me.addError("Le Format de path n'est pas valide.")

                Catch ex As System.Security.SecurityException

                    Me.addError("L 'appelant n'a pas l'autorisation requise.")

                End Try


                Return False

            End If

            Return Nothing

        End Function

        Public Function getContents(Optional ByVal toText As Boolean = True)

            If Me.currentVerif() = True Then

                If toText = True Then

                    Return System.IO.File.ReadAllText(MyBase.current_file_path)

                End If

                Return System.IO.File.ReadAllLines(MyBase.current_file_path)

            End If

            Return Nothing

        End Function

        Public Function countLines()

            If Me.currentExists() Then

                Return Me.getContents(False).Length

            End If

            Return Nothing

        End Function

    End Class

End Namespace
