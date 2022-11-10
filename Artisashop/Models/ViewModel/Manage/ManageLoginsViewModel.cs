﻿// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.


using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;

namespace Artisashop.Models.ViewModel.Manage
{
    public class ManageLoginsViewModel
    {
        public bool IsLinkedToFranceConnect { get; set; }

        public bool CanRemoveExternalLogin { get; set; }

        public UserLoginInfo? FranceConnectUserAccount { get; set; }

        public AuthenticationScheme? FranceConnectProvider { get; set; }
    }
}
