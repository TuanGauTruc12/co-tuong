using Microsoft.AspNetCore.Mvc;

public class GameController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
