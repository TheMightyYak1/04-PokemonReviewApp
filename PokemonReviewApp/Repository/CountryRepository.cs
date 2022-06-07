public class CountryRepository : ICountryRepository
{
    
    private DataContext _context;
    public CountryRepository(DataContext context)
    {
        _context = context;
    }

    public bool CountryExists(int id)
    {
        return _context.Counties.Any(c => c.Id == id);
    }

    public bool CreateCountry(Country country)
    {
        _context.Add(country);
        return Save();
    }

    public ICollection<Country> GetCountries()
    {
        return _context.Counties.ToList();
    }

    public Country GetCountry(int id)
    {
        return _context.Counties.Where(c => c.Id == id).FirstOrDefault();
    }

    public Country GetCountryByOwner(int ownerId)
    {
        return _context.Owners.Where(o => o.Id == ownerId).Select(c => c.Country).FirstOrDefault();
    }

    public ICollection<Owner> GetOwnersFromACountry(int countryId)
    {
        return _context.Owners.Where(c => c.Country.Id == countryId).ToList();
    }

    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0 ? true : false;
    }

    public bool UpdateCountry(Country country)
    {
        _context.Update(country);
        return Save();
    }

}