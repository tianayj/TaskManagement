using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskManager.DAL;

namespace TaskManager.Repository
{
    public class QuoteRepository : GenericRepository<Quote>
    {
        public QuoteRepository(TaskDBEntities context) : base(context)
        {

        }

        //Requires change if Quote model changes. Honestly should just force user to provide all new information instead of this extreme coupling.
        //Delete this code to enforce that by having the GenericRepository's implementation instead.
        new public void Update(Quote q) 
        {
            Quote oldQuote = GetByID(q.Id);
            if(oldQuote == null)
            {
                return;
            }

            dbSet.Attach(oldQuote);
            if (q.QuoteType != null)
                oldQuote.QuoteType = q.QuoteType;
            if (q.Contact != null)
                oldQuote.Contact = q.Contact;
            if (q.Task != null)
                oldQuote.Task = q.Task;
            if (q.Due != null)
                oldQuote.Due = q.Due;
            if (q.TaskType != null)
                oldQuote.TaskType = q.TaskType;
            context.SaveChanges();
        }

    }
}