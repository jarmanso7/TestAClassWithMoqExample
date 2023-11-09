using MockingExample.Library.Models;
using MockingExample.Library.Services;
using Moq;
using Xunit;

namespace MockingExample.Tests
{
    public class TransactionServiceTests
    {
        [Fact]
        public void CustomerCareResult_UponCalled_ReturnsExpectedResponse()
        {
            // Arrange (instantiate input parameters, mocks and the object to test (sut))
            var customerRequest = new CustomerRequest
            {
                Name = "Joe Biden",
                Address = "White House",
                City = "Washington DC",
                State = "Columbia",
                AccountNumber = "666"
            };

            //Create the mock for the external service we don't really want to call
            var dataServiceMock = new Mock<IDatabaseService>();

            //Set up the mock to behave as we would expect the real class to behave when calling its methods.
            //In this case, to return the expected value whenever the external IDatabaseService.createPutRequest is called
            dataServiceMock .Setup(m => m.createPutRequest(It.IsAny<CustomerRequest>()))
                            .Returns(new CustomerPutRequest
                            {
                                Name = "Joe Biden",
                                Address = "White House",
                                City = "Washington DC",
                                State = "Columbia"
                            });

            dataServiceMock.Setup(m => m.createPutResponse(It.IsAny<CustomerPutRequest>()))
                            .Returns(new CustomerPutResponse
                            {
                                Data = "this is the mocked data I expect my real external service to return"
                            });

            var sut = new TransactionService(dataServiceMock.Object);

            // Act (call a method on the sut)
            sut.CustomerCareResult(customerRequest);

            // Assert (verify that each of the 2 the methods in the IDatabaseService mock have been called exactly once)
            dataServiceMock.Verify(m => m.createPutRequest(It.IsAny<CustomerRequest>()), Times.Once());
            dataServiceMock.Verify(m => m.createPutResponse(It.IsAny<CustomerPutRequest>()), Times.Once());
        }
    }
}