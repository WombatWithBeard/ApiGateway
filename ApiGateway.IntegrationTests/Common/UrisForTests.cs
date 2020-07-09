namespace ApiGateway.IntegrationTests.Common
{
    public class UriForTests
    {
        public static string GetUri(string name, int id)
        {
            return $"/api/{name}/Get/{id}";
        }
        
        public static string GetAllUri(string name)
        {
            return $"/api/{name}/GetAll";
        }
        
        public static string DeleteUri(string name, int id)
        {
            return $"/api/{name}/Delete/{id}";
        }
        
        public static string CreateUri(string name)
        {
            return $"/api/{name}/Create";
        }
        
        public static string UpdateUri(string name)
        {
            return $"/api/{name}/Update";
        }
    }
}