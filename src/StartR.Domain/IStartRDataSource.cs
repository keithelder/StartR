using System;
using System.Collections.Generic;
using System.Linq;

namespace StartR.Domain
{
    public interface IStartRDataSource
    {
        IQueryable<Client> Clients { get; }
        IQueryable<Loan> Loans { get; }
        IQueryable<Lead> Leads { get; }
    }
}
