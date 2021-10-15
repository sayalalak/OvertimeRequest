﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Overtime.Base;
using Overtime.Models;
using Overtime.Repository.Data;
using Overtime.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Overtime.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestsController : BaseController<Request, RequestRepository, int>
    { 
        RequestRepository requestrepository;
        public RequestsController(RequestRepository repository) : base(repository)
        {
            this.requestrepository = repository;
        }

        [HttpPut("Approve")]
        public ActionResult Approve(UpdateStatusVM updateStatusVM)
        {
            try
            {
                var get = requestrepository.Approve(updateStatusVM);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    status = HttpStatusCode.BadRequest,
                    Message = e
                });
            }
        }

        [HttpPut("Decline")]
        public ActionResult Decline(UpdateStatusVM updateStatusVM)
        {
            try
            {
                var get = requestrepository.Decline(updateStatusVM);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(new 
                {
                    status = HttpStatusCode.BadRequest,
                    Message = e
                });
            }
        }
        [HttpGet("GetReq/{id}")]
        public ActionResult GetUserReq(string id)
        {
            var getRegister = requestrepository.GetReqByManagerId(id);
            if (getRegister == null)
            {
                return NotFound(getRegister);
            }
            else
            {
                return Ok(getRegister);
            }
        }
    }
}
