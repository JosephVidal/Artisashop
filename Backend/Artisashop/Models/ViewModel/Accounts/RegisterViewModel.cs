// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.ComponentModel.DataAnnotations;

namespace Artisashop.Models.ViewModel.Accounts
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Adresse e-mail")]
        public string Email { get; set; } = null!;

        [Required]
        [StringLength(100, ErrorMessage = "Le {0} doit faire au minimum {2} charactères de long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passe")]
        public string Password { get; set; } = null!;

        [DataType(DataType.Password)]
        [Display(Name = "Confirmer le mot de passe")]
        [Compare("Password", ErrorMessage = "Le mot de passe et le mot de passe de confirmation ne correspondent pas.")]
        public string ConfirmPassword { get; set; } = null!;

        [Display(Name = "Sexe")]
        public string Gender { get; set; } = null!;

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Date de naissance")]
        public DateTime? Birthdate { get; set; }

        [Required]
        [Display(Name = "Prénom")]
        public string GivenName { get; set; } = null!;

        [Required]
        [Display(Name = "Nom")]
        public string FamilyName { get; set; } = null!;

        [Display(Name = "Nom d'usage")]
        public string PreferredName { get; set; } = null!;

    }
}
