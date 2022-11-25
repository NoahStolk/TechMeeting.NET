#define INLINE

using Sample16.StaticAbstracts.MinimalApi;
#if !INLINE
using Sample16.StaticAbstracts.MinimalApi.Endpoints;
#endif

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<StorageService>();

WebApplication app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

#if INLINE
app.MapGet("store/{key}", (StorageService storage, string key) => storage.GetByKey(key));
app.MapPost("store", (StorageService storage, string key, string value) => storage.Add(key, value));
app.MapPost("store/clear", (StorageService storage) => storage.Clear());
#else
app.MapEndpoint(new GetKeyFromStoreEndpoint());
app.MapEndpoint(new AddKeyToStoreEndpoint());
app.MapEndpoint(new ClearStoreEndpoint());
#endif

app.UseHttpsRedirection();

app.Run();
