using OurGames.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OurGames.UI.Services.Abstractions
{
    public interface IPagSeguroPayment
    {
        string GetPaymentURL(PagSeguroModel model);
    }
}
