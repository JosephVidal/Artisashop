﻿// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

namespace Artisashop.Models;

using System;

public class PivotIdentity
{
    public string? Gender { get; set; }
    public DateTimeOffset Birthdate { get; set; }
    public string? Birthcountry { get; set; }
    public string? Birthplace { get; set; }
    public string? GivenName { get; set; }
    public string? FamilyName { get; set; }
    public string? PreferredName { get; set; }
    public string? Email { get; set; }
}
