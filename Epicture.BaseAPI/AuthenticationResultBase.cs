namespace Epicture.BaseAPI
{
    public class AuthenticationResultBase
    {
       public AAPIClient APIClient { get; set; }
       public bool Success { get; set; } 
       public string Error { get; set; }
    }
}
