Namespace Global.Chukaku.Supports

    Public MustInherit Class ErrorManage

        Protected error_message(-1) As String

        Public Sub eachError()

            If Me.error_message.Length = 0 Then

                Chukaku.Helper.out_red("Aucune erreur !")

                Exit Sub

            End If

            Chukaku.Helper.out_red(Chukaku.Helper.title("LE PARCOUR D'ERREUR"))

            For Each value In Me.error_message

                Chukaku.Helper.out_red(value, True, "        ")

            Next

        End Sub

        Public Function getError(Optional ByVal key = Nothing)

            If key IsNot Nothing Then

                Return Me.error_message(key)

            End If

            Return Me.error_message

        End Function

        Public Function getLastError()

            If Me.error_message.Length = 0 Then

                Return False

            End If

            Return Me.error_message(Me.error_message.Length - 1)

        End Function

        Public Function getFirstError()

            Return Me.error_message(0)

        End Function

        Protected Sub setError(ByVal message() As String)

            Me.error_message = message

        End Sub

        Protected Function redimError() As Integer

            Dim dms = Me.error_message.Length

            ReDim Preserve Me.error_message(dms)

            Return dms

        End Function

        Protected Sub addError(ByVal message As String, Optional out As Boolean = True)

            Dim key As Integer = Me.redimError()

            If out = True Then

                Me.error_message(key) = Chukaku.Helper.title("Error N°" & key + 1, "||", "=") & Chukaku.Helper.out_text(message)

            Else

                Me.error_message(key) = message

            End If

        End Sub


    End Class

End Namespace
