using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Repository;

namespace Models
{
    public class Especialidade
    {
        public int Id { set; get; }
        [Required]
        public string Descricao { set; get; }
        public string Detalhamento { set; get; }

        
        public Especialidade() { }
        
        public Especialidade(
            string Descricao,
            string Detalhamento
        )
        {
            this.Id = Id;
            this.Descricao = Descricao;
            this.Detalhamento = Detalhamento;
            Context db = new Context();
            db.Especialidades.Add(this);
            db.SaveChanges();
        }

        public override string ToString()
        {
            return $"Id: {this.Id}"
                + $"\nDescricao: {this.Descricao}"
                + $"\nDetalhamento: {this.Detalhamento}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (!Sala.ReferenceEquals(obj, this))
            {
                return false;
            }
            Especialidade it = (Especialidade)obj;
            return it.Id == this.Id;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static List<Especialidade> GetEspecialidades()
        {
            Context db = new Context();
            return (from Especialidade in db.Especialidades select Especialidade).ToList();
        }

        public static void RemoverEspecialidade(
            Especialidade especialidade
        )
        {
            Context db = new Context();
            db.Especialidades.Remove(especialidade);
        }
    }
}