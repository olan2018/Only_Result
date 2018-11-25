using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.Models
{
    public partial class UserItem
    {
        public UserItem() {}
        public int? UserItemID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime? Created { get; set; }
    }

    public class UserItemsConfiguration : IEntityTypeConfiguration<UserItem>
    {
        public void Configure(EntityTypeBuilder<UserItem> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(p => p)
        }
    }

    public class Entities
    {
    }
}
