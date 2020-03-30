using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
   public interface IEntryRepository
    {
        List<Entry> GetEntries();
        Entry GetEntry(int id);
        void CreateNewEntry(Entry entry);
        void UpdateEntry( Entry entry);

        List<Entry> Get(Expression<Func<Entry, bool>> predicate, Func<IQueryable<Entry>, IOrderedQueryable<Entry>> orderby,string includes);
        void DeleteEntry(int id);
    
    }
}
