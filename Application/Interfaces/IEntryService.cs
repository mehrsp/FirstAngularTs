
using Application.ViewModels;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IEntryService
    {
        List<EntryViewModel> GetEntries();
        EntryViewModel GetEntry(int id);
        void CreateNewEntry(EntryViewModel entry);
        void UpdateEntry( EntryViewModel entry);
       

        //List<EntryViewModel> Get(Expression<Func<Entry, bool>> predicate);
        void DeleteEntry(int id);
        
    }
}
