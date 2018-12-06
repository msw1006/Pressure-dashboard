Imports System.Drawing.Drawing2D
'Imports System.Drawing.Graphics
Imports System.Math
Imports System.ComponentModel

Public Class Ybp

    Private m_bbIsclicking As Boolean = False
    Private m_bbWaitCCD As Boolean = False
    Private m_sinSV As Single = 0.0

    Dim sYLset() As Single = {0, 0, 0} '压力设定值
    Dim ZzX(3) As Single
    Dim ZzY(3) As Single
    Dim AngleZZ As Single
    Dim Angle As Single
    Dim cR As Single
    Dim Cr1 As Single
    Dim rect_pts1(3) As PointF
    Dim g As Graphics = Me.CreateGraphics

    Private Sub ybp_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize

        If Me.Width > Me.Height Then Me.Height = Me.Width
        If Me.Height > Me.Width Then Me.Width = Me.Height
        cR = Me.Height / 2
    End Sub

#Region "绘制底色函数"

    Private Sub DrawYBP(ByVal g As Graphics)

        Try

            Dim PXl As Single = Me.Width
            Dim PYl As Single = Me.Height
            Dim Fh As Integer
            Dim rect_pts() As PointF = {New Point(0, 0), New Point(PXl, 0), New Point(PXl, PYl), New Point(0, PYl)} '表盘正方形
            g.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
            '---------------------------------------------------------------------------------绘制外圆
            Using circle_pen As New Pen(Color.White, 1.5) '外圈
                g.DrawEllipse(circle_pen, 5, 5, PXl - 10, PXl - 10)
                circle_pen.Dispose()
            End Using

            Dim rect As New Rectangle(8, 8, PXl - 16, PXl - 16) '表壳
            Using gradientBrush As New LinearGradientBrush(rect, Color.Gray, Color.AliceBlue, LinearGradientMode.BackwardDiagonal)
                g.FillEllipse(gradientBrush, rect)
                gradientBrush.Dispose()
            End Using

            Dim CR11 As Single = cR * 0.1 + 10 '表壳内线
            Dim CRW As Single = PXl - CR11 * 2
            Using circle_pen As New Pen(Color.Black, 1.5)
                circle_pen.Alignment = PenAlignment.Outset
                g.DrawEllipse(circle_pen, CR11, CR11, CRW, CRW)
                circle_pen.Dispose()
            End Using
            '---------------------------------------------------------------------------------绘制圆盘渐进色    
            Using ellipse_path As New GraphicsPath
                CR11 += 2
                CRW = PXl - CR11 * 2
                ellipse_path.AddEllipse(CR11, CR11, CRW, CRW)
                Using path_brush As New PathGradientBrush(ellipse_path)
                    'path_brush.CenterColor = Color.WhiteSmoke
                    path_brush.CenterColor = Color.White

                    If bUsed = True Then
                        path_brush.SurroundColors = New Color() {Color.Black}
                    Else
                        path_brush.SurroundColors = New Color() {Color.Gray}
                    End If

                    g.FillEllipse(path_brush, CR11, CR11, CRW, CRW)
                    path_brush.Dispose()
                End Using
                ellipse_path.Dispose()
            End Using
            '---------------------------------------------------------------------------------绘制文字
            Fh = PXl * 0.055                   '字体动态大小
            Using YbF As New Font("times new roman", Fh, FontStyle.Bold) 'Times New Roman

                Dim rcttxt As New Rectangle(0, PXl * 0.32, PXl, PXl)
                Dim txtfmt As New StringFormat
                txtfmt.Alignment = StringAlignment.Center
                g.DrawString("SF" + ChrW(8326), YbF, Brushes.Linen, rcttxt, txtfmt) 'ChrW(8326)=6  (8320-8329 0-9)
                rcttxt.Offset(0, PXl * 0.23)
                g.DrawString("Gas", YbF, Brushes.Linen, rcttxt, txtfmt)
                rcttxt.Offset(0, PXl * 0.26)
                g.DrawString("MPa", YbF, Brushes.Linen, rcttxt, txtfmt)
                YbF.Dispose()
            End Using

            '---------------------------------------------------------------------------------数据方框SV
            If bYBPsvVisbale = True Then

                Dim Rect_v2 As New Rectangle(PXl * 0.375, PXl * 0.63, PXl * 0.25, PXl * 0.08)
                g.FillRectangle(Brushes.Chocolate, Rect_v2) '填充
                'g.FillRectangle(Brushes.Red, Rect_v) '填充
                g.DrawRectangle(Pens.White, Rect_v2) '外框
            End If

            '---------------------------------------------------------------------------------数据方框PV
            Dim Rect_v As New Rectangle(PXl * 0.375, PXl * 0.72, PXl * 0.25, PXl * 0.08)

            If bUsed = True Then
                g.FillRectangle(Brushes.Chocolate, Rect_v) '填充
            End If

            g.DrawRectangle(Pens.Brown, Rect_v) '外框

            '---------------------------------------------------------------------------------压力区域
            Dim RctX As Single = cR * 0.29                                         'cR - (cR * 0.71)
            Dim RctW As Single = cR * 1.42
            Dim Rct_yh As New RectangleF(RctX, RctX, RctW, RctW)
            Dim sArcW As Single = cR * 0.1                                          '圆弧线宽
            Dim iKdcolor As Color

            If bUsed = True Then
                iKdcolor = Color.Red
            Else
                iKdcolor = Color.Gray
            End If

            Using circle_penARc As New Pen(iKdcolor, sArcW)
                g.DrawArc(circle_penARc, Rct_yh, 138, 264)
                circle_penARc.Dispose()
            End Using
            Using circle_penARc As New Pen(Color.Yellow, sArcW)

                Dim SAngle As Single = 180 + (sYLset(0) / 0.75) * 180
                Dim SweepAngle As Single = ((sYLset(1) - sYLset(0)) / 0.75) * 180
                g.DrawArc(circle_penARc, Rct_yh, SAngle, SweepAngle)
                circle_penARc.Dispose()
            End Using
            Using circle_penARc As New Pen(Color.Green, sArcW)

                Dim SAngle As Single = 180 + (sYLset(1) / 0.75) * 180
                Dim SweepAngle As Single = ((sYLset(2) - sYLset(1)) / 0.75) * 180
                g.DrawArc(circle_penARc, Rct_yh, SAngle, SweepAngle)
                circle_penARc.Dispose()
            End Using

            '--------------------------------------------------------------------------------- 表盘刻度 文字
            Dim Angle As Single
            Dim X(1), Y(1) As Single
            Using circle_penSZ As New Pen(Color.DeepSkyBlue, 5)

                Dim i As Single
                Dim YbS() As String = {"-0.1", "0.0", "0.1", "0.2", "0.3", "0.4", "0.5", "0.6", "0.7", "0.8", "0.9", "1.0"}
                Dim isz As Long = 0
                Fh = cR * 0.075

                For i = -42 To 222 Step 24                                         '大刻度及数字
                    '     For i = -20 To 200 Step 20                                         '大刻度及数字
                    Angle = (i * PI) / 180
                    X(0) = cR - (cR * 0.66) * Cos(Angle)
                    X(1) = cR - (cR * 0.6) * Cos(Angle)
                    Y(0) = cR - (cR * 0.66) * Sin(Angle)
                    Y(1) = cR - (cR * 0.6) * Sin(Angle)
                    g.DrawLine(circle_penSZ, X(0), Y(0), X(1), Y(1))               '粗刻度
                    Using circle_penSZ1 As New Pen(Color.Black, 2)
                        X(0) = cR - (cR * 0.755) * Cos(Angle)
                        X(1) = cR - (cR * 0.66) * Cos(Angle)
                        Y(0) = cR - (cR * 0.755) * Sin(Angle)
                        Y(1) = cR - (cR * 0.66) * Sin(Angle)
                        g.DrawLine(circle_penSZ1, X(0), Y(0), X(1), Y(1))
                        circle_penSZ1.Dispose()
                    End Using
                    Using YbF As New Font("times new roman", Fh, FontStyle.Bold) '文字

                        Dim z As SizeF = g.MeasureString(YbS(isz), YbF)
                        X(0) = cR - (cR * 0.5) * Cos(Angle) - z.Width / 2
                        Y(0) = cR - (cR * 0.5) * Sin(Angle) - z.Height / 2
                        g.DrawString(YbS(isz), YbF, Brushes.White, X(0), Y(0))
                        isz += 1
                        YbF.Dispose()
                    End Using
                Next

                circle_penSZ.Dispose()
            End Using
            Using circle_penSZ1 As New Pen(Color.Black, 1.2)

                For i = -42 To 222 Step 4.8                                 '小刻度
                    Angle = (i * PI) / 180
                    X(0) = cR - (cR * 0.755) * Cos(Angle)
                    X(1) = cR - (cR * 0.66) * Cos(Angle)
                    Y(0) = cR - (cR * 0.755) * Sin(Angle)
                    Y(1) = cR - (cR * 0.66) * Sin(Angle)
                    g.DrawLine(circle_penSZ1, X(0), Y(0), X(1), Y(1))
                Next

                circle_penSZ1.Dispose()
                Erase X
                Erase Y
            End Using

        Catch oE As System.Exception
            MsgBox("Error From Ybp-DrawYBP" & Chr(13) & oE.ToString)
        End Try

    End Sub

