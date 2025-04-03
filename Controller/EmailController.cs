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
        [ServiceFilter(typeof(AdminOnlyAuthorizationFilter))]
        public bool deneme1()
        {
            return true;
        }
        [ServiceFilter(typeof(ExecutionTimeActionFilter))]
        public bool deneme2()
        {
            return true;
        }
        [ServiceFilter(typeof(CustomResultFilter))]
        public bool deneme3()
        {
            return true;
        }
    }
}
   



