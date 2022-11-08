Namespace Services

    Public MustInherit Class PokerServiceBase (Of T)
        Implements IGameService(Of PokerServiceBase(Of T))

        Private ReadOnly Property GameServicesImplementation As IGameService(Of PokerServiceBase(Of T))

        

        Public Overridable Async Function IGameService_StartAsync() As Task(Of GameBase(Of IGameService(Of PokerServiceBase(Of T)))) Implements IGameService(Of PokerServiceBase(Of T)).StartAsync
            Return Await GameServicesImplementation.StartAsync()
        End Function

        Public Overridable Function IGameService_Start() As GameBase(Of IGameService(Of PokerServiceBase(Of T))) Implements IGameService(Of PokerServiceBase(Of T)).Start
            Return GameServicesImplementation.Start()
        End Function

        Public Overridable Function IGameService_Suspend(time As Double) As GameBase(Of IGameService(Of PokerServiceBase(Of T))) Implements IGameService(Of PokerServiceBase(Of T)).Suspend
            Return GameServicesImplementation.Suspend(time)
        End Function
        

        Public Overridable Async Function IGameService_SuspendAsync(time As Double) As Task(Of GameBase(Of IGameService(Of PokerServiceBase(Of T)))) Implements IGameService(Of PokerServiceBase(Of T)).SuspendAsync
            Return Await GameServicesImplementation.SuspendAsync(time)
        End Function
        
        Public Overridable Function IGameService_Finish() As GameBase(Of IGameService(Of PokerServiceBase(Of T))) Implements IGameService(Of PokerServiceBase(Of T)).Finish
            Return GameServicesImplementation.Finish()
        End Function
        

        Public Overridable Async Function IGameService_FinishAsync() As Task(Of GameBase(Of IGameService(Of PokerServiceBase(Of T)))) Implements IGameService(Of PokerServiceBase(Of T)).FinishAsync
            Return Await GameServicesImplementation.FinishAsync()
        End Function
        
    End Class
End NameSpace