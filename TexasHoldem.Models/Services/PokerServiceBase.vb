Namespace Services

    Public MustInherit Class PokerServiceBase (Of T)
        Implements IGameService(Of PokerServiceBase(Of PokerServiceBase(Of T)))

        Private ReadOnly Property GameServicesImplementation As _
            IGameService(Of PokerServiceBase(Of PokerServiceBase(Of T)))

        Public Function Start() As GameBase(Of IGameService(Of PokerServiceBase(Of PokerServiceBase(Of T)))) _
            Implements IGameService(Of PokerServiceBase(Of PokerServiceBase(Of T))).Start
            Return GameServicesImplementation.Start()
        End Function

        Public Async Function StartAsync() _
            As Task(Of GameBase(Of IGameService(Of PokerServiceBase(Of PokerServiceBase(Of T))))) _
            Implements IGameService(Of PokerServiceBase(Of PokerServiceBase(Of T))).StartAsync
            Return Await GameServicesImplementation.StartAsync()
        End Function

        Public Function Suspend(time As Double) _
            As GameBase(Of IGameService(Of PokerServiceBase(Of PokerServiceBase(Of T)))) _
            Implements IGameService(Of PokerServiceBase(Of PokerServiceBase(Of T))).Suspend
            Return GameServicesImplementation.Suspend(time)
        End Function

        Public Async Function SuspendAsync(time As Double) _
            As Task(Of GameBase(Of IGameService(Of PokerServiceBase(Of PokerServiceBase(Of T))))) _
            Implements IGameService(Of PokerServiceBase(Of PokerServiceBase(Of T))).SuspendAsync
            Return Await GameServicesImplementation.SuspendAsync(time)
        End Function

        Public Function Finish() As GameBase(Of IGameService(Of PokerServiceBase(Of PokerServiceBase(Of T)))) _
            Implements IGameService(Of PokerServiceBase(Of PokerServiceBase(Of T))).Finish
            Return GameServicesImplementation.Finish()
        End Function

        Public Async Function FinishAsync() _
            As Task(Of GameBase(Of IGameService(Of PokerServiceBase(Of PokerServiceBase(Of T))))) _
            Implements IGameService(Of PokerServiceBase(Of PokerServiceBase(Of T))).FinishAsync
            Return Await GameServicesImplementation.FinishAsync()
        End Function
    End Class
End NameSpace