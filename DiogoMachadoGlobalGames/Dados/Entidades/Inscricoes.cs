using System;
using System.ComponentModel.DataAnnotations;

namespace DiogoMachadoGlobalGames.Dados.Entidades
{
    public class Inscricoes
    {
        public int Id { get; set; }


        public string Nome { get; set; }

        public string Apelido { get; set; }

        public string Morada { get; set; }

        public int CC { get; set; }

        public string Localidade { get; set; }

        [Display(Name = "Data de Nascimento")]
        public DateTime DataNascimento { get; set; }




    }
}
