﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using JudoPayDotNet.Http;
using JudoPayDotNet.Models;
using JudoPayDotNetDotNet;
using NUnit.Framework;

namespace JudoPayDotNetIntegrationTests
{
    [TestFixture]
    public class WebPaymentsTests
    {
        [Test]
        public void PaymentCreate()
        {
            var judo = JudoPaymentsFactory.Create(Configuration.TOKEN,
                Configuration.SECRET,
                Configuration.BASEADDRESS);

            var request = new WebPaymentRequestModel()
            {
                Amount = 10,
                CardAddress = new WebPaymentCardAddress()
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
                JudoId = Configuration.JUDOID,
                PartnerRecId = 243532,
                PartnerServiceFee = 10,
                PaymentCancelUrl = "http://test.com",
                PaymentSuccessUrl = "http://test.com",
                Reference = "42421",
                Status = WebPaymentStatus.Open,
                TransactionType = TransactionType.SALE,
                YourConsumerReference = "4235325",
                YourPaymentReference = "42355"
            };

            var result = judo.WebPayments.Payments.Create(request).Result;

            Assert.NotNull(result);
            Assert.IsFalse(result.HasError);
            Assert.NotNull(result.Response);
            Assert.NotNull(result.Response.Reference);
            Assert.NotNull(result.Response.PostUrl);
        }

        [Test]
        public void PaymentUpdate()
        {
            var judo = JudoPaymentsFactory.Create(Configuration.TOKEN,
                Configuration.SECRET,
                Configuration.BASEADDRESS);

            var request = new WebPaymentRequestModel()
            {
                Amount = 10,
                CardAddress = new WebPaymentCardAddress()
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
                JudoId = Configuration.JUDOID,
                PartnerRecId = 243532,
                PartnerServiceFee = 10,
                PaymentCancelUrl = "http://test.com",
                PaymentSuccessUrl = "http://test.com",
                Reference = "42421",
                Status = WebPaymentStatus.Open,
                TransactionType = TransactionType.SALE,
                YourConsumerReference = "4235325",
                YourPaymentReference = "42355"
            };

            var result = judo.WebPayments.Payments.Create(request).Result;

            Assert.NotNull(result);
            Assert.IsFalse(result.HasError);
            Assert.NotNull(result.Response);
            Assert.NotNull(result.Response.Reference);
            Assert.NotNull(result.Response.PostUrl);

            request.Status = WebPaymentStatus.Paid;
            request.Reference = result.Response.Reference;

            var resultUpdate = judo.WebPayments.Payments.Update(request).Result;

            Assert.NotNull(resultUpdate);
            Assert.IsFalse(resultUpdate.HasError);
            Assert.NotNull(resultUpdate.Response);
            Assert.NotNull(resultUpdate.Response.Reference);
            Assert.AreEqual(result.Response.Reference, resultUpdate.Response.Reference);
            Assert.AreEqual(resultUpdate.Response.Status, resultUpdate.Response.Status);
        }

        [Test]
        public void PreAuthCreate()
        {
            var judo = JudoPaymentsFactory.Create(Configuration.TOKEN,
                Configuration.SECRET,
                Configuration.BASEADDRESS);

            var request = new WebPaymentRequestModel()
            {
                Amount = 10,
                CardAddress = new WebPaymentCardAddress()
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
                JudoId = Configuration.JUDOID,
                PartnerRecId = 243532,
                PartnerServiceFee = 10,
                PaymentCancelUrl = "http://test.com",
                PaymentSuccessUrl = "http://test.com",
                Reference = "42421",
                Status = WebPaymentStatus.Open,
                TransactionType = TransactionType.PREAUTH,
                YourConsumerReference = "4235325",
                YourPaymentReference = "42355"
            };

            var result = judo.WebPayments.PreAuths.Create(request).Result;

            Assert.NotNull(result);
            Assert.IsFalse(result.HasError);
            Assert.NotNull(result.Response);
            Assert.NotNull(result.Response.Reference);
            Assert.NotNull(result.Response.PostUrl);
        }

        [Test]
        public void PreAuthUpdate()
        {
            var judo = JudoPaymentsFactory.Create(Configuration.TOKEN,
                Configuration.SECRET,
                Configuration.BASEADDRESS);

            var request = new WebPaymentRequestModel()
            {
                Amount = 10,
                CardAddress = new WebPaymentCardAddress()
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
                JudoId = Configuration.JUDOID,
                PartnerRecId = 243532,
                PartnerServiceFee = 10,
                PaymentCancelUrl = "http://test.com",
                PaymentSuccessUrl = "http://test.com",
                Reference = "42421",
                Status = WebPaymentStatus.Open,
                TransactionType = TransactionType.SALE,
                YourConsumerReference = "4235325",
                YourPaymentReference = "42355"
            };

            var result = judo.WebPayments.PreAuths.Create(request).Result;

            Assert.NotNull(result);
            Assert.IsFalse(result.HasError);
            Assert.NotNull(result.Response);
            Assert.NotNull(result.Response.Reference);
            Assert.NotNull(result.Response.PostUrl);

            request.Status = WebPaymentStatus.Paid;
            request.Reference = result.Response.Reference;

            var resultUpdate = judo.WebPayments.PreAuths.Update(request).Result;

            Assert.NotNull(resultUpdate);
            Assert.IsFalse(resultUpdate.HasError);
            Assert.NotNull(resultUpdate.Response);
            Assert.NotNull(resultUpdate.Response.Reference);
            Assert.AreEqual(result.Response.Reference, resultUpdate.Response.Reference);
            Assert.AreEqual(resultUpdate.Response.Status, resultUpdate.Response.Status);
        }

