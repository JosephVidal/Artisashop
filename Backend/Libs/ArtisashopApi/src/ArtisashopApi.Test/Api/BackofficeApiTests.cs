/*
 * API Artisashop
 *
 * No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)
 *
 * The version of the OpenAPI document: v1
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */

using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using RestSharp;
using Xunit;

using ArtisashopApi.Client;
using ArtisashopApi.Api;
// uncomment below to import models
//using ArtisashopApi.Model;

namespace ArtisashopApi.Test.Api
{
    /// <summary>
    ///  Class for testing BackofficeApi
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by OpenAPI Generator (https://openapi-generator.tech).
    /// Please update the test case below to test the API endpoint.
    /// </remarks>
    public class BackofficeApiTests : IDisposable
    {
        private BackofficeApi instance;

        public BackofficeApiTests()
        {
            instance = new BackofficeApi();
        }

        public void Dispose()
        {
            // Cleanup when everything is done.
        }

        /// <summary>
        /// Test an instance of BackofficeApi
        /// </summary>
        [Fact]
        public void InstanceTest()
        {
            // TODO uncomment below to test 'IsType' BackofficeApi
            //Assert.IsType<BackofficeApi>(instance);
        }

        /// <summary>
        /// Test ApiBackofficeChangeValidationStatusPatch
        /// </summary>
        [Fact]
        public void ApiBackofficeChangeValidationStatusPatchTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //Dictionary<string, string>? requestBody = null;
            //var response = instance.ApiBackofficeChangeValidationStatusPatch(requestBody);
            //Assert.IsType<string>(response);
        }

        /// <summary>
        /// Test ApiBackofficeGet
        /// </summary>
        [Fact]
        public void ApiBackofficeGetTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //var response = instance.ApiBackofficeGet();
            //Assert.IsType<List<Account>>(response);
        }

        /// <summary>
        /// Test ApiBackofficeSetAccountParamPatch
        /// </summary>
        [Fact]
        public void ApiBackofficeSetAccountParamPatchTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string? userId = null;
            //string? propertyName = null;
            //bool? value = null;
            //var response = instance.ApiBackofficeSetAccountParamPatch(userId, propertyName, value);
            //Assert.IsType<string>(response);
        }

        /// <summary>
        /// Test ApiBackofficeStatsGet
        /// </summary>
        [Fact]
        public void ApiBackofficeStatsGetTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //var response = instance.ApiBackofficeStatsGet();
            //Assert.IsType<Home>(response);
        }
    }
}
