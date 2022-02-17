using Microsoft.EntityFrameworkCore;

namespace Backend.Challenge_repository.Model
{
    public class InnovationCastContext : DbContext
    {
        public InnovationCastContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<CommentModel> Comments { get; set; }
    }
}
