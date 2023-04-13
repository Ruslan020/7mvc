using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace _7mvc.Controllers
{
    public class MyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        // 
        // GET: /HelloWorld/ 
        /*public string Index()
        {
            return "This is my default action...";
        }*/
        // 
        // GET: /HelloWorld/Welcome/ 
        
        public IActionResult TestApi(string number)
        {
            if(number == null)
            {
                Random rnd = new Random();
                number = rnd.Next(0, 100).ToString();
            }
            string interestingFact = getData(number);

            ViewData["Number"] = number;
            ViewData["Message"] = interestingFact;
            return View();
        }

        private string getData(string number)
        {
            string res = "";
            string sURL;
            sURL = "http://numbersapi.com/" + number +"/trivia";

            WebRequest wrGETURL;
            wrGETURL = WebRequest.Create(sURL);

            Stream objStream;
            objStream = wrGETURL.GetResponse().GetResponseStream();

            StreamReader objReader = new StreamReader(objStream);

            string sLine = "";
            int i = 0;

            while (sLine != null)
            {
                i++;
                sLine = objReader.ReadLine();
                if (sLine != null)
                    res += sLine;
            }

            return res;
        }
    }
}
