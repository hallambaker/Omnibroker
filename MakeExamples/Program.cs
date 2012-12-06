using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using Goedel.Protocol;
using Goedel.Registry;
using OBPConnection;
using TestProtoGen;
using OmnibrokerExample;

namespace GoedelShell {

    
    class Program {

        //public override void About(About Options) {
        //    FileTools.About ();
        //    }

        static void Main(string[] args) {
            TestClient TestClient = new TestClient (Console.Out);

            TestClient.GetBinding ();
            TestClient.RefreshTicket ();
            TestClient.DeleteBinding ();

            WrapWriter WrapWriter;
            Generate Generate;

            //WrapWriter = new WrapWriter (Console.Out);
            //Generate = new Generate (WrapWriter);
            //Generate.ConnectionExample (TestClient.ExampleData);

            //WrapWriter = new WrapWriter(Console.Out);
            //Generate = new Generate(WrapWriter);
            //Generate.QueryExample(TestClient.ExampleData);

            if (args.Length > 0) {
                using (TextWriter TextWriter = new StreamWriter(args[0])) {
                    WrapWriter = new WrapWriter(TextWriter);
                    Generate = new Generate(WrapWriter);
                    Generate.ConnectionExample(TestClient.ExampleData);
                    }
                }

            if (args.Length > 1) {
                using (TextWriter TextWriter = new StreamWriter(args[1])) {
                    WrapWriter = new WrapWriter(TextWriter);
                    Generate = new Generate(WrapWriter);
                    Generate.QueryExample(TestClient.ExampleData);
                    }
                }
            if (args.Length > 2) {
                using (TextWriter TextWriter = new StreamWriter(args[2])) {
                    WrapWriter = new WrapWriter(TextWriter);
                    Generate = new Generate(WrapWriter);
                    Generate.MutualAuth(TestClient.ExampleData);
                    }
                }
            
            }
        }


    }
