using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Omnibroker;
using Goedel.Protocol;
using OBPConnection;

namespace Omnibroker {

    public class TicketBroker {
        List <string> Encryption = Cryptography.EncryptionAlgorithms;
        List <string> Authentication = Cryptography.AuthenticationAlgorithms;

        public void Bind(string Acct, string PIN) {
            string Domain = "localhost";
            int Port = 8080;
            WebServiceClient Client = new WebServiceClient(Domain, Port, null);

            OpenRequest OpenRequest = new OpenRequest () ;
            OpenRequest.Account = Account.User (Acct);
            OpenRequest.Domain = Account.Domain (Acct);;
            OpenRequest.HavePasscode = true;
            OpenRequest.HaveDisplay = false;
            OpenRequest.Encryption = Encryption;
            OpenRequest.Authentication = Authentication;
            OpenRequest.Challenge = Cryptography.Nonce ();
            string RequestData = OpenRequest.ToString ();

            // perform the request and wait for response
            string Result = Client.Request(RequestData);

            // Parse the result
            OpenResponse OpenResponse;
            OpenResponse.Deserialize (Result, out OpenResponse);
            
            if (OpenResponse.Cryptographic != null) {
                foreach (Cryptographic Crypto in OpenResponse.Cryptographic) {
                    CryptographicContext Context = CryptographicContext.MakeCryptographicContext (
                        Crypto.Ticket, Crypto.Secret, Crypto.Authentication, Crypto.Encryption);
                    if (Context != null) {
                        Client.CryptographicContext = Context;
                        break;
                        }
                    }
                if (Client.CryptographicContext == null) {
                    throw new Exception ("No supported algorithm");
                    }
                }

            TicketRequest TicketRequest = new TicketRequest ();
            TicketRequest.ChallengeResponse = Cryptography.ClientChallengeResponse (
                PIN, OpenRequest.Challenge, OpenResponse.Challenge, Cryptography.Authentication.Unknown);

            RequestData = TicketRequest.ToString ();
            Result =  Client.Request(RequestData);

            TicketResponse TicketResponse = new TicketResponse (Result);

            Console.WriteLine ("Result is");
            Console.WriteLine (Result);
            }

        public void Write() {
            Console.WriteLine ("Save binding to Windows registry");
            }
        public void Delete() {
            Console.WriteLine ("Erase binding from Windows registry");
            }
        public void Read() {
            Console.WriteLine ("Load binding to Windows registry");
            }
        }
    }
