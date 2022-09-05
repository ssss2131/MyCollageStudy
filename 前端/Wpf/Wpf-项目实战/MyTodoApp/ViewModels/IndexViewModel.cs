using MyTodo.Shared.Dtos;
using MyTodoApp.Common;
using MyTodoApp.Extensions;
using MyTodoApp.Models;
using MyTodoApp.Service;
using Prism.Commands;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseDto = MyTodo.Shared.Dtos.BaseDto;
using MemoDto = MyTodo.Shared.Dtos.MemoDto;
using TodoDto = MyTodo.Shared.Dtos.TodoDto;

namespace MyTodoApp.ViewModels
{
    public class IndexViewModel: NavigationViewModel
    {
        private readonly IRegionManager regionManager;  
        public IndexViewModel(IDialogHostService dialog ,IContainerProvider provider):base(provider)
        {
            this.todoService = provider.Resolve<ITodoService>();
            this.memoService = provider.Resolve<IMemoService>();
            this.regionManager = provider.Resolve<IRegionManager>();
            TaskBars = new ObservableCollection<TaskBar>();
            ExecuteCommand = new DelegateCommand<string>(execute);
            EditCommand = new DelegateCommand<TodoDto>(AddTodo);
            EditMemoCommand = new DelegateCommand<MemoDto>(AddMemo);
            ToDoCompltedCommand = new DelegateCommand<TodoDto>(complated);
            TaskBars = new ObservableCollection<TaskBar>();
            NavigationCommand = new DelegateCommand<TaskBar>(navigate);
            this.dialog = dialog;
            CreateTaskBars(); 
        }

 

        private ObservableCollection<TaskBar> taskBars;

        private SummaryDto summaryDto; 

        private readonly IDialogHostService dialog;
        private readonly ITodoService todoService;
        private readonly IMemoService memoService;

        public DelegateCommand<string> ExecuteCommand { get; private set; }
        public DelegateCommand<TodoDto> EditCommand { get; private set; }
        public DelegateCommand<MemoDto> EditMemoCommand { get; private set; }
        public DelegateCommand<TodoDto> ToDoCompltedCommand { get; private set; }
        public DelegateCommand<TaskBar> NavigationCommand { get; private set; }


        public SummaryDto SummaryDto
        {
            get { return summaryDto; }
            set
            {
                summaryDto = value;
                RaisePropertyChanged();
            }
        }
        public ObservableCollection<TaskBar> TaskBars
        {
            get { return taskBars; }
            set { taskBars = value; RaisePropertyChanged(); }
        }
  
        private async void complated(TodoDto obj)
        {
            try
            {
                UpdateLoading(true);
                var updateRes = await todoService.UpdateAsync(obj);
                if (updateRes.Status)
                {
                    summaryDto.TodoList.Remove(summaryDto.TodoList.FirstOrDefault(c => c.Id.Equals(obj.Id)));
                    refresh();
                }
                eventAggregator.SendMessage(new Common.Event.MessageModel { Message = "已完成！" });

            }
            catch (Exception ex)
            {

                throw;
            }
            finally 
            {
                UpdateLoading(false);
            }
          
        }
        private void execute(string obj)
        {
            switch (obj)
            {
                case "新增备忘录":
                    AddMemo(null);
                    break;

                case "新增待办":
                    AddTodo(null);
                    break;
            }
        }
     
    
        private async void AddTodo(TodoDto model)
        {
            DialogParameters param = new DialogParameters();
            if (model!=null)
                param.Add("Value", model);
       
            var dialogResult = await dialog.ShowDialog("AddToDoDialogView", param);
            if (dialogResult.Result==ButtonResult.OK)
            {
                var todo = dialogResult.Parameters.GetValue<TodoDto>("Value");
                if (todo.Id>0)
                {
                    var updateRes = await todoService.UpdateAsync(todo);
                    if (updateRes.Status)
                    {
                        var todoModel = summaryDto.TodoList.FirstOrDefault(c => c.Id.Equals(todo.Id));
                        if(todoModel!=null)
                        {
                            todoModel.Title = todo.Title;
                            todoModel.Content = todo.Content;
                            todoModel.Status = todo.Status;
                        }
                    }
                }
                else
                {
                    if (todo is null || string.IsNullOrWhiteSpace(todo.Title) || string.IsNullOrEmpty(todo.Content)||string.IsNullOrEmpty(todo.Status.ToString()))
                    {
                        return;
                    }
                    var addResult = await todoService.AddAsync(todo);
                    if (addResult.Status)
                    {
                        summaryDto.TodoList.Add(addResult.Result);
                        refresh();
                    }
                }
            }
        }

