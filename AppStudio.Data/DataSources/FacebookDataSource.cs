using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class FacebookDataSource : DataSourceBase<FacebookSchema>
    {
        private const long OAuthKey = 7834;
        private const string UserId = "914522411931935";

        protected override string CacheKey
        {
            get { return "FacebookDataSource"; }
        }

        public override bool HasStaticData
        {
            get { return false; }
        }

        public async override Task<IEnumerable<FacebookSchema>> LoadDataAsync()
        {
            try
            {
                var facebookDataProvider = new FacebookDataProvider(UserId, OAuthTokensRepository.GetTokens(OAuthKey));
                return await facebookDataProvider.LoadAsync();
            }
            catch (Exception ex)
            {
                AppLogs.WriteError("FacebookDataSourceDataSource.LoadData", ex.ToString());
                return new FacebookSchema[0];
            }
        }
    }
}
