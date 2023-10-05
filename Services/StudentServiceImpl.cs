using AutoMapper;
using StudentsDbApp.DAO;
using StudentsDbApp.DTO;
using StudentsDbApp.Models;
using System.Transactions;

namespace StudentsDbApp.Services
{
    public class StudentServiceImpl : IStudentService
    {
        private readonly IStudentDAO _studentDAO;
        private readonly IMapper _mapper;
        private readonly ILogger<StudentServiceImpl> _logger;

        public StudentServiceImpl(IStudentDAO studentDAO, IMapper mapper, ILogger<StudentServiceImpl> logger)
        {
            this._studentDAO = studentDAO;
            _mapper = mapper;
            _logger = logger;
        }

        public IList<Student> GetAllStudents()
        {
            try
            {
                IList<Student> students = _studentDAO.GetAll();
                return students;
            } catch (Exception ex)
            {
                _logger.LogError("An error occured while fetching all students: {0}", ex.Message);
                throw;
            }
        }

        public Student? GetStudent(int id)
        {
            try
            {
                return _studentDAO.GetById(id);
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occured while fetching one student: {0}", ex.Message);
                throw;
            }
        }

        public Student? InsertStudent(StudentInsertDTO dto)
        {
            if (dto is null) return null;
            var student = _mapper.Map<Student>(dto);

            try
            {
                using TransactionScope scope = new();
                Student? insertedStudent = _studentDAO.Insert(student);
                scope.Complete();
                return insertedStudent;
            } catch (Exception ex)
            {
                _logger.LogError("An error occured while inserting a student: {0}", ex.Message);
                throw;
            }
        }

        public Student? UpdateStudent(StudentUpdateDTO dto)
        {
            if (dto is null) return null;
            Student? student = _mapper.Map<Student>(dto);
            Student? updatedStudent = null;

            try
            {
                using TransactionScope scope = new();
                updatedStudent = _studentDAO.GetById(student.Id);
                if (updatedStudent is null) return null;
                updatedStudent = _studentDAO.Update(student);
                scope.Complete();
            } catch (Exception ex)
            {
                _logger.LogError("An error occured while updating a student: {0}", ex.Message);
                throw;
            }
            return updatedStudent;
        }

        public Student? DeleteStudent(int id)
        {
            Student? student = null;

            try
            {
                using TransactionScope scope = new();
                student = _studentDAO.GetById(id);
                if (student is null) return null;
                _studentDAO.Delete(id);
                scope.Complete();
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occured while deleting a student: {0}", ex.Message);
                throw;
            }
            return student;
        }
    }
}
