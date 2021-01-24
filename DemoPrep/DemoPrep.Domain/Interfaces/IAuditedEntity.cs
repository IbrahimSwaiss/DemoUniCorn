using System;

namespace DemoPrep.Domain.Interfaces
{
    public interface IAuditedEntity<T> : IEntity<T>, IAuditedEntity { }

    public interface IAuditedEntity : IEntity {
        string CreatedBy { get; set; }
        DateTime CreatedOn { get; set; }
        string ModifiedBy { get; set; }
        DateTime? ModifiedOn { get; set; }
    }
}