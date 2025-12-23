namespace Gs_Contability.Common.Dto
{
    public class ValidationErrorResponse : ErrorResponse
    {
        public IDictionary<string, string[]>? Errors { get; set; }
    }
}
