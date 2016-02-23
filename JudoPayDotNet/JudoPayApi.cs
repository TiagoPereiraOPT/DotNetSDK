﻿using System;
using System.Collections.Generic;
using JudoPayDotNet.Clients;
using JudoPayDotNet.Clients.Consumer;
using JudoPayDotNet.Clients.Market;
using JudoPayDotNet.Clients.WebPayments;
using JudoPayDotNet.Http;
using JudoPayDotNet.Logging;
using IPayments = JudoPayDotNet.Clients.IPayments;
using IPreAuths = JudoPayDotNet.Clients.IPreAuths;
using ITransactions = JudoPayDotNet.Clients.ITransactions;
using Payments = JudoPayDotNet.Clients.Payments;
using PreAuths = JudoPayDotNet.Clients.PreAuths;
using Transactions = JudoPayDotNet.Clients.Transactions;

namespace JudoPayDotNet
{
	/// <summary>
	/// The JudoPay API client, the main entry point for the SDK
	/// </summary>
    public class JudoPayApi : IJudoPayApi
    {
        internal IMarket Market { get; set; }

        public IWebPayments WebPayments { get; set; }
        public IBlacklists Blacklists { get; set; }
        public IConsumers Consumers { get; set; }

        public IPayments Payments { get; set; }
        public IRefunds Refunds { get; set; }
        public IPreAuths PreAuths { get; set; }
        public ITransactions Transactions { get; set; }
        public ICollections Collections { get; set; }
        public IThreeDs ThreeDs { get; set; }
        public IRegisterCards RegisterCards { get; set; }

        public JudoPayApi(Func<Type, ILog> logger, IClient client)
        {
            Payments = new Payments(logger(typeof(Payments)), client,true);
            Refunds = new Refunds(logger(typeof(Refunds)), client);
            PreAuths = new PreAuths(logger(typeof(PreAuths)), client, true);
            Transactions = new Transactions(logger(typeof(Transactions)), client);
            Collections = new Collections(logger(typeof(Collections)), client);
            ThreeDs = new ThreeDs(logger(typeof(ThreeDs)), client);
            RegisterCards = new RegisterCards(logger(typeof(RegisterCards)), client,true);

            Market = new Market
            {
                Refunds = new MarketRefunds(logger(typeof(MarketRefunds)), client),
                Transactions = new MarketTransactions(logger(typeof(MarketTransactions)), client),
                Collections = new MarketCollections(logger(typeof(MarketCollections)), client),
                Merchants = new MarketMerchants(logger(typeof(MarketMerchants)), client)
            };

            WebPayments = new WebPayments
            {
                Payments = new Clients.WebPayments.Payments(logger(typeof(Clients.WebPayments.Payments)), client),
                PreAuths = new Clients.WebPayments.PreAuths(logger(typeof(Clients.WebPayments.PreAuths)), client),
                Transactions = new Clients.WebPayments.Transactions(logger(typeof(Clients.WebPayments.Transactions)), client)
            };

            Consumers = new Consumers(logger(typeof(Consumers)), client);
            Blacklists = new Blacklists
            {
                Devices = new Devices(logger(typeof (Blacklists)), client)
            };
        }

    }
}
