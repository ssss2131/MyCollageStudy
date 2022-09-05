using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using WTM.VoteSystem.Controllers;
using WTM.VoteSystem.ViewModel.AreaUsers.SystemUserVMs;
using WalkingTec.Mvvm.Core;
using WTM.VoteSystem.DataAccess;


namespace WTM.VoteSystem.Test
{
    [TestClass]
    public class SystemUserControllerTest
    {
        private SystemUserController _controller;
        private string _seed;

        public SystemUserControllerTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateController<SystemUserController>(new DataContext(_seed, DBTypeEnum.Memory), "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            string rv2 = _controller.Search((rv.Model as SystemUserListVM).Searcher);
            Assert.IsTrue(rv2.Contains("\"Code\":200"));
        }

        [TestMethod]
        public void CreateTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Create();
            Assert.IsInstanceOfType(rv.Model, typeof(SystemUserVM));

            SystemUserVM vm = rv.Model as SystemUserVM;
            SystemUser v = new SystemUser();
			
            v.ID = 23;
            v.UserPhotoId = AddFileAttachment();
            v.Account = "YW981BtB";
            v.Password = "Km";
            v.UserName = "OudBG";
            v.Birthday = DateTime.Parse("2023-03-31 09:34:10");
            v.Email = "GhzIM";
            v.SystemActivityId = 81;
            v.Age = 40;
            v.RoleId = AddSystemRole();
            vm.Entity = v;
            _controller.Create(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<SystemUser>().Find(v.ID);
				
                Assert.AreEqual(data.ID, 23);
                Assert.AreEqual(data.Account, "YW981BtB");
                Assert.AreEqual(data.Password, "Km");
                Assert.AreEqual(data.UserName, "OudBG");
                Assert.AreEqual(data.Birthday, DateTime.Parse("2023-03-31 09:34:10"));
                Assert.AreEqual(data.Email, "GhzIM");
                Assert.AreEqual(data.SystemActivityId, 81);
                Assert.AreEqual(data.Age, 40);
            }

        }

        [TestMethod]
        public void EditTest()
        {
            SystemUser v = new SystemUser();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.ID = 23;
                v.UserPhotoId = AddFileAttachment();
                v.Account = "YW981BtB";
                v.Password = "Km";
                v.UserName = "OudBG";
                v.Birthday = DateTime.Parse("2023-03-31 09:34:10");
                v.Email = "GhzIM";
                v.SystemActivityId = 81;
                v.Age = 40;
                v.RoleId = AddSystemRole();
                context.Set<SystemUser>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Edit(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(SystemUserVM));

            SystemUserVM vm = rv.Model as SystemUserVM;
            vm.Wtm.DC = new DataContext(_seed, DBTypeEnum.Memory);
            v = new SystemUser();
            v.ID = vm.Entity.ID;
       		
            v.Account = "Hx2EIiAEF";
            v.Password = "zteT6BzQCpapM3OiDzQ";
            v.UserName = "ZRGrHhjU45";
            v.Birthday = DateTime.Parse("2022-06-07 09:34:11");
            v.Email = "jZmUVQuASbluFH5lZ";
            v.SystemActivityId = 84;
            v.Age = 81;
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.ID", "");
            vm.FC.Add("Entity.UserPhotoId", "");
            vm.FC.Add("Entity.Account", "");
            vm.FC.Add("Entity.Password", "");
            vm.FC.Add("Entity.UserName", "");
            vm.FC.Add("Entity.Birthday", "");
            vm.FC.Add("Entity.Email", "");
            vm.FC.Add("Entity.SystemActivityId", "");
            vm.FC.Add("Entity.Age", "");
            vm.FC.Add("Entity.RoleId", "");
            _controller.Edit(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<SystemUser>().Find(v.ID);
 				
                Assert.AreEqual(data.Account, "Hx2EIiAEF");
                Assert.AreEqual(data.Password, "zteT6BzQCpapM3OiDzQ");
                Assert.AreEqual(data.UserName, "ZRGrHhjU45");
                Assert.AreEqual(data.Birthday, DateTime.Parse("2022-06-07 09:34:11"));
                Assert.AreEqual(data.Email, "jZmUVQuASbluFH5lZ");
                Assert.AreEqual(data.SystemActivityId, 84);
                Assert.AreEqual(data.Age, 81);
            }

        }


        [TestMethod]
        public void DeleteTest()
        {
            SystemUser v = new SystemUser();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.ID = 23;
                v.UserPhotoId = AddFileAttachment();
                v.Account = "YW981BtB";
                v.Password = "Km";
                v.UserName = "OudBG";
                v.Birthday = DateTime.Parse("2023-03-31 09:34:10");
                v.Email = "GhzIM";
                v.SystemActivityId = 81;
                v.Age = 40;
                v.RoleId = AddSystemRole();
                context.Set<SystemUser>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Delete(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(SystemUserVM));

            SystemUserVM vm = rv.Model as SystemUserVM;
            v = new SystemUser();
            v.ID = vm.Entity.ID;
            vm.Entity = v;
            _controller.Delete(v.ID.ToString(),null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<SystemUser>().Find(v.ID);
                Assert.AreEqual(data, null);
            }

        }


