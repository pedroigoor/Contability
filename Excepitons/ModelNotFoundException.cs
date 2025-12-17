namespace Gs_Contability.Excepitons
{
    public class ModelNotFoundException : Exception
    {
        public ModelNotFoundException(string? message = "Recurso não encontrato") : base(message)
        { }
    }
}
