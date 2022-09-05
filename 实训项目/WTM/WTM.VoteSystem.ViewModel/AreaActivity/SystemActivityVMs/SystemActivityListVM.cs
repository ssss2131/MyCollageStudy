using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;


namespace WTM.VoteSystem.ViewModel.AreaActivity.SystemActivityVMs
{
    public partial class SystemActivityListVM : BasePagedListVM<SystemActivity_View, SystemActivitySearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("SystemActivity", GridActionStandardTypesEnum.Create, Localizer["Sys.Create"],"AreaActivity", dialogWidth: 800),
                this.MakeStandardAction("SystemActivity", GridActionStandardTypesEnum.Edit, Localizer["Sys.Edit"], "AreaActivity", dialogWidth: 800),
                this.MakeStandardAction("SystemActivity", GridActionStandardTypesEnum.Delete, Localizer["Sys.Delete"], "AreaActivity", dialogWidth: 800),
                this.MakeStandardAction("SystemActivity", GridActionStandardTypesEnum.Details, Localizer["Sys.Details"], "AreaActivity", dialogWidth: 800),
                this.MakeStandardAction("SystemActivity", GridActionStandardTypesEnum.BatchEdit, Localizer["Sys.BatchEdit"], "AreaActivity", dialogWidth: 800),
                this.MakeStandardAction("SystemActivity", GridActionStandardTypesEnum.BatchDelete, Localizer["Sys.BatchDelete"], "AreaActivity", dialogWidth: 800),
                this.MakeStandardAction("SystemActivity", GridActionStandardTypesEnum.Import, Localizer["Sys.Import"], "AreaActivity", dialogWidth: 800),
                this.MakeStandardAction("SystemActivity", GridActionStandardTypesEnum.ExportExcel, Localizer["Sys.Export"], "AreaActivity"),
            };
        }


        protected override IEnumerable<IGridColumn<SystemActivity_View>> InitGridHeader()
        {
            return new List<GridColumn<SystemActivity_View>>{
                this.MakeGridHeader(x => x.Title),
                this.MakeGridHeader(x => x.Content),
                this.MakeGridHeader(x => x.EachVoteNumber),
                this.MakeGridHeader(x => x.PhotoId).SetFormat(PhotoIdFormat),
                this.MakeGridHeader(x => x.WhoSend),
                this.MakeGridHeader(x => x.WhenStart),
                this.MakeGridHeader(x => x.WhenEnd),
                this.MakeGridHeaderAction(width: 200)
            };
        }
        private List<ColumnFormatInfo> PhotoIdFormat(SystemActivity_View entity, object val)
        {
            return new List<ColumnFormatInfo>
            {
                ColumnFormatInfo.MakeDownloadButton(ButtonTypesEnum.Button,entity.PhotoId),
                ColumnFormatInfo.MakeViewButton(ButtonTypesEnum.Button,entity.PhotoId,640,480),
            };
        }


        public override IOrderedQueryable<SystemActivity_View> GetSearchQuery()
        {
            var query = DC.Set<SystemActivity>()
                .CheckContain(Searcher.Content, x=>x.Content)
                .CheckEqual(Searcher.EachVoteNumber, x=>x.EachVoteNumber)
                .Select(x => new SystemActivity_View
                {
				    ID = x.ID,
                    Title = x.Title,
                    Content = x.Content,
                    EachVoteNumber = x.EachVoteNumber,
                    PhotoId = x.PhotoId,
                    WhoSend = x.WhoSend,
                    WhenStart = x.WhenStart,
                    WhenEnd = x.WhenEnd,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class SystemActivity_View : SystemActivity{

    }
}