#End Region

#Region "仪表盘+指针"

    Private Sub picMove_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles picMove.Paint

        '  If bUsed = False Then Exit Sub
        If bUsed = False Then PV = 0
        DrawYBP(e.Graphics)
        e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
        Using Zz_pen As New Pen(Color.Black, 1.7)
            Angle = PI * ((PV - 0.075) / 0.75)    '第1个点     0.75的由来 圆弧的角度 1.1/264*180=0.75 -0.075的由来是没想明白
            AngleZZ = Angle * 180 / PI
            Cr1 = cR * 0.66
            ZzX(0) = cR - Cr1 * Cos(Angle)
            ZzY(0) = cR - Cr1 * Sin(Angle)
            AngleZZ = AngleZZ + 175  '第2个点
            Angle = (AngleZZ * PI) / 180
            Cr1 = cR * 0.34
            ZzX(1) = cR - Cr1 * Cos(Angle)
            ZzY(1) = cR - Cr1 * Sin(Angle)
            AngleZZ = AngleZZ + 5  '第3个点
            Angle = (AngleZZ * PI) / 180
            ZzX(2) = cR - Cr1 * 1.02 * Cos(Angle)
            ZzY(2) = cR - Cr1 * 1.02 * Sin(Angle)
            AngleZZ = AngleZZ + 5  '第4个点
            Angle = (AngleZZ * PI) / 180
            ZzX(3) = cR - Cr1 * Cos(Angle)
            ZzY(3) = cR - Cr1 * Sin(Angle)
            rect_pts1(0) = New PointF(ZzX(0), ZzY(0))
            rect_pts1(1) = New PointF(ZzX(1), ZzY(1))
            rect_pts1(2) = New PointF(ZzX(2), ZzY(2))
            rect_pts1(3) = New PointF(ZzX(3), ZzY(3))
            e.Graphics.DrawPolygon(Zz_pen, rect_pts1)     '绘制指针外框

            If bUsed = True Then
                e.Graphics.FillPolygon(Brushes.Red, rect_pts1) '填充指针
            Else
                e.Graphics.FillPolygon(Brushes.DarkGray, rect_pts1) '填充指针
            End If

        End Using

        ''--------------------------------------------圆心填充
        Dim Crr As Single = cR * 0.06
        e.Graphics.FillEllipse(Brushes.Gray, cR - Crr, cR - Crr, Crr * 2, Crr * 2)
        e.Graphics.DrawEllipse(Pens.Black, cR - Crr, cR - Crr, Crr * 2, Crr * 2)
        e.Graphics.FillEllipse(Brushes.DarkGray, cR - 2, cR - 2, 4, 4)

        '--------------------------------------------显示文字PV
        Dim Fh As Single = cR * 0.082
        Using YbF As New Font("times new roman", Fh, FontStyle.Bold)

            Dim rcttxt As New Rectangle(cR * 0.75, cR * 1.46, cR * 0.5, cR * 0.16)
            Dim txtFmt As New StringFormat
            txtFmt.Alignment = StringAlignment.Center
            e.Graphics.DrawString(PV.ToString(strJingdu), YbF, Brushes.Black, rcttxt, txtFmt)
            YbF.Dispose()
            txtFmt.Dispose()
        End Using

        '--------------------------------------------显示文字SV
        If bYBPsvVisbale = True Then

            Dim FhSv As Single = cR * 0.082
            Using YbF As New Font("times new roman", FhSv, FontStyle.Bold)

                Dim rcttxt As New Rectangle(cR * 0.75, cR * 1.28, cR * 0.5, cR * 0.16)
                Dim txtFmt As New StringFormat
                txtFmt.Alignment = StringAlignment.Center
                e.Graphics.DrawString(SV.ToString(strJingdu), YbF, Brushes.White, rcttxt, txtFmt)
                YbF.Dispose()
                txtFmt.Dispose()
            End Using
        End If

    End Sub

