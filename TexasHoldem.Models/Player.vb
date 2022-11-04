Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Text.Json.Serialization

Public Class Player
    Public Sub New()
    End Sub

    Public Sub New(ByVal connectionId As String)
        ConnectionId = connectionId
    End Sub

    <JsonPropertyName("application_user")>
    Public Property User As ApplicationUser
    <NotMapped>
    <JsonPropertyName("connection_id")>
    Public Property ConnectionId As String
    <JsonPropertyName("user_id")>
    Public Property Id As Integer
    <JsonPropertyName("username")>
    Public Property UserName As String
    <JsonPropertyName("held_cards")>
    Public Property HeldCards As IEnumerable(Of Card)
    <JsonPropertyName("folded")>
    Public Property Folded As Boolean
End Class
