using _0_Framework.Domain;
using ArticleManagement.Domain.ArticleAgg;
using System.Collections.Generic;

namespace ArticleManagement.Domain.ArticleCategoryAgg
{
    public class ArticleCategory : DomainBase<long>
    {
        public string Name { get; private set; }
        public string Slug { get; private set; }
        public string KeyWords { get; private set; }
        public string MetaDescription { get; private set; }
        public string CanonicalAddress { get; private set; }
        public List<Article> Articles{ get; private set; }

        public ArticleCategory(string name, string slug, string keyWords, string metaDescription, string canonicalAddress)
        {
            Name = name;
            Slug = slug;
            KeyWords = keyWords;
            MetaDescription = metaDescription;
            CanonicalAddress = canonicalAddress;
            Articles = new List<Article>();
        }
        public void Edit(string name, string slug, string keyWords, string metaDescription, string canonicalAddress)
        {
            Name = name;
            Slug = slug;
            KeyWords = keyWords;
            MetaDescription = metaDescription;
            CanonicalAddress = canonicalAddress;
        }
    }
}
