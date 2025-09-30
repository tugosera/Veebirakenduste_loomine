namespace Veebirakenduste_loomine.Models
{
    public class Toode
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public bool IsActive { get; set; }

        public Toode(int id, string name, double price, bool isActive)
        {
            Id = id;
            Name = name;
            Price = price;
            IsActive = isActive;
        }
    }

    public class Kasutaja
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        public Kasutaja(int id, string userName, string password, string name, string lastName)
        {
            Id = id;
            UserName = userName;
            Password = password;
            Name = name;
            LastName = lastName;
        }
    }
}
