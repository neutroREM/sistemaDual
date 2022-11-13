using Microsoft.EntityFrameworkCore;
using sistemaDual.Interfaces;
using sistemaDual.Models;

namespace sistemaDual.Implementation
{
    public class MentorAcademicoService : IMentorAcademicoService
    {
        private readonly IGenericRespository<MentorAcademico> _respository;

        public MentorAcademicoService(IGenericRespository<MentorAcademico> respository)
        {
            _respository = respository;
        }

        public async Task<List<MentorAcademico>> Lista()
        {
            IQueryable<MentorAcademico> query = await _respository.Consultar();
            return query.Include(p => p.ProgramaEducativo).ToList();
        }

        public async Task<MentorAcademico> Crear(MentorAcademico entidad)
        {
            MentorAcademico mentor_existe = await _respository.Obtener(i => i.MentorAcademicoID == entidad.MentorAcademicoID);
            if (mentor_existe != null)
                throw new TaskCanceledException("Este Mentor ya esta registrado");

            try
            {
                MentorAcademico nuevo_mentor = await _respository.Crear(entidad);
                if (entidad.MentorAcademicoID == 0)
                    throw new TaskCanceledException("No se puedo registrar el Mentor");

                IQueryable<MentorAcademico> query = await _respository.Consultar(i => i.MentorAcademicoID == nuevo_mentor.MentorAcademicoID);
                nuevo_mentor = query.Include(p => p.ProgramaEducativo).First();
                return nuevo_mentor;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<MentorAcademico> Editar(MentorAcademico entidad)
        {
            MentorAcademico mentor_existe = await _respository.Obtener(i => i.MentorAcademicoID == entidad.MentorAcademicoID);
            if (mentor_existe == null)
                throw new TaskCanceledException("Este Mentor no esta registrado");

            try
            {
               
                IQueryable<MentorAcademico> query = await _respository.Consultar(i => i.MentorAcademicoID == entidad.MentorAcademicoID);
                MentorAcademico editar_mentor = query.First();
                editar_mentor.CURP = entidad.CURP;
                editar_mentor.Nombre = entidad.Nombre;
                editar_mentor.ApellidoP = entidad.ApellidoP;
                editar_mentor.ApellidoM = entidad.ApellidoM;
                editar_mentor.Correo = entidad.Correo;
                editar_mentor.Telefono = entidad.Telefono;
                editar_mentor.ProgramaEducativoID = entidad.ProgramaEducativoID;

                bool resp = await _respository.Editar(editar_mentor);
                if (!resp)
                    throw new TaskCanceledException("No se puedo editar el Mentor");

                MentorAcademico mentor_editado = query.Include(p => p.ProgramaEducativo).First();
                return mentor_editado;

            }
            catch 
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(int mentorAcademicoID)
        {
            try
            {
                MentorAcademico mentor_eliminar = await _respository.Obtener(i => i.MentorAcademicoID == mentorAcademicoID);
                if (mentor_eliminar == null)
                    throw new TaskCanceledException("No existe este Mentor");

                bool resp = await _respository.Eliminar(mentor_eliminar);
                return true;
            }
            catch
            {
                throw;
            }
        }

    }
}
