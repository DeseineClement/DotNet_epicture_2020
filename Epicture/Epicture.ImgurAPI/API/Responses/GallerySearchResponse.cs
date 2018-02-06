using Epicture.ImgurAPI.API.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Epicture.ImgurAPI.API.Responses
{
    public class GallerySearchResponse
    {
        public List<GallerySearch> data;
        public bool success;
        public int status;
    }
}
