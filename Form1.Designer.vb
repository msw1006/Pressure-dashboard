<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
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

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Ybp1 = New Ybp.Ybp
        Me.SuspendLayout()
        '
        'Ybp1
        '
        Me.Ybp1.AutoSize = True
        Me.Ybp1.BackColor = System.Drawing.Color.Transparent
        Me.Ybp1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Ybp1.bIsclicking = False
        Me.Ybp1.bLblColor = False
        Me.Ybp1.bSnvisbale = True
        Me.Ybp1.bUsed = True
        Me.Ybp1.bWaitCCD = False
        Me.Ybp1.bYBPsvVisbale = True
        Me.Ybp1.bYbpWait = False
        Me.Ybp1.ijingdu = 5
        Me.Ybp1.iSn = Nothing
        Me.Ybp1.Location = New System.Drawing.Point(45, 19)
        Me.Ybp1.Name = "Ybp1"
        Me.Ybp1.PV = 0.0!
        Me.Ybp1.Size = New System.Drawing.Size(443, 443)
        Me.Ybp1.SV = 0.0!
        Me.Ybp1.SvEd = 0.99!
        Me.Ybp1.TabIndex = 0
        Me.Ybp1.ylset = 0.0!
        Me.Ybp1.ylseth = 0.0!
        Me.Ybp1.ylseth1 = 0.0!
        '
        'Form1
        '
        Me.ClientSize = New System.Drawing.Size(656, 611)
        Me.Controls.Add(Me.Ybp1)
        Me.Name = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Ybp1 As Ybp.Ybp
    'Friend WithEvents Ybp1 As Ybp.Ybp
    'Friend WithEvents Ybp2 As Ybp.Ybp
End Class
