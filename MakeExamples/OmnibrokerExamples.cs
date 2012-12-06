// #script 1.0 
// Script Syntax Version:  1.0
// #license MITLicense 

//  Copyright ©  2011 by Default Deny Security Inc.
//  
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//  
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
//  
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.
//  
//  
// #using TestProtoGen 
using  TestProtoGen;
// #using Goedel.Protocol 
using  Goedel.Protocol;
// #using OBPConnection 
using  OBPConnection;
// #pclass OmnibrokerExample Generate 
using System;
using System.IO;
using System.Collections.Generic;
using Goedel.Registry;
namespace OmnibrokerExample {
	public class Generate {
		TextWriter _Output;
		public string _Indent = "";
		public Generate (TextWriter Output) {
			_Output = Output;
			}

		// #% string Service; 
		 string Service;
		// #% DateTime Now; 
		 DateTime Now;
		// #method ConnectionExample ExampleData Example 
		

		//
		// ConnectionExample
		//
		public void ConnectionExample (ExampleData Example) {
			// #% Service = Example.OmnibrokerService; 
			 Service = Example.OmnibrokerService;
			// #% WrapWriter WrapWriter = (WrapWriter) _Output; 
			 WrapWriter WrapWriter = (WrapWriter) _Output;
			// #% WrapWriter.MinLeading = "  "; 
			 WrapWriter.MinLeading = "  ";
			// #% WrapWriter.WrappedLeading = "  "; 
			 WrapWriter.WrappedLeading = "  ";
			// #% WrapWriter.Width = 66; 
			 WrapWriter.Width = 66;
			// <!-- Begin section of automatically generated text 
			_Output.Write ("<!-- Begin section of automatically generated text\n{0}", _Indent);
			// 	Line wrap = #{WrapWriter.Width} 
			_Output.Write ("	Line wrap = {1}\n{0}", _Indent, WrapWriter.Width);
			//    --> 
			_Output.Write ("   -->\n{0}", _Indent);
			//         <section title="Illustrative example" anchor="ConnectionRequestExample"> 
			_Output.Write ("        <section title=\"Illustrative example\" anchor=\"ConnectionRequestExample\">\n{0}", _Indent);
			//           <t> 
			_Output.Write ("          <t>\n{0}", _Indent);
			//             Alice is an employee of Example Inc. which runs its own 
			_Output.Write ("            Alice is an employee of Example Inc. which runs its own\n{0}", _Indent);
			//             local omnibroker service '#{Example.OmnibrokerService}'.  
			_Output.Write ("            local omnibroker service '{1}'. \n{0}", _Indent, Example.OmnibrokerService);
			// 			To configure her machine for use 
			_Output.Write ("			To configure her machine for use\n{0}", _Indent);
			//             with this service, Alice contacts her network 
			_Output.Write ("            with this service, Alice contacts her network\n{0}", _Indent);
			//             administrator who assigns her the account identifier 
			_Output.Write ("            administrator who assigns her the account identifier\n{0}", _Indent);
			//             '#{Example.Username}' and obtains a PIN number from the service  
			_Output.Write ("            '{1}' and obtains a PIN number from the service \n{0}", _Indent, Example.Username);
			//             '#{Example.PIN}' 
			_Output.Write ("            '{1}'\n{0}", _Indent, Example.PIN);
			//           </t> 
			_Output.Write ("          </t>\n{0}", _Indent);
			//           <t> 
			_Output.Write ("          <t>\n{0}", _Indent);
			//             Alice enters the values '#{Example.Username}@#{Example.OmnibrokerService}' and 
			_Output.Write ("            Alice enters the values '{1}@{2}' and\n{0}", _Indent, Example.Username, Example.OmnibrokerService);
			//             '#{Example.PIN}' into her Omnibroker-enabled  
			_Output.Write ("            '{1}' into her Omnibroker-enabled \n{0}", _Indent, Example.PIN);
			//             Web browser. 
			_Output.Write ("            Web browser.\n{0}", _Indent);
			//           </t> 
			_Output.Write ("          </t>\n{0}", _Indent);
			//            
			_Output.Write ("          \n{0}", _Indent);
			//           <t> 
			_Output.Write ("          <t>\n{0}", _Indent);
			//             The Web browser uses the local DNS to resolve '#{Example.OmnibrokerService}' 
			_Output.Write ("            The Web browser uses the local DNS to resolve '{1}'\n{0}", _Indent, Example.OmnibrokerService);
			//             and establishes a HTTPS connection to the specified IP address. 
			_Output.Write ("            and establishes a HTTPS connection to the specified IP address.\n{0}", _Indent);
			//             The client verifies that the certificate presented has a valid 
			_Output.Write ("            The client verifies that the certificate presented has a valid\n{0}", _Indent);
			//             certificate chain to an embedded trust anchor under an  
			_Output.Write ("            certificate chain to an embedded trust anchor under an \n{0}", _Indent);
			//             appropriate certificate policy (e.g. compliant with the Extended Validation 
			_Output.Write ("            appropriate certificate policy (e.g. compliant with the Extended Validation\n{0}", _Indent);
			//             Criteria defined by CA-Browser Forum). 
			_Output.Write ("            Criteria defined by CA-Browser Forum).\n{0}", _Indent);
			//           </t> 
			_Output.Write ("          </t>\n{0}", _Indent);
			//           <t> 
			_Output.Write ("          <t>\n{0}", _Indent);
			//             Having established an authenticated and encrypted TLS  
			_Output.Write ("            Having established an authenticated and encrypted TLS \n{0}", _Indent);
			//             session to the Omnibroker service, the client sends 
			_Output.Write ("            session to the Omnibroker service, the client sends\n{0}", _Indent);
			//             an OpenRequest message to begin the process of mutual  
			_Output.Write ("            an OpenRequest message to begin the process of mutual \n{0}", _Indent);
			//             authentication. This message specifies the cryptographic 
			_Output.Write ("            authentication. This message specifies the cryptographic\n{0}", _Indent);
			//             parameters supported by the client (Authentication, Encryption) 
			_Output.Write ("            parameters supported by the client (Authentication, Encryption)\n{0}", _Indent);
			//             and a nonce value (Challenge), device identification 
			_Output.Write ("            and a nonce value (Challenge), device identification\n{0}", _Indent);
			//             parameters (DeviceID, DeviceURI, DeviceName) and the 
			_Output.Write ("            parameters (DeviceID, DeviceURI, DeviceName) and the\n{0}", _Indent);
			//             name of the account being requested. 
			_Output.Write ("            name of the account being requested.\n{0}", _Indent);
			//           </t> 
			_Output.Write ("          </t>\n{0}", _Indent);
			//           <t> 
			_Output.Write ("          <t>\n{0}", _Indent);
			//             The client does not specify the PIN code in the initial Request,  
			_Output.Write ("            The client does not specify the PIN code in the initial request, \n{0}", _Indent);
			//             nor is the Request authenticated. Instead the client informs 
			_Output.Write ("            nor is the request authenticated. Instead the client informs\n{0}", _Indent);
			//             the server that it has a PIN code that can be supplied if 
			_Output.Write ("            the server that it has a PIN code that can be supplied if\n{0}", _Indent);
			//             necessary.  
			_Output.Write ("            necessary. \n{0}", _Indent);
			//           </t> 
			_Output.Write ("          </t>\n{0}", _Indent);
			// #call ExampleWSMessage Example.OpenRequest 
			ExampleWSMessage (Example.OpenRequest);
			//           <t> 
			_Output.Write ("          <t>\n{0}", _Indent);
			//             The service receives the Request. If the Request is consistent  
			_Output.Write ("            The service receives the request. If the request is consistent \n{0}", _Indent);
			//             with the access control policy for the server it returns a  
			_Output.Write ("            with the access control policy for the server it returns a \n{0}", _Indent);
			//             reply that specifies the chosen cryptographic parameters  
			_Output.Write ("            reply that specifies the chosen cryptographic parameters \n{0}", _Indent);
			//             (Cryptographic), responds to the client issued by the  
			_Output.Write ("            (Cryptographic), responds to the client issued by the \n{0}", _Indent);
			//             client to establish server proof of knowsledge of the PIN 
			_Output.Write ("            client to establish server proof of knowsledge of the PIN\n{0}", _Indent);
			//             (ChallengeResponse) and issues a challenge to the client  
			_Output.Write ("            (ChallengeResponse) and issues a challenge to the client \n{0}", _Indent);
			//             (Challenge). 
			_Output.Write ("            (Challenge).\n{0}", _Indent);
			//           </t> 
			_Output.Write ("          </t>\n{0}", _Indent);
			//           <t> 
			_Output.Write ("          <t>\n{0}", _Indent);
			//             The cryptographic parameters specify algorithms to be used  
			_Output.Write ("            The cryptographic parameters specify algorithms to be used \n{0}", _Indent);
			//             for encryption and authentication, a shared secret and a  
			_Output.Write ("            for encryption and authentication, a shared secret and a \n{0}", _Indent);
			//             ticket value. Note that while the shared secret is exchanged  
			_Output.Write ("            ticket value. Note that while the shared secret is exchanged \n{0}", _Indent);
			//             in plaintext form in the HTTP binding, the connection 
			_Output.Write ("            in plaintext form in the HTTP binding, the connection\n{0}", _Indent);
			//             protocol MUST provide encryption. 
			_Output.Write ("            protocol MUST provide encryption.\n{0}", _Indent);
			//           </t> 
			_Output.Write ("          </t>\n{0}", _Indent);
			// #call ExampleWSMessage Example.OpenResponse 
			ExampleWSMessage (Example.OpenResponse);
			//           <t> 
			_Output.Write ("          <t>\n{0}", _Indent);
			//             To complete the transaction, the client sends a TicketRequest message 
			_Output.Write ("            To complete the transaction, the client sends a TicketRequest message\n{0}", _Indent);
			//             to the serice containing a Response to the PIN challenge sent by the 
			_Output.Write ("            to the serice containing a response to the PIN challenge sent by the\n{0}", _Indent);
			//             service (ChallengeResponse). 
			_Output.Write ("            service (ChallengeResponse).\n{0}", _Indent);
			//             The TicketRequest message is authenticated under the shared secret specified 
			_Output.Write ("            The TicketRequest message is authenticated under the shared secret specified\n{0}", _Indent);
			//             in the OpenResponse message. 
			_Output.Write ("            in the OpenResponse message.\n{0}", _Indent);
			//           </t> 
			_Output.Write ("          </t>\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// #call ExampleWSMessage Example.TicketRequest 
			ExampleWSMessage (Example.TicketRequest);
			//  
			_Output.Write ("\n{0}", _Indent);
			// <t> 
			_Output.Write ("<t>\n{0}", _Indent);
			//   If the Response to the PIN challenge is correct, the service responds 
			_Output.Write ("  If the response to the PIN challenge is correct, the service responds\n{0}", _Indent);
			//   with a message that specifies a set of cryptographic parameters to be 
			_Output.Write ("  with a message that specifies a set of cryptographic parameters to be\n{0}", _Indent);
			//   used to authenticate future interactions with the service (Cryptographic)  
			_Output.Write ("  used to authenticate future interactions with the service (Cryptographic) \n{0}", _Indent);
			//   and a set of connection parameters for servers supporting the  
			_Output.Write ("  and a set of connection parameters for servers supporting the \n{0}", _Indent);
			//   Query Service (Service). 
			_Output.Write ("  Query Service (Service).\n{0}", _Indent);
			// </t> 
			_Output.Write ("</t>\n{0}", _Indent);
			//   <t> 
			_Output.Write ("  <t>\n{0}", _Indent);
			//     In this case the server returns three connections, each offering a 
			_Output.Write ("    In this case the server returns three connections, each offering a\n{0}", _Indent);
			//     different transport protocol option. Each connection specifies its 
			_Output.Write ("    different transport protocol option. Each connection specifies its\n{0}", _Indent);
			//     own set of cryptographic parameters (or will when the code is written 
			_Output.Write ("    own set of cryptographic parameters (or will when the code is written\n{0}", _Indent);
			//     for that). 
			_Output.Write ("    for that).\n{0}", _Indent);
			//   </t> 
			_Output.Write ("  </t>\n{0}", _Indent);
			// #call ExampleWSMessage Example.TicketResponse 
			ExampleWSMessage (Example.TicketResponse);
			//           <t> 
			_Output.Write ("          <t>\n{0}", _Indent);
			//             When Alice's machine is to be transfered to another employee, the  
			_Output.Write ("            When Alice's machine is to be transfered to another employee, the \n{0}", _Indent);
			//             Unbind transaction is used. The only parameter required is the 
			_Output.Write ("            Unbind transaction is used. The only parameter required is the\n{0}", _Indent);
			//             Ticket identifying the device association (Ticket). 
			_Output.Write ("            Ticket identifying the device association (Ticket).\n{0}", _Indent);
			//           </t> 
			_Output.Write ("          </t>\n{0}", _Indent);
			// #call ExampleWSMessage Example.UnbindRequest 
			ExampleWSMessage (Example.UnbindRequest);
			//           <t> 
			_Output.Write ("          <t>\n{0}", _Indent);
			//             Since the unbind Response represents the termination of the 
			_Output.Write ("            Since the unbind response represents the termination of the\n{0}", _Indent);
			//             relationship with the Omnibroker, the Response merely reports 
			_Output.Write ("            relationship with the Omnibroker, the response merely reports\n{0}", _Indent);
			//             the success or failure of the Request. 
			_Output.Write ("            the success or failure of the request.\n{0}", _Indent);
			//           </t> 
			_Output.Write ("          </t>\n{0}", _Indent);
			// #call ExampleWSMessage Example.UnbindResponse 
			ExampleWSMessage (Example.UnbindResponse);
			//           <t> 
			_Output.Write ("          <t>\n{0}", _Indent);
			//             The 'Ticket' value presented in the foregoing examples is  
			_Output.Write ("            The 'Ticket' value presented in the foregoing examples is \n{0}", _Indent);
			//             a sequence of binary data generated by the service that is 
			_Output.Write ("            a sequence of binary data generated by the service that is\n{0}", _Indent);
			//             opaque to the client. Services MAY generate ticket values  
			_Output.Write ("            opaque to the client. Services MAY generate ticket values \n{0}", _Indent);
			//             with a substructure that enable the service to avoid 
			_Output.Write ("            with a substructure that enable the service to avoid\n{0}", _Indent);
			//             the need to maintain server side state. 
			_Output.Write ("            the need to maintain server side state.\n{0}", _Indent);
			//           </t> 
			_Output.Write ("          </t>\n{0}", _Indent);
			//         <t> 
			_Output.Write ("        <t>\n{0}", _Indent);
			//           In the foregoing example, the ticket structures generated 
			_Output.Write ("          In the foregoing example, the ticket structures generated\n{0}", _Indent);
			//           by the service encode the cryptographic parameter data, 
			_Output.Write ("          by the service encode the cryptographic parameter data,\n{0}", _Indent);
			//           the shared secret, account identifier and an authentication  
			_Output.Write ("          the shared secret, account identifier and an authentication \n{0}", _Indent);
			//           value. The initial ticket value generated additionally encodes 
			_Output.Write ("          value. The initial ticket value generated additionally encodes\n{0}", _Indent);
			//           the values of the client and service challeng values for use 
			_Output.Write ("          the values of the client and service challeng values for use\n{0}", _Indent);
			//           in calculating the necessary ChallengeResponse. 
			_Output.Write ("          in calculating the necessary ChallengeResponse.\n{0}", _Indent);
			//           </t> 
			_Output.Write ("          </t>\n{0}", _Indent);
			//        
			_Output.Write ("      \n{0}", _Indent);
			//         </section> 
			_Output.Write ("        </section>\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// 		<!-- End section of automatically generated text --> 
			_Output.Write ("		<!-- End section of automatically generated text -->\n{0}", _Indent);
			// #end method 
			}
		//  
		//  
		// #method QueryExample ExampleData Example 
		

		//
		// QueryExample
		//
		public void QueryExample (ExampleData Example) {
			// #% Service = Example.OmnibrokerService; 
			 Service = Example.OmnibrokerService;
			// #% WrapWriter WrapWriter = (WrapWriter) _Output; 
			 WrapWriter WrapWriter = (WrapWriter) _Output;
			// #% WrapWriter.MinLeading = "  "; 
			 WrapWriter.MinLeading = "  ";
			// #% WrapWriter.WrappedLeading = "  "; 
			 WrapWriter.WrappedLeading = "  ";
			// #% WrapWriter.Width = 66; 
			 WrapWriter.Width = 66;
			// <!-- Begin section of automatically generated text 
			_Output.Write ("<!-- Begin section of automatically generated text\n{0}", _Indent);
			// 	Line wrap = #{WrapWriter.Width} 
			_Output.Write ("	Line wrap = {1}\n{0}", _Indent, WrapWriter.Width);
			//    --> 
			_Output.Write ("   -->\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			//         <section title="Illustrative example"> 
			_Output.Write ("        <section title=\"Illustrative example\">\n{0}", _Indent);
			// 		  <t> 
			_Output.Write ("		  <t>\n{0}", _Indent);
			// 			[For illustrative purposes, all the examples in this section 
			_Output.Write ("			[For illustrative purposes, all the examples in this section\n{0}", _Indent);
			// 			are shown using the Web Services Transport binding.  
			_Output.Write ("			are shown using the Web Services Transport binding. \n{0}", _Indent);
			// 			Examples of other transport bindgins are shown in  
			_Output.Write ("			Examples of other transport bindgins are shown in \n{0}", _Indent);
			// 			section [TBS].] 
			_Output.Write ("			section [TBS].]\n{0}", _Indent);
			// 		  </t> 
			_Output.Write ("		  </t>\n{0}", _Indent);
			//           <t> 
			_Output.Write ("          <t>\n{0}", _Indent);
			// 		     The Alice of the previous example uses her Web browser to 
			_Output.Write ("		     The Alice of the previous example uses her Web browser to\n{0}", _Indent);
			// 			 access the URL #{Example.QueryConnectURL}. Assuming this was done while 
			_Output.Write ("			 access the URL {1}. Assuming this was done while\n{0}", _Indent, Example.QueryConnectURL);
			// 			 the prior binding was still active (i.e. before the UnbindRequest 
			_Output.Write ("			 the prior binding was still active (i.e. before the UnbindRequest\n{0}", _Indent);
			// 			 message was sent), the Web browser would send a QueryConnectRequest  
			_Output.Write ("			 message was sent), the Web browser would send a QueryConnectRequest \n{0}", _Indent);
			// 			 Request to obtain the best connection parameters for the  
			_Output.Write ("			 request to obtain the best connection parameters for the \n{0}", _Indent);
			// 			 #{Example.QueryConnectSite} protocol at  
			_Output.Write ("			 {1} protocol at \n{0}", _Indent, Example.QueryConnectSite);
			// 			 #{Example.QueryConnectProtocol}: 
			_Output.Write ("			 {1}:\n{0}", _Indent, Example.QueryConnectProtocol);
			// 		  </t> 
			_Output.Write ("		  </t>\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// #call ExampleWSMessage Example.QueryConnectRequest 
			ExampleWSMessage (Example.QueryConnectRequest);
			// 		<t> 
			_Output.Write ("		<t>\n{0}", _Indent);
			// 			The service responds with an ordered list of possible connections. 
			_Output.Write ("			The service responds with an ordered list of possible connections.\n{0}", _Indent);
			// 			In this case the site is accessible via plain TCP transport or with 
			_Output.Write ("			In this case the site is accessible via plain TCP transport or with\n{0}", _Indent);
			// 			TLS. Since TLS is the preferred protocol, that connection is 
			_Output.Write ("			TLS. Since TLS is the preferred protocol, that connection is\n{0}", _Indent);
			// 			listed first. 
			_Output.Write ("			listed first.\n{0}", _Indent);
			// 		</t> 
			_Output.Write ("		</t>\n{0}", _Indent);
			// #call ExampleWSMessage Example.QueryConnectResponse 
			ExampleWSMessage (Example.QueryConnectResponse);
			// 		<t> 
			_Output.Write ("		<t>\n{0}", _Indent);
			// 			Although the QueryConnectResponse returned the hash of a PKIX 
			_Output.Write ("			Although the QueryConnectResponse returned the hash of a PKIX\n{0}", _Indent);
			// 			certificate considered valid for that connection, the server 
			_Output.Write ("			certificate considered valid for that connection, the server\n{0}", _Indent);
			// 			returns a different certificate which the client verifies using 
			_Output.Write ("			returns a different certificate which the client verifies using\n{0}", _Indent);
			// 			the ValidateRequest query. 
			_Output.Write ("			the ValidateRequest query.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// 		</t> 
			_Output.Write ("		</t>\n{0}", _Indent);
			// #call ExampleWSMessage Example.QueryValidateRequest 
			ExampleWSMessage (Example.QueryValidateRequest);
			// 		<t> 
			_Output.Write ("		<t>\n{0}", _Indent);
			// 			The service validates the certificate according to the  
			_Output.Write ("			The service validates the certificate according to the \n{0}", _Indent);
			// 			Omnibroker service policy.  
			_Output.Write ("			Omnibroker service policy. \n{0}", _Indent);
			// 		</t> 
			_Output.Write ("		</t>\n{0}", _Indent);
			// #call ExampleWSMessage Example.QueryValidateResponse 
			ExampleWSMessage (Example.QueryValidateResponse);
			// 		</section> 
			_Output.Write ("		</section>\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// 		<!-- End section of automatically generated text --> 
			_Output.Write ("		<!-- End section of automatically generated text -->\n{0}", _Indent);
			// #end method 
			}
		//  
		//  
		// #method MutualAuth ExampleData Example 
		

		//
		// MutualAuth
		//
		public void MutualAuth (ExampleData Example) {
			//  
			_Output.Write ("\n{0}", _Indent);
			//     <section title ="Mutual Authentication" anchor="MutualAuth"> 
			_Output.Write ("    <section title =\"Mutual Authentication\" anchor=\"MutualAuth\">\n{0}", _Indent);
			//       <t> 
			_Output.Write ("      <t>\n{0}", _Indent);
			//         A Connection Service MAY require that a connection Request be  
			_Output.Write ("        A Connection Service MAY require that a connection request be \n{0}", _Indent);
			//         authenticated. Three authentication mechanisms are defined. 
			_Output.Write ("        authenticated. Three authentication mechanisms are defined.\n{0}", _Indent);
			//       </t> 
			_Output.Write ("      </t>\n{0}", _Indent);
			//       <t> 
			_Output.Write ("      <t>\n{0}", _Indent);
			//         <list> 
			_Output.Write ("        <list>\n{0}", _Indent);
			//           <t> 
			_Output.Write ("          <t>\n{0}", _Indent);
			//             PIN Code: The client and server demonstrate mutual knowledge of 
			_Output.Write ("            PIN Code: The client and server demonstrate mutual knowledge of\n{0}", _Indent);
			//             a PIN code previously exchanged out of band. 
			_Output.Write ("            a PIN code previously exchanged out of band.\n{0}", _Indent);
			//           </t> 
			_Output.Write ("          </t>\n{0}", _Indent);
			//           <t> 
			_Output.Write ("          <t>\n{0}", _Indent);
			//             Established Key: The client and server demonstrate knowledge of the 
			_Output.Write ("            Established Key: The client and server demonstrate knowledge of the\n{0}", _Indent);
			//             private key associated with a credential previously  
			_Output.Write ("            private key associated with a credential previously \n{0}", _Indent);
			//             established. This MAY be a public key or a symmetric key. 
			_Output.Write ("            established. This MAY be a public key or a symmetric key.\n{0}", _Indent);
			//           </t> 
			_Output.Write ("          </t>\n{0}", _Indent);
			//           <t> 
			_Output.Write ("          <t>\n{0}", _Indent);
			//             Out of Band Confirmation: The Request for access is  
			_Output.Write ("            Out of Band Confirmation: The request for access is \n{0}", _Indent);
			//             forwarded to an out of band confirmation service. 
			_Output.Write ("            forwarded to an out of band confirmation service.\n{0}", _Indent);
			//           </t> 
			_Output.Write ("          </t>\n{0}", _Indent);
			//         </list> 
			_Output.Write ("        </list>\n{0}", _Indent);
			//       </t> 
			_Output.Write ("      </t>\n{0}", _Indent);
			//      
			_Output.Write ("    \n{0}", _Indent);
			//       <section title ="PIN Authentication" anchor="ChallengeResponse"> 
			_Output.Write ("      <section title =\"PIN Authentication\" anchor=\"ChallengeResponse\">\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			//         <t> 
			_Output.Write ("        <t>\n{0}", _Indent);
			//           [Motivation] 
			_Output.Write ("          [Motivation]\n{0}", _Indent);
			//         </t> 
			_Output.Write ("        </t>\n{0}", _Indent);
			//         <t> 
			_Output.Write ("        <t>\n{0}", _Indent);
			//           Although the PIN value is never exposed on the wire in any form, 
			_Output.Write ("          Although the PIN value is never exposed on the wire in any form,\n{0}", _Indent);
			//           the protcol considers the PIN value to be a text string encoded  
			_Output.Write ("          the protcol considers the PIN value to be a text string encoded \n{0}", _Indent);
			//           in UTF8 encoding. 
			_Output.Write ("          in UTF8 encoding.\n{0}", _Indent);
			//         </t> 
			_Output.Write ("        </t>\n{0}", _Indent);
			//         <t> 
			_Output.Write ("        <t>\n{0}", _Indent);
			//           [Considerations for PIN character set choice discussed in body 
			_Output.Write ("          [Considerations for PIN character set choice discussed in body\n{0}", _Indent);
			//           of draft, servers MUST support numeric only, clients SHOULD  
			_Output.Write ("          of draft, servers MUST support numeric only, clients SHOULD \n{0}", _Indent);
			//           support full Unicode] 
			_Output.Write ("          support full Unicode]\n{0}", _Indent);
			//         </t> 
			_Output.Write ("        </t>\n{0}", _Indent);
			//         <t> 
			_Output.Write ("        <t>\n{0}", _Indent);
			//           The PIN Mechanism is a three step process: 
			_Output.Write ("          The PIN Mechanism is a three step process:\n{0}", _Indent);
			//         </t> 
			_Output.Write ("        </t>\n{0}", _Indent);
			//         <t> 
			_Output.Write ("        <t>\n{0}", _Indent);
			//           <list> 
			_Output.Write ("          <list>\n{0}", _Indent);
			//             <t> 
			_Output.Write ("            <t>\n{0}", _Indent);
			//               The client sends an OpenRequest message to the Service containing  
			_Output.Write ("              The client sends an OpenRequest message to the Service containing \n{0}", _Indent);
			//               a challenge value CC. 
			_Output.Write ("              a challenge value CC.\n{0}", _Indent);
			//             </t> 
			_Output.Write ("            </t>\n{0}", _Indent);
			//             <t> 
			_Output.Write ("            <t>\n{0}", _Indent);
			//               The service returns an OpenResponse message containing to the client a server 
			_Output.Write ("              The service returns an OpenResponse message containing to the client a server\n{0}", _Indent);
			//               challenge value SV and a server Response value SR. 
			_Output.Write ("              challenge value SV and a server response value SR.\n{0}", _Indent);
			//             </t> 
			_Output.Write ("            </t>\n{0}", _Indent);
			//             <t> 
			_Output.Write ("            <t>\n{0}", _Indent);
			//               The client sends a TicketRequest message to the service containing 
			_Output.Write ("              The client sends a TicketRequest message to the service containing\n{0}", _Indent);
			//               a client Response value CR. 
			_Output.Write ("              a client response value CR.\n{0}", _Indent);
			//             </t> 
			_Output.Write ("            </t>\n{0}", _Indent);
			//           </list> 
			_Output.Write ("          </list>\n{0}", _Indent);
			//         </t> 
			_Output.Write ("        </t>\n{0}", _Indent);
			//         <t> 
			_Output.Write ("        <t>\n{0}", _Indent);
			//           Since no prior authentication key has been established, the  
			_Output.Write ("          Since no prior authentication key has been established, the \n{0}", _Indent);
			//           OpenRequest and OpenResponse messages are initially sent without  
			_Output.Write ("          OpenRequest and OpenResponse messages are initially sent without \n{0}", _Indent);
			//           authentication and authentication values established by the 
			_Output.Write ("          authentication and authentication values established by the\n{0}", _Indent);
			//           Challenge-Response mechanism. 
			_Output.Write ("          Challenge-Response mechanism.\n{0}", _Indent);
			//         </t> 
			_Output.Write ("        </t>\n{0}", _Indent);
			//         <t> 
			_Output.Write ("        <t>\n{0}", _Indent);
			//           The Challenge values CC,  and SC are cryptographic nonces. The nonces  
			_Output.Write ("          The Challenge values CC,  and SC are cryptographic nonces. The nonces \n{0}", _Indent);
			//           SHOULD be generated using an appropriate cryptographic random 
			_Output.Write ("          SHOULD be generated using an appropriate cryptographic random\n{0}", _Indent);
			//           source. The nonces MUST be at least as long as 128 bits, MUST be at least  
			_Output.Write ("          source. The nonces MUST be at least as long as 128 bits, MUST be at least \n{0}", _Indent);
			//           the minimum key size  
			_Output.Write ("          the minimum key size \n{0}", _Indent);
			//           of the authentication algorithm used and MUST NOT more than 640 bits  
			_Output.Write ("          of the authentication algorithm used and MUST NOT more than 640 bits \n{0}", _Indent);
			//           in length (640 bits should be enough for anybody). 
			_Output.Write ("          in length (640 bits should be enough for anybody).\n{0}", _Indent);
			//         </t> 
			_Output.Write ("        </t>\n{0}", _Indent);
			//         <t> 
			_Output.Write ("        <t>\n{0}", _Indent);
			//           The server Response and client Response values are generated 
			_Output.Write ("          The server response and client response values are generated\n{0}", _Indent);
			//           using an authentication algorithm selected by the server from the 
			_Output.Write ("          using an authentication algorithm selected by the server from the\n{0}", _Indent);
			//           choices proposed by the client in the OpenRequest message. 
			_Output.Write ("          choices proposed by the client in the OpenRequest message.\n{0}", _Indent);
			//         </t> 
			_Output.Write ("        </t>\n{0}", _Indent);
			//         <t> 
			_Output.Write ("        <t>\n{0}", _Indent);
			//           The algorithn chosen may be a MAC algorithm or an  
			_Output.Write ("          The algorithn chosen may be a MAC algorithm or an \n{0}", _Indent);
			//           encrypt-with-authentication (EWA) algorithm. If an EWA is specified,  
			_Output.Write ("          encrypt-with-authentication (EWA) algorithm. If an EWA is specified, \n{0}", _Indent);
			//           the encrypted data is discarded and only the authentication  
			_Output.Write ("          the encrypted data is discarded and only the authentication \n{0}", _Indent);
			//           value is used in its place. 
			_Output.Write ("          value is used in its place.\n{0}", _Indent);
			//         </t> 
			_Output.Write ("        </t>\n{0}", _Indent);
			//         <t> 
			_Output.Write ("        <t>\n{0}", _Indent);
			//           Let A(d,k) be the authentication value obtained by applying the  
			_Output.Write ("          Let A(d,k) be the authentication value obtained by applying the \n{0}", _Indent);
			//           authentication algorithm with key k to data d. 
			_Output.Write ("          authentication algorithm with key k to data d.\n{0}", _Indent);
			//         </t> 
			_Output.Write ("        </t>\n{0}", _Indent);
			//         <t> 
			_Output.Write ("        <t>\n{0}", _Indent);
			//           To create the Server Response value, the UTF8 encoding of the 
			_Output.Write ("          To create the Server Response value, the UTF8 encoding of the\n{0}", _Indent);
			//           PIN value 'P' is  
			_Output.Write ("          PIN value 'P' is \n{0}", _Indent);
			//           first converted into a symmetric key KPC by using the Client 
			_Output.Write ("          first converted into a symmetric key KPC by using the Client\n{0}", _Indent);
			//           challenge value as the key 
			_Output.Write ("          challenge value as the key\n{0}", _Indent);
			//           truncating if necessary and then applied to the payload of the 
			_Output.Write ("          truncating if necessary and then applied to the payload of the\n{0}", _Indent);
			//           OpenRequest message: 
			_Output.Write ("          OpenRequest message:\n{0}", _Indent);
			//         </t> 
			_Output.Write ("        </t>\n{0}", _Indent);
			//         <t> 
			_Output.Write ("        <t>\n{0}", _Indent);
			//           KPC = A (PIN, CC) 
			_Output.Write ("          KPC = A (PIN, CC)\n{0}", _Indent);
			//           SR = A (Secret + SC + OpenRequest, KPC) 
			_Output.Write ("          SR = A (Secret + SC + OpenRequest, KPC)\n{0}", _Indent);
			//         </t> 
			_Output.Write ("        </t>\n{0}", _Indent);
			//         <t> 
			_Output.Write ("        <t>\n{0}", _Indent);
			//           In the Web Service Binding, the Payload of the message is the  
			_Output.Write ("          In the Web Service Binding, the Payload of the message is the \n{0}", _Indent);
			//           HTTP Body as presented on the wire. The Secret and Server  
			_Output.Write ("          HTTP Body as presented on the wire. The Secret and Server \n{0}", _Indent);
			//           Challenge are presented in their 
			_Output.Write ("          Challenge are presented in their\n{0}", _Indent);
			//           binary format and the '+' operator stands for simple concatenation 
			_Output.Write ("          binary format and the '+' operator stands for simple concatenation\n{0}", _Indent);
			//           of the binary sequences. 
			_Output.Write ("          of the binary sequences.\n{0}", _Indent);
			//         </t> 
			_Output.Write ("        </t>\n{0}", _Indent);
			//         <t> 
			_Output.Write ("        <t>\n{0}", _Indent);
			//           This protocol construction ensures that the party constructing 
			_Output.Write ("          This protocol construction ensures that the party constructing\n{0}", _Indent);
			//           SR: 
			_Output.Write ("          SR:\n{0}", _Indent);
			//         </t> 
			_Output.Write ("        </t>\n{0}", _Indent);
			//         <t> 
			_Output.Write ("        <t>\n{0}", _Indent);
			//           <list> 
			_Output.Write ("          <list>\n{0}", _Indent);
			//             <t> 
			_Output.Write ("            <t>\n{0}", _Indent);
			//               Knows the PIN code value (through the construction of KPC). 
			_Output.Write ("              Knows the PIN code value (through the construction of KPC).\n{0}", _Indent);
			//             </t> 
			_Output.Write ("            </t>\n{0}", _Indent);
			//             <t> 
			_Output.Write ("            <t>\n{0}", _Indent);
			//               Is responding to the Open Request Message (SR depends on  
			_Output.Write ("              Is responding to the Open Request Message (SR depends on \n{0}", _Indent);
			//               OpenRequest). 
			_Output.Write ("              OpenRequest).\n{0}", _Indent);
			//             </t> 
			_Output.Write ("            </t>\n{0}", _Indent);
			//             <t> 
			_Output.Write ("            <t>\n{0}", _Indent);
			//               Has knowlege of the secret key which MUST be used to  
			_Output.Write ("              Has knowlege of the secret key which MUST be used to \n{0}", _Indent);
			//               authenticate the following TicketRequest/TicketResponse 
			_Output.Write ("              authenticate the following TicketRequest/TicketResponse\n{0}", _Indent);
			//               interaction that will establish the actual connection. 
			_Output.Write ("              interaction that will establish the actual connection.\n{0}", _Indent);
			//             </t> 
			_Output.Write ("            </t>\n{0}", _Indent);
			//             <t> 
			_Output.Write ("            <t>\n{0}", _Indent);
			//               Does not provide an oracle the PIN value. That is, the protocol  
			_Output.Write ("              Does not provide an oracle the PIN value. That is, the protocol \n{0}", _Indent);
			//               does not provide a service that reveals the (since the value SR 
			_Output.Write ("              does not provide a service that reveals the (since the value SR\n{0}", _Indent);
			//               includes the value SC which is a random nonce generated 
			_Output.Write ("              includes the value SC which is a random nonce generated\n{0}", _Indent);
			//               by the server and cannot be predicted by the client). 
			_Output.Write ("              by the server and cannot be predicted by the client).\n{0}", _Indent);
			//             </t> 
			_Output.Write ("            </t>\n{0}", _Indent);
			//           </list> 
			_Output.Write ("          </list>\n{0}", _Indent);
			//         </t> 
			_Output.Write ("        </t>\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			//         <t> 
			_Output.Write ("        <t>\n{0}", _Indent);
			//           To create the Client Response value, secret key is applied  
			_Output.Write ("          To create the Client Response value, secret key is applied \n{0}", _Indent);
			//           to the PIN value and server Challenge: 
			_Output.Write ("          to the PIN value and server Challenge:\n{0}", _Indent);
			//         </t> 
			_Output.Write ("        </t>\n{0}", _Indent);
			//         <t> 
			_Output.Write ("        <t>\n{0}", _Indent);
			//           CR = A (PIN + SC + OpenRequest, Secret) 
			_Output.Write ("          CR = A (PIN + SC + OpenRequest, Secret)\n{0}", _Indent);
			//         </t> 
			_Output.Write ("        </t>\n{0}", _Indent);
			//                 <t> 
			_Output.Write ("                <t>\n{0}", _Indent);
			//           Note that the server can calculate the value of the Client Response 
			_Output.Write ("          Note that the server can calculate the value of the Client Response\n{0}", _Indent);
			//           token at the time that it generates the Server Challenge. 
			_Output.Write ("          token at the time that it generates the Server Challenge.\n{0}", _Indent);
			//           This minimizes the amount of state that needs to be carried from  
			_Output.Write ("          This minimizes the amount of state that needs to be carried from \n{0}", _Indent);
			//           one Request to the next in the Ticket value when using the stateless 
			_Output.Write ("          one request to the next in the Ticket value when using the stateless\n{0}", _Indent);
			//           server implementation described in section <xref target="stateless"/> 
			_Output.Write ("          server implementation described in section <xref target=\"stateless\"/>\n{0}", _Indent);
			//         </t> 
			_Output.Write ("        </t>\n{0}", _Indent);
			//         <t> 
			_Output.Write ("        <t>\n{0}", _Indent);
			//           This protocol construction ensures that the constructor of CR 
			_Output.Write ("          This protocol construction ensures that the constructor of CR\n{0}", _Indent);
			//         </t> 
			_Output.Write ("        </t>\n{0}", _Indent);
			//         <t> 
			_Output.Write ("        <t>\n{0}", _Indent);
			//           <list> 
			_Output.Write ("          <list>\n{0}", _Indent);
			//             <t> 
			_Output.Write ("            <t>\n{0}", _Indent);
			//               Knows the PIN value. 
			_Output.Write ("              Knows the PIN value.\n{0}", _Indent);
			//             </t> 
			_Output.Write ("            </t>\n{0}", _Indent);
			//             <t> 
			_Output.Write ("            <t>\n{0}", _Indent);
			//               Is respoding to the OpenResponse generated by the server. 
			_Output.Write ("              Is respoding to the OpenResponse generated by the server.\n{0}", _Indent);
			//             </t> 
			_Output.Write ("            </t>\n{0}", _Indent);
			//           </list> 
			_Output.Write ("          </list>\n{0}", _Indent);
			//         </t> 
			_Output.Write ("        </t>\n{0}", _Indent);
			//         <t> 
			_Output.Write ("        <t>\n{0}", _Indent);
			//           Note that while disclosure of an oracle for the PIN value is a  
			_Output.Write ("          Note that while disclosure of an oracle for the PIN value is a \n{0}", _Indent);
			//           concern in the  
			_Output.Write ("          concern in the \n{0}", _Indent);
			//           construction of CR, this is not the case in the construction of  
			_Output.Write ("          construction of CR, this is not the case in the construction of \n{0}", _Indent);
			//           SR since the client has already demonstrated knowledge of the  
			_Output.Write ("          SR since the client has already demonstrated knowledge of the \n{0}", _Indent);
			//           PIN value. 
			_Output.Write ("          PIN value.\n{0}", _Indent);
			//         </t> 
			_Output.Write ("        </t>\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			//         </section> 
			_Output.Write ("        </section>\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			//         <section title="Example: Latin PIN Code"> 
			_Output.Write ("        <section title=\"Example: Latin PIN Code\">\n{0}", _Indent);
			//           <t> 
			_Output.Write ("          <t>\n{0}", _Indent);
			//             The Connection Request example of section  
			_Output.Write ("            The Connection Request example of section \n{0}", _Indent);
			//             <xref target="ConnectionRequestExample"/> demonstrates the use 
			_Output.Write ("            <xref target=\"ConnectionRequestExample\"/> demonstrates the use\n{0}", _Indent);
			//             of an alphanumeric PIN code using the Latin alphabet. 
			_Output.Write ("            of an alphanumeric PIN code using the Latin alphabet.\n{0}", _Indent);
			//           </t> 
			_Output.Write ("          </t>\n{0}", _Indent);
			//           <t> 
			_Output.Write ("          <t>\n{0}", _Indent);
			//             The PIN code is [] and the authentication algorithm is []. 
			_Output.Write ("            The PIN code is [] and the authentication algorithm is [].\n{0}", _Indent);
			//             The value KP is thus: 
			_Output.Write ("            The value KP is thus:\n{0}", _Indent);
			//           </t> 
			_Output.Write ("          </t>\n{0}", _Indent);
			//           <t> 
			_Output.Write ("          <t>\n{0}", _Indent);
			//             [TBS] 
			_Output.Write ("            [TBS]\n{0}", _Indent);
			//           </t> 
			_Output.Write ("          </t>\n{0}", _Indent);
			//           <t> 
			_Output.Write ("          <t>\n{0}", _Indent);
			//             The data over which the hash value is calulated is 
			_Output.Write ("            The data over which the hash value is calulated is\n{0}", _Indent);
			//             Secret + SC + OpenRequest: 
			_Output.Write ("            Secret + SC + OpenRequest:\n{0}", _Indent);
			//           </t> 
			_Output.Write ("          </t>\n{0}", _Indent);
			//           <t> 
			_Output.Write ("          <t>\n{0}", _Indent);
			//             [TBS] 
			_Output.Write ("            [TBS]\n{0}", _Indent);
			//           </t> 
			_Output.Write ("          </t>\n{0}", _Indent);
			//           <t> 
			_Output.Write ("          <t>\n{0}", _Indent);
			//             Applying the derrived key to the data produces the server  
			_Output.Write ("            Applying the derrived key to the data produces the server \n{0}", _Indent);
			//             Response: 
			_Output.Write ("            response:\n{0}", _Indent);
			//           </t> 
			_Output.Write ("          </t>\n{0}", _Indent);
			//           <t> 
			_Output.Write ("          <t>\n{0}", _Indent);
			//             The data for the client Response is PIN + SC: 
			_Output.Write ("            The data for the client response is PIN + SC:\n{0}", _Indent);
			//           </t> 
			_Output.Write ("          </t>\n{0}", _Indent);
			//           <t> 
			_Output.Write ("          <t>\n{0}", _Indent);
			//             [TBS] 
			_Output.Write ("            [TBS]\n{0}", _Indent);
			//           </t> 
			_Output.Write ("          </t>\n{0}", _Indent);
			//           <t> 
			_Output.Write ("          <t>\n{0}", _Indent);
			//             Applying the secret key to the data produces the client 
			_Output.Write ("            Applying the secret key to the data produces the client\n{0}", _Indent);
			//             Response: 
			_Output.Write ("            response:\n{0}", _Indent);
			//           </t> 
			_Output.Write ("          </t>\n{0}", _Indent);
			//           <t> 
			_Output.Write ("          <t>\n{0}", _Indent);
			//             [TBS] 
			_Output.Write ("            [TBS]\n{0}", _Indent);
			//           </t> 
			_Output.Write ("          </t>\n{0}", _Indent);
			//         </section> 
			_Output.Write ("        </section>\n{0}", _Indent);
			//         <section title="Example: Cyrillic PIN Code"> 
			_Output.Write ("        <section title=\"Example: Cyrillic PIN Code\">\n{0}", _Indent);
			//           <t> 
			_Output.Write ("          <t>\n{0}", _Indent);
			//             If the PIN code in the earlier example was [] the 
			_Output.Write ("            If the PIN code in the earlier example was [] the\n{0}", _Indent);
			//             value KP would be: 
			_Output.Write ("            value KP would be:\n{0}", _Indent);
			//           </t> 
			_Output.Write ("          </t>\n{0}", _Indent);
			//           <t> 
			_Output.Write ("          <t>\n{0}", _Indent);
			//             [TBS] 
			_Output.Write ("            [TBS]\n{0}", _Indent);
			//           </t>           
			_Output.Write ("          </t>          \n{0}", _Indent);
			//           <t> 
			_Output.Write ("          <t>\n{0}", _Indent);
			//             The Server Response would be: 
			_Output.Write ("            The Server Response would be:\n{0}", _Indent);
			//           </t> 
			_Output.Write ("          </t>\n{0}", _Indent);
			//           <t> 
			_Output.Write ("          <t>\n{0}", _Indent);
			//             [TBS] 
			_Output.Write ("            [TBS]\n{0}", _Indent);
			//           </t> 
			_Output.Write ("          </t>\n{0}", _Indent);
			//           <t> 
			_Output.Write ("          <t>\n{0}", _Indent);
			//             The rest of the protocol would then continue as before. 
			_Output.Write ("            The rest of the protocol would then continue as before.\n{0}", _Indent);
			//           </t> 
			_Output.Write ("          </t>\n{0}", _Indent);
			//         </section> 
			_Output.Write ("        </section>\n{0}", _Indent);
			//       <section title="Stateless server" anchor="stateless"> 
			_Output.Write ("      <section title=\"Stateless server\" anchor=\"stateless\">\n{0}", _Indent);
			//         <t> 
			_Output.Write ("        <t>\n{0}", _Indent);
			//           The protocol is designed to permit but not require a stateless 
			_Output.Write ("          The protocol is designed to permit but not require a stateless\n{0}", _Indent);
			//           implementation by the server using the Ticket value generated by the  
			_Output.Write ("          implementation by the server using the Ticket value generated by the \n{0}", _Indent);
			//           server to pass state from the first server transaction to the 
			_Output.Write ("          server to pass state from the first server transaction to the\n{0}", _Indent);
			//           second. 
			_Output.Write ("          second.\n{0}", _Indent);
			//         </t> 
			_Output.Write ("        </t>\n{0}", _Indent);
			//         <t> 
			_Output.Write ("        <t>\n{0}", _Indent);
			//           In the example shown in <xref target="ConnectionRequestExample"/>,  
			_Output.Write ("          In the example shown in <xref target=\"ConnectionRequestExample\"/>, \n{0}", _Indent);
			//         the server generates a 'temporary ticket' containing the  
			_Output.Write ("        the server generates a 'temporary ticket' containing the \n{0}", _Indent);
			//         following information: 
			_Output.Write ("        following information:\n{0}", _Indent);
			//         </t> 
			_Output.Write ("        </t>\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			//         <t> 
			_Output.Write ("        <t>\n{0}", _Indent);
			//           If a server uses the Ticket to transmit state in this way it 
			_Output.Write ("          If a server uses the Ticket to transmit state in this way it\n{0}", _Indent);
			//           MUST protect the confidentiality of the ticket using a strong 
			_Output.Write ("          MUST protect the confidentiality of the ticket using a strong\n{0}", _Indent);
			//           means of encryption and authentication. 
			_Output.Write ("          means of encryption and authentication.\n{0}", _Indent);
			//          </t> 
			_Output.Write ("         </t>\n{0}", _Indent);
			//       </section> 
			_Output.Write ("      </section>\n{0}", _Indent);
			//       <section title ="Established Key" anchor="PublicKeyAuth"> 
			_Output.Write ("      <section title =\"Established Key\" anchor=\"PublicKeyAuth\">\n{0}", _Indent);
			//         <t> 
			_Output.Write ("        <t>\n{0}", _Indent);
			//           The Established Key mechanism is used when the parties have 
			_Output.Write ("          The Established Key mechanism is used when the parties have\n{0}", _Indent);
			//           an existing shared key or public key credential. 
			_Output.Write ("          an existing shared key or public key credential.\n{0}", _Indent);
			//         </t> 
			_Output.Write ("        </t>\n{0}", _Indent);
			//         <t> 
			_Output.Write ("        <t>\n{0}", _Indent);
			//           The  
			_Output.Write ("          The \n{0}", _Indent);
			//           [Open Request open Response are authenticated under the 
			_Output.Write ("          [Open request open response are authenticated under the\n{0}", _Indent);
			//           respective keys] 
			_Output.Write ("          respective keys]\n{0}", _Indent);
			//         </t> 
			_Output.Write ("        </t>\n{0}", _Indent);
			//         <t> 
			_Output.Write ("        <t>\n{0}", _Indent);
			//           SR=CC, CR=SC 
			_Output.Write ("          SR=CC, CR=SC\n{0}", _Indent);
			//         </t> 
			_Output.Write ("        </t>\n{0}", _Indent);
			//       </section> 
			_Output.Write ("      </section>\n{0}", _Indent);
			//       <section title ="Out of Band Confirmation" anchor="OOBConfirmation"> 
			_Output.Write ("      <section title =\"Out of Band Confirmation\" anchor=\"OOBConfirmation\">\n{0}", _Indent);
			//         <t> 
			_Output.Write ("        <t>\n{0}", _Indent);
			//           The Out Of Band Confirmation mechanism is a three step  
			_Output.Write ("          The Out Of Band Confirmation mechanism is a three step \n{0}", _Indent);
			//           process in which: 
			_Output.Write ("          process in which:\n{0}", _Indent);
			//         </t> 
			_Output.Write ("        </t>\n{0}", _Indent);
			//         <t> 
			_Output.Write ("        <t>\n{0}", _Indent);
			//           <list> 
			_Output.Write ("          <list>\n{0}", _Indent);
			//             <t> 
			_Output.Write ("            <t>\n{0}", _Indent);
			//               The client makes an OpenRequest message to the service 
			_Output.Write ("              The client makes an OpenRequest message to the service\n{0}", _Indent);
			//               and obtains an OpenResponse message. 
			_Output.Write ("              and obtains an OpenResponse message.\n{0}", _Indent);
			//             </t> 
			_Output.Write ("            </t>\n{0}", _Indent);
			//             <t> 
			_Output.Write ("            <t>\n{0}", _Indent);
			//               The service is informed that the service has been 
			_Output.Write ("              The service is informed that the service has been\n{0}", _Indent);
			//               authorized through an out of band process. 
			_Output.Write ("              authorized through an out of band process.\n{0}", _Indent);
			//             </t> 
			_Output.Write ("            </t>\n{0}", _Indent);
			//             <t> 
			_Output.Write ("            <t>\n{0}", _Indent);
			//               The client makes a TicketRequest to the service 
			_Output.Write ("              The client makes a TicketRequest to the service\n{0}", _Indent);
			//               and obtains a TicketResponse message to complete  
			_Output.Write ("              and obtains a TicketResponse message to complete \n{0}", _Indent);
			//               the exchange. 
			_Output.Write ("              the exchange.\n{0}", _Indent);
			//             </t> 
			_Output.Write ("            </t>\n{0}", _Indent);
			//           </list> 
			_Output.Write ("          </list>\n{0}", _Indent);
			//         </t> 
			_Output.Write ("        </t>\n{0}", _Indent);
			//         <t> 
			_Output.Write ("        <t>\n{0}", _Indent);
			//           Since no prior authentication key has been established, the  
			_Output.Write ("          Since no prior authentication key has been established, the \n{0}", _Indent);
			//           OpenRequest and OpenResponse messages are sent without  
			_Output.Write ("          OpenRequest and OpenResponse messages are sent without \n{0}", _Indent);
			//           authentication. 
			_Output.Write ("          authentication.\n{0}", _Indent);
			//         </t> 
			_Output.Write ("        </t>\n{0}", _Indent);
			//         <t> 
			_Output.Write ("        <t>\n{0}", _Indent);
			//           The principal concern in the Out Of Band Confirmation  
			_Output.Write ("          The principal concern in the Out Of Band Confirmation \n{0}", _Indent);
			//           mechanism is ensuring that the party authorizing the 
			_Output.Write ("          mechanism is ensuring that the party authorizing the\n{0}", _Indent);
			//           Request is able to identify which party originated 
			_Output.Write ("          request is able to identify which party originated\n{0}", _Indent);
			//           the Request they are attempting to identify. 
			_Output.Write ("          the request they are attempting to identify.\n{0}", _Indent);
			//         </t> 
			_Output.Write ("        </t>\n{0}", _Indent);
			//         <t> 
			_Output.Write ("        <t>\n{0}", _Indent);
			//           If a device has the ability to display an image it 
			_Output.Write ("          If a device has the ability to display an image it\n{0}", _Indent);
			//           MAY set the HasDisplay=true in the OpenRequest message. 
			_Output.Write ("          MAY set the HasDisplay=true in the OpenRequest message.\n{0}", _Indent);
			//           If the broker recieves an OpenRequest with the HasDisplay 
			_Output.Write ("          If the broker recieves an OpenRequest with the HasDisplay\n{0}", _Indent);
			//           value set to true, the OpenResponse MAY contain one or more 
			_Output.Write ("          value set to true, the OpenResponse MAY contain one or more\n{0}", _Indent);
			//           VerificationImage entries specifying image data that is  
			_Output.Write ("          VerificationImage entries specifying image data that is \n{0}", _Indent);
			//           to be displayed to the user by both the client and the 
			_Output.Write ("          to be displayed to the user by both the client and the\n{0}", _Indent);
			//           confirmation interface. 
			_Output.Write ("          confirmation interface.\n{0}", _Indent);
			//         </t> 
			_Output.Write ("        </t>\n{0}", _Indent);
			//         <t> 
			_Output.Write ("        <t>\n{0}", _Indent);
			//           Before confirming the Request, the user SHOULD verify  
			_Output.Write ("          Before confirming the request, the user SHOULD verify \n{0}", _Indent);
			//           that the two images are the same and reject the Request 
			_Output.Write ("          that the two images are the same and reject the request\n{0}", _Indent);
			//           in the case that they are not. 
			_Output.Write ("          in the case that they are not.\n{0}", _Indent);
			//         </t> 
			_Output.Write ("        </t>\n{0}", _Indent);
			//         <t> 
			_Output.Write ("        <t>\n{0}", _Indent);
			//           Many devices do not have a display capability, in particular 
			_Output.Write ("          Many devices do not have a display capability, in particular\n{0}", _Indent);
			//           an embedded device such as a network switch or a thermostat. 
			_Output.Write ("          an embedded device such as a network switch or a thermostat.\n{0}", _Indent);
			//           In this case the device MAY be identified by means of the 
			_Output.Write ("          In this case the device MAY be identified by means of the\n{0}", _Indent);
			//           information provided in  
			_Output.Write ("          information provided in \n{0}", _Indent);
			//           DeviceID, DeviceURI, DeviceImage and DeviceName. 
			_Output.Write ("          DeviceID, DeviceURI, DeviceImage and DeviceName.\n{0}", _Indent);
			//         </t> 
			_Output.Write ("        </t>\n{0}", _Indent);
			//       </section> 
			_Output.Write ("      </section>\n{0}", _Indent);
			//     </section> 
			_Output.Write ("    </section>\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// #end method 
			}
		//  
		//  
		// #method ExampleWSMessage BoundMessage Message 
		

		//
		// ExampleWSMessage
		//
		public void ExampleWSMessage (BoundMessage Message) {
			//           <figure> 
			_Output.Write ("          <figure>\n{0}", _Indent);
			//             <artwork> 
			_Output.Write ("            <artwork>\n{0}", _Indent);
			// <![CDATA[#{Message.HTTPBinding}]]> 
			_Output.Write ("<![CDATA[{1}]]>\n{0}", _Indent, Message.HTTPBinding);
			//             </artwork> 
			_Output.Write ("            </artwork>\n{0}", _Indent);
			//           </figure> 
			_Output.Write ("          </figure>\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// #end method 
			}
		//  
		//  
		//  
		// #end pclass 
		}
	}
