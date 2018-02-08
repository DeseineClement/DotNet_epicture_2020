using System.Collections.Generic;
using System.Globalization;
using Windows.Storage;

namespace Epicture.ImgurAPI
{
    public class PictureResult
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Url { get; set; }
        public string Id { get; set; }
    }

    public class PicturesResult
    {
        public List<PictureResult> Result { get; set; }
        public bool Success { get; set; }
    }

    public class LocalPictureResult : PictureResult
    {
        public StorageFile File { get; set; }
    }
}
