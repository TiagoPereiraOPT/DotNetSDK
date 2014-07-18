﻿using JudoPayDotNet.Clients;
using JudoPayDotNet.Clients.Market;

namespace JudoPayDotNet
{
    class Market : IMarket
    {
        public IMarketPayments Payments { get; set; }

        public IMarketRefunds Refunds { get; set; }

        public IMarketPreAuths PreAuths { get; set; }

        public ITransactions Transactions { get; set; }

        public IMarketCollections Collections { get; set; }

        public IMarketMerchants Merchants { get; set; }
    }
}