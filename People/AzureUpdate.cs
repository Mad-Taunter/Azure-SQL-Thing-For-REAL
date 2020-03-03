using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;

namespace People
{
    public class AzureUpdate
    {
        private string dbplace;
        public AzureUpdate(string dbpath)
        {
            dbplace = dbpath;
        }
        public async Task PerformBlobOperation()
        {
            // Retrieve storage account from connection string.
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=gamingstoring;AccountKey=E2VOvWrj+xeYNj0fJj1k2rwswavgFGmxdtQfsUYRlMwxixODvCsoQjbFhPIzMDNrQM00+o7u2Xqz5iV+6On5uw==;EndpointSuffix=core.windows.net");

            // Create the blob client.
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            // Retrieve reference to a previously created container.
            CloudBlobContainer container = blobClient.GetContainerReference("mycontainer");

            // Create the container if it doesn't already exist.
            await container.CreateIfNotExistsAsync();

            // Retrieve reference to a blob named "myblob".
            CloudBlockBlob blockBlob = container.GetBlockBlobReference("myblob");

            // Create the "myblob" blob with the text "Hello, world!"
            //await blockBlob.UploadTextAsync("Hello, world!");
            blockBlob.UploadFromFile(dbplace);
        }

    }
}
