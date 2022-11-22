namespace Artisashop.Models.MappingProfiles;

using Artisashop.Models;
using Artisashop.Models.ViewModel;
using AutoMapper;
using ViewModel.Accounts;

public class AccountMappingProfile : Profile
{
    public AccountMappingProfile()
    {
        CreateMap<Register, Account>();
        
        // Fetch and update
        CreateMap<Account, AccountViewModel>();
        CreateMap<AccountViewModel, Account>();
    }
}