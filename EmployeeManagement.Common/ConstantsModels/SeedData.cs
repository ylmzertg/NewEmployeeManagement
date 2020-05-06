using EmployeeManagement.Data.DbModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Common.ConstantsModels
{
    public static class SeedData
    {
        public static void Seed(UserManager<Employee> userManager, RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }

        private static void SeedUsers(UserManager<Employee> userManager)
        {
            if (userManager.FindByNameAsync(ResultConstant.Admin_Email).Result == null)
            {
                var user = new Employee
                {
                    UserName = ResultConstant.Admin_Email,
                    Email = ResultConstant.Admin_Email
                };
                var result = userManager.CreateAsync(user, ResultConstant.Admin_Password).Result;
                if (result.Succeeded)
                    userManager.AddToRoleAsync(user, ResultConstant.Admin_Role);
            }
        }


        private static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync(ResultConstant.Admin_Role).Result)
            {
                var role = new IdentityRole
                {
                    Name = ResultConstant.Admin_Role
                };
                var result = roleManager.CreateAsync(role).Result;
            }
            if (!roleManager.RoleExistsAsync(ResultConstant.Employee_Role).Result)
            {
                var role = new IdentityRole
                {
                    Name = ResultConstant.Employee_Role
                };
                var result = roleManager.CreateAsync(role).Result;
            }
        }
    }
}
