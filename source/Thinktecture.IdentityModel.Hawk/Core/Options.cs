﻿using System;
using Thinktecture.IdentityModel.Hawk.Core.Helpers;
using Thinktecture.IdentityModel.Hawk.Core.MessageContracts;

namespace Thinktecture.IdentityModel.Hawk.Core
{
    /// <summary>
    /// Hawk authentication options.
    /// </summary>
    public class Options
    {
        public Options()
        {
            this.ClockSkewSeconds = 60;
            this.EnableServerAuthorization = true;
        }

        /// <summary>
        /// Local time offset in milliseconds.
        /// </summary>
        public int LocalTimeOffsetMillis { get; set; }

        /// <summary>
        /// Skew allowed between the client and the server clocks in seconds. Default is 60 seconds.
        /// </summary>
        public int ClockSkewSeconds { get; set; }

        /// <summary>
        /// If true, the Server-Authorization header is sent in the response. Default is true.
        /// </summary>
        public bool EnableServerAuthorization { get; set; }

        /// <summary>
        /// Func delegate that returns Credential for the given user identifier.
        /// </summary>
        public Func<string, Credential> CredentialsCallback { get; set; }

        /// <summary>
        /// Func delegate that returns the normalized form of the response message to be used
        /// as application specific data ('ext' field) in the Server-Authorization response header.
        /// </summary>
        public Func<IResponseMessage, string> NormalizationCallback { get; set; }

        /// <summary>
        /// Func delegate that returns true if the specified normalized form of the request
        /// message matches the normalized form of the specified request message.
        /// </summary>
        public Func<IRequestMessage, string, bool> VerificationCallback { get; set; }
        
        /// <summary>
        /// Func delegate that returns true, if the response body must be hashed and included
        /// in the MAC ('mac' field) sent in the Server-Authorization response header.
        /// </summary>
        public Func<IRequestMessage, bool> ResponsePayloadHashabilityCallback { get; set; }

        /// <summary>
        /// The request part used to determine the host name for creating normalized request.
        /// If not specified, X-Forwarded-Host header is tried first, then the Host request header,
        /// and finally request URI.
        /// </summary>
        public HostNameSource? HostNameSource { get; set; }

		/// <summary>
		/// The request part used to determine the port for creating normalized request.
		/// If not specified, X-Forwarded-Port header is tried first, then port based on X-Forwarded-Proto header,
		/// then port from X-Forwarded-Host header, then port from Host header, and finally request URI port.
		/// </summary>
		public PortSource? PortSource { get; set; }
    }
}
