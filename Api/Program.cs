using Microsoft.SemanticKernel;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddKernel().AddOpenAIChatCompletion("gpt-4", builder.Configuration["OpenAikey"]);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/chat", (string question, Kernel kernel) =>
{
    return kernel.InvokePromptStreamingAsync<string>(question);
});

app.Run();