using ClassRegistrationApi.Domain;
using ClassRegistrationApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClassRegistrationApi.Controllers;

[Route("registrations")]
[ApiController]
public class RegistrationController : ControllerBase
{

    private readonly ILookupCourseSchedules _scheduleLookup;

    public RegistrationController(ILookupCourseSchedules scheduleLookup)
    {
        _scheduleLookup = scheduleLookup;
    }

    [HttpPost]
    public async Task<ActionResult<Registration>> AddARegistration([FromBody] RegistrationRequest request)
    {
        // If the thing is valid...
        // --- Validate that the course is offered on the date.
        // Write the Code You Wish You Had
        var dateOfCourse = request.DateOfCourse!.Value;
        bool courseIsAvailableOnThatDate = await _scheduleLookup.CourseAvailabeAsync(request.Course, dateOfCourse);
        if(!courseIsAvailableOnThatDate)
        {
            return BadRequest("Sorry, that course isn't available then.");
        }
        var response = new Registration("99", request);

        return Ok(response);

    }
}
// {name: 'Henry Gonzalez', dateOfCourse: '2022-06-07T00:00:00', course: '62797b1a1823357feb3756ac'}
