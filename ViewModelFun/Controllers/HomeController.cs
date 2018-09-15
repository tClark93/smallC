using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ViewModelFun.Models;

namespace ViewModelFun.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            Message words = new Message()
            {
                Text = "Suspendisse nisl turpis, hendrerit et mauris et, euismod rutrum libero. Aenean ac euismod velit, at pharetra justo. Aenean eget odio dolor. Nullam eu maximus lacus. Ut at neque nunc. Nullam efficitur sapien et consequat pretium. Vestibulum sagittis iaculis gravida. Donec pulvinar justo lectus, at ultrices purus dapibus laoreet. Ut commodo vestibulum sem sed auctor. Quisque suscipit at velit vitae euismod. Curabitur pellentesque tempus nulla ut pretium. Nunc scelerisque tempor lorem ac lacinia. Nunc blandit fringilla arcu. Pellentesque elementum velit accumsan ex faucibus auctor. Aliquam pellentesque pellentesque lacus, eleifend volutpat erat consectetur in. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Donec a interdum sem. Cras convallis, elit ac aliquet varius, leo lectus ornare massa, nec tincidunt velit nisl vel felis. Nullam vel augue finibus, tincidunt arcu nec, viverra odio. Pellentesque id lorem aliquet, ultricies erat ut, vehicula augue. Sed a suscipit dolor. Nullam porttitor, lectus vel rhoncus imperdiet, massa nulla ullamcorper nisl, in auctor nisi ipsum ullamcorper neque. Nunc finibus nisi non libero congue vulputate. Proin sodales risus massa, in vestibulum enim iaculis ut. Pellentesque consequat felis nisl, eu condimentum mauris sodales vel. Curabitur a mauris sodales, iaculis tortor sit amet, efficitur tellus. Proin viverra est magna, lacinia pretium mi consectetur et. Sed varius nisi non pharetra convallis."
            };
            return View(words);
        }

        [HttpGet]
        [Route("numbers")]
        public IActionResult Numbers()
        {
            Number nums = new Number{
                Num = new int[] {4,2,8,9,3,1,5,7,3}
            };
            return View(nums);
        }

        [HttpGet]
        [Route("user")]
        public IActionResult User()
        {
            User user = new User
            {
                names = new string[] {"Jesse", "James", "Ash", "Pikachu", "Squirtle", "Ash"}
            };
            return View(user);
        }
        [HttpGet]
        [Route("users")]
        public IActionResult Users()
        {
            User user = new User
            {
                names = new string[] {"Jesse", "James", "Ash", "Pikachu", "Squirtle", "Ash"}
            };
            return View(user);
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
