using System.ComponentModel.DataAnnotations;

namespace ClassRegistrationApi.Models;


//public record RegistrationRequest(
//    [property:Required] string name, 
//    [property:Required] DateTime? dateOfCourse,
//    [property:Required] string course
    //);

public record RegistrationRequest
{
    [Required]
    public string Name { get; init; } = string.Empty;

    [Required]
    public DateTime? DateOfCourse { get; init; }
    [Required, MaxLength(500)]
    public string Course { get; init; } = string.Empty;
}



public record Registration(string id, RegistrationRequest registration);
// {name: 'Henry Gonzalez', dateOfCourse: '2022-06-07T00:00:00', course: '62797b1a1823357feb3756ac'}
