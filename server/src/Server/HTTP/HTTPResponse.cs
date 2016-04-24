﻿using System;
using System.Text;

namespace KRPC.Server.HTTP
{
    class HTTPResponse
    {
        const string PROTOCOL = "HTTP/1.1";

        public static HTTPResponse BadRequest {
            get { return new HTTPResponse (400, "Bad Request"); }
        }

        public static HTTPResponse Forbidden {
            get { return new HTTPResponse (403, "Forbidden"); }
        }

        public static HTTPResponse NotFound {
            get { return new HTTPResponse (404, "Not Found"); }
        }

        public static HTTPResponse MethodNotAllowed {
            get { return new HTTPResponse (405, "Method Not Allowed"); }
        }

        public static HTTPResponse UpgradeRequired {
            get { return new HTTPResponse (426, "Upgrade Required"); }
        }

        public static HTTPResponse InternalServerError {
            get { return new HTTPResponse (500, "Internal Server Error"); }
        }

        public static HTTPResponse HTTPVersionNotSupported {
            get { return new HTTPResponse (505, "HTTP Version Not Supported"); }
        }

        const string NEWLINE = "\r\n";
        readonly StringBuilder contents = new StringBuilder ();

        public string Body { get; set; }

        public HTTPResponse (uint code, string type)
        {
            contents.Append (PROTOCOL + " " + code + " " + type + NEWLINE);
            Body = "";
        }

        public void AddAttribute (string key, string value)
        {
            contents.Append (key + ": " + value + NEWLINE);
        }

        public override string ToString ()
        {
            var result = contents + NEWLINE;
            if (Body.Trim () != "")
                result += Body.Trim () + NEWLINE;
            return result;
        }

        public byte[] ToBytes ()
        {
            return Encoding.ASCII.GetBytes (ToString ());
        }
    }
}

