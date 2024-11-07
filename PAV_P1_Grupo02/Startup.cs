using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PAV_P1_Grupo02.Models;
using WebGrease.Css;

[assembly: OwinStartupAttribute(typeof(PAV_P1_Grupo02.Startup))]
namespace PAV_P1_Grupo02
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRolesAndUsers();
        }

        public void CreateRolesAndUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                var user = new ApplicationUser();
                user.UserName = "admin";
                user.Email = "admin@admin.com";

                string userPWD = "DennisVero123";
                var checkUser = userManager.Create(user, userPWD);

                if (checkUser.Succeeded)
                {
                    var resultado = userManager.AddToRole(user.Id, "Admin");
                }
            }

            if (!roleManager.RoleExists("Usuario"))
            {
                var role = new IdentityRole();
                role.Name = "Usuario";
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("Contabilidad"))
            {
                var role = new IdentityRole();
                role.Name = "Contabilidad";
                roleManager.Create(role);
            }
        }
    }
}