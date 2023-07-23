using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PersonStatisticsAPI.Data.Db;
using PersonStatisticsAPI.Data.Interfaces;
using PersonStatisticsAPI.DataModels;
using PersonStatisticsAPI.Models;

namespace PersonStatisticsAPI.Data;
public class PersonRepository : IPersonRepository
{
    private readonly AppliacationDbContext _db;
    private readonly IMapper _mapper;

    public PersonRepository(AppliacationDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public PersonDto AddOrUpdate(PersonDto dto)
    {
        Person person = _mapper.Map<PersonDto, Person>(dto);
        if (dto.Id > 0)
        {
            _db.Persons.Update(person);
        }
        else
        {
            _db.Persons.Add(person);
        }
        _db.SaveChanges();

        return _mapper.Map<Person,PersonDto>(person);
    }

    public PersonDto Delete(int id)
    {
        Person person = _db.Persons.FirstOrDefault(x => x.Id == id);
        if (person != null)
        {
            _db.Persons.Remove(person);
            return _mapper.Map<PersonDto>(person);
        }
        else
        {
            return null;
        }
    }

    public PersonDto Get(int id)
    {
        Person person = _db.Persons.AsNoTracking().FirstOrDefault(x => x.Id == id);
        return _mapper.Map<PersonDto>(person);
    }

    public PersonDto Get(string name)
    {
        Person person = _db.Persons.AsNoTracking().FirstOrDefault(x=>x.Name== name);
        return _mapper.Map<PersonDto>(person); 
    }

    public IEnumerable<PersonDto> GetAll()
    {
        IEnumerable<Person> personList = _db.Persons.ToList();
        return _mapper.Map<List<PersonDto>>(personList);
    }
}
