using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using Repository;

namespace Models
{
    public class AgendamentoProcedimento
    {
        public int Id { set; get; }
        [Required]
        public int AgendamentoId { set; get; }
        public Agendamento Agendamento { set; get; }
        [Required]
        public int ProcedimentoId { set; get; }
        public Procedimento Procedimento {set; get;}

        public AgendamentoProcedimento(){ }

        public AgendamentoProcedimento(
            int AgendamentoId,
            int ProcedimentoId
        )
        {
            this.Id = Id;
            this.AgendamentoId = AgendamentoId;
            this.ProcedimentoId = ProcedimentoId;
            this.Agendamento = Agendamento.GetAgendamentos().Find(Agendamento => Agendamento.Id == AgendamentoId);
            this.Procedimento = Procedimento.GetProcedimentos().Find(Procedimento => Procedimento.Id == ProcedimentoId);

            Context db = new Context();
            db.AgendamentoProcedimentos.Add(this);
            db.SaveChanges();
        }

        public override string ToString()
        {
            return $"ID: {this.Id}"
                + $"\nId Agendamento: {this.AgendamentoId}"
                + $"\nId Procedimento: { this.ProcedimentoId + "-" + this.Procedimento.Descricao}";
        }

        public static List<AgendamentoProcedimento> GetAgendamentoProcedimentos()
        {
             Context db = new Context();
            return (from AgendamentoProcedimento in db.AgendamentoProcedimentos select AgendamentoProcedimento).ToList();
        }

        public static void RemoverAgendamentoProcedimento(AgendamentoProcedimento agendamentoProcedimento)
        {
            Context db = new Context();
            db.AgendamentoProcedimentos.Remove(agendamentoProcedimento);
        }
    }
}