using CourseWorkProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseWorkProject.ViewModels
{
    public class ChatUser
    {
        public List<User> FriendList { get; set; }
        public User CurrentUser { get; set; }
    }
}