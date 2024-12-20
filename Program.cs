using Newtonsoft.Json;
internal class Program
{
    private static async Task Main()
    {
        HttpClient client=new HttpClient();
        client.BaseAddress=new Uri("http://api.openweathermap.org");

        HttpResponseMessage risposta = await client.GetAsync($"/data/2.5/weather?lat=44.261667&lon=12.358889&appid=5925c2e653052a57863fcaf5ac6acd81");//la risposta la da solo quando sara disponibile, rimane in attesa

        var risultato=await risposta.Content.ReadAsStringAsync();


//deserializzazione da jason
        var messaggio= JsonConvert.DeserializeObject<dynamic>(risultato)!;

//estrazione dell'id
        float temperatura =(float)(messaggio!.main.temp - 273.15);

        string cose=messaggio.weather[0].description;

        Console.WriteLine($"temperatura corrente a {messaggio.name}: {temperatura}\r\n descrizione:{cose}");
        
    }
}