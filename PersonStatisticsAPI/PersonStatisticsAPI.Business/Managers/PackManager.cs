using System.Net;
using PersonStatisticsAPI.Business.Interfaces;
using AutoMapper;
using PersonStatisticsAPI.Models;
using PersonStatisticsAPI.DataModels;
using PersonStatisticsAPI.Data.Interfaces;

namespace PersonStatisticsAPI.Business.Managers;

public class PackManager : IPackManager
{
    private readonly IPackRepository _packRepository;
    private readonly IMapper _mapper;

    public PackManager(IPackRepository dataStore, IMapper mapper)
    {
        _packRepository = dataStore;
        _mapper = mapper;
    }

    public HttpModelResult Add(BaseModel model)
    {
        HttpModelResult result = new HttpModelResult();
        if (_packRepository.Get(model.Name) == null)
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
        PackDto personDto = _mapper.Map<BaseModel, PackDto>(model);
        try
        {
            personDto = _packRepository.AddOrUpdate(personDto);
            if (personDto != null)
            {
                Pack createPerson = _mapper.Map<Pack>(personDto);
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
        BaseDto dto = _packRepository.Delete(id);
        result.HttpStatus = dto == null ? HttpStatusCode.NoContent : HttpStatusCode.OK;
        return result;
    }

    public HttpModelResult Get(int id)
    {
        HttpModelResult result = new HttpModelResult();
        PackDto personDto = _packRepository.Get(id);
        if (personDto == null)
        {
            result.HttpStatus = HttpStatusCode.NotFound;
        }
        else
        {
            result.HttpStatus = HttpStatusCode.OK;
            result.Model = _mapper.Map<Pack>(personDto);
        }
        return result;
    }

    public HttpModelResult GetAll()
    {
        HttpModelResult result = new HttpModelResult();
        IEnumerable<PackDto> dtos = _packRepository.GetAll();
        List<Pack> persons= dtos.Select(dtos => _mapper.Map<Pack>(dtos)).ToList();
        result.Models = persons.AsEnumerable();
        result.HttpStatus= HttpStatusCode.OK;
        return result;
    }

    public HttpModelResult Update(BaseModel model, int id)
    {
        if(_packRepository.Get(id)== null)
        {
            return Add(model);
        }
        else
        {
            model.Id = id;
            PackDto dto = _mapper.Map<BaseModel,PackDto>(model);
            dto = _packRepository.AddOrUpdate(dto);
            return new HttpModelResult
            {
                HttpStatus = HttpStatusCode.OK,
                Model = _mapper.Map<Pack>(dto)
            };
        }
    }
}
