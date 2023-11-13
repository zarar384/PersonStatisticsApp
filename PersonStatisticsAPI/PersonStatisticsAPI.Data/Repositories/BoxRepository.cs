using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PersonStatisticsAPI.Data.Db;
using PersonStatisticsAPI.Data.Interfaces;
using PersonStatisticsAPI.DataModels;
using PersonStatisticsAPI.Models;

namespace PersonStatisticsAPI.Data;
public class BoxRepository : IBoxRepository
{
    private readonly AppDbContext _db;
    private readonly IMapper _mapper;

    public BoxRepository(AppDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public BoxDto AddOrUpdate(BoxDto dto)
    {
        Box box = _mapper.Map<BoxDto, Box>(dto);

        if (dto.Id > 0)
        {
            _db.Boxes.Update(box);
        }
        else
        {
            _db.Boxes.Add(box);
        }
        _db.SaveChanges();

        return _mapper.Map<Box, BoxDto>(box);
    }

    public BoxDto Delete(int id)
    {
        Box box = _db.Boxes.FirstOrDefault(x => x.Id == id);

        if (box != null)
        {
            _db.Boxes.Remove(box);
            return _mapper.Map<BoxDto>(box);
        }
        else
        {
            return null;
        }
    }

    public BoxDto Get(int id)
    {
        Box box = _db.Boxes.AsNoTracking().FirstOrDefault(x => x.Id == id);
        return _mapper.Map<BoxDto>(box);
    }

    public BoxDto Get(string name)
    {
        Box box = _db.Boxes.AsNoTracking().FirstOrDefault(x => x.Name == name);
        return _mapper.Map<BoxDto>(box);
    }

    public IEnumerable<BoxDto> GetAll()
    {
        IEnumerable<Box> boxList = _db.Boxes.ToList();
        return _mapper.Map<List<BoxDto>>(boxList);
    }
}
