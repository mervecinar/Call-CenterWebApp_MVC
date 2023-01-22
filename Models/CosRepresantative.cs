namespace WebApplication13.Models
{
    public partial class CosRepresantative
    {
        public CosRepresantative()
        {
            Customers = new HashSet<Customer>();
            Score = new HashSet<Score>();


        }

        public int CosRepresantativeId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Country { get; set; }
        public int? DepartmentId { get; set; }
        

        public virtual Department? Department { get; set; }
        public virtual ICollection<Customer>? Customers { get; set; }
        public virtual ICollection<Score>? Score { get; set; }



    }
}
