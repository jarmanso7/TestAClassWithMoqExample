using MockingExample.Library.Models;

namespace MockingExample.Library.Services
{
    public class DatabaseService : IDatabaseService
    {
        public CustomerPutRequest createPutRequest(CustomerRequest request)
        {
            //PSEUDOCODE: Real code for your real service that returns a customerPutRequest

            //For demo purposes
            return new CustomerPutRequest
            {
                Name = request.Name,
            };
        }

        public CustomerPutResponse createPutResponse(CustomerPutRequest putRequest)
        {
            //PSEUDOCODE: Real code for your real service that returns a customerPutResponse

            //For demo purposes
            var response = new CustomerPutResponse();

            if (putRequest.Name.Equals("joe biden", StringComparison.InvariantCultureIgnoreCase))
            {
                response.Data = "The current president of the USA";
            }
            else if (putRequest.Name.Equals("pikachu", StringComparison.InvariantCultureIgnoreCase))
            {
                response.Data = "An adorable pokemon";
            }
            else if (putRequest.Name.Equals("slash", StringComparison.InvariantCultureIgnoreCase))
            {
                response.Data = "Welcome to the jungle!!";
            }
            else
            {
                response.Data = "Unknown customer";
            }

            return response;
        }
    }
}
