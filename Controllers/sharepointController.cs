using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace webServiceForReports.Controllers
{
    public class sharepointController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/spName/paramitters
        public object Get(string spName, string paramitters)
        {
            string[] strArray = paramitters.Split('-');
            object[] parameterValues = new object[strArray.Length];


         
                for (int i = 0; i < strArray.Length; i++)
                {
                    if (strArray[i].ToString().ToUpper() == "NULL")
                    {
                        parameterValues[i] = System.DBNull.Value;
                    }
                    else
                    {
                        int result = 0;
                        if (int.TryParse(strArray[i].ToString(), out result))
                        {
                            parameterValues[i] = result;
                        }
                        else
                        {
                            parameterValues[i] = strArray[i].ToString();
                        }
                    }
                }
                        DataAccessBase base2 = new DataAccessBase();
            return JsonConvert.SerializeObject(base2.ReaderSp(spName, parameterValues));
          
        }

 
    }
}