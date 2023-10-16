using AzureBlobStorage.Azure;
using AzureBlobStorage.Utils;
using System;

namespace AzureBlobStorage.Services
{
    public class AzureBlobService
    {
        private readonly AzureStorage _azureBlob;

        public AzureBlobService(AzureStorage azureBlob)
        {
            _azureBlob = azureBlob;
        }

        public async Task<string> UploadBlobFromContentBase64(string contentBase64)
        {
            var streamContent = Utils.Utils.GetStreamFromContentBase64(contentBase64);
            var blobName = Guid.NewGuid().ToString();
            var uploadedBlob = await _azureBlob.UploadBlob(streamContent, blobName);
            return String.Empty;
        }
    }
}
