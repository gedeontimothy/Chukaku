Namespace Global.Core.Supports

    Public Class Menu

        Inherits Helper

        Private Shared instance

        Private index_selected = Nothing

        Protected datas(-1) As MenuStruct

        Protected element As Integer = -1

        Protected Structure MenuStruct

            Dim key As String

            Dim title As String

            Dim call_back

        End Structure

        Public Shared Function getNew() As Menu

            Return New Menu()

        End Function

        Public Shared Function getInstance() As Menu

            If (instance Is Nothing) Then

                instance = New Menu()

            End If

            Return instance

        End Function

        Public Function add(ByVal key As String, ByVal title As String, Optional ByVal call_back As Object = Nothing) As Menu

            If Me.keyExists(key) = False Then

                'If Me.element = Me.dimension Then

                'End If

                Me.element += 1

                Me.datasRedim(Me.element)

                Me.datas(Me.element).key = key

                Me.datas(Me.element).title = title

                Me.datas(Me.element).call_back = call_back

            End If

            Return Me

        End Function

        Public Function keyExists(ByVal key As String) As Boolean

            If Me.element > 0 Then

                For Each value In Me.datas

                    If value.key.Trim.ToLower = key.Trim.ToLower Then

                        Console.WriteLine(vbLf & "   !!!  La clé " & key & " existe déjà  !!!" & vbLf)

                        Return True

                    End If

                Next

            End If

            Return False

        End Function

        Public Function choice(ByVal Optional loop_ As Boolean = True)

            Dim choice_ = Nothing

            Do

                out(title("Menu"))

                atl()

                For Each value In datas

                    'Console.WriteLine(vbLf & "   " & value.key.ToUpper & " - " & value.title)

                    out(value.key.ToUpper & " - " & value.title & vbLf, True, vbTab)

                Next

                choice_ = Me.getByKey(write_string({
                    vbLf & "   Faites votre choix : ",
                    vbLf & "    Incorrect !"
                }))

                If choice_ IsNot Nothing Then

                    loop_ = False

                    Me.setSelected(choice_(0))

                    choice_ = New With {.key = choice_(1).key, .title = choice_(1).title}


                ElseIf loop_ = True

                    out_red("!! Faites un choix judicieux. Réessayez !!")

                Else

                    Return Nothing

                End If

            Loop While loop_

            Return choice_

        End Function

        Public Sub verif()

            Console.WriteLine("   -----------" & vbLf & "   |  Debug  |" & vbLf & "   -----------" & vbLf)

            Console.WriteLine("   Item de menu => " & Me.datas.Count & vbLf)

            Console.WriteLine("   Les elements => " & (Me.element + 1) & vbLf)

            'Console.WriteLine("   Les Dimension => " & Me.dimension & vbLf)

            For Each value In Me.datas

                Console.WriteLine(vbLf & "      Element(" & Array.IndexOf(Me.datas, value) & ") => " & "key(" & value.key & ") title(" & value.title & ")")

            Next

        End Sub

        Protected Sub datasRedim(ByVal Optional size = Nothing)

            If size Is Nothing Then ' or is_int = false

                size = Me.element

            End If

            ReDim Preserve Me.datas(size)

        End Sub

        Protected Sub setSelected(ByVal index As String)

            Me.index_selected = index

        End Sub
        Public Function getSelected() As Object

            If Me.index_selected IsNot Nothing Then

                Return Me.datas(index_selected)

            End If

            Return Nothing

        End Function

        Public Function getData(ByVal key, Optional by_key = True) As Object

            If by_key = True Then

                Return Me.getByKey(key)(1)

            End If

            Return Me.getByIndex(key)

        End Function
        Protected Function getByKey(ByVal key As String) As Object

            For Each value In Me.datas

                If value.key.Trim.ToLower = key.Trim.ToLower Then

                    Return {Array.IndexOf(Me.datas, value), value}

                End If

            Next

            Return Nothing

        End Function

        Protected Function getByIndex(ByVal i As Integer) As Object

            Return Me.datas(i)

        End Function

    End Class

End Namespace