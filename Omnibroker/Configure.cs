﻿
//  Test
//  
//  This file was automatically generated at 9/10/2012 5:51:54 PM
//   
//  Changes to this file may be overwritten without warning
//  
//  Generator:  GoedelShell version 1.0.0.0
//      Goedel Script Version : 0.1   Generated 
//      Goedel Schema Version : 0.1   Generated
//  
//      Copyright : Copyright ©  2011
//  
//  Build Platform: Win32NT 6.1.7601.65536
//  
//  
// This file is automatically generated from the following source files:
// Command line options: 
//     /dlexer=False
//     /dparser=False
//     /dstack=False

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Goedel.Registry;


//
// Namespace Omnibroker
// Class Configure
//


// Types
//   TopTypeType
//       Connect
//       Query
//       Client
//   TypeType
//       Seed
//       Encryption
//       Authentication
//       Administrator
//       Scope
//       Connection
//       Address
//   IdType
//       Handle
//   NamespaceType
//       Omnibroker
//   ClassType
//       Configure
//   NameType
//       Id
//       Domain
//       Options
//       Port
//       Secrets
//       EncryptionAlgorithms
//       AuthenticationAlgorithms
//       Administrators
//       Secret
//       Account
//       Service
//       Scopes
//       Ticket
//       EncryptionAlgorithm
//       AuthenticationAlgorithm
//       Expires
//       Connections
//       Data
//       Expiry
//       IP
//       Algorithm
//   TokenType

namespace Omnibroker {


    public enum ConfigureType {
        _Top,

        Connect,
        Query,
        Client,
        Administrator,
        Connection,
        Seed,
        Secret,
        Ticket,
        Port,
        Address,
        Scope,
        Expires,
        Encryption,
        Authentication,

        _Label,
        _Bottom
        }    
    

    public abstract partial class _Choice {
        abstract public ConfigureType _Tag ();

		public abstract void Serialize (StructureWriter Output, bool tag);
        }



    public partial class Connect : _Choice {
        public ID<_Choice>				Id; 
		public string					Domain;
		public Port  Port = new  Port();
		public List<Seed>  Secrets = new  List <Seed> ();
		public List<Encryption>  EncryptionAlgorithms = new  List <Encryption> ();
		public List<Authentication>  AuthenticationAlgorithms = new  List <Authentication> ();
		public List<Administrator>  Administrators = new  List <Administrator> ();

        public override ConfigureType _Tag () {
            return ConfigureType.Connect;
            }

		public override void Serialize (StructureWriter Output, bool tag) {

			if (tag) {
				Output.StartElement ("Connect");
				}

	        Output.WriteId ("Id", Id.ToString()); 
			Output.WriteAttribute ("Domain", Domain);
			Output.StartList ("");
		// public Port  Port = new  Port();
			Port.Serialize (Output, true);
			foreach (Seed _e in Secrets) {
				_e.Serialize (Output, true);
				}
			foreach (Encryption _e in EncryptionAlgorithms) {
				_e.Serialize (Output, true);
				}
			foreach (Authentication _e in AuthenticationAlgorithms) {
				_e.Serialize (Output, true);
				}
			foreach (Administrator _e in Administrators) {
				_e.Serialize (Output, true);
				}
			Output.EndList ("");
			if (tag) {
				Output.EndElement ("Connect");
				}			
			}
		}

    public partial class Query : _Choice {
        public ID<_Choice>				Id; 
		public List<Seed>  Secret = new  List <Seed> ();

        public override ConfigureType _Tag () {
            return ConfigureType.Query;
            }

		public override void Serialize (StructureWriter Output, bool tag) {

			if (tag) {
				Output.StartElement ("Query");
				}

	        Output.WriteId ("Id", Id.ToString()); 
			Output.StartList ("");
			foreach (Seed _e in Secret) {
				_e.Serialize (Output, true);
				}
			Output.EndList ("");
			if (tag) {
				Output.EndElement ("Query");
				}			
			}
		}

    public partial class Client : _Choice {
        public ID<_Choice>				Id; 
		public string					Account;
		public string					Service;
		public List<Scope>  Scopes = new  List <Scope> ();
		public Secret  Secret = new  Secret();
		public Ticket  Ticket = new  Ticket();
		public Encryption  EncryptionAlgorithm = new  Encryption();
		public Authentication  AuthenticationAlgorithm = new  Authentication();
		public Expires  Expires = new  Expires();
		public List<Connection>  Connections = new  List <Connection> ();

