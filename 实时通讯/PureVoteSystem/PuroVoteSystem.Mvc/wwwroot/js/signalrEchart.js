var actId =  document.getElementById("actId").text;
var actId = 1;

// 基于准备好的dom，初始化echarts实例
var myChart = echarts.init(document.getElementById('main'));

// 指定图表的配置项和数据
var option = {
    title: {
        text: '投票数量'
    },
    tooltip: {},
    legend: {
        data: ['票数']
    },
    xAxis: {
        data: ['用户1', '用户2', '用户3', '用户4', '用户5', '用户6']
    },
    yAxis: {},
    series: [
        {
            name: '票数',
            type: 'bar',
            data: [5, 20, 36, 10, 10, 20]
        }
    ]
};

// 使用刚指定的配置项和数据显示图表。
myChart.setOption(option);



var echartsData
/*通过建造者模式创建一个connection*/

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

/*实时监听来自hub的数据*/
connection.on("PleaseEchartsData", function (value) {
    var xData = [];
    for (var i = 0; i < value.length; i++) {
        xData.push(value[i].userName);
    }
    var yData = [];
    for (var i = 0; i < value.length; i++) {
        yData.push(value[i].voteNumber);
    }
    option.xAxis.data = xData;
    option.yAxis.data = yData;
    myChart.setOption(option);
    console.log(value);
})

/*建立与hub的连接*/
connection.start().then(function () {
    console.log("连接成功建立");
}).catch(function (err) {
    return console.error(err.toString());
})
/*定时调用hub*/
setInterval(getData, 3000);
function getData() {
    var acrId = 1;
    connection.invoke("ShowData", "1").catch(function (err) {
        return console.error(err.toString());
    })
}