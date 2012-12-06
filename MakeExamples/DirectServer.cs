using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Goedel.Protocol;
using OBPConnection;
using OBPQuery;

namespace TestProtoGen {
    public class DirectServer {
        public ConnectionServer     ConnectionServer;

        public QueryServer                     WebQuery;
        public QueryServer                     DNSQuery;
        public QueryServer                     UDPQuery;

        public DirectConnectionBinding         ConnectionBinding;

        public DirectQueryBinding              WebBinding;
        public DirectQueryBinding              DNSBinding;
        public DirectQueryBinding              UDPBinding;

        public DirectServer() {
            ConnectionServer = new ConnectionServer ("Example.com");
            

            WebQuery = new QueryServer(Transport.WebService, "obp1.example.com", "10.1.2.3", 443, 1, 100);
            ConnectionServer.AddQueryServer(
                WebQuery.QueryServerConnection, WebQuery.MasterSeed);

            DNSQuery = new QueryServer(Transport.DNS, "dns1.example.com", "10.1.2.2", 53, 1, 100);
            ConnectionServer.AddQueryServer(
                DNSQuery.QueryServerConnection, DNSQuery.MasterSeed);

            UDPQuery = new QueryServer(Transport.UDP, "udp.example.com", "10.1.2.2", 5000, 1, 100);
            ConnectionServer.AddQueryServer(
                UDPQuery.QueryServerConnection, UDPQuery.MasterSeed);
            
            ConnectionBinding = new DirectConnectionBinding (ConnectionServer);

            WebBinding = new DirectQueryBinding (WebQuery);          
            DNSBinding = new DirectQueryBinding (DNSQuery);
            UDPBinding = new DirectQueryBinding (UDPQuery);
            }
        }
    }
