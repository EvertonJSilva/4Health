using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using Microsoft.IdentityModel.Tokens;
using FourHealth.MVC.Util;
using FourHealth.AppServices.DTOs;
using FourHealth.AppServices.Interfaces;
using System.Collections.Generic;

namespace FourHealth.MVC.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private readonly IUsuarioAppService appService;

        public LoginController(IUsuarioAppService appService)
        {
            this.appService = appService;
        }


        [AllowAnonymous]
        [HttpPost]
        public Token getToken(
            [FromBody]UsuarioDTO usuario,
            [FromServices]SigningConfigurations signingConfigurations,
            [FromServices]TokenConfigurations tokenConfigurations)
        {
            Token tokenRetorno;

            bool credenciaisValidas = false;
            if (usuario != null && !String.IsNullOrWhiteSpace(usuario.UserID))
            {
                var usuarioBase = appService.Find(usuario.UserID);
                credenciaisValidas = (usuarioBase != null &&
                    usuario.UserID == usuarioBase.UserID &&
                    usuario.AccessKey == usuarioBase.AccessKey);
            }

            if (credenciaisValidas)
            {
                ClaimsIdentity identity = new ClaimsIdentity(
                    new GenericIdentity(usuario.UserID, "Login"),
                    new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim(JwtRegisteredClaimNames.UniqueName, usuario.UserID)
                    }
                );

                DateTime dataCriacao = DateTime.Now;
                DateTime dataExpiracao = dataCriacao +
                    TimeSpan.FromSeconds(tokenConfigurations.Seconds);

                var handler = new JwtSecurityTokenHandler();
                var securityToken = handler.CreateToken(new SecurityTokenDescriptor
                {
                    Issuer = tokenConfigurations.Issuer,
                    Audience = tokenConfigurations.Audience,
                    SigningCredentials = signingConfigurations.SigningCredentials,
                    Subject = identity,
                    NotBefore = dataCriacao,
                    Expires = dataExpiracao
                });
                var token = handler.WriteToken(securityToken);

                tokenRetorno = new Token
                    (
                        true,
                        dataCriacao.ToString("yyyy-MM-dd HH:mm:ss"),
                        dataExpiracao.ToString("yyyy-MM-dd HH:mm:ss"),
                        token,
                        "OK"
                    );

            }
            else
            {
                tokenRetorno = new Token
                (
                   false,
                   "",
                   "",
                   "",
                   "Falha ao autenticar"
                );
            }

        var lista = new List<Token>();
        lista.Add(tokenRetorno);
        return tokenRetorno;
        }


    public class Token{
            public Boolean authenticated { get; set; }
            public String created { get; set; }
            public String expiration { get; set; }
        public String accessToken { get; set; }
            public String message { get; set; }

         public Token(Boolean authenticated,
                        String created,
                        String expiration,
                        String accessToken,
                        String message)
          {
                this.authenticated = authenticated;
                this.created = created;
                this.expiration = expiration;
                this.accessToken = accessToken;
                this.message = message;

            }
        }

    }
}