#End Region

#Region "SV 标签颜色变化"

    Public Property SV() As Single
        Get
            Return m_sinSV
        End Get
        Set(ByVal Value As Single)
            m_sinSV = Value
        End Set
    End Property

#End Region

#Region "额定值"
    <Category("Appearance")> _
    Private m_sinSvEd As Single = 0.99

    Public Property SvEd() As Single
        Get
            Return m_sinSvEd
        End Get
        Set(ByVal Value As Single)
            m_sinSvEd = Value
        End Set
    End Property

#End Region

#Region "PV"

    Private m_sinPV As Single = 0.0

    Public Property PV() As Single
        Get
            Return m_sinPV
        End Get
        Set(ByVal Value As Single)

            If Value < -0.1 Then Value = -0.1
            If Value > 1 Then Value = 1
            m_sinPV = Value

            If bUsed = True Then picMove.Refresh()
        End Set
    End Property

#End Region

#Region "Property 'ylset'"

    Private m_sinylset As Single = 0.0

    Public Property ylset() As Single
        Get
            Return m_sinylset
        End Get
        Set(ByVal Value As Single)
            m_sinylset = Value

            If Value < -0.1 Then Value = -0.1
            If Value > 1 Then Value = 1
            sYLset(0) = Value - 0.075
            picMove.Refresh()
        End Set
    End Property

