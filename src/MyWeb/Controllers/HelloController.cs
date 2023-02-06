using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace MyWeb.Controllers;

public record UploadProfileRequest(string Name, string Email);

[ApiController]
[Route("api/hello")]
public class HelloController : ControllerBase {

    [HttpPost("update-profile")]
    public async Task<ActionResult<string>> UpdateProfile(
        [FromBody] JsonElement json,
        [FromServices] ILogger<HelloController> logger) {

        // using var reader = new StreamReader(Request.Body, Encoding.UTF8);
        // var jsonBody = await reader.ReadToEndAsync();
        var jsonBody = json.ToString();

        logger.LogInformation("Update profile: {Json}", jsonBody);

        return Ok(jsonBody);
    }
}