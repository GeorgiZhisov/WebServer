using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;
using WebServer.Server.HTTP;
using WebServer.Server.HTTP_Request;

namespace WebServer.Server.Responses
{
    public class TextFileResponse : Response
    {
        public string FileName { get; init; }
        public TextFileResponse(string fileName) : base(StatusCode.OK)
        {
            FileName = fileName;
            this.Headers.Add(Header.ContentType, ContentType.PlainText);
        }

        public override string ToString()
        {
            if (File.Exists(FileName))
            {
                Body = File.ReadAllText(FileName);
                var fileBytesCount = new FileInfo(FileName).Length;
                this.Headers.Add(Header.ContentLength, fileBytesCount.ToString());
                this.Headers.Add(Header.ContentDisposition, $"attachment; filename=\"{this.FileName}\"");
            }
            return base.ToString();
        }
    }
}
