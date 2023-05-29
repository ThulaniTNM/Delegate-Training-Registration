using System.Text.Json;

namespace Delegate_Training_Registration.WebAPI.API_Custom_Extentsions
{
    // standard structure of error response.
    public class ErrorDetail
    {
        public string message { get; set; }
        public string type { get; set; }
        public int code { get; set; }
        public string origin { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
