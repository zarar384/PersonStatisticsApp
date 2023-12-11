using System.Net;
using Microsoft.AspNetCore.Mvc;
using PersonStatisticsAPI.Business.Interfaces;
using PersonStatisticsAPI.Extensions;
using PersonStatisticsAPI.Models;

namespace PersonStatisticsAPI;
public class BoxController : BaseApiController
{
    private readonly IBoxManager _boxManager;

    public BoxController(IBoxManager boxManager)
    {
        _boxManager = boxManager;
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        HttpModelResult modelResult = _boxManager.Get(id);

        if (modelResult.HttpStatus == HttpStatusCode.OK)
        {
            Box pack = modelResult.Model as Box;
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
    public IActionResult Create([FromBody] Box box)
    {
        if (!string.IsNullOrEmpty(User.GetUsername())) return NotFound();

        HttpModelResult modelResult = _boxManager.Add(box);

        if (modelResult.HttpStatus == HttpStatusCode.Created)
        {
            return new CreatedResult(string.Format("/api/box/{0}",
                                     modelResult.Model.Id),
                                     modelResult.Model);
        }

        return new StatusCodeResult((int)modelResult.HttpStatus);
    }

    [Route("{id}")]
    [HttpPut]
    public IActionResult Update(int id, [FromBody] Box pack)
    {
        HttpModelResult modelResult = _boxManager.Update(pack, id);
        if (modelResult.HttpStatus == HttpStatusCode.Created)
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
        HttpModelResult modelResult = _boxManager.Delete(id);
        return new StatusCodeResult((int)modelResult.HttpStatus);
    }

    [Route("")]
    [HttpGet]
    public IActionResult Get()
    {
        HttpModelResult modelResult = _boxManager.GetAll();
        return Ok(modelResult.Models);
    }
}
