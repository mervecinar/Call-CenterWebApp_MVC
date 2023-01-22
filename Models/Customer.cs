using System.Xml.Schema;

namespace WebApplication13.Models
{
    public partial class Customer
    {
        public Customer ()
        {
            RequestComplaints = new HashSet<RequestComplaint>();
            Score = new HashSet<Score>();

        }
        public int CustomerId { get; set; }
        public string?FirstName { get; set; }
        public string? LastName { get; set; }
        public string? country { get; set; }
        public string? phone { get; set; }
        public string? age { get; set; }
        public int? point { get; set; }
        public int? CosRepresantativeId { get; set; }
     
        public virtual CosRepresantative? CosRepresantative { get; set; }
        public virtual ICollection<RequestComplaint>? RequestComplaints { get; set; }
        public virtual ICollection<Score>? Score { get; set; }


    }
}
