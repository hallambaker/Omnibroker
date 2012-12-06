using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Omnibroker;

namespace OBPClient {
    public partial class OBPClient {
        public override void Bind(Bind Options) {
            Console.WriteLine ("Bind Account:{0} PIN:{1}", 
                Options.Account.Value, Options.PIN.Value);

            TicketBroker TicketBroker = new TicketBroker () ;

            TicketBroker.Bind (Options.Account.Value, Options.PIN.Value);

            }

        public override void Unbind(Unbind Options) {
            base.Unbind(Options);
            }
        
        public override void Resolve(Resolve Options) {
            base.Resolve(Options);
            }
        }
    }