        public override ConfigureType _Tag () {
            return ConfigureType.Client;
            }

		public override void Serialize (StructureWriter Output, bool tag) {

			if (tag) {
				Output.StartElement ("Client");
				}

	        Output.WriteId ("Id", Id.ToString()); 
			Output.WriteAttribute ("Account", Account);
			Output.WriteAttribute ("Service", Service);
			Output.StartList ("");
			foreach (Scope _e in Scopes) {
				_e.Serialize (Output, true);
				}
		// public Secret  Secret = new  Secret();
			Secret.Serialize (Output, true);
		// public Ticket  Ticket = new  Ticket();
			Ticket.Serialize (Output, true);
		// public Encryption  EncryptionAlgorithm = new  Encryption();
			EncryptionAlgorithm.Serialize (Output, true);
		// public Authentication  AuthenticationAlgorithm = new  Authentication();
			AuthenticationAlgorithm.Serialize (Output, true);
		// public Expires  Expires = new  Expires();
			Expires.Serialize (Output, true);
			foreach (Connection _e in Connections) {
				_e.Serialize (Output, true);
				}
			Output.EndList ("");
			if (tag) {
				Output.EndElement ("Client");
				}			
			}
		}

    public partial class Administrator : _Choice {
		public string					Account;

        public override ConfigureType _Tag () {
            return ConfigureType.Administrator;
            }

		public override void Serialize (StructureWriter Output, bool tag) {

			if (tag) {
				Output.StartElement ("Administrator");
				}

			Output.WriteAttribute ("Account", Account);
			if (tag) {
				Output.EndElement ("Administrator");
				}			
			}
		}

    public partial class Connection : _Choice {
		public List<Scope>  Scopes = new  List <Scope> ();
		public Secret  Secret = new  Secret();
		public Ticket  Ticket = new  Ticket();
		public Encryption  EncryptionAlgorithm = new  Encryption();
		public Authentication  AuthenticationAlgorithm = new  Authentication();
		public Expires  Expires = new  Expires();

        public override ConfigureType _Tag () {
            return ConfigureType.Connection;
            }

		public override void Serialize (StructureWriter Output, bool tag) {

			if (tag) {
				Output.StartElement ("Connection");
				}

			Output.StartList ("");
			foreach (Scope _e in Scopes) {
				_e.Serialize (Output, true);
				}
		// public Secret  Secret = new  Secret();
			Secret.Serialize (Output, true);
		// public Ticket  Ticket = new  Ticket();
			Ticket.Serialize (Output, true);
		// public Encryption  EncryptionAlgorithm = new  Encryption();
			EncryptionAlgorithm.Serialize (Output, true);
		// public Authentication  AuthenticationAlgorithm = new  Authentication();
			AuthenticationAlgorithm.Serialize (Output, true);
		// public Expires  Expires = new  Expires();
			Expires.Serialize (Output, true);
			Output.EndList ("");
			if (tag) {
				Output.EndElement ("Connection");
				}			
			}
		}

    public partial class Seed : _Choice {
		public string					Data;
		public string					Expiry;

        public override ConfigureType _Tag () {
            return ConfigureType.Seed;
            }

		public override void Serialize (StructureWriter Output, bool tag) {

			if (tag) {
				Output.StartElement ("Seed");
				}

			Output.WriteAttribute ("Data", Data);
			Output.WriteAttribute ("Expiry", Expiry);
			if (tag) {
				Output.EndElement ("Seed");
				}			
			}
		}

    public partial class Secret : _Choice {
		public string					Data;

        public override ConfigureType _Tag () {
            return ConfigureType.Secret;
            }

		public override void Serialize (StructureWriter Output, bool tag) {

			if (tag) {
				Output.StartElement ("Secret");
				}

			Output.WriteAttribute ("Data", Data);
			if (tag) {
				Output.EndElement ("Secret");
				}			
			}
		}

    public partial class Ticket : _Choice {
		public string					Data;

        public override ConfigureType _Tag () {
            return ConfigureType.Ticket;
            }

