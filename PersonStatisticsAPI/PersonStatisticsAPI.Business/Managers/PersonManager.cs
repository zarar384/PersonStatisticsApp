using System.Net;
using PersonStatisticsAPI.Business.Interfaces;
using AutoMapper;
using PersonStatisticsAPI.Data;
using PersonStatisticsAPI.Models;
using PersonStatisticsAPI.DataModels;

namespace PersonStatisticsAPI.Business.Managers;

public class PersonManager : IPersonManager
{
    private readonly IDataStore _dataStore;
    private readonly IMapper _mapper;

    public PersonManager(IDataStore dataStore, IMapper mapper)
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
        PersonDto personDto = _mapper.Map<PersonDto>(model);
        try
        {
            personDto = (PersonDto)_dataStore.AddOrUpdate(personDto);
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

    public HttpModelResult Delete(Guid id)
    {
        HttpModelResult result = new HttpModelResult();
        BaseDto dto = _dataStore.Delete(id);
        result.HttpStatus = dto == null ? HttpStatusCode.NoContent : HttpStatusCode.OK;
        return result;
    }

    public HttpModelResult Get(Guid id)
    {
        HttpModelResult result = new HttpModelResult();
        BaseDto personDto = _dataStore.Get(id);
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
        IEnumerable<BaseDto> dtos = _dataStore.GetAll();
        List<Person> persons= dtos.Select(baseDto => _mapper.Map<Person>(baseDto)).ToList();
        result.Models = persons.AsEnumerable();
        result.HttpStatus= HttpStatusCode.OK;
        return result;
    }

    public HttpModelResult Update(BaseModel model, Guid id)
    {
        if(_dataStore.Get(id)== null)
        {
            return Add(model);
        }
        else
        {
            model.Id = id;
            PersonDto dto = _mapper.Map<PersonDto>(model);
            dto = (PersonDto)_dataStore.AddOrUpdate(dto);
            return new HttpModelResult
            {
                HttpStatus = HttpStatusCode.OK,
                Model = _mapper.Map<Person>(dto)
            };
        }
    }
}
