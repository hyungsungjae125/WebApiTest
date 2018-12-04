using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiTest.Modules;
using MySql.Data.MySqlClient;
using System.Collections;

namespace WebApiTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<ArrayList> Get()
        {
            MYsql my = new MYsql();
            string sql  = "select * from test;";
            MySqlDataReader sdr = my.Reader(sql);

            ArrayList list = new ArrayList();
            while(sdr.Read()){//행 반복
                Hashtable ht = new Hashtable();
                for(int i=0;i<sdr.FieldCount;i++){
                    
                    ht.Add(sdr.GetName(i),sdr.GetValue(i).ToString());
                }
                list.Add(ht);
            }
            return list;
        }

        
        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

    }
}
