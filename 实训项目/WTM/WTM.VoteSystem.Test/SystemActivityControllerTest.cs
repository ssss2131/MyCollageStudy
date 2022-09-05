using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using WTM.VoteSystem.Controllers;
using WTM.VoteSystem.ViewModel.AreaActivity.SystemActivityVMs;
using WalkingTec.Mvvm.Core;
using WTM.VoteSystem.DataAccess;


namespace WTM.VoteSystem.Test
{
    [TestClass]
    public class SystemActivityControllerTest
    {
        private SystemActivityController _controller;
        private string _seed;

        public SystemActivityControllerTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateController<SystemActivityController>(new DataContext(_seed, DBTypeEnum.Memory), "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            string rv2 = _controller.Search((rv.Model as SystemActivityListVM).Searcher);
            Assert.IsTrue(rv2.Contains("\"Code\":200"));
        }

        [TestMethod]
        public void CreateTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Create();
            Assert.IsInstanceOfType(rv.Model, typeof(SystemActivityVM));

            SystemActivityVM vm = rv.Model as SystemActivityVM;
            SystemActivity v = new SystemActivity();
			
            v.ID = 84;
            v.Title = "Mb4oOkMuF3";
            v.Content = "BrsYm4Z4zZSQf";
            v.EachVoteNumber = 22;
            v.PhotoId = AddFileAttachment();
            v.WhoSend = "LPRkNII0AhBgwZ";
            v.WhenStart = DateTime.Parse("2022-10-20 10:21:11");
            v.WhenEnd = DateTime.Parse("2023-10-01 10:21:11");
            vm.Entity = v;
            _controller.Create(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<SystemActivity>().Find(v.ID);
				
                Assert.AreEqual(data.ID, 84);
                Assert.AreEqual(data.Title, "Mb4oOkMuF3");
                Assert.AreEqual(data.Content, "BrsYm4Z4zZSQf");
                Assert.AreEqual(data.EachVoteNumber, 22);
                Assert.AreEqual(data.WhoSend, "LPRkNII0AhBgwZ");
                Assert.AreEqual(data.WhenStart, DateTime.Parse("2022-10-20 10:21:11"));
                Assert.AreEqual(data.WhenEnd, DateTime.Parse("2023-10-01 10:21:11"));
            }

        }

        [TestMethod]
        public void EditTest()
        {
            SystemActivity v = new SystemActivity();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.ID = 84;
                v.Title = "Mb4oOkMuF3";
                v.Content = "BrsYm4Z4zZSQf";
                v.EachVoteNumber = 22;
                v.PhotoId = AddFileAttachment();
                v.WhoSend = "LPRkNII0AhBgwZ";
                v.WhenStart = DateTime.Parse("2022-10-20 10:21:11");
                v.WhenEnd = DateTime.Parse("2023-10-01 10:21:11");
                context.Set<SystemActivity>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Edit(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(SystemActivityVM));

            SystemActivityVM vm = rv.Model as SystemActivityVM;
            vm.Wtm.DC = new DataContext(_seed, DBTypeEnum.Memory);
            v = new SystemActivity();
            v.ID = vm.Entity.ID;
       		
            v.Title = "0J36Mv5SrMEi";
            v.Content = "UBn1F2";
            v.EachVoteNumber = 17;
            v.WhoSend = "0aRhx73tKAj";
            v.WhenStart = DateTime.Parse("2022-07-15 10:21:11");
            v.WhenEnd = DateTime.Parse("2023-08-20 10:21:11");
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.ID", "");
            vm.FC.Add("Entity.Title", "");
            vm.FC.Add("Entity.Content", "");
            vm.FC.Add("Entity.EachVoteNumber", "");
            vm.FC.Add("Entity.PhotoId", "");
            vm.FC.Add("Entity.WhoSend", "");
            vm.FC.Add("Entity.WhenStart", "");
            vm.FC.Add("Entity.WhenEnd", "");
            _controller.Edit(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<SystemActivity>().Find(v.ID);
 				
                Assert.AreEqual(data.Title, "0J36Mv5SrMEi");
                Assert.AreEqual(data.Content, "UBn1F2");
                Assert.AreEqual(data.EachVoteNumber, 17);
                Assert.AreEqual(data.WhoSend, "0aRhx73tKAj");
                Assert.AreEqual(data.WhenStart, DateTime.Parse("2022-07-15 10:21:11"));
                Assert.AreEqual(data.WhenEnd, DateTime.Parse("2023-08-20 10:21:11"));
            }

        }


