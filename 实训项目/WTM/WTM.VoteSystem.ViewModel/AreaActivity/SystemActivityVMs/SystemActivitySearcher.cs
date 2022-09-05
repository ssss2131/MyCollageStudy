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
    public partial class SystemActivitySearcher : BaseSearcher
    {
        [Display(Name = "活动内容")]
        public String Content { get; set; }
        [Display(Name = "允许票数")]
        public Int32? EachVoteNumber { get; set; }

        protected override void InitVM()
        {
        }

    }
}
