using System.Collections;

namespace BHB.Common.API
{
    public class PagedApiResponse<TList> : ApiResponse<TList> where TList : IEnumerable
    {
        public int Page { get; set; }
        public int NumPerPage { get; set; }
        public int TotalPages { get; set; }
    }
}