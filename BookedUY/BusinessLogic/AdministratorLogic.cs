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
                var newAdmin = this.administratorRepository.AddAndSave(administrator);
                return newAdmin;
            }
            throw new AlreadyExistsException("Administrator");
        }

        public Administrator GetByEmailAndPassword(string email, string password)
        {
            CheckEmail(email);
            var administrator = this.administratorRepository.GetByEmail(email);
            CheckAdministratorNull(administrator);
            CheckAdministrator(administrator, password);
            return administrator;            
        }

        private void CheckEmail(string email)
        {
            if (email == null)
            {
                throw new NullInputException("Administrator Email");
            }
            
        }

        private void CheckAdministratorNull(Administrator administrator)
        {
            if (administrator == null)
            {
                throw new NotFoundException("Administrator");
            }
        }
        private void CheckAdministrator(Administrator administrator, string password)
        {
            if (administrator.Password != password)
            {
                throw new NotFoundException("Administrator");
            }
        }

        public IEnumerable<Administrator> GetAll()
        {
            return this.administratorRepository.GetAll();
        }

        public Administrator Delete(Administrator administrator)
        {
            var administratorCheck = this.administratorRepository.GetByEmail(administrator.Email);
            CheckAdministratorNull(administratorCheck);
            return this.administratorRepository.Delete(administrator);
        }

        public Administrator GetById(int id)
        {
            var administrator = this.administratorRepository.GetById(id);
            CheckAdministratorNull(administrator);
            return administrator;
        }
    }
}