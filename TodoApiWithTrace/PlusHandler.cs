using Amazon.Lambda.Core;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]
namespace TodoApiWithTrace
{
    public class PlusHandler
    {
        public PlusResponse Plus(PlusRequest request)
        {
            return new PlusResponse(request.a + request.b);
        }
    }
    public class PlusRequest
    {
        public int a { get; set; }
        public int b { get; set; }
    }

    public class PlusResponse
    {
        public int result { get; set; }
        public PlusResponse(int result)
        {
            this.result = result;
        }

        public PlusResponse()
        {

        }
    }
}