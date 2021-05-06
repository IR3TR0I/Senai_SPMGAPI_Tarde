using Senai_SPMGAPI_Tarde.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_SPMGAPI_Tarde.Interfaces
{
    interface UsuarioRepository
    {
        List<Usuario> Listar();

        Usuario BuscarPorId(int id);

        void Cadastrar(Usuario novoUsuario);

        void Atualizar(int id, Usuario UsuarioAtualizado);

        void Deletar(int id);

        Usuario Login(string email, string senha);
    }
}
