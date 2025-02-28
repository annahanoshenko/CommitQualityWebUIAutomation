namespace CommitQualityWebUIAutomation.Entities
{
    internal class ProductEntity
    {
        public string Username { get; set; }    
        public int Price { get; set; }
        public double DataStocked { get; set; }

        public ProductEntity(string username, int price, double dataStocked) 
        {
            Username = username;
            Price = price;
            DataStocked = dataStocked;
        }
    }
}
