using CoreNative.Base.Entites;
using System;

namespace CoreNative.ArticleManagement.Entities.Concrete
{
    public class Article : IEntity
    {
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Content { get; set; }
        public string Thumbnail { get; set; }
        public string Author { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Status { get; set; }
    }
}
