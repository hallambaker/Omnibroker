
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Goedel.Protocol;




namespace OBPQuery {

	abstract public partial class QMessage {

		static string _Tag = "QMessage";
		public virtual string Tag () {
			return _Tag;
			}

		public QMessage () {
			}
		public QMessage (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}
		public QMessage (string _String) {
			Deserialize (_String);
			}

		public override string ToString () {
			StringWriter _Writer = new StringWriter ();
			JSONWriter _JSONWriter = new JSONWriter (_Writer);
			Serialize (_JSONWriter, true);
			return _Writer.ToString ();
			}

		public virtual void Serialize (Writer Writer) {
			Serialize (Writer, false);
			}

		public virtual void Serialize (Writer Writer, bool tag) {
			bool first = true;
			if (tag) {
				Writer.WriteObjectStart ();
				Writer.WriteToken(_Tag, 0);
				}
			
			Serialize (Writer, true, ref first);
			
			if (tag) {
				Writer.WriteObjectEnd ();
				}			
			}


		public virtual void Serialize (Writer Writer, bool wrap, ref bool first) {
			if (wrap) {
				Writer.WriteObjectStart ();
				}
			if (wrap) {
				Writer.WriteObjectEnd ();
				}
			}

        public static void Deserialize(string _Input, out QMessage Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			
			JSONReader.StartObject ();
			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "QMessage" : {
					Out = null;
					throw new Exception ("Can't create abstract type");
					}

				case "QRequest" : {
					Out = null;
					throw new Exception ("Can't create abstract type");
					}

				case "QueryConnectRequest" : {
					QueryConnectRequest Result = new QueryConnectRequest ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "AdvertiseRequest" : {
					AdvertiseRequest Result = new AdvertiseRequest ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "ValidateRequest" : {
					ValidateRequest Result = new ValidateRequest ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "CredentialPasswordRequest" : {
					CredentialPasswordRequest Result = new CredentialPasswordRequest ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "QResponse" : {
					Out = null;
					throw new Exception ("Can't create abstract type");
					}

				case "QueryConnectResponse" : {
					QueryConnectResponse Result = new QueryConnectResponse ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "AdvertiseResponse" : {
					AdvertiseResponse Result = new AdvertiseResponse ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "ValidateResponse" : {
					ValidateResponse Result = new ValidateResponse ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "CredentialPasswordResponse" : {
					CredentialPasswordResponse Result = new CredentialPasswordResponse ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					throw new Exception ("Not supported");
					}
				}
			JSONReader.EndObject ();

			// should we check for EOF here?
            }


		public virtual void Deserialize (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			Deserialize (JSONReader);
			}

		public virtual void Deserialize (JSONReader JSONReader) {
            
			bool Going = JSONReader.StartObject ();
			while (Going) {
				string Token = JSONReader.ReadToken ();
				if (Token == null) {
					Going = false;
					}
				else {
					DeserializeToken (JSONReader, Token);
					}
				Going = JSONReader.NextObject ();
				}
			// JSONReader.EndObject (); Implicit 
            }

		public virtual void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				default : {
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	// Every query request contains the following common elements:
	abstract public partial class QRequest : QMessage {
		bool								__Index = false;
		private int						_Index;
		public int						Index {
			get {return _Index;}
			set {_Index = value; __Index = true; }
			}

		static string _Tag = "QRequest";
		public override string Tag () {
			return _Tag;
			}

		public QRequest () {
			}
		public QRequest (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}
		public QRequest (string _String) {
			Deserialize (_String);
			}

		public override string ToString () {
			StringWriter _Writer = new StringWriter ();
			JSONWriter _JSONWriter = new JSONWriter (_Writer);
			Serialize (_JSONWriter, true);
			return _Writer.ToString ();
			}

		public new void Serialize (Writer Writer) {
			Serialize (Writer, false);
			}

		public new void Serialize (Writer Writer, bool tag) {
			bool first = true;
			if (tag) {
				Writer.WriteObjectStart ();
				Writer.WriteToken(_Tag, 0);
				}
			
			Serialize (Writer, true, ref first);
			
			if (tag) {
				Writer.WriteObjectEnd ();
				}			
			}


		public new void Serialize (Writer Writer, bool wrap, ref bool first) {
			if (wrap) {
				Writer.WriteObjectStart ();
				}
			((QMessage)this).Serialize(Writer, false, ref first);
			if (__Index){
				Writer.WriteObjectSeparator (ref first);
				Writer.WriteToken ("Index", 1);
					Writer.WriteInteger32 (Index);
				}
			if (wrap) {
				Writer.WriteObjectEnd ();
				}
			}

        public static void Deserialize(string _Input, out QRequest Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			
			JSONReader.StartObject ();
			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "QRequest" : {
					Out = null;
					throw new Exception ("Can't create abstract type");
					}

				case "QueryConnectRequest" : {
					QueryConnectRequest Result = new QueryConnectRequest ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "AdvertiseRequest" : {
					AdvertiseRequest Result = new AdvertiseRequest ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "ValidateRequest" : {
					ValidateRequest Result = new ValidateRequest ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "CredentialPasswordRequest" : {
					CredentialPasswordRequest Result = new CredentialPasswordRequest ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					throw new Exception ("Not supported");
					}
				}
			JSONReader.EndObject ();

			// should we check for EOF here?
            }


		public new void Deserialize (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			Deserialize (JSONReader);
			}

		public new void Deserialize (JSONReader JSONReader) {
            
			bool Going = JSONReader.StartObject ();
			while (Going) {
				string Token = JSONReader.ReadToken ();
				if (Token == null) {
					Going = false;
					}
				else {
					DeserializeToken (JSONReader, Token);
					}
				Going = JSONReader.NextObject ();
				}
			// JSONReader.EndObject (); Implicit 
            }

		public new void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "Index" : {
					Index = JSONReader.ReadInteger32 ();
					break;
					}
				default : {
					((QMessage)this).DeserializeToken(JSONReader, Tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	// Every Query Response contains the following common elements:
	abstract public partial class QResponse : QMessage {
		bool								__Status = false;
		private int						_Status;
		public int						Status {
			get {return _Status;}
			set {_Status = value; __Status = true; }
			}
		bool								__Index = false;
		private int						_Index;
		public int						Index {
			get {return _Index;}
			set {_Index = value; __Index = true; }
			}
		bool								__Count = false;
		private int						_Count;
		public int						Count {
			get {return _Count;}
			set {_Count = value; __Count = true; }
			}

		static string _Tag = "QResponse";
		public override string Tag () {
			return _Tag;
			}

		public QResponse () {
			}
		public QResponse (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}
		public QResponse (string _String) {
			Deserialize (_String);
			}

		public override string ToString () {
			StringWriter _Writer = new StringWriter ();
			JSONWriter _JSONWriter = new JSONWriter (_Writer);
			Serialize (_JSONWriter, true);
			return _Writer.ToString ();
			}

		public new void Serialize (Writer Writer) {
			Serialize (Writer, false);
			}

		public new void Serialize (Writer Writer, bool tag) {
			bool first = true;
			if (tag) {
				Writer.WriteObjectStart ();
				Writer.WriteToken(_Tag, 0);
				}
			
			Serialize (Writer, true, ref first);
			
			if (tag) {
				Writer.WriteObjectEnd ();
				}			
			}


		public new void Serialize (Writer Writer, bool wrap, ref bool first) {
			if (wrap) {
				Writer.WriteObjectStart ();
				}
			((QMessage)this).Serialize(Writer, false, ref first);
			if (__Status){
				Writer.WriteObjectSeparator (ref first);
				Writer.WriteToken ("Status", 1);
					Writer.WriteInteger32 (Status);
				}
			if (__Index){
				Writer.WriteObjectSeparator (ref first);
				Writer.WriteToken ("Index", 1);
					Writer.WriteInteger32 (Index);
				}
			if (__Count){
				Writer.WriteObjectSeparator (ref first);
				Writer.WriteToken ("Count", 1);
					Writer.WriteInteger32 (Count);
				}
			if (wrap) {
				Writer.WriteObjectEnd ();
				}
			}

        public static void Deserialize(string _Input, out QResponse Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			
			JSONReader.StartObject ();
			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "QResponse" : {
					Out = null;
					throw new Exception ("Can't create abstract type");
					}

				case "QueryConnectResponse" : {
					QueryConnectResponse Result = new QueryConnectResponse ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "AdvertiseResponse" : {
					AdvertiseResponse Result = new AdvertiseResponse ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "ValidateResponse" : {
					ValidateResponse Result = new ValidateResponse ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "CredentialPasswordResponse" : {
					CredentialPasswordResponse Result = new CredentialPasswordResponse ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					throw new Exception ("Not supported");
					}
				}
			JSONReader.EndObject ();

			// should we check for EOF here?
            }


		public new void Deserialize (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			Deserialize (JSONReader);
			}

		public new void Deserialize (JSONReader JSONReader) {
            
			bool Going = JSONReader.StartObject ();
			while (Going) {
				string Token = JSONReader.ReadToken ();
				if (Token == null) {
					Going = false;
					}
				else {
					DeserializeToken (JSONReader, Token);
					}
				Going = JSONReader.NextObject ();
				}
			// JSONReader.EndObject (); Implicit 
            }

		public new void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "Status" : {
					Status = JSONReader.ReadInteger32 ();
					break;
					}
				case "Index" : {
					Index = JSONReader.ReadInteger32 ();
					break;
					}
				case "Count" : {
					Count = JSONReader.ReadInteger32 ();
					break;
					}
				default : {
					((QMessage)this).DeserializeToken(JSONReader, Tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	// Specifies an Internet service by means of a DNS address and either a
	// DNS service prefix, an IP port number or both. An Internet peer 
	// connection MAY be specified by additionally specifying an account.
	public partial class Identifier {
		public string						Name;
		public string						Account;
		public string						Service;
		bool								__Port = false;
		private int						_Port;
		public int						Port {
			get {return _Port;}
			set {_Port = value; __Port = true; }
			}

		static string _Tag = "Identifier";
		public virtual string Tag () {
			return _Tag;
			}

		public Identifier () {
			}
		public Identifier (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}

		public override string ToString () {
			StringWriter _Writer = new StringWriter ();
			JSONWriter _JSONWriter = new JSONWriter (_Writer);
			Serialize (_JSONWriter, true);
			return _Writer.ToString ();
			}

		public virtual void Serialize (Writer Writer) {
			Serialize (Writer, false);
			}

		public virtual void Serialize (Writer Writer, bool tag) {
			bool first = true;
			if (tag) {
				Writer.WriteObjectStart ();
				Writer.WriteToken(_Tag, 0);
				}
			
			Serialize (Writer, true, ref first);
			
			if (tag) {
				Writer.WriteObjectEnd ();
				}			
			}


		public virtual void Serialize (Writer Writer, bool wrap, ref bool first) {
			if (wrap) {
				Writer.WriteObjectStart ();
				}
			if (Name != null) {
				Writer.WriteObjectSeparator (ref first);
				Writer.WriteToken ("Name", 1);
					Writer.WriteString (Name);
				}
			if (Account != null) {
				Writer.WriteObjectSeparator (ref first);
				Writer.WriteToken ("Account", 1);
					Writer.WriteString (Account);
				}
			if (Service != null) {
				Writer.WriteObjectSeparator (ref first);
				Writer.WriteToken ("Service", 1);
					Writer.WriteString (Service);
				}
			if (__Port){
				Writer.WriteObjectSeparator (ref first);
				Writer.WriteToken ("Port", 1);
					Writer.WriteInteger32 (Port);
				}
			if (wrap) {
				Writer.WriteObjectEnd ();
				}
			}

        public static void Deserialize(string _Input, out Identifier Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			
			JSONReader.StartObject ();
			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "Identifier" : {
					Identifier Result = new Identifier ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					throw new Exception ("Not supported");
					}
				}
			JSONReader.EndObject ();

			// should we check for EOF here?
            }


		public virtual void Deserialize (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			Deserialize (JSONReader);
			}

		public virtual void Deserialize (JSONReader JSONReader) {
            
			bool Going = JSONReader.StartObject ();
			while (Going) {
				string Token = JSONReader.ReadToken ();
				if (Token == null) {
					Going = false;
					}
				else {
					DeserializeToken (JSONReader, Token);
					}
				Going = JSONReader.NextObject ();
				}
			// JSONReader.EndObject (); Implicit 
            }

		public virtual void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "Name" : {
					Name = JSONReader.ReadString ();
					break;
					}
				case "Account" : {
					Account = JSONReader.ReadString ();
					break;
					}
				case "Service" : {
					Service = JSONReader.ReadString ();
					break;
					}
				case "Port" : {
					Port = JSONReader.ReadInteger32 ();
					break;
					}
				default : {
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	public partial class Connection {
		public string						IPAddress;
		bool								__IPPort = false;
		private int						_IPPort;
		public int						IPPort {
			get {return _IPPort;}
			set {_IPPort = value; __IPPort = true; }
			}
		public string						Transport;
		public string						TransportPolicy;
		public string						ProtocolPolicy;
		public Advice						Advice;

		static string _Tag = "Connection";
		public virtual string Tag () {
			return _Tag;
			}

		public Connection () {
			}
		public Connection (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}

		public override string ToString () {
			StringWriter _Writer = new StringWriter ();
			JSONWriter _JSONWriter = new JSONWriter (_Writer);
			Serialize (_JSONWriter, true);
			return _Writer.ToString ();
			}

		public virtual void Serialize (Writer Writer) {
			Serialize (Writer, false);
			}

		public virtual void Serialize (Writer Writer, bool tag) {
			bool first = true;
			if (tag) {
				Writer.WriteObjectStart ();
				Writer.WriteToken(_Tag, 0);
				}
			
			Serialize (Writer, true, ref first);
			
			if (tag) {
				Writer.WriteObjectEnd ();
				}			
			}


		public virtual void Serialize (Writer Writer, bool wrap, ref bool first) {
			if (wrap) {
				Writer.WriteObjectStart ();
				}
			if (IPAddress != null) {
				Writer.WriteObjectSeparator (ref first);
				Writer.WriteToken ("IPAddress", 1);
					Writer.WriteString (IPAddress);
				}
			if (__IPPort){
				Writer.WriteObjectSeparator (ref first);
				Writer.WriteToken ("IPPort", 1);
					Writer.WriteInteger32 (IPPort);
				}
			if (Transport != null) {
				Writer.WriteObjectSeparator (ref first);
				Writer.WriteToken ("Transport", 1);
					Writer.WriteString (Transport);
				}
			if (TransportPolicy != null) {
				Writer.WriteObjectSeparator (ref first);
				Writer.WriteToken ("TransportPolicy", 1);
					Writer.WriteString (TransportPolicy);
				}
			if (ProtocolPolicy != null) {
				Writer.WriteObjectSeparator (ref first);
				Writer.WriteToken ("ProtocolPolicy", 1);
					Writer.WriteString (ProtocolPolicy);
				}
			if (Advice != null) {
				Writer.WriteObjectSeparator (ref first);
				Writer.WriteToken ("Advice", 1);
					Advice.Serialize (Writer, false);
				}
			if (wrap) {
				Writer.WriteObjectEnd ();
				}
			}

        public static void Deserialize(string _Input, out Connection Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			
			JSONReader.StartObject ();
			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "Connection" : {
					Connection Result = new Connection ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					throw new Exception ("Not supported");
					}
				}
			JSONReader.EndObject ();

			// should we check for EOF here?
            }


		public virtual void Deserialize (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			Deserialize (JSONReader);
			}

		public virtual void Deserialize (JSONReader JSONReader) {
            
			bool Going = JSONReader.StartObject ();
			while (Going) {
				string Token = JSONReader.ReadToken ();
				if (Token == null) {
					Going = false;
					}
				else {
					DeserializeToken (JSONReader, Token);
					}
				Going = JSONReader.NextObject ();
				}
			// JSONReader.EndObject (); Implicit 
            }

		public virtual void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "IPAddress" : {
					IPAddress = JSONReader.ReadString ();
					break;
					}
				case "IPPort" : {
					IPPort = JSONReader.ReadInteger32 ();
					break;
					}
				case "Transport" : {
					Transport = JSONReader.ReadString ();
					break;
					}
				case "TransportPolicy" : {
					TransportPolicy = JSONReader.ReadString ();
					break;
					}
				case "ProtocolPolicy" : {
					ProtocolPolicy = JSONReader.ReadString ();
					break;
					}
				case "Advice" : {
					Advice = new Advice (JSONReader);
					break;
					}
				default : {
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	public partial class Credential {
		public string						Type;
		public byte[]						Data;

		static string _Tag = "Credential";
		public virtual string Tag () {
			return _Tag;
			}

		public Credential () {
			}
		public Credential (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}

		public override string ToString () {
			StringWriter _Writer = new StringWriter ();
			JSONWriter _JSONWriter = new JSONWriter (_Writer);
			Serialize (_JSONWriter, true);
			return _Writer.ToString ();
			}

		public virtual void Serialize (Writer Writer) {
			Serialize (Writer, false);
			}

		public virtual void Serialize (Writer Writer, bool tag) {
			bool first = true;
			if (tag) {
				Writer.WriteObjectStart ();
				Writer.WriteToken(_Tag, 0);
				}
			
			Serialize (Writer, true, ref first);
			
			if (tag) {
				Writer.WriteObjectEnd ();
				}			
			}


		public virtual void Serialize (Writer Writer, bool wrap, ref bool first) {
			if (wrap) {
				Writer.WriteObjectStart ();
				}
			if (Type != null) {
				Writer.WriteObjectSeparator (ref first);
				Writer.WriteToken ("Type", 1);
					Writer.WriteString (Type);
				}
			if (Data != null) {
				Writer.WriteObjectSeparator (ref first);
				Writer.WriteToken ("Data", 1);
					Writer.WriteBinary (Data);
				}
			if (wrap) {
				Writer.WriteObjectEnd ();
				}
			}

        public static void Deserialize(string _Input, out Credential Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			
			JSONReader.StartObject ();
			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "Credential" : {
					Credential Result = new Credential ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					throw new Exception ("Not supported");
					}
				}
			JSONReader.EndObject ();

			// should we check for EOF here?
            }


		public virtual void Deserialize (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			Deserialize (JSONReader);
			}

		public virtual void Deserialize (JSONReader JSONReader) {
            
			bool Going = JSONReader.StartObject ();
			while (Going) {
				string Token = JSONReader.ReadToken ();
				if (Token == null) {
					Going = false;
					}
				else {
					DeserializeToken (JSONReader, Token);
					}
				Going = JSONReader.NextObject ();
				}
			// JSONReader.EndObject (); Implicit 
            }

		public virtual void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "Type" : {
					Type = JSONReader.ReadString ();
					break;
					}
				case "Data" : {
					Data = JSONReader.ReadBinary ();
					break;
					}
				default : {
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	// Additional information that a service MAY return to support
	// a service connection identification. For example, DNSSEC 
	// signatures chains, SAML assertions, DANE records, 
	// Certificate Transparency proof chains, etc.
	public partial class Advice {
		public string						Type;
		public byte[]						Data;

		static string _Tag = "Advice";
		public virtual string Tag () {
			return _Tag;
			}

		public Advice () {
			}
		public Advice (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}

		public override string ToString () {
			StringWriter _Writer = new StringWriter ();
			JSONWriter _JSONWriter = new JSONWriter (_Writer);
			Serialize (_JSONWriter, true);
			return _Writer.ToString ();
			}

		public virtual void Serialize (Writer Writer) {
			Serialize (Writer, false);
			}

		public virtual void Serialize (Writer Writer, bool tag) {
			bool first = true;
			if (tag) {
				Writer.WriteObjectStart ();
				Writer.WriteToken(_Tag, 0);
				}
			
			Serialize (Writer, true, ref first);
			
			if (tag) {
				Writer.WriteObjectEnd ();
				}			
			}


		public virtual void Serialize (Writer Writer, bool wrap, ref bool first) {
			if (wrap) {
				Writer.WriteObjectStart ();
				}
			if (Type != null) {
				Writer.WriteObjectSeparator (ref first);
				Writer.WriteToken ("Type", 1);
					Writer.WriteString (Type);
				}
			if (Data != null) {
				Writer.WriteObjectSeparator (ref first);
				Writer.WriteToken ("Data", 1);
					Writer.WriteBinary (Data);
				}
			if (wrap) {
				Writer.WriteObjectEnd ();
				}
			}

        public static void Deserialize(string _Input, out Advice Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			
			JSONReader.StartObject ();
			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "Advice" : {
					Advice Result = new Advice ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					throw new Exception ("Not supported");
					}
				}
			JSONReader.EndObject ();

			// should we check for EOF here?
            }


		public virtual void Deserialize (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			Deserialize (JSONReader);
			}

		public virtual void Deserialize (JSONReader JSONReader) {
            
			bool Going = JSONReader.StartObject ();
			while (Going) {
				string Token = JSONReader.ReadToken ();
				if (Token == null) {
					Going = false;
					}
				else {
					DeserializeToken (JSONReader, Token);
					}
				Going = JSONReader.NextObject ();
				}
			// JSONReader.EndObject (); Implicit 
            }

		public virtual void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "Type" : {
					Type = JSONReader.ReadString ();
					break;
					}
				case "Data" : {
					Data = JSONReader.ReadBinary ();
					break;
					}
				default : {
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	// Describes a service connection
	public partial class Service {
		public List<Identifier>				Identifier;
		public Connection						Connection;

		static string _Tag = "Service";
		public virtual string Tag () {
			return _Tag;
			}

		public Service () {
			}
		public Service (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}

		public override string ToString () {
			StringWriter _Writer = new StringWriter ();
			JSONWriter _JSONWriter = new JSONWriter (_Writer);
			Serialize (_JSONWriter, true);
			return _Writer.ToString ();
			}

		public virtual void Serialize (Writer Writer) {
			Serialize (Writer, false);
			}

		public virtual void Serialize (Writer Writer, bool tag) {
			bool first = true;
			if (tag) {
				Writer.WriteObjectStart ();
				Writer.WriteToken(_Tag, 0);
				}
			
			Serialize (Writer, true, ref first);
			
			if (tag) {
				Writer.WriteObjectEnd ();
				}			
			}


		public virtual void Serialize (Writer Writer, bool wrap, ref bool first) {
			if (wrap) {
				Writer.WriteObjectStart ();
				}
			if (Identifier != null) {
				Writer.WriteObjectSeparator (ref first);
				Writer.WriteToken ("Identifier", 1);
				Writer.WriteArrayStart ();
				bool firstarray = true;
				foreach (Identifier _index in Identifier) {
					Writer.WriteArraySeparator (ref firstarray);
					bool firstinner = true;
					_index.Serialize (Writer, true, ref firstinner);
					}
				Writer.WriteArrayEnd ();
				}

			if (Connection != null) {
				Writer.WriteObjectSeparator (ref first);
				Writer.WriteToken ("Connection", 1);
					Connection.Serialize (Writer, false);
				}
			if (wrap) {
				Writer.WriteObjectEnd ();
				}
			}

        public static void Deserialize(string _Input, out Service Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			
			JSONReader.StartObject ();
			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "Service" : {
					Service Result = new Service ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					throw new Exception ("Not supported");
					}
				}
			JSONReader.EndObject ();

			// should we check for EOF here?
            }


		public virtual void Deserialize (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			Deserialize (JSONReader);
			}

		public virtual void Deserialize (JSONReader JSONReader) {
            
			bool Going = JSONReader.StartObject ();
			while (Going) {
				string Token = JSONReader.ReadToken ();
				if (Token == null) {
					Going = false;
					}
				else {
					DeserializeToken (JSONReader, Token);
					}
				Going = JSONReader.NextObject ();
				}
			// JSONReader.EndObject (); Implicit 
            }

		public virtual void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "Identifier" : {
					bool _Going = JSONReader.StartArray ();
					Identifier = new List <Identifier> ();
					while (_Going) {
						Identifier _Item = new Identifier (JSONReader);
						Identifier.Add (_Item);
						_Going = JSONReader.NextArray ();
						}

					break;
					}
				case "Connection" : {
					Connection = new Connection (JSONReader);
					break;
					}
				default : {
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	// Requests a connection context to connect to a specified Internet service
	// or peer.
	public partial class QueryConnect {

		static string _Tag = "QueryConnect";
		public virtual string Tag () {
			return _Tag;
			}

		public QueryConnect () {
			}
		}

	// Specifies the Internet
	// service or peer that a connection is to be established to and the
	// acceptable security policies.
	public partial class QueryConnectRequest : QRequest {
		public Identifier						Identifier;
		public List<string>				Policy;
		bool								__ProveIt = false;
		private bool						_ProveIt;
		public bool						ProveIt {
			get {return _ProveIt;}
			set {_ProveIt = value; __ProveIt = true; }
			}

		static string _Tag = "QueryConnectRequest";
		public override string Tag () {
			return _Tag;
			}

		public QueryConnectRequest () {
			}
		public QueryConnectRequest (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}
		public QueryConnectRequest (string _String) {
			Deserialize (_String);
			}

		public override string ToString () {
			StringWriter _Writer = new StringWriter ();
			JSONWriter _JSONWriter = new JSONWriter (_Writer);
			Serialize (_JSONWriter, true);
			return _Writer.ToString ();
			}

		public new void Serialize (Writer Writer) {
			Serialize (Writer, false);
			}

		public new void Serialize (Writer Writer, bool tag) {
			bool first = true;
			if (tag) {
				Writer.WriteObjectStart ();
				Writer.WriteToken(_Tag, 0);
				}
			
			Serialize (Writer, true, ref first);
			
			if (tag) {
				Writer.WriteObjectEnd ();
				}			
			}


		public new void Serialize (Writer Writer, bool wrap, ref bool first) {
			if (wrap) {
				Writer.WriteObjectStart ();
				}
			((QRequest)this).Serialize(Writer, false, ref first);
			if (Identifier != null) {
				Writer.WriteObjectSeparator (ref first);
				Writer.WriteToken ("Identifier", 1);
					Identifier.Serialize (Writer, false);
				}
			if (Policy != null) {
				Writer.WriteObjectSeparator (ref first);
				Writer.WriteToken ("Policy", 1);
				Writer.WriteArrayStart ();
				bool firstarray = true;
				foreach (string _index in Policy) {
					Writer.WriteArraySeparator (ref firstarray);
					Writer.WriteString (_index);
					}
				Writer.WriteArrayEnd ();
				}

			if (__ProveIt){
				Writer.WriteObjectSeparator (ref first);
				Writer.WriteToken ("ProveIt", 1);
					Writer.WriteBoolean (ProveIt);
				}
			if (wrap) {
				Writer.WriteObjectEnd ();
				}
			}

        public static void Deserialize(string _Input, out QueryConnectRequest Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			
			JSONReader.StartObject ();
			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "QueryConnectRequest" : {
					QueryConnectRequest Result = new QueryConnectRequest ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					throw new Exception ("Not supported");
					}
				}
			JSONReader.EndObject ();

			// should we check for EOF here?
            }


		public new void Deserialize (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			Deserialize (JSONReader);
			}

		public new void Deserialize (JSONReader JSONReader) {
            
			bool Going = JSONReader.StartObject ();
			while (Going) {
				string Token = JSONReader.ReadToken ();
				if (Token == null) {
					Going = false;
					}
				else {
					DeserializeToken (JSONReader, Token);
					}
				Going = JSONReader.NextObject ();
				}
			// JSONReader.EndObject (); Implicit 
            }

		public new void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "Identifier" : {
					Identifier = new Identifier (JSONReader);
					break;
					}
				case "Policy" : {
					bool _Going = JSONReader.StartArray ();
					Policy = new List <String> ();
					while (_Going) {
						String _Item = JSONReader.ReadString ();
						Policy.Add (_Item);
						_Going = JSONReader.NextArray ();
						}

					break;
					}
				case "ProveIt" : {
					ProveIt = JSONReader.ReadBoolean ();
					break;
					}
				default : {
					((QRequest)this).DeserializeToken(JSONReader, Tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	// Returns one or more connection contexts in response to a 
	// QueryConnectRequest Message.
	public partial class QueryConnectResponse : QResponse {
		public List<Connection>				Connection;
		public Advice						Advice;
		public List<string>				Policy;

		static string _Tag = "QueryConnectResponse";
		public override string Tag () {
			return _Tag;
			}

		public QueryConnectResponse () {
			}
		public QueryConnectResponse (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}
		public QueryConnectResponse (string _String) {
			Deserialize (_String);
			}

		public override string ToString () {
			StringWriter _Writer = new StringWriter ();
			JSONWriter _JSONWriter = new JSONWriter (_Writer);
			Serialize (_JSONWriter, true);
			return _Writer.ToString ();
			}

		public new void Serialize (Writer Writer) {
			Serialize (Writer, false);
			}

		public new void Serialize (Writer Writer, bool tag) {
			bool first = true;
			if (tag) {
				Writer.WriteObjectStart ();
				Writer.WriteToken(_Tag, 0);
				}
			
			Serialize (Writer, true, ref first);
			
			if (tag) {
				Writer.WriteObjectEnd ();
				}			
			}


		public new void Serialize (Writer Writer, bool wrap, ref bool first) {
			if (wrap) {
				Writer.WriteObjectStart ();
				}
			((QResponse)this).Serialize(Writer, false, ref first);
			if (Connection != null) {
				Writer.WriteObjectSeparator (ref first);
				Writer.WriteToken ("Connection", 1);
				Writer.WriteArrayStart ();
				bool firstarray = true;
				foreach (Connection _index in Connection) {
					Writer.WriteArraySeparator (ref firstarray);
					bool firstinner = true;
					_index.Serialize (Writer, true, ref firstinner);
					}
				Writer.WriteArrayEnd ();
				}

			if (Advice != null) {
				Writer.WriteObjectSeparator (ref first);
				Writer.WriteToken ("Advice", 1);
					Advice.Serialize (Writer, false);
				}
			if (Policy != null) {
				Writer.WriteObjectSeparator (ref first);
				Writer.WriteToken ("Policy", 1);
				Writer.WriteArrayStart ();
				bool firstarray = true;
				foreach (string _index in Policy) {
					Writer.WriteArraySeparator (ref firstarray);
					Writer.WriteString (_index);
					}
				Writer.WriteArrayEnd ();
				}

			if (wrap) {
				Writer.WriteObjectEnd ();
				}
			}

        public static void Deserialize(string _Input, out QueryConnectResponse Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			
			JSONReader.StartObject ();
			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "QueryConnectResponse" : {
					QueryConnectResponse Result = new QueryConnectResponse ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					throw new Exception ("Not supported");
					}
				}
			JSONReader.EndObject ();

			// should we check for EOF here?
            }


		public new void Deserialize (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			Deserialize (JSONReader);
			}

		public new void Deserialize (JSONReader JSONReader) {
            
			bool Going = JSONReader.StartObject ();
			while (Going) {
				string Token = JSONReader.ReadToken ();
				if (Token == null) {
					Going = false;
					}
				else {
					DeserializeToken (JSONReader, Token);
					}
				Going = JSONReader.NextObject ();
				}
			// JSONReader.EndObject (); Implicit 
            }

		public new void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "Connection" : {
					bool _Going = JSONReader.StartArray ();
					Connection = new List <Connection> ();
					while (_Going) {
						Connection _Item = new Connection (JSONReader);
						Connection.Add (_Item);
						_Going = JSONReader.NextArray ();
						}

					break;
					}
				case "Advice" : {
					Advice = new Advice (JSONReader);
					break;
					}
				case "Policy" : {
					bool _Going = JSONReader.StartArray ();
					Policy = new List <String> ();
					while (_Going) {
						String _Item = JSONReader.ReadString ();
						Policy.Add (_Item);
						_Going = JSONReader.NextArray ();
						}

					break;
					}
				default : {
					((QResponse)this).DeserializeToken(JSONReader, Tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	// Advises a broker that one or more Internet services are 
	// being offered with particular attributes.
	public partial class Advertise {

		static string _Tag = "Advertise";
		public virtual string Tag () {
			return _Tag;
			}

		public Advertise () {
			}
		}

	// Specifies the connection(s) to be established.
	//
	// The attributes required depend on the infrastructure(s) that the 
	// broker is capable of registering the service with.
	public partial class AdvertiseRequest : QRequest {
		public List<Service>				Service;

		static string _Tag = "AdvertiseRequest";
		public override string Tag () {
			return _Tag;
			}

		public AdvertiseRequest () {
			}
		public AdvertiseRequest (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}
		public AdvertiseRequest (string _String) {
			Deserialize (_String);
			}

		public override string ToString () {
			StringWriter _Writer = new StringWriter ();
			JSONWriter _JSONWriter = new JSONWriter (_Writer);
			Serialize (_JSONWriter, true);
			return _Writer.ToString ();
			}

		public new void Serialize (Writer Writer) {
			Serialize (Writer, false);
			}

		public new void Serialize (Writer Writer, bool tag) {
			bool first = true;
			if (tag) {
				Writer.WriteObjectStart ();
				Writer.WriteToken(_Tag, 0);
				}
			
			Serialize (Writer, true, ref first);
			
			if (tag) {
				Writer.WriteObjectEnd ();
				}			
			}


		public new void Serialize (Writer Writer, bool wrap, ref bool first) {
			if (wrap) {
				Writer.WriteObjectStart ();
				}
			((QRequest)this).Serialize(Writer, false, ref first);
			if (Service != null) {
				Writer.WriteObjectSeparator (ref first);
				Writer.WriteToken ("Service", 1);
				Writer.WriteArrayStart ();
				bool firstarray = true;
				foreach (Service _index in Service) {
					Writer.WriteArraySeparator (ref firstarray);
					bool firstinner = true;
					_index.Serialize (Writer, true, ref firstinner);
					}
				Writer.WriteArrayEnd ();
				}

			if (wrap) {
				Writer.WriteObjectEnd ();
				}
			}

        public static void Deserialize(string _Input, out AdvertiseRequest Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			
			JSONReader.StartObject ();
			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "AdvertiseRequest" : {
					AdvertiseRequest Result = new AdvertiseRequest ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					throw new Exception ("Not supported");
					}
				}
			JSONReader.EndObject ();

			// should we check for EOF here?
            }


		public new void Deserialize (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			Deserialize (JSONReader);
			}

		public new void Deserialize (JSONReader JSONReader) {
            
			bool Going = JSONReader.StartObject ();
			while (Going) {
				string Token = JSONReader.ReadToken ();
				if (Token == null) {
					Going = false;
					}
				else {
					DeserializeToken (JSONReader, Token);
					}
				Going = JSONReader.NextObject ();
				}
			// JSONReader.EndObject (); Implicit 
            }

		public new void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "Service" : {
					bool _Going = JSONReader.StartArray ();
					Service = new List <Service> ();
					while (_Going) {
						Service _Item = new Service (JSONReader);
						Service.Add (_Item);
						_Going = JSONReader.NextArray ();
						}

					break;
					}
				default : {
					((QRequest)this).DeserializeToken(JSONReader, Tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	// Specifies the connection(s)
	public partial class AdvertiseResponse : QResponse {
		public List<Service>				Service;

		static string _Tag = "AdvertiseResponse";
		public override string Tag () {
			return _Tag;
			}

		public AdvertiseResponse () {
			}
		public AdvertiseResponse (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}
		public AdvertiseResponse (string _String) {
			Deserialize (_String);
			}

		public override string ToString () {
			StringWriter _Writer = new StringWriter ();
			JSONWriter _JSONWriter = new JSONWriter (_Writer);
			Serialize (_JSONWriter, true);
			return _Writer.ToString ();
			}

		public new void Serialize (Writer Writer) {
			Serialize (Writer, false);
			}

		public new void Serialize (Writer Writer, bool tag) {
			bool first = true;
			if (tag) {
				Writer.WriteObjectStart ();
				Writer.WriteToken(_Tag, 0);
				}
			
			Serialize (Writer, true, ref first);
			
			if (tag) {
				Writer.WriteObjectEnd ();
				}			
			}


		public new void Serialize (Writer Writer, bool wrap, ref bool first) {
			if (wrap) {
				Writer.WriteObjectStart ();
				}
			((QResponse)this).Serialize(Writer, false, ref first);
			if (Service != null) {
				Writer.WriteObjectSeparator (ref first);
				Writer.WriteToken ("Service", 1);
				Writer.WriteArrayStart ();
				bool firstarray = true;
				foreach (Service _index in Service) {
					Writer.WriteArraySeparator (ref firstarray);
					bool firstinner = true;
					_index.Serialize (Writer, true, ref firstinner);
					}
				Writer.WriteArrayEnd ();
				}

			if (wrap) {
				Writer.WriteObjectEnd ();
				}
			}

        public static void Deserialize(string _Input, out AdvertiseResponse Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			
			JSONReader.StartObject ();
			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "AdvertiseResponse" : {
					AdvertiseResponse Result = new AdvertiseResponse ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					throw new Exception ("Not supported");
					}
				}
			JSONReader.EndObject ();

			// should we check for EOF here?
            }


		public new void Deserialize (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			Deserialize (JSONReader);
			}

		public new void Deserialize (JSONReader JSONReader) {
            
			bool Going = JSONReader.StartObject ();
			while (Going) {
				string Token = JSONReader.ReadToken ();
				if (Token == null) {
					Going = false;
					}
				else {
					DeserializeToken (JSONReader, Token);
					}
				Going = JSONReader.NextObject ();
				}
			// JSONReader.EndObject (); Implicit 
            }

		public new void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "Service" : {
					bool _Going = JSONReader.StartArray ();
					Service = new List <Service> ();
					while (_Going) {
						Service _Item = new Service (JSONReader);
						Service.Add (_Item);
						_Going = JSONReader.NextArray ();
						}

					break;
					}
				default : {
					((QResponse)this).DeserializeToken(JSONReader, Tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	// The Validate query requests validation of credentials
	// presented to establish a connection. For example credentials
	// presented by a server in the process of setting up a 
	// TLS session.
	public partial class Validate {

		static string _Tag = "Validate";
		public virtual string Tag () {
			return _Tag;
			}

		public Validate () {
			}
		}

	// Specifies the credentials to be validated and the purpose
	// for which they are to be used.
	public partial class ValidateRequest : QRequest {
		public Service						Service;
		public Credential						Credential;
		public List<string>				Policy;

		static string _Tag = "ValidateRequest";
		public override string Tag () {
			return _Tag;
			}

		public ValidateRequest () {
			}
		public ValidateRequest (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}
		public ValidateRequest (string _String) {
			Deserialize (_String);
			}

		public override string ToString () {
			StringWriter _Writer = new StringWriter ();
			JSONWriter _JSONWriter = new JSONWriter (_Writer);
			Serialize (_JSONWriter, true);
			return _Writer.ToString ();
			}

		public new void Serialize (Writer Writer) {
			Serialize (Writer, false);
			}

		public new void Serialize (Writer Writer, bool tag) {
			bool first = true;
			if (tag) {
				Writer.WriteObjectStart ();
				Writer.WriteToken(_Tag, 0);
				}
			
			Serialize (Writer, true, ref first);
			
			if (tag) {
				Writer.WriteObjectEnd ();
				}			
			}


		public new void Serialize (Writer Writer, bool wrap, ref bool first) {
			if (wrap) {
				Writer.WriteObjectStart ();
				}
			((QRequest)this).Serialize(Writer, false, ref first);
			if (Service != null) {
				Writer.WriteObjectSeparator (ref first);
				Writer.WriteToken ("Service", 1);
					Service.Serialize (Writer, false);
				}
			if (Credential != null) {
				Writer.WriteObjectSeparator (ref first);
				Writer.WriteToken ("Credential", 1);
					Credential.Serialize (Writer, false);
				}
			if (Policy != null) {
				Writer.WriteObjectSeparator (ref first);
				Writer.WriteToken ("Policy", 1);
				Writer.WriteArrayStart ();
				bool firstarray = true;
				foreach (string _index in Policy) {
					Writer.WriteArraySeparator (ref firstarray);
					Writer.WriteString (_index);
					}
				Writer.WriteArrayEnd ();
				}

			if (wrap) {
				Writer.WriteObjectEnd ();
				}
			}

        public static void Deserialize(string _Input, out ValidateRequest Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			
			JSONReader.StartObject ();
			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "ValidateRequest" : {
					ValidateRequest Result = new ValidateRequest ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					throw new Exception ("Not supported");
					}
				}
			JSONReader.EndObject ();

			// should we check for EOF here?
            }


		public new void Deserialize (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			Deserialize (JSONReader);
			}

		public new void Deserialize (JSONReader JSONReader) {
            
			bool Going = JSONReader.StartObject ();
			while (Going) {
				string Token = JSONReader.ReadToken ();
				if (Token == null) {
					Going = false;
					}
				else {
					DeserializeToken (JSONReader, Token);
					}
				Going = JSONReader.NextObject ();
				}
			// JSONReader.EndObject (); Implicit 
            }

		public new void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "Service" : {
					Service = new Service (JSONReader);
					break;
					}
				case "Credential" : {
					Credential = new Credential (JSONReader);
					break;
					}
				case "Policy" : {
					bool _Going = JSONReader.StartArray ();
					Policy = new List <String> ();
					while (_Going) {
						String _Item = JSONReader.ReadString ();
						Policy.Add (_Item);
						_Going = JSONReader.NextArray ();
						}

					break;
					}
				default : {
					((QRequest)this).DeserializeToken(JSONReader, Tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	// Reports the status of the credential presented.
	public partial class ValidateResponse : QResponse {
		public List<string>				Policy;

		static string _Tag = "ValidateResponse";
		public override string Tag () {
			return _Tag;
			}

		public ValidateResponse () {
			}
		public ValidateResponse (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}
		public ValidateResponse (string _String) {
			Deserialize (_String);
			}

		public override string ToString () {
			StringWriter _Writer = new StringWriter ();
			JSONWriter _JSONWriter = new JSONWriter (_Writer);
			Serialize (_JSONWriter, true);
			return _Writer.ToString ();
			}

		public new void Serialize (Writer Writer) {
			Serialize (Writer, false);
			}

		public new void Serialize (Writer Writer, bool tag) {
			bool first = true;
			if (tag) {
				Writer.WriteObjectStart ();
				Writer.WriteToken(_Tag, 0);
				}
			
			Serialize (Writer, true, ref first);
			
			if (tag) {
				Writer.WriteObjectEnd ();
				}			
			}


		public new void Serialize (Writer Writer, bool wrap, ref bool first) {
			if (wrap) {
				Writer.WriteObjectStart ();
				}
			((QResponse)this).Serialize(Writer, false, ref first);
			if (Policy != null) {
				Writer.WriteObjectSeparator (ref first);
				Writer.WriteToken ("Policy", 1);
				Writer.WriteArrayStart ();
				bool firstarray = true;
				foreach (string _index in Policy) {
					Writer.WriteArraySeparator (ref firstarray);
					Writer.WriteString (_index);
					}
				Writer.WriteArrayEnd ();
				}

			if (wrap) {
				Writer.WriteObjectEnd ();
				}
			}

        public static void Deserialize(string _Input, out ValidateResponse Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			
			JSONReader.StartObject ();
			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "ValidateResponse" : {
					ValidateResponse Result = new ValidateResponse ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					throw new Exception ("Not supported");
					}
				}
			JSONReader.EndObject ();

			// should we check for EOF here?
            }


		public new void Deserialize (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			Deserialize (JSONReader);
			}

		public new void Deserialize (JSONReader JSONReader) {
            
			bool Going = JSONReader.StartObject ();
			while (Going) {
				string Token = JSONReader.ReadToken ();
				if (Token == null) {
					Going = false;
					}
				else {
					DeserializeToken (JSONReader, Token);
					}
				Going = JSONReader.NextObject ();
				}
			// JSONReader.EndObject (); Implicit 
            }

		public new void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "Policy" : {
					bool _Going = JSONReader.StartArray ();
					Policy = new List <String> ();
					while (_Going) {
						String _Item = JSONReader.ReadString ();
						Policy.Add (_Item);
						_Going = JSONReader.NextArray ();
						}

					break;
					}
				default : {
					((QResponse)this).DeserializeToken(JSONReader, Tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	// The QueryCredentialPassword query is used to request a password credential
	// that the user has previously chosen to store at the broker.
	public partial class QueryCredentialPassword {

		static string _Tag = "QueryCredentialPassword";
		public virtual string Tag () {
			return _Tag;
			}

		public QueryCredentialPassword () {
			}
		}

	// Requests a password for the specified account.
	public partial class CredentialPasswordRequest : QRequest {
		public string						Account;

		static string _Tag = "CredentialPasswordRequest";
		public override string Tag () {
			return _Tag;
			}

		public CredentialPasswordRequest () {
			}
		public CredentialPasswordRequest (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}
		public CredentialPasswordRequest (string _String) {
			Deserialize (_String);
			}

		public override string ToString () {
			StringWriter _Writer = new StringWriter ();
			JSONWriter _JSONWriter = new JSONWriter (_Writer);
			Serialize (_JSONWriter, true);
			return _Writer.ToString ();
			}

		public new void Serialize (Writer Writer) {
			Serialize (Writer, false);
			}

		public new void Serialize (Writer Writer, bool tag) {
			bool first = true;
			if (tag) {
				Writer.WriteObjectStart ();
				Writer.WriteToken(_Tag, 0);
				}
			
			Serialize (Writer, true, ref first);
			
			if (tag) {
				Writer.WriteObjectEnd ();
				}			
			}


		public new void Serialize (Writer Writer, bool wrap, ref bool first) {
			if (wrap) {
				Writer.WriteObjectStart ();
				}
			((QRequest)this).Serialize(Writer, false, ref first);
			if (Account != null) {
				Writer.WriteObjectSeparator (ref first);
				Writer.WriteToken ("Account", 1);
					Writer.WriteString (Account);
				}
			if (wrap) {
				Writer.WriteObjectEnd ();
				}
			}

        public static void Deserialize(string _Input, out CredentialPasswordRequest Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			
			JSONReader.StartObject ();
			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "CredentialPasswordRequest" : {
					CredentialPasswordRequest Result = new CredentialPasswordRequest ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					throw new Exception ("Not supported");
					}
				}
			JSONReader.EndObject ();

			// should we check for EOF here?
            }


		public new void Deserialize (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			Deserialize (JSONReader);
			}

		public new void Deserialize (JSONReader JSONReader) {
            
			bool Going = JSONReader.StartObject ();
			while (Going) {
				string Token = JSONReader.ReadToken ();
				if (Token == null) {
					Going = false;
					}
				else {
					DeserializeToken (JSONReader, Token);
					}
				Going = JSONReader.NextObject ();
				}
			// JSONReader.EndObject (); Implicit 
            }

		public new void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "Account" : {
					Account = JSONReader.ReadString ();
					break;
					}
				default : {
					((QRequest)this).DeserializeToken(JSONReader, Tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	// Returns a password for the specified account.
	public partial class CredentialPasswordResponse : QResponse {
		public string						Password;

		static string _Tag = "CredentialPasswordResponse";
		public override string Tag () {
			return _Tag;
			}

		public CredentialPasswordResponse () {
			}
		public CredentialPasswordResponse (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}
		public CredentialPasswordResponse (string _String) {
			Deserialize (_String);
			}

		public override string ToString () {
			StringWriter _Writer = new StringWriter ();
			JSONWriter _JSONWriter = new JSONWriter (_Writer);
			Serialize (_JSONWriter, true);
			return _Writer.ToString ();
			}

		public new void Serialize (Writer Writer) {
			Serialize (Writer, false);
			}

		public new void Serialize (Writer Writer, bool tag) {
			bool first = true;
			if (tag) {
				Writer.WriteObjectStart ();
				Writer.WriteToken(_Tag, 0);
				}
			
			Serialize (Writer, true, ref first);
			
			if (tag) {
				Writer.WriteObjectEnd ();
				}			
			}


		public new void Serialize (Writer Writer, bool wrap, ref bool first) {
			if (wrap) {
				Writer.WriteObjectStart ();
				}
			((QResponse)this).Serialize(Writer, false, ref first);
			if (Password != null) {
				Writer.WriteObjectSeparator (ref first);
				Writer.WriteToken ("Password", 1);
					Writer.WriteString (Password);
				}
			if (wrap) {
				Writer.WriteObjectEnd ();
				}
			}

        public static void Deserialize(string _Input, out CredentialPasswordResponse Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			
			JSONReader.StartObject ();
			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "CredentialPasswordResponse" : {
					CredentialPasswordResponse Result = new CredentialPasswordResponse ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					throw new Exception ("Not supported");
					}
				}
			JSONReader.EndObject ();

			// should we check for EOF here?
            }


		public new void Deserialize (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			Deserialize (JSONReader);
			}

		public new void Deserialize (JSONReader JSONReader) {
            
			bool Going = JSONReader.StartObject ();
			while (Going) {
				string Token = JSONReader.ReadToken ();
				if (Token == null) {
					Going = false;
					}
				else {
					DeserializeToken (JSONReader, Token);
					}
				Going = JSONReader.NextObject ();
				}
			// JSONReader.EndObject (); Implicit 
            }

		public new void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "Password" : {
					Password = JSONReader.ReadString ();
					break;
					}
				default : {
					((QResponse)this).DeserializeToken(JSONReader, Tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	}

