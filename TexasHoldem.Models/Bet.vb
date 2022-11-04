Imports System.Text.Json.Serialization

Public Class Bet
    Public Sub New()
    End Sub

    Public Sub New(ByVal threshold As Double, ByVal amount As Double, ByVal gambler As Player)
        Amount =
            If _
                (Not (amount.Equals(0)) AndAlso (amount >= threshold), amount,
                 CSharpImpl.__Throw (Of System.Int32)(New BetBelowThresholdException(threshold, amount, gambler)))
        Gambler = gambler
    End Sub

    <JsonPropertyName("bet_id")>
    Public Property Id As Integer

    <JsonPropertyName("amount")>
    Public Property Amount As Double

    <JsonPropertyName("player")>
    Public Property Gambler As Player

    Private Class CSharpImpl
        <Obsolete("Please refactor calling code to use normal throw statements")>
        Shared Function __Throw (Of T)(ByVal e As Exception) As T
            Throw e
        End Function
    End Class
End Class
