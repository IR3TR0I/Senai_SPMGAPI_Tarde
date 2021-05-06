using Senai_SPMGAPI_Tarde.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_SPMGAPI_Tarde.Interfaces
{
    interface IConsultaRepository
    {
        List<Consulta> Listar();

        Consulta BuscarPorId(int id);

        void Cadastrar(Consulta novoConsulta);

        void Atualizar(int id, Consulta ConsultaAtualizado);

        void Deletar(int id);

        List<Consulta> Minhas(int idUsuario);

        void AlterStatus(int id, string ConsultaPermissao);

        void Prontuario(int id, Consulta novoPaciente);
        void AlterStatus(int id, object situacao1);
    }
}
