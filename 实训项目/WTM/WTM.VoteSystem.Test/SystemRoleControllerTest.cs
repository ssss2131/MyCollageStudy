using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using WTM.VoteSystem.Controllers;
using WTM.VoteSystem.ViewModel.AreaRole.SystemRoleVMs;
using WalkingTec.Mvvm.Core;
using WTM.VoteSystem.DataAccess;


namespace WTM.VoteSystem.Test
{
    [TestClass]
    public class SystemRoleControllerTest
    {
        private SystemRoleController _controller;
        private string _seed;

        public SystemRoleControllerTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateController<SystemRoleController>(new DataContext(_seed, DBTypeEnum.Memory), "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            string rv2 = _controller.Search((rv.Model as SystemRoleListVM).Searcher);
            Assert.IsTrue(rv2.Contains("\"Code\":200"));
        }

        [TestMethod]
        public void CreateTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Create();
            Assert.IsInstanceOfType(rv.Model, typeof(SystemRoleVM));

            SystemRoleVM vm = rv.Model as SystemRoleVM;
            SystemRole v = new SystemRole();
			
            v.ID = 83;
            v.RoleName = "pLDja1orzlmgmj";
            vm.Entity = v;
            _controller.Create(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<SystemRole>().Find(v.ID);
				
                Assert.AreEqual(data.ID, 83);
                Assert.AreEqual(data.RoleName, "pLDja1orzlmgmj");
            }

        }

        [TestMethod]
        public void EditTest()
        {
            SystemRole v = new SystemRole();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.ID = 83;
                v.RoleName = "pLDja1orzlmgmj";
                context.Set<SystemRole>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Edit(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(SystemRoleVM));

            SystemRoleVM vm = rv.Model as SystemRoleVM;
            vm.Wtm.DC = new DataContext(_seed, DBTypeEnum.Memory);
            v = new SystemRole();
            v.ID = vm.Entity.ID;
       		
            v.RoleName = "wc3VBSTLsw";
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.ID", "");
            vm.FC.Add("Entity.RoleName", "");
            _controller.Edit(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<SystemRole>().Find(v.ID);
 				
                Assert.AreEqual(data.RoleName, "wc3VBSTLsw");
            }

        }


        [TestMethod]
        public void DeleteTest()
        {
            SystemRole v = new SystemRole();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.ID = 83;
                v.RoleName = "pLDja1orzlmgmj";
                context.Set<SystemRole>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Delete(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(SystemRoleVM));

            SystemRoleVM vm = rv.Model as SystemRoleVM;
            v = new SystemRole();
            v.ID = vm.Entity.ID;
            vm.Entity = v;
            _controller.Delete(v.ID.ToString(),null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<SystemRole>().Find(v.ID);
                Assert.AreEqual(data, null);
            }

        }


        [TestMethod]
        public void DetailsTest()
        {
            SystemRole v = new SystemRole();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v.ID = 83;
                v.RoleName = "pLDja1orzlmgmj";
                context.Set<SystemRole>().Add(v);
                context.SaveChanges();
            }
            PartialViewResult rv = (PartialViewResult)_controller.Details(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(IBaseCRUDVM<TopBasePoco>));
            Assert.AreEqual(v.ID, (rv.Model as IBaseCRUDVM<TopBasePoco>).Entity.GetID());
        }

        [TestMethod]
        public void BatchEditTest()
        {
            SystemRole v1 = new SystemRole();
            SystemRole v2 = new SystemRole();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.ID = 83;
                v1.RoleName = "pLDja1orzlmgmj";
                v2.ID = 19;
                v2.RoleName = "wc3VBSTLsw";
                context.Set<SystemRole>().Add(v1);
                context.Set<SystemRole>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(SystemRoleBatchVM));

            SystemRoleBatchVM vm = rv.Model as SystemRoleBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            
            vm.FC = new Dictionary<string, object>();
			
            _controller.DoBatchEdit(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<SystemRole>().Find(v1.ID);
                var data2 = context.Set<SystemRole>().Find(v2.ID);
 				
            }
        }


        [TestMethod]
        public void BatchDeleteTest()
        {
            SystemRole v1 = new SystemRole();
            SystemRole v2 = new SystemRole();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.ID = 83;
                v1.RoleName = "pLDja1orzlmgmj";
                v2.ID = 19;
                v2.RoleName = "wc3VBSTLsw";
                context.Set<SystemRole>().Add(v1);
                context.Set<SystemRole>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(SystemRoleBatchVM));

            SystemRoleBatchVM vm = rv.Model as SystemRoleBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            _controller.DoBatchDelete(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<SystemRole>().Find(v1.ID);
                var data2 = context.Set<SystemRole>().Find(v2.ID);
                Assert.AreEqual(data1, null);
            Assert.AreEqual(data2, null);
            }
        }


    }
}
