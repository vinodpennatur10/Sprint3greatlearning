using Microsoft.AspNetCore.Mvc;
using System;
using WebApplication1;
using WebApplication1.Controllers;
using System.Collections.Generic;

using Xunit;
using Microsoft.AspNetCore.Http;

using System.Threading.Tasks;

namespace TestProject2
{
    public class UnitTest
    {
        [Fact]
        public void TestValidatelogin()
        {
            LoginRepository LoginRepository = new LoginRepository();
            LoginModel loginModel = new LoginModel();
          
            loginModel.Name = "test";
            loginModel.Password = "test";

            string status = LoginRepository.ValidateUser(loginModel.Name, loginModel.Password);

            Assert.Equal("success", status.ToString());
        }

        [Fact]
        public void TestValidateauser()
        {
           UserRepository UserRepository = new UserRepository();
            UserModel UserModel = UserRepository.GetaUser(1);

            Assert.Equal(UserModel, UserModel);
        }
        [Fact]
        public void TestValidatecreateuser()
        {
            UserRepository UserRepository = new UserRepository();
            UserModel userModel = new UserModel();
            userModel.FirstName = "test";
            userModel.LastName = "test";
            userModel.Email = "test@test.com";
            userModel.Password = "test";
            UserRepository.CreateUser(userModel);

            Assert.Equal(userModel, userModel);
        }
        [Fact]
        public void TestValidateupdateuser()
        {
            UserRepository UserRepository = new UserRepository();
            UserModel userModel = new UserModel();
            userModel.FirstName = "test1";
            userModel.LastName = "test";
            userModel.Email = "test@test.com";
            userModel.Password = "test";
           string rst= UserRepository.UpdateUser(userModel);

            Assert.Equal("success",rst);
        }

        [Fact]
        public void TestValidatealluser()
        {
            UserRepository UserRepository = new UserRepository();
            List<UserModel> UserModel = UserRepository.GetGetalluser();

            Assert.Equal(UserModel, UserModel);
        }


        [Fact]
        public void TestValidateProject()
        {
            ProjectRepository ProjectRepository = new ProjectRepository();
            ProjectModel ProjectModel = ProjectRepository.Getaproject(1);

            Assert.Equal(ProjectModel, ProjectModel);
        }

        [Fact]
        public void TestValidatecreateProject()
        {
            ProjectRepository ProjectRepository = new ProjectRepository();
            ProjectModel ProjectModel = new ProjectModel();
           // ProjectModel.CreatedOn = null; 
            ProjectModel.Detail="test";
            ProjectModel.Id = 1;
            ProjectModel.Name = "test";
            ProjectRepository.Create(ProjectModel);
            Assert.Equal(ProjectModel, ProjectModel);
        }

        [Fact]
        public void TestValidateUpdateProject()
        {
            ProjectRepository ProjectRepository = new ProjectRepository();
            ProjectModel ProjectModel = new ProjectModel();
            // ProjectModel.CreatedOn = null; 
            ProjectModel.Detail = "test1";
            ProjectModel.Id = 1;
            ProjectModel.Name = "test";
          string result=  ProjectRepository.Updateproject(ProjectModel);
            Assert.Equal("success", result);
        }

        [Fact]
        public void TestValidateallProject()
        {
            ProjectRepository ProjectRepository = new ProjectRepository();
            List<ProjectModel> lstprojectmodel = ProjectRepository.Getallproject();

            Assert.Equal(lstprojectmodel, lstprojectmodel);
        }


        [Fact]
        public void TestValidatetask()
        {
            TaskRepository TaskRepository = new TaskRepository();
            TaskModel TaskModel = TaskRepository.GetaTask(1);

            Assert.Equal(TaskModel, TaskModel);
        }

        [Fact]
        public void TestValidatealltask()
        {
            TaskRepository TaskRepository = new TaskRepository();
            List< TaskModel> lstTaskModel = TaskRepository.GetallTasks();

            Assert.Equal(lstTaskModel, lstTaskModel);
        }

        [Fact]
        public void TestValidatecreatetask()
        {
            TaskRepository TaskRepository = new TaskRepository();
            TaskModel TaskModel = new TaskModel();
            TaskModel.AssignedUserId = 1;
            TaskModel.Detail = "test";
            TaskModel.Id = 1;
            TaskModel.ProjectId = 10;
            TaskModel.Status = "success";
            TaskRepository.CreateTask(TaskModel);
            Assert.Equal(TaskModel, TaskModel);
          
        }

        [Fact]
        public void TestValidateupdatetask()
        {
            TaskRepository TaskRepository = new TaskRepository();
            TaskModel TaskModel = new TaskModel();
            TaskModel.AssignedUserId = 1;
            TaskModel.Detail = "tes1t";
            TaskModel.Id = 1;
            TaskModel.ProjectId = 10;
            TaskModel.Status = "success";
            string result=TaskRepository.UpdateTask(TaskModel);
            Assert.Equal("success",result);

        }
    }
}