		public override void Serialize (StructureWriter Output, bool tag) {

			if (tag) {
				Output.StartElement ("Ticket");
				}

			Output.WriteAttribute ("Data", Data);
			if (tag) {
				Output.EndElement ("Ticket");
				}			
			}
		}

    public partial class Port : _Choice {
		public int						Data;

        public override ConfigureType _Tag () {
            return ConfigureType.Port;
            }

		public override void Serialize (StructureWriter Output, bool tag) {

			if (tag) {
				Output.StartElement ("Port");
				}

			Output.WriteAttribute ("Data", Data);
			if (tag) {
				Output.EndElement ("Port");
				}			
			}
		}

    public partial class Address : _Choice {
		public string					IP;

        public override ConfigureType _Tag () {
            return ConfigureType.Address;
            }

		public override void Serialize (StructureWriter Output, bool tag) {

			if (tag) {
				Output.StartElement ("Address");
				}

			Output.WriteAttribute ("IP", IP);
			if (tag) {
				Output.EndElement ("Address");
				}			
			}
		}

    public partial class Scope : _Choice {
		public string					Domain;

        public override ConfigureType _Tag () {
            return ConfigureType.Scope;
            }

		public override void Serialize (StructureWriter Output, bool tag) {

			if (tag) {
				Output.StartElement ("Scope");
				}

			Output.WriteAttribute ("Domain", Domain);
			if (tag) {
				Output.EndElement ("Scope");
				}			
			}
		}

    public partial class Expires : _Choice {
		public string					Expiry;

        public override ConfigureType _Tag () {
            return ConfigureType.Expires;
            }

		public override void Serialize (StructureWriter Output, bool tag) {

			if (tag) {
				Output.StartElement ("Expires");
				}

			Output.WriteAttribute ("Expiry", Expiry);
			if (tag) {
				Output.EndElement ("Expires");
				}			
			}
		}

    public partial class Encryption : _Choice {
		public string					Algorithm;

        public override ConfigureType _Tag () {
            return ConfigureType.Encryption;
            }

		public override void Serialize (StructureWriter Output, bool tag) {

			if (tag) {
				Output.StartElement ("Encryption");
				}

			Output.WriteAttribute ("Algorithm", Algorithm);
			if (tag) {
				Output.EndElement ("Encryption");
				}			
			}
		}

    public partial class Authentication : _Choice {
		public string					Algorithm;

        public override ConfigureType _Tag () {
            return ConfigureType.Authentication;
            }

		public override void Serialize (StructureWriter Output, bool tag) {

			if (tag) {
				Output.StartElement ("Authentication");
				}

			Output.WriteAttribute ("Algorithm", Algorithm);
			if (tag) {
				Output.EndElement ("Authentication");
				}			
			}
		}

    class _Label : _Choice {
        public REF<_Choice>            Label;

		// This method is never called. It exists only to prevent a warning when a
		// Schema does not contain a ChoiceREF element.
        public void Reach() {
            Label = null;
            }

        public override ConfigureType _Tag () {
            return ConfigureType._Label;
            }

		public override void Serialize (StructureWriter Output, bool tag) {
			Output.WriteId ("ID", Label.ToString());
			}
        }
//	}

//namespace Goedel.Registry {

    public enum StateCode {  
        _Start,
        _Choice,
        _End,

		Connect_Start,
		Connect__Id,				
		Connect__Domain,				
		Connect__Options,				
		Query_Start,
		Query__Id,				
		Query__Options,				
		Client_Start,
		Client__Id,				
		Client__Account,				
		Client__Service,				
		Client__Options,				
		Administrator_Start,
		Administrator__Account,				
		Connection_Start,
		Connection__Options,				
		Seed_Start,
		Seed__Data,				
		Seed__Expiry,				
		Secret_Start,
		Secret__Data,				
		Ticket_Start,
		Ticket__Data,				
		Port_Start,
		Port__Data,				
		Address_Start,
		Address__IP,				
		Scope_Start,
		Scope__Domain,				
		Expires_Start,
		Expires__Expiry,				
		Encryption_Start,
		Encryption__Algorithm,				
		Authentication_Start,
		Authentication__Algorithm,				
        }


    struct _StackItem {
        public StateCode   State;
        public Omnibroker._Choice     Token;
        }

