using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using ZoomMeeting.Models;
using System.Net.Http.Headers;

namespace ZoomMeeting.Controllers
{
    public class MeetingController : Controller
    {
        // GET: Meeting
        public ActionResult Index()
        {
            return View();
        }

        public String Create(MeetingModel meetingModel)
        {
            CallApi();
            return "You Successfully Scheduled the meeting!";
        }

        

        private void CallApi()
        {
         string URL = "https://api.zoom.us/v1/meeting/create";
         string urlParameters = "api_key=your_api_key&api_secret=your_api_secret&host_id=your_user_host_id&topic=meeting_topic&type=2";
        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri(URL);

        // Add an Accept header for JSON format.
        client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            // List data response.
            HttpResponseMessage response = client.GetAsync(urlParameters).Result;  // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                //// Parse the response body. Blocking!
                //var dataObjects = response.Content.ReadAsAsync<IEnumerable<DataObject>>().Result;
                //foreach (var d in dataObjects)
                //{
                //    Console.WriteLine("{0}", d.Name);
                //}
}
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }
           
    }
}