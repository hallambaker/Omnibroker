

using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Goedel.Protocol;
using TestProtoGen;



namespace OBPConnection {

    abstract public partial class Response : Message {

        }


    abstract public partial class Request : Message {
        public TicketData TicketData;

        public virtual bool Authenticate() {
            return true;
            }

        public virtual Response Dispatch(ConnectionServerContext ConnectionServerContext,
                        TicketData TicketData) {
            return null;
            }
        }


    // Implement open binding requests as follows
    //
    // Initial requests to create an account require passcode authentication
    // 
    public partial class OpenRequest : BindRequest {
        public override bool Authenticate() {
            return false;
            }

        public override Response Dispatch(ConnectionServerContext Context,
                            TicketData TicketData) {
            OpenResponse Response = new OpenResponse();

            Account AccountData = Context.GetAccount (Account, Domain);

            Cryptography.Authentication AuthenticationAlg = Context.GetAuthentication (Authentication);

            if (HavePasscode) {
                Response.Challenge = Cryptography.Nonce (16); // 128 bit challenge
                string PIN = Context.GetPIN (Account, Domain); // calculate the PIN

                Response.ChallengeResponse = Cryptography.ServerChallengeResponse (PIN, 
                                    Challenge, AuthenticationAlg);
                // What is the algorithm here?


                Response.Status = 203;
                Response.StatusDescription = "Passcode";
                Response.Cryptographic = new List<Cryptographic>();

                // Create a temporary ticket
                TemporaryTicketData Ticket = new TemporaryTicketData () ;
                Ticket.Domain = Domain;
                Ticket.Account = Account;
                Ticket.Authentication = Context.GetAuthentication (Authentication);
                Ticket.Encryption = Context.GetEncryption (Encryption);
                Ticket.ClientChallenge = Challenge;
                Ticket.ServerChallenge = Response.Challenge;


                Response.Cryptographic.Add (Context.GetCryptographic (Ticket, null));
                }

            return Response;
            }
        }



    public partial class TicketRequest : Request {
        public override Response Dispatch(ConnectionServerContext Context,
                        TicketData TicketData) {
            
            // check the client Response to the joint challenge here
            // oops, kinda need to fish out the data from the ticket!

            TicketData ConnectionTicket = new TicketData () ;
            ConnectionTicket.Domain = TicketData.Domain;
            ConnectionTicket.Account = TicketData.Account;
            ConnectionTicket.Authentication = TicketData.Authentication;
            ConnectionTicket.Encryption = TicketData.Encryption;
            
            TicketResponse Response = new TicketResponse();
            Response.Cryptographic = new List<Cryptographic>();
            Response.Cryptographic.Add (Context.GetCryptographic (ConnectionTicket, "OBPConnection"));
            Response.Status = 200;
            Response.StatusDescription = "Complete";
            Response.Service = new List<Connection> ();

            foreach (MasterQueryServerConnection ServerConnection in Context.QueryServers) {
                Connection Connection = new Connection ();
                Connection.Name = ServerConnection.Domain;
                Connection.Port = ServerConnection.Port;
                Connection.Address = ServerConnection.Address;
                Connection.Priority = ServerConnection.Priority;
                Connection.Weight =ServerConnection.Weight;
                Connection.Transport = Converter.ToString (ServerConnection.Transport);

                TicketData QueryTicket = new TicketData () ;
                QueryTicket.Domain = TicketData.Domain;
                QueryTicket.Account = TicketData.Account;
                QueryTicket.Authentication = TicketData.Authentication;
                QueryTicket.Encryption = TicketData.Encryption;

                Connection.Cryptographic = Context.GetCryptographic (QueryTicket, "OBPQuery",
                    QueryTicket.GetTicket (ServerConnection.MasterSeed));

                Response.Service.Add (Connection);
                }

            return Response;
            }
        }


    public partial class UnbindRequest : Request {
        public override Response Dispatch(ConnectionServerContext Context,
                        TicketData TicketData) {
            UnbindResponse Response = new UnbindResponse();
            return Response;
            }
        }



    // We don't use these for now, leave them as stubs in case of future need
    abstract public partial class Message { }
    abstract public partial class BindRequest : Request { }
    abstract public partial class BindResponse : Response { }
    public partial class OpenResponse : BindResponse { }
    public partial class TicketResponse : BindResponse { }
    public partial class UnbindResponse : Response { }
    }