    public partial class Configure : Goedel.Registry.Parser{
        public List <Omnibroker._Choice>        Top;
        public Registry	<Omnibroker._Choice>	Registry;



        bool _StartOfEntry;
        public bool StartOfEntry {
            get {return _StartOfEntry;}
            private set { _StartOfEntry = value; }
            }

        StateCode								State;
        Omnibroker._Choice				Current;
        List <_StackItem>						Stack;
        TokenType								CurrentToken;
        Position								CurrentPosition;
        string									CurrentText;



        public Configure() {
            Top = new List<Omnibroker._Choice> () ;
            Registry = new Registry <Omnibroker._Choice> ();
            State = StateCode._Start;
            Stack = new List <_StackItem> ();
            _StartOfEntry = true;

			TYPE__Handle = Registry.TYPE ("Handle"); 



            }



        TYPE<Omnibroker._Choice> TYPE__Handle ;

        private Omnibroker._Choice New_Choice(string Label) {
            switch (Label) {

                case "Connect": return NewConnect();
                case "Query": return NewQuery();
                case "Client": return NewClient();
                case "Administrator": return NewAdministrator();
                case "Connection": return NewConnection();
                case "Seed": return NewSeed();
                case "Secret": return NewSecret();
                case "Ticket": return NewTicket();
                case "Port": return NewPort();
                case "Address": return NewAddress();
                case "Scope": return NewScope();
                case "Expires": return NewExpires();
                case "Encryption": return NewEncryption();
                case "Authentication": return NewAuthentication();

				}
            throw new Exception("Reserved word not recognized \"" + Label + "\"");
            }



        private Omnibroker.Connect NewConnect() {
            Omnibroker.Connect result = new Omnibroker.Connect();
            Push (result);
            State = StateCode.Connect_Start;
            return result;
            }


        private Omnibroker.Query NewQuery() {
            Omnibroker.Query result = new Omnibroker.Query();
            Push (result);
            State = StateCode.Query_Start;
            return result;
            }


        private Omnibroker.Client NewClient() {
            Omnibroker.Client result = new Omnibroker.Client();
            Push (result);
            State = StateCode.Client_Start;
            return result;
            }


        private Omnibroker.Administrator NewAdministrator() {
            Omnibroker.Administrator result = new Omnibroker.Administrator();
            Push (result);
            State = StateCode.Administrator_Start;
            return result;
            }


        private Omnibroker.Connection NewConnection() {
            Omnibroker.Connection result = new Omnibroker.Connection();
            Push (result);
            State = StateCode.Connection_Start;
            return result;
            }


        private Omnibroker.Seed NewSeed() {
            Omnibroker.Seed result = new Omnibroker.Seed();
            Push (result);
            State = StateCode.Seed_Start;
            return result;
            }


        private Omnibroker.Secret NewSecret() {
            Omnibroker.Secret result = new Omnibroker.Secret();
            Push (result);
            State = StateCode.Secret_Start;
            return result;
            }


        private Omnibroker.Ticket NewTicket() {
            Omnibroker.Ticket result = new Omnibroker.Ticket();
            Push (result);
            State = StateCode.Ticket_Start;
            return result;
            }


        private Omnibroker.Port NewPort() {
            Omnibroker.Port result = new Omnibroker.Port();
            Push (result);
            State = StateCode.Port_Start;
            return result;
            }


        private Omnibroker.Address NewAddress() {
            Omnibroker.Address result = new Omnibroker.Address();
            Push (result);
            State = StateCode.Address_Start;
            return result;
            }


        private Omnibroker.Scope NewScope() {
            Omnibroker.Scope result = new Omnibroker.Scope();
            Push (result);
            State = StateCode.Scope_Start;
            return result;
            }


        private Omnibroker.Expires NewExpires() {
            Omnibroker.Expires result = new Omnibroker.Expires();
            Push (result);
            State = StateCode.Expires_Start;
            return result;
            }


        private Omnibroker.Encryption NewEncryption() {
            Omnibroker.Encryption result = new Omnibroker.Encryption();
            Push (result);
            State = StateCode.Encryption_Start;
            return result;
            }


        private Omnibroker.Authentication NewAuthentication() {
            Omnibroker.Authentication result = new Omnibroker.Authentication();
            Push (result);
            State = StateCode.Authentication_Start;
            return result;
            }


