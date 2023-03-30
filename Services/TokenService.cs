namespace AirlineCompany.Services
{
    public static class TokenService
    {
        public static string? GetToken(HttpRequest Request)
        {
            if (Request != null)
            {
                string? token = Request.Headers["Authorization"];

                return token.Replace("Bearer", "").Trim();
            }
            return null;
         
        }
    }
}
