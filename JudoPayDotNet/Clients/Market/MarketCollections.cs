﻿using JudoPayDotNet.Http;
using JudoPayDotNet.Logging;

namespace JudoPayDotNet.Clients.Market
{
    internal class MarketCollections : BaseCollections, IMarketCollections
    {
        private const string CREATEADDRESS = "market/transactions/collections";

        public MarketCollections(ILog logger, IClient client) : base(logger, client, CREATEADDRESS)
        {
        }
    }
}
