using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using WTM.VoteSystem.Controllers;
using WTM.VoteSystem.ViewModel.AreaCandidateManager.SystemCandidateManagerVMs;
using WalkingTec.Mvvm.Core;
using WTM.VoteSystem.DataAccess;


namespace WTM.VoteSystem.Test
{
    [TestClass]
    public class SystemCandidateManagerControllerTest
    {
        private SystemCandidateManagerController _controller;
        private string _seed;

        public SystemCandidateManagerControllerTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateController<SystemCandidateManagerController>(new DataContext(_seed, DBTypeEnum.Memory), "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            string rv2 = _controller.Search((rv.Model as SystemCandidateManagerListVM).Searcher);
            Assert.IsTrue(rv2.Contains("\"Code\":200"));
        }

        [TestMethod]
        public void CreateTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Create();
            Assert.IsInstanceOfType(rv.Model, typeof(SystemCandidateManagerVM));

            SystemCandidateManagerVM vm = rv.Model as SystemCandidateManagerVM;
            SystemCandidateManager v = new SystemCandidateManager();
			
            v.ID = 82;
            v.SystemUserId = AddSystemUser();
            v.SystemActivityId = AddSystemActivity();
            v.CountVote = 51;
            vm.Entity = v;
            _controller.Create(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<SystemCandidateManager>().Find(v.ID);
				
                Assert.AreEqual(data.ID, 82);
                Assert.AreEqual(data.CountVote, 51);
            }

        }

        [TestMethod]
        public void EditTest()
        {
            SystemCandidateManager v = new SystemCandidateManager();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.ID = 82;
                v.SystemUserId = AddSystemUser();
                v.SystemActivityId = AddSystemActivity();
                v.CountVote = 51;
                context.Set<SystemCandidateManager>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Edit(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(SystemCandidateManagerVM));

            SystemCandidateManagerVM vm = rv.Model as SystemCandidateManagerVM;
            vm.Wtm.DC = new DataContext(_seed, DBTypeEnum.Memory);
            v = new SystemCandidateManager();
            v.ID = vm.Entity.ID;
       		
            v.CountVote = 80;
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.ID", "");
            vm.FC.Add("Entity.SystemUserId", "");
            vm.FC.Add("Entity.SystemActivityId", "");
            vm.FC.Add("Entity.CountVote", "");
            _controller.Edit(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<SystemCandidateManager>().Find(v.ID);
 				
                Assert.AreEqual(data.CountVote, 80);
            }

        }


        [TestMethod]
        public void DeleteTest()
        {
            SystemCandidateManager v = new SystemCandidateManager();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.ID = 82;
                v.SystemUserId = AddSystemUser();
                v.SystemActivityId = AddSystemActivity();
                v.CountVote = 51;
                context.Set<SystemCandidateManager>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Delete(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(SystemCandidateManagerVM));

            SystemCandidateManagerVM vm = rv.Model as SystemCandidateManagerVM;
            v = new SystemCandidateManager();
            v.ID = vm.Entity.ID;
            vm.Entity = v;
            _controller.Delete(v.ID.ToString(),null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<SystemCandidateManager>().Find(v.ID);
                Assert.AreEqual(data, null);
            }

        }


