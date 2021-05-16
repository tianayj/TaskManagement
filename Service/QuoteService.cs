using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskManager.DAL;
using TaskManager.Repository;

namespace TaskManager.Service
{
    public class QuoteService : IQuoteService
    {
        private readonly UnitOfWork UoW = new UnitOfWork();

        public IEnumerable<Quote> getQuotes()
        {
            return UoW.QuoteRepository.GetAll();
        }

        public bool Add(Quote q)
        {
            if(!isValidQuote(q))
            {
                return false;
            }
            UoW.QuoteRepository.Insert(q);
            return true;
        }

        public Quote Find(int Id)
        {
            return UoW.QuoteRepository.GetByID(Id);
        }

        public bool Update(Quote q)
        {
            if(q.Id == 0 || UoW.QuoteRepository.GetByID(q.Id) == null) {
                return false;
            } 
            UoW.QuoteRepository.Update(q);
            return true;
        }

        public void Delete(int Id)
        {
            Quote q = UoW.QuoteRepository.GetByID(Id);
            if(q == null)
            {
                return;
            }
            UoW.QuoteRepository.Delete(q);
        }

        private Boolean isValidQuote(Quote q)
        {
            if (q == null || q.QuoteType == null || q.Contact == null || q.Task == null)
            {
                return false;
            }
            return true;
        }
    }
}