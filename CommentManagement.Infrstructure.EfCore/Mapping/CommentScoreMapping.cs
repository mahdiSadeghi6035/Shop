using CommentManagement.Domain.CommentScoreAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CommentManagement.Infrstructure.EfCore.Mapping
{
    public class CommentScoreMapping : IEntityTypeConfiguration<CommentScore>
    {
        public void Configure(EntityTypeBuilder<CommentScore> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("CommentScore");
            builder.OwnsMany(x => x.CommentScoreOptions, navigation =>
            {
                navigation.ToTable("CommentScoreOption");
                navigation.HasKey(x => x.Id);
                navigation.WithOwner(x => x.CommentScores).HasForeignKey(x => x.CommentScoreId);
            });
        }
    }
}
