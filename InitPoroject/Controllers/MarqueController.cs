using InitPoroject.Interface;
using InitPoroject.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace InitPoroject.Controllers;
[ApiController]
[Route("api/v1/marques")]
public class MarqueController : ControllerBase
{
    private readonly IMarqueRepository _marqueRepository;
    
    public MarqueController(IMarqueRepository marqueRepository)
    {
        _marqueRepository = marqueRepository;
    }
    [HttpGet]
    public async Task<IActionResult> GetALlMarques()
    {
        var marques = await _marqueRepository.GetAllMarques();
        if (marques is null)
            return BadRequest(new { message = "Marques Is NUll" });
        return Ok(marques.Select(m=>m.ToReadMarqueDto()));
    }
}