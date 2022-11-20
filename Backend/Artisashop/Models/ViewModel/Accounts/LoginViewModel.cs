// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.ComponentModel.DataAnnotations;

namespace Artisashop.Models.ViewModel.Accounts
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Adresse e-mail")]
        public string Email { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passe")]
        public string Password { get; set; } = null!;

        [Display(Name = "Se souvenir de moi ?")]
        public bool RememberMe { get; set; }
    }
}
