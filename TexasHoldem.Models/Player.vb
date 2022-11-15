Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Text.Json.Serialization

<Table("Players")>
Public Class Player
    Public Sub New()
    End Sub

    Public Sub New(ByVal connectionId As String)
        ConnectionId = connectionId
    End Sub

    <Required>
    <ForeignKey("User_Player_FK")>
    <JsonPropertyName("application_user")>
    Public Property User As ApplicationUser

    <NotMapped>
    <JsonPropertyName("connection_id")>
    Public Property ConnectionId As String

    <Key>
    <DatabaseGenerated(DatabaseGeneratedOption.Identity)>
    <JsonPropertyName("player_id")>
    Public Property Id As Integer

    <Required>
    <JsonPropertyName("username")>
    Public Property UserName As String

    <NotMapped>
    <JsonPropertyName("held_cards")>
    Public Property HeldCards As IEnumerable(Of Card)

    <NotMapped>
    <JsonPropertyName("folded")>
    Public Property Folded As Boolean
End Class
