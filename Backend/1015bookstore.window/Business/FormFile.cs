using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _1015bookstore.window.Business
{
    public class FormFile : IFormFile
    {
        private Stream stream;

        public FormFile(Stream stream, long length, long? totalLength, string name, string fileName)
        {
            this.stream = stream;
            Length = length;
            Name = name;
            FileName = fileName;
            ContentDisposition = $"form-data; name={name}; filename={fileName}";
            Headers = new HeaderDictionary();
            Headers["Content-Disposition"] = new StringValues(ContentDisposition);
            Headers["Content-Type"] = new StringValues("application/octet-stream");
        }

        public string ContentDisposition { get; }
        public string ContentType { get; } = "application/octet-stream";
        public IHeaderDictionary Headers { get; }
        public long Length { get; }
        public string Name { get; }
        public string FileName { get; }
        public Stream OpenReadStream() => stream;

        public void CopyTo(Stream target)
        {
            stream.CopyTo(target);
        }

        public Task CopyToAsync(Stream target, CancellationToken cancellationToken = default)
        {
            return stream.CopyToAsync(target, 81920, cancellationToken);
        }
    }
    
}