        [TestMethod]
        public void DeleteTest()
        {
            SystemActivity v = new SystemActivity();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.ID = 84;
                v.Title = "Mb4oOkMuF3";
                v.Content = "BrsYm4Z4zZSQf";
                v.EachVoteNumber = 22;
                v.PhotoId = AddFileAttachment();
                v.WhoSend = "LPRkNII0AhBgwZ";
                v.WhenStart = DateTime.Parse("2022-10-20 10:21:11");
                v.WhenEnd = DateTime.Parse("2023-10-01 10:21:11");
                context.Set<SystemActivity>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Delete(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(SystemActivityVM));

            SystemActivityVM vm = rv.Model as SystemActivityVM;
            v = new SystemActivity();
            v.ID = vm.Entity.ID;
            vm.Entity = v;
            _controller.Delete(v.ID.ToString(),null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<SystemActivity>().Find(v.ID);
                Assert.AreEqual(data, null);
            }

        }


        [TestMethod]
        public void DetailsTest()
        {
            SystemActivity v = new SystemActivity();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v.ID = 84;
                v.Title = "Mb4oOkMuF3";
                v.Content = "BrsYm4Z4zZSQf";
                v.EachVoteNumber = 22;
                v.PhotoId = AddFileAttachment();
                v.WhoSend = "LPRkNII0AhBgwZ";
                v.WhenStart = DateTime.Parse("2022-10-20 10:21:11");
                v.WhenEnd = DateTime.Parse("2023-10-01 10:21:11");
                context.Set<SystemActivity>().Add(v);
                context.SaveChanges();
            }
            PartialViewResult rv = (PartialViewResult)_controller.Details(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(IBaseCRUDVM<TopBasePoco>));
            Assert.AreEqual(v.ID, (rv.Model as IBaseCRUDVM<TopBasePoco>).Entity.GetID());
        }

        [TestMethod]
        public void BatchEditTest()
        {
            SystemActivity v1 = new SystemActivity();
            SystemActivity v2 = new SystemActivity();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.ID = 84;
                v1.Title = "Mb4oOkMuF3";
                v1.Content = "BrsYm4Z4zZSQf";
                v1.EachVoteNumber = 22;
                v1.PhotoId = AddFileAttachment();
                v1.WhoSend = "LPRkNII0AhBgwZ";
                v1.WhenStart = DateTime.Parse("2022-10-20 10:21:11");
                v1.WhenEnd = DateTime.Parse("2023-10-01 10:21:11");
                v2.ID = 6;
                v2.Title = "0J36Mv5SrMEi";
                v2.Content = "UBn1F2";
                v2.EachVoteNumber = 17;
                v2.PhotoId = v1.PhotoId; 
                v2.WhoSend = "0aRhx73tKAj";
                v2.WhenStart = DateTime.Parse("2022-07-15 10:21:11");
                v2.WhenEnd = DateTime.Parse("2023-08-20 10:21:11");
                context.Set<SystemActivity>().Add(v1);
                context.Set<SystemActivity>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(SystemActivityBatchVM));

            SystemActivityBatchVM vm = rv.Model as SystemActivityBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            
            vm.FC = new Dictionary<string, object>();
			
            _controller.DoBatchEdit(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<SystemActivity>().Find(v1.ID);
                var data2 = context.Set<SystemActivity>().Find(v2.ID);
 				
            }
        }


        [TestMethod]
        public void BatchDeleteTest()
        {
            SystemActivity v1 = new SystemActivity();
            SystemActivity v2 = new SystemActivity();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.ID = 84;
                v1.Title = "Mb4oOkMuF3";
                v1.Content = "BrsYm4Z4zZSQf";
                v1.EachVoteNumber = 22;
                v1.PhotoId = AddFileAttachment();
                v1.WhoSend = "LPRkNII0AhBgwZ";
                v1.WhenStart = DateTime.Parse("2022-10-20 10:21:11");
                v1.WhenEnd = DateTime.Parse("2023-10-01 10:21:11");
                v2.ID = 6;
                v2.Title = "0J36Mv5SrMEi";
                v2.Content = "UBn1F2";
                v2.EachVoteNumber = 17;
                v2.PhotoId = v1.PhotoId; 
                v2.WhoSend = "0aRhx73tKAj";
                v2.WhenStart = DateTime.Parse("2022-07-15 10:21:11");
                v2.WhenEnd = DateTime.Parse("2023-08-20 10:21:11");
                context.Set<SystemActivity>().Add(v1);
                context.Set<SystemActivity>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(SystemActivityBatchVM));

            SystemActivityBatchVM vm = rv.Model as SystemActivityBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            _controller.DoBatchDelete(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<SystemActivity>().Find(v1.ID);
                var data2 = context.Set<SystemActivity>().Find(v2.ID);
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

                v.FileName = "1J1cFjpZIlOJ";
                v.FileExt = "2Ica4";
                v.Path = "x3AdVnf1fogrUDBmFs";
                v.Length = 73;
                v.UploadTime = DateTime.Parse("2023-11-19 10:21:11");
                v.SaveMode = "tQIU";
                v.ExtraInfo = "tVqVFGqyXIIYf";
                v.HandlerInfo = "wVthoGcZnjDY9hC4a6w";
                context.Set<FileAttachment>().Add(v);
                context.SaveChanges();
                }
                catch{}
            }
            return v.ID;
        }


    }
}
