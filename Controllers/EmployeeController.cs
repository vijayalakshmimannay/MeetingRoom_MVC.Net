using MeetingRoom1.Models;
using MeetingRoom1.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace MeetingRoom1.Controllers
{
    public class EmployeeController : Controller
    {

        IEmployeeRL employeeRL;
        public EmployeeController(IEmployeeRL employeeRL)
        {
            this.employeeRL = employeeRL;
        }
        public int MeetingRoom_Id;
        public int UserId;

        [HttpGet]
        public IActionResult ListOfEmployee(int Id)
        {
            //List<MeetingRoomModel> meetingroomlist = new List<MeetingRoomModel>();
            
            MeetingRoom_Id = Id;
           var meetingroomlist = employeeRL.GetAllMeetingRooms();

            return View(meetingroomlist);
        }

        [HttpGet]
        public IActionResult AddEmp()
        {
            
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddEmp([Bind] EmployeeModel employee)
        {
            if (ModelState.IsValid)
            {
                employeeRL.AddEmployee(employee);
                //return RedirectToAction("Employee/Login");
            }
            return View(employee);
        }
    
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "Admin,Employee")]
        public IActionResult Login([Bind] LoginModel loginModel)
        {
            string message = string.Empty;
            if (ModelState.IsValid)
            {
                var result = employeeRL.UserLogin(loginModel);
              
                if (result != null)
                {
                    message = "Username and/or password is correct.";
                    Console.WriteLine(message);
                    return RedirectToAction("ListOfEmployee");

                }
                else
                {
                    return RedirectToAction("Login");
                }

                
            }
            return null; 
        }

        [HttpGet]
        public IActionResult AddRequest()
        {

         

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddRequest([Bind] RequestModel employee)
        {
            
            if (ModelState.IsValid)
            {
                //int UserId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "EmployeeId").Value);

                //var EmailId = User.FindFirst(ClaimTypes.Email).Value.ToString();
                  
                var EmployeeId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

                var identity = HttpContext.User.Identity as ClaimsIdentity;
                if (identity != null)
                {
                   // IEnumerable<Claim> claims = identity.Claims;
                    // or
                    //identity = FindFirst("EmployeeId").Value;
                   UserId = Convert.ToInt32(identity.FindFirst("EmployeeId").Value);


                }
                employeeRL.AddRequest(employee, UserId, MeetingRoom_Id);


                //return RedirectToAction("Employee/Login");
            }
            return View(employee);
        }





    }
}
