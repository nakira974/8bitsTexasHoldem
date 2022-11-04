Imports TexasHoldem.Models.Services

Public Interface IGameService(Of T)
    Public Function Start() As GameBase(Of IGameService(Of T))
    Public Function StartAsync() As Task(Of GameBase(Of IGameService(Of T)))
    Public Function Suspend(ByVal time As Double) As GameBase(Of IGameService(Of T))
    Public Function SuspendAsync(ByVal time As Double) As Task(Of GameBase(Of IGameService(Of T)))
    Public Function Finish() As GameBase(Of IGameService(Of T))
    Public Function FinishAsync() As Task(Of GameBase(Of IGameService(Of T)))
    
End Interface