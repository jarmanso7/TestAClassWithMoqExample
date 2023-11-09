using MockingExample.Library.Models;

namespace MockingExample.Library.Services
{
    public class TransactionService
    {
        private readonly IDatabaseService _databaseService;

        public TransactionService(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public CustomerPutResponse CustomerCareResult(CustomerRequest request)
        {
            var apiRequestObj = ApiCreateRequestObj(request);

            var apiResponseObj = ApiCreateResponseObj(apiRequestObj);
            
            return apiResponseObj;
        }

        private CustomerPutRequest ApiCreateRequestObj(CustomerRequest req)
        {
            return _databaseService.createPutRequest(req);
        }

        private CustomerPutResponse ApiCreateResponseObj(CustomerPutRequest resp)
        {
            return _databaseService.createPutResponse(resp);
        }
    }
}