        [TestMethod]
        public void DetailsTest()
        {
            SystemCandidateManager v = new SystemCandidateManager();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v.ID = 82;
                v.SystemUserId = AddSystemUser();
                v.SystemActivityId = AddSystemActivity();
                v.CountVote = 51;
                context.Set<SystemCandidateManager>().Add(v);
                context.SaveChanges();
            }
            PartialViewResult rv = (PartialViewResult)_controller.Details(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(IBaseCRUDVM<TopBasePoco>));
            Assert.AreEqual(v.ID, (rv.Model as IBaseCRUDVM<TopBasePoco>).Entity.GetID());
        }

        [TestMethod]
        public void BatchEditTest()
        {
            SystemCandidateManager v1 = new SystemCandidateManager();
            SystemCandidateManager v2 = new SystemCandidateManager();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.ID = 82;
                v1.SystemUserId = AddSystemUser();
                v1.SystemActivityId = AddSystemActivity();
                v1.CountVote = 51;
                v2.ID = 67;
                v2.SystemUserId = v1.SystemUserId; 
                v2.SystemActivityId = v1.SystemActivityId; 
                v2.CountVote = 80;
                context.Set<SystemCandidateManager>().Add(v1);
                context.Set<SystemCandidateManager>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(SystemCandidateManagerBatchVM));

            SystemCandidateManagerBatchVM vm = rv.Model as SystemCandidateManagerBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            
            vm.FC = new Dictionary<string, object>();
			
            _controller.DoBatchEdit(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<SystemCandidateManager>().Find(v1.ID);
                var data2 = context.Set<SystemCandidateManager>().Find(v2.ID);
 				
            }
        }


        [TestMethod]
        public void BatchDeleteTest()
        {
            SystemCandidateManager v1 = new SystemCandidateManager();
            SystemCandidateManager v2 = new SystemCandidateManager();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.ID = 82;
                v1.SystemUserId = AddSystemUser();
                v1.SystemActivityId = AddSystemActivity();
                v1.CountVote = 51;
                v2.ID = 67;
                v2.SystemUserId = v1.SystemUserId; 
                v2.SystemActivityId = v1.SystemActivityId; 
                v2.CountVote = 80;
                context.Set<SystemCandidateManager>().Add(v1);
                context.Set<SystemCandidateManager>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(SystemCandidateManagerBatchVM));

            SystemCandidateManagerBatchVM vm = rv.Model as SystemCandidateManagerBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            _controller.DoBatchDelete(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<SystemCandidateManager>().Find(v1.ID);
                var data2 = context.Set<SystemCandidateManager>().Find(v2.ID);
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

                v.FileName = "KFZR4B";
                v.FileExt = "KijUS8";
                v.Path = "2hccueQX9vBaQ";
                v.Length = 72;
                v.UploadTime = DateTime.Parse("2022-08-21 09:35:23");
                v.SaveMode = "FHqDT3hA1qHq";
                v.ExtraInfo = "0JSk20RX9EVDO";
                v.HandlerInfo = "8afBdSYLNqkwG";
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

                v.ID = 42;
                v.RoleName = "WPsv5MaRfFQqy9FC";
                context.Set<SystemRole>().Add(v);
                context.SaveChanges();
                }
                catch{}
            }
            return v.ID;
        }

        private Int32 AddSystemUser()
        {
            SystemUser v = new SystemUser();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                try{

                v.ID = 75;
                v.UserPhotoId = AddFileAttachment();
                v.Account = "VDIv9MIwx97DVjq";
                v.Password = "pshUJRWR1CIpIzms1Ua";
                v.UserName = "Q";
                v.Birthday = DateTime.Parse("2021-06-16 09:35:23");
                v.Email = "3UzNvkiuYL2xz46";
                v.SystemActivityId = 25;
                v.Age = 16;
                v.RoleId = AddSystemRole();
                context.Set<SystemUser>().Add(v);
                context.SaveChanges();
                }
                catch{}
            }
            return v.ID;
        }

        private Int32 AddSystemActivity()
        {
            SystemActivity v = new SystemActivity();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                try{

                v.ID = 28;
                v.Title = "SIBcgVMM";
                v.Content = "qRtLKEvXa";
                v.EachVoteNumber = 26;
                v.PhotoId = AddFileAttachment();
                v.WhoSend = "hQahp";
                v.WhenStart = DateTime.Parse("2022-09-29 09:35:23");
                v.WhenEnd = DateTime.Parse("2023-07-01 09:35:23");
                context.Set<SystemActivity>().Add(v);
                context.SaveChanges();
                }
                catch{}
            }
            return v.ID;
        }


    }
}
