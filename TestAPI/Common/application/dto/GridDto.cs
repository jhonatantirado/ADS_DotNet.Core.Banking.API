using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Application.Dto
{
    public class GridDto
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
        public IList Content { get; set; }
        public int TotalPages =>   (int)Math.Ceiling((decimal)(PageSize == 0 ? 0 : TotalRecords / PageSize));
      


    }
}
