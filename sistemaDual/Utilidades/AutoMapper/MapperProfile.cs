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
                opt => opt.MapFrom(src => src.Domicilio.Direccion))
                .ForMember(dest => dest.Colonia,
                opt => opt.MapFrom(src => src.Domicilio.Colonia))
                .ForMember(dest => dest.Municipio,
                opt => opt.MapFrom(src => src.Domicilio.Municipio))
                .ForMember(dest => dest.CodigoPostal,
                opt => opt.MapFrom(src => src.Domicilio.CodigoPostal))
                ;

            CreateMap<UniversidadViewModel, Universidad>()
                .ForMember(dest => dest.Domicilio,
                opt => opt.Ignore());



            #endregion

            #region ProgramaEducativo
            CreateMap<ProgramaEducativo, ProgramaEducativoViewModel>()
                .ForMember(dest => dest.NombreU,
                opt => opt.MapFrom(src => src.Universidad.NombreU));

            CreateMap<ProgramaEducativoViewModel, ProgramaEducativo>()
                .ForMember(dest => dest.Universidad,
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

            #region Asignatura
            CreateMap<Asignatura, AsignaturaViewModel>().ReverseMap();
            #endregion

            #region AlumnoDual
            CreateMap<AlumnoDual, AlumnoDualViewModel>()
                .ForMember(dest => dest.Descripcion,
                opt => opt.MapFrom(src => src.Rol.Descripcion))
                .ForMember(dest => dest.EsActivo,
                opt => opt.MapFrom(src => src.EsActivo == true ? 1 : 0))
                .ForMember(dest => dest.Estatus,
                opt => opt.MapFrom(src => src.Estatus.Descripcion));


            CreateMap<AlumnoDualViewModel, AlumnoDual>()
                .ForMember(dest => dest.Rol,
                opt => opt.Ignore())
                .ForMember(dest => dest.EsActivo,
                opt => opt.MapFrom(src => src.EsActivo == 1 ? true : false))
                .ForMember(dest => dest.Estatus,
                opt => opt.Ignore());

            #endregion

            #region MentorEmpresarial
            CreateMap<MentorEmpresarial, MentorEmpresarialViewModel>()
                .ForMember(dest => dest.NombreC,
                opt => opt.MapFrom(src => src.Empresa.NombreC));

            CreateMap<MentorEmpresarialViewModel, MentorEmpresarial>()
                .ForMember(dest => dest.Empresa,
                opt => opt.Ignore());
            #endregion

            #region MentorAcademico
            CreateMap<MentorAcademico, MentorAcademicoViewModel>()
                .ForMember(dest => dest.NombreP,
                opt => opt.MapFrom(src => src.ProgramaEducativo.NombreP));

            CreateMap<MentorAcademicoViewModel, MentorAcademico>()
                .ForMember(dest => dest.ProgramaEducativo,
                opt => opt.Ignore());
            #endregion

            #region AsesorInstitucional
            CreateMap<AsesorInstitucional, AsesorInstitucionalViewModel>()
                .ForMember(dest => dest.NombreP,
                opt => opt.MapFrom(src => src.ProgramaEducativo.NombreP));

            CreateMap<AsesorInstitucionalViewModel, AsesorInstitucional>()
                .ForMember(dest => dest.ProgramaEducativo,
                opt => opt.Ignore());
            #endregion

            #region ResposableInstitucional
            CreateMap<ResponsableInstitucional, ResponsableInstitucionalViewModel>()
                .ForMember(dest => dest.NombreU,
                opt => opt.MapFrom(src => src.Universidad.NombreU));

            CreateMap<ResponsableInstitucionalViewModel, ResponsableInstitucional>()
                .ForMember(dest => dest.Universidad,
                opt => opt.Ignore());
            #endregion


            #region CatalagoProyecto

            CreateMap<CatalagoProyecto, CatalagoProyectoViewModel>()
                .ForMember(dest => dest.FechaInicio,
                opt => opt.MapFrom(src => src.FechaInicio.Value.ToString("dd/MM/yyyy")))
                 .ForMember(dest => dest.FechaTermino,
                opt => opt.MapFrom(src => src.FechaTermino.Value.ToString("dd/MM/yyyy")))
                .ForMember(dest => dest.CURP,
                opt => opt.MapFrom(src => src.AlumnoDual.CURP))
                .ForMember(dest => dest.NombreA,
                opt => opt.MapFrom(src => src.AlumnoDual.NombreA))
                .ForMember(dest => dest.NombreC,
                opt => opt.MapFrom(src => src.Empresa.NombreC))
                .ForMember(dest => dest.NombreP,
                opt => opt.MapFrom(src => src.ProgramaEducativo.NombreP))
                .ForMember(dest => dest.NombreAsesor,
                opt => opt.MapFrom(src => src.AsesorInstitucional.NombreA))
                .ForMember(dest => dest.NombreResponsable,
                opt => opt.MapFrom(src => src.ResponsableInstitucional.NombreR));

            CreateMap<CatalagoProyectoViewModel, CatalagoProyecto>()
                .ForMember(dest => dest.AlumnoDual,
                opt => opt.Ignore())
                .ForMember(dest => dest.Empresa,
                opt => opt.Ignore())
                .ForMember(dest => dest.ProgramaEducativo,
                opt => opt.Ignore())
                .ForMember(dest => dest.AsesorInstitucional,
                opt => opt.Ignore())
                .ForMember(dest => dest.ResponsableInstitucional,
                opt => opt.Ignore());


            #endregion
        }
    }
}
