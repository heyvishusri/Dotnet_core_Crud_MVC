using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppDotNetCoreCrudNew.Models;

namespace WebAppDotNetCoreCrudNew.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentContext _Db;
        public StudentController(StudentContext Db)
        {
            _Db = Db;
        }

        public IActionResult StudentList()
        {
            try
            {
                var stdList = (from a in _Db.Student
                               join b in _Db.Department
                               on a.DepID equals b.ID into Dep
                               from b in Dep.DefaultIfEmpty()
                               select new Student
                               {
                                   ID = a.ID,
                                   Name = a.Name,
                                   Fname = a.Fname,
                                   Mobile = a.Mobile,
                                   Email = a.Email,
                                   Description = a.Description,
                                   DepID = a.DepID,
                                   DeptName = b != null ? b.DeptName.ToString() : ""
                               }).ToList();
                return View(stdList);
            }
            catch (Exception)
            {
                return View();
            }
        }

        public IActionResult Create(Student obj)
        {
            LoadDDL();
            return View(obj);
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent(Student obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (obj.ID == 0)
                    {
                        _Db.Student.Add(obj);
                        await _Db.SaveChangesAsync();
                    }
                    else
                    {
                        _Db.Entry(obj).State = EntityState.Modified;
                        await _Db.SaveChangesAsync();
                    }

                    return RedirectToAction("StudentList");
                }

                return View(obj);
            }
            catch (Exception ex)
            {

                return RedirectToAction("StudentList");
            }
        }

        private void LoadDDL()
        {
            try
            {
                var depList = _Db.Department.ToList();
                depList.Insert(0, new Departments { ID = 0, DeptName = "Please Select" });
                ViewBag.DepList = depList;
            }
            catch (Exception)
            {
                ViewBag.DepList = null;
            }
        }
    }
}