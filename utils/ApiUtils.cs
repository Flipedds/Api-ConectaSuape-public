using Newtonsoft.Json;

namespace Api.utils;

public class ApiUtils
{
    public static string CreateNewToken()
    {
        Random random = new Random();
        int aleatory = random.Next(1, 16);
        DateTime dt = DateTime.Now.AddDays(7);
        string dt_formated = dt.ToString("ddMMyy");
        string token = DateTime.Now.ToString("MMMM") + aleatory + dt_formated;

        return new string(token);
    }

    public static string StringSerializator(string token)
    {
        var tokenObject = new { token };
        return JsonConvert.SerializeObject(tokenObject);;
    }
}
