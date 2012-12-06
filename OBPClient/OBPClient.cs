
//This file was automatically generated at 9/11/2012 2:29:39 PM
// 
//Changes to this file may be overwritten without warning
//
//Generator:  CommandParse version 1.0.4632.25446
//    Goedel Script Version : 0.1   Generated 
//    Goedel Schema Version : 0.1   Generated
//
//    Copyright : Copyright ©  2011
//
//Build Platform: Win32NT 6.1.7601.65536
//
//
//Copyright ©  2011 by Default Deny Security Inc.
//
//Permission is hereby granted, free of charge, to any person obtaining a copy
//of this software and associated documentation files (the "Software"), to deal
//in the Software without restriction, including without limitation the rights
//to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//copies of the Software, and to permit persons to whom the Software is
//furnished to do so, subject to the following conditions:
//
//The above copyright notice and this permission notice shall be included in
//all copies or substantial portions of the Software.
//
//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//THE SOFTWARE.
//
//


using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Goedel.Registry;

namespace OBPClient {
    class _Main {

		static char UsageFlag;
		static char UnixFlag = '-';
		static char WindowsFlag = '/';

		static char Separator;
		static char UnixSeparator = '=';
		static char WindowsSeparator = ':';

        static bool IsFlag(char c) {
            return (c == UnixFlag) | (c == WindowsFlag) ;
            }

        static _Main () {
            System.OperatingSystem OperatingSystem = System.Environment.OSVersion;

            if (OperatingSystem.Platform == PlatformID.Unix |
                    OperatingSystem.Platform == PlatformID.MacOSX) {
                UsageFlag = UnixFlag;
				Separator = UnixSeparator;
                }
            else {
                UsageFlag = WindowsFlag;
				Separator = WindowsSeparator;
                }
            }

        static void Main(string[] args) {

			OBPClient Dispatch = new OBPClient ();


            //try {
				if (args.Length == 0) {
					throw new ParserException ("No command specified");
					}

                if (IsFlag(args[0][0])) {


                    switch (args[0].Substring(1).ToLower()) {
						case "resolve" : {
							Handle_Resolve (Dispatch, args, 1);
							break;
							}
						case "bind" : {
							Handle_Bind (Dispatch, args, 1);
							break;
							}
						case "unbind" : {
							Handle_Unbind (Dispatch, args, 1);
							break;
							}
						default: {
							throw new ParserException("Unknown Command: " + args[0]);
                            }
                        }
                    }
                else {
					Handle_Resolve (Dispatch, args, 0);
                    }
            //    }


            //catch (System.Exception Exception) {
            //    if (Exception.GetType() == typeof (ParserException)) {
            //        Usage ();
            //        }
            //    else {
            //       Console.WriteLine("Application: {0}", Exception.Message);
            //        }
            //    }
            } // Main


		private enum TagType_Resolve {
			Domain,
			Service,
			Verbose,
			}

		private static void Handle_Resolve (
					OBPClient Dispatch, string[] args, int index) {
			Resolve		Options = new Resolve ();

			Registry Registry = new Registry ();

			Options.Domain.Register ("domain", Registry, (int) TagType_Resolve.Domain);
			Options.Service.Register ("service", Registry, (int) TagType_Resolve.Service);
			Options.Verbose.Register ("verbose", Registry, (int) TagType_Resolve.Verbose);

			// looking for parameter Param.Name}
			if (index < args.Length && !IsFlag (args [index][0] )) {
				// Have got the parameter, call the parameter value method
				Options.Domain.Parameter (args [index]);
				index++;
				}
			// looking for parameter Param.Name}
			if (index < args.Length && !IsFlag (args [index][0] )) {
				// Have got the parameter, call the parameter value method
				Options.Service.Parameter (args [index]);
				index++;
				}

#pragma warning disable 162
			for (int i = index; i< args.Length; i++) {
				if 	(!IsFlag (args [i][0] )) {
					throw new Exception ("Unexpected parameter: " + args[i]);}			
				string Rest = args [i].Substring (1);

				TagType_Resolve TagType = (TagType_Resolve) Registry.Find (Rest);

				// here have the cases for what to do with it.

				switch (TagType) {
					case TagType_Resolve.Verbose : {
						int OptionParams = Options.Verbose.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Verbose.Parameter (args[i]);
								}
							}
						break;
						}
					default : throw new Exception ("Internal error");
					}
				}

#pragma warning restore 162
			Dispatch.Resolve (Options);

			}
		private enum TagType_Bind {
			Account,
			PIN,
			Server,
			Port,
			}

		private static void Handle_Bind (
					OBPClient Dispatch, string[] args, int index) {
			Bind		Options = new Bind ();

			Registry Registry = new Registry ();

			Options.Account.Register ("account", Registry, (int) TagType_Bind.Account);
			Options.PIN.Register ("pin", Registry, (int) TagType_Bind.PIN);
			Options.Server.Register ("server", Registry, (int) TagType_Bind.Server);
			Options.Port.Register ("port", Registry, (int) TagType_Bind.Port);

			// looking for parameter Param.Name}
			if (index < args.Length && !IsFlag (args [index][0] )) {
				// Have got the parameter, call the parameter value method
				Options.Account.Parameter (args [index]);
				index++;
				}
			// looking for parameter Param.Name}
			if (index < args.Length && !IsFlag (args [index][0] )) {
				// Have got the parameter, call the parameter value method
				Options.PIN.Parameter (args [index]);
				index++;
				}

#pragma warning disable 162
			for (int i = index; i< args.Length; i++) {
				if 	(!IsFlag (args [i][0] )) {
					throw new Exception ("Unexpected parameter: " + args[i]);}			
				string Rest = args [i].Substring (1);

				TagType_Bind TagType = (TagType_Bind) Registry.Find (Rest);

				// here have the cases for what to do with it.

				switch (TagType) {
					case TagType_Bind.Server : {
						int OptionParams = Options.Server.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Server.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_Bind.Port : {
						int OptionParams = Options.Port.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Port.Parameter (args[i]);
								}
							}
						break;
						}
					default : throw new Exception ("Internal error");
					}
				}

