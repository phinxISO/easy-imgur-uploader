Imports System.Drawing.Drawing2D, System.ComponentModel, System.Windows.Forms

<ToolboxBitmap("")> _
Class eButton
    Inherits Control

#Region " Mouse States"
    Enum MouseState As Byte
        None = 0
        Over = 1
        Down = 2
        Block = 3
    End Enum
#End Region

#Region " Variables"
    Friend G As Graphics, B As Bitmap
    Friend _FlatColor As Color = Color.FromArgb(35, 168, 109)
    Friend NearSF As New StringFormat() With {.Alignment = StringAlignment.Near, .LineAlignment = StringAlignment.Near}
    Friend CenterSF As New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center}
#End Region

#Region " Functions"

    Public Function RoundRec(ByVal Rectangle As Rectangle, ByVal Curve As Integer) As GraphicsPath
        Dim P As GraphicsPath = New GraphicsPath()
        Dim ArcRectangleWidth As Integer
        If Curve = 0 Then ArcRectangleWidth = 1 Else ArcRectangleWidth = Curve * 2
        P.AddArc(New Rectangle(Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -180, 90)
        P.AddArc(New Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -90, 90)
        P.AddArc(New Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 0, 90)
        P.AddArc(New Rectangle(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 90, 90)
        P.AddLine(New Point(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y), New Point(Rectangle.X, Curve + Rectangle.Y))
        Return P
    End Function
    Public Sub DrawRoundedRectangle(ByVal g As Drawing.Graphics, ByVal r As Rectangle, ByVal d As Integer, ByVal p As Pen)
        g.DrawArc(p, r.X, r.Y, d, d, 180, 90)
        g.DrawLine(p, CInt(r.X + d / 2), r.Y, CInt(r.X + r.Width - d / 2), r.Y)
        g.DrawArc(p, r.X + r.Width - d, r.Y, d, d, 270, 90)
        g.DrawLine(p, r.X, CInt(r.Y + d / 2), r.X, CInt(r.Y + r.Height - d / 2))
        g.DrawLine(p, CInt(r.X + r.Width), CInt(r.Y + d / 2), CInt(r.X + r.Width), CInt(r.Y + r.Height - d / 2))
        g.DrawLine(p, CInt(r.X + d / 2), CInt(r.Y + r.Height), CInt(r.X + r.Width - d / 2), CInt(r.Y + r.Height))
        g.DrawArc(p, r.X, r.Y + r.Height - d, d, d, 90, 90)
        g.DrawArc(p, r.X + r.Width - d, r.Y + r.Height - d, d, d, 0, 90)
    End Sub
    Public Function FadeBitmap(ByVal bmp As Bitmap, ByVal OpacityPercent As Single) As Bitmap
        Dim bmp2 As New Bitmap(bmp.Width, bmp.Height, Imaging.PixelFormat.Format32bppArgb)
        OpacityPercent = Math.Min(OpacityPercent, 100)

        Using ia As New Imaging.ImageAttributes
            Dim cm As New Imaging.ColorMatrix
            cm.Matrix33 = OpacityPercent / 100.0F
            ia.SetColorMatrix(cm)
            Dim destpoints() As PointF = _
                   {New Point(0, 0), New Point(bmp.Width, 0), New Point(0, bmp.Height)}
            Using g As Graphics = Graphics.FromImage(bmp2)
                g.Clear(Color.Transparent)
                g.DrawImage(bmp, destpoints, _
                   New RectangleF(Point.Empty, bmp.Size), GraphicsUnit.Pixel, ia)
            End Using
        End Using
        Return bmp2
    End Function

    Public Sub DrawRoundedRectangle(ByVal objGraphics As Graphics, _
                                ByVal m_intxAxis As Integer, _
                                ByVal m_intyAxis As Integer, _
                                ByVal m_intWidth As Integer, _
                                ByVal m_intHeight As Integer, _
                                ByVal m_diameter As Integer, ByVal p As Pen)

        If m_intxAxis = 0 Then m_intxAxis = 1
        If m_intyAxis = 0 Then m_intyAxis = 1
        If m_intWidth = 0 Then m_intWidth = 1
        If m_intHeight = 0 Then m_intHeight = 1
        If m_diameter = 0 Then m_diameter = 1

        'Dim g As Graphics
        Dim BaseRect As New RectangleF(m_intxAxis, m_intyAxis, m_intWidth,
                                      m_intHeight)
        Dim ArcRect As New RectangleF(BaseRect.Location,
                                  New SizeF(m_diameter, m_diameter))
        'top left Arc
        objGraphics.DrawArc(p, ArcRect, 180, 90)
        objGraphics.DrawLine(p, m_intxAxis + CInt(m_diameter / 2),
                             m_intyAxis,
                             m_intxAxis + m_intWidth - CInt(m_diameter / 2),
                             m_intyAxis)

        ' top right arc
        ArcRect.X = BaseRect.Right - m_diameter
        objGraphics.DrawArc(p, ArcRect, 270, 90)
        objGraphics.DrawLine(p, m_intxAxis + m_intWidth,
                             m_intyAxis + CInt(m_diameter / 2),
                             m_intxAxis + m_intWidth,
                             m_intyAxis + m_intHeight - CInt(m_diameter / 2))

        ' bottom right arc
        ArcRect.Y = BaseRect.Bottom - m_diameter
        objGraphics.DrawArc(p, ArcRect, 0, 90)
        objGraphics.DrawLine(p, m_intxAxis + CInt(m_diameter / 2),
                             m_intyAxis + m_intHeight,
                             m_intxAxis + m_intWidth - CInt(m_diameter / 2),
                             m_intyAxis + m_intHeight)

        ' bottom left arc
        ArcRect.X = BaseRect.Left
        objGraphics.DrawArc(p, ArcRect, 90, 90)
        objGraphics.DrawLine(p,
                             m_intxAxis, m_intyAxis + CInt(m_diameter / 2),
                             m_intxAxis,
                             m_intyAxis + m_intHeight - CInt(m_diameter / 2))

    End Sub

    Public Function RoundRect(ByVal x!, ByVal y!, ByVal w!, ByVal h!, Optional ByVal r! = 0.3, Optional ByVal TL As Boolean = True, Optional ByVal TR As Boolean = True, Optional ByVal BR As Boolean = True, Optional ByVal BL As Boolean = True) As GraphicsPath
        Dim d! = Math.Min(w, h) * r, xw = x + w, yh = y + h
        RoundRect = New GraphicsPath

        With RoundRect
            If TL Then .AddArc(x, y, d, d, 180, 90) Else .AddLine(x, y, x, y)
            If TR Then .AddArc(xw - d, y, d, d, 270, 90) Else .AddLine(xw, y, xw, y)
            If BR Then .AddArc(xw - d, yh - d, d, d, 0, 90) Else .AddLine(xw, yh, xw, yh)
            If BL Then .AddArc(x, yh - d, d, d, 90, 90) Else .AddLine(x, yh, x, yh)

            .CloseFigure()
        End With
    End Function

    '-- Credit: AeonHack
    Public Function DrawArrow(ByVal x As Integer, ByVal y As Integer, ByVal flip As Boolean) As GraphicsPath
        Dim GP As New GraphicsPath()

        Dim W As Integer = 12
        Dim H As Integer = 6

        If flip Then
            GP.AddLine(x + 1, y, x + W + 1, y)
            GP.AddLine(x + W, y, x + H, y + H - 1)
        Else
            GP.AddLine(x, y + H, x + W, y + H)
            GP.AddLine(x + W, y + H, x + H, y)
        End If

        GP.CloseFigure()
        Return GP
    End Function

#End Region



#Region "Variables"

    Private W, H As Integer
    Private _BorderSize As Integer = 0
    Private _BorderColor As Color = Color.Black
    Private _BodyRadius As Decimal = 6
    Private State As MouseState = MouseState.None
    Private _Shape As Boolean = False
    Private _Opacity As Integer
    Private _BorderOpacity As Integer
    Private _BorderRadius As Integer

    Private _LayerOver As Color
    Private _layerDown As Color
    Private _layerOpacity As Integer = 20

    Private _OverPIC As Image
    Private _DownPIC As Image
    Private _MainPIC As Image
    Private _PicOpacity As Integer

    Private _OverBody_Border As Boolean
    Private _OverBody As Color
    Private _DownBody As Color
    Private _OverBorder As Color
    Private _DownBorder As Color

#End Region

#Region "PROPERTIES"

    <Category("OverBody_Border")> _
    Public Property OverBody_Border() As Boolean
        Get
            Return _OverBody_Border
        End Get
        Set(ByVal value As Boolean)
            _OverBody_Border = value
        End Set
    End Property
    <Category("OverBody_Border")> _
    Public Property OverBody() As Color
        Get
            Return _OverBody
        End Get
        Set(ByVal value As Color)
            _OverBody = value
        End Set
    End Property
    <Category("OverBody_Border")> _
    Public Property DownBody() As Color
        Get
            Return _DownBody
        End Get
        Set(ByVal value As Color)
            _DownBody = value
        End Set
    End Property
    <Category("OverBody_Border")> _
    Public Property OverBorder() As Color
        Get
            Return _OverBorder
        End Get
        Set(ByVal value As Color)
            _OverBorder = value
        End Set
    End Property
    <Category("OverBody_Border")> _
    Public Property DownBorder() As Color
        Get
            Return _DownBorder
        End Get
        Set(ByVal value As Color)
            _DownBorder = value
        End Set
    End Property


    <Category("OverPicStatus")> _
    Public Property PICOpacity() As Integer
        Get
            Return _PicOpacity
        End Get
        Set(ByVal value As Integer)
            _PicOpacity = value
            Invalidate()
        End Set
    End Property
    <Category("OverPicStatus")> _
    Public Property OverPIC() As Image
        Get
            Return _OverPIC
        End Get
        Set(ByVal value As Image)
            _OverPIC = value
        End Set
    End Property
    <Category("OverPicStatus")> _
    Public Property DownPIC() As Image
        Get
            Return _DownPIC
        End Get
        Set(ByVal value As Image)
            _DownPIC = value
        End Set
    End Property
    <Category("OverPicStatus")> _
    Public Property MainPIC() As Image
        Get
            Return _MainPIC
        End Get
        Set(ByVal value As Image)
            _MainPIC = value
            Invalidate()
        End Set
    End Property

    <Category("OverLayerStatus")> _
    Public Property layerOpacity() As Integer
        Get
            Return _layerOpacity
        End Get
        Set(ByVal value As Integer)
            _layerOpacity = value
        End Set
    End Property
    <Category("OverLayerStatus")> _
    Public Property layerDown() As Color
        Get
            Return _layerDown
        End Get
        Set(ByVal value As Color)
            _layerDown = value
        End Set
    End Property
    <Category("OverLayerStatus")> _
    Public Property LayerOver() As Color
        Get
            Return _LayerOver
        End Get
        Set(ByVal value As Color)
            _LayerOver = value
        End Set
    End Property

    <Category("Border")> _
    Public Property BorderSize() As Integer
        Get
            Return _BorderSize
        End Get
        Set(ByVal value As Integer)
            'If value = 0 Then
            '    value = 1
            'End If
            _BorderSize = value
            Invalidate()
        End Set
    End Property

    <Category("Border")> _
    Public Property BorderColor() As Color
        Get
            Return _BorderColor
        End Get
        Set(ByVal value As Color)
            If value = Color.Transparent Then
                value = Color.White
                BorderOpacity = 0
            End If
            _BorderColor = value
            Invalidate()
        End Set
    End Property
    <Category("Border")> _
    Public Property BorderOpacity() As Integer
        Get
            Return _BorderOpacity
        End Get
        Set(ByVal value As Integer)
            _BorderOpacity = value
            Invalidate()
        End Set
    End Property
    <Category("Border")> _
    Public Property BorderRadius() As Integer
        Get
            Return _BorderRadius
        End Get
        Set(ByVal value As Integer)
            _BorderRadius = value
            Invalidate()
        End Set
    End Property
    <Category("Body")> _
    Public Property BodyColor() As Color
        Get
            Return _BodyColor
        End Get
        Set(ByVal value As Color)
            If value = Color.Transparent Then
                value = Color.White
                Opacity = 0
            End If
            _BodyColor = value
            Invalidate()
        End Set
    End Property

    <Category("Body")> _
    Public Property BodyRadius() As Integer
        Get
            Return _BodyRadius
        End Get
        Set(ByVal value As Integer)
            _BodyRadius = value
            Invalidate()
        End Set
    End Property

    <Category("Body")> _
    Public Property CircleShape() As Boolean
        Get
            Return _Shape
        End Get
        Set(ByVal value As Boolean)
            _Shape = value
            Invalidate()
        End Set
    End Property

    <Category("Body")> _
    Public Property Opacity() As Integer
        Get
            Return _Opacity
        End Get
        Set(ByVal value As Integer)
            _Opacity = value
            Invalidate()
        End Set
    End Property
#End Region


#Region "Mouse States"

    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        State = MouseState.Down : Invalidate()
    End Sub
    Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
        MyBase.OnMouseUp(e)
        State = MouseState.Over : Invalidate()
    End Sub
    Protected Overrides Sub OnMouseEnter(ByVal e As EventArgs)
        MyBase.OnMouseEnter(e)
        State = MouseState.Over : Invalidate()
    End Sub
    Protected Overrides Sub OnMouseLeave(ByVal e As EventArgs)
        MyBase.OnMouseLeave(e)
        State = MouseState.None : Invalidate()
    End Sub

#End Region


#Region "Colors"

    Private _BodyColor As Color = _FlatColor

#End Region

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or _
                 ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer Or _
                 ControlStyles.SupportsTransparentBackColor, True)
        DoubleBuffered = True
        Size = New Size(106, 32)
        BackColor = Color.Transparent
        BodyColor = Color.BlanchedAlmond
        Opacity = 100
        layerDown = Color.Black
        LayerOver = Color.White
        layerOpacity = 8
        Font = New Font("Arial Rounded MT Bold", 14.25, FontStyle.Bold)
        ForeColor = Color.FromArgb(93, 93, 93)
        PICOpacity = 100
        BorderSize = 2
        BorderOpacity = 100
        BorderColor = Color.FromArgb(210, 210, 210)
        BodyColor = Color.FromArgb(232, 232, 232)
        BorderRadius = 50
        BodyRadius = 50
        Size = New Size(159, 53)
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        '    Try
        If CircleShape Then
            Width = Height
            If BodyRadius <> 50 Then BodyRadius = 50
        End If
        If BodyColor = Color.Transparent Then Opacity = 0
        If BorderColor = Color.Transparent Then BorderOpacity = 0

        B = New Bitmap(Width, Height) : G = Graphics.FromImage(B)
        W = Width : H = Height

        Dim GP As New GraphicsPath
        Dim BGP As New GraphicsPath
        Dim R As Integer = Math.Round((BorderSize / 2), MidpointRounding.AwayFromZero)
        'Dim Base As New Rectangle(BorderSize, BorderSize, W - BorderSize * 2, H - BorderSize * 2)
        'Dim BBase As New Rectangle(0, 0, W, H)

        Dim RAD As Integer
        If H = W Or H > W Then RAD = W
        If W > H Then RAD = H

        '    Dim q1, q2, q3, q4 As Integer
        '  q1 = BorderSize - R
        '   q2 = BorderSize - R
        '   q3 = W - ((BorderSize - BorderSize / 2) * 2)
        '   q4 = H - ((BorderSize - BorderSize / 2) * 2)
        '   Dim zi As New Rectangle(q1 - BorderSize, q2 - BorderSize, q3 - BorderSize, q4 - BorderSize)
        '  Dim qweqwe As New Rectangle(q1, q2, q3, q4)

        Dim qw1 As Integer = Math.Abs((BorderRadius * RAD / 100) - ((BorderSize / 2) + 3))
        Dim BrBase As New Rectangle(BorderSize - R + 2, BorderSize - R + 2, W - ((BorderSize - R) * 2) - 4, H - ((BorderSize - R) * 2) - 4)
        BGP = DrawingHelper.RoundedRect(BrBase, qw1, Corner.All, Height, BorderRadius)
        Dim BBase1 As New Rectangle(BrBase.X + R - 1, BrBase.Y + R - 1, BrBase.Width - R * 2 + 2, BrBase.Height - R * 2 + 2)

        Dim qw As Integer = Val((Math.Abs((BodyRadius * RAD / 100) - ((BorderSize / 2) + 3))).ToString)
        GP = DrawingHelper.RoundedRect(BBase1, qw, Corner.All, Height, BodyRadius)

        With G
            .SmoothingMode = 2
            .PixelOffsetMode = 2
            .TextRenderingHint = 5
            .Clear(BackColor)

            Select Case State
                Case MouseState.None
                    'border
                    .DrawPath(New Pen(Color.FromArgb(BorderOpacity * 255 / 100, BorderColor), BorderSize), BGP)

                    '-- Base
                    .FillPath(New SolidBrush(Color.FromArgb(Opacity * 255 / 100, _BodyColor)), GP)

                    'draw image
                    Try
                        Dim bit = New Bitmap(MainPIC)
                        bit = FadeBitmap(bit, PICOpacity)
                        .DrawImage(bit, 0, 0, W, H)
                    Catch
                    End Try

                Case MouseState.Over
                    'border
                    If OverBody_Border Then
                        .DrawPath(New Pen(Color.FromArgb(BorderOpacity * 255 / 100, OverBorder), BorderSize), BGP)
                    Else
                        .DrawPath(New Pen(Color.FromArgb(BorderOpacity * 255 / 100, BorderColor), BorderSize), BGP)
                    End If

                    '-- Base
                    If OverBody_Border Then
                        .FillPath(New SolidBrush(Color.FromArgb(Opacity * 255 / 100, _OverBody)), GP)
                    Else
                        .FillPath(New SolidBrush(Color.FromArgb(Opacity * 255 / 100, _BodyColor)), GP)
                    End If


                    'draw image
                    Try
                        Dim bit = New Bitmap(OverPIC)
                        bit = FadeBitmap(bit, PICOpacity)
                        .DrawImage(bit, 0, 0, W, H)
                    Catch
                    End Try

                    'layer
                    .FillPath(New SolidBrush(Color.FromArgb(layerOpacity * 255 / 100, LayerOver)), GP)

                Case MouseState.Down
                    'border
                    If OverBody_Border Then
                        .DrawPath(New Pen(Color.FromArgb(BorderOpacity * 255 / 100, DownBorder), BorderSize), BGP)
                    Else
                        .DrawPath(New Pen(Color.FromArgb(BorderOpacity * 255 / 100, BorderColor), BorderSize), BGP)
                    End If

                    '-- Base
                    If OverBody_Border Then
                        .FillPath(New SolidBrush(Color.FromArgb(Opacity * 255 / 100, DownBody)), GP)
                    Else
                        .FillPath(New SolidBrush(Color.FromArgb(Opacity * 255 / 100, _BodyColor)), GP)
                    End If

                    'draw image
                    Try
                        Dim bit = New Bitmap(DownPIC)
                        bit = FadeBitmap(bit, PICOpacity)
                        .DrawImage(bit, 0, 0, W, H)
                    Catch
                    End Try

                    'layer
                    .FillPath(New SolidBrush(Color.FromArgb(layerOpacity * 255 / 100, layerDown)), GP)

            End Select
            '-- Text
            Dim Font1 As Font = New Font(Font.FontFamily, Font.Size, Font.Style, GraphicsUnit.Pixel)
            .TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAliasGridFit
            .DrawString(Text, Font1, New SolidBrush(ForeColor), BBase1, CenterSF)
        End With

        MyBase.OnPaint(e)
        G.Dispose()
        e.Graphics.InterpolationMode = 7
        e.Graphics.DrawImageUnscaled(B, 0, 0)
        B.Dispose()
        '  Catch
        '   End Try

    End Sub

    Protected Overrides Sub OnTextChanged(e As EventArgs)
        MyBase.OnTextChanged(e)
        Invalidate()
    End Sub

End Class

Class DrawingHelper

    Public Shared Function RoundedRect(ByVal rect As RectangleF, Optional ByVal cornerradius As Integer = 5, Optional ByVal roundedcorners As Corner = Corner.All, Optional ByVal H1 As Integer = 7, Optional ByVal borderR As Integer = 8) As Drawing2D.GraphicsPath
        Dim p As New Drawing2D.GraphicsPath
        Dim x As Single = rect.X, y As Single = rect.Y, w As Single = rect.Width, h As Single = rect.Height, r As Integer = cornerradius

        p.StartFigure()
        'top left arc
        If CBool(Corner.TopLeft) And H1 > 6 And borderR > 7 Then
            Try
                p.AddArc(New RectangleF(x, y, 2 * r, 2 * r), 180, 90)
            Catch
            End Try
        Else
            p.AddLine(New PointF(x, y), New PointF(x, y))
            p.AddLine(New PointF(x, y), New PointF(x, y))
        End If

        'top line
        ' p.AddLine(New PointF(x + r, y), New PointF(x + w - r, y))

        'top right arc
        If CBool(Corner.TopRight) And H1 > 6 And borderR > 7 Then
            Try
                p.AddArc(New RectangleF(x + w - 2 * r, y, 2 * r, 2 * r), 270, 90)
            Catch
            End Try
        Else
            p.AddLine(New PointF(x + w, y), New PointF(x + w, y))
            p.AddLine(New PointF(x + w, y), New PointF(x + w, y))
        End If

        'right line
        '  p.AddLine(New PointF(x + w, y + r), New PointF(x + w, y + h - r))

        'bottom right arc
        If CBool(Corner.BottomRight) And H1 > 6 And borderR > 7 Then
            Try
                p.AddArc(New RectangleF(x + w - 2 * r, y + h - 2 * r, 2 * r, 2 * r), 0, 90)
            Catch
            End Try
        Else
            p.AddLine(New PointF(x + w, y + h), New PointF(x + w, y + h))
            p.AddLine(New PointF(x + w, y + h), New PointF(x + w, y + h))
        End If

        'bottom line
        '   p.AddLine(New PointF(x + w - r, y + h), New PointF(x + r, y + h))

        'bottom left arc
        If CBool(Corner.BottomLeft) And H1 > 6 And borderR > 7 Then
            Try
                p.AddArc(New RectangleF(x, y + h - 2 * r, 2 * r, 2 * r), 90, 90)
            Catch
            End Try
        Else
            p.AddLine(New PointF(x, y + h), New PointF(x, y + h))
            p.AddLine(New PointF(x, y + h), New PointF(x, y + h))
        End If

        'left line
        ' p.AddLine(New PointF(x, y + h - r), New PointF(x, y + r))

        'close figure...
        p.CloseFigure()

        Return p
    End Function

    Public Shared Function RoundedRect(ByVal location As Point, ByVal size As Size, Optional ByVal cornerradius As Integer = 5, Optional ByVal roundedcorners As Corner = Corner.All) As Drawing2D.GraphicsPath
        Return RoundedRect(New RectangleF(location.X, location.Y, size.Width, size.Height), cornerradius, roundedcorners)
    End Function

    Public Shared Function RoundedRect(ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer, Optional ByVal cornerradius As Integer = 5, Optional ByVal roundedcorners As Corner = Corner.All) As Drawing2D.GraphicsPath
        Return RoundedRect(New RectangleF(x, y, width, height), cornerradius, roundedcorners)
    End Function

    Public Shared Function RoundedRect(ByVal rect As Rectangle, Optional ByVal cornerradius As Integer = 5, Optional ByVal roundedcorners As Corner = Corner.All, Optional ByVal H1 As Integer = 7, Optional ByVal borderR As Integer = 8) As Drawing2D.GraphicsPath
        Return RoundedRect(New RectangleF(rect.Left, rect.Top, rect.Width, rect.Height), cornerradius, roundedcorners, H1, borderR)
    End Function

    Public Shared Function RoundedRect(ByVal location As PointF, ByVal size As SizeF, Optional ByVal cornerradius As Integer = 5, Optional ByVal roundedcorners As Corner = Corner.All) As Drawing2D.GraphicsPath
        Return RoundedRect(New RectangleF(location.X, location.Y, size.Width, size.Height), cornerradius, roundedcorners)
    End Function
End Class

<Flags()> _
Public Enum Corner
    None = 0
    TopLeft = 1
    TopRight = 2
    BottomLeft = 4
    BottomRight = 8
    All = TopLeft Or TopRight Or BottomLeft Or BottomRight
    TLBR = TopLeft Or BottomRight
    TRBL = TopRight Or BottomLeft
    TRBR = TopRight Or BottomRight
    TLBL = TopLeft Or BottomLeft
    TRTL = TopRight Or TopLeft
    BRBL = BottomRight Or BottomLeft
    AllxBottomRight = TopLeft Or TopRight Or BottomLeft
End Enum