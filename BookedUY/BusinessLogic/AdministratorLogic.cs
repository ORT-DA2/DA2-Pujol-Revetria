using BusinessLogicInterface;
using DataAccessInterface;
using Domain;
using System.Collections.Generic;

namespace BusinessLogic
{
    public class AdministratorLogic : IAdministratorLogic
    {
        private readonly IAdministratorRepository administratorRepository;

        public AdministratorLogic(IAdministratorRepository administratorRepository)
        {
            this.administratorRepository = administratorRepository;
        }

        public Administrator AddAdministrator(Administrator administrator)
        {
            if (this.administratorRepository.GetByEmail(administrator.Email) == null)
            {
                var newAdmin = this.administratorRepository.Add(administrator);
                return newAdmin;
            }
            throw new AlreadyExistsException("Administrator");
        }

        public Administrator GetByEmailAndPassword(string email, string password)
        {
            if (email == null)
            {
                throw new NullInputException("Administrator Email");
            }
            var admin = this.administratorRepository.GetByEmail(email);
            if (admin == null) {
                throw new NotFoundException("Administrator");
            }
            if (admin.Password == password)
            {
                return admin;
            }
            throw new NotFoundException("Administrator");
        }

        public IEnumerable<Administrator> GetAll()
        {
            return this.administratorRepository.GetAll();
        }

        public Administrator Delete(Administrator administrator)
        {
            if (this.administratorRepository.GetByEmail(administrator.Email) == null)
            {
                throw new NotFoundException("Administrator");
            }
            return this.administratorRepository.Delete(administrator);
        }

        public Administrator GetById(int id)
        {
            var administrator = this.administratorRepository.GetById(id);
            if (administrator == null)
            {
                throw new NotFoundException("Administrator");
            }
            return administrator;
        }
    }
}