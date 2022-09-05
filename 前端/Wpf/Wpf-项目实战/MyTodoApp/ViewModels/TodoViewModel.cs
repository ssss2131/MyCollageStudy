
using MyTodo.Shared.Dtos;
using MyTodo.Shared.Parameter;
using MyTodoApp.Service;
using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MyTodoApp.ViewModels
{
    public class TodoViewModel: NavigationViewModel
    {     
        public TodoViewModel(ITodoService service, IContainerProvider provider)
            :base(provider)
        {
            this.service = service;
            ExecuteCommand = new DelegateCommand<string>(Execute);
            SelectedCommand = new DelegateCommand<TodoDto>(selected);
            DeleteCommand = new DelegateCommand<TodoDto>(delete);
        }

    
      

        private ObservableCollection<MyTodo.Shared.Dtos.TodoDto> todoDtos;
        private bool isRightDrawerOpen;
        private readonly ITodoService service;
        private TodoDto currentDto;
        private string search;
        private int selectIndex;

      
        public DelegateCommand<string> ExecuteCommand { get; private set; }
        public DelegateCommand<TodoDto> SelectedCommand { get; private set; }
        public DelegateCommand<TodoDto> DeleteCommand { get; private set; }
        public string Search
        {
            get { return search; }
            set { search = value; }
        }

        public int SelectIndex
        {
            get { return selectIndex; }
            set
            {
                selectIndex = value;
                RaisePropertyChanged();
            }
        }

        public TodoDto CurrentDto
        {
            get { return currentDto; }
            set { currentDto = value; 
                RaisePropertyChanged(); 
            }
        }

        public bool IsRightDrawerOpen
        {
            get { return isRightDrawerOpen; }
            set { isRightDrawerOpen = value;
                RaisePropertyChanged();
            }
        }


        public ObservableCollection<MyTodo.Shared.Dtos.TodoDto> TodoDtos
        {
            get { return todoDtos; }
            set { todoDtos = value;
                RaisePropertyChanged();
            }
        }
        async void GetDataAsync()
        {
            UpdateLoading(true);
            int? status = SelectIndex == 0 ? null : SelectIndex == 1 ? 1 : 0;
            TodoDtos = new ObservableCollection<MyTodo.Shared.Dtos.TodoDto>();
            var todoResult = await service.GetAllFilterAsync(new FilterQueryParameter()
            {
                PageIndex = 0,
                PageSize = 100,
                Status = status
            }) ;
            if (todoResult.Status)
            {
                TodoDtos.Clear();
                foreach (var item in todoResult.Result.Items)
                {
                    TodoDtos.Add(item);
                }
            }
            UpdateLoading(false);
        }
        private void add()
        {
            CurrentDto = new TodoDto();
            IsRightDrawerOpen = !IsRightDrawerOpen;
        }
        private async void selected(TodoDto obj)
        {
            try
            {
                UpdateLoading(true);
                var todoResult = await service.GetFirstOfDefaultAsync(obj.Id);
                if (todoResult.Status)
                {
                    CurrentDto = todoResult.Result;
                    IsRightDrawerOpen = true;
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                UpdateLoading(false);
            }
         
        }    
        private void Execute(string obj)
        {
            switch (obj)
            {
                case "新增":
                    add();
                    break;
                case "查询":
                    query();
                    break;
                case "更新":
                    update();
                    break;
               
            }
        }
    
        private async void update()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(CurrentDto.Title) || string.IsNullOrWhiteSpace(CurrentDto.Content))
                    return;
                if (currentDto.Id > 0)
                {
                    //更新
                    var updateResult = await service.UpdateAsync(CurrentDto);
                    if (updateResult.Status)
                    {
                        var todo = TodoDtos.FirstOrDefault(c => c.Id.Equals(CurrentDto.Id));

                        if (todo != null)
                        {
                            todo.Title = CurrentDto.Title;
                            todo.Content = CurrentDto.Content;
                            todo.Status = CurrentDto.Status;
                        }
                    }
                }
                else
                {
                    //新增
                    var addResult = await service.AddAsync(currentDto);

                    if (addResult.Status)
                    {
                        TodoDtos.Add(addResult.Result);
                        IsRightDrawerOpen = false;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                IsRightDrawerOpen = false;
            }

        }

        private async void query()
        {
            TodoDtos.Clear();
            int? status = selectIndex == 0 ? null : selectIndex == 1 ? 1 : 0;
            var todoResult = await service.GetAllFilterAsync(new FilterQueryParameter() { PageIndex = 0, PageSize = 100, Search = Search, Status = status });
            if (todoResult.Status)
            {
                foreach (var item in todoResult.Result.Items)
                {
                    TodoDtos.Add(item);
                }
            }
        }
        private async void delete(TodoDto obj)
        {
            var delResult = await service.DeleteAsync(id: obj.Id);
            if (delResult.Status)
            {
                var model = TodoDtos.FirstOrDefault(t => t.Id.Equals(obj.Id));
                TodoDtos.Remove(obj);
            }
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            base.OnNavigatedTo(navigationContext);
   
            if (navigationContext.Parameters.GetValue<int>("Value")> 0)
            {
                SelectIndex = navigationContext.Parameters.GetValue<int>("Value");
            }
            else
            {
                SelectIndex = 0;
            }
            GetDataAsync();
        }
    }
}
