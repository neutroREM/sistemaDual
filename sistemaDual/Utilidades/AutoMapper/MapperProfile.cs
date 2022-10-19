using sistemaDual.Models;
using sistemaDual.Models.ViewModels;
using AutoMapper;

namespace sistemaDual.Utilidades.AutoMapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            #region Rol
            CreateMap<Rol, RolViewModel>().ReverseMap();
            #endregion

            #region Domicilio
            CreateMap<Domicilio, DomicilioViewModel>().ReverseMap();
            #endregion

            #region Universidad
            CreateMap<Universidad, UniversidadViewModel>()
                .ForMember(dest => dest.Direccion,
                opt => opt.MapFrom(src => src.Domicilio));

            CreateMap<Universidad, UniversidadViewModel>()
                .ForMember(dest => dest.Direccion,
                opt => opt.Ignore());
            #endregion

            #region ProgramaEducativo
            CreateMap<ProgramaEducativo, ProgramaEducativoViewModel>()
                .ForMember(dest => dest.UniversidadID,
                opt => opt.MapFrom(src => src.Universidad));
            
            CreateMap<ProgramaEducativoViewModel, ProgramaEducativo>()
                .ForMember(dest => dest.UniversidadID,
                opt => opt.Ignore());
            #endregion

            #region Empresa
            CreateMap<Empresa, EmpresaViewModel>()
                .ReverseMap();
            #endregion

            #region Estatus
            CreateMap<Estatus, EstatusViewModel>().ReverseMap();
            #endregion

            #region BecaDual
            CreateMap<BecaDual, BecaDualViewModel>().ReverseMap();
            #endregion

            #region AlumnoDual
            #endregion

            #region MentorEmpresarial
            #endregion

            #region MentorAcademico
            #endregion

            #region AsesorInstitucional
            #endregion

            #region ResposableInstitucional
            #endregion
        }
    }
}
