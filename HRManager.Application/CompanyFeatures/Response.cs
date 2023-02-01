namespace HRManager.Application.CompanyFeatures
{
    public class Response
    {
        public object Result { get; }

        public Response()
        {
        }
        public Response(object result)
        {
            Result = result;
        }
    }
}
