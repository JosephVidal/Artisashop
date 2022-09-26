namespace Artichaut.Models.ViewModel
{
    public class SearchViewModel
    {
        public SearchViewModel(bool searchType, string searchStr)
        {
            SearchType = searchType;
            SearchStr = searchStr;
        }

        public bool SearchType { get; set; }
        public string SearchStr { get; set; }
    }
}
