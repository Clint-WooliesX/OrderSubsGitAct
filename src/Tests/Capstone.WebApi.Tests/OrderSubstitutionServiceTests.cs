using System;
using Xunit;
using System.Threading.Tasks;
using Capstone.WebApi.Models;
using Capstone.WebApi.Services;
using Moq;
using System.Net.Http;
namespace Capstone.WebApi.Tests
{
	public class OrderSubstitutionServiceTests
	{
		// arrange, act, assert
		//stockCode { get; set; }

		//fulfilmentStoreKey { get; set; }

		// Quantity { get; set; }

		// branchID { get; set; }
		// "stockCode": 827364,
		//"fulfilmentStoreKey": "3308",
		//"quantity": 12,
		//"branchID": "3308"


		[Fact]
		public async Task Unit_GetSubstitutionOfOrder_SmartSubsReturnArray()
        {
			//Arrange

			DTOOrder[] testArray = new DTOOrder[]
			{
				new DTOOrder()
				{
					stockCode = 827364,
					fulfilmentStoreKey = "3308",
					quantity = 12,
					branchID = "3308"
				},

				new DTOOrder()
				{
					stockCode = 827364,
					fulfilmentStoreKey = "3308",
					quantity = 12,
					branchID = "3308"
				}
			};

            var mockClient = new Mock<IHttpClientFactory>();
            var clientHandlerStub = new HttpMessageHandlerStub();
            var client = new HttpClient(clientHandlerStub);

            mockClient.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(client);           


            OrderSubstitutionService testSubService = new OrderSubstitutionService(mockClient.Object);


            // Act

            var result = await testSubService.GetSubstitutionOfOrder(testArray);

            // Assert

            Assert.NotNull(result);
            Assert.IsType<SmartSubsReturn[]>(result);

        }

		[Fact]
		public async Task Integration_GetSubstitutionOfOrder_SmartSubsReturnArray()
		{
			//Arrange

			DTOOrder[] testArray = new DTOOrder[]
			{
				new DTOOrder()
				{
					stockCode = 827364,
					fulfilmentStoreKey = "3308",
					quantity = 12,
					branchID = "3308"
				},

				new DTOOrder()
				{
					stockCode = 827364,
					fulfilmentStoreKey = "3308",
					quantity = 12,
					branchID = "3308"
				}
			};

			var mockClient = new Mock<IHttpClientFactory>();
			var clientHandlerStub = new HttpMessageHandlerStub();
			var client = new HttpClient(clientHandlerStub);

			mockClient.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(client);


			OrderSubstitutionService testSubService = new OrderSubstitutionService(mockClient.Object);


			// Act

			var result = await testSubService.GetSubstitutionOfOrder(testArray);

			// Assert

			Assert.NotNull(result);
			Assert.IsType<SmartSubsReturn[]>(result);

		}
	}
}

