using FluentHealth.Core.Services;
using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace FluentHealth.Services.Storage
{
    public class LocalStorage : IFilesStorage
    {
        private const string FILES_DIRECTORY = "Files";

        private readonly string _rootDirectory;
        private readonly ILogger _logger;

        public LocalStorage(string rootDirectory, ILogger logger)
        {
            _rootDirectory = rootDirectory;
            _logger = logger;
        }

        public byte[] LoadFile(object id)
        {
            try
            {
                using (var file = File.OpenRead(Path.Combine(_rootDirectory, FILES_DIRECTORY, id.ToString())))
                using (var fileStream = new BinaryReader(file))
                {
                    return fileStream.ReadBytes((int)file.Length);
                }
            }
            catch (Exception exc)
            {
                //_logger.LogError(exc, nameof(TryUploadFile));
                return null;
            }
        }

        public bool TryUploadFile(byte[] data, string originalName, out object id)
        {
            try
            {
                id = Guid.NewGuid();

                using (var file = File.Create(Path.Combine(_rootDirectory, FILES_DIRECTORY, $"{id}{Path.GetExtension(originalName)}"), data.Length, FileOptions.Asynchronous))
                using (var fileStream = new BinaryWriter(file))
                {
                    fileStream.Write(data);
                    fileStream.Close();
                }

                return true;
            }
            catch(Exception exc)
            {
                //_logger.LogError(exc, nameof(TryUploadFile));
                id = Guid.Empty;
            }

            return false;
        }
    }
}
