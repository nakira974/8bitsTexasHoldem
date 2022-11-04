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


   


    
End Class
