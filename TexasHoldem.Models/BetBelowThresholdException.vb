Public Class BetBelowThresholdException
    Inherits Exception

    Public Sub New(ByVal threshold As Double, ByVal amount As Double, ByVal player As Player)
        MyBase.New($"Player:{player.Id} has placed a bet:{amount}$ below the threshold:{threshold}$")
    End Sub
End Class