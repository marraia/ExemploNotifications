using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExemploNotifications.Domain;
using ExemploNotifications.Domain.Services.Abstraction;
using Marraia.Notifications.Base;
using Marraia.Notifications.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExemploNotifications.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : BaseController
    {
        private readonly IStudentDomainService _studentDomainService;

        public StudentController(
            IStudentDomainService studentDomainService,
            INotificationHandler<DomainNotification> notification
        ) 
            : base (notification)
        {
            _studentDomainService = studentDomainService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(string), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Post([FromBody] Student input)
        {
            var student = _studentDomainService
                                    .Insert(input);

            return CreatedContent("", student);
        }
    }
}
