using Google.Protobuf.WellKnownTypes;
using THIA_Tech.Models;

namespace THIA_Tech.Services
{
    public class FilterMediator
    {
        private FilterBuilder _filterBuilder;

        public void Setup(int max, int min)
        {

        }
        public List<Product> giveFiltered()
        {
            return new List<Product>();
        }
    }
}
