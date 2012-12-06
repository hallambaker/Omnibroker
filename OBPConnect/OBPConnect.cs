
//This file was automatically generated at 9/10/2012 5:43:26 PM
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

namespace OBPConnect {
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

			OBPConnect Dispatch = new OBPConnect ();


			try {
				if (args.Length == 0) {
					throw new ParserException ("No command specified");
					}

                if (IsFlag(args[0][0])) {


                    switch (args[0].Substring(1).ToLower()) {
						case "server" : {
							Handle_Server (Dispatch, args, 1);
							break;
							}
						case "pin" : {
							Handle_PIN (Dispatch, args, 1);
							break;
							}
						case "init" : {
							Handle_Initialize (Dispatch, args, 1);
							break;
							}
						case "roll" : {
							Handle_Rollover (Dispatch, args, 1);
							break;
							}
						default: {
							throw new ParserException("Unknown Command: " + args[0]);
                            }
                        }
                    }
                else {
					Handle_Server (Dispatch, args, 0);
                    }
				}


            catch (System.Exception Exception) {
                if (Exception.GetType() == typeof (ParserException)) {
                    Usage ();
                    }
                else {
                   Console.WriteLine("Application: {0}", Exception.Message);
                    }
                }
            } // Main


		private enum TagType_Server {
			Configuration,
			Log,
			Detach,
			Handle,
			}

		private static void Handle_Server (
					OBPConnect Dispatch, string[] args, int index) {
			Server		Options = new Server ();

			Registry Registry = new Registry ();

			Options.Configuration.Register ("config", Registry, (int) TagType_Server.Configuration);
			Options.Log.Register ("log", Registry, (int) TagType_Server.Log);
			Options.Detach.Register ("detach", Registry, (int) TagType_Server.Detach);
			Options.Handle.Register ("id", Registry, (int) TagType_Server.Handle);

			// looking for parameter Param.Name}
			if (index < args.Length && !IsFlag (args [index][0] )) {
				// Have got the parameter, call the parameter value method
				Options.Configuration.Parameter (args [index]);
				index++;
				}

#pragma warning disable 162
			for (int i = index; i< args.Length; i++) {
				if 	(!IsFlag (args [i][0] )) {
					throw new Exception ("Unexpected parameter: " + args[i]);}			
				string Rest = args [i].Substring (1);

				TagType_Server TagType = (TagType_Server) Registry.Find (Rest);

				// here have the cases for what to do with it.

				switch (TagType) {
					case TagType_Server.Log : {
						int OptionParams = Options.Log.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Log.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_Server.Detach : {
						int OptionParams = Options.Detach.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Detach.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_Server.Handle : {
						int OptionParams = Options.Handle.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Handle.Parameter (args[i]);
								}
							}
						break;
						}
					default : throw new Exception ("Internal error");
					}
				}

#pragma warning restore 162
			Dispatch.Server (Options);

			}
		private enum TagType_PIN {
			Configuration,
			Account,
			Handle,
			}

		private static void Handle_PIN (
					OBPConnect Dispatch, string[] args, int index) {
			PIN		Options = new PIN ();

			Registry Registry = new Registry ();

			Options.Configuration.Register ("config", Registry, (int) TagType_PIN.Configuration);
			Options.Account.Register ("account", Registry, (int) TagType_PIN.Account);
			Options.Handle.Register ("id", Registry, (int) TagType_PIN.Handle);

			// looking for parameter Param.Name}
			if (index < args.Length && !IsFlag (args [index][0] )) {
				// Have got the parameter, call the parameter value method
				Options.Configuration.Parameter (args [index]);
				index++;
				}
			// looking for parameter Param.Name}
			if (index < args.Length && !IsFlag (args [index][0] )) {
				// Have got the parameter, call the parameter value method
				Options.Account.Parameter (args [index]);
				index++;
				}

#pragma warning disable 162
			for (int i = index; i< args.Length; i++) {
				if 	(!IsFlag (args [i][0] )) {
					throw new Exception ("Unexpected parameter: " + args[i]);}			
				string Rest = args [i].Substring (1);

				TagType_PIN TagType = (TagType_PIN) Registry.Find (Rest);

				// here have the cases for what to do with it.

				switch (TagType) {
					case TagType_PIN.Handle : {
						int OptionParams = Options.Handle.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Handle.Parameter (args[i]);
								}
							}
						break;
						}
					default : throw new Exception ("Internal error");
					}
				}

