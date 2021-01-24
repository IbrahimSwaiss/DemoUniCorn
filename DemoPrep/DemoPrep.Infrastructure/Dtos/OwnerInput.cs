using System;
using System.Collections.Generic;

namespace DemoPrep.Infrastructure.Dtos
{
    public class OwnerInput {
        public int Id { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class ManageUnicornInput
    {
        public int OwnerId { get; set; }
        public List<int> UnicornIds { get; set; }
    }
}