        static Omnibroker.ConfigureType _Reserved(string Label) {
            switch (Label) {

                case "Connect": return Omnibroker.ConfigureType.Connect;
                case "Query": return Omnibroker.ConfigureType.Query;
                case "Client": return Omnibroker.ConfigureType.Client;
                case "Administrator": return Omnibroker.ConfigureType.Administrator;
                case "Connection": return Omnibroker.ConfigureType.Connection;
                case "Seed": return Omnibroker.ConfigureType.Seed;
                case "Secret": return Omnibroker.ConfigureType.Secret;
                case "Ticket": return Omnibroker.ConfigureType.Ticket;
                case "Port": return Omnibroker.ConfigureType.Port;
                case "Address": return Omnibroker.ConfigureType.Address;
                case "Scope": return Omnibroker.ConfigureType.Scope;
                case "Expires": return Omnibroker.ConfigureType.Expires;
                case "Encryption": return Omnibroker.ConfigureType.Encryption;
                case "Authentication": return Omnibroker.ConfigureType.Authentication;

                }
            return Omnibroker.ConfigureType._Bottom;
            }


		public void Serialize (TextWriter Output) {
			Serialize (Output, OutputFormat.Goedel);
			}

		public void Serialize (TextWriter Output, OutputFormat OutputFormat) {

			StructureWriter StructureWriter = StructureWriter.GetStructureWriter (Output, OutputFormat);
			StructureWriter.StartDocument ();
			foreach (Omnibroker._Choice Entry in Top) {
				Entry.Serialize (StructureWriter, true);
				}
			StructureWriter.EndDocument ();
			}


        void Push (Omnibroker._Choice Token) {
            _StackItem Item = new _StackItem ();
            Item.State = State;
            Item.Token = Current;

            Stack.Add (Item);

            //Console.WriteLine ("$$$$PUSH {0}", Current);

            Current = Token;
            }

        void Pop () {
            if (Stack.Count == 0) throw new Exception ("Internal Parser Error");

            _StackItem Item = Stack[Stack.Count -1];
            State = Item.State;
            Current = Item.Token;

            Stack.RemoveAt (Stack.Count -1 ) ;

            //Console.WriteLine ("$$$$POP {0}", Current);
            }



