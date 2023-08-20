using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web;
using PersonStatisticsAPI.Business.Interfaces;
using PersonStatisticsAPI.Extensions;
using PersonStatisticsAPI.Models;

namespace PersonStatisticsAPI;
public class PackController : BaseApiController
{
    private readonly IPackManager _packManager;

    public PackController(IPackManager packManager)
    {
        _packManager = packManager;
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        HttpModelResult modelResult = _packManager.Get(id);
        if (modelResult.HttpStatus == HttpStatusCode.OK)
        {
            Pack pack = modelResult.Model as Pack;
            return Ok(pack);
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
    public IActionResult Post([FromBody] Pack pack)
    {
        if (!string.IsNullOrEmpty(User.GetUsername())) return NotFound();

        HttpModelResult modelResult = _packManager.Add(pack);

        if (modelResult.HttpStatus == HttpStatusCode.Created)
        {
            return new CreatedResult(string.Format("/api/pack/{0}",
                                     modelResult.Model.Id),
                                     modelResult.Model);
        }

        return new StatusCodeResult((int)modelResult.HttpStatus);
    }

    [Route("{id}")]
    [HttpPut]
    public IActionResult Put(int id,[FromBody] Pack pack)
    {
        HttpModelResult modelResult = _packManager.Update(pack, id);
        if(modelResult.HttpStatus == HttpStatusCode.Created) 
        {
            return new CreatedResult(
                string.Format("/api/pack/{0}",
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
