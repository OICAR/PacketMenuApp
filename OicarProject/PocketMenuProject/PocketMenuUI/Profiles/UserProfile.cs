using AutoMapper;
using PocketMenuUI.Models;
using PocketMenuUI.Models.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocketMenuUI.Profiles
{
    public class UserProfile :Profile
    {

        public UserProfile()
        {
            CreateMap<User, UserDTO>()
             .ForMember(
                dest => dest.EatingHabits,
                opt => opt.MapFrom(src => src.TempEatingHabits));
        }
       

    }
}
