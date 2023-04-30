using AutoMapper;
using Entity.Dto.Choice;
using Entity.Dto.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Choice.Mappings
{
    public class ChoiceProfile : Profile
    {
        public ChoiceProfile()
        {
            this.CreateMap<Entity.Domain.Choice.Choice, ChoiceDto>();
            this.CreateMap<ChoiceDto, Entity.Domain.Choice.Choice>();
        }
    }
}
