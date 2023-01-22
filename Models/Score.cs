using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WebApplication13.Models
{
    public partial class Score
    {

        [Key]
        public int CosRepresantativeId { get; set; }
        public String? Name { get; set; }
        public int? totalScore { get; set;}

        public virtual Customer? Customer { get; set; }
        public virtual CosRepresantative? CosRepresantative { get; set; }


    }
}
