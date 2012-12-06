using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Goedel.Protocol;
using TestProtoGen;

namespace OBPQuery {


    public partial class Connection {

        public Connection(string _IPAddress, int _Port, string _Transport,
                    string _TransportPolicy, string _ProtocolPolicy) {
            IPAddress = _IPAddress ;
            IPPort = _Port;
            Transport = _Transport;
            TransportPolicy = _TransportPolicy;
            ProtocolPolicy = _ProtocolPolicy;
            }
        }


    abstract public partial class QResponse : QMessage {
        public String      StatusDescription = "";
        }


    // Define dispatcher for the abstract class, this will be overriden by
    // code for each Request as it is implemented.

    abstract public partial class QRequest : QMessage {
        public TicketData TicketData;

        // Does Request require authentication?
        // Override to return false in derrived class if not
        public virtual bool Authenticate() {
            return false;
            }

        public virtual QResponse Dispatch(QueryServerContext ConnectionServerContext,
                        TicketData TicketData) {
            return null;
            }
        }

    public partial class QueryConnectRequest : QRequest {

        public override QResponse Dispatch(QueryServerContext Context,
                        TicketData TicketData) {
            QueryConnectResponse Response = new QueryConnectResponse();

            // If we were doing this properly we would do a DNS lookup 
            // (via a cache of course) to resolve the parameters here


            Response.Connection = new List<Connection> ();

            Response.Connection.Add (new Connection (
                "10.3.2.1", 443, "TLS", "TLS=Optional", "Strict"));
            Response.Connection.Add (new Connection ("10.3.2.1", 80, null, null, "Strict"));
            Response.Status = 200;

            return Response;
            }
        }

    public partial class ValidateRequest : QRequest {

        public override QResponse Dispatch(QueryServerContext Context,
                    TicketData TicketData) {
            ValidateResponse Response = new ValidateResponse();
            Response.Status = 200;

            return Response;
            }
        }

    public partial class AdvertiseRequest : QRequest {

        public override QResponse Dispatch(QueryServerContext Context,
                    TicketData TicketData) {
            AdvertiseResponse Response = new AdvertiseResponse();

            return Response;
            }
        }

    public partial class CredentialPasswordRequest : QRequest {

        public override QResponse Dispatch(QueryServerContext Context,
                    TicketData TicketData) {
            CredentialPasswordResponse Response = new CredentialPasswordResponse();

            return Response;
            }
        }

    }