#pragma warning restore 162
			Dispatch.PIN (Options);

			}
		private enum TagType_Initialize {
			Configuration,
			Handle,
			Refresh,
			}

		private static void Handle_Initialize (
					OBPConnect Dispatch, string[] args, int index) {
			Initialize		Options = new Initialize ();

			Registry Registry = new Registry ();

			Options.Configuration.Register ("config", Registry, (int) TagType_Initialize.Configuration);
			Options.Handle.Register ("id", Registry, (int) TagType_Initialize.Handle);
			Options.Refresh.Register ("refresh", Registry, (int) TagType_Initialize.Refresh);

			// looking for parameter Param.Name}
			if (index < args.Length && !IsFlag (args [index][0] )) {
				// Have got the parameter, call the parameter value method
				Options.Configuration.Parameter (args [index]);
				index++;
				}

#pragma warning disable 162
			for (int i = index; i< args.Length; i++) {
				if 	(!IsFlag (args [i][0] )) {
					throw new Exception ("Unexpected parameter: " + args[i]);}			
				string Rest = args [i].Substring (1);

				TagType_Initialize TagType = (TagType_Initialize) Registry.Find (Rest);

				// here have the cases for what to do with it.

				switch (TagType) {
					case TagType_Initialize.Handle : {
						int OptionParams = Options.Handle.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Handle.Parameter (args[i]);
								}
							}
						break;
						}
					case TagType_Initialize.Refresh : {
						int OptionParams = Options.Refresh.Tag (Rest);
						
						if (OptionParams>0 && ((i+1) < args.Length)) {
							if 	(!IsFlag (args [i+1][0] )) {
								i++;								
								Options.Refresh.Parameter (args[i]);
								}
							}
						break;
						}
					default : throw new Exception ("Internal error");
					}
				}

