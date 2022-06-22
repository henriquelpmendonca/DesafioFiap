using GSVServicesAPI.Models;
using GSVServicesAPI.Repositories.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace GSVServicesAPI.Repositories
{
    public class LoginRepository : IRepository<Login>
    {
        private readonly IDapperOperacoes _dapper;
        public LoginRepository(IDapperOperacoes dapper)
        {
            this._dapper = dapper;
        }

        public Task<int> Create(Login Model)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<Login> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Login>> ListAll()
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(Login Model)
        {
            throw new NotImplementedException();
        }


        public async Task<Login> VerficarLogin(Login login)
        {
            var Login = await Task.FromResult(_dapper.Get<Login>($"select * from [Tb_Login] where Usuario = '{login.Usuario.Trim()}' and Senha = '{login.Senha.Trim()}'", null,
            commandType: CommandType.Text));
            return Login;
        }
    }
}
