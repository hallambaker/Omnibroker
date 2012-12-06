using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Goedel.Protocol;

namespace Goedel.Protocol {
    public class CryptographicContext {
        public byte[] Ticket;
        public Cryptography.Key Key;
        public Cryptography.Authentication Authentication;
        public Cryptography.Encryption Encryption;

        public static CryptographicContext MakeCryptographicContext(
            byte[] TicketIn, byte[] KeyIn,
            string AuthenticationIn, string EncryptionIn) {

            Cryptography.Authentication Authentication =
                    Cryptography.AuthenticationCode(AuthenticationIn);
            Cryptography.Encryption Encryption =
                    Cryptography.EncryptionCode(EncryptionIn);

            if (Authentication == Cryptography.Authentication.Unknown) return null;
            if (Encryption == Cryptography.Encryption.Unknown) return null;

            return new CryptographicContext(TicketIn, KeyIn, Authentication, Encryption);
            }

        public CryptographicContext(
            byte[] TicketIn, byte[] KeyIn,
            Cryptography.Authentication AuthenticationIn,
            Cryptography.Encryption EncryptionIn) {
            Ticket = TicketIn;
            Key = new Cryptography.Key(KeyIn, AuthenticationIn, EncryptionIn);
            Authentication = AuthenticationIn;
            Encryption = EncryptionIn;
            }

        public byte[] MAC(byte[] data) {

            return Cryptography.GetMAC(data, data.Length, Authentication, Key);
            }

        public string GetIntegrityHeader(byte[] data) {
            return "Integrity: mac=" + Convert.ToBase64String(MAC(data))
                + "; ticket=" + Convert.ToBase64String(Ticket);
            }

        public static void ParseIntegrityHeader(string Header, out byte[] Mac, out byte[] Ticket) {
            int Start = 0;
            int state = 0;
            int Tag = -1;
            Mac = null;
            Ticket = null;
            for (int i = 0; i < Header.Length; i++) {
                char c = Header[i];
                switch (state) {
                    case 0: {
                            if (c == ':') state = 1;
                            break;
                            }
                    case 1:
                        if ((c != ' ') & (c != '\t')) {
                            state = 2;
                            Start = i;
                            }
                        break;
                    case 2:
                        if (c == '=') {
                            string s = Header.Substring (Start, i-Start);
                            if (s == "mac") Tag = 0;
                            else if (s == "ticket") Tag = 1;
                            state = 3;
                            Start = i+1;
                            }
                        break;
                    case 3:
                        if (c == ' ' | c == '\t' | i + 1 == Header.Length) {
                            string s = Header.Substring (Start, i-Start);
                            if (Tag == 0) {
                                Mac = Convert.FromBase64String(s);
                                }
                            if (Tag == 1) {
                                Ticket = Convert.FromBase64String(s);
                                }
                            }
                        break;
                    }
                }
            }
        }
    }
