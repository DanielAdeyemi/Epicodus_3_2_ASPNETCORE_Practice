using Microsoft.AspNetCore.Mvc;
using FriendLetter.Models;

namespace FriendLetter.Controllers
{
  public class HomeController: Controller
  {
    [Route("/hello")]
    public string Hello() {return "Hello, friend"; }

    [Route("/goodbye")]
    public string Goodbye() {return "Goodbye friend!"; }

    [Route("/")]
    public ActionResult Letter() 
    { 
      LetterVariable myLetterVariable = new LetterVariable();
      myLetterVariable.Recipient = "Lina";
      return View(myLetterVariable); 
    }
  }
}