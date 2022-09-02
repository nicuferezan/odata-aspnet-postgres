using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using ODataAPI.Entities;

static IEdmModel GetEdmModel()
{
    var builder = new ODataConventionModelBuilder();
    builder.EntitySet<Activity>("Activity");
    return builder.GetEdmModel();
}

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRouting();
builder.Services.AddDbContext<ODataAPI.EntityFramework.ActivityAppContext>(
    options => options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreConnection"))
);

builder.Services.AddControllers().AddOData(opt => opt.AddRouteComponents("v1",
    GetEdmModel()).Filter().Select().Expand()
);

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "ODataAPI", Version = "v1" });
});
builder.Services.AddMvc(option => option.EnableEndpointRouting = false);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseAuthorization();

app.MapControllers();

app.UseHttpsRedirection();

app.Run();
