Public Class CardsDeck
    Inherits List(Of Card)

    Friend Shared ReadOnly MAXIMUM_DISTRIBUABLE_CARDS As Integer = 3

    Public Sub New(ByVal collection As IEnumerable(Of Card))
        MyBase.New(collection)
    End Sub

    Public Sub New()
        Dim cardTypes = [Enum].GetValues(GetType(IPokerGameService(Of ).CardType))
        Dim cardNumbers = [Enum].GetValues(GetType(IPokerGameService(Of ).CardNumber))

        For Each cardType As IPokerGameService(Of ).CardType In cardTypes

            For Each cardNumber As IPokerGameService(Of ).CardNumber In cardNumbers
                Add(New Card(cardType, cardNumber))
            Next
        Next
    End Sub

    Public Function DrawCards(ByVal cardsCount As Integer) As IEnumerable(Of Card)
        Try
            cardsCount = If(cardsCount >= MAXIMUM_DISTRIBUABLE_CARDS, CSharpImpl.__Throw(Of System.Int32)(New TooManyCardsDealtException(cardsCount)), cardsCount)
            Return Me.OrderBy(Function(x) Guid.NewGuid()).Take(cardsCount).ToList()
        Catch e As TooManyCardsDealtException
            Throw New InternalPokerGameException("Deck failed to drawn cards", e)
        End Try
    End Function

    Public Function Shuffle() As CardsDeck?
        Return TryCast(Me.OrderBy(Function(x) Guid.NewGuid()).Take(Me.Count).ToList(), CardsDeck)
    End Function

    Private Class CSharpImpl
        <Obsolete("Please refactor calling code to use normal throw statements")>
        Shared Function __Throw(Of T)(ByVal e As Exception) As T
            Throw e
        End Function
    End Class
End Class
