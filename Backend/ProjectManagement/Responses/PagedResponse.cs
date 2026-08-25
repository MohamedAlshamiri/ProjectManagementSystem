namespace ProjectManagement.Responses
{
    public class PagedResponse<T>
    {
        public IEnumerable<T> Items { get; set; }
            = Enumerable.Empty<T>();

        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public int TotalCount { get; set; }

        public int TotalPages
        {
            get
            {
                if (PageSize <= 0)
                    return 0;

                return (int)Math.Ceiling(
                    (double)TotalCount / PageSize);
            }
        }

        public bool HasPrevious
        {
            get => PageNumber > 1;
        }

        public bool HasNext
        {
            get => PageNumber < TotalPages;
        }
    }
}
