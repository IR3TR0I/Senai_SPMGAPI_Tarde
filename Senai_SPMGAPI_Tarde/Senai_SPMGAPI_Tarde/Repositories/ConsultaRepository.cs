using Senai_SPMGAPI_Tarde.Contexts;
using Senai_SPMGAPI_Tarde.Domains;
using Senai_SPMGAPI_Tarde.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_SPMGAPI_Tarde.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {
        SPMGContext ctx = new SPMGContext();
        public void Atualizar(int id, Consulta ConsultaAtualizado)
        {
            Consulta ConsultumBuscado = ctx.Consultas.Find(id);

            if (ConsultaAtualizado.IdMedico != null)
            {
                ConsultumBuscado.IdMedico = ConsultaAtualizado.IdMedico;
            }

            if (ConsultaAtualizado.IdPaciente != null)
            {
                ConsultumBuscado.IdPaciente = ConsultaAtualizado.IdPaciente;
            }

            if (ConsultaAtualizado.IdSituação != null)
            {
                ConsultumBuscado.IdSituação = ConsultaAtualizado.IdSituação;
            }

            if (ConsultaAtualizado.DataConsulta > DateTime.Now)
            {
                ConsultumBuscado.DataConsulta = ConsultaAtualizado.DataConsulta;
            }

#pragma warning disable CS8073 // O resultado da expressão é sempre o mesmo, pois um valor deste tipo nunca é 'null' 
            if (ConsultaAtualizado.HoraConsulta != null)
#pragma warning restore CS8073 // O resultado da expressão é sempre o mesmo, pois um valor deste tipo nunca é 'null' 
            {
                ConsultumBuscado.HoraConsulta = ConsultaAtualizado.HoraConsulta;
            }

            if (ConsultaAtualizado.Descricao != null)
            {
                ConsultumBuscado.Descricao = ConsultumBuscado.Descricao;
            }

            if (ConsultaAtualizado.Descricao == null)
            {
                ConsultumBuscado.Descricao = ConsultumBuscado.Descricao;
            }

            object p = ctx.Consultas.Update(ConsultumBuscado);

            ctx.SaveChanges();
        }

        public Consulta BuscarPorId(int id)
        {
            return ctx.Consultas.FirstOrDefault(tu => tu.IdConsulta == id);
        }

        public void Cadastrar(Consulta novoConsultum)
        {
            ctx.Consultas.Add(novoConsultum);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Consulta ConsultaBuscado = ctx.Consultas.Find(id);

            ctx.Consultas.Remove(ConsultaBuscado);

            ctx.SaveChanges();
        }

        public List<Consulta> Listar() => ctx.Consultas.ToList();

        public List<Consulta> Minhas(int idUsuario)
        {
            return ctx.Consultas

                .Include(p => p.IdMedicoNavigation)

                .Include(p => p.IdPacienteNavigation)

                .Include(p => p.IdSituaçãoNavigation)

                .Where(p => p.IdConsulta == idUsuario)

                .ToList();
        }

        public void AlterStatus(int id, string ConsultumPermissao)
        {
            Consulta ConsultumBuscado = ctx.Consultas

                .Include(p => p.IdMedicoNavigation)

                .Include(p => p.IdPacienteNavigation)

                .Include(p => p.IdSituaçãoNavigation)

                .FirstOrDefault(p => p.IdConsulta == id);

            switch (ConsultumPermissao)
            {
                case "1":
                    ConsultumBuscado.IdSituação = 1;
                    break;

                case "2":
                    ConsultumBuscado.IdSituação = 2;
                    break;

                case "3":
                    ConsultumBuscado.IdSituação = 3;
                    break;

                default:
                    ConsultumBuscado.IdSituação = ConsultumBuscado.IdSituação;
                    break;
            }

            ctx.Consultas.Update(ConsultumBuscado);

            ctx.SaveChanges();
        }

        public void Prontuario(int id, Consulta novoProntuario)
        {
            Consulta ConsultumBuscado = ctx.Consultas.Find(id);

            if (novoProntuario.Descricao != null)
            {
                ConsultumBuscado.Descricao = novoProntuario.Descricao;
            }

            ctx.Consultas.Update(ConsultumBuscado);

            ctx.SaveChanges();
        }

        public void AlterStatus(int id, object situacao1)
        {
            throw new NotImplementedException();
        }
    }
}
