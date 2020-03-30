using Infra.Data;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.ViewModels;


namespace firstAPI.Controllers
{
    [EnableCors("http://localhost:4200", "*","*")]
    public class EntryController : ApiController
    {
        UnitOfWork dbu=new UnitOfWork();
        IEntryService _es;
        public EntryController(IEntryService es )
        {
            this._es = es;
           // this._es = EngineContext.Current.Resolve<IEntryService>();
           
        }
        public   IHttpActionResult  GetEntries()
        {
            try
            {
                var entries=_es.GetEntries();
                return Ok(entries);
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
               
                    var entry = _es.GetEntry(id);
                    if (entry == null) return NotFound();
                  
                    return Ok(entry);



                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IHttpActionResult CreateNewEntry([FromBody]EntryViewModel entry)
        {
            try
            {
                if(!ModelState.IsValid) return BadRequest(ModelState);

                    
                        _es.CreateNewEntry(entry);
                        
                        return Ok("New Entry Created");

                    

                

            }
            catch(Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public IHttpActionResult UpdateEntry(int id ,[FromBody]EntryViewModel entry)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
               if (id != entry.entryid) return BadRequest();
                _es.UpdateEntry(entry);
               
                 return Ok("The Entry Is Updated!");
                

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
                
                    _es.DeleteEntry(id);
                 
                    return Ok("The Entry Deleted!");

                

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
            
    } 
}
