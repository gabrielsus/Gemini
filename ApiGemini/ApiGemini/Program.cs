using System.Net.Http.Json;

var builder = WebApplication.CreateBuilder(args);

// Aquí invocas la clave
var gcpApiKey = builder.Configuration["GCP:ApiKey"];
var url = "https://generativelanguage.googleapis.com/v1beta/interactions";

using var client = new HttpClient();

// Añadimos el encabezado especial que pide la nueva API
client.DefaultRequestHeaders.Add("x-goog-api-key", gcpApiKey);

var requestBody = new
{
    model = "gemini-3.1-flash-lite",
    input = "Hola, ¿cómo estás?"
};

var response = await client.PostAsJsonAsync(url, requestBody);
var responseContent = await response.Content.ReadAsStringAsync();

Console.WriteLine("Status: " + response.StatusCode);
Console.WriteLine("Respuesta: " + responseContent);