#End Region

#Region "Property 'ylseth'"

    Private m_sinylseth As Single = 0.0

    Public Property ylseth() As Single
        Get
            Return m_sinylseth
        End Get
        Set(ByVal Value As Single)
            m_sinylseth = Value

            If Value < -0.1 Then Value = -0.1
            If Value > 1 Then Value = 1
            sYLset(1) = Value - 0.075
            picMove.Refresh()
        End Set
    End Property

#End Region

#Region "Property 'ylseth1'"

    Private m_sinylseth1 As Single = 0.0

    Public Property ylseth1() As Single
        Get
            Return m_sinylseth1
        End Get
        Set(ByVal Value As Single)
            m_sinylseth1 = Value

            If Value < -0.1 Then Value = -0.1
            If Value > 1 Then Value = 1
            sYLset(2) = Value - 0.075
            picMove.Refresh()
        End Set
    End Property

#End Region

#Region "Property 'bSnvisbale'"

    Private m_bbSnvisbale As Boolean = True

    Public Property bSnvisbale() As Boolean
        Get
            Return m_bbSnvisbale
        End Get
        Set(ByVal Value As Boolean)
            m_bbSnvisbale = Value
            lblJdqbh.Visible = Value
        End Set
    End Property

#End Region

#Region "Property 'iSn'"

    Private m_striSn As String

    Public Property iSn() As String
        Get
            Return m_striSn
        End Get
        Set(ByVal Value As String)
            m_striSn = Value
            lblJdqbh.Text = Value & " 号"
        End Set
    End Property

