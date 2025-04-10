using Microsoft.FeatureManagement;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Configuration.AddAzureAppConfiguration(options =>
{
    options.Connect(
        "Endpoint=https://applicationconfig1000.azconfig.io;Id=T1M7;Secret=F1joyQwoV4YqVZw9Mtb1Xc653u3hpjy2y7oWez7CGlW0DxEhm5gLJQQJ99BDACYeBjFKgyCrAAABAZAC418i"
    );
    options.UseFeatureFlags();
});

builder.Services.AddFeatureManagement();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
