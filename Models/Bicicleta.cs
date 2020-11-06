using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Bike.Models
{
    public class Bicicleta
    {

        [Key]
        public int Id { get; set; }

        [DisplayName("Modelo da bicicleta")]
        public string Modelo { get; set; }

        [DisplayName("Valor da bicicleta")]
        public double Valor { get; set; }

        [DisplayName("Quantidade em estoque da bicicleta")]
        public int QtdEstoque { get; set; }

        [DisplayName("Data de cadastro da bicicleta")]
        public string DataCadastro { get; set; }
    }
}
