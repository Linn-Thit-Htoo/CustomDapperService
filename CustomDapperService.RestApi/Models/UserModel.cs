﻿namespace CustomDapperService.RestApi.Models;

public class UserModel
{
    public long UserId { get; set; }
    public string UserName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? Password { get; set; } = null!;
    public string UserRole { get; set; } = null!;
    public int Age { get; set; }
    public string Gender { get; set; } = null!;
    public string Address { get; set; } = null!;
    public bool IsActive { get; set; }
}