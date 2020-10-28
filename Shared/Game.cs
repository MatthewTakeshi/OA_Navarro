using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OA_Teste_Sozinho.Shared
{
    public class Game
    {
        [Required (ErrorMessage = "ID é obrigatório")]
        public int ID { get; set; }
        [Required (ErrorMessage = "Nome é obrigatório")]
        public string Jogo_Nome { get; set; }
        public int Genero_ID { get; set; }
        public List<Genero> Generos { get; set; }
    }
}