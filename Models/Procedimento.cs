using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Repository;

namespace Models
{
    public class Procedimento
    {
        public int Id { set; get; }
        [Required]
        public string Descricao { set; get; }
        [Required]
        public double Preco { set; get; }
        [Required]
        public int IdAgendamento { set; get; }
        public Agendamento Agendamento { get; }

        public Procedimento(){ }

        public Procedimento(
            string Descricao,
            double Preco,
            int IdAgendamento
        )
        {
            this.Id = Id;
            this.Descricao = Descricao;
            this.Preco = Preco;
            this.IdAgendamento = IdAgendamento;

            this.Agendamento = Agendamento.GetAgendamentos()
                                .Find(Agendamento => Agendamento.Id == IdAgendamento);
            Context db = new Context();
            db.Procedimentos.Add(this);
            db.SaveChanges();
        }

        public override string ToString()
        {
            return $"ID: {this.Id}"
                + $"\nDescricao: {this.Descricao}"
                + $"\nPreco: {this.Preco}"
                + $"\nId do Agendamento: {this.Agendamento.Id}"
                + $"\nData do Agendamento:{this.Agendamento.Data}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (!Procedimento.ReferenceEquals(obj, this))
            {
                return false;
            }
            Procedimento it = (Procedimento)obj;
            return it.Id == this.Id;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static List<Procedimento> GetProcedimentos()
        {
            Context db = new Context();
            return (from Procedimento in db.Procedimentos select Procedimento).ToList();
        }

        public static void RemoverProcedimento(
            Procedimento procedimento
        )
        {
            Context db = new Context();
            db.Procedimentos.Remove(procedimento);
        }
    }
}