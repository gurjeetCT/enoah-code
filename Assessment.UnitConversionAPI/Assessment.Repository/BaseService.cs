using AutoMapper;

namespace Assessment.Repository
{

    public abstract class BaseRepository
    {        
        protected readonly IMapper _mapper;
        public BaseRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

    }
}