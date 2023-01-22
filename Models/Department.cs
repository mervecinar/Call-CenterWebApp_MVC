namespace WebApplication13.Models
{
    public partial class Department
    {
        public Department()
        {
            CosRepresantatives = new HashSet<CosRepresantative>();
        }

        public int DepartmentId { get; set; }
        public string? DepartmentName { get; set; }

        public virtual ICollection<CosRepresantative>? CosRepresantatives { get; set; }

    }
}
