using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Goedel.Protocol;
using OBPConnection;
using OBPQuery;

namespace TestProtoGen {

    //public class CryptoContext {
    //    public byte[] Ticket;
    //    public Cryptography.Key Key;
    //    public Cryptography.Authentication Authentication;
    //    public Cryptography.Encryption Encryption;
    //    }

    public class ExampleData {
        public string                  OmnibrokerService = "example.com";
        public string                  Username = "alice";
        public string                  PIN;        

        public BoundMessage             OpenRequest;
        public BoundMessage             OpenResponse;
        public BoundMessage             TicketRequest;
        public BoundMessage             TicketResponse;

        public BoundMessage             UnbindRequest;
        public BoundMessage             UnbindResponse;



        public string            QueryConnectSite  = "http";
        public string            QueryConnectProtocol  = "www.example.com";
        public string QueryConnectURL {
            get { return QueryConnectProtocol + "://" + QueryConnectProtocol + "/"; }
            }

        public byte [] Certificate = {0, 1, 2, 3, 4};

        public BoundMessage             QueryConnectRequest;
        public BoundMessage             QueryConnectResponse;
        public BoundMessage             QueryValidateRequest;
        public BoundMessage             QueryValidateResponse;

        }


    class TestClient {
        OmnibrokerClient        OmnibrokerClient = null;

        TextWriter              Output = null;

        DirectServer  DirectServer = new DirectServer ();

        public ExampleData ExampleData = new ExampleData();
        // Generates the examples for the omnibroker draft

        public TestClient (TextWriter _Output) {
            
            Output = _Output;
         
            // Set up the connection to the client binding
            OmnibrokerClient = new TestOmnibrokerClient (DirectServer);

            ExampleData.PIN = DirectServer.ConnectionServer.GetPIN (ExampleData.OmnibrokerService, 
                ExampleData.Username);
            }

        public void GetBinding() {
            OmnibrokerClient.Bind (ExampleData.OmnibrokerService, ExampleData.Username, ExampleData.PIN);

            

            OmnibrokerClient.Refresh ();
            OmnibrokerClient.Unbind (); // Yes, should be last BWTF

            OmnibrokerClient.Connect (ExampleData.QueryConnectSite, 
                ExampleData.QueryConnectProtocol, 80);
            OmnibrokerClient.Validate (ExampleData.Certificate);

            StartExample ("GetBindingParameters");
            Output.WriteLine ("Create binding for account {0}@{1}", 
                    ExampleData.Username, ExampleData.OmnibrokerService);
            Output.WriteLine ("Preshared PIN is {0}", ExampleData.PIN);

            List<BoundMessage> ConnectionMessages = DirectServer.ConnectionBinding.Messages;
            List<BoundMessage> QueryMessages = DirectServer.WebBinding.Messages;

            ExampleData.OpenRequest = ConnectionMessages [0];
            ExampleData.OpenResponse = ConnectionMessages [1];
            ExampleData.TicketRequest = ConnectionMessages [2];
            ExampleData.TicketResponse = ConnectionMessages [3];
            ExampleData.UnbindRequest = ConnectionMessages [6];
            ExampleData.UnbindResponse = ConnectionMessages [7];
            
            ExampleData.QueryConnectRequest = QueryMessages [0];
            ExampleData.QueryConnectResponse = QueryMessages [1];
            ExampleData.QueryValidateRequest = QueryMessages [2];
            ExampleData.QueryValidateResponse = QueryMessages [3];

            Console.WriteLine ("********** HTTP binding");
            Console.WriteLine (ExampleData.OpenRequest.HTTPBinding);
            Console.WriteLine (ExampleData.OpenResponse.HTTPBinding);
            }

        public void RefreshTicket() {
            
            }


        public void DeleteBinding() {
            
            }


        // These will be MIME separators in due course
        void StartExample (string tag) {
            Output.WriteLine ("--------------");
            Output.WriteLine ("ID: {0}\n");
            Output.WriteLine ();
            }
        
        void EndExample () {
            Output.WriteLine ("--------------");
            }    
        }


    abstract class  OmnibrokerClient {

        public abstract void Bind (string Service, string Account, string PIN);
        public abstract void Refresh() ;
        public abstract void Unbind() ;

        public abstract void Connect(string Name, string Protocol, int port) ;
        public abstract void Validate(byte [] Certificate) ;

        protected QueryServerConnection [] QueryServers; 
        }

