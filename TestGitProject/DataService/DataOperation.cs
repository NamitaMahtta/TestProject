using TestGitProject.Model;
using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.IO;
using System.IO.Compression;

namespace TestGitProject.DataService
{
    class DataOperation
    {
        HttpClient client = new HttpClient();

        readonly string server = "https://cmctracker-test.chpc.utah.edu/";

        readonly string serverBase = "https://cmctracker-test.chpc.utah.edu/scripts/App/";

        public DataOperation()
        {
        }

        public async Task<byte[]> GetImageFromServer(string link)
        {
            //Display image from the database
            var baseLoc = server + "X/";
            var response = await client.GetByteArrayAsync(baseLoc + link);
            return response;
        }

    }
}