using AutoMapper;
using Entity.Dto.Choice;

namespace API.Models.Choice.Mappings
{
    public class ChoiceProfile : Profile
    {
        public ChoiceProfile()
        {
            this.CreateMap<ChoiceCreateRequest, ChoiceDto>();
        }
    }
}
