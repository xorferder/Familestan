using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Familestan.Core.Entities;

namespace Familestan.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, long, 
        IdentityUserClaim<long>, UserRole, IdentityUserLogin<long>, IdentityRoleClaim<long>, IdentityUserToken<long>>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options) { }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Follow> Follows { get; set; }
        public DbSet<FamilyCircle> FamilyCircles { get; set; }
        public DbSet<FamilyClaim> FamilyClaims { get; set; }
        public DbSet<FamilyRelation> FamilyRelations { get; set; }
        public DbSet<FamilyRelationType> FamilyRelationTypes { get; set; }
        public DbSet<FamilyTree> FamilyTrees { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Media> Media { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PostTag> PostTags { get; set; }
        public DbSet<Word> Words { get; set; }
        public DbSet<PostWord> PostWords { get; set; }
        public new DbSet<UserRole> UserRoles { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<Permission> Permissions { get; set; }
    }
}