        [Test]
        public void TransactionsGetByReference()
        {
            var judo = JudoPaymentsFactory.Create(Configuration.TOKEN,
                Configuration.SECRET,
                Configuration.BASEADDRESS);

            var request = new WebPaymentRequestModel()
            {
                Amount = 10,
                CardAddress = new WebPaymentCardAddress()
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
                JudoId = Configuration.JUDOID,
                PartnerRecId = 243532,
                PartnerServiceFee = 10,
                PaymentCancelUrl = "http://test.com",
                PaymentSuccessUrl = "http://test.com",
                Reference = "42421",
                Status = WebPaymentStatus.Open,
                TransactionType = TransactionType.SALE,
                YourConsumerReference = "4235325",
                YourPaymentReference = "42355"
            };

            var result = judo.WebPayments.Payments.Create(request).Result;

            Assert.NotNull(result);
            Assert.IsFalse(result.HasError);
            Assert.NotNull(result.Response);
            Assert.NotNull(result.Response.Reference);
            Assert.NotNull(result.Response.PostUrl);

            var webRequest = judo.WebPayments.Transactions.Get(result.Response.Reference).Result;

            Assert.NotNull(webRequest);
            Assert.IsFalse(webRequest.HasError);
            Assert.NotNull(webRequest.Response);
            Assert.NotNull(webRequest.Response.Reference);
            Assert.AreEqual(result.Response.Reference, webRequest.Response.Reference);
            Assert.AreEqual(request.JudoId, webRequest.Response.JudoId);
        }

        [Test]
        public void TransactionsGetByReceiptId()
        {

            // WebPaymentRequest - Do a web payment
            var judo = JudoPaymentsFactory.Create(Configuration.TOKEN,
                Configuration.SECRET,
                Configuration.BASEADDRESS);

            var request = new WebPaymentRequestModel()
            {
                Amount = 10,
                CardAddress = new WebPaymentCardAddress()
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
                JudoId = Configuration.JUDOID,
                PartnerRecId = 243532,
                PartnerServiceFee = 10,
                PaymentCancelUrl = "http://test.com",
                PaymentSuccessUrl = "http://test.com",
                Reference = "42421",
                Status = WebPaymentStatus.Open,
                TransactionType = TransactionType.SALE,
                YourConsumerReference = "4235325",
                YourPaymentReference = "42355"
            };

            var result = judo.WebPayments.Payments.Create(request).Result;

            var reference = result.Response.Reference;

            // Forms - Post a form with credentials to post url from the webpaymentresponse passing form parameter Reference

            var httpClient = new HttpClient();
            var formContent = new FormUrlEncodedContent(new[] 
            {
                new KeyValuePair<string, string>("Reference", reference),
            });

            var formRequest = CreateJudoApiRequest(result.Response.PostUrl, HttpMethod.Post, "3.2.0.0", Configuration.TOKEN,
                Configuration.SECRET);

            formContent.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
            formRequest.Content = formContent;

            var paymentPage = httpClient.SendAsync(formRequest).Result;

            var resultBody = paymentPage.Content.ReadAsStringAsync().Result;

            /* ok this next bit is a hack. I know on Iridium's ACS simulator the PaRes value is lurking in the HTML (It's a simulator after all!) */
            var doc = new HtmlDocument();
            doc.LoadHtml(resultBody);

            // Forms - Post a form with credentials and cookie and form following variables:
            // url= /v1/Pay variables: CardNumber, ExpiryDate, Cv2, form variable: __RequestVerificationToken

            var formField = doc.DocumentNode.SelectSingleNode("//input[@name='__RequestVerificationToken']");

            var requestVerificationToken = formField.GetAttributeValue("value", "");

                //            CardNumber = "4976000000003436",
                //CV2 = "452",
                //ExpiryDate = "12/15",

            formContent = new FormUrlEncodedContent(new[] 
            {
                new KeyValuePair<string, string>("__RequestVerificationToken", requestVerificationToken),
                new KeyValuePair<string, string>("CardNumber", "4976000000003436"),
                new KeyValuePair<string, string>("Cv2", "452"), 
                new KeyValuePair<string, string>("ExpiryDate", "12/15"), 
                new KeyValuePair<string, string>("Reference", reference)
            });

            formRequest = CreateJudoApiRequest("http://127.0.0.1/webpayments/v1/Pay", HttpMethod.Post, "3.2.0.0", Configuration.TOKEN,
                Configuration.SECRET);

            formContent.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
            formRequest.Content = formContent;

            var resultPage = httpClient.SendAsync(formRequest).Result;

            resultBody = resultPage.Content.ReadAsStringAsync().Result;

            // Retrieve from the response the receipt id

            doc = new HtmlDocument();
            doc.LoadHtml(resultBody);

            formField = doc.DocumentNode.SelectSingleNode("//input[@name='ReceiptId']");

            var receiptId = formField.GetAttributeValue("value", "");

            var webRequest = judo.WebPayments.Transactions.GetByReceipt(receiptId).Result;

            Assert.NotNull(webRequest);
            Assert.IsFalse(webRequest.HasError);
            Assert.NotNull(webRequest.Response);
            Assert.NotNull(webRequest.Response.Reference);
            Assert.AreEqual(request.JudoId, webRequest.Response.JudoId);
        }

        protected HttpRequestMessage CreateJudoApiRequest(string url, HttpMethod method, string apiVersion, string apiToken, string apiSecret)
        {


            var request = new HttpRequestMessage(method, url);

            string full = string.Format("{0}:{1}", apiToken, apiSecret);

            var authDetails = Encoding.GetEncoding("iso-8859-1").GetBytes(full);
            var parameter = Convert.ToBase64String(authDetails);

            request.Headers.Add("Accept", "application/json");

            request.Headers.Add("Api-Version", apiVersion);

            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", parameter);

            return request;
        }
    }
}
