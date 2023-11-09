using MockingExample.Library.Models;

namespace MockingExample.Library.Services
{
    public interface IDatabaseService
    {
        public CustomerPutRequest createPutRequest(CustomerRequest request);

        public CustomerPutResponse createPutResponse(CustomerPutRequest putRequest); 
    }
}