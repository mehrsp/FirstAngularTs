﻿using Infra.Data;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Threading.Tasks;

namespace firstAPI.Controllers
{
    [EnableCors("http://localhost:4200", "*","*")]
    public class EntryController : ApiController
    {
        public   IHttpActionResult  GetEntries()
        {
            try
            {
                using (var contex = new AppDbContext())
                {
                    var entries = contex.Entries.ToList();
                    return Ok();



                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    } 
}
