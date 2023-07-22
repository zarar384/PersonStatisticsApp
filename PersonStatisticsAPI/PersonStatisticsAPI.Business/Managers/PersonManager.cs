using System.Net;
using PersonStatisticsAPI.Business.Interfaces;
using AutoMapper;
using PersonStatisticsAPI.Models;
using PersonStatisticsAPI.DataModels;
using PersonStatisticsAPI.Data.Interfaces;

namespace PersonStatisticsAPI.Business.Managers;

public class PersonManager : IPersonManager
{
    private readonly IPersonRepository _dataStore;
    private readonly IMapper _mapper;

    public PersonManager(IPersonRepository dataStore, IMapper mapper)
    {
        _dataStore = dataStore;
        _mapper = mapper;
    }

    public HttpModelResult Add(BaseModel model)
    {
        HttpModelResult result = new HttpModelResult();
        if (_dataStore.Get(model.Name) == null)
        {
            result = AddModel(model);
        }
        else
        {
            result.HttpStatus = HttpStatusCode.Conflict;
            return result;
        }
        return result;
    }

    private HttpModelResult AddModel(BaseModel model)
    {
        HttpModelResult result = new HttpModelResult();
        PersonDto personDto = _mapper.Map<BaseModel, PersonDto>(model);
        try
        {
            personDto = _dataStore.AddOrUpdate(personDto);
            if (personDto != null)
            {
                Person createPerson = _mapper.Map<Person>(personDto);
                result.Model = createPerson;
                result.HttpStatus = HttpStatusCode.Created;
            }
            else
            {
                result.HttpStatus = HttpStatusCode.InternalServerError;
            }
        }
        catch
        {
            result.HttpStatus = HttpStatusCode.InternalServerError;
        }

        return result;
    }

    public HttpModelResult Delete(int id)
    {
        HttpModelResult result = new HttpModelResult();
        BaseDto dto = _dataStore.Delete(id);
        result.HttpStatus = dto == null ? HttpStatusCode.NoContent : HttpStatusCode.OK;
        return result;
    }

    public HttpModelResult Get(int id)
    {
        HttpModelResult result = new HttpModelResult();
        PersonDto personDto = _dataStore.Get(id);
        if (personDto == null)
        {
            result.HttpStatus = HttpStatusCode.NotFound;
        }
        else
        {
            result.HttpStatus = HttpStatusCode.OK;
            result.Model = _mapper.Map<Person>(personDto);
        }
        return result;
    }

    public HttpModelResult GetAll()
    {
        HttpModelResult result = new HttpModelResult();
        IEnumerable<PersonDto> dtos = _dataStore.GetAll();
        List<Person> persons= dtos.Select(dtos => _mapper.Map<Person>(dtos)).ToList();
        result.Models = persons.AsEnumerable();
        result.HttpStatus= HttpStatusCode.OK;
        return result;
    }

    public HttpModelResult Update(BaseModel model, int id)
    {
        if(_dataStore.Get(id)== null)
        {
            return Add(model);
        }
        else
        {
            model.Id = id;
            PersonDto dto = _mapper.Map<BaseModel,PersonDto>(model);
            dto = _dataStore.AddOrUpdate(dto);
            return new HttpModelResult
            {
                HttpStatus = HttpStatusCode.OK,
                Model = _mapper.Map<Person>(dto)
            };
        }
    }
}
