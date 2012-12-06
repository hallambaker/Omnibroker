using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Goedel.Protocol;
using OBPConnection;
using OBPQuery;
using Omnibroker;

namespace TestProtoGen {

    public class Account {
        string Domain;
        string ID;
        }

    //
    //  ServerContext is the class from which all Server Contexts are
    //  inherited, it contains utility functions for managing tickets
    //

    public class ServerContext {
        public string Domain;
        public Cryptography.Authentication Authentication;

        public Cryptography.Key MasterSeed;

        public TicketData GetTicketData(byte [] Ticket) {
            return TicketData.MakeTicket (Ticket, MasterSeed);
            }

        public bool VerifyTicket(byte[] Ticket) {
            return TicketData.VerifyTicket (Ticket, MasterSeed);
            }


        public Cryptography.Encryption GetEncryption (List<string> Algs) {
            return Cryptography.Encryption.A128CBC;
            }

        public Cryptography.Authentication GetAuthentication (List<string> Algs) {
            if (Algs.Count == 0) {
                return Cryptography.Authentication.HS256;
                }
            else {
                // Well we could support other algorithms but we don't
                return Cryptography.Authentication.HS256;
                //return Algs [0];
                }
            }

        public ServerContext() {
            InitServerContext (Cryptography.Authentication.HS256T128);
            }

        protected void InitServerContext(Cryptography.Authentication AuthenticationIn) {
            Authentication = AuthenticationIn;
            MasterSeed = new Cryptography.Key (Authentication);
            }

        }

    public abstract class Server {
        protected static BoundResponse ErrorBadMac = 
                new BoundResponse (401, "Not Authorized");
        protected static BoundResponse ErrorUnknown = new 
                BoundResponse (500, "Internal Server Error");
        protected static BoundResponse ErrorSyntax = 
                new BoundResponse (400, "Bad Request");

        public abstract BoundResponse Request(BoundRequest BoundRequest);
        }



    public class ConnectionServerContext : ServerContext {
        
        public byte[] PINSeed = Cryptography.Nonce();

        public List<MasterQueryServerConnection> QueryServers = 
            new List<MasterQueryServerConnection>();


        public ConnectionServerContext () {
            InitServerContext (Cryptography.Authentication.HS256);
            }

        // Only a connection server issues PIN challenges
        public string GetPIN(string Domain, string Account) {
            string Text = Account + "@" + Domain;

            return Cryptography.MakePin(Text, PINSeed, 10);
            }

        public Account GetAccount(string Domain, string Account) {
            return null;
            }

        public Cryptographic GetCryptographic(TicketData Ticket, String Protocol) {
            return GetCryptographic (Ticket, Protocol, Ticket.GetTicket (MasterSeed));
            }

        public Cryptographic GetCryptographic(TicketData TicketData, String Protocol, byte [] Ticket) {
            Cryptographic Result = new Cryptographic ();

            // Fill in the Response structures
            Result.Authentication = Cryptography.AuthenticationCode (TicketData.Authentication);
            Result.Encryption = Cryptography.EncryptionCode (TicketData.Encryption);
            Result.Secret = TicketData.MasterKey.KeyData;
            Result.Protocol = Protocol;
            Result.Ticket = Ticket;

            return Result;
            }

        public void AddQueryServer(QueryServerConnection Description, Cryptography.Key MasterSeed) {
            MasterQueryServerConnection Connection;
            Connection = (MasterQueryServerConnection) Description;
            Connection.MasterSeed = MasterSeed;

            QueryServers.Add(Connection);
            }
        }

    public class ConnectionServer : Server {
        ConnectionServerContext Context = new ConnectionServerContext ();

        public ConnectionServer(string DomainIn) {
            Context.Domain = DomainIn;
            }

        public ConnectionServer(Connect Connect) {
            Context.Domain = Connect.Domain;
            // load up the details from the config file
            Context.PINSeed = Convert.FromBase64String(Connect.Secrets [0].Data);

            }

        public string GetPIN(string Domain, string Account) {
            return Context.GetPIN(Domain, Account);
            }

        public void AddQueryServer(QueryServerConnection Description, Cryptography.Key MasterSeed) {
            Context.AddQueryServer(Description, MasterSeed);
            }

        // The main processing loop
        // 
        // Unlike in normal C# we do not throw exceptions, instead we return 
        // an error code to the calling client