#End Region

#Region "Property 'bUsed'"

    Private m_bbUsed As Boolean = 1

    Public Property bUsed() As Boolean
        Get
            Return m_bbUsed
        End Get
        Set(ByVal Value As Boolean)
            m_bbUsed = Value
            chkIsuse.Checked = Value
            Me.Refresh()
        End Set
    End Property

    Private Sub chkIsuse_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkIsuse.CheckedChanged
        bUsed = chkIsuse.CheckState

        If bUsed = False Then
            ylset = 0
            ylseth = 0
            ylseth1 = 0
        End If

        chkIsuse.Text = IIf(bUsed, "启用", "停用")
    End Sub

#End Region

#Region "CCD显示"

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        picCCD.Visible = Not picCCD.Visible

        If bIsclicking Then picClick.Visible = Not picClick.Visible
    End Sub

    Public Property bWaitCCD() As Boolean
        Get
            Return m_bbWaitCCD
        End Get
        Set(ByVal Value As Boolean)
            m_bbWaitCCD = Value
            Timer1.Enabled = Value
            picCCD.Visible = Value
        End Set
    End Property

    Public Property bIsclicking() As Boolean
        Get
            Return m_bbIsclicking
        End Get
        Set(ByVal Value As Boolean)
            m_bbIsclicking = Value
            picClick.Visible = Value
        End Set
    End Property

#End Region

#Region "Property 'bLblColor'"

    Private m_bbLblColor As Boolean

    Public Property bLblColor() As Boolean
        Get
            Return m_bbLblColor
        End Get
        Set(ByVal Value As Boolean)
            m_bbLblColor = Value
            lblJdqbh.BackColor = IIf(Value = True, Color.Red, Color.Transparent)
        End Set
    End Property

#End Region

#Region "稳定倒计时"

    Private m_bbYbpWait As Boolean = False

    Dim iWaitCnt As Integer = 10

    Public Property bYbpWait() As Boolean
        Get
            Return m_bbYbpWait
        End Get
        Set(ByVal Value As Boolean)
            m_bbYbpWait = Value
            lblWait.Visible = Value
            Timer2.Enabled = Value

            If Value = True Then
                iWaitCnt = 10
                m_bbYbpWait = False
            End If

        End Set
    End Property

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick

        iWaitCnt -= 1
        lblWait.Text = iWaitCnt
        If iWaitCnt <= 0 Then
            Timer2.Enabled = False
            lblWait.Visible = False
        End If

    End Sub

#End Region

#Region "Property 'bYBPsvVisbale'"

    Private m_bbYBPsvVisbale As Boolean = True

    Public Property bYBPsvVisbale() As Boolean
        Get
            Return m_bbYBPsvVisbale
        End Get
        Set(ByVal Value As Boolean)
            m_bbYBPsvVisbale = Value
        End Set
    End Property

#End Region
    Dim strJingdu As String = "f4"
#Region "Property 'ijingdu'"

    Private m_intijingdu As Integer = 4
    Public Property ijingdu() As Integer
        Get
            Return m_intijingdu
        End Get
        Set(ByVal Value As Integer)
            m_intijingdu = Value
            strJingdu = "f" & Value
        End Set
    End Property

#End Region 'Property 'ijingdu'


End Class
