using Microsoft.EntityFrameworkCore;
using Relay.DBUtility;

namespace Relay.DBUtility.Models;

public class User(int id, string name)
{
    public required int Id { get; set; } = id;

    public required string Name { get; set; } = name;
}