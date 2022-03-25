using System;
using System.Collections.Generic;
using System.Linq;
using Models;
using System.Text.RegularExpressions;

namespace Controllers
{
    public class ProcedimentoController
    {
        public static Procedimento InserirProcedimento(
            string Descricao,
            double Preco,
            int IdAgendamento
        )
        {
            if (String.IsNullOrEmpty(Descricao))
            {
                throw new Exception("Descrição inválida");
            }

            return new Procedimento(Descricao, Preco, IdAgendamento);
        }

        public static Procedimento AlterarProcedimento(
            int Id,
            string Descricao,
            double Preco
        )
        {
            Procedimento procedimento = GetProcedimento(Id);

            if (!String.IsNullOrEmpty(Descricao))
            {
                procedimento.Descricao = Descricao;
            }
            procedimento.Preco = Preco;
            return procedimento;
        }

        public static Procedimento ExcluirProcedimento(
            int Id
        )
        {
            Procedimento procedimento = GetProcedimento(Id);
            Procedimento.RemoverProcedimento(procedimento);
            return procedimento;
        }

        public static List<Procedimento> VisualizarProcedimentos()
        {
            return Procedimento.GetProcedimentos();
        }

        public static Procedimento GetProcedimento(int Id)
        {
            List<Procedimento> procedimentosModels = Models.Procedimento.GetProcedimentos();
            IEnumerable<Procedimento> procedimentos = from Procedimento in procedimentosModels
                                                      where Procedimento.Id == Id
                                                      select Procedimento;
            Procedimento procedimento = procedimentos.First();

            return procedimento;
        }
    }
}