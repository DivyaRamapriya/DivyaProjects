using System;
using System.Collections.Generic;
using System.Web.Mvc;
using WebQuiz.Models;
using System.Linq;

namespace WebQuiz.Controllers
{
    public class PartialController : Controller
    {
        List<UserDetails> details = new List<UserDetails>()
            {
               new UserDetails { Name="Divya",Lastname="Ramapriya",Email="DivyaRamapriya16@gmail.com",PhoneNumber="045678901" },
               new UserDetails { Name="Matt",Lastname="M",Email="Matt@gmail.com",PhoneNumber="0459078901" },
               new UserDetails { Name="Vikram",Lastname="S",Email="Vikram@gmail.com",PhoneNumber="045677901" },
               new UserDetails { Name="Josh",Lastname="Raymer",Email="Josh@gmail.com",PhoneNumber="045678901" },
               new UserDetails { Name="Naveen",Lastname="Y",Email="Naveen@gmail.com",PhoneNumber="04564401" },
               new UserDetails { Name="Thomas",Lastname="T",Email="Thomas@gmail.com",PhoneNumber="046578901" },
               new UserDetails { Name="Phebe",Lastname="M",Email="Phebe@gmail.com",PhoneNumber="045689901" },
               new UserDetails { Name="Monica",Lastname="J",Email="Monica@gmail.com",PhoneNumber="045668901" }
            };
        public string Name { get; set; }

        // GET: Partial
        public ActionResult Main()
        {
            return View();
        }

        // GET: Partial
        public ActionResult Default()
        {
            return View();
        }

        // GET: Partial
        public ActionResult Profile()
        {
            return View();
        }

        public ActionResult User(string txtValue, string sortOrder)
        {
         if (!String.IsNullOrEmpty(sortOrder))
            {
                ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
                ViewBag.LastNameSortParm = String.IsNullOrEmpty(sortOrder) ? "lastname_desc" : "";
                ViewBag.EmailSortParm = String.IsNullOrEmpty(sortOrder) ? "email_desc" : "";
                var sort = from m in details
                               select m;
                switch (sortOrder)
                {
                    case "name_desc":
                        sort = sort.OrderByDescending(s => s.Name);
                        break;
                    case "lastname_desc":
                        sort = sort.OrderByDescending(s => s.Lastname);
                        break;
                    case "email_desc":
                        sort = sort.OrderByDescending(s => s.Email);
                        break;
                    default:
                        sort = sort.OrderBy(s => s.Lastname);
                        break;
                }
                return View(sort);
            }
         else if (!String.IsNullOrEmpty(txtValue))
            {
                var Select = from m in details
                         select m;


                Select = Select.Where(s => s.Name.ToLower().Contains(txtValue.ToLower()));
                return View(Select);
            }
            else
            return View(details);
        }

      
    }
}