namespace DemoPrep.Domain.Interfaces {
    public interface IEntity { }
    public interface IEntity<T> : IEntity {
        T Id { get; }
    }
}
