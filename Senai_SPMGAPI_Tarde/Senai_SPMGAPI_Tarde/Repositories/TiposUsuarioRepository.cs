using Microsoft.EntityFrameworkCore;
using Senai_SPMGAPI_Tarde.Contexts;
using Senai_SPMGAPI_Tarde.Domains;
using Senai_SPMGAPI_Tarde.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_SPMGAPI_Tarde.Repositories
{
    public class TiposUsuarioRepository : IConsultaRepository
    {
        SPMGContext ctx = new SPMGContext();
        public void Atualizar(int id, Consulta ConsultumAtualizado)
        {
            Consulta ConsultumBuscado = ctx.Consultas.Find(id);

            if (ConsultumAtualizado.IdMedico != null)
            {
                ConsultumBuscado.IdMedico = ConsultumAtualizado.IdMedico;
            }

            if (ConsultumAtualizado.IdPaciente != null)
            {
                ConsultumBuscado.IdPaciente = ConsultumAtualizado.IdPaciente;
            }

            if (ConsultumAtualizado.IdSituação != null)
            {
                ConsultumBuscado.IdSituação = ConsultumAtualizado.IdSituação;
            }

            if (ConsultumAtualizado.DataConsulta > DateTime.Now)
            {
                ConsultumBuscado.DataConsulta = ConsultumAtualizado.DataConsulta;
            }

#pragma warning disable CS8073 // O resultado da expressão é sempre o mesmo, pois um valor deste tipo nunca é 'null' 
            if (ConsultumAtualizado.HoraConsulta != null)
#pragma warning restore CS8073 // O resultado da expressão é sempre o mesmo, pois um valor deste tipo nunca é 'null' 
            {
                ConsultumBuscado.HoraConsulta = ConsultumAtualizado.HoraConsulta;
            }

            if (ConsultumAtualizado.Descricao != null)
            {
                ConsultumBuscado.Descricao = ConsultumBuscado.Descricao;
            }

            if (ConsultumAtualizado.Descricao == null)
            {
                ConsultumBuscado.Descricao = ConsultumBuscado.Descricao;
            }

            ctx.Consultas.Update(ConsultumBuscado);

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
            Consulta ConsultumBuscado = ctx.Consultas.Find(id);

            ctx.Consultas.Remove(ConsultumBuscado);

            ctx.SaveChanges();
        }

        public List<Consulta> Listar()
        {
            return ctx.Consultas.ToList();
        }

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
