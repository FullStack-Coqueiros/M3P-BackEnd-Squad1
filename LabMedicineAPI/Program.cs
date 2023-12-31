using LabMedicineAPI.Infra;
using LabMedicineAPI.Repositories;
using LabMedicineAPI.Service.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using LabMedicineAPI.Service.Consulta;
using LabMedicineAPI.Service.Dieta;
using LabMedicineAPI.Service.Endereco;
using LabMedicineAPI.Service.Exame;
using LabMedicineAPI.Service.Exercicio;
using LabMedicineAPI.Service.Medicamento;
using LabMedicineAPI.Service.Paciente;
using LabMedicineAPI.Service.Usuario;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "LabMedicine", Version = "v1" });
    //Adi��o do header de autentica��o no Swagger 
    c.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme. 
                                              Escreva 'Bearer' [espa�o] e o token gerado no login na caixa abaixo.
                                              Exemplo: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                                          {
                                            {
                                              new OpenApiSecurityScheme
                                              {
                                                Reference = new OpenApiReference
                                                  {
                                                    Type = ReferenceType.SecurityScheme,
                                                    Id = JwtBearerDefaults.AuthenticationScheme
                                                  },
                                                },
                                                new List<string>()
                                              }
                                            });
});


builder.Services.AddTransient<ILoginService, LoginService>();

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;
builder.Services.AddDbContext<LabMedicineDbContext>(o => o.UseSqlServer(connectionString));
var options = new JsonSerializerOptions
{
    ReferenceHandler = ReferenceHandler.Preserve,
};
builder.Services.AddControllers(options =>
{
    options.ModelMetadataDetailsProviders.Add(new SystemTextJsonValidationMetadataProvider());
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("StatusSistemaAtivo", policy =>
    {
        policy.RequireClaim("StatusSistema", "true");
    });
});

builder.Services.AddRouting(options =>
{
    options.LowercaseUrls = true;
    options.LowercaseQueryStrings = true;
});

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IPacienteServices, PacienteServices>();
builder.Services.AddScoped<IUsuarioServices, UsuarioServices>();
builder.Services.AddScoped<IMedicamentoServices, MedicamentoServices>();
builder.Services.AddScoped<IConsultaServices, ConsultaServices>();
builder.Services.AddScoped<IDietaServices, DietaServices>();
builder.Services.AddScoped<IEnderecoServices, EnderecoServices>();
builder.Services.AddScoped<IExameServices, ExameServices>();
builder.Services.AddScoped<IExercicioServices, ExercicioServices>();

//ConfigurationMapper
builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "auth v1"));
}

app.UseHttpsRedirection();

app.UseCors(p =>
{
    p.AllowAnyOrigin();
    p.AllowAnyHeader();
    p.AllowAnyMethod();
});

app.UseAuthentication();
app.UseAuthorization();

app.UseAuthorization();

app.MapControllers();

app.Run();
