using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeFirstOne.Models;
using CodeFirstOne.ViewModels;

namespace CodeFirstOne.Controllers
{
    public class HomeController : Controller
    {
        private Repo_Student repo = new Repo_Student();
        private Manager man = new Manager();
        //
        // GET: /VM/
        public ActionResult Index()
        {
            return View(repo.getStudentNames());
        }

        public ActionResult List()
        {
            return View(repo.getStudentsFull());
        }

        public ActionResult Create()
        {
            ViewBag.ddl = man.getSelectList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(StudentFull st, FormCollection form)
        {
            if (ModelState.IsValid)
            {
                //form[5] is the collection of selected values in the listbox
                if (form.Count == 6)
                {
                    repo.createStudent(st, form[5]); 
                }
                else
                {
                    repo.createStudent(st);
                }


                return RedirectToAction("Index");
            }
            else
            {
                return View("Error");
            }
        }

        public ActionResult Details(int? id)
        {
            return View(repo.getStudentPublic(id));
        }

        public ActionResult Error()
        {
            return View();
        }
    }

}