#pragma warning restore 162
			Dispatch.Bind (Options);

			}
		private enum TagType_Unbind {
			}

		private static void Handle_Unbind (
					OBPClient Dispatch, string[] args, int index) {
			Unbind		Options = new Unbind ();

			Registry Registry = new Registry ();



#pragma warning disable 162
			for (int i = index; i< args.Length; i++) {
				if 	(!IsFlag (args [i][0] )) {
					throw new Exception ("Unexpected parameter: " + args[i]);}			
				string Rest = args [i].Substring (1);

				TagType_Unbind TagType = (TagType_Unbind) Registry.Find (Rest);

				// here have the cases for what to do with it.

				switch (TagType) {
					default : throw new Exception ("Internal error");
					}
				}

#pragma warning restore 162
			Dispatch.Unbind (Options);

			}

		private static void Usage () {

				Console.WriteLine ("Omnibroker Client");
				Console.WriteLine ("");

				{
					Resolve		Dummy = new Resolve ();

					Console.Write ("{0}resolve ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.Domain.Usage (null, "domain", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Service.Usage (null, "service", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Verbose.Usage ("verbose", "value", UsageFlag));
					Console.WriteLine ();

				}

				{
					Bind		Dummy = new Bind ();

					Console.Write ("{0}bind ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.Account.Usage (null, "account", UsageFlag));
					Console.Write ("[{0}] ", Dummy.PIN.Usage (null, "pin", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Server.Usage ("server", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Port.Usage ("port", "value", UsageFlag));
					Console.WriteLine ();

				}

				{
					Unbind		Dummy = new Unbind ();

					Console.Write ("{0}unbind ", UsageFlag);
					Console.WriteLine ();

				}

			} // Usage 

		public class ParserException : Exception {

			public ParserException(string message)
				: base(message) {

				Console.WriteLine (message);
				}
			}


	} // class Main


	// The stub class for carrying optional parameters for each command type
	// As with the main class each consists of an abstract main class 
	// with partial virtual that can be extended as required.

	// All subclasses inherit from the abstract classes Goedel.Regisrty.Dispatch 
	// and Goedel.Registry.Type




    public class _Resolve : Goedel.Registry.Dispatch {
		public String			Domain = new String ();
		public String			Service = new String ();

		public String			Verbose = new  String ();


		}

    public partial class Resolve : _Resolve {
        } // class Resolve


    public class _Bind : Goedel.Registry.Dispatch {
		public String			Account = new String ();
		public String			PIN = new String ();

		public String			Server = new  String ();

		public Integer			Port = new  Integer ();


		}

    public partial class Bind : _Bind {
        } // class Bind


    public class _Unbind : Goedel.Registry.Dispatch {


		}

    public partial class Unbind : _Unbind {
        } // class Unbind



    // Parameter type NewFile
    public abstract class _NewFile : Goedel.Registry.Type {
        public _NewFile() {
            }
        public _NewFile(string Value) {
			Default (Value);
            } 

		// Builtin for NewFile
		public string Extension = "";

		public override void Default(string TextIn) {
			Extension = TextIn;
			}
		public string			Value {
			get {return Text;}
			}

        } // _NewFile

    public partial class  NewFile : _NewFile {
        public NewFile() {
            } 
        public NewFile(string Value) {
			Default (Value);
            } 
        } // NewFile


    // Parameter type ExistingFile
    public abstract class _ExistingFile : Goedel.Registry.Type {
        public _ExistingFile() {
            }
        public _ExistingFile(string Value) {
			Default (Value);
            } 

		// Builtin for ExistingFile
		public string Extension = "";

		public override void Default(string TextIn) {
			Extension = TextIn;
			}
		public string			Value {
			get {return Text;}
			}

        } // _ExistingFile

    public partial class  ExistingFile : _ExistingFile {
        public ExistingFile() {
            } 
        public ExistingFile(string Value) {
			Default (Value);
            } 
        } // ExistingFile


    // Parameter type String
    public abstract class _String : Goedel.Registry.Type {
        public _String() {
            }
        public _String(string Value) {
			Default (Value);
            } 

		public string			Value {
			get {return Text;}
			}

        } // _String

    public partial class  String : _String {
        public String() {
            } 
        public String(string Value) {
			Default (Value);
            } 
        } // String


    // Parameter type Integer
    public abstract class _Integer : Goedel.Registry.Type {
        public _Integer() {
            }
        public _Integer(string Value) {
			Default (Value);
            } 

		public string			Value {
			get {return Text;}
			}

        } // _Integer

    public partial class  Integer : _Integer {
        public Integer() {
            } 
        public Integer(string Value) {
			Default (Value);
            } 
        } // Integer


    // Parameter type Flag
    public abstract class _Flag : Goedel.Registry.Type {
        public _Flag() {
            }
        public _Flag(string Value) {
			Default (Value);
            } 

		// Builtin for flag
	    public bool         IsSet;

		public bool			Value {
			get {return IsSet;}
			}

        public override void  Register(string Tag, Registry Registry, int Index) {
            Registry.Register (Tag, Index);
            Registry.Register ("no" + Tag, Index);
            }

        public override int Tag(string Tag) {
            if ((Tag.Length > 2) && Tag[0] == 'n' && Tag[1] == 'o') {
                IsSet = false;
                }
            else {
                IsSet = true;
                }

            return 0; // number of required parameters is 0
            }

        public override void Parameter(string Text) {
            //Text = (Text == null) ? "true" : Text;
            switch (Text.ToLower()) {
                case "true":
                case "1":
                    IsSet = true;
                    break;
                case "false":
                case "0":
                    IsSet = false;
                    break;
                default :
                    throw new Exception ("Flag value not recognized" + Text);
                }
            }
        public override string ToString() {
            return IsSet ? "true" : "false";
            }

		public override string Usage (string Tag, string Value, char Usage) {
			return Usage + "[no]" + Tag;
			}



        } // _Flag

    public partial class  Flag : _Flag {
        public Flag() {
            } 
        public Flag(string Value) {
			Default (Value);
            } 
        } // Flag




	// The stub class just contains routines that echo their arguments and
	// write 'not yet implemented'

	// Eventually there will be a compiler option to suppress the debugging
	// to eliminate the redundant code
    public class _OBPClient {


		public virtual void Resolve ( Resolve Options
				) {

			char UsageFlag = '-';
				{
					Resolve		Dummy = new Resolve ();

					Console.Write ("{0}resolve ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.Domain.Usage (null, "domain", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Service.Usage (null, "service", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Verbose.Usage ("verbose", "value", UsageFlag));
					Console.WriteLine ();

				}

				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"Domain", Options.Domain);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"Service", Options.Service);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"Verbose", Options.Verbose);
			Console.WriteLine ("Not Yet Implemented");
			}
		public virtual void Bind ( Bind Options
				) {

			char UsageFlag = '-';
				{
					Bind		Dummy = new Bind ();

					Console.Write ("{0}bind ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.Account.Usage (null, "account", UsageFlag));
					Console.Write ("[{0}] ", Dummy.PIN.Usage (null, "pin", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Server.Usage ("server", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Port.Usage ("port", "value", UsageFlag));
					Console.WriteLine ();

				}

				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"Account", Options.Account);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"PIN", Options.PIN);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"Server", Options.Server);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "Integer", 
							"Port", Options.Port);
			Console.WriteLine ("Not Yet Implemented");
			}
		public virtual void Unbind ( Unbind Options
				) {

			char UsageFlag = '-';
				{
					Unbind		Dummy = new Unbind ();

					Console.Write ("{0}unbind ", UsageFlag);
					Console.WriteLine ();

				}

			Console.WriteLine ("Not Yet Implemented");
			}

        } // class _OBPClient

    public partial class OBPClient : _OBPClient {
        } // class OBPClient

    } // namespace OBPClient


