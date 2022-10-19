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
            CreateMap<AlumnoDual, AlumnoDualViewModel>()
                .ForMember(dest => dest.Direccion,
                opt => opt.MapFrom(src => src.Domicilio))
                .ForMember(dest => dest.ProgramaEducativoID,
                opt => opt.MapFrom(src => src.ProgramaEducativo))
                .ForMember(dest => dest.RolID,
                opt => opt.MapFrom(src => src.Rol))
                .ForMember(dest => dest.EstatusID,
                opt => opt.MapFrom(src => src.Estatus))
                .ForMember(dest => dest.BecaDualID,
                opt => opt.MapFrom(src => src.BecaDual));

            CreateMap<AlumnoDual, AlumnoDualViewModel>()
                .ForMember(dest => dest.Direccion,
                opt => opt.Ignore())
                .ForMember(dest => dest.ProgramaEducativoID,
                opt => opt.Ignore())
                .ForMember(dest => dest.RolID,
                opt => opt.Ignore())
                .ForMember(dest => dest.EstatusID,
                opt => opt.Ignore())
                .ForMember(dest => dest.BecaDualID,
                opt => opt.Ignore());

            #endregion

            #region MentorEmpresarial
            CreateMap<MentorEmpresarial, MentorEmpresarialViewModel>()
                .ForMember(dest => dest.EmpresaID,
                opt => opt.MapFrom(src => src.Empresa));

            CreateMap<MentorEmpresarial, MentorEmpresarialViewModel>()
                .ForMember(dest => dest.EmpresaID,
                opt => opt.Ignore());
            #endregion

            #region MentorAcademico
            CreateMap<MentorAcademico, MentorAcademicoViewModel>()
                .ForMember(dest => dest.ProgramaEducativoID,
                opt => opt.MapFrom(src => src.ProgramaEducativo));

            CreateMap<MentorAcademico, MentorAcademicoViewModel>()
                .ForMember(dest => dest.ProgramaEducativoID,
                opt => opt.Ignore());
            #endregion

            #region AsesorInstitucional
            CreateMap<AsesorInstitucional, AsesorInstitucionalViewModel>()
                .ForMember(dest => dest.ProgramaEducativoID,
                opt => opt.MapFrom(src => src.ProgramaEducativo));

            CreateMap<AsesorInstitucional, AsesorInstitucionalViewModel>()
                .ForMember(dest => dest.ProgramaEducativoID,
                opt => opt.Ignore());
            #endregion

            #region ResposableInstitucional
            CreateMap<ResponsableInstitucional, ResponsableInstitucionalViewModel>()
                .ForMember(dest => dest.UniversidadID,
                opt => opt.MapFrom(src => src.Universidad));

            CreateMap<ResponsableInstitucional, ResponsableInstitucionalViewModel>()
                .ForMember(dest => dest.UniversidadID,
                opt => opt.Ignore());
            #endregion
        }
    }
}
