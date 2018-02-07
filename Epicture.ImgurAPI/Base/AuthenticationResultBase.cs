using System;
using System.Collections.Generic;
using System.Text;

namespace Epicture.ImgurAPI
{
    public class AuthenticationResultBase
    {
       public AAPIClient APIClient { get; set; }
       public bool Success { get; set; } 
       public string Error { get; set; }
    }
}
