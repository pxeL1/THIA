namespace THIA_Tech.Services
{
    public interface IFilterBuilder
    {
        public void Reset();
        public void AddPriceRange(int min, int max);
        public void AddWantedModel(string model);
        public void AddWantedManufacturer(string manufacturer);
        public void AddAlphabetical(bool sortAlpha);
        public void AddSortOrder(string sortOrder);
    }
}
