using AutoMapper;
using EmpresaWRWeb.Domain;
using EmpresaWRWeb.ViewModels;

namespace EmpresaWRWeb.AutoMapper
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<Enterprise, EnterpriseVM>();
            CreateMap<EnterpriseVM, Enterprise>();
        }
    }
}
