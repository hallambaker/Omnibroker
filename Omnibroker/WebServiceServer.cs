﻿using System;
using System.Net;
using System.IO;
using System.Text;
using System.Collections.Generic;
using TestProtoGen;

//
//  In order to use the WebServiceServer class the account must have the appropriate 
//  privileges. This can be done by runing as administrator, or by adding the
//  appropriate privilleges to the account using the windows netsh command which
//  isn't mentioned anywhere in the .NET documentation as that would make it much
//  to easy
//
//  From a command line window with admin privs enabled, type:
//
//  netsh http add urlacl http://*:8080/ user=You


namespace Omnibroker {

    struct ServiceInstance {
        public string Prefix;
        public Server Server;
        // TBS dispatch delegate
        }


    public class WebServiceServer {
        static string HTTPIntegrityHeader = "Integrity";
        
        // Specifies the maximum number of outstanding requests
        public int MaxRequests = 1;
        List<ServiceInstance> Instances = new List<ServiceInstance>();

        ServiceInstance GetInstance(string URI) {
            return Instances [0];
            }


        // Set false to shut down service in orderly fashion completing
        // outstanding requests.
        public bool Active = true;

        // Call RegisterService to register for each port, etc.
        public void RegisterService(string domain, int port, string Location,
                    Server Server ) {
            if (Location == null) {
                Location = "";
                }

            ServiceInstance Instance = new ServiceInstance();
            Instance.Prefix = "http://" + domain + ":" + port.ToString() + "/" + Location;
            Instance.Server = Server;
            Instances.Add(Instance);
            }

        public void Listener() {
            if (!HttpListener.IsSupported) {
                throw new Exception("Platform not supported");
                }
            HttpListener Listener = new HttpListener();

            foreach (ServiceInstance Instance in Instances) {
                Listener.Prefixes.Add(Instance.Prefix);
                }
            Listener.Start();
            Console.WriteLine("Listening...");

            while (Active) {
                HandleContext(Listener.GetContext());
                }

            Listener.Stop();
            }

        public void HandleContext(HttpListenerContext Context) {
            HttpListenerRequest Request = Context.Request;

            Console.WriteLine("Request: {0} {1}  Length {2}",
                Request.HttpMethod, Request.RawUrl, Request.ContentLength64);

            string Content;

            string[] IntegrityHeaders = Request.Headers.GetValues (HTTPIntegrityHeader);
            if (IntegrityHeaders != null) {
                foreach (string IntegrityHeader in IntegrityHeaders) {
                    Console.WriteLine("Integrity: {0}", IntegrityHeader);
                    }
                }
            else {
                Console.WriteLine("No Integrity header");
                }

            // Get the content 
            Stream body = Request.InputStream;
            Encoding encoding = Request.ContentEncoding;
            StreamReader Reader = new StreamReader(body, encoding);
            Content = Reader.ReadToEnd();
            Console.WriteLine(Content);
            Console.WriteLine("-----------");

            BoundRequest BoundRequest = new BoundRequest (Content);

            // Will need to fix this at some point defaults to just the first
            // service in the list
            ServiceInstance Instance = GetInstance (Request.RawUrl);
            Server ThisServer = Instance.Server;

            BoundResponse BoundResponse = ThisServer.Request (BoundRequest);

            HttpListenerResponse Response = Context.Response;
            Response.StatusCode = BoundResponse.Status;
            Response.StatusDescription = BoundResponse.StatusDescription;

            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(BoundResponse.Payload);

            Response.ContentLength64 = buffer.Length;

            Stream output = Response.OutputStream;
            output.Write(buffer, 0, buffer.Length);
            // You must close the output stream.
            output.Close();
            }

        }
    }
