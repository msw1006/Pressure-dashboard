<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Ybp
    Inherits System.Windows.Forms.UserControl
    'UserControl 重写 Dispose,以清理组件列表。
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
        Me.components = New System.ComponentModel.Container
        Me.lblJdqbh = New System.Windows.Forms.Label
        Me.chkIsuse = New System.Windows.Forms.CheckBox
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.picClick = New System.Windows.Forms.PictureBox
        Me.picCCD = New System.Windows.Forms.PictureBox
        Me.picMove = New System.Windows.Forms.PictureBox
        Me.lblWait = New System.Windows.Forms.Label
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.picClick, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picCCD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picMove, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblJdqbh
        '
        Me.lblJdqbh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblJdqbh.BackColor = System.Drawing.SystemColors.Info
        Me.lblJdqbh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblJdqbh.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lblJdqbh.Location = New System.Drawing.Point(435, 0)
        Me.lblJdqbh.Name = "lblJdqbh"
        Me.lblJdqbh.Size = New System.Drawing.Size(65, 21)
        Me.lblJdqbh.TabIndex = 3
        Me.lblJdqbh.Text = "1 号"
        Me.lblJdqbh.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblJdqbh.Visible = False
        '
        'chkIsuse
        '
        Me.chkIsuse.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkIsuse.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.chkIsuse.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.chkIsuse.Location = New System.Drawing.Point(285, 175)
        Me.chkIsuse.Name = "chkIsuse"
        Me.chkIsuse.Size = New System.Drawing.Size(62, 18)
        Me.chkIsuse.TabIndex = 4
        Me.chkIsuse.Text = "停用"
        Me.chkIsuse.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.chkIsuse.UseVisualStyleBackColor = False
        Me.chkIsuse.Visible = False
        '
        'Timer1
        '
        Me.Timer1.Interval = 800
        '
        'picClick
        '
        Me.picClick.Image = Global.YBP.My.Resources.Resources.click
        Me.picClick.InitialImage = Nothing
        Me.picClick.Location = New System.Drawing.Point(9, 8)
        Me.picClick.Name = "picClick"
        Me.picClick.Size = New System.Drawing.Size(39, 35)
        Me.picClick.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picClick.TabIndex = 6
        Me.picClick.TabStop = False
        Me.picClick.Visible = False
        '
        'picCCD
        '
        Me.picCCD.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picCCD.Image = Global.YBP.My.Resources.Resources.未标题_1
        Me.picCCD.InitialImage = Nothing
        Me.picCCD.Location = New System.Drawing.Point(458, 462)
        Me.picCCD.Name = "picCCD"
        Me.picCCD.Size = New System.Drawing.Size(39, 35)
        Me.picCCD.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picCCD.TabIndex = 5
        Me.picCCD.TabStop = False
        Me.picCCD.Visible = False
        '
        'picMove
        '
        Me.picMove.BackColor = System.Drawing.Color.Black
        Me.picMove.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.picMove.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picMove.Dock = System.Windows.Forms.DockStyle.Fill
        Me.picMove.Location = New System.Drawing.Point(0, 0)
        Me.picMove.Name = "picMove"
        Me.picMove.Size = New System.Drawing.Size(500, 500)
        Me.picMove.TabIndex = 0
        Me.picMove.TabStop = False
        '
        'lblWait
        '
        Me.lblWait.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblWait.AutoSize = True
        Me.lblWait.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lblWait.ForeColor = System.Drawing.Color.Red
        Me.lblWait.Location = New System.Drawing.Point(5, 476)
        Me.lblWait.Name = "lblWait"
        Me.lblWait.Size = New System.Drawing.Size(28, 21)
        Me.lblWait.TabIndex = 8
        Me.lblWait.Text = "10"
        Me.lblWait.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblWait.Visible = False
        '
        'Timer2
        '
        '
        'Ybp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.Transparent
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Controls.Add(Me.lblWait)
        Me.Controls.Add(Me.picClick)
        Me.Controls.Add(Me.picCCD)
        Me.Controls.Add(Me.chkIsuse)
        Me.Controls.Add(Me.lblJdqbh)
        Me.Controls.Add(Me.picMove)
        Me.DoubleBuffered = True
        Me.Name = "Ybp"
        Me.Size = New System.Drawing.Size(500, 500)
        CType(Me.picClick, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picCCD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picMove, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents picMove As System.Windows.Forms.PictureBox
    Friend WithEvents lblJdqbh As System.Windows.Forms.Label
    Friend WithEvents chkIsuse As System.Windows.Forms.CheckBox
    Friend WithEvents picCCD As System.Windows.Forms.PictureBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents picClick As System.Windows.Forms.PictureBox
    Friend WithEvents lblWait As System.Windows.Forms.Label
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
End Class
