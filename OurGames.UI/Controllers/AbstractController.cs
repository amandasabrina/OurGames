using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OurGames.Core;

namespace OurGames.UI.Controllers
{
    public class AbstractController : Controller
    {
        protected AccessLevel UserAccessLevel => 
            (AccessLevel)Enum.Parse(typeof(AccessLevel), User.FindFirst("userAccessLevel").Value);
    }
}