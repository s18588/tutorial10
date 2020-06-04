using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Tutorial10.Models
{
    public partial class s18588Context : DbContext
    {
        public s18588Context()
        {
        }

        public s18588Context(DbContextOptions<s18588Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<CategoryReservation> CategoryReservation { get; set; }
        public virtual DbSet<Enrollment> Enrollment { get; set; }
        public virtual DbSet<Guest> Guest { get; set; }
        public virtual DbSet<PaymentType> PaymentType { get; set; }
        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<Reservation> Reservation { get; set; }
        public virtual DbSet<Room> Room { get; set; }
        public virtual DbSet<RoomAssigned> RoomAssigned { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<Studies> Studies { get; set; }
        public virtual DbSet<Task> Task { get; set; }
        public virtual DbSet<TaskType> TaskType { get; set; }
        public virtual DbSet<TeamMember> TeamMember { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=db-mssql16.pjwstk.edu.pl;Initial Catalog=s18588;User ID=apbds18588; Password=admin");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(x => x.IdCategory)
                    .HasName("Category_pk");

                entity.Property(e => e.IdCategory).ValueGeneratedNever();

                entity.Property(e => e.Category1)
                    .IsRequired()
                    .HasColumnName("Category")
                    .HasMaxLength(20);

                entity.Property(e => e.Price).HasColumnType("money");
            });

            modelBuilder.Entity<CategoryReservation>(entity =>
            {
                entity.HasKey(x => x.IdCategoryReservation)
                    .HasName("CategoryReservation_pk");

                entity.Property(e => e.IdCategoryReservation).ValueGeneratedNever();

                entity.HasOne(d => d.IdCategoryNavigation)
                    .WithMany(p => p.CategoryReservation)
                    .HasForeignKey(x => x.IdCategory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CategoryReservation_Category");

                entity.HasOne(d => d.IdReservationNavigation)
                    .WithMany(p => p.CategoryReservation)
                    .HasForeignKey(x => x.IdReservation)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CategoryReservation_Reservation");
            });

            modelBuilder.Entity<Enrollment>(entity =>
            {
                entity.HasKey(x => x.IdEnrollment)
                    .HasName("Enrollment_pk");

                entity.Property(e => e.IdEnrollment).ValueGeneratedNever();

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.IdStudyNavigation)
                    .WithMany(p => p.Enrollment)
                    .HasForeignKey(x => x.IdStudy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Enrollment_Studies");
            });

            modelBuilder.Entity<Guest>(entity =>
            {
                entity.HasKey(x => x.IdGuest)
                    .HasName("Guest_pk");

                entity.Property(e => e.IdGuest).ValueGeneratedNever();

                entity.Property(e => e.Discount).HasColumnType("decimal(3, 2)");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PaymentType>(entity =>
            {
                entity.HasKey(x => x.IdPaymentType)
                    .HasName("PaymentType_pk");

                entity.Property(e => e.IdPaymentType).ValueGeneratedNever();

                entity.Property(e => e.PaymentType1)
                    .IsRequired()
                    .HasColumnName("PaymentType")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasKey(x => x.IdProject)
                    .HasName("Project_pk");

                entity.Property(e => e.Deadline).HasColumnType("date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.HasKey(x => x.IdReservation)
                    .HasName("Reservation_pk");

                entity.Property(e => e.IdReservation).ValueGeneratedNever();

                entity.Property(e => e.ConfirmationDate).HasColumnType("date");

                entity.Property(e => e.DateFrom).HasColumnType("date");

                entity.Property(e => e.DateTo).HasColumnType("date");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.HasOne(d => d.IdGuestNavigation)
                    .WithMany(p => p.Reservation)
                    .HasForeignKey(x => x.IdGuest)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Reservation_Guest");

                entity.HasOne(d => d.IdPaymentTypeNavigation)
                    .WithMany(p => p.Reservation)
                    .HasForeignKey(x => x.IdPaymentType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Reservation_PaymentType");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.HasKey(x => x.IdRoom)
                    .HasName("Room_pk");

                entity.Property(e => e.IdRoom).ValueGeneratedNever();

                entity.Property(e => e.Number)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCategoryNavigation)
                    .WithMany(p => p.Room)
                    .HasForeignKey(x => x.IdCategory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Room_Category");
            });

            modelBuilder.Entity<RoomAssigned>(entity =>
            {
                entity.HasKey(x => new { x.IdRoom, x.IdReservation })
                    .HasName("RoomAssigned_pk");

                entity.HasOne(d => d.IdReservationNavigation)
                    .WithMany(p => p.RoomAssigned)
                    .HasForeignKey(x => x.IdReservation)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RoomInReservation_Reservation");

                entity.HasOne(d => d.IdRoomNavigation)
                    .WithMany(p => p.RoomAssigned)
                    .HasForeignKey(x => x.IdRoom)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RoomInReservation_Room");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(x => x.IndexNumber)
                    .HasName("Student_pk");

                entity.Property(e => e.IndexNumber).HasMaxLength(100);

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Studies>(entity =>
            {
                entity.HasKey(x => x.IdStudy)
                    .HasName("Studies_pk");

                entity.Property(e => e.IdStudy).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.HasKey(x => x.IdTask)
                    .HasName("Task_pk");

                entity.Property(e => e.Deadline).HasColumnType("date");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.IdAssignedToNavigation)
                    .WithMany(p => p.TaskIdAssignedToNavigation)
                    .HasForeignKey(x => x.IdAssignedTo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Task_TeamMember2");

                entity.HasOne(d => d.IdCreatorNavigation)
                    .WithMany(p => p.TaskIdCreatorNavigation)
                    .HasForeignKey(x => x.IdCreator)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Task_TeamMember1");

                entity.HasOne(d => d.IdProjectNavigation)
                    .WithMany(p => p.Task)
                    .HasForeignKey(x => x.IdProject)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Task_Project");

                entity.HasOne(d => d.IdTaskTypeNavigation)
                    .WithMany(p => p.Task)
                    .HasForeignKey(x => x.IdTaskType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Task_TaskType");
            });

            modelBuilder.Entity<TaskType>(entity =>
            {
                entity.HasKey(x => x.IdTaskType)
                    .HasName("TaskType_pk");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TeamMember>(entity =>
            {
                entity.HasKey(x => x.IdTeamMember)
                    .HasName("TeamMember_pk");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
