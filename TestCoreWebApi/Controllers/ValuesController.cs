using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IBM.Data.DB2.Core;

namespace TestCoreWebApi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var values = new List<string>();
            string connectionString = "Server=10.1.1.1:446;Database=ESCTEST;UID=USER;PWD=p1234567;";
            string mySelectQuery = "SELECT * FROM SHARLIB.DCPF66";
            var myConnection = new DB2Connection(connectionString);
            DB2Command myCommand = new DB2Command(mySelectQuery, myConnection);
            try
            {
                myConnection.Open();
                DB2DataReader myReader;
                myReader = myCommand.ExecuteReader();
                // Always call Read before accessing data.
                while (myReader.Read())
                {
                   values.Add(myReader.GetString(0));
                }
                // always call Close when done reading.
                myReader.Close();
            }
            catch (Exception ex)
            {
                values = new List<string>();
                values.Add(ex.Message);
                throw;
            }
            finally
            {
                // Close the connection when done with it.
                myConnection.Close();
            }

            return values.ToArray();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
