using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Net;
using System.Net.NetworkInformation;
using System.Text;


namespace CloudDiags.Controllers
{
    public class NetworkController : Controller
    {
        public IActionResult Index()
        {
            string anAddress = "google.com";
            PingIt p = new PingIt();

            String strReturn = string.Empty;
            Ping pingSender = new Ping();
            PingOptions options = new PingOptions();

            options.DontFragment = true;

            // Create a buffer of 32 bytes of data to be transmitted.
            string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            int timeout = 120;
            PingReply reply = pingSender.Send(anAddress, timeout, buffer, options);
            if (reply.Status == IPStatus.Success)
            {
                ViewData["Address"] = reply.Address.ToString();
            }

            return View();
        }

        public ActionResult Vault()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public string Welcome(string name, int numTimes = 1)
        {
            return HtmlEncoder.Default.Encode($"Hello {name}, NumTimes is: {numTimes}");

        }

        public string Ping(string name)
        {
            PingIt p = new PingIt();
            return HtmlEncoder.Default.Encode($"Ping {p.PingItStr("ivisibility.com")}");

        }

    }
}

