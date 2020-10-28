using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OA_Teste_Sozinho.Shared
{
    public class GameDto
    {
        [Required (ErrorMessage = "ID é obrigatório")]
        public int Jogo_ID { get; set; }
        [Required (ErrorMessage = "Nome é obrigatório")]
        public string Jogo_Nome { get; set; }
        public string Genero_ID { get; set; }
        public List<Genero> Generos { get; set; }
    }
}