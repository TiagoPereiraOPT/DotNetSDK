﻿using System;
using System.Configuration;
using JudoPayDotNet;
using JudoPayDotNet.Authentication;
using JudoPayDotNet.Enums;
using JudoPayDotNet.Http;
using JudoPayDotNetDotNet.Configuration;
using JudoPayDotNetDotNet.Logging;

namespace JudoPayDotNetDotNet
{
    // ReSharper disable UnusedMember.Global
	/// <summary>
	/// This factory creates an instance of the JudoPay client using the supplied credentials
	/// </summary>
    public static class JudoPaymentsFactory
    {
        private const string Apiversionheader = "api-version";
	    private const string ApiVersionKey = "ApiVersion";
        private const string SandboxUrlKey = "SandboxUrl";
        private const string LiveUrlKey = "LiveUrl";
	    private const string DEFAULT_API_VERSION = "5.0";
        private const string DEFAULT_SANDBOX_URL = "https://gw1.judopay-sandbox.com/";
        private const string DEFAULT_LIVE_URL = "https://gw1.judopay.com/";
        private static readonly IJudoConfiguration defaultConfigurationAccess = new JudoConfiguration();

	    private static readonly Func<string, string, IJudoConfiguration, string> GetConfigValue = (key, defaultValue, configuration) =>
	    {
	        string configurationSetting;
            return string.IsNullOrWhiteSpace(configurationSetting = configuration[key])
	            ? defaultValue
	            : configurationSetting;
	    };


        private static JudoPayApi Create(Credentials credentials, string baseUrl, IJudoConfiguration configuration)
        {
            //TODO allow this to be set for testing
            var apiVersion = GetConfigValue(ApiVersionKey, DEFAULT_API_VERSION, configuration);

            var httpClient = new HttpClientWrapper(new AuthorizationHandler(credentials,
                                                    DotNetLoggerFactory.Create(typeof(AuthorizationHandler))),
                                                    new VersioningHandler(Apiversionheader, apiVersion));
            var connection = new Connection(httpClient,
                                            DotNetLoggerFactory.Create,
                                            baseUrl);
            var client = new Client(connection);

            return new JudoPayApi(DotNetLoggerFactory.Create, client);
        }

        internal static string GetEnvironmentUrl(JudoEnvironment judoEnvironment, IJudoConfiguration configuration = null)
        {
            string key = null;
		    string defaultValue = null;

            switch (judoEnvironment)
            {
                case JudoEnvironment.Sandbox:
                    key = SandboxUrlKey;
                    defaultValue = DEFAULT_SANDBOX_URL;
                    break;
                case JudoEnvironment.Live:
                    key = LiveUrlKey;
                    defaultValue = DEFAULT_LIVE_URL;
                    break;
            }

            return GetConfigValue(key, defaultValue, configuration ?? defaultConfigurationAccess);
        }

		/// <summary>
		/// Creates an instance of the judopay api client with a custom base url, that will authenticate with your api token and secret.
		/// </summary>
		/// <param name="judoEnvironment">Either the sandbox (development/testing) or live environments</param>
		/// <param name="token">Your API token (from our merchant dashboard)</param>
		/// <param name="secret">Your API secret (from our merchant dashboard)</param>
		public static JudoPayApi Create(JudoEnvironment judoEnvironment, string token, string secret)
        {
            return Create(token, secret, GetEnvironmentUrl(judoEnvironment), defaultConfigurationAccess);
        }

	    /// <summary>
	    /// Creates an instance of the judopay api client with a custom base url, that will authenticate with your api token and secret.
	    /// </summary>
	    /// <remarks>This is intented for development/sandbox environments</remarks>
	    /// <param name="token"></param>
	    /// <param name="secret"></param>
	    /// <param name="baseUrl"></param>
	    /// <param name="configuration">Application configuration accessor</param>
	    /// <returns></returns>
	    public static JudoPayApi Create(string token, string secret, string baseUrl, IJudoConfiguration configuration = null)
        {
            var credentials = new Credentials(token, secret);
            return Create(credentials, baseUrl, configuration ?? defaultConfigurationAccess);
        }

		/// <summary>
		/// Creates an instance of the judopay api client with a custom base url, that will authenticate with the supplied OAuth access token
		/// </summary>
		/// <param name="judoEnvironment">Either the sandbox (development/testing) or live environments</param>
		/// <param name="oauthAccessToken">Your marketplace seller's access token</param>
		/// <returns></returns>
        public static JudoPayApi Create(JudoEnvironment judoEnvironment, string oauthAccessToken)
        {
            return Create(oauthAccessToken, GetEnvironmentUrl(judoEnvironment), defaultConfigurationAccess);
        }

	    /// <summary>
	    /// Creates an instance of the judopay api client with a custom base url, that will authenticate with the supplied OAuth access token
	    /// </summary>
	    /// <remarks>This is intented for development/sandbox environments</remarks>
	    /// <param name="oauthAccessToken">Your marketplace seller's access token</param>
	    /// <param name="baseUrl"></param>
        /// <param name="configuration">Application configuration accessor</param>
	    /// <returns></returns>
		public static JudoPayApi Create(string oauthAccessToken, string baseUrl, IJudoConfiguration configuration = null)
        {
            var credentials = new Credentials(oauthAccessToken);
            return Create(credentials, baseUrl, configuration ?? defaultConfigurationAccess);
        }

	    internal static JudoPayApi Create(string version, string token, string secret, string baseUrl, IJudoConfiguration configuration = null)
	    {
	        return Create(token, secret, baseUrl, configuration);
	    }
    }
    // ReSharper restore UnusedMember.Global
}
