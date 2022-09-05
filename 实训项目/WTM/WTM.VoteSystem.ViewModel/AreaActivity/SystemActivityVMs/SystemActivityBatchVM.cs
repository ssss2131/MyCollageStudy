using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using WalkingTec.Mvvm.Core;


namespace WTM.VoteSystem.ViewModel.AreaActivity.SystemActivityVMs
{
    public partial class SystemActivityBatchVM : BaseBatchVM<SystemActivity, SystemActivity_BatchEdit>
    {
        public SystemActivityBatchVM()
        {
            ListVM = new SystemActivityListVM();
            LinkedVM = new SystemActivity_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class SystemActivity_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
