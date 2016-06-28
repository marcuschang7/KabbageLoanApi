using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Text;
using System.Web.Mvc;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using MarcusChangKappageAPI.Models;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.EnterpriseServices;

namespace ASP.NET_MVC5_Bootstrap3_3_1_LESS.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            PreQualificationResponseFinal PR = new PreQualificationResponseFinal
            {
                Qualified = "",
                QualifyAmount = 0,
                RedirectUrl = ""
            };
            ViewData["ResponseResults"] = PR;
            //return View();
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(KabbageFormModel model)
        {

            PreQualificationResponseFinal PR = new PreQualificationResponseFinal();

            ModelState.Remove("api_key");
            model.api_key = "vauwg9sbqkrdnzdmr7eyk92t";

            if (ModelState.IsValid)
            {
                using (var prequalApiClient = new HttpClient())
                {
                    prequalApiClient.BaseAddress = new Uri("https://api.kabbage.com/");
                    prequalApiClient.DefaultRequestHeaders.Accept.Clear();
                    prequalApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));

                    var requestParameters = model.GetType().GetProperties().Select(p => new KeyValuePair<string, string>(p.Name, p.GetValue(model).ToString()));
                    var requestContent = new FormUrlEncodedContent(requestParameters);
                    using (HttpResponseMessage response = await prequalApiClient.PostAsync("v2/prequalify", requestContent))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var serializer = new DataContractJsonSerializer(typeof(PreQualificationResponse));
                            var contentStream = response.Content.ReadAsStreamAsync().Result;
                            var prequalResult = (PreQualificationResponse)serializer.ReadObject(contentStream);

                            if (prequalResult != null)
                            {
                                string Qual;
                                if (prequalResult.Qualified == "true")
                                {
                                    Qual = "Qualified";
                                }
                                else
                                {
                                    Qual = prequalResult.Qualified;
                                }
                                if (prequalResult.Qualified == "false")
                                {
                                    Qual = "NotQualified";
                                }
                                PR.Qualified = Qual;
                                PR.QualifyAmount = prequalResult.QualifyAmount;
                                PR.RedirectUrl = Convert.ToString(prequalResult.RedirectUrl);
                                string Ok = Convert.ToString(prequalResult.RedirectUrl);
                                ViewData["ResponseResults"] = PR;
                                return View();
                            }
                        }
                    }
                }
            }
            PR.Qualified = "TryAgain";
            PR.QualifyAmount = 0;
            ViewData["ResponseResults"] = PR;
            return View(model);
        }

    }
}