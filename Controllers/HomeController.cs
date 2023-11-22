using EF_CodeFirstApproach.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EF_CodeFirstApproach.Models;
using System.Data.Entity;

namespace EF_CodeFirstApproach.Controllers
{
    public class HomeController : Controller
    {
        StudentContext db = new StudentContext();
        // GET: Home
        public ActionResult Index()
        {
            var data = db.Stu.ToList();
            return View(data);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student s)     // jun data aaye ni s ma catch garney 
        {
            //if error or empty , returns false
            if(ModelState.IsValid == true)
            {
                db.Stu.Add(s);      //list ma jj cha tes ma ajhai kura add gareko , whatever comes from s
                int catching = db.SaveChanges();
                if (catching > 0)                //if something new is stored then giving alert
                {
                    //    ViewBag.InsertMessage = "<script>alert('Data Inserted')</script>";
                    //     ModelState.Clear();        //to clear feilds after inserting datas that are stored


                    TempData["InsertMessage"] = "<script>alert('Data Inserted')</script>";
                    return RedirectToAction("Index");


                
                }
                else
                {
                    ViewBag.InsertMessage = "<script>alert('Data Not Inserted')</script>";
                }
                
            }
            return View();
        }

        // for update 

        public ActionResult Edit(int Id)
        {
            var row = db.Stu.Where(model => model.id == Id).FirstOrDefault();
            return View(row);
        }

        [HttpPost]
        public ActionResult Edit(Student s)
        {
            if(ModelState.IsValid == true)
            {
                db.Entry(s).State = EntityState.Modified;        // to change or edit
                int a = db.SaveChanges();
                if (a > 0)
                {
                    // ViewBag.UpdateMessage = "<script>alert('Data Updated')</script>";
                    //ModelState.Clear();

                    TempData["UpdatedMessage"] = "<script>alert('Data Updated')</script>";
                    return RedirectToAction("Index");

                }
                else
                {
                    ViewBag.UpdateMessage = "<script>alert('Data Not Updated')</script>";
                }
            }
            
            return View();
        }

        //for delete 
        public ActionResult Delete(int Id)
        {
            var StudentIdRow = db.Stu.Where(model => model.id == Id).FirstOrDefault();
            return View(StudentIdRow);
        }

        [HttpPost]
        public ActionResult Delete(Student s)
        {
            if (ModelState.IsValid == true)
            {
                db.Entry(s).State = EntityState.Deleted;
                int a = db.SaveChanges();
                if (a > 0)
                {
                    TempData["DeleteMessage"] = "<script>alert('Data Deleted')</script>";
                }
                else
                {
                    TempData["DeleteMessage"] = "<script>alert('Data Not Deleted')</script>";
                }
                return RedirectToAction("Index");

            }
            return View();
        }

        //showing the details - id by pressing it 

        public ActionResult Details(int Id)
        {
            var DetailsById = db.Stu.Where(model => model.id == Id).FirstOrDefault();
            return View(DetailsById);


        }
    }
}