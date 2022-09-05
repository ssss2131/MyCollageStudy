using AutoMapper;
using ShopStoreCore.System;
using ShopStoreCore.System.Provicy;
using StoreShare.Dto.Menu;
using StoreShare.Dto.Operation;
using StoreShare.Dto.Role;
using StoreShare.Dto.User;
using StoreShare.Dto.User.Door;

namespace StoreShare
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {           
            CreateMap<MenuAddDto, SystemMenu>();
            CreateMap<UserAddDto, SystemUser>();
            CreateMap<SystemRole,RolesDto>();
            CreateMap<RoleAddDto, SystemRole>();
            CreateMap<SystemOperation, OprsDto>();
            CreateMap<OprsAddDto, SystemOperation>();
            CreateMap<SystemUser, UsersDto>();
            CreateMap<UserAddDto, SystemUser>();
            CreateMap<LoginDto, SystemUser>();
        }
    }
}