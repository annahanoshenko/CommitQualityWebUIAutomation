namespace CommitQualityWebUIAutomation.Entities
{
    public class ProductEntity
    {
        public string ProductName { get; set; }    
        public string ProductPrice { get; set; }
        public string DateStocked { get; set; }

        public ProductEntity(string username, string price, string dataStocked) 
        {
            ProductName = username;
            ProductPrice = price;
            DateStocked = dataStocked;
        }
    }
}
