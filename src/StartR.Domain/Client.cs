using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace StartR.Domain
{
    public class Client : IEntity
    {
        public virtual int Id { get; set; }
        [Required]
        public virtual string FirstName { get; set; }
        [Required]
        public virtual string LastName { get; set; }
        [Required]
        public virtual string Address1 { get; set; }
        public virtual string Address2 { get; set; }
        [Required]
        public virtual string City { get; set; }
        [Required]
        public virtual string State { get; set; }
        [Required]
        public virtual string Zip { get; set; }
    }
}
