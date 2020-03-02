using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;

namespace People
{

    static CloudBlobContainer GetContainer(ContainerType containerType)
    {
        var account = CloudStorageAccount.Parse(Constants.StorageConnection);
        var client = account.CreateCloudBlobClient();
        return client.GetContainerReference(containerType.ToString().ToLower());
    }

    class AzureUpdate
    {

    }
}
