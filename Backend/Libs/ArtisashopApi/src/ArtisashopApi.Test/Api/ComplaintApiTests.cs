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
    ///  Class for testing ComplaintApi
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by OpenAPI Generator (https://openapi-generator.tech).
    /// Please update the test case below to test the API endpoint.
    /// </remarks>
    public class ComplaintApiTests : IDisposable
    {
        private ComplaintApi instance;

        public ComplaintApiTests()
        {
            instance = new ComplaintApi();
        }

        public void Dispose()
        {
            // Cleanup when everything is done.
        }

        /// <summary>
        /// Test an instance of ComplaintApi
        /// </summary>
        [Fact]
        public void InstanceTest()
        {
            // TODO uncomment below to test 'IsType' ComplaintApi
            //Assert.IsType<ComplaintApi>(instance);
        }

        /// <summary>
        /// Test ApiComplaintGet
        /// </summary>
        [Fact]
        public void ApiComplaintGetTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string? userId = null;
            //int? productId = null;
            //var response = instance.ApiComplaintGet(userId, productId);
            //Assert.IsType<List<Complaint>>(response);
        }

        /// <summary>
        /// Test ApiComplaintIdGet
        /// </summary>
        [Fact]
        public void ApiComplaintIdGetTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //int id = null;
            //var response = instance.ApiComplaintIdGet(id);
            //Assert.IsType<Complaint>(response);
        }

        /// <summary>
        /// Test ApiComplaintPost
        /// </summary>
        [Fact]
        public void ApiComplaintPostTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //Complaint? complaint = null;
            //var response = instance.ApiComplaintPost(complaint);
            //Assert.IsType<Complaint>(response);
        }
    }
}
