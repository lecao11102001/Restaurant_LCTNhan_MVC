namespace Restaurant_MVC.Models.SharedData
{
    public class DataSharingService : IDataSharingService
    {
        private Dictionary<string, string> _sharedDataDict = new Dictionary<string, string>();

        public string GetSharedData(string key)
        {
            if (_sharedDataDict.ContainsKey(key))
            {
                return _sharedDataDict[key];
            }
            return null;
        }

        public void SetSharedData(string key, string data)
        {
            _sharedDataDict[key] = data;
        }

        public void ClearShareData(string key)
        {
            _sharedDataDict[key] = null;
        }
    }
}
