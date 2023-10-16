using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using AzureBlobStorage.Models;
using Microsoft.Extensions.Options;

namespace AzureBlobStorage.Azure
{
    //Low-level module
    public class AzureStorage
    {
        private readonly string _connectionKey;
        private readonly string _container;

        public AzureStorage(IOptions<AzureSetting> options)
        {
            _connectionKey = options.Value.ConnectionKey;
            _container = options.Value.Container;
        }

        public async Task<Stream> DownloadBlob(string blobName)
        {
            var blobClient = CreateBlobClient(blobName);
            using (MemoryStream memoryStream = new MemoryStream())
            {
                await blobClient.DownloadToAsync(memoryStream);
                return memoryStream;
            }
        }

        public async Task<BlobContentInfo> UploadBlob(Stream Content, string BlobName)
        {
            var blobClient = CreateBlobClient(BlobName);
            return await blobClient.UploadAsync(Content, true);
        }

        private BlobClient CreateBlobClient(string blobName)
        {
            var serviceClient = new BlobServiceClient(_connectionKey);
            var containerClient = serviceClient.GetBlobContainerClient(_container);
            var blobClient = containerClient.GetBlobClient(blobName);
            return blobClient;
        }
    }
}