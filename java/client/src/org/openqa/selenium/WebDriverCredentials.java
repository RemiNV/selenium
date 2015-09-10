// Licensed to the Software Freedom Conservancy (SFC) under one
// or more contributor license agreements.  See the NOTICE file
// distributed with this work for additional information
// regarding copyright ownership.  The SFC licenses this file
// to you under the Apache License, Version 2.0 (the
// "License"); you may not use this file except in compliance
// with the License.  You may obtain a copy of the License at
//
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing,
// software distributed under the License is distributed on an
// "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, either express or implied.  See the License for the
// specific language governing permissions and limitations
// under the License.

package org.openqa.selenium;

import java.util.Map;

/**
 * Configuration parameters for using credentials in WebDriver. Drivers which support these
 * settings will use the specified credentials by default.
 */
public class WebDriverCredentials {

  public enum AuthType {

	  /** Normal HTTP authentication */
	  NORMAL,
	  /** NTLM ("Windows") authentication */
	  NTLM,
	  /** No explicit authentication */
	  UNSPECIFIED
  }

  private AuthType authType = AuthType.UNSPECIFIED;
  private String username;
  private String password;
  private String host;
  private int port = -1;
  private String realm;
  private String ntlmWorkstation;
  private String ntlmDomain;

  public WebDriverCredentials() {
    // Empty default constructor
  }

  public WebDriverCredentials(Map<String, ?> raw) {
    if (raw.containsKey("authType") && raw.get("authType") != null) {
      setAuthType(AuthType.valueOf(((String) raw.get("authType")).toUpperCase()));
    }
    if (raw.containsKey("username") && raw.get("username") != null) {
      setUsername((String) raw.get("username"));
    }
    if (raw.containsKey("password") && raw.get("password") != null) {
      setPassword((String) raw.get("password"));
    }
    if (raw.containsKey("host") && raw.get("host") != null) {
      setHost((String) raw.get("host"));
    }
    if (raw.containsKey("port") && raw.get("port") != null) {
      setPort(((Number) raw.get("port")).intValue());
    }
    if (raw.containsKey("realm") && raw.get("realm") != null) {
      setRealm((String) raw.get("realm"));
    }
    if (raw.containsKey("ntlmWorkstation") && raw.get("ntlmWorkstation") != null) {
      setNtlmWorkstation((String) raw.get("ntlmWorkstation"));
    }
    if (raw.containsKey("ntlmDomain") && raw.get("ntlmDomain") != null) {
      setNtlmDomain((String) raw.get("ntlmDomain"));
    }
  }
  
  /**
   * Gets the {@link AuthType}. 
   * It defaults to {@link AuthType#UNSPECIFIED}.
   *
   * @return the authentication type employed
   */
  public AuthType getAuthType() {
	  return this.authType;
  }
  
  /**
   * Explicitly sets the authentication type
   * 
   * @return reference to self
   */
  public WebDriverCredentials setAuthType(AuthType authType) {
	  this.authType = authType;
	  return this;
  }
  
  /**
   * Gets the username used for authentication.
   * 
   * @return the username if present, or null if not set
   */
  public String getUsername() {
	  return username;
  }
  
  /**
   * Specify which username to use for authentication.
   * 
   * @param username
   * @return reference to self
   */
  public WebDriverCredentials setUsername(String username) {
	  this.username = username;
	  return this;
  }
  
  /**
   * Gets the authentication password.
   * 
   * @return the authentication password if present, or null if not set
   */
  public String getPassword() {
	  return password;
  }
  
  /**
   * Specify which password to use for authentication.
   * 
   * @param password
   * @return reference to self
   */
  public WebDriverCredentials setPassword(String password) {
	  this.password = password;
	  return this;
  }
  
  /**
   * Gets authentication host to which the credentials apply
   * 
   * @return The authentication host, or null if not set
   */
  public String getHost() {
	  return host;
  }
  
  /**
   * Specify which port to which the credentials apply
   * 
   * @param host
   * @return reference to self
   */
  public WebDriverCredentials setHost(String host) {
	  this.host = host;
	  return this;
  }
  
  /**
   * Gets the port to which the credentials apply.
   * 
   * @return the port, or -1 if unspecified
   */
  public int getPort() {
	  return port;
  }

  /**
   * Specify which port to which the credentials apply
   * @param port The port; use -1 for unspecified
   * @return reference to self
   */
  public WebDriverCredentials setPort(int port) {
	  this.port = port;
	  return this;
  }
  
  /**
   * Gets the realm to which the credentials apply
   * @return The realm, or null if not set
   */
  public String getRealm() {
	  return realm;
  }
  
  /**
   * Specify the realm to which the credentials apply.
   * @param realm
   * @return reference to self
   */
  public WebDriverCredentials setRealm(String realm) {
	  this.realm = realm;
	  return this;
  }
  
  /**
   * Gets the workstation for NTLM authentication
   * @return the workstation
   */
  public String getNtlmWorkstation() {
	  return ntlmWorkstation;
  }
  
  /**
   * Specifies the workstation for NTLM authentication
   * 
   * @param ntlmWorkstation The workstation
   * @return reference to self
   */
  public WebDriverCredentials setNtlmWorkstation(String ntlmWorkstation) {
	  this.ntlmWorkstation = ntlmWorkstation;
	  return this;
  }
  
  /**
   * Gets the domain for NTLM authentication
   * 
   * @return the domain
   */
  public String getNtlmDomain() {
	  return ntlmDomain;
  }
  
  /**
   * Specifies the domain for NTLM authentication
   * 
   * @param ntlmDomain The domain
   * @return reference to self
   */
  public WebDriverCredentials setNtlmDomain(String ntlmDomain) {
	  this.ntlmDomain = ntlmDomain;
	  return this;
  }

  @SuppressWarnings({"unchecked"})
  public static WebDriverCredentials extractFrom(Capabilities capabilities) {
    Object rawCredentials = capabilities.getCapability("credentials");
    WebDriverCredentials credentials = null;
    if (rawCredentials != null) {
      if (rawCredentials instanceof WebDriverCredentials) {
    	  credentials = (WebDriverCredentials) rawCredentials;
      } else if (rawCredentials instanceof Map) {
    	  credentials = new WebDriverCredentials((Map<String, ?>) rawCredentials);
      }
    }
    return credentials;
  }
}
