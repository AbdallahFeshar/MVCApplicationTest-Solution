using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MVCApplicationTest.BLL.Interfaces;
using MVCApplicationTest.DAL.Models;
using MVCApplicationTestPL.ViewModels;
using System;
using System.Collections.Generic;

namespace MVCApplicationTestPL.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;

        public DepartmentController(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        public IActionResult Index(string SearchValue)
        {
            IEnumerable<Department> departments;
            if (string.IsNullOrEmpty(SearchValue))
                departments = _departmentRepository.GetAll();
            else
                departments = _departmentRepository.GetDepartmentByName(SearchValue);
            
            var departmentsVM = _mapper.Map<IEnumerable<Department>,IEnumerable<DepartmentViewModel>>(departments);
            return View(departmentsVM);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DepartmentViewModel departmentVM)
        {
            if (ModelState.IsValid)
            {
                /// Manual Mapping 
                ///Department mappedDepartment = new Department()
                ///{
                ///    Id = department.Id,
                ///    Name = department.Name,
                ///    Code = department.Code,
                ///    DateOfCreation = department.DateOfCreation,
                ///    Employees = department.Employees,
                ///};
                ///

                Department mappedDepartment = _mapper.
                    Map<DepartmentViewModel, Department>(departmentVM);
               
                int insertedRowCount = _departmentRepository.Add(mappedDepartment);
                if (insertedRowCount > 0)
                    TempData["Message"] = "Department Created Successfully!!";
                return RedirectToAction(nameof(Index));
            }
            return View(departmentVM);
        }

        public IActionResult Details(int? id, string viewName = "Details")
        {
            if (id is null)
                return BadRequest();
            var department = _departmentRepository.Get(id.Value);

            if(department is null)
                return NotFound();
            var departmentVM = _mapper.Map<Department,DepartmentViewModel>(department);
            return View(viewName,departmentVM);
        }

        public IActionResult Edit(int?id)
        {
            //if(id is null ) return BadRequest();
            //var department = _departmentRepository.Get(id.Value);
            //if(department is null) return NotFound();
            //return View(department);

            return Details(id, "Edit");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Edit([FromRoute]int id, DepartmentViewModel departmentVM)
        {
            if(id != departmentVM.Id)
                return BadRequest();
            if(ModelState.IsValid)
            {
                try
                {
                    Department mappedDepartment = 
                        _mapper.Map<DepartmentViewModel, Department>(departmentVM);
                    _departmentRepository.Update(mappedDepartment);

                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    //restore at log file
                    //Show friendly message
                     ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            return View(departmentVM);
        }

        public IActionResult Delete(int? id)
        {
            //if (id is null) return BadRequest();
            //var department = _departmentRepository.Get(id.Value);
            //if(department is null) return NotFound();
            //return View(department);
            return Details(id, "Delete");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete([FromRoute] int id, DepartmentViewModel departmentVM)
        {
            if(id != departmentVM.Id)
                return BadRequest();
            if(ModelState.IsValid)
            {
                try
                {
                    Department mappedDepartment =
                        _mapper.Map<DepartmentViewModel, Department>(departmentVM);
                    _departmentRepository.Delete(mappedDepartment);
                    return RedirectToAction(nameof(Index));
                }catch(Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            return View(departmentVM);
        }
    }
}
