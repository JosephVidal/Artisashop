namespace Backend.Models.ViewModel
{
    public class Search
    {
        public Search(bool searchType, string searchStr)
        {
            SearchType = searchType;
            SearchStr = searchStr;
        }

        public bool SearchType { get; set; }
        public string SearchStr { get; set; }
    }
}
