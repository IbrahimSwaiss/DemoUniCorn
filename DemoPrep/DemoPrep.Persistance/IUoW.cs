using System.Threading.Tasks;

namespace DemoPrep.Persistance {
    public interface IUoW {
        Task CompleteAsync();
    }
}