Imports System.Drawing.Drawing2D
Imports System.Net
Imports System.Text
Imports System.IO
Imports System.Text.RegularExpressions
Imports System.ComponentModel

Public Class Form2
    Private mPrevPos As New Point
    Private oldXY As Point = Point.Empty
    Dim delta
    Private Sub Form2_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        End
    End Sub
    Private Sub Form2_LocationChanged(sender As Object, e As EventArgs) Handles Me.LocationChanged
        Form1.Location = New Point(Me.Location.X - 6, Me.Location.Y - 6)
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Location = New Point(-1000, -1000)
        Form1.Show()
        Form1.Location = New Point(Me.Location.X - 6, Me.Location.Y - 6)
        Me.Owner = Form1

        Dim sto1 = New Stopwatch
        sto1.Start()
        Do While sto1.ElapsedMilliseconds <= 300
            Application.DoEvents()
        Loop

        Me.Location = New Point(0, 0)
        Control.CheckForIllegalCrossThreadCalls = False
        ' عشان تغير ترتيب الفورمات فى الظهور اعكس مليكة الفورم 
        ' يعنى خلى Me.Owner = form2 
        ' بس طبعاً يتحط الكود فى الفورم الاولانى

    End Sub
    Private Sub Panel1_MouseEnter(sender As Object, e As EventArgs) Handles Panel1.MouseEnter
        Panel1.Focus()
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

        '  MsgBox(PictureBox2.Height)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ak As Integer = 0
        For Each eq As Control In Panel1.Controls
            If eq.Size.Height + eq.Location.Y > Panel1.Height Then
                If eq.Size.Height + eq.Location.Y - Panel1.Height > ak Then
                    ak = eq.Size.Height + eq.Location.Y - Panel1.Height
                End If
            End If
        Next

        PictureBox2.Height = Panel1.VerticalScroll.LargeChange - ak - 20
        '   PictureBox2.Height = Panel1.VerticalScroll.LargeChange - 8
        'MsgBox(Panel1.VerticalScroll.LargeChange)
        'MsgBox(Panel1.VerticalScroll.SmallChange)
        'MsgBox(Panel1.VerticalScroll.Value)
    End Sub
    Private Sub PictureBox2_MouseMove1(sender As Object, e As MouseEventArgs) Handles PictureBox2.MouseMove
        delta = New Size(0, e.Y - mPrevPos.Y)
        If (e.Button = MouseButtons.Left) And truee(PictureBox2.Location + delta) Then
            Button1.Text = PictureBox2.Location.ToString
            Panel1.VerticalScroll.Value = PictureBox2.Location.Y
            PictureBox2.Location += delta
            mPrevPos = e.Location - delta
        Else
            mPrevPos = e.Location
        End If
    End Sub
    Function truee(ByVal x As Point) As Boolean
        ' If x.Y >= 0 Then
        If x.Y <= Panel2.Height - PictureBox2.Height And 0 <= x.Y Then
            Return True
        Else
            Return False
        End If
    End Function
    'If e.Y < oldXY.Y Then
    '            Button1.Text = "down"
    '            If e.Location.Y + PictureBox2.Location.Y + PictureBox2.Height <= Panel2.Height Then
    '                PictureBox2.Location += delta
    '                mPrevPos = e.Location - delta
    '            Else
    '            End If
    '        ElseIf e.Y > oldXY.Y Then
    '            Button1.Text = "up"
    '            PictureBox2.Location += delta
    '            mPrevPos = e.Location - delta
    '        End If

    '        oldXY.X = e.X
    '        oldXY.Y = e.Y

    Private Sub Panel1_MouseWheel(sender As Object, e As MouseEventArgs) Handles Panel1.MouseWheel
        PictureBox2.Location = New Point(0, Panel1.VerticalScroll.Value)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        MsgBox(Panel1.VerticalScroll.SmallChange)

    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click

    End Sub
