using System;
using System.Collections.Generic;
using System.Linq;
using Models;
using System.Text.RegularExpressions;

namespace Controllers
{
    public class EspecialidadeController
    {
        public static Especialidade InserirEspecialidade(
            string Descricao,
            string Detalhamento
        )
        {
            if (String.IsNullOrEmpty(Descricao))
            {
                throw new Exception("Descrição inválida");
            }
            if (String.IsNullOrEmpty(Detalhamento))
            {
                throw new Exception("Detalhamento inválido");
            }
            return new Especialidade(Descricao, Detalhamento);
        }

        public static Especialidade AlterarEspecialidade(
            int Id,
            string Descricao,
            string Detalhamento
        )
        {
            Especialidade especialidade = GetEspecialidade(Id);

            if (!String.IsNullOrEmpty(Descricao))
            {
                especialidade.Descricao = Descricao;
            }

            if (!String.IsNullOrEmpty(Detalhamento))
            {
                especialidade.Detalhamento = Detalhamento;
            }
            return especialidade;
        }

        public static Especialidade ExcluirEspecialidade(
            int Id
        )
        {
            Especialidade especialidade = GetEspecialidade(Id);
            Especialidade.RemoverEspecialidade(especialidade);
            return especialidade;
        }

        public static List<Especialidade> VisualizarEspecialidades()
        {
            return Especialidade.GetEspecialidades();
        }

        public static Especialidade GetEspecialidade(int Id)
        {
            List<Especialidade> especialidadesModels = Models.Especialidade.GetEspecialidades();
            IEnumerable<Especialidade> especialidades = from Especialidade in especialidadesModels
                            where Especialidade.Id == Id
                            select Especialidade;
            Especialidade especialidade = especialidades.First();
            
            if (especialidade == null)
            {
                throw new Exception("Especialidade não encontrada");
            }

            return especialidade;
        }
    }
}