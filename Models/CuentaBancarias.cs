using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace pc2_leonardo.Models
{
    [Table("t_cuentas_bancarias")]
    public class CuentaBancarias
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string? Nombre_Titular { get; set; }
        public string? Tipo_Cuenta { get; set; }
        public Decimal SaldoInicial { get; set; }
        public string? Email { get; set; }
    }
}