using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using SERVICE.Contracts;

namespace BlazorBookStore_App.Controller
{
      public class EmailController : ControllerBase
    {
        private readonly IAuthUserEngine _userEngine;
        public EmailController(IAuthUserEngine userEngine)
        {
            _userEngine = userEngine;
        }


   

    }

