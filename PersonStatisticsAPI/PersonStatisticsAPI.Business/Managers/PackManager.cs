using System.Net;
using PersonStatisticsAPI.Business.Interfaces;
using AutoMapper;
using PersonStatisticsAPI.Models;
using PersonStatisticsAPI.DataModels;
using PersonStatisticsAPI.Data.Interfaces;

namespace PersonStatisticsAPI.Business.Managers;

public class BoxManager : IBoxManager
{
    private readonly IBoxRepository _boxRepository;
    private readonly IMapper _mapper;

    public BoxManager(IBoxRepository dataStore, IMapper mapper)
    {
        _boxRepository = dataStore;
        _mapper = mapper;
    }

    public HttpModelResult Add(BaseModel model)
    {
        HttpModelResult result = new HttpModelResult();
        if (_boxRepository.Get(model.Id) == null)
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
        BoxDto boxDto = _mapper.Map<BaseModel, BoxDto>(model);

        try
        {
            boxDto = _boxRepository.AddOrUpdate(boxDto);
            
            if (boxDto != null)
            {
                Box createPerson = _mapper.Map<Box>(boxDto);
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
        BaseDto dto = _boxRepository.Delete(id);
        result.HttpStatus = dto == null ? HttpStatusCode.NoContent : HttpStatusCode.OK;
        return result;
    }

    public HttpModelResult Get(int id)
    {
        HttpModelResult result = new HttpModelResult();
        BoxDto personDto = _boxRepository.Get(id);
        if (personDto == null)
        {
            result.HttpStatus = HttpStatusCode.NotFound;
        }
        else
        {
            result.HttpStatus = HttpStatusCode.OK;
            result.Model = _mapper.Map<Box>(personDto);
        }
        return result;
    }

    public HttpModelResult GetAll()
    {
        HttpModelResult result = new HttpModelResult();
        IEnumerable<BoxDto> dtos = _boxRepository.GetAll();
        List<Box> persons = dtos.Select(dtos => _mapper.Map<Box>(dtos)).ToList();
        result.Models = persons.AsEnumerable();
        result.HttpStatus = HttpStatusCode.OK;
        return result;
    }

    public HttpModelResult Update(BaseModel model, int id)
    {
        if (_boxRepository.Get(id) == null)
        {
            return Add(model);
        }
        else
        {
            model.Id = id;
            BoxDto dto = _mapper.Map<BaseModel, BoxDto>(model);
            dto = _boxRepository.AddOrUpdate(dto);
            return new HttpModelResult
            {
                HttpStatus = HttpStatusCode.OK,
                Model = _mapper.Map<Box>(dto)
            };
        }
    }
}
