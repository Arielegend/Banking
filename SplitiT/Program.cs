using SplitiT.Services;
using SplitiT.Services.DataBase;
using SplitiT.Services.DataBase.AddPurchaseHistory;
using SplitiT.Services.EfficientDataStructure;
using SplitiT.Services.JsonValidators;
using SplitiT.Services.Payloads;
using SplitiT.Services.Validators;
using SplitiT.Services.Validators.RequestsValidators;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IPayload1Service, Payload1Service>();
builder.Services.AddTransient<IPayload2Service, Payload2Service>();
builder.Services.AddTransient<IPayload3Service, Payload3Service>();

builder.Services.AddTransient<IPayloadValidatorService, PayloadValidatorService>();
builder.Services.AddTransient<IResponseGenerator, ResponseGenerator>();
builder.Services.AddTransient<IAddPayloadLogRecord, AddPayloadLogRecord>();
builder.Services.AddTransient<IAuthorizeService, AuthorizeService>();
builder.Services.AddTransient<IAddPurchaseHistory, AddPurchaseHistory>();

builder.Services.AddSingleton<IEfficientDataStructureService, EfficientDataStructureService>();

builder.Services.AddTransient<IAddPayloadRequestValidator, AddPayloadRequestValidator>();
builder.Services.AddTransient<IGetPurchasesRequestValidator, GetPurchasesRequestValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
