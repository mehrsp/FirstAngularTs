using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using System.Data.Entity;


namespace Infra.Data.Repository
{
    public class EntryRepository : IEntryRepository
    {

        private AppDbContext _adc;
        private DbSet<Entry> _db;
      
        public EntryRepository(AppDbContext adc)
        {
            this._adc = adc;
            this._db = adc.Set<Entry>();
        }
        public virtual void CreateNewEntry(Entry entry)
        {
            //context.BehIndicator.Add(behindicator);

            _db.Add(entry);
        }

        public virtual void DeleteEntry(int id)
        {

            //context.BehIndicator.Remove(behindicator);

            var entry = GetEntry(id);
            _db.Remove(entry);
            //_adc.Entry(entry).State = EntityState.Deleted; ;

        }

        public virtual List<Entry> GetEntries()
        {
            //return context.BehIndicator.Include(a => a.behObjective).ToList();

           // return context.BehIndicator.Include(a => a.behObjective).Where(predicate).ToList();

            return _db.ToList();
        }
        public virtual List<Entry> Get(System.Linq.Expressions.Expression<Func<Entry, bool>> predicate=null,Func<IQueryable<Entry>,IOrderedQueryable<Entry>> orderby=null,string includes="")
        {

            IQueryable<Entry> query = _db;

            if(predicate!=null)
            {
                query = query.Where(predicate);
            }
            if(orderby!=null)
            {
                query = orderby(query);
            }
            if(includes!="")
            {
                foreach(string include in includes.Split(','))
                {
                    query = query.Include(include);
                }
            }
            return query.ToList();
            //return _db.Where(predicate).ToList();
        }
        public virtual Entry GetEntry(int id)
        {



            // return context.BehIndicator.Find(behindicatorId);

            return _db.Find(id);
            //Entry entry =_adc.Entries.FirstOrDefault(n => n.EntryId == id);
            // return entry;
        }

      
        public virtual void UpdateEntry( Entry entry)
        {
            //_adc.Entry(entry).State = EntityState.Modified;
            
        }


        //public List<Indicator> Get(Expression<Func<Indicator, bool>> predicate)
        //{
        //    return context.Indicators.Include(a => a.objective).Include(a => a.ConfirmBy).Include(a => a.ConfirmBy.person).Where(predicate).ToList();
        //}
    }
}
