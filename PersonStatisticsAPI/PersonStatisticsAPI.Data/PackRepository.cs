using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PersonStatisticsAPI.Data.Db;
using PersonStatisticsAPI.Data.Interfaces;
using PersonStatisticsAPI.DataModels;
using PersonStatisticsAPI.Models;

namespace PersonStatisticsAPI.Data;
public class PackRepository : IPackRepository
{
    private readonly AppliacationDbContext _db;
    private readonly IMapper _mapper;

    public PackRepository(AppliacationDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public PackDto AddOrUpdate(PackDto dto)
    {
        Pack person = _mapper.Map<PackDto, Pack>(dto);
        if (dto.Id > 0)
        {
            _db.Packs.Update(person);
        }
        else
        {
            _db.Packs.Add(person);
        }
        _db.SaveChanges();

        return _mapper.Map<Pack,PackDto>(person);
    }

    public PackDto Delete(int id)
    {
        Pack person = _db.Packs.FirstOrDefault(x => x.Id == id);
        if (person != null)
        {
            _db.Packs.Remove(person);
            return _mapper.Map<PackDto>(person);
        }
        else
        {
            return null;
        }
    }

    public PackDto Get(int id)
    {
        Pack person = _db.Packs.AsNoTracking().FirstOrDefault(x => x.Id == id);
        return _mapper.Map<PackDto>(person);
    }

    public PackDto Get(string name)
    {
        Pack person = _db.Packs.AsNoTracking().FirstOrDefault(x=>x.Name== name);
        return _mapper.Map<PackDto>(person); 
    }

    public IEnumerable<PackDto> GetAll()
    {
        IEnumerable<Pack> personList = _db.Packs.ToList();
        return _mapper.Map<List<PackDto>>(personList);
    }
}
