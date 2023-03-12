using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace NpgsqlIncludeIssue.Controllers;

[ApiController]
[Route("[controller]")]
public class IncludeIssueController : ControllerBase
{
    public async Task<ActionResult> Get()
    {
        var context = new DatabaseContext();
        var id = Guid.NewGuid();

        var unexpectedResult = context.BaseMyClasses
            .Where(x => x.Id == id && x.Information.Boolean)
            .Include(x => x.Information.Nav1)
            .Include(x => x.Information.Nav2)
            .ToList();
        
        // Generates:
        // SELECT b."Id", b."BaseEntityProperty", b."Information_Boolean", b."Information_Nav1Id", b."Information_Nav2Id"
        // FROM "BaseMyClasses" AS b
        // WHERE b."Id" = @__id_0 AND b."Information_Boolean"

        
        
        var expectedResult = context.BaseMyClasses
            .Include(x => x.Information.Nav1)
            .Include(x => x.Information.Nav2)
            .Where(x => x.Id == id && x.Information.Boolean)
            .ToList();
        
        // Generates:
        // SELECT b."Id", b."BaseEntityProperty", b."Information_Boolean", b."Information_Nav1Id", b."Information_Nav2Id", n."Id", n0."Id"
        // FROM "BaseMyClasses" AS b
        // LEFT JOIN "Nav1" AS n ON b."Information_Nav1Id" = n."Id"
        // LEFT JOIN "Nav2" AS n0 ON b."Information_Nav2Id" = n0."Id"


        return Ok();
    }
}



