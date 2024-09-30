using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LearnIRepository.Models.NorthWind;
using LearnIRepository.Interface;
using System.Linq.Expressions;
using LearnIRepository.Models.NorthWind.ViewModel;

namespace LearnIRepository.Controllers
{
    public class EmployeesController : Controller
    {

        private readonly IRepository<Employee> _repository;

        public EmployeesController(IRepository<Employee> repository)
        {
            _repository = repository;
        }


        // GET: Employees
        public async Task<IActionResult> Index()
        {
            var northWindContext = await _repository.GetAllAsync();
            return View(northWindContext);
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var employee = await _repository.GetSingleByIdAsync(id);

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateEmployee createemployee)
        {
            if (ModelState.IsValid)
            {
                Employee employee = new Employee()
                {
                    FirstName = createemployee.FirstName,
                    LastName = createemployee.LastName,
                    Title = createemployee.Title,
                    BirthDate = createemployee.BirthDate,
                    HireDate = createemployee.HireDate,
                    Address = createemployee.Address,
                    City = createemployee.City,
                    Region = createemployee.Region,
                    PostalCode = createemployee.PostalCode,
                    Country = createemployee.Country,
                    HomePhone = createemployee.HomePhone,
                    Extension = createemployee.Extension,
                    Phone = createemployee.Phone
                };
                await _repository.CreateAsync(employee);

                return RedirectToAction("Index");
            }

            return View(createemployee);
        }

        // GET: Employees/Edit/5
        public IActionResult Edit(int id)
        {
            var employee = _repository.GetSingleByIdAsync(id).Result;
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Employee employee)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    await _repository.UpdateAsync(employee);
                    await _repository.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.EmployeeId))
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
            return View(employee);
        }

        // GET: Employees/Delete/5
        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var employee = _repository.GetSingleByIdAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = _repository.GetSingleByIdAsync(id);

            if (employee != null)
            {
                await _repository.DeleteAsync(id);
            }

            await _repository.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool EmployeeExists(int id)
        {
            Expression<Func<Employee, bool>> predicate = s => s.EmployeeId == id;

            if (predicate == null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }


    }
}
