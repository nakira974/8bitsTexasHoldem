Imports System.Text.Json.Serialization

Public Class Card
    <JsonPropertyName("family")>
    Public Property Family As IPokerGameService(Of ).CardType
    <JsonPropertyName("number")>
    Public Property Number As IPokerGameService(Of ).CardNumber

    Public Sub New(ByVal family As IPokerGameService(Of ).CardType, ByVal number As IPokerGameService(Of ).CardNumber)
        Family = family
        Number = number
    End Sub
End Class