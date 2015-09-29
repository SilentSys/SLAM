Public Class SourceGame
    Public Property Name As String
    Public Property Directory As String
    Public Property ToCfg As String
    Public Property LibraryName As String
    Public Property FileExtension As String = ".wav"
    Public Property SampleRate As Integer = 11025
    Public Property Bits As Integer = 16
    Public Property Channels As Integer = 1

    Public Property PollInterval As Integer = 100
    Public Property RelayKey As String = "="

    Public Property tracks As New List(Of track)
    Public Class track
        Public Property Name As String
        Public Property Tags As New List(Of String)
        Public Property Hotkey As String
    End Class
End Class