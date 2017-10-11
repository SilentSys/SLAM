Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Public Class CustomTabControlc
    Inherits TabControl

    Dim MainColor As Color
    Dim TextColor As Color
    Dim LightTheme As Boolean

    Public Property UseLightTheme() As Boolean
        Get
            Return LightTheme
        End Get
        Set(state As Boolean)
            LightTheme = state
            Refresh()
        End Set
    End Property

    Public Property TabColor As Color
        Get
            Return MainColor
        End Get
        Set(col As Color)
            MainColor = col
            Refresh()
        End Set
    End Property

    Public Property FontColor As Color
        Get
            Return TextColor
        End Get
        Set(col As Color)
            TextColor = col
            Refresh()
        End Set
    End Property

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.ResizeRedraw Or ControlStyles.UserPaint Or ControlStyles.OptimizedDoubleBuffer, True)
        DoubleBuffered = True
        SizeMode = TabSizeMode.Fixed
        ItemSize = New Size(100, 40)
        Size = New Size(400, 250)
        MainColor = Color.DeepPink
        TextColor = Color.White
        LightTheme = False
        Alignment = TabAlignment.Top
    End Sub

    Function ToPen(ByVal color As Color) As Pen
        Return New Pen(color)
    End Function

    Function ToBrush(ByVal color As Color) As Brush
        Return New SolidBrush(color)
    End Function

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim B As New Bitmap(Width, Height)
        Dim G As Graphics = Graphics.FromImage(B)

        'tabpage color
        If LightTheme = False Then
            Try : SelectedTab.BackColor = Color.FromArgb(255, 70, 70, 70) : Catch : End Try
            G.Clear(Color.FromArgb(255, 70, 70, 70))
        Else
            Try : SelectedTab.BackColor = Color.FromArgb(255, 220, 220, 220) : Catch : End Try
            G.Clear(Color.FromArgb(255, 220, 220, 220))
        End If

        'tab bar
        If LightTheme = False Then
            If Alignment = TabAlignment.Top Then
                G.FillRectangle(New SolidBrush(Color.FromArgb(255, 34, 34, 34)), New Rectangle(0, 0, Width, ItemSize.Height))
            ElseIf Alignment = TabAlignment.Bottom Then
                G.FillRectangle(New SolidBrush(Color.FromArgb(255, 34, 34, 34)), New Rectangle(0, Height - ItemSize.Height, Width, ItemSize.Height))
            ElseIf Alignment = TabAlignment.Left Then
                G.FillRectangle(New SolidBrush(Color.FromArgb(255, 34, 34, 34)), New Rectangle(0, 0, ItemSize.Height, Height))
            ElseIf Alignment = TabAlignment.Right Then
                G.FillRectangle(New SolidBrush(Color.FromArgb(255, 34, 34, 34)), New Rectangle(Width - ItemSize.Height, 0, ItemSize.Height, Height))
            End If
        Else
            If Alignment = TabAlignment.Top Then
                G.FillRectangle(New SolidBrush(Color.FromArgb(255, 200, 200, 200)), New Rectangle(0, 0, Width, ItemSize.Height))
            ElseIf Alignment = TabAlignment.Bottom Then
                G.FillRectangle(New SolidBrush(Color.FromArgb(255, 200, 200, 200)), New Rectangle(0, Height - ItemSize.Height, Width, ItemSize.Height))
            ElseIf Alignment = TabAlignment.Left Then
                G.FillRectangle(New SolidBrush(Color.FromArgb(255, 200, 200, 200)), New Rectangle(0, 0, ItemSize.Height, Height))
            ElseIf Alignment = TabAlignment.Right Then
                G.FillRectangle(New SolidBrush(Color.FromArgb(255, 200, 200, 200)), New Rectangle(Width - ItemSize.Height, 0, ItemSize.Height, Height))
            End If
        End If

        'tab bar \ panel separator
        If LightTheme = False Then
            If Alignment = TabAlignment.Top Then
                G.DrawLine(ToPen(Me.MainColor), New Point(0, ItemSize.Height + 3), New Point(Width, ItemSize.Height + 3))
            ElseIf Alignment = TabAlignment.Bottom Then
                G.DrawLine(ToPen(Me.MainColor), New Point(0, Height - ItemSize.Height), New Point(Width, Height - ItemSize.Height))
            ElseIf Alignment = TabAlignment.Left Then
                G.DrawLine(ToPen(Me.MainColor), New Point(ItemSize.Height, 0), New Point(ItemSize.Height, Height))
            ElseIf Alignment = TabAlignment.Right Then
                G.DrawLine(ToPen(Me.MainColor), New Point(Width - ItemSize.Height, 0), New Point(Width - ItemSize.Height, Height))
            End If
        Else
            If Alignment = TabAlignment.Top Then
                G.DrawLine(New Pen(Color.FromArgb(255, 234, 234, 234)), New Point(0, ItemSize.Height), New Point(Width, ItemSize.Height))
            ElseIf Alignment = TabAlignment.Bottom Then
                G.DrawLine(New Pen(Color.FromArgb(255, 234, 234, 234)), New Point(0, Height - ItemSize.Height), New Point(Width, Height - ItemSize.Height))
            ElseIf Alignment = TabAlignment.Left Then
                G.DrawLine(New Pen(Color.FromArgb(255, 234, 234, 234)), New Point(ItemSize.Height, 0), New Point(ItemSize.Height, Height))
            ElseIf Alignment = TabAlignment.Right Then
                G.DrawLine(New Pen(Color.FromArgb(255, 234, 234, 234)), New Point(Width - ItemSize.Height, 0), New Point(Width - ItemSize.Height, Height))
            End If
        End If

        'selected tab stuff
        For i = 0 To TabCount - 1
            If i = SelectedIndex Then
                Dim x2 As Rectangle = New Rectangle(GetTabRect(i).Location.X, GetTabRect(i).Location.Y, GetTabRect(i).Width, GetTabRect(i).Height)
                Dim myblend As New ColorBlend()
                myblend.Colors = {Me.MainColor, Me.MainColor, Me.MainColor} 'colors
                myblend.Positions = {0.0F, 0.5F, 1.0F}
                Dim lgBrush As New LinearGradientBrush(x2, Color.Black, Color.Black, 90.0F)
                lgBrush.InterpolationColors = myblend
                G.FillRectangle(lgBrush, x2)
                If LightTheme = False Then
                    G.DrawRectangle(New Pen(Color.FromArgb(255, 34, 34, 34)), x2)
                Else
                    G.DrawRectangle(New Pen(Color.FromArgb(255, 200, 200, 200)), x2)
                End If

                'pointer (triange)
                G.SmoothingMode = SmoothingMode.HighQuality

                Dim pt As New Point
                Dim pc As New Point
                Dim pb As New Point

                If Alignment = TabAlignment.Top Then
                    pt = New Point(GetTabRect(i).Location.X + ItemSize.Width / 2 - 5, ItemSize.Height + 2)
                    pc = New Point(GetTabRect(i).Location.X + ItemSize.Width / 2, ItemSize.Height - 5)
                    pb = New Point(GetTabRect(i).Location.X + ItemSize.Width / 2 + 5, ItemSize.Height + 2)
                ElseIf Alignment = TabAlignment.Bottom Then
                    pt = New Point(GetTabRect(i).Location.X + ItemSize.Width / 2 - 5, Height - ItemSize.Height - 2)
                    pc = New Point(GetTabRect(i).Location.X + ItemSize.Width / 2, Height - ItemSize.Height + 5)
                    pb = New Point(GetTabRect(i).Location.X + ItemSize.Width / 2 + 5, Height - ItemSize.Height - 2)
                ElseIf Alignment = TabAlignment.Left Then
                    pt = New Point(ItemSize.Height + 2, GetTabRect(i).Location.Y + ItemSize.Width / 2 - 5)
                    pc = New Point(ItemSize.Height - 5, GetTabRect(i).Location.Y + ItemSize.Width / 2)
                    pb = New Point(ItemSize.Height + 2, GetTabRect(i).Location.Y + ItemSize.Width / 2 + 5)
                ElseIf Alignment = TabAlignment.Right Then
                    pt = New Point(Width - ItemSize.Height - 2, GetTabRect(i).Location.Y + ItemSize.Width / 2 - 5)
                    pc = New Point(Width - ItemSize.Height + 5, GetTabRect(i).Location.Y + ItemSize.Width / 2)
                    pb = New Point(Width - ItemSize.Height - 2, GetTabRect(i).Location.Y + ItemSize.Width / 2 + 5)
                End If

                Dim p() As Point = {pt, pc, pb}

                If LightTheme = False Then
                    G.FillPolygon(ToBrush(Color.FromArgb(255, 70, 70, 70)), p) ' pointer color
                    G.DrawPolygon(New Pen(Color.FromArgb(255, 70, 70, 70)), p)
                Else
                    G.FillPolygon(ToBrush(Color.FromArgb(255, 220, 220, 220)), p) ' pointer color
                    G.DrawPolygon(New Pen(Color.FromArgb(255, 220, 220, 220)), p)
                End If

                ' AREA 1
                'paste here.........................................................................................
                If ImageList IsNot Nothing Then
                    Try
                        If ImageList.Images(TabPages(i).ImageIndex) IsNot Nothing Then

                            G.DrawImage(ImageList.Images(TabPages(i).ImageIndex), New Point(x2.Location.X + 8, x2.Location.Y + 6))
                            G.DrawString("      " & TabPages(i).Text, Font, Me.ToBrush(Me.TextColor), x2, New StringFormat With {.LineAlignment = StringAlignment.Center, .Alignment = StringAlignment.Center})
                        Else
                            G.DrawString(TabPages(i).Text, New Font(Font.FontFamily, Font.Size, FontStyle.Bold), Me.ToBrush(Me.TextColor), x2, New StringFormat With {.LineAlignment = StringAlignment.Center, .Alignment = StringAlignment.Center})
                        End If
                    Catch ex As Exception
                        G.DrawString(TabPages(i).Text, New Font(Font.FontFamily, Font.Size, FontStyle.Bold), Me.ToBrush(Me.TextColor), x2, New StringFormat With {.LineAlignment = StringAlignment.Center, .Alignment = StringAlignment.Center})
                    End Try
                Else
                    G.DrawString(TabPages(i).Text, New Font(Font.FontFamily, Font.Size, FontStyle.Bold), Me.ToBrush(Me.TextColor), x2, New StringFormat With {.LineAlignment = StringAlignment.Center, .Alignment = StringAlignment.Center})
                End If
                '...................................................................................................

                If LightTheme = False Then
                    G.DrawLine(New Pen(Color.FromArgb(255, 0, 0, 0)), New Point(x2.Location.X - 1, x2.Location.Y - 1), New Point(x2.Location.X, x2.Location.Y))
                    G.DrawLine(New Pen(Color.FromArgb(255, 0, 0, 0)), New Point(x2.Location.X - 1, x2.Bottom - 1), New Point(x2.Location.X, x2.Bottom))
                Else
                    G.DrawLine(New Pen(Color.FromArgb(255, 255, 255, 255)), New Point(x2.Location.X - 1, x2.Location.Y - 1), New Point(x2.Location.X, x2.Location.Y))
                    G.DrawLine(New Pen(Color.FromArgb(255, 255, 255, 255)), New Point(x2.Location.X - 1, x2.Bottom - 1), New Point(x2.Location.X, x2.Bottom))
                End If

            Else
                Dim x1 As Rectangle = New Rectangle(GetTabRect(i).Location.X, GetTabRect(i).Location.Y, GetTabRect(i).Width, GetTabRect(i).Height)
                ' unselected tab color
                If LightTheme = False Then
                    G.FillRectangle(New SolidBrush(Color.FromArgb(255, 0, 0, 0)), x1)
                Else
                    G.FillRectangle(New SolidBrush(Color.FromArgb(255, 255, 255, 255)), x1)
                End If

                'tab borders
                If Alignment = TabAlignment.Top Then
                    G.DrawLine(New Pen(MainColor), New Point(x1.Left, x1.Bottom), New Point(x1.Right, x1.Bottom))
                ElseIf Alignment = TabAlignment.Bottom Then
                    G.DrawLine(New Pen(MainColor), New Point(x1.Left, x1.Top), New Point(x1.Right, x1.Top))
                ElseIf Alignment = TabAlignment.Left Then
                    G.DrawLine(New Pen(MainColor), New Point(x1.Right, x1.Top), New Point(x1.Right, x1.Bottom))
                ElseIf Alignment = TabAlignment.Right Then
                    G.DrawLine(New Pen(MainColor), New Point(x1.Left, x1.Top), New Point(x1.Left, x1.Bottom))
                End If

                ' AREA 2
                'paste here......................................................................................
                If LightTheme = False Then
                    If ImageList IsNot Nothing Then
                        Try
                            If ImageList.Images(TabPages(i).ImageIndex) IsNot Nothing Then
                                G.DrawImage(ImageList.Images(TabPages(i).ImageIndex), New Point(x1.Location.X + 8, x1.Location.Y + 6))
                                G.DrawString("      " & TabPages(i).Text, Font, Brushes.White, x1, New StringFormat With {.LineAlignment = StringAlignment.Center, .Alignment = StringAlignment.Center})
                            Else
                                G.DrawString(TabPages(i).Text, Font, Brushes.White, x1, New StringFormat With {.LineAlignment = StringAlignment.Center, .Alignment = StringAlignment.Center})
                            End If
                        Catch ex As Exception
                            G.DrawString(TabPages(i).Text, Font, Brushes.White, x1, New StringFormat With {.LineAlignment = StringAlignment.Center, .Alignment = StringAlignment.Center})
                        End Try
                    Else
                        G.DrawString(TabPages(i).Text, Font, Brushes.White, x1, New StringFormat With {.LineAlignment = StringAlignment.Center, .Alignment = StringAlignment.Center})
                    End If
                ElseIf LightTheme = True Then
                    If ImageList IsNot Nothing Then
                        Try
                            If ImageList.Images(TabPages(i).ImageIndex) IsNot Nothing Then
                                G.DrawImage(ImageList.Images(TabPages(i).ImageIndex), New Point(x1.Location.X + 8, x1.Location.Y + 6))
                                G.DrawString("      " & TabPages(i).Text, Font, ToBrush(Color.FromArgb(255, 64, 64, 64)), x1, New StringFormat With {.LineAlignment = StringAlignment.Center, .Alignment = StringAlignment.Center})
                            Else
                                G.DrawString(TabPages(i).Text, Font, ToBrush(Color.FromArgb(255, 64, 64, 64)), x1, New StringFormat With {.LineAlignment = StringAlignment.Center, .Alignment = StringAlignment.Center})
                            End If
                        Catch ex As Exception
                            G.DrawString(TabPages(i).Text, Font, ToBrush(Color.FromArgb(255, 64, 64, 64)), x1, New StringFormat With {.LineAlignment = StringAlignment.Center, .Alignment = StringAlignment.Center})
                        End Try
                    Else
                        G.DrawString(TabPages(i).Text, Font, ToBrush(Color.FromArgb(255, 64, 64, 64)), x1, New StringFormat With {.LineAlignment = StringAlignment.Center, .Alignment = StringAlignment.Center})
                    End If
                    '................................................................................................

                End If
            End If
        Next

        e.Graphics.DrawImage(B.Clone, 0, 0)
        G.Dispose() : B.Dispose()

    End Sub
End Class