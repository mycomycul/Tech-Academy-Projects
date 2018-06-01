        namespace Project.Controllers
{
    public class CommentController : Controller
    {
        //Save the updated comment after being changed
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Content,DatePosted,PostID,User_UserID")] Comment comment)
        {

            if (ModelState.IsValid)
            {
                db.Entry(comment).State = EntityState.Modified;
                db.SaveChanges();
                return new EmptyResult();
            {
            return new EmptyResult();
        }
    
        //Return a partial view for editing a current element
            public ActionResult RenderEdit(int? id)
        {
            var cmt = db.Comments.Find(id);
            CommentsViewModel comment = new CommentsViewModel()
            {
                Content = cmt.Content,
                DatePosted = cmt.DatePosted,
                PostID = cmt.PostID,
                User_UserID = cmt.User.ToString()
            };
            return PartialView("_EditComment", comment);
        }
    }
}