using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OBPConnect;
using Omnibroker;
using TestProtoGen;
using Goedel.Protocol;

namespace OBPConnect {
    public partial class OBPConnect {
        public override void PIN(PIN Options) {
            Console.WriteLine ("Pin file {0} account {1}", Options.Configuration,
                    Options.Account);
            OmniBroker.Config Config = new OmniBroker.Config (Options.Configuration.Value);
            Connect Connect = Config.GetConnect (Options.Handle.Text);

            Seed LatestSeed = Connect.Secrets.First ();
            if (LatestSeed == null) throw new Exception ("Cryptographic seed not initialized");

            string PIN = Cryptography.MakePin (Options.Account.Value, LatestSeed.MasterSeed.KeyData, 8);
            Console.WriteLine ("PIN value for account {0} is {1}", Options.Account, PIN);
            Console.WriteLine ("   Will expire on [TBS]");
            }

        // 
        public override void Initialize(Initialize Options) {
            Console.WriteLine ("Create configuration file {0}", Options.Configuration);
            OmniBroker.Config Config = new OmniBroker.Config (Options.Configuration.Value);

            Connect Connect = Config.GetConnect (Options.Handle.Text);

            Seed NewSeed = new Seed (Convert.ToInt32 (Options.Refresh.Value));
            Connect.Secrets.Insert (0, NewSeed);
            Config.Write (Options.Configuration.Value);

            }
        public override void Server(Server Options) {
            Console.WriteLine ("Launch the server using configuration file {0}",
                    Options.Configuration);

            
            OmniBroker.Config Config = new OmniBroker.Config (Options.Configuration.Value);

            Connect Connect = Config.GetConnect (Options.Handle.Text);


            // Here we need to change Connection Server to pass in the 
            // Connection server description.
            ConnectionServer ConnectionServer = new ConnectionServer (Connect);

            WebServiceServer WebService = new WebServiceServer ();
            // Connect.Domain
            WebService.RegisterService ("*", Connect.Port.Data, null, 
                ConnectionServer);

            WebService.Listener ();
            }

        }
    }
