using NBitcoin;

namespace BTCPayServer
{
    public partial class BTCPayNetworkProvider
    {
        public void InitThought()
        {
            //not needed: NBitcoin.Altcoins.Thought.Instance.EnsureRegistered();
            var nbxplorerNetwork = NBXplorerNetworkProvider.GetFromCryptoCode("THT");
            Add(new BTCPayNetwork()
            {
                CryptoCode = nbxplorerNetwork.CryptoCode,
                DisplayName = "Thought",
                BlockExplorerLink = NetworkType == NetworkType.Mainnet
                    ? "https://exp.thought.live/insight/tx/{0}"
                    : "https://ext.thought.live/insight/tx/{0}",
                NBXplorerNetwork = nbxplorerNetwork,
                UriScheme = "thought",
                DefaultRateRules = new[]
                    {
                        "THT_X = THT_BTC * BTC_X",
                        "THT_BTC = coinall(THT_BTC)"
                    },
                CryptoImagePath = "imlegacy/thought.png",
                DefaultSettings = BTCPayDefaultSettings.GetDefaultSettings(NetworkType),
                //https://github.com/satoshilabs/slips/blob/master/slip-0044.md
                CoinType = NetworkType == NetworkType.Mainnet ? new KeyPath("5'")
                    : new KeyPath("1'")
            });
        }
    }
}
