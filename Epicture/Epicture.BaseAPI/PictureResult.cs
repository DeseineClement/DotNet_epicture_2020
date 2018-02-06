using System.Globalization;

namespace Epicture.BaseAPI
{
    public class PictureResult
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Url { get; set; }
    }
}
