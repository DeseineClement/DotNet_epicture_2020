using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epicture.ImgurAPI.API.Models;

namespace Epicture.ImgurAPI.API.Responses
{
    class ImageResponse
    {
        public List<Image> data;
        public bool success;
        public int status;
    }
}
