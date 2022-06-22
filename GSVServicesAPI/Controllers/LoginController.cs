using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GSVServicesAPI.Models;
using GSVServicesAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GSVServicesAPI.Controllers
{
    [Route("Login")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        [HttpPost]
        [Route("AutenticarUsuario")]
        public async Task<Response> Post([FromServices] LoginRepository repo, [FromBody] Login login)
        {
            var retorno = await repo.VerficarLogin(login);
            
            if (retorno != null)
            {
                return new Response()
                {
                    Mensagem = "Login concluido com sucesso!",
                    StatusRequest = true,
                    objeto = retorno
                };
            }
            else
            {
                return new Response()
                {
                    Mensagem = "Login Inválido!",
                    StatusRequest = false,
                    objeto = retorno
                };
            }

        }

    }
}