        private async void AddMemo(BaseDto model)
        {
            DialogParameters param = new DialogParameters();
            if (model != null)
                param.Add("Value", model);

            var dialogResult = await dialog.ShowDialog("AddMemoDialogView", param);
            if (dialogResult.Result == ButtonResult.OK)
            {
                var memo = dialogResult.Parameters.GetValue<MemoDto>("Value");
                if (memo.Id > 0)
                {
                    var updateRes = await memoService.UpdateAsync(memo);
                    if (updateRes.Status)
                    {
                        var memoModel = SummaryDto.MemoList.FirstOrDefault(c => c.Id.Equals(memo.Id));
                        if (memoModel != null)
                        {
                            memoModel.Title = memo.Title;
                            memoModel.Content = memo.Content;
                        }
                        eventAggregator.SendMessage(new Common.Event.MessageModel { Message = "修改成功！" });
                    }
                }
                else
                {
                    if (memo is null ||string.IsNullOrWhiteSpace(memo.Title)||string.IsNullOrEmpty(memo.Content))
                    {
                        eventAggregator.SendMessage(new Common.Event.MessageModel { Message = "新增失败！标题或内容不能为空" });
                        return;
                    }
                    var addResult = await memoService.AddAsync(memo);
                    if (addResult.Status)
                    {
                        SummaryDto.MemoList.Add(addResult.Result);
                        refresh();
                        eventAggregator.SendMessage(new Common.Event.MessageModel { Message = "新增成功！" });
                    }
                }
            }
        }
        private void navigate(TaskBar obj)
        {
            if (string.IsNullOrWhiteSpace(obj.Target))
                return;
            NavigationParameters param = new NavigationParameters();
            if (obj.Title == "已完成")
            {
                param.Add("Value", 2);
            }
            regionManager.Regions[PrismManager.MainViewRegionName].RequestNavigate(obj.Target, param);
        }
        void CreateTaskBars()
        {
            TaskBars.Add(new TaskBar { Color = "#FF0CA0FF", Content = "9", Icon = "ClockFast", Target = "TodoView", Title = "汇总" });
            TaskBars.Add(new TaskBar { Color = "#FF1ECA3A", Content = "9", Icon = "ClockCheckOutline", Target = "TodoView", Title = "已完成" });
            TaskBars.Add(new TaskBar { Color = "#FF02C6DC", Content = "100%", Icon = "CalendarTextOutline", Target = "ChartLineVariant", Title = "完成率" });
            TaskBars.Add(new TaskBar { Color = "#FFFFA000", Content = "19", Icon = "CalendarTextOutline", Target = "MemoView", Title = "备忘录" });
        }
        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            base.OnNavigatedTo(navigationContext);
            refresh();               
        }
        async void refresh()
        {
            var summaryRes = await todoService.GetSummary();

            if (summaryRes.Status)
            {
                SummaryDto = summaryRes.Result;
            }
            TaskBars[0].Content = SummaryDto.Sum.ToString();
            TaskBars[1].Content = SummaryDto.CompletedCount.ToString();
            TaskBars[2].Content = SummaryDto.CompletedRatio;
            TaskBars[3].Content = SummaryDto.MemoCount.ToString();

        }
    }

}
