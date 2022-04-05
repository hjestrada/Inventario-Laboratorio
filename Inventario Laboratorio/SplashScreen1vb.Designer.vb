<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SplashScreen1vb
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SplashScreen1vb))
        Me.Version = New System.Windows.Forms.Label()
        Me.Copyright = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Version
        '
        Me.Version.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Version.BackColor = System.Drawing.Color.Transparent
        Me.Version.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Version.Location = New System.Drawing.Point(218, 270)
        Me.Version.Name = "Version"
        Me.Version.Size = New System.Drawing.Size(241, 20)
        Me.Version.TabIndex = 6
        Me.Version.Text = "Versión {0}.{1:00}"
        Me.Version.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Copyright
        '
        Me.Copyright.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Copyright.BackColor = System.Drawing.Color.Transparent
        Me.Copyright.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Copyright.Location = New System.Drawing.Point(218, 290)
        Me.Copyright.Name = "Copyright"
        Me.Copyright.Size = New System.Drawing.Size(241, 40)
        Me.Copyright.TabIndex = 7
        Me.Copyright.Text = "Copyright"
        Me.Copyright.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(70, 43)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(536, 212)
        Me.PictureBox1.TabIndex = 8
        Me.PictureBox1.TabStop = False
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ProgressBar1.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ProgressBar1.Location = New System.Drawing.Point(0, 347)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(695, 10)
        Me.ProgressBar1.Step = 1
        Me.ProgressBar1.TabIndex = 9
        Me.ProgressBar1.Value = 100
        '
        'SplashScreen1vb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ClientSize = New System.Drawing.Size(695, 357)
        Me.ControlBox = False
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Version)
        Me.Controls.Add(Me.Copyright)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SplashScreen1vb"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Version As Label
    Friend WithEvents Copyright As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents ProgressBar1 As ProgressBar
End Class
