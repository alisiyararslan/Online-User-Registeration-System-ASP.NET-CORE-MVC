using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PeopleRegistrationSystem.Models;
using PeopleRegistrationSystem.ViewModels;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace PeopleRegistrationSystem.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IHttpContextAccessor contxt;

        private AppDbContext _context;

        private readonly IMapper _mapper;

        public DashboardController(AppDbContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;

            _mapper = mapper;

            contxt = httpContextAccessor;
        }
        public IActionResult Index()
        {

            var scholarships = _context.Users.ToList();

            return View(_mapper.Map<List<UserViewModel>>(scholarships));
            
        }

        public IActionResult removeUser(int id)
        {
            var scholarship = _context.Users.Find(id);

            _context.Users.Remove(scholarship);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult updateUser(int id)
        {
            var scholarship = _context.Users.Find(id);

            ViewBag.EducationLevelSelect = new SelectList(new List<EducationLevelSelectList>()
            {
                new(){Data="Primary Education", Value="Primary Education"},
                new(){Data="Secondary Education", Value="Secondary Education"},
                new(){Data="High School", Value="High School"},
                new(){Data="Bachelor's Degree", Value="Bachelor's Degree"},
                new(){Data="Master Degree", Value="Master Degree"},
                new(){Data="PhD", Value="PhD"},


            }, "Value", "Data");//view Data to user
            return View(_mapper.Map<UserViewModel>(scholarship));
        }

        [HttpPost]
        public IActionResult updateUser(UserViewModel updateScholarship)
        {
            IActionResult result = null;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Users.Update(_mapper.Map<User>(updateScholarship));

                    _context.SaveChanges();

                    TempData["status"] = "User successfully updated.";

                    return RedirectToAction("Index");
                }
                catch (Exception)
                {

                    result = View();
                }

            }
            else
            {
                result = View();

            }

            ViewBag.EducationLevelSelect = new SelectList(new List<EducationLevelSelectList>()
                {
                    new(){Data="Primary Education", Value="Primary Education"},
                    new(){Data="Secondary Education", Value="Secondary Education"},
                    new(){Data="High School", Value="High School"},
                    new(){Data="Bachelor's Degree", Value="Bachelor's Degree"},
                    new(){Data="Master Degree", Value="Master Degree"},
                    new(){Data="PhD", Value="PhD"},


                }, "Value", "Data");//view Data to user

            return result;
        }
    }
}
