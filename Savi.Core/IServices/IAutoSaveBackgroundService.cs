namespace Savi.Core.IServices
{
    public interface IAutoSaveBackgroundService
    {
        public Task<bool> CheckAndExecuteAutoSaveTask();
    }
}
