using PlatformService.Models;


namespace PlatformService.Data
{
    public class PlatformRepository(AppDbContext context) : IPlatformRepository
    {
        private readonly AppDbContext _context = context;

        public void CreatePlatform(Platform platform)
        {
            _context.Platforms.Add(platform ?? throw new ArgumentException(nameof(platform)));
        }



        public IEnumerable<Platform> GetAllPlatforms()
        {
            return _context.Platforms.ToList();
        }



        public Platform GetPlatformById(int id)
        {
            var platform = _context.Platforms.FirstOrDefault(p => p.Id == id);
            return platform ?? throw new InvalidOperationException("No platform found with the provided ID.");
        }



        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }
    }
}
