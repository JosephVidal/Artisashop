/*
 * API Artisashop
 *
 * No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)
 *
 * The version of the OpenAPI document: v1
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using OpenAPIDateConverter = ArtisashopApi.Client.OpenAPIDateConverter;

namespace ArtisashopApi.Model
{
    /// <summary>
    /// Defines DeliveryOption
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum DeliveryOption
    {
        /// <summary>
        /// Enum DELIVERY for value: DELIVERY
        /// </summary>
        [EnumMember(Value = "DELIVERY")]
        DELIVERY = 1,

        /// <summary>
        /// Enum TAKEOUT for value: TAKEOUT
        /// </summary>
        [EnumMember(Value = "TAKEOUT")]
        TAKEOUT = 2

    }

}
