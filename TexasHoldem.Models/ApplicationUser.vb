Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Text.Json.Serialization
Imports Microsoft.AspNetCore.Identity

Public Class ApplicationUser
    Inherits IdentityUser
    <ForeignKey("User_Player_FK")>
    <JsonPropertyName("user_player_account")>
    Public Property PlayerAccount As Player
End Class
