
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Goedel.Protocol;




namespace OBPConnection {

	abstract public partial class Message {

		static string _Tag = "Message";
		public virtual string Tag () {
			return _Tag;
			}

		public Message () {
			}
		public Message (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}
		public Message (string _String) {
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

        public static void Deserialize(string _Input, out Message Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			
			JSONReader.StartObject ();
			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "Message" : {
					Out = null;
					throw new Exception ("Can't create abstract type");
					}

				case "Response" : {
					Out = null;
					throw new Exception ("Can't create abstract type");
					}

				case "ErrorResponse" : {
					ErrorResponse Result = new ErrorResponse ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "BindResponse" : {
					Out = null;
					throw new Exception ("Can't create abstract type");
					}

				case "OpenResponse" : {
					OpenResponse Result = new OpenResponse ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "TicketResponse" : {
					TicketResponse Result = new TicketResponse ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "UnbindResponse" : {
					UnbindResponse Result = new UnbindResponse ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "Request" : {
					Out = null;
					throw new Exception ("Can't create abstract type");
					}

				case "BindRequest" : {
					Out = null;
					throw new Exception ("Can't create abstract type");
					}

				case "OpenRequest" : {
					OpenRequest Result = new OpenRequest ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "TicketRequest" : {
					TicketRequest Result = new TicketRequest ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "UnbindRequest" : {
					UnbindRequest Result = new UnbindRequest ();
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

	abstract public partial class Response : Message {
		bool								__Status = false;
		private int						_Status;
		public int						Status {
			get {return _Status;}
			set {_Status = value; __Status = true; }
			}
		public string						StatusDescription;

		static string _Tag = "Response";
		public override string Tag () {
			return _Tag;
			}

		public Response () {
			}
		public Response (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}
		public Response (string _String) {
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
			((Message)this).Serialize(Writer, false, ref first);
			if (__Status){
				Writer.WriteObjectSeparator (ref first);
				Writer.WriteToken ("Status", 1);
					Writer.WriteInteger32 (Status);
				}
			if (StatusDescription != null) {
				Writer.WriteObjectSeparator (ref first);
				Writer.WriteToken ("StatusDescription", 1);
					Writer.WriteString (StatusDescription);
				}
			if (wrap) {
				Writer.WriteObjectEnd ();
				}
			}

        public static void Deserialize(string _Input, out Response Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			
			JSONReader.StartObject ();
			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "Response" : {
					Out = null;
					throw new Exception ("Can't create abstract type");
					}

				case "ErrorResponse" : {
					ErrorResponse Result = new ErrorResponse ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "BindResponse" : {
					Out = null;
					throw new Exception ("Can't create abstract type");
					}

				case "OpenResponse" : {
					OpenResponse Result = new OpenResponse ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "TicketResponse" : {
					TicketResponse Result = new TicketResponse ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "UnbindResponse" : {
					UnbindResponse Result = new UnbindResponse ();
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
				case "StatusDescription" : {
					StatusDescription = JSONReader.ReadString ();
					break;
					}
				default : {
					((Message)this).DeserializeToken(JSONReader, Tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	// An error Response MAY be returned in Response to any Request.
	//
	// Note that requests MAY be rejected by the code implementing
	// the transport binding before application processing begins
	// and so a server is not guaranteed to provide an error Response
	// message.
	public partial class ErrorResponse : Response {

		static string _Tag = "ErrorResponse";
		public override string Tag () {
			return _Tag;
			}

		public ErrorResponse () {
			}
		public ErrorResponse (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}
		public ErrorResponse (string _String) {
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
			((Response)this).Serialize(Writer, false, ref first);
			if (wrap) {
				Writer.WriteObjectEnd ();
				}
			}

        public static void Deserialize(string _Input, out ErrorResponse Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			
			JSONReader.StartObject ();
			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "ErrorResponse" : {
					ErrorResponse Result = new ErrorResponse ();
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
				default : {
					((Response)this).DeserializeToken(JSONReader, Tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	abstract public partial class Request : Message {

		static string _Tag = "Request";
		public override string Tag () {
			return _Tag;
			}

		public Request () {
			}
		public Request (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}
		public Request (string _String) {
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
			((Message)this).Serialize(Writer, false, ref first);
			if (wrap) {
				Writer.WriteObjectEnd ();
				}
			}

        public static void Deserialize(string _Input, out Request Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			
			JSONReader.StartObject ();
			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "Request" : {
					Out = null;
					throw new Exception ("Can't create abstract type");
					}

				case "BindRequest" : {
					Out = null;
					throw new Exception ("Can't create abstract type");
					}

				case "OpenRequest" : {
					OpenRequest Result = new OpenRequest ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "TicketRequest" : {
					TicketRequest Result = new TicketRequest ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "UnbindRequest" : {
					UnbindRequest Result = new UnbindRequest ();
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
				default : {
					((Message)this).DeserializeToken(JSONReader, Tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	// Parameters describing a cryptographic context.
	public partial class Cryptographic {
		public string						Protocol;
		public byte[]						Secret;
		public string						Encryption;
		public string						Authentication;
		public byte[]						Ticket;
		bool								__Expires = false;
		private DateTime						_Expires;
		public DateTime						Expires {
			get {return _Expires;}
			set {_Expires = value; __Expires = true; }
			}

		static string _Tag = "Cryptographic";
		public virtual string Tag () {
			return _Tag;
			}

		public Cryptographic () {
			}
		public Cryptographic (JSONReader JSONReader) {
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
			if (Protocol != null) {
				Writer.WriteObjectSeparator (ref first);
				Writer.WriteToken ("Protocol", 1);
					Writer.WriteString (Protocol);
				}
			if (Secret != null) {
				Writer.WriteObjectSeparator (ref first);
				Writer.WriteToken ("Secret", 1);
					Writer.WriteBinary (Secret);
				}
			if (Encryption != null) {
				Writer.WriteObjectSeparator (ref first);
				Writer.WriteToken ("Encryption", 1);
					Writer.WriteString (Encryption);
				}
			if (Authentication != null) {
				Writer.WriteObjectSeparator (ref first);
				Writer.WriteToken ("Authentication", 1);
					Writer.WriteString (Authentication);
				}
			if (Ticket != null) {
				Writer.WriteObjectSeparator (ref first);
				Writer.WriteToken ("Ticket", 1);
					Writer.WriteBinary (Ticket);
				}
			if (__Expires){
				Writer.WriteObjectSeparator (ref first);
				Writer.WriteToken ("Expires", 1);
					Writer.WriteDateTime (Expires);
				}
			if (wrap) {
				Writer.WriteObjectEnd ();
				}
			}

        public static void Deserialize(string _Input, out Cryptographic Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			
			JSONReader.StartObject ();
			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "Cryptographic" : {
					Cryptographic Result = new Cryptographic ();
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
				case "Protocol" : {
					Protocol = JSONReader.ReadString ();
					break;
					}
				case "Secret" : {
					Secret = JSONReader.ReadBinary ();
					break;
					}
				case "Encryption" : {
					Encryption = JSONReader.ReadString ();
					break;
					}
				case "Authentication" : {
					Authentication = JSONReader.ReadString ();
					break;
					}
				case "Ticket" : {
					Ticket = JSONReader.ReadBinary ();
					break;
					}
				case "Expires" : {
					Expires = JSONReader.ReadDateTime ();
					break;
					}
				default : {
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	public partial class ImageLink {
		public string						Algorithm;
		public byte[]						Image;

		static string _Tag = "ImageLink";
		public virtual string Tag () {
			return _Tag;
			}

		public ImageLink () {
			}
		public ImageLink (JSONReader JSONReader) {
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
			if (Algorithm != null) {
				Writer.WriteObjectSeparator (ref first);
				Writer.WriteToken ("Algorithm", 1);
					Writer.WriteString (Algorithm);
				}
			if (Image != null) {
				Writer.WriteObjectSeparator (ref first);
				Writer.WriteToken ("Image", 1);
					Writer.WriteBinary (Image);
				}
			if (wrap) {
				Writer.WriteObjectEnd ();
				}
			}

        public static void Deserialize(string _Input, out ImageLink Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			
			JSONReader.StartObject ();
			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "ImageLink" : {
					ImageLink Result = new ImageLink ();
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
				case "Algorithm" : {
					Algorithm = JSONReader.ReadString ();
					break;
					}
				case "Image" : {
					Image = JSONReader.ReadBinary ();
					break;
					}
				default : {
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	// Contains information describing a network connection.
	public partial class Connection {
		public string						Name;
		bool								__Port = false;
		private int						_Port;
		public int						Port {
			get {return _Port;}
			set {_Port = value; __Port = true; }
			}
		public string						Address;
		bool								__Priority = false;
		private int						_Priority;
		public int						Priority {
			get {return _Priority;}
			set {_Priority = value; __Priority = true; }
			}
		bool								__Weight = false;
		private int						_Weight;
		public int						Weight {
			get {return _Weight;}
			set {_Weight = value; __Weight = true; }
			}
		public string						Transport;
		bool								__Expires = false;
		private DateTime						_Expires;
		public DateTime						Expires {
			get {return _Expires;}
			set {_Expires = value; __Expires = true; }
			}
		public Cryptographic						Cryptographic;

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
			if (Name != null) {
				Writer.WriteObjectSeparator (ref first);
				Writer.WriteToken ("Name", 1);
					Writer.WriteString (Name);
				}
			if (__Port){
				Writer.WriteObjectSeparator (ref first);
				Writer.WriteToken ("Port", 1);
					Writer.WriteInteger32 (Port);
				}
			if (Address != null) {
				Writer.WriteObjectSeparator (ref first);
				Writer.WriteToken ("Address", 1);
					Writer.WriteString (Address);
				}
			if (__Priority){
				Writer.WriteObjectSeparator (ref first);
				Writer.WriteToken ("Priority", 1);
					Writer.WriteInteger32 (Priority);
				}
			if (__Weight){
				Writer.WriteObjectSeparator (ref first);
				Writer.WriteToken ("Weight", 1);
					Writer.WriteInteger32 (Weight);
				}
			if (Transport != null) {
				Writer.WriteObjectSeparator (ref first);
				Writer.WriteToken ("Transport", 1);
					Writer.WriteString (Transport);
				}
			if (__Expires){
				Writer.WriteObjectSeparator (ref first);
				Writer.WriteToken ("Expires", 1);
					Writer.WriteDateTime (Expires);
				}
			if (Cryptographic != null) {
				Writer.WriteObjectSeparator (ref first);
				Writer.WriteToken ("Cryptographic", 1);
					Cryptographic.Serialize (Writer, false);
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
				case "Name" : {
					Name = JSONReader.ReadString ();
					break;
					}
				case "Port" : {
					Port = JSONReader.ReadInteger32 ();
					break;
					}
				case "Address" : {
					Address = JSONReader.ReadString ();
					break;
					}
				case "Priority" : {
					Priority = JSONReader.ReadInteger32 ();
					break;
					}
				case "Weight" : {
					Weight = JSONReader.ReadInteger32 ();
					break;
					}
				case "Transport" : {
					Transport = JSONReader.ReadString ();
					break;
					}
				case "Expires" : {
					Expires = JSONReader.ReadDateTime ();
					break;
					}
				case "Cryptographic" : {
					Cryptographic = new Cryptographic (JSONReader);
					break;
					}
				default : {
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	// Binding a device is a two step protocol that begins with the
	// Start Query followed by a sequence of Ticket queries.
	public partial class Bind {

		static string _Tag = "Bind";
		public virtual string Tag () {
			return _Tag;
			}

		public Bind () {
			}
		}

	// The following parameters MAY occur in either a
	// StartRequest or TicketRequest:
	abstract public partial class BindRequest : Request {
		public List<string>				Encryption;
		public List<string>				Authentication;

		static string _Tag = "BindRequest";
		public override string Tag () {
			return _Tag;
			}

		public BindRequest () {
			}
		public BindRequest (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}
		public BindRequest (string _String) {
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
			((Request)this).Serialize(Writer, false, ref first);
			if (Encryption != null) {
				Writer.WriteObjectSeparator (ref first);
				Writer.WriteToken ("Encryption", 1);
				Writer.WriteArrayStart ();
				bool firstarray = true;
				foreach (string _index in Encryption) {
					Writer.WriteArraySeparator (ref firstarray);
					Writer.WriteString (_index);
					}
				Writer.WriteArrayEnd ();
				}

			if (Authentication != null) {
				Writer.WriteObjectSeparator (ref first);
				Writer.WriteToken ("Authentication", 1);
				Writer.WriteArrayStart ();
				bool firstarray = true;
				foreach (string _index in Authentication) {
					Writer.WriteArraySeparator (ref firstarray);
					Writer.WriteString (_index);
					}
				Writer.WriteArrayEnd ();
				}

			if (wrap) {
				Writer.WriteObjectEnd ();
				}
			}

        public static void Deserialize(string _Input, out BindRequest Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			
			JSONReader.StartObject ();
			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "BindRequest" : {
					Out = null;
					throw new Exception ("Can't create abstract type");
					}

				case "OpenRequest" : {
					OpenRequest Result = new OpenRequest ();
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
				case "Encryption" : {
					bool _Going = JSONReader.StartArray ();
					Encryption = new List <String> ();
					while (_Going) {
						String _Item = JSONReader.ReadString ();
						Encryption.Add (_Item);
						_Going = JSONReader.NextArray ();
						}

					break;
					}
				case "Authentication" : {
					bool _Going = JSONReader.StartArray ();
					Authentication = new List <String> ();
					while (_Going) {
						String _Item = JSONReader.ReadString ();
						Authentication.Add (_Item);
						_Going = JSONReader.NextArray ();
						}

					break;
					}
				default : {
					((Request)this).DeserializeToken(JSONReader, Tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	// The following parameters MAY occur in either a
	// StartResponse or TicketResponse:
	abstract public partial class BindResponse : Response {
		public List<Cryptographic>				Cryptographic;
		public List<Connection>				Service;

		static string _Tag = "BindResponse";
		public override string Tag () {
			return _Tag;
			}

		public BindResponse () {
			}
		public BindResponse (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}
		public BindResponse (string _String) {
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
			((Response)this).Serialize(Writer, false, ref first);
			if (Cryptographic != null) {
				Writer.WriteObjectSeparator (ref first);
				Writer.WriteToken ("Cryptographic", 1);
				Writer.WriteArrayStart ();
				bool firstarray = true;
				foreach (Cryptographic _index in Cryptographic) {
					Writer.WriteArraySeparator (ref firstarray);
					bool firstinner = true;
					_index.Serialize (Writer, true, ref firstinner);
					}
				Writer.WriteArrayEnd ();
				}

			if (Service != null) {
				Writer.WriteObjectSeparator (ref first);
				Writer.WriteToken ("Service", 1);
				Writer.WriteArrayStart ();
				bool firstarray = true;
				foreach (Connection _index in Service) {
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

        public static void Deserialize(string _Input, out BindResponse Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			
			JSONReader.StartObject ();
			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "BindResponse" : {
					Out = null;
					throw new Exception ("Can't create abstract type");
					}

				case "OpenResponse" : {
					OpenResponse Result = new OpenResponse ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "TicketResponse" : {
					TicketResponse Result = new TicketResponse ();
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
				case "Cryptographic" : {
					bool _Going = JSONReader.StartArray ();
					Cryptographic = new List <Cryptographic> ();
					while (_Going) {
						Cryptographic _Item = new Cryptographic (JSONReader);
						Cryptographic.Add (_Item);
						_Going = JSONReader.NextArray ();
						}

					break;
					}
				case "Service" : {
					bool _Going = JSONReader.StartArray ();
					Service = new List <Connection> ();
					while (_Going) {
						Connection _Item = new Connection (JSONReader);
						Service.Add (_Item);
						_Going = JSONReader.NextArray ();
						}

					break;
					}
				default : {
					((Response)this).DeserializeToken(JSONReader, Tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	// The OpenRequest Message is used to begin a device binding transaction.
	// Depending on the authentication requirements of the service the
	// transaction may be completed in a single query or require a 
	// further Ticket Query to complete.
	//
	// If authentication is required, the mechanism to be used depends on
	// the capabilities of the device, the requirements of the broker and
	// the existing relationship between the user and the broker.
	//
	// If the device supports some means of data entry, authentication 
	// MAY be achieved by entering a passcode previously delivered out
	// of band into the device.
	//
	// The OpenRequest specifies the properties of the service
	// (Account, Domain) and Device (ID, URI, Name) that will remain
	// constant throughout the period that the device binding is active
	// and parameters to be used for the mutual authentication protocol.
	public partial class OpenRequest : BindRequest {
		public string						Account;
		public string						Domain;
		bool								__HavePasscode = false;
		private bool						_HavePasscode;
		public bool						HavePasscode {
			get {return _HavePasscode;}
			set {_HavePasscode = value; __HavePasscode = true; }
			}
		bool								__HaveDisplay = false;
		private bool						_HaveDisplay;
		public bool						HaveDisplay {
			get {return _HaveDisplay;}
			set {_HaveDisplay = value; __HaveDisplay = true; }
			}
		public byte[]						Challenge;
		public string						DeviceID;
		public string						DeviceURI;
		public ImageLink						DeviceImage;
		public string						DeviceName;

		static string _Tag = "OpenRequest";
		public override string Tag () {
			return _Tag;
			}

		public OpenRequest () {
			}
		public OpenRequest (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}
		public OpenRequest (string _String) {
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
			((BindRequest)this).Serialize(Writer, false, ref first);
			if (Account != null) {
				Writer.WriteObjectSeparator (ref first);
				Writer.WriteToken ("Account", 1);
					Writer.WriteString (Account);
				}
			if (Domain != null) {
				Writer.WriteObjectSeparator (ref first);
				Writer.WriteToken ("Domain", 1);
					Writer.WriteString (Domain);
				}
			if (__HavePasscode){
				Writer.WriteObjectSeparator (ref first);
				Writer.WriteToken ("HavePasscode", 1);
					Writer.WriteBoolean (HavePasscode);
				}
			if (__HaveDisplay){
				Writer.WriteObjectSeparator (ref first);
				Writer.WriteToken ("HaveDisplay", 1);
					Writer.WriteBoolean (HaveDisplay);
				}
			if (Challenge != null) {
				Writer.WriteObjectSeparator (ref first);
				Writer.WriteToken ("Challenge", 1);
					Writer.WriteBinary (Challenge);
				}
			if (DeviceID != null) {
				Writer.WriteObjectSeparator (ref first);
				Writer.WriteToken ("DeviceID", 1);
					Writer.WriteString (DeviceID);
				}
			if (DeviceURI != null) {
				Writer.WriteObjectSeparator (ref first);
				Writer.WriteToken ("DeviceURI", 1);
					Writer.WriteString (DeviceURI);
				}
			if (DeviceImage != null) {
				Writer.WriteObjectSeparator (ref first);
				Writer.WriteToken ("DeviceImage", 1);
					DeviceImage.Serialize (Writer, false);
				}
			if (DeviceName != null) {
				Writer.WriteObjectSeparator (ref first);
				Writer.WriteToken ("DeviceName", 1);
					Writer.WriteString (DeviceName);
				}
			if (wrap) {
				Writer.WriteObjectEnd ();
				}
			}

        public static void Deserialize(string _Input, out OpenRequest Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			
			JSONReader.StartObject ();
			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "OpenRequest" : {
					OpenRequest Result = new OpenRequest ();
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
				case "Domain" : {
					Domain = JSONReader.ReadString ();
					break;
					}
				case "HavePasscode" : {
					HavePasscode = JSONReader.ReadBoolean ();
					break;
					}
				case "HaveDisplay" : {
					HaveDisplay = JSONReader.ReadBoolean ();
					break;
					}
				case "Challenge" : {
					Challenge = JSONReader.ReadBinary ();
					break;
					}
				case "DeviceID" : {
					DeviceID = JSONReader.ReadString ();
					break;
					}
				case "DeviceURI" : {
					DeviceURI = JSONReader.ReadString ();
					break;
					}
				case "DeviceImage" : {
					DeviceImage = new ImageLink (JSONReader);
					break;
					}
				case "DeviceName" : {
					DeviceName = JSONReader.ReadString ();
					break;
					}
				default : {
					((BindRequest)this).DeserializeToken(JSONReader, Tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	// An Open Request MAY be accepted immediately or be held pending
	// completion of an inband or out-of-band authentication process.
	//
	// The OpenResponse returns a ticket and a set of cryptographic
	// connection parameters in either case. If the 
	public partial class OpenResponse : BindResponse {
		public byte[]						Challenge;
		public byte[]						ChallengeResponse;
		public List<ImageLink>				VerificationImage;

		static string _Tag = "OpenResponse";
		public override string Tag () {
			return _Tag;
			}

		public OpenResponse () {
			}
		public OpenResponse (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}
		public OpenResponse (string _String) {
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
			((BindResponse)this).Serialize(Writer, false, ref first);
			if (Challenge != null) {
				Writer.WriteObjectSeparator (ref first);
				Writer.WriteToken ("Challenge", 1);
					Writer.WriteBinary (Challenge);
				}
			if (ChallengeResponse != null) {
				Writer.WriteObjectSeparator (ref first);
				Writer.WriteToken ("ChallengeResponse", 1);
					Writer.WriteBinary (ChallengeResponse);
				}
			if (VerificationImage != null) {
				Writer.WriteObjectSeparator (ref first);
				Writer.WriteToken ("VerificationImage", 1);
				Writer.WriteArrayStart ();
				bool firstarray = true;
				foreach (ImageLink _index in VerificationImage) {
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

        public static void Deserialize(string _Input, out OpenResponse Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			
			JSONReader.StartObject ();
			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "OpenResponse" : {
					OpenResponse Result = new OpenResponse ();
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
				case "Challenge" : {
					Challenge = JSONReader.ReadBinary ();
					break;
					}
				case "ChallengeResponse" : {
					ChallengeResponse = JSONReader.ReadBinary ();
					break;
					}
				case "VerificationImage" : {
					bool _Going = JSONReader.StartArray ();
					VerificationImage = new List <ImageLink> ();
					while (_Going) {
						ImageLink _Item = new ImageLink (JSONReader);
						VerificationImage.Add (_Item);
						_Going = JSONReader.NextArray ();
						}

					break;
					}
				default : {
					((BindResponse)this).DeserializeToken(JSONReader, Tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	// The TicketRequest message is used to (1) complete a binding Request
	// begun with an OpenRequest and (2) to refresh ticket or connection 
	// parameters as necessary.
	public partial class TicketRequest : Request {
		public byte[]						ChallengeResponse;

		static string _Tag = "TicketRequest";
		public override string Tag () {
			return _Tag;
			}

		public TicketRequest () {
			}
		public TicketRequest (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}
		public TicketRequest (string _String) {
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
			((Request)this).Serialize(Writer, false, ref first);
			if (ChallengeResponse != null) {
				Writer.WriteObjectSeparator (ref first);
				Writer.WriteToken ("ChallengeResponse", 1);
					Writer.WriteBinary (ChallengeResponse);
				}
			if (wrap) {
				Writer.WriteObjectEnd ();
				}
			}

        public static void Deserialize(string _Input, out TicketRequest Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			
			JSONReader.StartObject ();
			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "TicketRequest" : {
					TicketRequest Result = new TicketRequest ();
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
				case "ChallengeResponse" : {
					ChallengeResponse = JSONReader.ReadBinary ();
					break;
					}
				default : {
					((Request)this).DeserializeToken(JSONReader, Tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	// The TicketResponse message returns cryptographic and/or connection
	// context information to a client.
	public partial class TicketResponse : BindResponse {

		static string _Tag = "TicketResponse";
		public override string Tag () {
			return _Tag;
			}

		public TicketResponse () {
			}
		public TicketResponse (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}
		public TicketResponse (string _String) {
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
			((BindResponse)this).Serialize(Writer, false, ref first);
			if (wrap) {
				Writer.WriteObjectEnd ();
				}
			}

        public static void Deserialize(string _Input, out TicketResponse Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			
			JSONReader.StartObject ();
			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "TicketResponse" : {
					TicketResponse Result = new TicketResponse ();
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
				default : {
					((BindResponse)this).DeserializeToken(JSONReader, Tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	// Requests that a previous device association be deleted.
	public partial class Unbind {

		static string _Tag = "Unbind";
		public virtual string Tag () {
			return _Tag;
			}

		public Unbind () {
			}
		}

	// Since the ticket identifies the binding to be deleted, the
	// only thing that the unbind message need specify is that
	// the device wishes to cancel the binding.
	public partial class UnbindRequest : Request {

		static string _Tag = "UnbindRequest";
		public override string Tag () {
			return _Tag;
			}

		public UnbindRequest () {
			}
		public UnbindRequest (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}
		public UnbindRequest (string _String) {
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
			((Request)this).Serialize(Writer, false, ref first);
			if (wrap) {
				Writer.WriteObjectEnd ();
				}
			}

        public static void Deserialize(string _Input, out UnbindRequest Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			
			JSONReader.StartObject ();
			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "UnbindRequest" : {
					UnbindRequest Result = new UnbindRequest ();
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
				default : {
					((Request)this).DeserializeToken(JSONReader, Tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	// Reports on the success of the unbinding operation.
	//
	// If the server reports success, the client SHOULD delete the
	// ticket and all information relating to the binding.
	//
	// A service MAY continue to accept a ticket after an unbind Request
	// has been granted but MUST NOT accept such a ticket for
	// a bind Request.
	public partial class UnbindResponse : Response {

		static string _Tag = "UnbindResponse";
		public override string Tag () {
			return _Tag;
			}

		public UnbindResponse () {
			}
		public UnbindResponse (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}
		public UnbindResponse (string _String) {
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
			((Response)this).Serialize(Writer, false, ref first);
			if (wrap) {
				Writer.WriteObjectEnd ();
				}
			}

        public static void Deserialize(string _Input, out UnbindResponse Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			
			JSONReader.StartObject ();
			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "UnbindResponse" : {
					UnbindResponse Result = new UnbindResponse ();
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
				default : {
					((Response)this).DeserializeToken(JSONReader, Tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	}

