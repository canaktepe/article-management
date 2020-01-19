using CoreNative.Base.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreNative.ArticleManagement.Entities.Concrete
{
    public class ArticleComment : IEntity
    {
        public int ArticleCommentId { get; set; }
        public int ArticleId { get; set; }
        public string AuthorFullName { get; set; }
        public string AuthorEmail { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsApproved { get; set; }
    }
}
