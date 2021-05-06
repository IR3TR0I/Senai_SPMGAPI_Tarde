using Senai_SPMGAPI_Tarde.Domains;
using Senai_SPMGAPI_Tarde.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Senai_SPMGAPI_Tarde.Contexts;

namespace Senai_SPMGAPI_Tarde.Repositories
{
    public class ClinicaRepository : IClinicaRepository
    {
        SPMGContext ctx = new SPMGContext();

        public void Atualizar(int id, Clinica ClinicaAtualizado)
        {
            Clinica ClinicaBuscada = BuscarPorId(id);

            if (ClinicaAtualizado.Cnpj != null)
            {
                ClinicaBuscada.Cnpj = ClinicaAtualizado.Cnpj;
            }

            if (ClinicaAtualizado.Endereço != null)
            {
                ClinicaBuscada.Endereço = ClinicaAtualizado.Endereço;
            }

            if (ClinicaAtualizado.NomeFantasia != null)
            {
                ClinicaBuscada.NomeFantasia = ClinicaAtualizado.NomeFantasia;
            }

            if (ClinicaAtualizado.RazaoSocial != null)
            {
                ClinicaBuscada.RazaoSocial = ClinicaAtualizado.RazaoSocial;
            }

            ctx.Clinicas.Update(ClinicaBuscada);

            ctx.SaveChanges();
        }

        public Clinica BuscarPorId(int id)
        {
            return ctx.Clinicas.Find(id);
        }

        public void Cadastrar(Clinica novaClinica)
        {
            ctx.Clinicas.Add(novaClinica);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Clinicas.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public List<Clinica> Listar()
        {
            return ctx.Clinicas.ToList();
        }
    }
}
