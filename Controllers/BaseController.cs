using Microsoft.AspNetCore.Mvc;
using school.Models;

namespace school.Controllers;

public class BaseController : Controller
{
        public EscuelaContext? _context;
        
}