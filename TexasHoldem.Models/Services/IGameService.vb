Namespace Services
    Public Interface IGameService (Of T) 
        Function Start() As GameBase(Of IGameService(Of T))
        Function StartAsync() As Task(Of GameBase(Of IGameService(Of T)))
        Function Suspend(ByVal time As Double) As GameBase(Of IGameService(Of T))
        Function SuspendAsync(ByVal time As Double) As Task(Of GameBase(Of IGameService(Of T)))
        Function Finish() As GameBase(Of IGameService(Of T))
        Function FinishAsync() As Task(Of GameBase(Of IGameService(Of T)))
    End Interface
End NameSpace