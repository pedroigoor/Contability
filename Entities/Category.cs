namespace Gs_Contability.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public Category( string description)
        {
            Description = description;
        }
    }
}
