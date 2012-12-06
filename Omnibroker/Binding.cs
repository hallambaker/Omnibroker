using System;
using System.Collections.Generic;
using System.Text;
using Goedel.Protocol;
using OBPConnection;
using OBPQuery;

namespace TestProtoGen {
    //
    // These methods are only partially set up to permit asynchronous handling
    //
    // It should be possible to have multiple pending requests and responses
    // for query operations at the least. This is much less important for Queries

    public class CryptoContext {
        public byte[] Ticket;
        public Cryptography.Key Key;
        public Cryptography.Authentication Authentication;
        public Cryptography.Encryption Encryption;
        }

    public class CryptoBinding {
        public byte [] ticket;
        public Cryptography.Key MasterKey;
        public Cryptography.Authentication Authentication;
        public Cryptography.Encryption Encryption;
        }

    public abstract class Binding {
        //public bool Ready = false;
        //public Response Response ();
        //public abstract bool AsyncRequest (Payload Payload);



        protected Cryptographic Cryptographic = null;

        public void SetCrypto(Cryptographic Crypto) {
            Cryptographic = Crypto;
            }

        public byte[] Ticket {
            get { return Cryptographic == null ? null: Cryptographic.Ticket;}
            }
        }


    public abstract class ConnectionBinding : Binding {

        public virtual Response RequestResponse(Request RequestIn) {
            Request (RequestIn);
            return Response ();
            }

        public abstract void Request (Request Request);
        public abstract Response Response ();
        }


    public class DirectConnectionBinding : ConnectionBinding {
        public ConnectionServer      ConnectionServer;
        public List <BoundMessage> Messages = new List <BoundMessage> ();
        BoundMessage                     PendingResponse = null;



        CryptoContext CryptoContext = null;

        public DirectConnectionBinding(ConnectionServer ConnectionServerIn) {
            ConnectionServer = ConnectionServerIn;
            }

        public override void Request(Request Request) {
            BoundRequest BoundRequest = new BoundRequest (Request.ToString (), Cryptographic);
            Messages.Add (BoundRequest);
            Console.WriteLine (BoundRequest.HTTPBinding);
            PendingResponse = ConnectionServer.Request (BoundRequest); 
            Messages.Add (PendingResponse);
            }

        public override Response Response() {
            Message Result;
            Console.WriteLine (PendingResponse.HTTPBinding);
            Message.Deserialize (PendingResponse.Payload, out Result);
            return (Response) Result;
            }

        }


    //
    // This will eventually connect to the Web Service version
    //
    public class WebServiceConnectionBinding : ConnectionBinding {
        public override void Request(Request Request) {
            }
        public override Response Response() {
            return null;
            }
        }

    
    // Query bindings work in the same way as connection bindings
    // This time there are three concrete bindings
    
    public abstract class QueryBinding : Binding {
        public virtual QResponse RequestResponse(QRequest RequestIn) {
            Request (RequestIn);
            return Response ();
            }

        public abstract void Request (QRequest Request);
        public abstract QResponse Response ();


        }
 
    // For debugging
    public class DirectQueryBinding : QueryBinding{
        public QueryServer      QueryServer;
        public List <BoundMessage> Messages = new List <BoundMessage> ();
        BoundMessage                     PendingResponse = null;

        public DirectQueryBinding(QueryServer QueryServerIn) {
            QueryServer = QueryServerIn;
            }

        public override void Request(QRequest Request) {
            BoundRequest BoundRequest = new BoundRequest (Request.ToString (), Cryptographic);
            Messages.Add (BoundRequest);
            Console.WriteLine (BoundRequest.HTTPBinding);
            PendingResponse =  QueryServer.Request (BoundRequest); 
            Messages.Add (PendingResponse);
            }

        public override QResponse Response() {
            QMessage Result = null; 
            Console.WriteLine (PendingResponse.HTTPBinding);
            QMessage.Deserialize (PendingResponse.Payload, out Result);
            return (QResponse) Result;
            }
        }  

    //// Web Service Transport
    //class WebServiceServer : QueryBinding {
    //    } 

    //// DNS Transport
    //class DNSQueryBinding : QueryBinding {
    //    } 

    //// UDP Transport
    //class UDPQueryBinding : QueryBinding {
    //    } 

    //// Tries to connect via the best available query binding
    //class BestQueryBinding : QueryBinding {
    //    } 

    }
