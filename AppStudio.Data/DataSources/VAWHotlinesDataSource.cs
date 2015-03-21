using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class VAWHotlinesDataSource : DataSourceBase<VAWHotlinesSchema>
    {
        private const string _file = "/Assets/Data/VAWHotlinesDataSource.json";

        protected override string CacheKey
        {
            get { return "VAWHotlinesDataSource"; }
        }

        public override bool HasStaticData
        {
            get { return false; }
        }

        public async override Task<IEnumerable<VAWHotlinesSchema>> LoadDataAsync()
        {
            try
            {
                var serviceDataProvider = new StaticDataProvider(_file);
                return await serviceDataProvider.Load<VAWHotlinesSchema>();
            }
            catch (Exception ex)
            {
                AppLogs.WriteError("VAWHotlinesDataSource.LoadData", ex.ToString());
                return new VAWHotlinesSchema[0];
            }
        }
    }
}
