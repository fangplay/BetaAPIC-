using BetaAPIC_.Models;

namespace BetaAPIC_.Services;

public static class GenerationService
{
    static List<Generation> Generations { get; }
    static int nextId = 3;
    static GenerationService()
    {
        Generations = new List<Generation>
        {
            new Generation { Id = 1, Name = "SPECTRUM&NEOSPECTRUM", IsActive = false },
            new Generation { Id = 2, Name = "NeoNext SPECTRUM", IsActive = true }
        };
    }

    public static List<Generation> GetAll() => Generations;

    public static Generation? Get(int id) => Generations.FirstOrDefault(p => p.Id == id);

    public static void Add(Generation Generation)
    {
        Generation.Id = nextId++;
        Generations.Add(Generation);
    }

    public static void Delete(int id)
    {
        var Generation = Get(id);
        if(Generation is null)
            return;

        Generations.Remove(Generation);
    }

    public static void Update(Generation Generation)
    {
        var index = Generations.FindIndex(p => p.Id == Generation.Id);
        if(index == -1)
            return;

        Generations[index] = Generation;
    }
}