using AutoMapper;
using PhantasiaEngine.Auth.Models;
using PhantasiaEngine.Auth.Requests;
using PhantasiaEngine.Shared.Utilities;

namespace PhantasiaEngine.Auth.Profiles
{
    // ReSharper disable once UnusedType.Global
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserRequest, User>()
                .ForMember(dest => dest.PasswordHash,
                    opt =>
                        opt.MapFrom(src => Cryptonite.Hash(src.Password)))
                .ForMember(dest => dest.Token,
                    opt => 
                        opt.MapFrom(src => Tokenizer.CreateTimestampedToken()));
        }
    }
}