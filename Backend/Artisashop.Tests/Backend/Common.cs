using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Artisashop.Tests.Backend
{
    public static class Common
    {
        public static void Control(string? msg, HttpResponseMessage response, Type? responseType = null)
        {
            if (responseType == null)
                responseType = typeof(string);
            switch (response.StatusCode)
            {
                case HttpStatusCode.Redirect:
                    Assert.AreEqual(msg, response.Content.ReadFromJsonAsync(responseType).Result!.ToString());
                    break;
                case HttpStatusCode.Unauthorized:
                    Assert.AreEqual(msg, response.Content.ReadFromJsonAsync(responseType).Result!.ToString());
                    break;
                case HttpStatusCode.BadRequest:
                    Assert.AreEqual(msg, response.Content.ReadFromJsonAsync(responseType).Result!.ToString());
                    break;
                case HttpStatusCode.NotFound:
                    Assert.AreEqual(msg, response.Content.ReadFromJsonAsync(responseType).Result!.ToString());
                    break;
                default:
                    throw new KeyNotFoundException("Return type exception");
            };
        }
    }
}
