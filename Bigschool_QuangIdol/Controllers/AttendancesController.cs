using Bigschool_QuangIdol.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bigschool_QuangIdol.DTOs;

namespace Bigschool_QuangIdol.Controllers
{
    [Authorize]
    public class AttendancesController : ApiController
    {
        ApplicationDbContext dbContext;
        public AttendancesController()
        {
            dbContext = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult Attend(AttendanceDto attendanceDto)
        {
            var userId = User.Identity.GetUserId();
            if (dbContext.Attendances.Any(a => a.AttendeeId == userId && a.CourseId == attendanceDto.CourseId))
                return BadRequest("The Attendance already exists");
            var attendance = new Attendance
            {
                CourseId = attendanceDto.CourseId,
                AttendeeId = userId
            };
            dbContext.Attendances.Add(attendance);
            dbContext.SaveChanges();
            return Ok();
        }
    }
}