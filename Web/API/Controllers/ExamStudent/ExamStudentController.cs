﻿using Abstraction.Service.Course;
using Abstraction.Service.ExamUser;
using AutoMapper;
using Entity.Dto.Course;
using Entity.Dto.ExamUser;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.ExamUser
{
    [ApiController]
    [Route("[controller]")]
    public class ExamUserController : ControllerBase
    {
        private readonly IExamUserService examUserService;
        private readonly IMapper mapper;

        public ExamUserController(IExamUserService examUserService, IMapper mapper)
        {
            this.examUserService = examUserService;
            this.mapper = mapper;
        }

        [HttpGet("GetExamByUserId/{userId}")]
        public List<ExamUserDto> GetExamByUserId(string user)
        {
            var response = this.examUserService.GetExamByUser(user);
            return response;
        }

    }
}
