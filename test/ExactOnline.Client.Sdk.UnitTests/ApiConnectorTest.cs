﻿using ExactOnline.Client.Sdk.Exceptions;
using ExactOnline.Client.Sdk.Helpers;
using ExactOnline.Client.Sdk.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace ExactOnline.Client.Sdk.UnitTests
{
    [TestClass]
    public class ApiConnectorTest
    {
        IApiConnector _connector;

        private static string GetAccessToken() => "accessToken";

        [TestInitialize]
        public void Setup() => _connector = new ApiConnector(GetAccessToken, null);


        [TestMethod]
        [TestCategory("Unit Test"), ExpectedException(typeof(ArgumentNullException))]
        public void ApiConnector_Constructor_WithoutDelegate_Fails() => 
            _ = new ApiConnector(null, null);

        [TestMethod]
        [TestCategory("Unit Test")]
        public void ApiConnector_Constructor_WithDelegate_Succeeds() => 
            _ = new ApiConnector(GetAccessToken, null);

        [TestMethod]
        [TestCategory("Unit Test"), ExpectedException(typeof(BadRequestException))]
        public void ApiConnector_DoDeleteRequest_With_EmptyValues_Fails() => 
            _connector.DoDeleteRequest(string.Empty);

        [TestMethod]
        [TestCategory("Unit Test"), ExpectedException(typeof(BadRequestException))]
        public async Task ApiConnector_DoDeleteRequest_With_EmptyValues_FailsAsync() => 
            await _connector.DoDeleteRequestAsync(string.Empty).ConfigureAwait(false);
    }
}
