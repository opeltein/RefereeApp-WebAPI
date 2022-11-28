namespace RefereeApp.Utils;



public static class HttpContextExtensions
{
    public static string GetUserId(this HttpContext self)
    {
        var authUser = self.User;
        //TODO: Walnąć wyjątkiem jeśli null
        return authUser.Claims.FirstOrDefault(claim => claim.Type == "UserID").Value ?? string.Empty;
    }
}

