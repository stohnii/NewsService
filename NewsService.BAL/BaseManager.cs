using AutoMapper;

namespace NewsService.BAL
{
    public abstract class BaseManager
    {
        protected IMapper Mapper { get; private set; }

        public BaseManager(IMapper mapper)
        {
            Mapper = mapper;
        }
    }
}
