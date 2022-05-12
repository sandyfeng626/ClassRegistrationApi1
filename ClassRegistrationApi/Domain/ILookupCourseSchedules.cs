namespace ClassRegistrationApi.Domain;

public interface ILookupCourseSchedules
{
    Task<bool> CourseAvailabeAsync(string course, DateTime dateOfCourse);
}
