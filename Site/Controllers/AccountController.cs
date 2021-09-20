using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Site.Entity;
using Site.Identity;
using Site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Site.Controllers
{
    public class AccountController : Controller
    {
        DataContext db = new DataContext();
       
        private UserManager<ApplicationUser> UserManager;
        private RoleManager<ApplicationRole> RoleManager;
        public AccountController()
        {
            
            var userStore = new UserStore<ApplicationUser>(new IdentityDataContext());
            UserManager = new UserManager<ApplicationUser>(userStore);

            var roleStore = new RoleStore<ApplicationRole>(new IdentityDataContext());
            RoleManager = new RoleManager<ApplicationRole>(roleStore);
        }
        // GET: Account

        public ActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        [Authorize]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {

            var id = HttpContext.GetOwinContext().Authentication.User.Identity.GetUserId();
            var user = UserManager.FindById(id);
            if (user.UserName!=model.Username)
            {
                return RedirectToAction("Index", "Home");
            }
           



            if (ModelState.IsValid )
            {
                var result = UserManager.ChangePassword(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);
                return View("Update");
            }






            return View(model);
        }

        private object UserManagerExtensions(string oldPassword)
        {
            throw new NotImplementedException();
        }

        public PartialViewResult UserCount()
        {
            var u = UserManager.Users;
            return PartialView(u);
        }
        public ActionResult UserList()
        {
            var u = UserManager.Users;
            return View(u);
        }











        public ActionResult UserProfil()
        {
            var id = HttpContext.GetOwinContext().Authentication.User.Identity.GetUserId();
            var user = UserManager.FindById(id);
            var data = new UserProfile()
            {
                id = user.Id,
                Name=user.Name,
                Surname=user.Surname,
                Username=user.UserName,
                Uyelik=user.PhoneNumber,
                Email=user.Email

            };
            return View(data);
        }
        [HttpPost]
        public ActionResult UserProfil(UserProfile model)
        {
            var user = UserManager.FindById(model.id);
            user.Name = model.Name;
            user.Surname = model.Surname;
            user.UserName = model.Username;
            user.Email = model.Email;
            user.PhoneNumber = model.Uyelik;
            UserManager.Update(user);
            return View("Update");

        }
        public ActionResult LogOut()
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Login model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = UserManager.Find(model.Username, model.Password);
                if (user != null)
                {
                    var authManager = HttpContext.GetOwinContext().Authentication;
                    var IdentityClaims = UserManager.CreateIdentity(user, "ApplicationCookie");
                    var authProperties = new AuthenticationProperties();
                    authProperties.IsPersistent = model.RememberMe;
                    authManager.SignIn(authProperties, IdentityClaims);
                    if (!String.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    
                }
            }
            return View(model);
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Register model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser();
                user.Name = model.Name;
                user.UserName = model.Username;
                user.Surname = model.Surname;
                user.Email = model.Email;
                user.PhoneNumber = model.Uyelik;
                var result = UserManager.Create(user, model.Password);
                if (result.Succeeded)
                {
                    if (RoleManager.RoleExists("user"))
                    {
                        UserManager.AddToRole(user.Id, "user");
                    }
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    ModelState.AddModelError("RegisterUserError", "Kayıt Olunamadı");
                }
            }
            return View(model);
        }




           



        public ActionResult Index()
        {

            var username = User.Identity.Name;
            var order = db.Orders.Where(i => i.UserName == username).Select(i => new UserOrder
            {
                Id = i.Id,
                OrderNumber = i.OrderNumber,
                OrderState = i.OrderState,
                OrderDate = i.OrderDate,
                Total = i.Total

            }).OrderByDescending(i => i.OrderDate).ToList();
            return View(order);
        }
        public ActionResult Index1()
        {

            var username = User.Identity.Name;
            var order1 = db.Order1s.Where(i => i.UserName == username).Select(i => new UserKiralama
            {
                Id = i.Id,
                OrderNumber = i.OrderNumber,
                OrderState = i.OrderState,
                OrderDate = i.OrderDate,
                Total = i.Total

            }).OrderByDescending(i => i.OrderDate).ToList();
            return View(order1);
        }
        public ActionResult Details(int id)
        {
            var model = db.Orders.Where(i => i.Id == id).Select(i => new OrderDetails()
            {

                OrderId = i.Id,
                OrderNumber = i.OrderNumber,
                Total = i.Total,
                OrderDate = i.OrderDate,
                OrderState = i.OrderState,
                Sehir = i.Sehir,
                Adres = i.Adres,
                Semt = i.Semt,
                Mahalle = i.Mahalle,
                PostaKodu = i.PostaKodu,
                OrderLines = i.OrderLines.Select(x => new OrderLineModel()
                {
                    ProductId = x.ProductId,
                    RESIM = x.Product.RESIM,
                    ProductName = x.Product.OAD,
                    Quantity = x.Quantity,
                    FIYAT = x.Product.FIYAT,
                }).ToList()



            }).FirstOrDefault();
            return View(model);
        }



        public ActionResult Details1(int id)
        {
            var model = db.Order1s.Where(i => i.Id == id).Select(i => new OrderDetails1()
            {

                OrderId = i.Id,
                OrderNumber = i.OrderNumber,
                Total = i.Total,
                OrderDate = i.OrderDate,
                OrderState = i.OrderState,
                Sehir = i.Sehir,
                Adres = i.Adres,
                Semt = i.Semt,
                Mahalle = i.Mahalle,
                PostaKodu = i.PostaKodu,
                OrderLines1 = i.OrderLines1.Select(x => new OrderLineModel1()
                {
                    ProductId = x.ProductId,
                    RESIM = x.Product.RESIM,
                    ProductName = x.Product.OAD,
                    Quantity = x.Quantity,
                    FIYAT = x.Product.FIYAT,
                }).ToList()



            }).FirstOrDefault();
            return View(model);
        }
       
        [HttpGet]
        public ActionResult Reset()
        {
            return View();

        }

       
       /*  public ActionResult Reset(Reset model)
        {
          
            

            var id = HttpContext.GetOwinContext().Authentication.User.Identity.GetUserId();
            var user = UserManager.FindById(id);
            if (user.Email==model.Mail && model.Mail!=null)
            {


                Guid rastgele = Guid.NewGuid();
                user.p = rastgele.ToString().Substring(0, 8);

              
              
                db.SaveChanges();

                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("akkayaoto2924@gmail.com","Şifre Sıfırlama");
                mail.To.Add(user.Email);
                mail.IsBodyHtml = true;
                mail.Subject = "Şifre Değiştirme İsteği";
                mail.Body += "MErhaba Şifreniz" + user.Surname;
                NetworkCredential net = new NetworkCredential("akkayaoto2924@gmail.com", "147896325m");
                client.Credentials = net;
                client.Send(mail);
                return RedirectToAction("Index");




            }
           
                return RedirectToAction("Register");
            
           
                
           
        }*/





















    }

}