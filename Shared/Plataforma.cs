using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OA_Teste_Sozinho.Shared
{
    public class Plataforma
    {
        [Required (ErrorMessage = "ID de Plataforma é obrigatório")]
        public int ID { get; set; }
        [Required (ErrorMessage = "Nome da Plataforma é obrigatório")]
        public string Plataforma_Nome { get; set; }
    }
}