using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DAL;

namespace TaskManager.Repository
{
    public class UnitOfWork : IDisposable
    {
        private TaskDBEntities context = new TaskDBEntities();
        private QuoteRepository quoteRepository;

        public QuoteRepository QuoteRepository
        {
            get
            {

                if (this.quoteRepository == null)
                {
                    this.quoteRepository = new QuoteRepository(context);
                }
                return quoteRepository;
            }

        }

        //public GenericRepository<Quote> QuoteRepository
        //{
        //    get
        //    {

        //        if (this.quoteRepository == null)
        //        {
        //            this.quoteRepository = new GenericRepository<Quote>(context);
        //        }
        //        return quoteRepository;
        //    }

        //}

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
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
