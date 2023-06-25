using System.Net;
using PersonStatisticsAPI.Business.Interfaces;
using AutoMapper;
using PersonStatisticsAPI.Data;
using PersonStatisticsAPI.Models;
using PersonStatisticsAPI.DataModels;

namespace PersonStatisticsAPI.Business;

public class PersonManager : IPersonManager
{
    private readonly IDataStore _dataStore;
    private readonly IMapper _mapper;

    public PersonManager(IDataStore dataStore, IMapper mapper)
    {
        _dataStore = dataStore;
        _mapper = mapper;
    }

    HttpModelResult IPersonManager.Add(BaseModel model)
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

    HttpModelResult IPersonManager.Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    HttpModelResult IPersonManager.Get(Guid id)
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

    HttpModelResult IPersonManager.GetAll()
    {
        throw new NotImplementedException();
    }

    HttpModelResult IPersonManager.Update(BaseModel model, Guid id)
    {
        throw new NotImplementedException();
    }
}
