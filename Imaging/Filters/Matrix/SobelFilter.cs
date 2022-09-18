namespace Imaging.Filters.Matrix
{
    public class SobelFilter: MatrixFilter
    {
        private static double[,] _filter = new double[3, 3]
        {
            { -1, 0, 1 },
            { -2, 0, 2 },
            { -1, 0, 1 },
        };

        public SobelFilter() : base(_filter, 4)
        {
        }
    }
}
