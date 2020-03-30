using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infra.Data.Repository;
using Infra.Data;

namespace Infra.Data
{
    public class UnitOfWork:IDisposable
    {
        AppDbContext _ctx =new AppDbContext();

        private EntryRepository entryRepository;

        public EntryRepository Entryrepository
        {


            get { return this.entryRepository ?? (this.entryRepository = new EntryRepository(_ctx)); }

            //get
            //{
            //    if (Entryrepository == null)
            //    {
            //        entryRepository = new EntryRepository(db);
            //    }

            //    return Entryrepository;
            //}
        }
        public void Save()
        {
            _ctx.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _ctx.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
