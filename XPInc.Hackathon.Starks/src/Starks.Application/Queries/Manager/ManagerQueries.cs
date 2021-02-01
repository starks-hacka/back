using System;
using System.Threading.Tasks;
using XPInc.Hackathon.Starks.Domain.AggregatesModel.ManagerAggregate;

namespace XPInc.Hackathon.Starks.Application.Queries.Manager
{
    public class ManagerQueries : IManagerQueries
    {
        private readonly IManagerRepository _managerRepository;

        public ManagerQueries(IManagerRepository managerRepository)
        {
            _managerRepository = managerRepository;
        }

        public async Task<Manager> GetManagerByIdAsync(Guid id)
        {
            var manager = await _managerRepository.GetAsync(id);

            if (manager != null)
            {
                return new Manager
                {
                    Id = manager.Id,
                    Email = manager.Email,
                    Name = manager.Name,
                    Surname = manager.Surname,
                    Phone = manager.Phone
                };
            }
            else
                return null;
        }

        public async Task<Manager> GetManagerByEmailAsync(string email)
        {
            var manager = await _managerRepository.GetAsync(email);

            if (manager != null)
            {
                return new Manager
                {
                    Id = manager.Id,
                    Email = manager.Email,
                    Name = manager.Name,
                    Surname = manager.Surname,
                    Phone = manager.Phone
                };
            }
            else
                return null;
        }
    }
}
