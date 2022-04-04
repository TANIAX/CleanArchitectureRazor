using Application.Common.Interfaces;
using Microsoft.AspNetCore.Identity;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace WebUI.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _contextAccessor = httpContextAccessor;
        }

        /*https://stackoverflow.com/questions/59793111/ihttpcontextaccessor-httpcontext-user-identity-shows-all-null-properties-in-curr*/
        public string UserId { get { return _contextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier); } }
    }
}

