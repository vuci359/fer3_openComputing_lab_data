using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using openComputingLab.Data;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
//using Librame.AspNetCore.Authentication.OpenIdConnect;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//veze prema bazi podataka...
builder.Services.AddDbContext <AppDbContext> (o => o.UseNpgsql(builder.Configuration.GetConnectionString("Ef_Postgres_Db")));

//oauth2 openID connect
builder.Services.AddAuthentication(options => {
        
        options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
    })
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options => {
        
        options.Cookie.SameSite = SameSiteMode.Strict;
    })
    .AddOpenIdConnect(options => {

        options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;

        options.Authority = builder.Configuration.GetValue<string>("OpenIdConnect:Issuer");
        options.ClientId = builder.Configuration.GetValue<string>("OpenIdConnect:ClientId");
        options.ClientSecret = builder.Configuration.GetValue<string>("OpenIdConnect:ClientSecret");
        options.ResponseType = OpenIdConnectResponseType.Code;
        options.ResponseMode = OpenIdConnectResponseMode.Query;
        options.GetClaimsFromUserInfoEndpoint = true;

        string scopeString = builder.Configuration.GetValue<string>("OpenIDConnect:Scope");
        scopeString.Split(" ", StringSplitOptions.TrimEntries).ToList().ForEach(scope => {
            options.Scope.Add(scope);
        });

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidIssuer = options.Authority,
            ValidAudience = options.ClientId
        };

        options.Events.OnRedirectToIdentityProviderForSignOut = (context) =>
        {
            context.ProtocolMessage.PostLogoutRedirectUri = builder.Configuration.GetValue<string>("OpenIdConnect:PostLogoutRedirectUri");
            return Task.CompletedTask;
        };

        options.SaveTokens = true;
    });
    builder.Services.AddAuthorization();
    builder.Services.AddRazorPages();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()){
    Console.WriteLine("Development");
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
