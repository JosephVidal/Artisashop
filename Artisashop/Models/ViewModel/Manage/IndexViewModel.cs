// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.


using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Artisashop.Models.ViewModel.Manage
{
    public class IndexViewModel
    {
        public bool HasPassword { get; set; }

        public IList<UserLoginInfo> Logins { get; set; }

        public bool BrowserRemembered { get; set; }
    }
}
