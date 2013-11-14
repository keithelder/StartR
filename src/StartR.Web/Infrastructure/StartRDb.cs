using StartR.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StartR.Web.Infrastructure
{
    public class StartRDb : DbContext, IStartRDataSource
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Lead> Leads { get; set; }

        public StartRDb() : base("DefaultConnection")
        {
            
        }

        IQueryable<Client> IStartRDataSource.Clients
        {
            get { return Clients; }
        }

        IQueryable<Loan> IStartRDataSource.Loans
        {
            get { return Loans; }
        }

        IQueryable<Lead> IStartRDataSource.Leads
        {
            get { return Leads; }
        }

    }
}