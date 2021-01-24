using DemoPrep.Domain.Interfaces;
using System;

namespace DemoPrep.Domain.Entities.Implementation {
    public class AuditedEntity<T> : Entity<T>, IAuditedEntity<T> {
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}