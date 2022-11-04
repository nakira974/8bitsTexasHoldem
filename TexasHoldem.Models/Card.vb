Imports System.Text.Json.Serialization

Public Class Card
    <JsonPropertyName("family")>
    Public Property Family As CardType
    <JsonPropertyName("number")>
    Public Property Number As CardNumber

    Public Sub New(ByVal family As CardType, ByVal number As CardNumber)
        Family = family
        Number = number
    End Sub
End Class