using Microsoft.AspNetCore.Mvc;
using AutoMapper;

[Route("api/[controller]")]
[ApiController]

public class CountryController : Controller
{
    private readonly ICountryRepository _countryRepository;
    private readonly IMapper _mapper;

    public CountryController(ICountryRepository countryRepository, IMapper mapper)
    {
        _countryRepository = countryRepository;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Country>))]
    public IActionResult GetCounties()
    {
        var countries = _mapper.Map<List<CountryDto>>(_countryRepository.GetCountries());

        if(!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(countries);
    }

    [HttpGet("{countryId}")]
    [ProducesResponseType(200, Type = typeof(Country))]
    [ProducesResponseType(400)]
    public IActionResult GetCountry(int countryId)
    {
        if(!_countryRepository.CountryExists(countryId))
            return NotFound();
        
        var countries = _mapper.Map<CountryDto>(_countryRepository.GetCountry(countryId));

        if(!ModelState.IsValid)
            return BadRequest(ModelState);
        return Ok(countries);
    }

    [HttpGet("/owners/{ownerId}")]
    [ProducesResponseType(400)]
    [ProducesResponseType(200, Type = typeof(Country))]
    public IActionResult GetCountryByOwner(int ownerId)
    {
        var country = _mapper.Map<CountryDto>(
            _countryRepository.GetCountryByOwner(ownerId));

        if(!ModelState.IsValid)
            return BadRequest(ModelState);
        return Ok(country);
    }
}