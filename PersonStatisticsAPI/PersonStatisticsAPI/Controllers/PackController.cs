using System.Net;
using Microsoft.AspNetCore.Mvc;
using PersonStatisticsAPI.Business.Interfaces;
using PersonStatisticsAPI.Models;

namespace PersonStatisticsAPI;
public class PackController : BaseApiController
{
    private readonly IPackManager _packManager;

    public PackController(IPackManager personManager)
    {
        _packManager = personManager;
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        HttpModelResult modelResult = _packManager.Get(id);
        if (modelResult.HttpStatus == HttpStatusCode.OK)
        {
            Pack person = modelResult.Model as Pack;
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
    public IActionResult Post([FromBody] Pack person)
    {
        HttpModelResult modelResult = _packManager.Add(person);
        if (modelResult.HttpStatus == HttpStatusCode.Created)
        {
            //_db.Add(person);
            //_db.SaveChanges();
            return new CreatedResult(string.Format("/api/person/{0}",
                                     modelResult.Model.Id),
                                     modelResult.Model);
        }

        return new StatusCodeResult((int)modelResult.HttpStatus);
    }

    [Route("{id}")]
    [HttpPut]
    public IActionResult Put(int id,[FromBody] Pack person)
    {
        HttpModelResult modelResult = _packManager.Update(person, id);
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
        HttpModelResult modelResult = _packManager.Delete(id);
        return new StatusCodeResult((int)modelResult.HttpStatus);
    }

    [Route("")]
    [HttpGet]
    public IActionResult Get()
    {
        HttpModelResult modelResult = _packManager.GetAll();
        return Ok(modelResult.Models);
    }
}
