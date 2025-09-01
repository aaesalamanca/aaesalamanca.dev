using System.Net.Http.Headers;
using Aaesalamanca.RazorPages.Clients;
using Aaesalamanca.RazorPages.Options;
using Aaesalamanca.RazorPages.Services;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOptions<GitHubOptions>().BindConfiguration("GitHub");

builder.Services.AddHttpClient<IGitHubPostsClient, GitHubPostsClient>(
    (serviceProvider, httpClient) =>
    {
        var gitHubOptions = serviceProvider.GetRequiredService<IOptions<GitHubOptions>>().Value;
        httpClient.BaseAddress = new Uri("http://api.github.com");
        httpClient.DefaultRequestHeaders.UserAgent.Add(
            new ProductInfoHeaderValue("aaesalamanca-dev", "1.0")
        );
        httpClient.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/vnd.github+json")
        );
        httpClient.DefaultRequestHeaders.Add("X-GitHub-Api-Version", "2022-11-28");
        if (!string.IsNullOrWhiteSpace(gitHubOptions.Token))
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Bearer",
                gitHubOptions.Token
            );
        }
    }
);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddSingleton<FrontMatterParser>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages().WithStaticAssets();

app.Run();
