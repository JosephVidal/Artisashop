// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

namespace Artisashop.Models.ViewModel.Accounts;

using System.ComponentModel.DataAnnotations;

public class ExternalLoginConfirmationViewModel
{
    [EmailAddress]
    [Display(Name = "Adresse e-mail")]
    public required string? Email { get; set; }

    [Display(Name = "Sexe")]
    public required string? Gender { get; set; }

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    [Display(Name = "Date de naissance")]
    public required DateTime? Birthdate { get; set; }

    [Display(Name = "Prénom")]
    public required string? GivenName { get; set; }

    [Display(Name = "Nom")]
    public required string? LastName { get; set; }

    [Display(Name = "Nom d'usage")]
    public string? PreferredName { get; set; }
}