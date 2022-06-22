using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Threading;
using System.Net;
using Capstone.WebApi.Models;
using System.Text.Json;
using System.Collections.Generic;

namespace Capstone.WebApi.Tests
{
    public class HttpMessageHandlerStub : HttpMessageHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var responseMessage = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JsonSerializer.Serialize(
                    new SmartSubsReturn()
                    {
                        productRecommendations = new List<ProductRecommendation>()

                    {
                        new ProductRecommendation()
                        {
                            active = true,
                            stockCode = 880018,
                            recommendations = new List<Recommendation>()
                            {
                                new Recommendation()
                                {
                                    stockCode = 482298,
                                    score = 17
                                },

                            {
                                new Recommendation()
                                {
                                    stockCode = 482321,
                                    score = 11
                                }
                            },

                            {
                                new Recommendation()
                                {
                                    stockCode = 840481,
                                    score = 6
                                }

                            }
                        }
                    }
            }

                    }))
            };





            return await Task.FromResult(responseMessage);
        }
    }
}

