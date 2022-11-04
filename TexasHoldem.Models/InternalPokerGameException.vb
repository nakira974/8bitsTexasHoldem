Public Class InternalPokerGameException
    Inherits Exception

    Public Sub New(ByVal message As String, ByVal innerException As TooManyCardsDealtException)
        MyBase.New(message, innerException)
    End Sub
End Class