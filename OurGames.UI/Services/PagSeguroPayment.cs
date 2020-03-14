using Microsoft.Extensions.Options;
using OurGames.Core.Entity;
using OurGames.UI.Models;
using OurGames.UI.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace OurGames.UI.Services
{
    public class PagSeguroPayment : IPagSeguroPayment
    {
        private readonly OurGamesUIConfig _config;

        public PagSeguroPayment(IOptions<OurGamesUIConfig> options)
        {
            _config = options.Value;
        }

        public string GetPaymentURL(PagSeguroModel model)
        {

            //Conjunto de parâmetros/formData.
            System.Collections.Specialized.NameValueCollection postData = new NameValueCollection
            {
                { "email", _config.PagSeguroEmail },
                { "token", _config.PagSeguroToken },
                { "currency", "BRL" },
                { "itemId1", model.Id },
                { "itemDescription1", model.Name },
                { "itemAmount1", model.Amount },
                { "itemQuantity1", "1" },
                { "itemWeight1", "0" },
                { "reference", "REF1234" },
                { "senderName", model.Name ?? ""},
                //{ "senderAreaCode", "44" },
                //{ "senderPhone", "999999999" },
                { "senderEmail", model.SenderEmail ?? "" },
                { "shippingAddressRequired", "false" }
            };

            string xmlString = null;

            using (var wc = new WebClient())
            {
                wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";

                var result = wc.UploadValues(_config.PagSeguroUrl, postData);

                xmlString = Encoding.ASCII.GetString(result);
            }

            var xmlDoc = new XmlDocument();

            xmlDoc.LoadXml(xmlString);

            var code = xmlDoc.GetElementsByTagName("code")[0];

            var date = xmlDoc.GetElementsByTagName("date")[0];

            var paymentUrl = string.Concat("https://pagseguro.uol.com.br/v2/checkout/payment.html?code=", code.InnerText);

            return paymentUrl;
        }
    }
}