        [TestMethod]
        public void DetailsTest()
        {
            SystemUser v = new SystemUser();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v.ID = 23;
                v.UserPhotoId = AddFileAttachment();
                v.Account = "YW981BtB";
                v.Password = "Km";
                v.UserName = "OudBG";
                v.Birthday = DateTime.Parse("2023-03-31 09:34:10");
                v.Email = "GhzIM";
                v.SystemActivityId = 81;
                v.Age = 40;
                v.RoleId = AddSystemRole();
                context.Set<SystemUser>().Add(v);
                context.SaveChanges();
            }
            PartialViewResult rv = (PartialViewResult)_controller.Details(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(IBaseCRUDVM<TopBasePoco>));
            Assert.AreEqual(v.ID, (rv.Model as IBaseCRUDVM<TopBasePoco>).Entity.GetID());
        }

        [TestMethod]
        public void BatchEditTest()
        {
            SystemUser v1 = new SystemUser();
            SystemUser v2 = new SystemUser();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.ID = 23;
                v1.UserPhotoId = AddFileAttachment();
                v1.Account = "YW981BtB";
                v1.Password = "Km";
                v1.UserName = "OudBG";
                v1.Birthday = DateTime.Parse("2023-03-31 09:34:10");
                v1.Email = "GhzIM";
                v1.SystemActivityId = 81;
                v1.Age = 40;
                v1.RoleId = AddSystemRole();
                v2.ID = 13;
                v2.UserPhotoId = v1.UserPhotoId; 
                v2.Account = "Hx2EIiAEF";
                v2.Password = "zteT6BzQCpapM3OiDzQ";
                v2.UserName = "ZRGrHhjU45";
                v2.Birthday = DateTime.Parse("2022-06-07 09:34:11");
                v2.Email = "jZmUVQuASbluFH5lZ";
                v2.SystemActivityId = 84;
                v2.Age = 81;
                v2.RoleId = v1.RoleId; 
                context.Set<SystemUser>().Add(v1);
                context.Set<SystemUser>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(SystemUserBatchVM));

            SystemUserBatchVM vm = rv.Model as SystemUserBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            
            vm.FC = new Dictionary<string, object>();
			
            _controller.DoBatchEdit(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<SystemUser>().Find(v1.ID);
                var data2 = context.Set<SystemUser>().Find(v2.ID);
 				
            }
        }


        [TestMethod]
        public void BatchDeleteTest()
        {
            SystemUser v1 = new SystemUser();
            SystemUser v2 = new SystemUser();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.ID = 23;
                v1.UserPhotoId = AddFileAttachment();
                v1.Account = "YW981BtB";
                v1.Password = "Km";
                v1.UserName = "OudBG";
                v1.Birthday = DateTime.Parse("2023-03-31 09:34:10");
                v1.Email = "GhzIM";
                v1.SystemActivityId = 81;
                v1.Age = 40;
                v1.RoleId = AddSystemRole();
                v2.ID = 13;
                v2.UserPhotoId = v1.UserPhotoId; 
                v2.Account = "Hx2EIiAEF";
                v2.Password = "zteT6BzQCpapM3OiDzQ";
                v2.UserName = "ZRGrHhjU45";
                v2.Birthday = DateTime.Parse("2022-06-07 09:34:11");
                v2.Email = "jZmUVQuASbluFH5lZ";
                v2.SystemActivityId = 84;
                v2.Age = 81;
                v2.RoleId = v1.RoleId; 
                context.Set<SystemUser>().Add(v1);
                context.Set<SystemUser>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(SystemUserBatchVM));

            SystemUserBatchVM vm = rv.Model as SystemUserBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            _controller.DoBatchDelete(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<SystemUser>().Find(v1.ID);
                var data2 = context.Set<SystemUser>().Find(v2.ID);
                Assert.AreEqual(data1, null);
            Assert.AreEqual(data2, null);
            }
        }

        private Guid AddFileAttachment()
        {
            FileAttachment v = new FileAttachment();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                try{

                v.FileName = "IWs";
                v.FileExt = "6Wg0";
                v.Path = "jKcaLumzC";
                v.Length = 14;
                v.UploadTime = DateTime.Parse("2023-06-29 09:34:11");
                v.SaveMode = "PK8AN";
                v.ExtraInfo = "y15hIkGZQH6";
                v.HandlerInfo = "XGZ";
                context.Set<FileAttachment>().Add(v);
                context.SaveChanges();
                }
                catch{}
            }
            return v.ID;
        }

        private Int32 AddSystemRole()
        {
            SystemRole v = new SystemRole();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                try{

                v.ID = 22;
                v.RoleName = "Cd9PM9evtGdYoL2HQ";
                context.Set<SystemRole>().Add(v);
                context.SaveChanges();
                }
                catch{}
            }
            return v.ID;
        }


    }
}
