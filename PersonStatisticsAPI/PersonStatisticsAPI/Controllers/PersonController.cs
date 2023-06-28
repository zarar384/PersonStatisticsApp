using System.Net;
using Microsoft.AspNetCore.Mvc;
using PersonStatisticsAPI.Business.Interfaces;
using PersonStatisticsAPI.Models;

namespace PersonStatisticsAPI;
public class PersonController : BaseApiController
{
    private readonly IPersonManager _personManager;

    public PersonController(IPersonManager personManager)
    {
        _personManager = personManager;
    }

    [HttpGet("{id}")]
    public IActionResult Get(Guid id)
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
            return new CreatedResult(string.Format("/api/person/{0}",
                                     modelResult.Model.Id),
                                     modelResult.Model);
        }

        return new StatusCodeResult((int)modelResult.HttpStatus);
    }

    [Route("{id}")]
    [HttpPut]
    public IActionResult Put(Guid id,[FromBody] Person person)
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
    public IActionResult Delete(Guid id)
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
