Public Class TooManyCardsDealtException
    Inherits Exception

    Public Sub New(ByVal cardsCount As Integer)
        MyBase.New(
            $"Too many cards dealt {cardsCount} for Texas Holdem the limit is {CardsDeck.MAXIMUM_DISTRIBUABLE_CARDS}")
    End Sub
End Class