using DemoPrep.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DemoPrep.Domain.Entities {
    public class Owner : IAuditedEntity<int> {
        public int Id { get; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public List<Unicorn> Unicorns { get; set; }

        public void SetUnicorns(IEnumerable<Unicorn> unicorns)
        {
            //TODO: validate unicorns
            Unicorns = unicorns.ToList();
        }
    }
}
