using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Data.SqlClient;

#nullable disable

namespace WebAPI.Models
{
    public partial class DataAccess : DbContext
    {
        public DataAccess()
        {
        }

        public DataAccess(DbContextOptions<DataAccess> options)
            : base(options)
        {
        }

        public virtual DbSet<Enduser> Endusers { get; set; }
        public virtual DbSet<Userpassword> Userpasswords { get; set; }
        public virtual DbSet<Usersession> Usersessions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("COMP2001_DB");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Enduser>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__ENDUSER__CB9A1CDF98E69AED");

                entity.ToTable("ENDUSER");

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.Property(e => e.UserEmail)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("user_email");

                entity.Property(e => e.UserFName)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("user_fName");

                entity.Property(e => e.UserLName)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("user_lName");
            });

            modelBuilder.Entity<Userpassword>(entity =>
            {
                entity.HasKey(e => e.PasswordId)
                    .HasName("PK__USERPASS__C648F0548540FCDC");

                entity.ToTable("USERPASSWORD");

                entity.Property(e => e.PasswordId).HasColumnName("passwordID");

                entity.Property(e => e.PasswordDateChanged)
                    .HasColumnType("datetime")
                    .HasColumnName("password_dateChanged");

                entity.Property(e => e.PasswordNew)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("password_new");

                entity.Property(e => e.PasswordOld)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("password_old");

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Userpasswords)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("fk1_password");
            });

            modelBuilder.Entity<Usersession>(entity =>
            {
                entity.HasKey(e => e.SessionId)
                    .HasName("PK__USERSESS__23DB12CB532D40A7");

                entity.ToTable("USERSESSION");

                entity.Property(e => e.SessionId).HasColumnName("sessionID");

                entity.Property(e => e.SessionDate)
                    .HasColumnType("datetime")
                    .HasColumnName("session_date");

                entity.Property(e => e.SessionStatus).HasColumnName("session_status");

                entity.Property(e => e.SessionToken)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("session_token");

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Usersessions)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("fk1_session");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public bool Validate(Enduser enduser)
        {
            try
            {
                Database.ExecuteSqlRaw("EXEC dbo.validateUser @Email, @Password",
                new SqlParameter ("@Email", enduser.UserEmail.ToString()),
                new SqlParameter("@Password", enduser.ToString()));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Register(Enduser enduser, Userpassword userpassword, out string response)
        {
            try
            {
                SqlConnection conn = new SqlConnection("COMP2001_DB");
                SqlCommand command = new SqlCommand("returnResponse", conn);
                
                Database.ExecuteSqlRaw("EXEC dbo.registerUser @FirstName, @LastName, @Email, @NewPassword, @ResponseMessage",
                new SqlParameter("@FirstName", enduser.UserFName.ToString()),
                new SqlParameter("@LastName", enduser.UserLName.ToString()),
                new SqlParameter("@Email", enduser.UserEmail.ToString()),
                new SqlParameter("@Password", userpassword.PasswordNew.ToString()));
                response = (string) command.Parameters["@ResponseMessage"].Value;
                
            }
            catch (Exception)
            {
                response = "SQL Execution failed. User could not be registered.";
            }
        }

        public void Update(Enduser enduser, Userpassword userpassword, int id)
        {
            try
            {
                Database.ExecuteSqlRaw("EXEC dbo.updateUser @FirstName, @LastName, @Email, @Password, @ID ",
                new SqlParameter("@FirstName", enduser.UserFName),
                new SqlParameter("@LastName", enduser.UserLName),
                new SqlParameter("@Email", enduser.UserEmail),
                new SqlParameter("@Password", userpassword.PasswordNew),
                new SqlParameter("@ID", enduser.UserId));
            } 
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(int id)
        {
            try
            {
                Database.ExecuteSqlRaw("EXEC dbo.deleteUser @ID",
                new SqlParameter("@ID", id));
            }
            catch
            {
                throw;
            }
        }
    }
}
