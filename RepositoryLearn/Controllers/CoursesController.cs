using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RepositoryLearn.Models;
using RepositoryLearn.Services;

namespace RepositoryLearn.Controllers
{
    public class CoursesController : Controller
    {
        //private readonly ContosoUniversityContext _context;
        private readonly ICourseServices _courseServices;


        public CoursesController(ICourseServices courseServices)
        {
            _courseServices = courseServices;
        }

        // GET: Courses
        public async Task<IActionResult> Index()
        {
            return View(await _courseServices.GetAllCoursesAsync());
        }

        // GET: Courses/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var course = await _courseServices.GetCoursesByIdAsync(id);

            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // GET: Courses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Course course)
        {
            if (ModelState.IsValid)
            {
                await _courseServices.AddCoursesAsync(course);
                await _courseServices.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        // GET: Courses/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var course = await _courseServices.GetCoursesByIdAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Course course)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var selectCourse = await _courseServices.GetCoursesByIdAsync(course.CourseId);

                    if (selectCourse == null)
                    {
                        return NotFound();

                    }
                    await _courseServices.UpdateCoursesAsync(course);
                    await _courseServices.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseExists(course.CourseId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        // GET: Courses/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var course = await _courseServices.GetCoursesByIdAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            else
            {
                await _courseServices.DeleteProductAsync(id);
                return View(course);
            }
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (CourseExists(id))
            {
                return NotFound();
            }
            else
            {
                await _courseServices.DeleteProductAsync(id);
                await _courseServices.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
        }

        private bool CourseExists(int id)
        {
            var course = _courseServices.GetCoursesByIdAsync(id);

            if (course == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
