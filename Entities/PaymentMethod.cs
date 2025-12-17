namespace Gs_Contability.Entities
{
    public class PaymentMethod
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public PaymentMethod(string description)
        {
            Description = description;
        }
    }
}
