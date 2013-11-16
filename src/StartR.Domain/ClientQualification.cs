using System;
using System.Collections.Generic;
using System.Linq;

namespace StartR.Domain
{
    public class ClientQualification : IEntity
    {
        public virtual decimal? QualityRating { get; set; }
        public virtual DateTime? BestCallTime { get; set; }
        public virtual int? PredictiveCreditScore { get; set; }
        public virtual string TodaysMood { get; set; }
    }
}
