﻿using AutoMapper;
using EmployeeDeductions.Domain.Interfaces;
using EmployeeDeductions.Domain.Models;
using EmployeeDeductions.Web.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace EmployeeDeductions.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployeeService _employeeService;
        
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        
        public ActionResult Index()
        {
            var employee = _employeeService.GetAll();

            var returnValue = Mapper.Map<List<Employee>, List<EmployeeViewModel>>(employee);
            
            return View(returnValue);
        }                       

        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Create(EmployeeViewModel employee)
        {
            var employeeTranslated = Mapper.Map<EmployeeViewModel, Employee>(employee);

            _employeeService.Create(employeeTranslated);

            return RedirectToAction("Index");
        }
        
        public ActionResult AddDependent(int employeeId)
        {
            return RedirectToAction("Create", "Dependent", new { employeeId = employeeId });
        }

        //[HttpPost]
        //public ActionResult AddDependent(DependentViewModel dependent)
        //{
        //    return View();
        //}

        [HttpGet]
        public JsonResult CalculateBenefitsCost()
        {
            var benefitCost = _employeeService.CalculateBenefitsCost(1);

            //return "here is some calculated data!";

            return Json(benefitCost, JsonRequestBehavior.AllowGet);

            //return Json(benefitCost);
        }
        
    }
} 