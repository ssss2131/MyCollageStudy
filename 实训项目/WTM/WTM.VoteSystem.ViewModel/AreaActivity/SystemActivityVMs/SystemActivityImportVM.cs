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
    public partial class SystemActivityTemplateVM : BaseTemplateVM
    {
        [Display(Name = "活动标题")]
        public ExcelPropety Title_Excel = ExcelPropety.CreateProperty<SystemActivity>(x => x.Title);
        [Display(Name = "活动内容")]
        public ExcelPropety Content_Excel = ExcelPropety.CreateProperty<SystemActivity>(x => x.Content);
        [Display(Name = "允许票数")]
        public ExcelPropety EachVoteNumber_Excel = ExcelPropety.CreateProperty<SystemActivity>(x => x.EachVoteNumber);
        [Display(Name = "活动发起人")]
        public ExcelPropety WhoSend_Excel = ExcelPropety.CreateProperty<SystemActivity>(x => x.WhoSend);
        [Display(Name = "活动开始时间")]
        public ExcelPropety WhenStart_Excel = ExcelPropety.CreateProperty<SystemActivity>(x => x.WhenStart);
        [Display(Name = "活动结束时间")]
        public ExcelPropety WhenEnd_Excel = ExcelPropety.CreateProperty<SystemActivity>(x => x.WhenEnd);

	    protected override void InitVM()
        {
        }

    }

    public class SystemActivityImportVM : BaseImportVM<SystemActivityTemplateVM, SystemActivity>
    {

    }

}
