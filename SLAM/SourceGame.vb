Public Class SourceGame
    Public name As String
    Public id As Integer
    Public directory As String
    Public ToCfg As String
    Public libraryname As String
    Public VoiceFadeOut As Boolean = True
    Public exename As String = "hl2"

    Public FileExtension As String = ".wav"
    Public samplerate As Integer = 11025
    Public bits As Integer = 16
    Public channels As Integer = 1

    Public PollInterval As Integer = 100

    Public tracks As New List(Of Track)
    Public blacklist As New List(Of String) From {"slam", "slam_listtracks", "list", "tracks", "la", "slam_play", "slam_play_on", "slam_play_off", "slam_updatecfg", "slam_curtrack", "slam_saycurtrack", "slam_sayteamcurtrack"}

    Public Class track
        Public name As String
        Public tags As New List(Of String)
        Public hotkey As String = vbNullString
        Public volume As Integer = 100
        Public startpos As Integer
        Public endpos As Integer
    End Class
End Class