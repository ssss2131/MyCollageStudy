
using MyTodo.Shared.Dtos;
using MyTodo.Shared.Parameter;
using MyTodoApp.Service;
using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTodoApp.ViewModels
{
    public class MemoViewModel: NavigationViewModel
    {
        public MemoViewModel(IMemoService service,IContainerProvider provider)
            :base(provider)
        {
            this.service = service;

            ExecuteCommand = new DelegateCommand<string>(execute);  
            SelectedCommand = new DelegateCommand<MemoDto>(select);
            DeleteCommand = new DelegateCommand<MemoDto>(delete);
        }

     
        private ObservableCollection <MemoDto> memoDtos;
        private bool isRightDrawerOpen;
        private readonly IMemoService service;
        private MemoDto currentDto;
        private string search;

        public string Search
        {
            get { return search; }
            set { search = value;
                RaisePropertyChanged();
            }
        }

        public MemoDto CurrentDto
        {
            get { return currentDto; }
            set { currentDto = value;
                RaisePropertyChanged();
            }
        }


        public DelegateCommand<MemoDto> SelectedCommand { get;private set; }
        public DelegateCommand<MemoDto> DeleteCommand { get; private set; }
        public DelegateCommand<string> ExecuteCommand { get; private set; }

        public bool IsRightDrawerOpen
        {
            get { return isRightDrawerOpen; }
            set
            {
                isRightDrawerOpen = value;
                RaisePropertyChanged();
            }
        }

  
        public ObservableCollection<MemoDto> MemoDtos
        {
            get { return memoDtos; }
            set
            {
                memoDtos = value;
                RaisePropertyChanged();
            }
        }
        private void execute(string obj)
        {
            switch (obj)
            {
                case "新增":
                    add();
                    break;
                case "更新":
                    update();
                    break;
                case "查询":
                    query();
                    break;
            }
        }
        async void GetDataAsync()
        {
            try
            {
                UpdateLoading(true);
                MemoDtos = new ObservableCollection<MemoDto>();
                var memoResult = await service.GetAllAsync(new QueryParameter()
                {
                    PageIndex = 0,
                    PageSize = 100
                });
                if (memoResult.Status)
                {
                    MemoDtos.Clear();
                    foreach (var item in memoResult.Result.Items)
                    {
                        MemoDtos.Add(item);

                    }
                    UpdateLoading(false);
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                UpdateLoading(false);
            }
         
        }
        private void add()
        {
            CurrentDto = new MemoDto();
            IsRightDrawerOpen = !IsRightDrawerOpen;
        }
        private async void update()
        {
            try
            {
                UpdateLoading(true);
                if (string.IsNullOrWhiteSpace(CurrentDto.Title) || string.IsNullOrWhiteSpace(CurrentDto.Content))
                    return;
                else if (CurrentDto.Id > 0)
                {
                    //修改
                    var updateResult = await service.UpdateAsync(CurrentDto);
                    if (updateResult.Status)
                    {
                        var memo = MemoDtos.FirstOrDefault(t => t.Id.Equals(CurrentDto.Id));
                        if (memo != null)
                        {
                            memo.Title = CurrentDto.Title;
                            memo.Content = CurrentDto.Content;
                        }
                        UpdateLoading(false);
                    }
                }
                else
                {
                    //新增
                    var addResult = await service.AddAsync(CurrentDto);
                    if (addResult.Status)
                    {
                        MemoDtos.Add(addResult.Result);
                        isRightDrawerOpen = false;
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
                UpdateLoading(false);
            }
          
                
        }
        private async void select(MemoDto obj)
        {
            try
            {              
                var memoResult = await service.GetFirstOfDefaultAsync(obj.Id);
                if (memoResult.Status)
                {
                    CurrentDto = memoResult.Result;
                    IsRightDrawerOpen = true;
                }

            }
            catch (Exception)
            {

                throw;
            }
            

        }
        private async void delete(MemoDto obj)
        {
            try
            {
                UpdateLoading(true);
                var delResult = await service.DeleteAsync(id: obj.Id);
                if (delResult.Status)
                {
                    MemoDtos.Remove(MemoDtos.FirstOrDefault(c => c.Id.Equals(obj.Id)));
                    UpdateLoading(false);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                UpdateLoading(false);
            }
         
        }
        private async void query()
        {
            try
            {
                UpdateLoading(true);
                var queryResult = await service.GetAllAsync(new QueryParameter()
                {
                    PageIndex = 0,
                    PageSize = 100,
                    Search = this.Search
                });
                if (queryResult.Status)
                {
                    MemoDtos.Clear();
                    foreach (var item in queryResult.Result.Items)
                    {
                        MemoDtos.Add(item);
                    }
                    UpdateLoading(false);
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                UpdateLoading(false);
            }
           
        }



        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            base.OnNavigatedTo(navigationContext);
       
            GetDataAsync(); 
        }
    }
}
