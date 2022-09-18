using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imaging.Filters.Matrix
{
    public class ErosianFilter : MatrixFilter
    {
        private static double[,] _filter = new double[5, 5]
        {
            { 0,0,1,0,0 },
            { 0,1,1,1,0 },
            { 1,1,1,1,1 },
            { 0,1,1,1,0 },
            { 0,0,1,0,0 }
        };

        public ErosianFilter() : base(_filter, (int)_filter.LongLength)
        {
        }
    }
}
