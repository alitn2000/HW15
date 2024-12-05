using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quize2.Entites;

namespace Quize2.InferaStructure;

public class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(k => k.UserName);
        builder.HasData(
            new User {FirstName="ali", LastName="tahmasebinia", NationalId="0023527676", Password = "123", UserName ="alitn" },
            new User {FirstName = "reza", LastName = "rezayi", NationalId = "0023527677", Password = "123", UserName = "reza" },
            new User {FirstName = "mamad", LastName = "mamali", NationalId = "0023527678", Password = "123", UserName = "mamali" }
            );
    }
}
