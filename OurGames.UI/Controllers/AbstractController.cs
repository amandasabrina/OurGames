using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OurGames.Core.Entity;

namespace OurGames.UI.Controllers
{
    //[Authorize]
    public class AbstractController : Controller
    {
        protected AccessLevelType UserAccessLevel => 
            (AccessLevelType)Enum.Parse(typeof(AccessLevelType), User.FindFirst("userAccessLevel").Value);
    }
}