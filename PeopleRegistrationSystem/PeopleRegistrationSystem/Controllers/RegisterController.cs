using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using PeopleRegistrationSystem.Models;
using PeopleRegistrationSystem.ViewModels;

namespace PeopleRegistrationSystem.Controllers
{
    public class RegisterController : Controller
    {
        private AppDbContext _context;

        private readonly IMapper _mapper;

        public RegisterController(AppDbContext context, IMapper mapper)
        {
            _context = context;

            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]//Default
        public IActionResult userRegister()
        {
            // Create a select list for education levels
            ViewBag.EducationLevelSelectUser = new SelectList(new List<EducationLevelSelectList>()
            {
                new(){Data="Primary Education", Value="Primary Education"},
                new(){Data="Secondary Education", Value="Secondary Education"},
                new(){Data="High School", Value="High School"},
                new(){Data="Bachelor's Degree", Value="Bachelor's Degree"},
                new(){Data="Master Degree", Value="Master Degree"},
                new(){Data="PhD", Value="PhD"},



            }, "Value", "Data");//view Data to who make registeration

            return View();
        }

        [HttpPost]
        public IActionResult userRegister(UserViewModel newUser)
        {
            IActionResult result = null;
            // Create a select list for education levels
            ViewBag.EducationLevelSelectUser = new SelectList(new List<EducationLevelSelectList>()
                {
                    new(){Data="Primary Education", Value="Primary Education"},
                    new(){Data="Secondary Education", Value="Secondary Education"},
                    new(){Data="High School", Value="High School"},
                    new(){Data="Bachelor's Degree", Value="Bachelor's Degree"},
                    new(){Data="Master Degree", Value="Master Degree"},
                    new(){Data="PhD", Value="PhD"},

                }, "Value", "Data");//view Data to who make registiration

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Users.Add(_mapper.Map<User>(newUser));

                    _context.SaveChanges();

                    TempData["status"] = "User successfully registered.";

                    return RedirectToAction("Index", "Home");
                }
                catch (Exception ex)
                {
                    // Check if the exception is due to a unique key violation (duplicate email & identification num.)
                    if (ex.InnerException is SqlException sqlException )
                    {
                        if (sqlException.Message.Contains("Cannot insert duplicate key row") &&
        sqlException.Message.Contains("IX_User_Email"))
                        {
                            TempData["status"] = "Email is already registered.";
                        }
                        else if(sqlException.Message.Contains("Cannot insert duplicate key row") &&
        sqlException.Message.Contains("IX_User_Identification"))
                        {
                            TempData["status"] = "Idetification number is already registered.";
                        }
                        
                    }
                    else
                    {
                        // Handle other exceptions
                        TempData["status"] = "An error occurred while registering the user.";
                    }
                    return View();
                }
            }
            else
            {
                result = View();
            }
            return result;
        }

    }
}
