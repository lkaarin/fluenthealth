namespace FluentHealth.Core.Services
{
    public interface IFilesStorage
    {
        byte[] LoadFile(object id);
        bool TryUploadFile(byte[] data, string originalName, out object id);
    }
}
