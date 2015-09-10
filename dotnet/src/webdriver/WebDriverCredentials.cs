// <copyright file="WebDriverCredentials.cs" company="WebDriver Committers">
// Licensed to the Software Freedom Conservancy (SFC) under one
// or more contributor license agreements. See the NOTICE file
// distributed with this work for additional information
// regarding copyright ownership. The SFC licenses this file
// to you under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Newtonsoft.Json;

namespace OpenQA.Selenium
{
    /// <summary>
    /// Describes the type of authentication.
    /// </summary>
    public enum AuthType
    {
        /// <summary>
        ///  Normal HTTP authentication
        /// </summary>
        Normal,

        /// <summary>
        /// NTLM ("Windows") authentication
        /// </summary>
        NTLM,

        /// <summary>
        /// No explicit authentication
        /// </summary>
        Unspecified
    }
    
    /// <summary>
    /// Describes authentication settings to be used with a driver instance.
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class WebDriverCredentials
    {
        private AuthType authType = AuthType.Unspecified;
        private String username;
        private String password;
        private String host;
        private int port = -1;
        private String realm;
        private String ntlmWorkstation;
        private String ntlmDomain;

        /// <summary>
        /// Initializes a new instance of the <see cref="WebDriverCredentials"/> class.
        /// </summary>
        public WebDriverCredentials()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WebDriverCredentials"/> class with the given authentication settings.
        /// </summary>
        /// <param name="settings">A dictionary of settings to use for authentication.</param>
        public WebDriverCredentials(Dictionary<string, object> settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings", "settings dictionary cannot be null");
            }

            if (settings.ContainsKey("authType"))
            {
                AuthType rawType = (AuthType)Enum.Parse(typeof(AuthType), settings["authType"].ToString(), true);
                this.Type = rawType;
            }

            if (settings.ContainsKey("username"))
            {
                this.Username = settings["username"].ToString();
            }
            
            if (settings.ContainsKey("password"))
            {
                this.Password = settings["password"].ToString();
            }
            
            if (settings.ContainsKey("host"))
            {
                this.Host = settings["host"].ToString();
            }
            
            if (settings.ContainsKey("port"))
            {
                if (settings["port"] is int) {
                    this.Port = (int)settings["port"];
                }
                else if(!int.TryParse(settings["port"].ToString(), out this.port)) {
                    this.port = -1;
                }
            }
            
            if (settings.ContainsKey("realm"))
            {
                this.Realm = settings["realm"].ToString();
            }

            if (settings.ContainsKey("ntlmWorkstation"))
            {
                this.NtlmWorkstation = settings["ntlmWorkstation"].ToString();
            }

            if (settings.ContainsKey("ntlmDomain"))
            {
                this.NtlmDomain = settings["ntlmDomain"].ToString();
            }
        }

        /// <summary>
        /// Gets or sets the type of authentication.
        /// </summary>
        [JsonIgnore]
        public AuthType Type
        {
            get 
            {
                return this.authType; 
            }

            set
            {
                this.authType = value;
            }
        }

        /// <summary>
        /// Gets the type of authentication as a string for JSON serialization.
        /// </summary>
        [JsonProperty("authType")]
        public string SerializableProxyKind {
            get {
                return this.authType.ToString().ToUpperInvariant();
            }
        }

        /// <summary>
        /// Gets or sets the value of the username for authentication.
        /// </summary>
        [JsonProperty("username", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string Username {
            get {
                return this.username;
            }

            set {
                this.username = value;
            }
        }

        /// <summary>
        /// Gets or sets the value of the password for authentication.
        /// </summary>
        [JsonProperty("password", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string Password {
            get {
                return this.password;
            }

            set {
                this.password = value;
            }
        }

        /// <summary>
        /// Gets or sets the host to which the credentials apply.
        /// </summary>
        [JsonProperty("host", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string Host {
            get {
                return this.host;
            }

            set {
                this.host = value;
            }
        }

        /// <summary>
        /// Gets or sets the port to which the credentials apply.
        /// </summary>
        [JsonProperty("port", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public int Port {
            get {
                return this.port;
            }

            set {
                this.port = value;
            }
        }

        /// <summary>
        /// Gets or sets the realm to which the credentials apply.
        /// </summary>
        [JsonProperty("realm", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string Realm {
            get {
                return this.realm;
            }

            set {
                this.realm = value;
            }
        }

        /// <summary>
        /// Gets or sets the workstation for NTLM authentication.
        /// </summary>
        [JsonProperty("ntlmWorkstation", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string NtlmWorkstation {
            get {
                return this.ntlmWorkstation;
            }

            set {
                this.ntlmWorkstation = value;
            }
        }

        /// <summary>
        /// Gets or sets the domain for NTLM authentication.
        /// </summary>
        [JsonProperty("ntlmDomain", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string NtlmDomain {
            get {
                return this.ntlmDomain;
            }

            set {
                this.ntlmDomain = value;
            }
        }
    }
}
