using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using IdentityModel;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ProAgil.Application.Api.Config
{
    public static class AuthenticationSettings
    {
        public static void RegisterAuthentication(IServiceCollection services, ApplicationSettings config)
        {
            services.AddAuthentication(options => {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddIdentityServerAuthentication(options => //AddJwtBearer(options =>
            {
                options.Authority = config.IdentityServerUrl;
                options.RequireHttpsMetadata = false;
                options.EnableCaching = false;
                //options.Audience = "resourceapi";                
                //options.ApiName = "api1";

                options.JwtBearerEvents = new JwtBearerEvents()// = new JwtBearerEvents() //
                {
                    OnTokenValidated = async ctx => {                        
                        var token = (JwtSecurityToken)ctx.SecurityToken;
                        (ctx.Principal.Identity as ClaimsIdentity).AddClaim(new Claim("token", token.RawData));
                    }
                };
            });

            services.AddAuthorization(options => {
                options.AddPolicy("scopes", builder => {
                    foreach (string scope in config.Scopes)
                    {
                        builder.RequireScope(scope);
                    }
                });
            });        
        }
    }
}