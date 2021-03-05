using System;

namespace WebComputerStore.ViewModel
{
    public class PagingInfo
    {

        /*
         Information to the view about the number of pages available, the current page, and
            the total number of products in the repository.
         */

        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }

        public int TotalPages =>
            (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage);

    }
}
