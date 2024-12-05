using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quize2.Entites;

namespace Quize2.InferaStructure;

public class CardConfig : IEntityTypeConfiguration<Card>
{
    public void Configure(EntityTypeBuilder<Card> builder)
    {
        builder.HasKey(c => c.CardNumber);
        builder.HasOne(u => u.User).WithMany(c => c.Cards).HasForeignKey(u => u.HolderName).OnDelete(DeleteBehavior.Restrict);


        builder.HasData(
            new Card {CardNumber = "5892101407708383", Password="123", Balance=500000, DailyTransferAmount=0, HolderName="alitn", IsActive =true},
            new Card {CardNumber = "5892101407708384", Password = "123", Balance = 500000, DailyTransferAmount = 0, HolderName = "reza", IsActive = true },
            new Card {CardNumber = "5892101407708385", Password = "123", Balance = 500000, DailyTransferAmount = 0, HolderName = "mamali", IsActive = true }
            );
    }
}
