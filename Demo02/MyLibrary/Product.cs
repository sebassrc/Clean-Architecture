namespace MyLibrary
{
    public class Product
    {
        // Field, Campo, variable
        private int Id_Field;

        public int Id
        {
            get { return Id_Field; }
            set { Id_Field = value; }
        }

        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
    }
}
