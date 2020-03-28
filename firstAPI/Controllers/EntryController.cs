using Infra.Data;
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
                    return Ok(entries);



                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public IHttpActionResult GetEntry(int id)
        {
            try
            {
                using (var contex = new AppDbContext())
                {
                    var entry = contex.Entries.FirstOrDefault(n => n.EntryId == id);
                    if (entry == null) return NotFound();
                  
                    return Ok(entry);



                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IHttpActionResult CreateNewEntry([FromBody]Entry entry)
        {
            try
            {
                if(!ModelState.IsValid) return BadRequest(ModelState);

                    using (var context = new AppDbContext())
                    {
                        context.Entries.Add(entry);
                        context.SaveChanges();
                        return Ok("New Entry Created");

                    }

                

            }
            catch(Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public IHttpActionResult UpdateEntry(int id ,[FromBody]Entry entry)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
               if (id != entry.EntryId) return BadRequest();
                using (var context=new AppDbContext())
                {
                    var oldEntry=context.Entries.FirstOrDefault(n => n.EntryId == id);
                    if (oldEntry == null)
                        return NotFound();

                    oldEntry.Desc = entry.Desc;
                    oldEntry.IsExpense = entry.IsExpense;
                    oldEntry.value = entry.value;
                    context.SaveChanges();
                    return Ok("The Entry Is Updated!");
                }

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpDelete]
        public IHttpActionResult DeleteEntry(int id)
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    var entry=context.Entries.FirstOrDefault(n => n.EntryId == id);
                    if (entry == null) return NotFound();
                    context.Entries.Remove(entry);
                    context.SaveChanges();
                    return Ok("The Entry Deleted!");

                }

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
            
    } 
}
