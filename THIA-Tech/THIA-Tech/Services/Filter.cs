using THIA_Tech.Models;
using THIA_Tech.Services;

namespace THIA_Tech.Service
{
    public class Filter : ISort
    {
        private List<Product> Products;
        private ISort SortType;

        public void Sort(List<Product> Products)
        {
            throw new NotImplementedException();
        }
        public void ChangeSortType(ISort Type)
        {
            SortType = Type;
        }
    }
}
