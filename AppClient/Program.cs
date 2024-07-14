using System.Net.Http.Json;

using HttpClient client = new();

client.BaseAddress = new("http://localhost:5103");

while (true)
{
    Console.Write("Question: ");

    var line = Console.ReadLine();

    await foreach (var msg in client.GetFromJsonAsAsyncEnumerable<string>($"/chat?question={line}"))
    {
        Console.Write(msg);
    }

    Console.WriteLine();
}