using BlazorBookStore_App.Components.Models;
using Blazored.Modal;
using COMMON.Interfaces;
using COMMON.Models;
using Microsoft.AspNetCore.Components;
using SERVICE.Contracts;
using System;
using System.Threading.Tasks;

public class UserState
{
    private readonly IUnitOfWork _uow;
    private readonly IBookUserEngine _userEngine;
    public UserState(IUnitOfWork uow,IBookUserEngine userEngine)
    {
            _uow = uow;
        _userEngine = userEngine;
    }

    public int Id { get; set; }
    public bool IsAuthenticated { get; private set; }
    public string? FirstName { get; private set; }
    public string? LastName { get; private set; }
    public string UserName { get; private set; } = string.Empty;
    public string Token { get; private set; } = string.Empty;
    public string? Password { get; set; }
    public string? Bio { get; set; } 
    public string? City { get; set; }
    public int FollowerCount { get; set; } = 0;
    public int FollowedCount { get; set; } = 0;
    public ICollection<UserListModel> Followers { get; set; } = new List<UserListModel>();
    public ICollection<UserListModel> Following { get; set; } = new List<UserListModel>();

    public event Action? OnChange;

    public void SetUser(LoggedUser user)
    {
        Id=user.Id;
        IsAuthenticated = true;
        UserName = user.UserName;
        Token = user.Token;
        Bio = user.Bio;
        City = user.City;
        FollowerCount = user.FollowerCount;
        FollowedCount = user.FollowedCount;
        Followers = _userEngine.GetFollowerUsers(user.Id).Result;
        Following = _userEngine.GetFollowedUsers(user.Id).Result;



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
