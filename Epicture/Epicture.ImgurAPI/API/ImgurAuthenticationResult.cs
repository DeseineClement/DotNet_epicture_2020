﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Epicture.ImgurAPI.API
{
    public class ImgurAuthenticationResult
    {
        public string access_token { get; set; }
        public int expires_in { get; set; }
        public string token_type { get; set; }
        public object scope { get; set; }
        public string refresh_token { get; set; }
        public int account_id { get; set; }
        public string account_username { get; set; }
    }
}
