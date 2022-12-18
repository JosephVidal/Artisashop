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
    ///  Class for testing AdminUserRoleApi
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by OpenAPI Generator (https://openapi-generator.tech).
    /// Please update the test case below to test the API endpoint.
    /// </remarks>
    public class AdminUserRoleApiTests : IDisposable
    {
        private AdminUserRoleApi instance;

        public AdminUserRoleApiTests()
        {
            instance = new AdminUserRoleApi();
        }

        public void Dispose()
        {
            // Cleanup when everything is done.
        }

        /// <summary>
        /// Test an instance of AdminUserRoleApi
        /// </summary>
        [Fact]
        public void InstanceTest()
        {
            // TODO uncomment below to test 'IsType' AdminUserRoleApi
            //Assert.IsType<AdminUserRoleApi>(instance);
        }

        /// <summary>
        /// Test ApiAdminUserRoleGet
        /// </summary>
        [Fact]
        public void ApiAdminUserRoleGetTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string? filter = null;
            //string? range = null;
            //string? sort = null;
            //var response = instance.ApiAdminUserRoleGet(filter, range, sort);
            //Assert.IsType<List<StringIdentityUserRole>>(response);
        }

        /// <summary>
        /// Test ApiAdminUserRoleIdDelete
        /// </summary>
        [Fact]
        public void ApiAdminUserRoleIdDeleteTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //int id = null;
            //var response = instance.ApiAdminUserRoleIdDelete(id);
            //Assert.IsType<StringIdentityUserRole>(response);
        }

        /// <summary>
        /// Test ApiAdminUserRoleIdGet
        /// </summary>
        [Fact]
        public void ApiAdminUserRoleIdGetTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //int id = null;
            //var response = instance.ApiAdminUserRoleIdGet(id);
            //Assert.IsType<StringIdentityUserRole>(response);
        }

        /// <summary>
        /// Test ApiAdminUserRoleIdPut
        /// </summary>
        [Fact]
        public void ApiAdminUserRoleIdPutTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //int id = null;
            //StringIdentityUserRole? stringIdentityUserRole = null;
            //var response = instance.ApiAdminUserRoleIdPut(id, stringIdentityUserRole);
            //Assert.IsType<StringIdentityUserRole>(response);
        }

        /// <summary>
        /// Test ApiAdminUserRolePost
        /// </summary>
        [Fact]
        public void ApiAdminUserRolePostTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //StringIdentityUserRole? stringIdentityUserRole = null;
            //var response = instance.ApiAdminUserRolePost(stringIdentityUserRole);
            //Assert.IsType<StringIdentityUserRole>(response);
        }
    }
}