namespace ImageCore.Logic.Options
{
    public class ImageOptions: BaseImageOptions
    {
        public object GetStartPoint => Store[Keys.StartPoint];
        public void SetStartPoint(object startPoint)
        {
            Store.Add(Keys.StartPoint, startPoint);
        }
    }
}
