using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OA_Teste_Sozinho.Shared
{
    public class Genero
    {
        [Required (ErrorMessage = "ID de Genero é obrigatório")]
        public int ID { get; set; }
        [Required (ErrorMessage = "Nome do Genero é obrigatório")]
        public string Genero_Nome { get; set; }
        public int Jogo_ID { get; set; }
        public Game Jogos { get; set; }
    }
}