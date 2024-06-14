using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain
{
    [Table("client")]
    public class Client
    {
        [Key]
        [Column(name:"id")]
        public int Id { get; set; }
        [Column(name: "nom")]
        [MaxLength(100)]
        public string? Nom {  get; set; }
        [Column(name: "telephone")]
        public string? Telephone { get; set; }
        [Column(name: "lieu")]
        public string? Lieu {  get; set; }
    }
}
