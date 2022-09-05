$(function () {
    var l = abp.localization.getResource('newsProject');

    var dataTable = $('#NewsTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: false,
            scrollX: true,//newsProject.news.iNewsService.newsServiceImp.getList({}).done(function (result) { console.log(result); });
            ajax: abp.libs.datatables.createAjax(newsProject.news.iNewsService.newsServiceImp.getList),
            columnDefs: [
                {
                    title: l('title'),
                    data: "title"
                },
                {
                    title: l('sTitle'),
                    data: "sTitle"
                },
                {
                    title: l('data'),
                    data: "data"
                },
                {
                    title: l('category'),
                    data: "category"
                },
                {
                    title: l('clickNum'),
                    data: "clickNum"
                 }, 
                 {
                    title: l('dateTime'),
                    data: "dateTime"
                 }
                 
                 
                // {
                //     title: l('dateTime'),
                //     data: "dateTime",
                //     render: function (data) {
                //         return luxon
                //             .DateTime
                //             .fromISO(data, {
                //                 locale: abp.localization.currentCulture.name
                //             }).toLocaleString();
                //     }
                // }
            ]
        })
    );
});