    class TestOmnibrokerClient : OmnibrokerClient {

        DirectServer Server;

        string DeviceID = "Serial:0002212";
        string DeviceURI = "http://comodo.com/dragon/v3.4";
        string DeviceName = "Comodo Dragon";

        List <string> Encryption = Cryptography.AuthenticationAlgorithms;
        List <string> Authentication = Cryptography.EncryptionAlgorithms;

        ConnectionBinding ConnectionBinding;

        public DirectQueryBinding              WebBinding;
        //public DirectQueryBinding              DNSBinding;
        //public DirectQueryBinding              UDPBinding;

        public TestOmnibrokerClient(DirectServer DirectServer) {
            Server = DirectServer;
            ConnectionBinding = Server.ConnectionBinding;
            WebBinding = Server.WebBinding;
            }

        public override void Bind (string Domain, string Account, string PIN) {
            byte [] Challenge = Cryptography.Nonce();

            OpenRequest OpenRequest = new OpenRequest ();
            OpenRequest.DeviceID = DeviceID;
            OpenRequest.DeviceURI = DeviceURI;
            OpenRequest.DeviceName = DeviceName;

            OpenRequest.Authentication = Authentication;
            OpenRequest.Encryption = Encryption;

            OpenRequest.Domain = Domain;
            OpenRequest.Account = Account;

            OpenRequest.HavePasscode = (PIN != null);
            OpenRequest.HaveDisplay = true;

            OpenRequest.Challenge = Challenge;

            OpenResponse ResponseOut = (OpenResponse) ConnectionBinding.RequestResponse (OpenRequest);

            // Check the server Response to our challenge here

            ConnectionBinding.SetCrypto (ResponseOut.Cryptographic[0]);
            TicketRequest TicketRequest = new TicketRequest ();
            TicketRequest.ChallengeResponse = Cryptography.ClientChallengeResponse(
                        PIN, Challenge, ResponseOut.Challenge, Cryptography.Authentication.Unknown); 

            TicketResponse ResponseOut2 =  (TicketResponse) ConnectionBinding.RequestResponse (TicketRequest);

            ConnectionBinding.SetCrypto (ResponseOut2.Cryptographic[0]);


            QueryServers = new QueryServerConnection [ResponseOut2.Service.Count];

            foreach (OBPConnection.Connection Connection in ResponseOut2.Service) {
                QueryServerConnection QueryServerConnection = new QueryServerConnection();

                Console.WriteLine("Got a connection to {0}, type {1}",
                        Connection.Name, Connection.Transport);

                if (Connection.Transport == "WebService") {
                    WebBinding.SetCrypto (Connection.Cryptographic);
                    }
                }


            // Need to add in all the rest of the parameters here
            
            //DNSBinding = new DirectQueryBinding (Transport.DNS);
            //UDPBinding = new DirectQueryBinding (Transport.UDP);
            }


        public override void Refresh() {
            TicketRequest TicketRequest = new TicketRequest ();
            TicketRequest.ChallengeResponse = Cryptography.Nonce(); // dummy this for now
            //TicketRequest.TicketData = ConnectionBinding.TicketData;

            // agh! gotta fake the authentication this time

            Response ResponseOut2 =  ConnectionBinding.RequestResponse (TicketRequest);
            }

        public override void Unbind() {
            UnbindRequest UnbindRequest = new UnbindRequest ();
            //UnbindRequest.TicketData = ConnectionBinding.TicketData;

            Response ResponseOut2 =  ConnectionBinding.RequestResponse (UnbindRequest);
            }


        public override void Connect(string Name, string Service, int Port) {
            Identifier Identifier = new Identifier ();
            Identifier.Name = Name;
            Identifier.Service = Service;
            Identifier.Port = Port;
            
            QueryConnectRequest QueryConnectRequest = new QueryConnectRequest ();
            QueryConnectRequest.Identifier = Identifier;

            QResponse ResponseOut = WebBinding.RequestResponse (QueryConnectRequest);
            }
        public override void Validate(byte [] Certificate) {
            ValidateRequest ValidateRequest = new ValidateRequest ();
            Credential Credential = new Credential ();
            Credential.Data = Certificate;
            Credential.Type = "application/x-x509-server-cert";

            ValidateRequest.Credential = Credential;

            QResponse ResponseOut = WebBinding.RequestResponse (ValidateRequest);
            }
        }
    }
