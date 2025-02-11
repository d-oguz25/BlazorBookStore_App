using BlazorBookStore_App.Components.Models;
using Blazored.Modal;
using COMMON.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

public class UserState
{
    public bool IsAuthenticated { get; private set; }
    public string UserName { get; private set; } = string.Empty;
    public string Token { get; private set; } = string.Empty;
    public string? Password { get; set; }
    public string Bio { get; set; } 
    public string City { get; set; }
    public int FollowerCount { get; set; }
    public int FollowedCount { get; set; }

    public event Action? OnChange;

    public void SetUser(LoggedUser user)
    {
        IsAuthenticated = true;
        UserName = user.UserName;
        Token = user.Token;
        Bio = user.Bio;
        City = user.City;
        FollowerCount = user.FollowerCount;
        FollowedCount = user.FollowedCount;
        

        NotifyStateChanged();
    }

    public void Logout()
    {
        IsAuthenticated = false;
        UserName = string.Empty;
        Token = string.Empty;
        NotifyStateChanged();
    }

    private void NotifyStateChanged() => OnChange?.Invoke();
}
