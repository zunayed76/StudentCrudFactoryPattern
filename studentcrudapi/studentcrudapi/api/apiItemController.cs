using Newtonsoft.Json;
using studentcrudapi.Factories;
using studentcrudapi.Interfaces;
using studentcrudapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace studentcrudapi.api
{
    [RoutePrefix("api")]
    public class apiItemController : ApiController
    {
        private iItemUnit objUnit = null;
        public apiItemController()
        {
            objUnit = new ItemUnit();
        }

        [HttpPost]
        public HttpResponseMessage temp(object[] data)
        {
            string result = "";
            try
            {
                Item cmnParam = JsonConvert.DeserializeObject<Item>(data[0].ToString());

                if (cmnParam != null)
                {
                    result = objUnit.saveItemUnit(cmnParam);
                }
                else
                {
                    result = "";
                }
            }
            catch (Exception e)
            {
                e.ToString();
                result = "";
            }
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        //[HttpPost]
        //public HttpResponseMessage delet(object[] data)
        //{
        //    string result = "";
        //    try
        //    {
        //        Item cmnParam = JsonConvert.DeserializeObject<Item>(data[0].ToString());

        //        if (cmnParam != null)
        //        {
        //            result = objUnit.delItemUnit(cmnParam);
        //        }
        //        else
        //        {
        //            result = "";
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        e.ToString();
        //        result = "";
        //    }
        //    return Request.CreateResponse(HttpStatusCode.OK, result);
        //}



        [HttpGet]
        public List<Item> GetAllData()
        {
            List<Item> lst = new List<Item>();
            lst = objUnit.GetItem();
            return lst;
        }
    }
}
