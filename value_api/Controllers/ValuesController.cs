using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace value_api.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private static Dictionary<int, string> valuesDic;

        static ValuesController()
        {
            var dic = new Dictionary<int, string>();
            dic[1] = "value1";
            dic[2] = "value2";
            dic[3] = "value3";
            dic[4] = "value4";
            dic[5] = "value5";

            valuesDic = dic;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return valuesDic.Values;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            if (valuesDic.TryGetValue(id, out string value))
            {
                return value;
            }

            return "not found";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
            int id = valuesDic.Count + 1;
            valuesDic[id] = value;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
            if (valuesDic.ContainsKey(id))
            {
                valuesDic[id] = value;
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            valuesDic.Remove(id);
        }
    }
}
