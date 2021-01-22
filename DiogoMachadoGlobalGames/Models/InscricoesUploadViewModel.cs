namespace DiogoMachadoGlobalGames.Models
{
    using DiogoMachadoGlobalGames.Dados.Entidades;
    using Microsoft.AspNetCore.Http;
    using System.ComponentModel.DataAnnotations;

    public class InscricoesUploadViewModel : Inscricoes
    {
        [Display(Name = "Image")]
        public IFormFile ImageFile { get; set; }

    }
}
