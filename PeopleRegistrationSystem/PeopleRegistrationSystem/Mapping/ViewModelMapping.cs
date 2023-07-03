using AutoMapper;
using PeopleRegistrationSystem.Models;
using PeopleRegistrationSystem.ViewModels;

namespace PeopleRegistrationSystem.Mapping
{
    public class ViewModelMapping:Profile
    {
        public ViewModelMapping()
        {
            CreateMap<User,UserViewModel>().ReverseMap();
        }
    }
}
