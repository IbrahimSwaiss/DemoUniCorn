using DemoPrep.Domain.Interfaces;

namespace DemoPrep.Domain.Entities.Implementation {
    public class Entity<T> : IEntity<T> {
        public T Id { get; protected set; }
    }
}
