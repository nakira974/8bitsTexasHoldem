Imports TexasHoldem.Models.Services

Public Class IPokerGameService(Of T)
    Implements IGameService(Of IPokerGameService(Of IPokerGameService(Of T)))

    Private ReadOnly Property GameServicesImplementation As IGameService(Of IPokerGameService(Of IPokerGameService(Of T)))

    Public Function Start() As GameBase(Of IGameService(Of IPokerGameService(Of IPokerGameService(Of T)))) Implements IGameService(Of IPokerGameService(Of IPokerGameService(Of T))).Start
        Return GameServicesImplementation.Start()
    End Function

    Public Async Function StartAsync() As Task(Of GameBase(Of IGameService(Of IPokerGameService(Of IPokerGameService(Of T))))) Implements IGameService(Of IPokerGameService(Of IPokerGameService(Of T))).StartAsync
        Return Await GameServicesImplementation.StartAsync()
    End Function

    Public Function Suspend(time As Double) As GameBase(Of IGameService(Of IPokerGameService(Of IPokerGameService(Of T)))) Implements IGameService(Of IPokerGameService(Of IPokerGameService(Of T))).Suspend
        Return GameServicesImplementation.Suspend(time)
    End Function

    Public Async Function SuspendAsync(time As Double) As Task(Of GameBase(Of IGameService(Of IPokerGameService(Of IPokerGameService(Of T))))) Implements IGameService(Of IPokerGameService(Of IPokerGameService(Of T))).SuspendAsync
        Return Await GameServicesImplementation.SuspendAsync(time)
    End Function

    Public Function Finish() As GameBase(Of IGameService(Of IPokerGameService(Of IPokerGameService(Of T)))) Implements IGameService(Of IPokerGameService(Of IPokerGameService(Of T))).Finish
        Return GameServicesImplementation.Finish()
    End Function

    Public Async Function FinishAsync() As Task(Of GameBase(Of IGameService(Of IPokerGameService(Of IPokerGameService(Of T))))) Implements IGameService(Of IPokerGameService(Of IPokerGameService(Of T))).FinishAsync
        Return Await GameServicesImplementation.FinishAsync()
    End Function


    Public Enum CardNumber
        Two = &H02
        Three = &H03
        Four = &H04
        Five = &H05
        Six = &H06
        Seven = &H07
        Height = &H08
        Nine = &H09
        Ten = &H0A
        Jack = &H0B
        Queen = &H0C
        King = &H0D
        Ace = &H0E
    End Enum

    Public Enum CardType
        Club = &H0EAB0A
        Heart = &H0EAB0B
        Spade = &H0EAB0C
        Diamond = &H0EAB0D
    End Enum
    
End Class
