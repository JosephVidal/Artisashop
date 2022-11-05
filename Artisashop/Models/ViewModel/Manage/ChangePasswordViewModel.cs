﻿// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.


using System.ComponentModel.DataAnnotations;

namespace Artisashop.Models.ViewModel.Manage
{
    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passe actuel")]
        public string OldPassword { get; set; } = null!;

        [Required]
        [StringLength(100, ErrorMessage = "Le {0} doit faire au minimum {2} charactères de long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Nouveau mot de passe")]
        public string NewPassword { get; set; } = null!;

        [DataType(DataType.Password)]
        [Display(Name = "Confirmer le nouveau mot de passe")]
        [Compare("NewPassword", ErrorMessage = "Le nouveau mot de passe et le mot de passe de confirmation ne correspondent pas.")]
        public string ConfirmPassword { get; set; } = null!;
    }
}
