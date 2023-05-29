using AutoMapper;
using Entity.Dto.ExamUser;

namespace Service.ExamUser.Mappings
{
    public class ExamUserProfile:Profile
    {
        public ExamUserProfile()
        {
            this.CreateMap<Entity.Domain.ExamUser.ExamUser, ExamUserDto>();
			this.CreateMap<ExamUserDto, Entity.Domain.ExamUser.ExamUser>();			
		}
    }
}
