
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports NAudio.Wave

''' <summary>
''' Control for viewing waveforms
''' </summary>
Public Class AdvWaveViewer
    Inherits System.Windows.Forms.UserControl
    ''' <summary> 
    ''' Required designer variable.
    ''' </summary>
    Private components As System.ComponentModel.Container = Nothing
    Private m_waveStream As WaveStream
    Private m_samplesPerPixel As Integer = 128
    Private m_startPosition As Long
    Private bytesPerSample As Integer = 2
    ''' <summary>
    ''' Creates a new WaveViewer control
    ''' </summary>
    Public Sub New()
        ' This call is required by the Windows.Forms Form Designer.
        InitializeComponent()

        Me.DoubleBuffered = True

    End Sub

    Public Sub Fit()
        If m_waveStream Is Nothing Then
            Return
        End If

        If Not Me.Width > 0 Then
            Return
        End If

        Dim samples As Integer = CInt(m_waveStream.Length / bytesPerSample)
        m_startPosition = 0
        SamplesPerPixel = samples / Me.Width

    End Sub

    Protected Overrides Sub OnResize(e As EventArgs)
        MyBase.OnResize(e)
        Fit()
    End Sub

    Private mousePos As Point, startPos As Point
    Private mouseDrag As Boolean = False

    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        If e.Button = System.Windows.Forms.MouseButtons.Left And Me.Enabled Then

            startPos = e.Location
            mousePos = New Point(-1, -1)
            mouseDrag = True
            DrawVerticalLine(e.X)

        End If

        MyBase.OnMouseDown(e)
    End Sub

    Protected Overrides Sub OnMouseMove(e As MouseEventArgs)
        If e.X >= 0 And e.X <= Me.Width And Me.Enabled Then
            If mouseDrag Then
                DrawVerticalLine(e.X)
                If mousePos.X <> -1 Then
                    DrawVerticalLine(mousePos.X)
                End If
                mousePos = e.Location
            End If
        End If
        MyBase.OnMouseMove(e)
    End Sub

    Public ReadOnly Property MaxSamples As Integer
        Get
            Return m_waveStream.Length / bytesPerSample
        End Get
    End Property

    Private m_leftSample As Integer = -1
    Public Property leftSample As Integer
        Get
            Return m_leftSample
        End Get
        Set(value As Integer)
            m_leftSample = value
            Me.Invalidate()
        End Set
    End Property
    Private m_rightSample As Integer = -1
    Public Property rightSample As Integer
        Get
            Return m_rightSample
        End Get
        Set(value As Integer)
            m_rightSample = value
            Me.Invalidate()
        End Set
    End Property

    Public Property leftpos As Integer
        Get
            Return m_leftSample * bytesPerSample
        End Get
        Set(value As Integer)
            m_leftSample = value / bytesPerSample
            Me.Invalidate()
        End Set
    End Property

    Public Property rightpos As Integer
        Get
            Return m_rightSample * bytesPerSample
        End Get
        Set(value As Integer)
            m_rightSample = value / bytesPerSample
            Me.Invalidate()
        End Set
    End Property

    Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
        If mouseDrag AndAlso e.Button = System.Windows.Forms.MouseButtons.Left AndAlso Me.Enabled Then
            mouseDrag = False
            'DrawVerticalLine(startPos.X)

            If mousePos.X = -1 Then

                If Not startPos.X = 0 Then
                    DrawVerticalLine(startPos.X)
                End If

                Return
            End If
            'DrawVerticalLine(mousePos.X)

            m_leftSample = CInt(StartPosition \ bytesPerSample + m_samplesPerPixel * Math.Min(startPos.X, mousePos.X))
            m_rightSample = CInt(StartPosition \ bytesPerSample + m_samplesPerPixel * Math.Max(startPos.X, mousePos.X))
            Me.Invalidate()
        End If

        MyBase.OnMouseUp(e)
    End Sub

    Private Sub DrawVerticalLine(x As Integer)
        ControlPaint.DrawReversibleLine(PointToScreen(New Point(x, 0)), PointToScreen(New Point(x, Height)), Color.Black)
    End Sub

    ''' <summary>
    ''' sets the associated wavestream
    ''' </summary>
    Public Property WaveStream() As WaveStream
        Get
            Return m_waveStream
        End Get
        Set(value As WaveStream)
            m_waveStream = value
            If m_waveStream IsNot Nothing Then
                bytesPerSample = (m_waveStream.WaveFormat.BitsPerSample / 8) * m_waveStream.WaveFormat.Channels
                Fit()
            End If
            Me.Invalidate()
        End Set
    End Property

    Public ReadOnly Property SampleRate As Integer
        Get
            Return m_waveStream.WaveFormat.SampleRate
        End Get
    End Property

    ''' <summary>
    ''' The zoom level, in samples per pixel
    ''' </summary>
    Public Property SamplesPerPixel() As Integer
        Get
            Return m_samplesPerPixel
        End Get
        Set(value As Integer)
            m_samplesPerPixel = value
            Me.Invalidate()
        End Set
    End Property

    ''' <summary>
    ''' Start position (currently in bytes)
    ''' </summary>
    Public Property StartPosition() As Long
        Get
            Return m_startPosition
        End Get
        Set(value As Long)
            m_startPosition = value
        End Set
    End Property

    Private m_marker As Integer
    Public Property marker() As Long
        Get
            Return m_marker
        End Get
        Set(value As Long)
            If value <= MaxSamples Then
                m_marker = value
                Me.Invalidate()
            End If
        End Set
    End Property

    ''' <summary> 
    ''' Clean up any resources being used.
    ''' </summary>
    Protected Overrides Sub Dispose(disposing As Boolean)
        If disposing Then
            If components IsNot Nothing Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    ''' <summary>
    ''' <see cref="Control.OnPaint"/>
    ''' </summary>
    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        If m_waveStream IsNot Nothing Then
            m_waveStream.Position = 0
            Dim bytesRead As Integer
            Dim waveData As Byte() = New Byte(m_samplesPerPixel * bytesPerSample - 1) {}
            m_waveStream.Position = m_startPosition + (e.ClipRectangle.Left * bytesPerSample * m_samplesPerPixel)

            Dim leftpos As Integer = CInt(m_leftSample \ m_samplesPerPixel - StartPosition \ bytesPerSample \ m_samplesPerPixel)
            Dim rightpos As Integer = CInt(m_rightSample \ m_samplesPerPixel - StartPosition \ bytesPerSample \ m_samplesPerPixel)
            Dim markerpos As Integer = CInt((m_marker + m_leftSample) \ m_samplesPerPixel - StartPosition \ bytesPerSample \ m_samplesPerPixel)

            For x As Single = e.ClipRectangle.X To e.ClipRectangle.Right - 1
                Dim low As Short = 0
                Dim high As Short = 0
                bytesRead = m_waveStream.Read(waveData, 0, m_samplesPerPixel * bytesPerSample)
                If bytesRead = 0 Then
                    Exit For
                End If
                For n As Integer = 0 To bytesRead - 1 Step 2
                    Dim sample As Short = BitConverter.ToInt16(waveData, n)
                    If sample < low Then
                        low = sample
                    End If
                    If sample > high Then
                        high = sample
                    End If
                Next
                Dim lowPercent As Single = ((CSng(low) - Short.MinValue) / UShort.MaxValue)
                Dim highPercent As Single = ((CSng(high) - Short.MinValue) / UShort.MaxValue)
                Using DodgerBluePen As New Pen(Color.DodgerBlue), BluePen As New Pen(Color.Blue), RedPen As New Pen(Color.Red), GreenPen As New Pen(Color.Green)

                    If x = leftpos And Not leftSample = rightSample Or x = rightpos And Not rightSample = leftSample Then
                        e.Graphics.DrawLine(RedPen, x, 0, x, Me.Height)

                    ElseIf x = markerpos And m_marker > 0 Then
                        e.Graphics.DrawLine(GreenPen, x, 0, x, Me.Height)

                    ElseIf x > leftpos And x < rightpos Then
                        e.Graphics.DrawLine(BluePen, x, Me.Height * lowPercent, x, Me.Height * highPercent)

                    Else
                        e.Graphics.DrawLine(DodgerBluePen, x, Me.Height * lowPercent, x, Me.Height * highPercent)

                    End If

                End Using
            Next
        End If

        MyBase.OnPaint(e)
    End Sub


#Region "Component Designer generated code"
    ''' <summary> 
    ''' Required method for Designer support - do not modify 
    ''' the contents of this method with the code editor.
    ''' </summary>
    Private Sub InitializeComponent()
        components = New System.ComponentModel.Container()
    End Sub
#End Region
End Class
