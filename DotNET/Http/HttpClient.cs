using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
// 安裝Package: Json.Net
using Newtonsoft.Json.Linq;
using SysAPI.Models;

namespace SysAPI.Controllers
{
    public class AuthAPIController : ApiController
    {
        public IHttpActionResult PostData() {
			HttpClient client = new HttpClient();
			client.BaseAddress = new Uri("DOMAIN_URL");
            client.DefaultRequestHeaders.Add("HEADER","HEADER_VALUE");
			client.DefaultRequestHeaders.Accept.Add(
			   new MediaTypeWithQualityHeaderValue("application/json")
            );
            var parameters = new Parameters();
            parameters.statusCode = 200;
            parameters.data = "Successfully";
            var response = client.PostAsJsonAsync("URI", parameters).Result;
            var contents = JObject.Parse(response.Content.ReadAsStringAsync().Result);

			if (response.IsSuccessStatusCode)
			{
                return Ok(contents);
			}
			else
			{
                return Content(response.StatusCode, contents);
			}
        }
	}
}
