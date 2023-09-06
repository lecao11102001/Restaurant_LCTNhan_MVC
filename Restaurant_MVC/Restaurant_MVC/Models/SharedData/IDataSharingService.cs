namespace Restaurant_MVC.Models.SharedData
{
    public interface IDataSharingService
    {
        string GetSharedData(string key);

        void SetSharedData(string key, string data);

        void ClearShareData(string key);
    }
}
