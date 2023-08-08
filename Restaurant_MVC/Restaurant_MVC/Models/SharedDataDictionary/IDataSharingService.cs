namespace Restaurant_MVC.Models.SharedDataDictionary
{
    public interface IDataSharingService
    {
        string GetSharedData(string key);
        void SetSharedData(string key, string data);

        void ClearShareData(string key);
    }
}
