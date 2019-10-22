using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using shared_classes.Models;

namespace shared_classes.Data
{
    public class CommentRepository : EntityBaseRepository<CommentModel>, ICommentRepository
    {
        public CommentRepository(BlogDbContext context) : base(context) { }
    }
}