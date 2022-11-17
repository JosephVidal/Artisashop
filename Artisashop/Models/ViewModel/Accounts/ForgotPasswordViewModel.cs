// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.ComponentModel.DataAnnotations;

namespace Artisashop.Models.ViewModel.Accounts
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Adresse e-mail")]
        public string Email { get; set; } = null!;
    }
}
