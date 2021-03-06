﻿using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using JudoPayDotNet;
using JudoPayDotNet.Http;
using JudoPayDotNet.Models;
using JudoPayDotNet.Logging;
using NSubstitute;
using NUnit.Framework;

namespace JudoPayDotNetTests.Clients.WebPayments
{
    [TestFixture]
    public class PreAuthsTests
    {
        [Test]
        public void CreatePreAuth()
        {
            var httpClient = Substitute.For<IHttpClient>();
            var request = new WebPaymentRequestModel
            {
                Amount = 10,
                CardAddress = new WebPaymentCardAddress
                {
                    CardHolderName = "Test User",
                    Line1 = "Test Street",
                    Line2 = "Test Street",
                    Line3 = "Test Street",
                    Town = "London",
                    PostCode = "W31 4HS",
                    Country = "England"
                },
                ClientIpAddress = "127.0.0.1",
                CompanyName = "Test",
                Currency = "GBP",
                ExpiryDate = DateTimeOffset.Now,
                JudoId = "1254634",
                PartnerServiceFee = 10,
                PaymentCancelUrl = "http://test.com",
                PaymentSuccessUrl = "http://test.com",
                Reference = "42421",
                Status = WebPaymentStatus.Open,
                TransactionType = TransactionType.PAYMENT,
                YourConsumerReference = "4235325",
                
                Receipt = new PaymentReceiptModel
                {
                    ReceiptId = 134567,
                    Type = "Create",
                    JudoId = 12456,
                    OriginalAmount = 20,
                    Amount = 20,
                    NetAmount = 20,
                    CardDetails = new CardDetails
                    {
                        CardLastfour = "1345",
                        EndDate = "1214",
                        CardToken = "ASb345AE",
                        CardType = CardType.VISA
                    },
                    Currency = "GBP",
                    Consumer = new Consumer
                    {
                        ConsumerToken = "B245SEB",
                        YourConsumerReference = "Consumer1"
                    }
                }
            };
            var response = new HttpResponseMessage(HttpStatusCode.OK) {Content = new StringContent(@"{
		                                             postUrl : 'http://test.com',
		                                             reference : '1342423'   
                                                }")};
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var responseTask = new TaskCompletionSource<HttpResponseMessage>();
            responseTask.SetResult(response);

            httpClient.SendAsync(Arg.Any<HttpRequestMessage>()).Returns(responseTask.Task);

            var client = new Client(new Connection(httpClient,
                                                    DotNetLoggerFactory.Create,
                                                    "http://something.com"));

            var judo = new JudoPayApi(DotNetLoggerFactory.Create, client);

            var paymentReceiptResult = judo.WebPayments.PreAuths.Create(request).Result;

            Assert.NotNull(paymentReceiptResult);
            Assert.IsFalse(paymentReceiptResult.HasError);
            Assert.NotNull(paymentReceiptResult.Response);
            Assert.AreEqual("1342423", paymentReceiptResult.Response.Reference);
            Assert.NotNull(paymentReceiptResult.Response.PostUrl);
        }

        [Test]
        public void UpdatePreAuth()
        {
            var httpClient = Substitute.For<IHttpClient>();
            var request = new WebPaymentRequestModel
            {
                Amount = 10,
                CardAddress = new WebPaymentCardAddress
                {
                    CardHolderName = "Test User",
                    Line1 = "Test Street",
                    Line2 = "Test Street",
                    Line3 = "Test Street",
                    Town = "London",
                    PostCode = "W31 4HS",
                    Country = "England"
                },
                ClientIpAddress = "127.0.0.1",
                CompanyName = "Test",
                Currency = "GBP",
                ExpiryDate = DateTimeOffset.Now,
                JudoId = "1254634",
                PartnerServiceFee = 10,
                PaymentCancelUrl = "http://test.com",
                PaymentSuccessUrl = "http://test.com",
                Reference = "42421",
                Status = WebPaymentStatus.Open,
                TransactionType = TransactionType.PAYMENT,
                YourConsumerReference = "4235325",
                
                Receipt = new PaymentReceiptModel
                {
                    ReceiptId = 134567,
                    Type = "Create",
                    JudoId = 12456,
                    OriginalAmount = 20,
                    Amount = 20,
                    NetAmount = 20,
                    CardDetails = new CardDetails
                    {
                        CardLastfour = "1345",
                        EndDate = "1214",
                        CardToken = "ASb345AE",
                        CardType = CardType.VISA
                    },
                    Currency = "GBP",
                    Consumer = new Consumer
                    {
                        ConsumerToken = "B245SEB",
                        YourConsumerReference = "Consumer1"
                    }
                }
            };
            var response = new HttpResponseMessage(HttpStatusCode.OK) {Content = new StringContent(@"{
    	                                            amount : 10,
    	                                            cardAddress : 
    	                                            {
    		                                            cardHolderName : 'Test User',
    		                                            line1 : 'Test Street',
    		                                            line2 : 'Test Street',
    		                                            line3 : 'Test Street',
    		                                            town : 'London',
    		                                            postCode : 'W31 4HS',
    		                                            country : 'England'
    	                                            },
    	                                            clientIpAddress : '128.0.0.1',
    	                                            clientUserAgent : 'Chrome',
    	                                            companyName : 'Test',
    	                                            currency : 'GBP',
    	                                            expiryDate : '2012-07-19T14:30:00+09:30',
    	                                            judoId : '1254634',
		                                            partnerRecId : '243532',
		                                            partnerServiceFee : 10,
		                                            paymentCancelUrl : 'http://test.com',
		                                            paymentSuccessUrl : 'http://test.com',
		                                            reference : '1342423',
		                                            status : 'Open',
		                                            transactionType : 'SALE',
		                                            yourConsumerReference : '4235325',
		                                            yourPaymentReference : '42355',
		                                            receipt:
		                                            {
	                                                    receiptId : '134567',
	                                                    type : 'Create',
	                                                    judoId : '12456',
	                                                    originalAmount : 20,
	                                                    amount : 20,
	                                                    netAmount : 20,
	                                                    cardDetails :
	                                                        {
	                                                            cardLastfour : '1345',
	                                                            endDate : '1214',
	                                                            cardToken : 'ASb345AE',
	                                                            cardType : 'VISA'
	                                                        },
	                                                    currency : 'GBP',
	                                                    consumer : 
	                                                        {
	                                                            consumerToken : 'B245SEB',
	                                                            yourConsumerReference : 'Consumer1'
	                                                        }
		                                            },
                                                    response: 
                                                    {
		                                                 postUrl : 'http://test.com',
		                                                 reference : '1342423'   
                                                    }
                                                }")};
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var responseTask = new TaskCompletionSource<HttpResponseMessage>();
            responseTask.SetResult(response);

            httpClient.SendAsync(Arg.Any<HttpRequestMessage>()).Returns(responseTask.Task);

            var client = new Client(new Connection(httpClient,
                                                    DotNetLoggerFactory.Create,
                                                    "http://something.com"));

            var judo = new JudoPayApi(DotNetLoggerFactory.Create, client);

            var paymentReceiptResult = judo.WebPayments.PreAuths.Update(request).Result;

            Assert.NotNull(paymentReceiptResult);
            Assert.IsFalse(paymentReceiptResult.HasError);
            Assert.NotNull(paymentReceiptResult.Response);
            Assert.AreEqual("1342423", paymentReceiptResult.Response.Reference);
            Assert.AreEqual("1342423", paymentReceiptResult.Response.Response.Reference);
            Assert.NotNull(paymentReceiptResult.Response.Response.PostUrl);
        }
    }
}