        public override void Process(TokenType Token, Position Position, string Text) {
            CurrentToken = Token;
            CurrentPosition = Position;
            CurrentText = Text;

            if ((Token == TokenType.SEPARATOR) |
                (Token == TokenType.NULL) |
                (Token == TokenType.COMMENT)) return;
            if (Token == TokenType.INVALID)
                throw new Exception("Invalid Token");

            bool Represent = true;

            while (Represent) {
                //Console.WriteLine ("    {3}: {0} {1} '{2}'", Token, Position, Text, State);


                Represent = false;
                switch (State) {
                    case StateCode._Start:                 //      BEGIN
                        if (Token == TokenType.BEGIN) {
                            State = StateCode._Choice;
                            break;
                            }
                        else throw new Exception("Parser Error Expected START");

                    case StateCode._Choice:                //      LABEL Class | END
                        if (Token == TokenType.LABEL) {
                            Omnibroker.ConfigureType LabelType = _Reserved (Text);
                            if (false |
									(LabelType == Omnibroker.ConfigureType.Connect) |
									(LabelType == Omnibroker.ConfigureType.Query) |
									(LabelType == Omnibroker.ConfigureType.Client)) {
                                Top.Add(New_Choice(Text));
                                }
                            else {
                                throw new Exception("Parser Error Expected [Class]");
                                }
                            break;
                            }
                        if (Token == TokenType.END) {
                            State = StateCode._End;
                            break;
                            }
                        else throw new Exception("Parser Error Expected [Class]");

                    case StateCode._End:                   //      -
                        throw new Exception("Too Many Closing Braces");

                    case StateCode.Connect_Start:
                        if ((Token == TokenType.LABEL) | (Token == TokenType.LITERAL)) {
                            Omnibroker.Connect Current_Cast = (Omnibroker.Connect)Current;
                            Current_Cast.Id = Registry.ID(Position, Text, TYPE__Handle, Current_Cast);
                            State = StateCode.Connect__Id;
                            break;
                            }
                        throw new Exception("Expected LABEL or LITERAL");

                    case StateCode.Connect__Id:
                        if (Token == TokenType.STRING) {
                            Omnibroker.Connect Current_Cast = (Omnibroker.Connect)Current;
                            Current_Cast.Domain = Text;
                            State = StateCode.Connect__Domain;
                            break;
                            }
                        throw new Exception("Expected String");

                    case StateCode.Connect__Domain:
                        if (Token == TokenType.BEGIN) {
                            State = StateCode.Connect__Options;
                            }
                        else {
							Pop ();
                            Represent = true;
                            }
                        break;
                    case StateCode.Connect__Options: 
                        if (Token == TokenType.END) {
                            Pop();
                            break;
                            }

						// Parser transition for OPTIONS $$$$$
                        else if (Token == TokenType.LABEL) {
							Omnibroker.Connect Current_Cast = (Omnibroker.Connect)Current;
                            Omnibroker.ConfigureType LabelType = _Reserved (Text);
							switch (LabelType) {
								case Omnibroker.ConfigureType.Port : {

									// Port  Port
									Current_Cast.Port = NewPort ();
									break;
									}
								case Omnibroker.ConfigureType.Seed : {

									// Secrets  Seed
									Current_Cast.Secrets.Add (NewSeed ());
									break;
									}
								case Omnibroker.ConfigureType.Encryption : {

									// EncryptionAlgorithms  Encryption
									Current_Cast.EncryptionAlgorithms.Add (NewEncryption ());
									break;
									}
								case Omnibroker.ConfigureType.Authentication : {

									// AuthenticationAlgorithms  Authentication
									Current_Cast.AuthenticationAlgorithms.Add (NewAuthentication ());
									break;
									}
								case Omnibroker.ConfigureType.Administrator : {

									// Administrators  Administrator
									Current_Cast.Administrators.Add (NewAdministrator ());
									break;
									}
								default : {
									throw new Exception("Parser Error Expected [Port Seed Encryption Authentication Administrator ]");
									}
								}
							}
                        break;

                    case StateCode.Query_Start:
                        if ((Token == TokenType.LABEL) | (Token == TokenType.LITERAL)) {
                            Omnibroker.Query Current_Cast = (Omnibroker.Query)Current;
                            Current_Cast.Id = Registry.ID(Position, Text, TYPE__Handle, Current_Cast);
                            State = StateCode.Query__Id;
                            break;
                            }
                        throw new Exception("Expected LABEL or LITERAL");

                    case StateCode.Query__Id:
                        if (Token == TokenType.BEGIN) {
                            State = StateCode.Query__Options;
                            }
                        else {
							Pop ();
                            Represent = true;
                            }
                        break;
                    case StateCode.Query__Options: 
                        if (Token == TokenType.END) {
                            Pop();
                            break;
                            }

						// Parser transition for OPTIONS $$$$$
                        else if (Token == TokenType.LABEL) {
							Omnibroker.Query Current_Cast = (Omnibroker.Query)Current;
                            Omnibroker.ConfigureType LabelType = _Reserved (Text);
							switch (LabelType) {
								case Omnibroker.ConfigureType.Seed : {

									// Secret  Seed
									Current_Cast.Secret.Add (NewSeed ());
									break;
									}
								default : {
									throw new Exception("Parser Error Expected [Seed ]");
									}
								}
							}
                        break;

                    case StateCode.Client_Start:
                        if ((Token == TokenType.LABEL) | (Token == TokenType.LITERAL)) {
                            Omnibroker.Client Current_Cast = (Omnibroker.Client)Current;
                            Current_Cast.Id = Registry.ID(Position, Text, TYPE__Handle, Current_Cast);
                            State = StateCode.Client__Id;
                            break;
                            }
                        throw new Exception("Expected LABEL or LITERAL");

                    case StateCode.Client__Id:
                        if (Token == TokenType.STRING) {
                            Omnibroker.Client Current_Cast = (Omnibroker.Client)Current;
                            Current_Cast.Account = Text;
                            State = StateCode.Client__Account;
                            break;
                            }
                        throw new Exception("Expected String");

                    case StateCode.Client__Account:
                        if (Token == TokenType.STRING) {
                            Omnibroker.Client Current_Cast = (Omnibroker.Client)Current;
                            Current_Cast.Service = Text;
                            State = StateCode.Client__Service;
                            break;
                            }
                        throw new Exception("Expected String");

                    case StateCode.Client__Service:
                        if (Token == TokenType.BEGIN) {
                            State = StateCode.Client__Options;
                            }
                        else {
							Pop ();
                            Represent = true;
                            }
                        break;
                    case StateCode.Client__Options: 
                        if (Token == TokenType.END) {
                            Pop();
                            break;
                            }

						// Parser transition for OPTIONS $$$$$
                        else if (Token == TokenType.LABEL) {
							Omnibroker.Client Current_Cast = (Omnibroker.Client)Current;
                            Omnibroker.ConfigureType LabelType = _Reserved (Text);
							switch (LabelType) {
								case Omnibroker.ConfigureType.Scope : {

									// Scopes  Scope
									Current_Cast.Scopes.Add (NewScope ());
									break;
									}
								case Omnibroker.ConfigureType.Secret : {

									// Secret  Secret
									Current_Cast.Secret = NewSecret ();
									break;
									}
								case Omnibroker.ConfigureType.Ticket : {

									// Ticket  Ticket
									Current_Cast.Ticket = NewTicket ();
									break;
									}
								case Omnibroker.ConfigureType.Encryption : {

									// EncryptionAlgorithm  Encryption
									Current_Cast.EncryptionAlgorithm = NewEncryption ();
									break;
									}
								case Omnibroker.ConfigureType.Authentication : {

									// AuthenticationAlgorithm  Authentication
									Current_Cast.AuthenticationAlgorithm = NewAuthentication ();
									break;
									}
								case Omnibroker.ConfigureType.Expires : {

									// Expires  Expires
									Current_Cast.Expires = NewExpires ();
									break;
									}
								case Omnibroker.ConfigureType.Connection : {

									// Connections  Connection
									Current_Cast.Connections.Add (NewConnection ());
									break;
									}
								default : {
									throw new Exception("Parser Error Expected [Scope Secret Ticket Encryption Authentication Expires Connection ]");
									}
								}
							}
                        break;

                    case StateCode.Administrator_Start:
                        if (Token == TokenType.STRING) {
                            Omnibroker.Administrator Current_Cast = (Omnibroker.Administrator)Current;
                            Current_Cast.Account = Text;
                            State = StateCode.Administrator__Account;
                            break;
                            }
                        throw new Exception("Expected String");

                    case StateCode.Administrator__Account:
                        Pop ();
                        Represent = true; 
                        break;
                    case StateCode.Connection_Start:
                        if (Token == TokenType.BEGIN) {
                            State = StateCode.Connection__Options;
                            }
                        else {
							Pop ();
                            Represent = true;
                            }
                        break;
                    case StateCode.Connection__Options: 
                        if (Token == TokenType.END) {
                            Pop();
                            break;
                            }

						// Parser transition for OPTIONS $$$$$
                        else if (Token == TokenType.LABEL) {
							Omnibroker.Connection Current_Cast = (Omnibroker.Connection)Current;
                            Omnibroker.ConfigureType LabelType = _Reserved (Text);
							switch (LabelType) {
								case Omnibroker.ConfigureType.Scope : {

									// Scopes  Scope
									Current_Cast.Scopes.Add (NewScope ());
									break;
									}
								case Omnibroker.ConfigureType.Secret : {

									// Secret  Secret
									Current_Cast.Secret = NewSecret ();
									break;
									}
								case Omnibroker.ConfigureType.Ticket : {

									// Ticket  Ticket
									Current_Cast.Ticket = NewTicket ();
									break;
									}
								case Omnibroker.ConfigureType.Encryption : {

									// EncryptionAlgorithm  Encryption
									Current_Cast.EncryptionAlgorithm = NewEncryption ();
									break;
									}
								case Omnibroker.ConfigureType.Authentication : {

									// AuthenticationAlgorithm  Authentication
									Current_Cast.AuthenticationAlgorithm = NewAuthentication ();
									break;
									}
								case Omnibroker.ConfigureType.Expires : {

									// Expires  Expires
									Current_Cast.Expires = NewExpires ();
									break;
									}
								default : {
									throw new Exception("Parser Error Expected [Scope Secret Ticket Encryption Authentication Expires ]");
									}
								}
							}
                        break;

                    case StateCode.Seed_Start:
                        if (Token == TokenType.STRING) {
                            Omnibroker.Seed Current_Cast = (Omnibroker.Seed)Current;
                            Current_Cast.Data = Text;
                            State = StateCode.Seed__Data;
                            break;
                            }
                        throw new Exception("Expected String");

                    case StateCode.Seed__Data:
                        if (Token == TokenType.STRING) {
                            Omnibroker.Seed Current_Cast = (Omnibroker.Seed)Current;
                            Current_Cast.Expiry = Text;
                            State = StateCode.Seed__Expiry;
                            break;
                            }
                        throw new Exception("Expected String");

                    case StateCode.Seed__Expiry:
                        Pop ();
                        Represent = true; 
                        break;
                    case StateCode.Secret_Start:
                        if (Token == TokenType.STRING) {
                            Omnibroker.Secret Current_Cast = (Omnibroker.Secret)Current;
                            Current_Cast.Data = Text;
                            State = StateCode.Secret__Data;
                            break;
                            }
                        throw new Exception("Expected String");

                    case StateCode.Secret__Data:
                        Pop ();
                        Represent = true; 
                        break;
                    case StateCode.Ticket_Start:
                        if (Token == TokenType.STRING) {
                            Omnibroker.Ticket Current_Cast = (Omnibroker.Ticket)Current;
                            Current_Cast.Data = Text;
                            State = StateCode.Ticket__Data;
                            break;
                            }
                        throw new Exception("Expected String");

                    case StateCode.Ticket__Data:
                        Pop ();
                        Represent = true; 
                        break;
                    case StateCode.Port_Start:
                        if (Token == TokenType.INTEGER) {
                            Omnibroker.Port Current_Cast = (Omnibroker.Port)Current;
                            Current_Cast.Data = Convert.ToInt32(Text);
                            State = StateCode.Port__Data;
                            break;
                            }
                        throw new Exception("Expected Integer");

                    case StateCode.Port__Data:
                        Pop ();
                        Represent = true; 
                        break;
                    case StateCode.Address_Start:
                        if (Token == TokenType.STRING) {
                            Omnibroker.Address Current_Cast = (Omnibroker.Address)Current;
                            Current_Cast.IP = Text;
                            State = StateCode.Address__IP;
                            break;
                            }
                        throw new Exception("Expected String");

                    case StateCode.Address__IP:
                        Pop ();
                        Represent = true; 
                        break;
                    case StateCode.Scope_Start:
                        if (Token == TokenType.STRING) {
                            Omnibroker.Scope Current_Cast = (Omnibroker.Scope)Current;
                            Current_Cast.Domain = Text;
                            State = StateCode.Scope__Domain;
                            break;
                            }
                        throw new Exception("Expected String");

                    case StateCode.Scope__Domain:
                        Pop ();
                        Represent = true; 
                        break;
                    case StateCode.Expires_Start:
                        if (Token == TokenType.STRING) {
                            Omnibroker.Expires Current_Cast = (Omnibroker.Expires)Current;
                            Current_Cast.Expiry = Text;
                            State = StateCode.Expires__Expiry;
                            break;
                            }
                        throw new Exception("Expected String");

                    case StateCode.Expires__Expiry:
                        Pop ();
                        Represent = true; 
                        break;
                    case StateCode.Encryption_Start:
                        if (Token == TokenType.STRING) {
                            Omnibroker.Encryption Current_Cast = (Omnibroker.Encryption)Current;
                            Current_Cast.Algorithm = Text;
                            State = StateCode.Encryption__Algorithm;
                            break;
                            }
                        throw new Exception("Expected String");

                    case StateCode.Encryption__Algorithm:
                        Pop ();
                        Represent = true; 
                        break;
                    case StateCode.Authentication_Start:
                        if (Token == TokenType.STRING) {
                            Omnibroker.Authentication Current_Cast = (Omnibroker.Authentication)Current;
                            Current_Cast.Algorithm = Text;
                            State = StateCode.Authentication__Algorithm;
                            break;
                            }
                        throw new Exception("Expected String");

                    case StateCode.Authentication__Algorithm:
                        Pop ();
                        Represent = true; 
                        break;

                    default:
                        throw new Exception("Unreachable code reached");
                    }
                }
            }
        }
	}


