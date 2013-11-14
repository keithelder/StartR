using System;
using System.Collections.Generic;
using System.Linq;

namespace StartR.Domain
{
    public class Loan : IEntity
    {
        public int Id { get; set; }
        public decimal? Amount { get; set; }
        public decimal? Ltv { get; set; }
        public decimal? InterestRate { get; set; }
        public bool? Approved { get; set; }
    }
}
