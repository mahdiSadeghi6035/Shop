using _0_Framework.Domain;
using ShopManagement.Domain.ProductAgg;

namespace ShopManagement.Domain.VideoProductAgg
{
    public class VideoProduct : DomainBase<long>
    {
        public string Video { get; private set; }
        public string Type { get; private set; }
        public bool IsRemoved { get; private set; }
        public long ProductId { get; private set; }
        public Product Products{ get; private set; }
        public VideoProduct(string video, string type, long productId)
        {
            Video = video;
            Type = type;
            IsRemoved = false;
            ProductId = productId;
        }
        public void Edit(string video, string type, long productId)
        {
            if(!string.IsNullOrWhiteSpace(video))
                Video = video;
            Type = type;
            ProductId = productId;
        }
        public void Remove()
        {
            IsRemoved = true;
        }
        public void Restore()
        {
            IsRemoved = false;
        }
    }
}