#pragma warning restore 162
			Dispatch.Initialize (Options);

			}
		private enum TagType_Rollover {
			}

		private static void Handle_Rollover (
					OBPConnect Dispatch, string[] args, int index) {
			Rollover		Options = new Rollover ();

			Registry Registry = new Registry ();



#pragma warning disable 162
			for (int i = index; i< args.Length; i++) {
				if 	(!IsFlag (args [i][0] )) {
					throw new Exception ("Unexpected parameter: " + args[i]);}			
				string Rest = args [i].Substring (1);

				TagType_Rollover TagType = (TagType_Rollover) Registry.Find (Rest);

				// here have the cases for what to do with it.

				switch (TagType) {
					default : throw new Exception ("Internal error");
					}
				}

#pragma warning restore 162
			Dispatch.Rollover (Options);

			}

		private static void Usage () {

				Console.WriteLine ("Omnibroker Connection Service");
				Console.WriteLine ("");

				{
					Server		Dummy = new Server ();

					Console.Write ("{0}server ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.Configuration.Usage (null, "config", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Log.Usage ("log", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Detach.Usage ("detach", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Handle.Usage ("id", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Launch omnibroker connection service");

				}

				{
					PIN		Dummy = new PIN ();

					Console.Write ("{0}pin ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.Configuration.Usage (null, "config", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Account.Usage (null, "account", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Handle.Usage ("id", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Provide a pin code for the specified account");

				}

				{
					Initialize		Dummy = new Initialize ();

					Console.Write ("{0}init ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.Configuration.Usage (null, "config", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Handle.Usage ("id", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Refresh.Usage ("refresh", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Create and register new master secrets");

				}

				{
					Rollover		Dummy = new Rollover ();

					Console.Write ("{0}roll ", UsageFlag);
					Console.WriteLine ();

					Console.WriteLine ("    Roll over the master secrets");

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




    public class _Server : Goedel.Registry.Dispatch {
		public ExistingFile			Configuration = new ExistingFile ();

		public NewFile			Log = new  NewFile ();

		public Flag			Detach = new  Flag ();

		public String			Handle = new  String ();


		}

    public partial class Server : _Server {
        } // class Server


    public class _PIN : Goedel.Registry.Dispatch {
		public ExistingFile			Configuration = new ExistingFile ();
		public String			Account = new String ();

		public String			Handle = new  String ();


		}

    public partial class PIN : _PIN {
        } // class PIN


    public class _Initialize : Goedel.Registry.Dispatch {
		public ExistingFile			Configuration = new ExistingFile ();

		public String			Handle = new  String ();

		public Integer			Refresh = new  Integer ("24");


		}

    public partial class Initialize : _Initialize {
        } // class Initialize


    public class _Rollover : Goedel.Registry.Dispatch {


		}

    public partial class Rollover : _Rollover {
        } // class Rollover



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
    public class _OBPConnect {


		public virtual void Server ( Server Options
				) {

			char UsageFlag = '-';
				{
					Server		Dummy = new Server ();

					Console.Write ("{0}server ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.Configuration.Usage (null, "config", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Log.Usage ("log", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Detach.Usage ("detach", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Handle.Usage ("id", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Launch omnibroker connection service");

				}

				Console.WriteLine ("    {0}\t{1} = [{2}]", "ExistingFile", 
							"Configuration", Options.Configuration);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "NewFile", 
							"Log", Options.Log);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "Flag", 
							"Detach", Options.Detach);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"Handle", Options.Handle);
			Console.WriteLine ("Not Yet Implemented");
			}
		public virtual void PIN ( PIN Options
				) {

			char UsageFlag = '-';
				{
					PIN		Dummy = new PIN ();

					Console.Write ("{0}pin ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.Configuration.Usage (null, "config", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Account.Usage (null, "account", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Handle.Usage ("id", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Provide a pin code for the specified account");

				}

				Console.WriteLine ("    {0}\t{1} = [{2}]", "ExistingFile", 
							"Configuration", Options.Configuration);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"Account", Options.Account);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"Handle", Options.Handle);
			Console.WriteLine ("Not Yet Implemented");
			}
		public virtual void Initialize ( Initialize Options
				) {

			char UsageFlag = '-';
				{
					Initialize		Dummy = new Initialize ();

					Console.Write ("{0}init ", UsageFlag);
					Console.Write ("[{0}] ", Dummy.Configuration.Usage (null, "config", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Handle.Usage ("id", "value", UsageFlag));
					Console.Write ("[{0}] ", Dummy.Refresh.Usage ("refresh", "value", UsageFlag));
					Console.WriteLine ();

					Console.WriteLine ("    Create and register new master secrets");

				}

				Console.WriteLine ("    {0}\t{1} = [{2}]", "ExistingFile", 
							"Configuration", Options.Configuration);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "String", 
							"Handle", Options.Handle);
				Console.WriteLine ("    {0}\t{1} = [{2}]", "Integer", 
							"Refresh", Options.Refresh);
			Console.WriteLine ("Not Yet Implemented");
			}
		public virtual void Rollover ( Rollover Options
				) {

			char UsageFlag = '-';
				{
					Rollover		Dummy = new Rollover ();

					Console.Write ("{0}roll ", UsageFlag);
					Console.WriteLine ();

					Console.WriteLine ("    Roll over the master secrets");

				}

			Console.WriteLine ("Not Yet Implemented");
			}

        } // class _OBPConnect

    public partial class OBPConnect : _OBPConnect {
        } // class OBPConnect

    } // namespace OBPConnect


