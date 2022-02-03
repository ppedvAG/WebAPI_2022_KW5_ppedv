#nullable disable

using ControllerSample.SharedLib;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

Console.WriteLine("Drücken Sie einen Key, wenn der Service verfügbar ist");
Console.ReadKey();

string baseURL = "https://localhost:7169/api/movies/";

HttpClient client = new HttpClient();
//client.SendAsync() ->GET/POST/PUT/DELETE

//client.GetAsync() ->GET
//client.PostAsync() ->POST
//client.PutAsync() -> PUT
//client.DeleteAsync




#region Http call Get-Methode 
//Request wird aufgebaut
//https://localhost:7169/api/movies/
HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, baseURL);
httpRequestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
//Antwort von WebAPI
HttpResponseMessage responseMessage = await client.SendAsync(httpRequestMessage);

string jsonText = await responseMessage.Content.ReadAsStringAsync();


List<Movie> movies = JsonConvert.DeserializeObject<List<Movie>>(jsonText);

foreach(Movie currentMovie in movies)
{
    Console.WriteLine($"{currentMovie.Id} {currentMovie.Title} {currentMovie.Description}");
}
#endregion


#region GetByID -> GetSync
//https://localhost:7169/api/movies/1
string extendedURL = baseURL + 1.ToString();

HttpRequestMessage httpRequest = new HttpRequestMessage(HttpMethod.Get, extendedURL);
httpRequest.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

HttpResponseMessage responseMessage2 = await client.SendAsync(httpRequest);
jsonText = await responseMessage2.Content.ReadAsStringAsync();
Movie movie = JsonConvert.DeserializeObject<Movie>(jsonText);
#endregion


#region Insert a Movie

Movie myMovie = new Movie()
{
    Title = "Free Willy",
    Description = "komische Comedy",
    Price = 19.99m,
    Genre = GenreType.Thriller
};

string movieAsJson = JsonConvert.SerializeObject(myMovie);
StringContent body = new StringContent(movieAsJson, Encoding.UTF8, "application/json");

HttpResponseMessage responseMessage3 = await client.PostAsync(baseURL, body);

Console.WriteLine("Weiter mit PressKey");
Console.ReadLine();
// responseMessage3.Content -> befindet sich der StatusCode -> 201
#endregion
