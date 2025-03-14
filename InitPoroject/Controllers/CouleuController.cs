using InitPoroject.Interface;
using InitPoroject.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace InitPoroject.Controllers;

[ApiController]
[Route("api/v1/couleurs")]
public class CouleuController : ControllerBase
{
    private readonly ICouleurRepository _couleurRepository;

    public CouleuController(ICouleurRepository couleurRepository)
    {
        _couleurRepository = couleurRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCouleursAsync()
    {
        var couleurs = await _couleurRepository.GetAllCouleurs();
        if (couleurs is null)
            return BadRequest(new { message = "Couleurs Is NUll" });
        return Ok(couleurs.Select(c=>c.ToReadCouleurDto()));
    }
}