public interface IOwnerRepository
{
    ICollection<Owner> GetOwners();
    Owner GetOwner(int id);
    ICollection<Owner> GetOwnerOfAPokemon(int pokeId);
    ICollection<Pokemon> GetPokemonByOwner(int ownerId);
    bool OwnerExists(int ownerId);
}