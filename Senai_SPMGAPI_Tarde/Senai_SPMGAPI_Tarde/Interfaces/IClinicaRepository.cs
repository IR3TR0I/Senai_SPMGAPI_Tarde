using Senai_SPMGAPI_Tarde.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_SPMGAPI_Tarde.Interfaces
{
    interface IClinicaRepository
    {
        List<Clinica> Listar();

        Clinica BuscarPorId(int id);

        void Cadastrar(Clinica novaClinica);

        void Atualizar(int id, Clinica ClinicaAtualizado);

        void Deletar(int id);
    }
}
