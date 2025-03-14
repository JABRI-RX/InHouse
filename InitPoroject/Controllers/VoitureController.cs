using InitPoroject.Dto.Voiture;
using InitPoroject.Helpers;
using InitPoroject.Interface;
using InitPoroject.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace InitPoroject.Controllers;

[ApiController]
[Route("api/v1/voitures")]
public class VoitureController : ControllerBase
{
    private readonly IVoitureRepository _voitureRepository;
    private readonly IClientRepository _clientRepository;

    public VoitureController(IVoitureRepository voitureRepository, IClientRepository clientRepository)
    {
        _voitureRepository = voitureRepository;
        _clientRepository = clientRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllVoitures([FromQuery] QueryObjectVoiture queryObjectVoiture)
    {
        var voitures = await _voitureRepository.GetAllVoituressasync(queryObjectVoiture);
        if (voitures is null)
            return BadRequest("Voitures is null");
        return Ok(voitures.Select(v => v.ToReadVoitureDto()));
    }

    [HttpGet("{immatriculation}")]
    public async Task<IActionResult> GetVoitureByImma([FromRoute] string immatriculation)
    {
        var voiture = await _voitureRepository.GetCarByImmatriculationAsync(immatriculation);
        if (voiture is null)
            return NotFound(new { message = "Voiture N'exist Pas" });
        return Ok(voiture.ToReadVoitureDto());
    }

    [HttpPost]
    public async Task<IActionResult> CreateVoiture([FromBody] CreateVoitureDto voitureDto)
    {
        Console.WriteLine("WAHT THE FUCK");
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        //this is used to check for attribitues that have string value but they are int 
        var checkResult = CheckFunctions.CheckCreateVoitureDto(voitureDto);
        if (!string.IsNullOrEmpty(checkResult))
            return BadRequest(new {message=checkResult});
        
        var voiture = await _voitureRepository.CreateCarAsync(voitureDto.FromCreateToNormal());
        if (voiture.Voiture is null)
            return BadRequest(new { message = voiture.Message });

        return CreatedAtAction(
            nameof(GetVoitureByImma),
            new { immatriculation = voiture },
            voiture.Voiture.ToReadVoitureDto()
        );
    }

    [HttpPut("{immatriculation}")]
    public async Task<IActionResult> UpdateVoiture([FromRoute] string immatriculation, [FromBody] UpdateVoitureDto voitureDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var voiture = await _voitureRepository.UpdateVoitureAsync(immatriculation, voitureDto);
        if (voiture.Voiture is null)
            return BadRequest(new { message = voiture.Message });
        return Ok(voiture.Voiture.ToReadVoitureDto());
    }
    [HttpDelete("{immatriculation}")]
    public async Task<IActionResult> DeleteVoiture(string immatriculation)
    {
        var isDeleted = await _voitureRepository.DeleteVoitureAsync(immatriculation);
        if (!isDeleted)
            return NotFound(new { message = "Voiture N'exist Pas" });
        return NoContent();
    }
}