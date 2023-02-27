Namespace Global

    Public Class Helper

        ' |======= TABULATION START -->

        Public Shared tabs = "   "

        Private Shared Function getTab(tab)

            If is_null(tab) Then

                Return tabs

            End If

            Return tab

        End Function

        Public Shared Sub resetTab()

            tabs = "   "

        End Sub

        ' <-- TABULATION STOP =======|









        ' >======= WRITE START -->

        Public Shared Function write_integer(Optional ByVal message() = Nothing) As Integer

            If message Is Nothing Then

                ReDim message(1)

                message = {"Entrez le nombre -> ", "Incorrect !"}

            End If

            Dim inp = Nothing

            Dim loop_ As Boolean = True

            While loop_

                out_inline(message(0), False)

                inp = Console.ReadLine()

                If (IsNumeric(inp)) Then

                    inp = Int32.Parse(inp)

                    loop_ = False

                Else

                    out_red(message(1))

                End If

            End While

            Return inp

        End Function

        Public Shared Function write_string(Optional ByVal message() = Nothing) As String

            If message Is Nothing Then

                ReDim message(1)

                message = {"Entrez le text : ", "Incorrect !"}

            End If

            Dim inp = Nothing

            Dim loop_ As Boolean = True

            While loop_

                out_inline(message(0), False)

                inp = Console.ReadLine()

                If (TypeOf inp Is String) Then

                    loop_ = False

                Else

                    out_red(message(1))

                End If

            End While

            Return inp

        End Function

        ' <-- WRITE STOP =======<









        ' |======= OUT START -->

        Public Shared Sub out_red(text, ByVal Optional lf_ = True, ByVal Optional tab = Nothing)

            tab = getTab(tab)

            Console.ForegroundColor = ConsoleColor.Red

            out(text, lf_, tab)

            Console.ResetColor()

        End Sub

        Public Shared Sub out(text, ByVal Optional lf_ = True, Optional tab = Nothing)

            tab = getTab(tab)

            lf_ = lf(lf_)

            If (text Is Nothing) Then

                text = ""

            End If

            Console.Write(lf_ & tab & text.ToString)

        End Sub

        Public Shared Sub out_inline(ByVal text, ByVal Optional lf_ = True, ByVal Optional tab = Nothing)

            tab = getTab(tab)

            lf_ = lf(lf_)

            If (text Is Nothing) Then

                text = ""

            End If

            Console.Write(lf_ & tab & text.ToString)

        End Sub

        ' <-- OUT STOP =======|









        ' |======= SPECIFIC START -->
        Public Shared Function title(ByVal text As String, Optional between_x_symbol As String = "|", Optional between_y_symbol As String = "-", Optional tab As String = Nothing) 'As String

            tab = getTab(tab)

            text = between_x_symbol & "  " & text & "  " & between_x_symbol

            Dim symb_y As String = tab

            For i = 1 To text.Length

                symb_y &= "-"

            Next

            Return vbLf & symb_y & vbLf & tab & text & vbLf & symb_y

        End Function

        Public Shared Sub pause(ByVal Optional text = Nothing, ByVal Optional lf_ = True, ByVal Optional tab = Nothing)

            tab = getTab(tab)

            If text IsNot Nothing Then

                out(text, lf_, tab)

            End If

            Console.Read()

        End Sub

        Public Shared Function lf(Optional ver = True)

            If ver = True Then

                ver = vbLf

            ElseIf ver = False

                ver = ""

            ElseIf ver IsNot Nothing And IsNumeric(ver) And Int32.Parse(ver) > 0

                Dim reco = ""

                For i = 1 To Int32.Parse(ver)

                    reco &= vbLf

                Next

                ver = reco

            End If

            Return ver

        End Function

        Public Shared Sub atl(Optional ver As Integer = 1)

            Console.Write(lf(ver))

        End Sub

        Public Shared Sub var_dump(expression)

            Debug.Print(expression)

        End Sub

        ' <-- SPECIFIC STOP =======|









        ' |======= CHECKER START -->

        Public Shared Function is_null(ByVal value)

            If value Is Nothing Then

                Return True

            Else

                Return False

            End If

        End Function

        Public Shared Function is_array(ByVal value)

            Return IsArray(value)

        End Function

        Public Shared Function array_initialized(ByVal value)

            If is_null(value) Then

                Return False

            ElseIf IsArray(value)

                Return True

            End If

            Return Nothing

        End Function

        Public Shared Function empty(ByVal value)

            'If (is_array(value) And array_initialized(value)) Or (value.GetType().ToString = "System.String" And String.IsNullOrEmpty(value)) Or is_null(value) Then
            If (value.GetType().ToString = "System.String" And String.IsNullOrEmpty(value)) Or is_null(value) Then

                Return True

            Else

                Return False

            End If

        End Function

        ' <-- CHECKER STOP =======|









        ' |======= FILE START -->

        Public Shared Function file_exists(ByVal file_path As String) As Boolean

            Return Core.Supports.File.exists(file_path)

        End Function

        Public Shared Function dir_exists(ByVal path As String) As Boolean

            Return Core.Supports.Dir.exists(path)

        End Function

        Public Shared Function root(Optional ByVal path As String = Nothing) As String

            Return Core.Supports.Dir.root(path)

        End Function

        Public Shared Function is_file(ByVal f_path as String)

            Return Core.Supports.File.is_file(f_path)

        End Function

        Public Shared Function is_dir(ByVal path As String)

            Return Core.Supports.Dir.is_dir(path)

        End Function

        Public Shared Function file_gets_contents(ByVal path As String, Optional ByVal toString As Boolean = True)

            Dim file = New Core.Supports.File(path)

            Return file.getContents()

        End Function

        ' <-- FILE STOP =======|

    End Class

End Namespace