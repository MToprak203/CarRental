﻿using Business.Abstract;
using Entities.Concrete.Properties;
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
    public class ColorsController : CrudsController<IColorService, Color>
    {
        public ColorsController(IColorService colorService) : base(colorService)
        {
        }
    }
}
