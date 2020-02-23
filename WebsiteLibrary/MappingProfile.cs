using System;
using AutoMapper;
using WebsiteLibrary.Models;
using WebsiteLibrary.ViewModels;

namespace WebsiteLibrary
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserRegistrationViewModel, User>()
                .ForMember(u => u.UserName, opt => opt.MapFrom(x => x.Email))
                .ForMember(u => u.Id, opt => opt.MapFrom(y => Guid.NewGuid()));
                //Guid.NewGuid() sẽ rd ra 1 Guid. Guid là 1 dạng chuỗi để làm khóa chính cho Key
                //các dữ liệu để rd ra Giud là các dữ liệu trong bô nhớ của từng máy tính: ngày tháng năm, cpu....
                //chính vì thế tỉ lệ để 2 máy trùng Giud khi rd ra là cực thấp
        }
    }
}
