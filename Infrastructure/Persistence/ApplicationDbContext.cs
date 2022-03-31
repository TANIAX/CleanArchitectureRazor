using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Application.Common;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Infrastructure.Identity;
using Domain.Common;

namespace Infrastructure.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
    {
        private readonly IDateTime _dateTime;
        private readonly ICurrentUserService _currentUserService;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IDateTime dateTime, ICurrentUserService currentUserService) : base(options)
        {
            _dateTime = dateTime;
            _currentUserService = currentUserService;
        }

        public DbSet<TodoList> TodoLists => Set<TodoList>();
        public DbSet<TodoItem> TodoItems => Set<TodoItem>();


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        if (_currentUserService.UserId != String.Empty)
                            entry.Entity.CreatedBy = _currentUserService.UserId;
                        entry.Entity.Created = _dateTime.Now;
                        break;

                    case EntityState.Modified:
                        if (_currentUserService.UserId != String.Empty)
                            entry.Entity.LastModifiedBy = _currentUserService.UserId;
                        entry.Entity.LastModified = _dateTime.Now;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region TodoItem
            //Create index
            modelBuilder.Entity<TodoItem>()
                .HasIndex(b => b.Title);

            //Adding default value
            modelBuilder.Entity<TodoItem>()
                .Property(b => b.Title)
                .HasDefaultValue("Todo");
            #endregion

            #region TodoList
            //Multiple columns index
            modelBuilder.Entity<TodoList>()
                .HasIndex(b => new { b.CreatedBy, b.Title });
            #endregion

            base.OnModelCreating(modelBuilder);
        }

    }
}