namespace SmtWallet.Web.Data.Entities
{
    public class Customer: BaseEntity<Guid>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public GenderEnum Gender { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public bool Active { get; set; }
    }
}
