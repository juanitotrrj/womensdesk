using System.Collections.Generic;

namespace AppStudio.Data
{
    public static class OAuthTokensRepository
    {
        private static Dictionary<long, OAuthTokens> Tokens { get; set; }

        static OAuthTokensRepository()
        {
            Tokens = new Dictionary<long, OAuthTokens>();


            Tokens.Add(7834, new OAuthTokens
                            {
                                { "AppId", "459084440910488" },
                                { "AppSecret", "dadc74d49d3585c9f1f466798e0d986c" }
                            });

            Tokens.Add(7838, new OAuthTokens
                            {
                                { "ClientId", "2ac2a899b9ba4e3598723769e4a3a6cb" }
                            });

            Tokens.Add(7837, new OAuthTokens
                            {
                                { "ConsumerKey", "HwstqOgvMbiEOeHpCCtkL5cOd" },
                                { "ConsumerSecret", "PAX4iqsxZ5KDUF92LwdblMchsGW7VemSo3mGhr9U7RTitCDt5h" },
                                { "AccessToken", "134397845-qot2sQbyIyItVgG8tzedrOJXyJJNqXBQrsSjOlwu" },
                                { "AccessTokenSecret", "IKtt0WgusYf6M4YTr0rbhxWzGVcP736ADdhCOsszSRo7O" }
                            });

            Tokens.Add(7840, new OAuthTokens
                            {
                                { "ApiKey", "AIzaSyBc0qtHc6biGF6BHjeug0nCFP4-Ig9AGhA" }
                            });

        }

        public static OAuthTokens GetTokens(long key)
        {
            if (Tokens.ContainsKey(key))
            {
                return Tokens[key];
            }
            return null;
        }

    }
}
