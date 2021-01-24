using System;
using System.Collections.Generic;
using System.Text;

namespace DemoPrep.Infrastructure.Dtos {
    public class OwnerOutput {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<UnicornList> Unicorns { get; set; }
    }
}
