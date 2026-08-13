namespace Day1WebApi.Dto;

public class AssignUserRoleDto
{
    public required string Email { get; set; }
    public required string RoleName { get; set; }
}