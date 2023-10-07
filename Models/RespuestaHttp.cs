namespace ApiNetCore7.Models
{
    public class RespuestaHttp
    {
        public Boolean status { get; set; }
        public string message { get; set; }
        public dynamic data { get; set; }

        public RespuestaHttp(Boolean status, string message, dynamic data)
        {
            this.status = status;
            this.message = message;
            this.data = data;
        }
    }
}
