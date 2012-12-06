using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Omnibroker;
using Goedel.Registry;

// Store cryptographic keys and tickets

// Windows Platform

// Configuration file locations are stored as follows
//       HKEY_LOCAL_MACHINE\SOFTWARE\Comodo\Omnibroker
//          \Connect      Connection Server
//          \Query        Query Server
//
//       HKEY_CURRENT_USER\SOFTWARE\Comodo\Omnibroker
//          \Client       Client

// UNIX Platform
//       \etc\connect.conf
//       \etc\query.conf
//       ~\.trustprofile


namespace OmniBroker {
    public class Config {
        string                      Path;
        public Configure                   Configure;


        public Config () {
            Configure = new Configure ();
            }

        public Config (string PathIn) {
            Read (PathIn);
            }

        public void Read (string PathIn) {
            Path = PathIn;

            // Set up the parser
            Configure = new Configure ();

    		using (Stream infile =
                        new FileStream(Path, FileMode.Open, FileAccess.Read)) {
                // Create a new lexer
                Lexer Lexer = new Lexer(Path);
                // Call the lexer using the parser as the delegate
                Lexer.Process (infile, Configure);
                }
 
            Configure.Serialize (Console.Out);
            
            }

        public void Write() {
            Write (Path);
            }

        public void Write(string PathIn) {
            Configure.Serialize (Console.Out);

            using (Stream outfile = new FileStream(PathIn, FileMode.OpenOrCreate, FileAccess.Write)) {
                using (TextWriter writer = new StreamWriter (outfile)) {
                    Configure.Serialize (writer);
                    }
                }

            }

        public Connect GetConnect(string handle) {
            foreach (_Choice Choice in Configure.Top) {
                if (Choice._Tag() == ConfigureType.Connect) {
                    Connect Entry = (Connect) Choice;
                    if (handle == null | (Entry.Id.ToString() == handle)) {
                        return Entry;
                        }
                    }
                }
            throw new Exception("Handle not found");
            }

        public Query GetQuery(string handle) {
            foreach (_Choice Choice in Configure.Top) {
                if (Choice._Tag() == ConfigureType.Query) {
                    Query Entry = (Query) Choice;
                    if (handle == null | (Entry.Id.ToString() == handle)) {
                        return Entry;
                        }
                    }
                }
            throw new Exception ("Handle not found");
            }

        }
    }
