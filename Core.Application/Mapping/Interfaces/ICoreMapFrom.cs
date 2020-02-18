using AutoMapper;

namespace Core.Application.Mapping.Interfaces
{
    public interface ICoreMapFrom<T>
    {
        void Mapping(Profile profile)
        {
            profile.CreateMap(typeof(T), GetType());
        }
    }
}
