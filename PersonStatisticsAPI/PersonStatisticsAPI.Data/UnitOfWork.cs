using AutoMapper;
using PersonStatisticsAPI.Data.Db;
using PersonStatisticsAPI.Data.Interfaces;

namespace PersonStatisticsAPI.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _contex;
        public UnitOfWork(AppDbContext contex, IMapper mapper)
        {
            _contex = contex;
            _mapper = mapper;

        }
        public IUserRepository UserRepository => new UserRepository(_contex, _mapper);

        public IBoxRepository BoxRepository => new BoxRepository(_contex, _mapper);

        public async Task<bool> Complete()
        {
            return await _contex.SaveChangesAsync() > 0;
        }

        public bool HasChanges()
        {
            return _contex.ChangeTracker.HasChanges();
        }
    }
}