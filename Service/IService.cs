using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskManager.DAL;
using TaskManager.Repository;

namespace TaskManager.Service
{
    public interface IQuoteService
    {
        IEnumerable<Quote> getQuotes();

        bool Add(Quote q);

        Quote Find(int Id);

        bool Update(Quote q);

        void Delete(int Id);
    }
}