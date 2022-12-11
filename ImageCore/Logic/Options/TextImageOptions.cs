using static ImageCore.Logic.Options.TextImageOptions;

namespace ImageCore.Logic.Options
{
    public abstract class BaseImageOptions
    {
        public enum Keys
        {
            Font,
            Color,
            StartPoint
        }
        public IDictionary<Keys, object> Store { get; private set; } = new Dictionary<Keys, object>();
    }

    public class TextImageOptions: BaseImageOptions
    {

        #region
        public object GetFont => Store[Keys.Font];
        public void SetFont(object font)
        {
            Store.Add(Keys.Font, font);
        }

        public object GetColor => Store[Keys.Color];
        public void SetColor(object color)
        {
            Store.Add(Keys.Color, color);
        }

        public object GetStartPoint => Store[Keys.StartPoint];
        public void SetStartPoint(object startPoint)
        {
            Store.Add(Keys.StartPoint, startPoint);
        }
        #endregion
    }
}
