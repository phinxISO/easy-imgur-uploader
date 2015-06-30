<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.EButton1 = New easy_imgur_uploader.eButton()
        Me.SuspendLayout()
        '
        'EButton1
        '
        Me.EButton1.BackColor = System.Drawing.Color.Transparent
        Me.EButton1.BodyColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.EButton1.BodyRadius = 50
        Me.EButton1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.EButton1.BorderOpacity = 25
        Me.EButton1.BorderRadius = 1
        Me.EButton1.BorderSize = 12
        Me.EButton1.CircleShape = False
        Me.EButton1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.EButton1.DownBody = System.Drawing.Color.Empty
        Me.EButton1.DownBorder = System.Drawing.Color.Empty
        Me.EButton1.DownPIC = Nothing
        Me.EButton1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Bold)
        Me.EButton1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(93, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(93, Byte), Integer))
        Me.EButton1.layerDown = System.Drawing.Color.Black
        Me.EButton1.layerOpacity = 8
        Me.EButton1.LayerOver = System.Drawing.Color.White
        Me.EButton1.Location = New System.Drawing.Point(0, 0)
        Me.EButton1.MainPIC = Nothing
        Me.EButton1.Name = "EButton1"
        Me.EButton1.Opacity = 100
        Me.EButton1.OverBody = System.Drawing.Color.Empty
        Me.EButton1.OverBody_Border = False
        Me.EButton1.OverBorder = System.Drawing.Color.Empty
        Me.EButton1.OverPIC = Nothing
        Me.EButton1.PICOpacity = 100
        Me.EButton1.Size = New System.Drawing.Size(349, 287)
        Me.EButton1.TabIndex = 0
        Me.EButton1.Text = "EButton1"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.BlanchedAlmond
        Me.ClientSize = New System.Drawing.Size(349, 287)
        Me.Controls.Add(Me.EButton1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents EButton1 As easy_imgur_uploader.eButton

End Class
