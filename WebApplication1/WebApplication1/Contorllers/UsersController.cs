using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UsersController : ControllerBase
  {

    private UserManager<ApplicationUser> userManager;

    public UsersController(UserManager<ApplicationUser> manager)
    {

      userManager = manager;
    }

    // ROUTES

    [HttpPost("Register")]
    public async Task<ActionResult<ApplicationUser>> Register(ApplicationUser data)
    {
      // Note: data (RegisterUser) comes from an inbound DTO/Model created for this purpose
      // this.ModelState?  This comes from MVC Binding and shares an interface with the Model
      //var user = await userService.Register(data, this.ModelState);
      var user = new ApplicationUser
      {
        UserName = data.UserName,
        Email = data.Email,
        PhoneNumber = data.PhoneNumber
      };

      var result = await userManager.CreateAsync(user, data.Password);

      if (result.Succeeded)
      {
        return new ApplicationUser
        {
          Id = user.Id,
          UserName = user.UserName
        };
      }

      // What about our errors?
      foreach (var error in result.Errors)
      {
        var errorKey =
            error.Code.Contains("Password") ? nameof(data.Password) :
            error.Code.Contains("Email") ? nameof(data.Email) :
            error.Code.Contains("UserName") ? nameof(data.UserName) :
            "";
        ModelState.AddModelError(errorKey, error.Description);
      }

      

      if (ModelState.IsValid)
      {
        return user;
      }

      return BadRequest(new ValidationProblemDetails(ModelState));
    }

    [HttpPost("Login")]
    public async Task<ActionResult<ApplicationUser>> Login(ApplicationUser data)
    {
      
      var user = await userManager.FindByNameAsync(data.UserName);

      if (await userManager.CheckPasswordAsync(user, data.Password))
      {

        return new ApplicationUser()
        {
          Id = user.Id,
          UserName = user.UserName,
        };
      }
      if (user == null)
      {
        return Unauthorized();
      }

      return user;
    }

  }
}
