using DemoPrep.Domain.Interfaces;
using System;

namespace DemoPrep.Domain.Entities {
    public class Admin : IAuditedEntity<int> {
        public int Id { get; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string Name { get; set; }
    }
}
