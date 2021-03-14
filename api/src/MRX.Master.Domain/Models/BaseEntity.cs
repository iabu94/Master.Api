using System;

namespace MRX.Master.Domain.Models
{
    public abstract class BaseEntity<T> where T : struct
    {
        public virtual T Id { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
