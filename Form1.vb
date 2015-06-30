Imports System.Runtime.InteropServices
Imports System.Drawing.Drawing2D
Public Class Form1

    'Private Sub Form1_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
    '    ' Form2.TopMost = True
    '    Form2.Focus()
    'End Sub
    'Private Sub Form1_LostFocus(sender As Object, e As EventArgs) Handles Me.LostFocus
    '    Form2.TopMost = False
    'End Sub
    
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Size = New Size(Form2.Size.Width + 12, Form2.Size.Height + 12)
        'Form2.ShowInTaskbar = True
        Me.ShowInTaskbar = False
    End Sub

    Private Sub Form1_Paint() Handles Me.Paint
        Dim g As Graphics = Me.CreateGraphics
        Dim tx As New GraphicsPath

        'Set black to get nice transparent
        Me.BackColor = Color.Black
        'Set this form transparent
        DwmExtendFrameIntoClientArea(Me.Handle, New MARGINS(-1, -1, -1, -1))
        ' Set Smoothing Mode to get smooth text
        g.SmoothingMode = SmoothingMode.AntiAlias
        'Fill form with text and color (brush)
        g.FillPath(New SolidBrush(Color.Black), tx)

    End Sub

    Private Sub Form1_ResizeEnd() Handles Me.ResizeEnd
        ' When form resize, re-draw the form and show it smooth again
        Me.Refresh()
    End Sub
    ' DwmApi To Call Glasses Window
    <StructLayout(LayoutKind.Sequential)> _
    Public Structure MARGINS
        Public LeftWidth As Integer
        Public RightWidth As Integer
        Public TopHeight As Integer
        Public Buttomheight As Integer
        Public Sub New(ByVal left As Integer, ByVal right As Integer, ByVal top As Integer, ByVal bottom As Integer)
            LeftWidth = left
            RightWidth = right
            TopHeight = top
            Buttomheight = bottom
        End Sub
    End Structure
    <DllImport("dwmapi.dll")> _
    Shared Sub DwmExtendFrameIntoClientArea(ByVal hwnd As IntPtr, ByRef mrg As MARGINS)
    End Sub

End Class