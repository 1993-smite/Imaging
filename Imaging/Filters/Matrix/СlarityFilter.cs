using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imaging.Filters.Matrix
{
    public class ClarityFilter : MatrixFilter
    {
        private static double[,] _filter = new double[3, 3]
        {
            { -1,-1,-1 },
            { -1, 9,-1 },
            { -1,-1,-1 },
        };

        public ClarityFilter() : base(_filter)
        {
        }
    }
}
