using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imaging.Searching
{
    public class SearchingInfo
    {
        public int X { get; set; }
        public int Y { get; set; }
        public decimal D { get; set; }
    }

    interface ISearching
    {
        public IEnumerable<SearchingInfo> Searchings(Bitmap bitmap, Bitmap bitmap1);
    }
}
