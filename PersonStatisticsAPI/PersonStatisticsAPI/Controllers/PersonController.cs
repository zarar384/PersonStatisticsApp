using System.Net;
using Microsoft.AspNetCore.Mvc;
using PersonStatisticsAPI.Business.Interfaces;
using PersonStatisticsAPI.Db;
using PersonStatisticsAPI.Models;

namespace PersonStatisticsAPI;
public class PersonController : BaseApiController
{
    private readonly IPersonManager _personManager;
    private readonly AppDbContext _db;

    public PersonController(IPersonManager personManager, AppDbContext db)
    {
        _personManager = personManager;
        _db = db;
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        HttpModelResult modelResult = _personManager.Get(id);
        if (modelResult.HttpStatus == HttpStatusCode.OK)
        {
            Person person = modelResult.Model as Person;
            return Ok(person);
        }

        switch (modelResult.HttpStatus)
        {
            case HttpStatusCode.NotFound:
                return NotFound();
        }

        return BadRequest();
    }

    [Route("")]
    [HttpPost]
    public IActionResult Post([FromBody] Person person)
    {
        HttpModelResult modelResult = _personManager.Add(person);
        if (modelResult.HttpStatus == HttpStatusCode.Created)
        {
            _db.Add(person);
            _db.SaveChanges();
            return new CreatedResult(string.Format("/api/person/{0}",
                                     modelResult.Model.Id),
                                     modelResult.Model);
        }

        return new StatusCodeResult((int)modelResult.HttpStatus);
    }

    [Route("{id}")]
    [HttpPut]
    public IActionResult Put(int id,[FromBody] Person person)
    {
        HttpModelResult modelResult = _personManager.Update(person, id);
        if(modelResult.HttpStatus == HttpStatusCode.Created) 
        {
            return new CreatedResult(
                string.Format("/api/person/{0}",
                modelResult.Model.Id),
                modelResult.Model);
        }

        return new StatusCodeResult((int)modelResult.HttpStatus);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        HttpModelResult modelResult = _personManager.Delete(id);
        return new StatusCodeResult((int)modelResult.HttpStatus);
    }

    [Route("")]
    [HttpGet]
    public IActionResult Get()
    {
        HttpModelResult modelResult = _personManager.GetAll();
        return Ok(modelResult.Models);
    }
}
