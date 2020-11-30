using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace TestGitProject.Interfaces
{
    public interface ISave
    {
        Task SaveAsync(string filename, string contentType, MemoryStream s);
        Stream ConvertPngToJpeg(Stream stream);

    }
}
