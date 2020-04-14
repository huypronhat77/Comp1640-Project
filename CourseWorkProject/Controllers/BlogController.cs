using CourseWorkProject.DAL;
using CourseWorkProject.Models;
using CourseWorkProject.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CourseWorkProject.Controllers
{
    [Authorize(Roles ="Student, Tutor")]
    public class BlogController : Controller
    {
        private CWContext db = new CWContext();
        // GET: Blog
        public ActionResult Index()
        {
            var currentUser = db.Users.FirstOrDefault(h => h.UserName == HttpContext.User.Identity.Name);
            ViewBag.Empty = "There ar no blogs";
            if (currentUser.Role.id == 2)
            {
                var list = db.Blogs.Where(h => h.Group == currentUser.Group).ToList();
                return View(list);
            }
            var BlogList = db.Blogs.Where(h => h.Group.GroupName == currentUser.GroupMember.Group.GroupName).OrderByDescending(h => h.CreateDate).ToList();
           return View(BlogList);
        }

        public ActionResult CreateBlog()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateBlog(BlogVM model, HttpPostedFileBase File)
        {
            
          
            if (File.ContentLength > 0)
            {
                string _FileName = Path.GetFileName(File.FileName);
                string _Path = Path.Combine(Server.MapPath("~/UploadFiles"), _FileName);
                File.SaveAs(_Path);
                ViewBag.Message = "File Uploaded Successfully!!";
            }
            if (ModelState.IsValid)
            {
                var CurrentUser = db.Users.Where(h => h.UserName == HttpContext.User.Identity.Name).FirstOrDefault();
                if (CurrentUser!=null)
                {
                    model.Creator = CurrentUser.Profile.Name;
                    model.FileName = Path.GetFileName(File.FileName);
                    Blog newBlog = new Blog();
                    newBlog.Content = model.Content;
                    newBlog.CreateDate = model.CreateDate;
                    newBlog.FileName = model.FileName;
                    if (CurrentUser.id == 2)
                    {
                        newBlog.Group = CurrentUser.Group;
                    }
                    else
                    {
                        newBlog.Group = CurrentUser.GroupMember.Group;
                    }                    
                    newBlog.Title = model.Title;
                    newBlog.Creator = model.Creator;
                    db.Blogs.Add(newBlog);
                    db.SaveChanges();
                }

            }
            return RedirectToAction("Index","Blog");
        }

        public PartialViewResult GetComments(int blogid)
        {
            var BlogComments = db.Comments.Where(h => h.Blog.id == blogid).ToList();
            return PartialView("~/Views/Shared/_Comment.cshtml",BlogComments);
        }

        public ActionResult AddComment(CommentVM comment, int blogId)
        {
            var UserComment = new Comment();
            var CurrentUser = db.Users.Where(h => h.UserName == comment.Creator).FirstOrDefault();
            var CurrentBlog = db.Blogs.FirstOrDefault(h => h.id == blogId);
            if (CurrentUser != null)
            {
                comment.Creator = CurrentUser.Profile.Name;
            }
            UserComment.Content = comment.Content;
            UserComment.CreateDate = comment.CreateDate;
            UserComment.User = CurrentUser;
            UserComment.Blog = CurrentBlog;
            db.Comments.Add(UserComment);
            db.SaveChanges();
            return Json(comment, JsonRequestBehavior.AllowGet);
        }
    }
}