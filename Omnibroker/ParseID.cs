using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Omnibroker {
    public class Account {
        public static string User(string ID) {
            int At = ID.IndexOf ('@');
            if (At < 1) {
                throw new Exception ("Bad account specifier");
                }

            return ID.Substring (0,At);
            }
        public static string Domain(string ID) {
            int At = ID.IndexOf ('@');
            if (At < 1) {
                throw new Exception ("Bad account specifier");
                }
            return ID.Substring (At+1);
            }
        }
    }
