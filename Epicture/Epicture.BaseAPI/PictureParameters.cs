namespace Epicture.BaseAPI
{
    public class PictureParameters
    {
        public string Name;
        public string[] Tags { get; set; }
        public int MinWidth { get; set; }
        public int MaxWidth { get; set; }
        public int MinHeight { get; set; }
        public int MaxHeight { get; set; }
    }
}