End Class
Public Class vbpa : Inherits Panel
    Friend WithEvents mnm As PictureBox = New PictureBox
    Friend WithEvents RichTextBox1 As RichTextBox = New RichTextBox
    Friend WithEvents Label1 As Label = New Label
    Friend WithEvents PictureBox1 As PictureBox = New PictureBox
    Friend WithEvents BasicProgressBar1 As BasicProgressBar = New BasicProgressBar
    Friend WithEvents BackgroundWorker1 As BackgroundWorker = New BackgroundWorker
    Dim ClientId As String = "a26909d25c25896"
    Dim link As String


    Sub New(ByVal link1 As String)
        link = link1
        Control.CheckForIllegalCrossThreadCalls = False
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or _
                         ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer Or _
                         ControlStyles.SupportsTransparentBackColor, True)

        DoubleBuffered = True
        Size = New Size(306, 64)
        BackColor = Color.White
        '

        'Label1
        '
        Me.Label1.BackColor = Color.White
        Me.Label1.Cursor = Cursors.Hand
        Me.Label1.Font = New Font("Tahoma", 8.25!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = Color.Crimson
        Me.Label1.Location = New Point(71, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New Size(230, 15)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "sdf"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = Color.White
        Me.PictureBox1.Cursor = Cursors.Hand
        Me.PictureBox1.Location = New Point(64, 39)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New Size(237, 18)
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'RichTextBox1
        '
        Me.RichTextBox1.BorderStyle = BorderStyle.None
        Me.RichTextBox1.Cursor = Cursors.Default
        Me.RichTextBox1.Font = New Font("Tahoma", 8.25!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))
        Me.RichTextBox1.Location = New Point(62, 3)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New Size(239, 29)
        Me.RichTextBox1.TabIndex = 1
        Me.RichTextBox1.Text = "sdfsadfsdf"
        '
        'mnm
        '
        Me.mnm.BackColor = Color.Crimson
        Me.mnm.Location = New Point(3, 3)
        Me.mnm.Name = "mnm"
        Me.mnm.Size = New Size(56, 56)
        Me.mnm.TabIndex = 0
        Me.mnm.TabStop = False
        '
        'BasicProgressBar1
        '
        Me.BasicProgressBar1.BackColor = Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(73, Byte), Integer))
        Me.BasicProgressBar1.BassColor = Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.BasicProgressBar1.Location = New Point(62, 37)
        Me.BasicProgressBar1.Maximum = 100
        Me.BasicProgressBar1.Name = "BasicProgressBar1"
        Me.BasicProgressBar1.ProgressColor = Color.Empty
        Me.BasicProgressBar1.Size = New Size(241, 22)
        Me.BasicProgressBar1.TabIndex = 2
        Me.BasicProgressBar1.Text = "BasicProgressBar1"
        Me.BasicProgressBar1.Value = 0

        Controls.Add(Me.Label1)
        Controls.Add(Me.PictureBox1)
        Controls.Add(Me.BasicProgressBar1)
        Controls.Add(Me.RichTextBox1)
        Controls.Add(Me.mnm)
    End Sub
    Private Sub RichTextBox1_x() Handles RichTextBox1.Enter, RichTextBox1.GotFocus, RichTextBox1.Invalidated, RichTextBox1.MouseEnter
        mnm.Focus()
    End Sub
    Private Sub Label1_Click() Handles Label1.Click, PictureBox1.Click

    End Sub

    Public Function UploadImage(ByVal image As String)
        Dim w As New WebClient()
        w.Headers.Add("Authorization", "Client-ID " & ClientId)
        Dim Keys As New System.Collections.Specialized.NameValueCollection
        Try
            Keys.Add("image", Convert.ToBase64String(File.ReadAllBytes(image)))
            Dim responseArray As Byte() = w.UploadValues("https://api.imgur.com/3/image", Keys)
            Dim result = Encoding.ASCII.GetString(responseArray)
            Dim reg As New System.Text.RegularExpressions.Regex("link"":""(.*?)""")
            Dim match As Match = reg.Match(result)
            Dim url As String = match.ToString.Replace("link"":""", "").Replace("""", "").Replace("\/", "/")
            Return url
        Catch s As Exception
            MessageBox.Show("Something went wrong. " & s.Message)
            Return "field! "
        End Try
    End Function

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        UploadImage(link)
    End Sub
    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        BackgroundWorker1.Dispose()
    End Sub

    Sub run()
        BackgroundWorker1.RunWorkerAsync()
    End Sub

End Class

Class BasicProgressBar : Inherits Control

#Region " Variables"

    Private W, H As Integer
    Private _Value As Integer = 0
    Private _Maximum As Integer = 100

#End Region

#Region " Properties"

#Region " Control"

    Public Property Maximum() As Integer
        Get
            Return _Maximum
        End Get
        Set(ByVal V As Integer)
            Select Case V
                Case Is < _Value
                    _Value = V
            End Select
            _Maximum = V
            Invalidate()
        End Set
    End Property

    Public Property Value() As Integer
        Get
            Select Case _Value
                Case 0
                    Return 0
                    Invalidate()
                Case Else
                    Return _Value
                    Invalidate()
            End Select
        End Get
        Set(ByVal V As Integer)
            Select Case V
                Case Is > _Maximum
                    V = _Maximum
                    Invalidate()
            End Select
            _Value = V
            Invalidate()
        End Set
    End Property

#End Region

#Region " Colors"

    Public Property ProgressColor() As Color
        Get
            Return _ProgressColor
        End Get
        Set(ByVal value As Color)
            _ProgressColor = value
            Invalidate()
        End Set
    End Property


#End Region

    Public Property BassColor() As Color
        Get
            Return _BaseColor
        End Get
        Set(ByVal value As Color)
            _BaseColor = value
            Invalidate()
        End Set
    End Property

#End Region

    Public Sub Increment(ByVal Amount As Integer)
        Value += Amount
    End Sub



#Region " Colors"

    Private _BaseColor As Color = Color.FromArgb(45, 47, 49)
    Private _ProgressColor As Color = _FlatColor

#End Region

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or _
                 ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer, True)
        DoubleBuffered = True
        BackColor = Color.FromArgb(60, 70, 73)
        Height = 42
        Value = 10
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        B = New Bitmap(Width, Height) : G = Graphics.FromImage(B)
        W = Width : H = Height

        Dim Base As New Rectangle(0, 0, W, H)
        Dim GP, GP2, GP3 As New GraphicsPath

        With G
            .SmoothingMode = 2
            .PixelOffsetMode = 2
            .TextRenderingHint = 5
            .Clear(BackColor)

            '-- Progress Value
            Dim iValue As Integer = CInt(_Value / _Maximum * Width)

            Select Case Value
                Case 0
                    '-- Base
                    .FillRectangle(New SolidBrush(_BaseColor), Base)
                    '--Progress
                    .FillRectangle(New SolidBrush(_ProgressColor), New Rectangle(0, 0, iValue - 1, H))
                Case 100
                    '-- Base
                    .FillRectangle(New SolidBrush(_BaseColor), Base)
                    '--Progress
                    .FillRectangle(New SolidBrush(_ProgressColor), New Rectangle(0, 0, iValue - 1, H))
                Case Else
                    '-- Base
                    .FillRectangle(New SolidBrush(_BaseColor), Base)

                    '--Progress
                    GP.AddRectangle(New Rectangle(0, 0, iValue - 1, H))
                    .FillPath(New SolidBrush(_ProgressColor), GP)

                    '-- Hatch Brush
                    Dim HB As New HatchBrush(HatchStyle.Plaid, _ProgressColor, _ProgressColor)
                    .FillRectangle(HB, New Rectangle(0, 0, iValue - 1, H))
            End Select
        End With

        MyBase.OnPaint(e)
        G.Dispose()
        e.Graphics.InterpolationMode = 7
        e.Graphics.DrawImageUnscaled(B, 0, 0)
        B.Dispose()
    End Sub

#Region " Variables"
    Friend G As Graphics, B As Bitmap
    Friend _FlatColor As Color = Color.FromArgb(35, 168, 109)
    Friend NearSF As New StringFormat() With {.Alignment = StringAlignment.Near, .LineAlignment = StringAlignment.Near}
    Friend CenterSF As New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center}
#End Region
End Class