namespace Imaging.Filters.Matrix
{
    public class PrewittFilter: MatrixFilter
    {
        private static double[,] _filter = new double[3, 3]
        {
            { 1, 0, -1 },
            { 1, 0, -1 },
            { 1, 0, -1 },
        };

        public PrewittFilter() : base(_filter, 3)
        {
        }
    }
}
