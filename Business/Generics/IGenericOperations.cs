using System.Threading.Tasks;

namespace Business.Generics
{
    public interface IGenericOperations<T>
    {
        Task<T[]> GetBySearchText(string searchText, int skipItemCount = 0, int maxItemCount = 25);
    }
}