        public override BoundResponse Request(BoundRequest BoundRequest) {
            bool Authenticated = false;
            Response Response = null;
            TicketData TicketData = null;

            try {
                if (BoundRequest.Ticket != null) {
                    TicketData = Context.GetTicketData (BoundRequest.Ticket);
                    // Check that the MAC code evaluates under the ticket
                    //
                    bool valid = true; //BoundRequest.VerifyMAC(TicketData.Authentication, TicketData.MasterKey);
                    if (!valid) {
                        return ErrorBadMac;
                        }
                    Authenticated = true;
                    }

                Request Request;
                try {
                    Request.Deserialize(BoundRequest.Payload, out Request);
                    Request.TicketData = TicketData;
                    }
                catch {
                    return ErrorSyntax;
                    }

                // The only time we will accept a message without authentication
                // is if it is an initial connection
                if (!Authenticated & Request.Authenticate ()) {
                    return ErrorBadMac;
                    }

                Response = Request.Dispatch (Context, TicketData);

                if (Response == null) {
                    return ErrorUnknown;
                    }

                BoundResponse BoundResponse;
                if (TicketData == null) {
                    BoundResponse = new BoundResponse  (Response.ToString());
                    }
                else {
                    BoundResponse = new BoundResponse (Response.ToString(), 
                        BoundRequest.Ticket, TicketData.Authentication, TicketData.MasterKey);
                    }

                BoundResponse.Status = Response.Status;
                BoundResponse.StatusDescription = Response.StatusDescription;

                return BoundResponse;
                }
            catch {
                return ErrorUnknown;
                }
            }
        }





    public class QueryServerConnection {
        public Transport Transport;  // Web Service, UDP or DNS
        public string Domain;
        public int Port;
        public string Address;
        public int Priority;
        public int Weight;

        public byte [] Ticket;
        }

    public class MasterQueryServerConnection : QueryServerConnection{
        public Cryptography.Key    MasterSeed;
        }


    public class QueryServerContext : ServerContext {

        public QueryServerContext(MasterQueryServerConnection Connection) {
            InitServerContext (Cryptography.Authentication.HS256T128);
            }

        }


    public  class QueryServer : Server  {
        QueryServerContext Context;
        public MasterQueryServerConnection QueryServerConnection;

        RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();

        public Cryptography.Key MasterSeed {
            get { return Context.MasterSeed;}}

        // Expire the old seed immediately
        public DateTime OldSeedExpiry = DateTime.MinValue ;

        Transport   Transport;

        public QueryServer(Transport TransportIn, string Domain, string Address, int Port,
                        int Priority, int Weight) {
            // set transport
            Transport = TransportIn;

            // Set up the QueryServerConnection
            QueryServerConnection = new MasterQueryServerConnection ();
            QueryServerConnection.Transport = TransportIn;
            QueryServerConnection.Domain = Domain;
            QueryServerConnection.Address = Address;
            QueryServerConnection.Port = Port;
            QueryServerConnection.Priority = Priority;
            QueryServerConnection.Weight = Weight;

            Context = new QueryServerContext (QueryServerConnection);

            QueryServerConnection.MasterSeed = MasterSeed;
            }


        public override BoundResponse Request(BoundRequest BoundRequest) {
            bool Authenticated = false;
            QResponse Response = null;
            TicketData TicketData = null;

            try {
                if (BoundRequest.Ticket != null) {
                    TicketData = Context.GetTicketData (BoundRequest.Ticket);
                    Authenticated = true; // Otherwise an exception would have been thrown
                    }

                QRequest Request;
                try {
                    QRequest.Deserialize(BoundRequest.Payload, out Request);
                    Request.TicketData = TicketData;
                    }
                catch {
                    return ErrorSyntax;
                    }

                // The only time we will accept a message without authentication
                // is if it is an initial connection
                if (!Authenticated & Request.Authenticate ()) {
                    return ErrorBadMac;
                    }

                Response = Request.Dispatch (Context, TicketData);

                if (Response == null) {
                    return ErrorUnknown;
                    }

                BoundResponse BoundResponse;
                if (TicketData == null) {
                    BoundResponse = new BoundResponse(Response.ToString());
                    }
                else {
                    BoundResponse = new BoundResponse(Response.ToString(), 
                        BoundRequest.Ticket, TicketData.Authentication, TicketData.MasterKey);
                    }
                BoundResponse.Status = Response.Status;
                BoundResponse.StatusDescription = Response.StatusDescription;
                return BoundResponse;
                }
            catch {
                return ErrorUnknown;
                }
            }
        }


    public enum Transport {
        WebService,
        DNS,
        UDP,
        Null
        };

    public partial class Converter {

        public static Transport ToTransport (string label) {
            if (label == "WebService") return Transport.DNS;
            if (label == "DNS") return Transport.UDP;
            if (label == "UDP") return Transport.WebService;
            return Transport.Null;
            }

        public static string ToString(Transport label) {
            if (label == Transport.DNS) return "DNS";
            if (label == Transport.UDP) return "UDP";
            if (label == Transport.WebService) return "WebService";
            return "Null";
            }

        }

    }
