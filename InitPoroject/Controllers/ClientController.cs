using InitPoroject.Dfto.Client;
using InitPoroject.Interface;
using Microsoft.AspNetCore.Mvc;
using InitPoroject.Mappers;
namespace InitPoroject.Controllers;

[ApiController]
[Route("api/v1/clients")]
public class ClientController : ControllerBase
{
    private readonly IClientRepository _clientRepository;

    public ClientController(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }

    [HttpGet]
    public async Task<IActionResult> index()
    {
        var clients = await _clientRepository.GetAllCLientAsync();
 
        return Ok(clients.Select(c=>c.ToReadClientDto()));
    }

    [HttpGet("{cin}")]
    public async Task<IActionResult> GetClientByCIN([FromRoute] string cin)
    {
        var client = await _clientRepository.GetClientByCINAsync(cin);
        if (client is null)
            return NotFound(new {message="Client N'exist Pas"});
        return Ok(client.ToReadClientDto());
    }

    [HttpPost]
    public async Task<IActionResult> CreateClient([FromBody] CreateClientDto clientDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var client = await _clientRepository.CreateClientAsync(clientDto.FromCreateToNormal());
        if (client is null)
            return BadRequest(new { message = "Client Exist Deja" });
        return CreatedAtAction(
            nameof(GetClientByCIN),
            new {cin=client.CIN},
            client.ToReadClientDto());
    }

    [HttpPut("{cin}")]
    public async Task<IActionResult> UpdateClient([FromRoute] string cin,[FromBody] UpdateClientDto clientDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var client = await _clientRepository.UpdateClientAsync(cin,clientDto);
        if (client is null)
            return NotFound();
        return Ok(client.ToReadClientDto());
    }

    [HttpDelete("{cin}")]
    public async Task<IActionResult> DeleteClient([FromRoute] string cin)
    {
        var isDeleted = await _clientRepository.DeleteClientByCINAsync(cin);
        if (!isDeleted)
            return NotFound(new { message = "Client N'exist Pas " });
        return NoContent();
    }
}












