using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Goedel.Protocol;

namespace Goedel.Protocol {

    
    
    public class WebServiceClient {
        int Port;
        string Domain;
        string Stem;

        public CryptographicContext CryptographicContext = null;
        

        public WebServiceClient(string DomainIn, int PortIn, string StemIn) {
            Port = PortIn;
            Domain = DomainIn;
            Stem = StemIn == null ? "" : StemIn;
            }

        public string Request(string Content) {
            string Uri = "http://" + Domain + ":" + Port.ToString() + "/" + Stem;

            WebRequest  WebRequest = WebRequest.Create (Uri);
            WebRequest.Method = "POST";

            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(Content);
            WebRequest.ContentLength = buffer.Length;

            WebRequest.ContentType = "application/json;charset=UTF-8";
            WebRequest.Headers.Add("Cache-Control: no-store");

            if (CryptographicContext != null) {
                string Integrity = CryptographicContext.GetIntegrityHeader (buffer);
                WebRequest.Headers.Add(Integrity);
                }

            Stream RequestStream = WebRequest.GetRequestStream ();
            RequestStream.Write (buffer, 0 ,buffer.Length);
            RequestStream.Close();

            HttpWebResponse WebResponse  = (HttpWebResponse) WebRequest.GetResponse ();
            int Code = (int) WebResponse.StatusCode;
            
            Console.WriteLine ("Got a response {0} {1}", 
                Code, WebResponse.StatusDescription);


            if (Code > 299) {
                throw new Exception (WebResponse.StatusDescription);
                }


            Stream ResponseStream = WebResponse.GetResponseStream ();
            StreamReader Reader = new StreamReader(ResponseStream, Encoding.UTF8);
            string Result = Reader.ReadToEnd();
            Console.WriteLine(Result);
            Console.WriteLine("-----------");

            return Result;
            }
        }
    }
