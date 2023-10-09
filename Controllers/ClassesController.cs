using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PFSSITEWITHOUTENTITY.Models;
using PFSSITEWITHOUTENTITY.ViewModel;

namespace PFSSITEWITHOUTENTITY.Controllers
{
    public class ClassesController : Controller
    {
        private readonly ClassDataAccess _classdataAccess;

        public ClassesController(ClassDataAccess dataAccess)
        {
            _classdataAccess = dataAccess;
        }

        // GET: Classes
        public async Task<IActionResult> Index()
        {
            var classList = _classdataAccess.GetAllClasses();
            return View(classList);
        }

        public async Task<PartialViewResult> Details(int? id)
        {
            var @class = _classdataAccess.GetClass(id);
            return PartialView("Details", @class);
        }

        public PartialViewResult Create()
        {
            ViewBag.SessionId = new SelectList(_classdataAccess.GetSessions(), "SessionId", "SessionName").ToList();
            return PartialView("Create");
        }

        // POST: Classes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClassVM @class)
        {
            if (ModelState.IsValid)
            {
                var classModel = new Class();
                classModel.ClassName = @class.ClassName;
                classModel.SessionId = @class.SessionId;
                classModel.Description = @class.Description;

                _classdataAccess.CreateClass(classModel);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.SessionId = new SelectList(_classdataAccess.GetSessions(), "SessionId", "SessionName").ToList();
            return View(@class);
        }

        // GET: Classes/Edit/5
        public async Task<PartialViewResult> Edit(int? id)
        {
            var @class = _classdataAccess.GetClass(id);
            var classModel = new ClassVM();
            classModel.ClassId = @class.ClassId;
            classModel.SessionId = @class.SessionId;
            classModel.ClassName = @class.ClassName;
            classModel.Description = @class.Description;
            ViewBag.SessionId = new SelectList(_classdataAccess.GetSessions(), "SessionId", "SessionName", @class.SessionId).ToList();
            return PartialView("Edit", classModel);
        }

        // POST: Classes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ClassVM @class)
        {
            var classModel = _classdataAccess.GetClass(@class.ClassId);
            if (classModel == null)
            {
                ViewBag.SessionId = new SelectList(_classdataAccess.GetSessions(), "SessionId", "SessionName", @class.SessionId).ToList();
                return View(@class);
            }

            try
            {
                classModel.SessionId = @class.SessionId;
                classModel.ClassName = @class.ClassName;
                classModel.Description = @class.Description;
                _classdataAccess.UpdateClass(classModel);
            }
            catch (Exception ex)
            {

            }
            return RedirectToAction(nameof(Index));

        }

        // POST: Classes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _classdataAccess.DeleteClass(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
