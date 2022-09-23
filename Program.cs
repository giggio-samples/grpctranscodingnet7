using GrpcTranscodingNet7.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSwaggerGen(c =>
{
    var filePath = Path.Combine(AppContext.BaseDirectory, $"{nameof(GrpcTranscodingNet7)}.xml");
    c.IncludeXmlComments(filePath);
    c.IncludeGrpcXmlComments(filePath, includeControllerXmlComments: true);
});
builder.Services.AddGrpcSwagger();

builder.Services.AddGrpc().AddJsonTranscoding();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.MapGrpcService<GreeterService>();

app.Run();
