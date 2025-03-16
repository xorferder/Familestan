using Microsoft.EntityFrameworkCore;
using Familestan.Core.Entities;

namespace Familestan.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options) { }

        // 🟢 تعریف DbSet ها
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Member> Members { get; set; }
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
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<NotificationSetting> NotificationSettings { get; set; }
        public DbSet<OtpVerification> OtpVerifications { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 🔹 تنظیم کلیدهای اصلی
            modelBuilder.Entity<User>().HasKey(u => u.UserId);
            modelBuilder.Entity<Member>().HasKey(m => m.MemberId);
            modelBuilder.Entity<UserRole>().HasKey(ur => ur.UserRoleId);
            modelBuilder.Entity<RolePermission>().HasKey(rp => rp.RolePermissionId);
            modelBuilder.Entity<PostTag>().HasKey(pt => new { pt.PostTagPostId, pt.PostTagTagId });
            modelBuilder.Entity<PostWord>().HasKey(pw => new { pw.PostWordPostId, pw.PostWordWordId });
            modelBuilder.Entity<OtpVerification>().HasKey(o => o.OtpId);

            // 🔹 تنظیم روابط `UserRole`
            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.UserRoleUser)
                .WithMany()
                .HasForeignKey(ur => ur.UserRoleUserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.UserRoleRole)
                .WithMany()
                .HasForeignKey(ur => ur.UserRoleRoleId)
                .OnDelete(DeleteBehavior.Cascade);

            // 🔹 تنظیم روابط `RolePermission`
            modelBuilder.Entity<RolePermission>()
                .HasOne(rp => rp.RolePermissionRole)
                .WithMany()
                .HasForeignKey(rp => rp.RolePermissionRoleId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<RolePermission>()
                .HasOne(rp => rp.RolePermissionPermission)
                .WithMany()
                .HasForeignKey(rp => rp.RolePermissionPermissionId)
                .OnDelete(DeleteBehavior.Cascade);

            // 🔹 تنظیم روابط `Post`
            modelBuilder.Entity<Post>()
                .HasOne(p => p.PostMember)
                .WithMany()
                .HasForeignKey(p => p.PostMemberId)
                .OnDelete(DeleteBehavior.Cascade);

            // 🔹 تنظیم روابط `Comment` (🚀 مشکل Cascade حل شد)
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.CommentPost)
                .WithMany()
                .HasForeignKey(c => c.CommentPostId)
                .OnDelete(DeleteBehavior.Restrict); // ⬅️ جلوگیری از Cascade حذف پست و کامنت

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.CommentMember)
                .WithMany()
                .HasForeignKey(c => c.CommentMemberId)
                .OnDelete(DeleteBehavior.Cascade);

            // 🔹 تنظیم روابط `Like` (🚀 مشکل Cascade حل شد)
            modelBuilder.Entity<Like>()
                .HasOne(l => l.LikePost)
                .WithMany()
                .HasForeignKey(l => l.LikePostId)
                .OnDelete(DeleteBehavior.Restrict); // ⬅️ جلوگیری از Cascade حذف پست و لایک‌ها

            modelBuilder.Entity<Like>()
                .HasOne(l => l.LikeMember)
                .WithMany()
                .HasForeignKey(l => l.LikeMemberId)
                .OnDelete(DeleteBehavior.Cascade);

            // 🔹 تنظیم روابط `Follow` (🚀 مشکل جلوگیری از حذف ترتیبی حل شد)
            modelBuilder.Entity<Follow>()
                .HasOne(f => f.FollowFollower)
                .WithMany(m => m.MemberFollowers)
                .HasForeignKey(f => f.FollowFollowerId)
                .OnDelete(DeleteBehavior.Restrict);  // جلوگیری از حذف ترتیبی

            modelBuilder.Entity<Follow>()
                .HasOne(f => f.FollowFollowing)
                .WithMany(m => m.MemberFollowing)
                .HasForeignKey(f => f.FollowFollowingId)
                .OnDelete(DeleteBehavior.Restrict);  // جلوگیری از حذف ترتیبی


            // 🔹 تنظیم روابط `FamilyRelation`
            modelBuilder.Entity<FamilyRelation>()
                .HasOne(fr => fr.FamilyRelationMember1)
                .WithMany()
                .HasForeignKey(fr => fr.FamilyRelationMember1Id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<FamilyRelation>()
                .HasOne(fr => fr.FamilyRelationMember2)
                .WithMany()
                .HasForeignKey(fr => fr.FamilyRelationMember2Id)
                .OnDelete(DeleteBehavior.Restrict);

            // 🔹 تنظیم روابط `FamilyClaim`
            modelBuilder.Entity<FamilyClaim>()
                .HasOne(fc => fc.FamilyClaimClaimant)
                .WithMany()
                .HasForeignKey(fc => fc.FamilyClaimClaimantId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<FamilyClaim>()
                .HasOne(fc => fc.FamilyClaimTargetMember)
                .WithMany()
                .HasForeignKey(fc => fc.FamilyClaimTargetMemberId)
                .OnDelete(DeleteBehavior.Restrict);

            // 🔹 تنظیم روابط `FamilyCircle` (🚀 مشکل حذف ترتیبی حل شد)
            modelBuilder.Entity<FamilyCircle>()
                .HasOne(fc => fc.FamilyCircleMember)
                .WithMany()
                .HasForeignKey(fc => fc.FamilyCircleMemberId)
                .OnDelete(DeleteBehavior.Restrict); // ⬅️ جلوگیری از حذف ترتیبی

            modelBuilder.Entity<FamilyCircle>()
                .HasOne(fc => fc.FamilyCircleConnectedMember)
                .WithMany()
                .HasForeignKey(fc => fc.FamilyCircleConnectedMemberId)
                .OnDelete(DeleteBehavior.Restrict); // ⬅️ جلوگیری از حذف ترتیبی

            // 🔹 تنظیم روابط `FamilyTree` (🚀 مشکل حذف ترتیبی حل شد)
            modelBuilder.Entity<FamilyTree>()
                .HasOne(ft => ft.FamilyTreeMember)
                .WithMany()
                .HasForeignKey(ft => ft.FamilyTreeMemberId)
                .OnDelete(DeleteBehavior.Restrict); // ⬅️ جلوگیری از حذف ترتیبی

            modelBuilder.Entity<FamilyTree>()
                .HasOne(ft => ft.FamilyTreeRootMember)
                .WithMany()
                .HasForeignKey(ft => ft.FamilyTreeRootMemberId)
                .OnDelete(DeleteBehavior.Restrict); // ⬅️ جلوگیری از حذف ترتیبی

            // 🔹 تنظیم روابط `PostTag`
            modelBuilder.Entity<PostTag>()
                .HasOne(pt => pt.PostTagPost)
                .WithMany()
                .HasForeignKey(pt => pt.PostTagPostId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PostTag>()
                .HasOne(pt => pt.PostTagTag)
                .WithMany()
                .HasForeignKey(pt => pt.PostTagTagId)
                .OnDelete(DeleteBehavior.Cascade);

            // 🔹 تنظیم روابط `PostWord`
            modelBuilder.Entity<PostWord>()
                .HasOne(pw => pw.PostWordPost)
                .WithMany()
                .HasForeignKey(pw => pw.PostWordPostId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PostWord>()
                .HasOne(pw => pw.PostWordWord)
                .WithMany()
                .HasForeignKey(pw => pw.PostWordWordId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<OtpVerification>()
                .HasOne(o => o.OtpMember)
                .WithMany()
                .HasForeignKey(o => o.OtpMemberId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
