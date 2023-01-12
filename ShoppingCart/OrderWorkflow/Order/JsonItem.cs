namespace ShoppingCart
{
public class JsonItem
    {
        public int quantity{get;set;}
        public string name{get; set;}
        
    }
public class Root
{
    public List<JsonItem> listOfStockInfo {get ; set;}
}
}