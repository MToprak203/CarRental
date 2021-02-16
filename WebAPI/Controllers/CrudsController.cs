using Business.Abstract;
using Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class CrudsController<TEntityService, TEntity> : ControllerBase 
        where TEntityService : class, ICrudService<TEntity>
        where TEntity : class, IEntity, new()
    {

        public TEntityService _entityService;
        public CrudsController(TEntityService entityService)
        {
            _entityService = entityService;
        }

        [HttpPost("add")]
        public virtual IActionResult Add(TEntity entity)
        {
            var result = _entityService.Add(entity);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public virtual IActionResult Update(TEntity entity)
        {
            var result = _entityService.Update(entity);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public virtual IActionResult Delete(TEntity entity)
        {
            var result = _entityService.Delete(entity);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public virtual IActionResult GetAll()
        {
            var result = _entityService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public virtual IActionResult GetById(int id)
        {
            var result = _entityService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
