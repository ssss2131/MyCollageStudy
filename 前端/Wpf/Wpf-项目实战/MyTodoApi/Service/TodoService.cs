using AutoMapper;
using Microsoft.AspNetCore.Mvc.Formatters;
using MyTodo.Shared;
using MyTodo.Shared.Dtos;
using MyTodo.Shared.Parameter;
using MyTodoApi.Context;
using MyTodoApi.Context.UnitOfWork;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace MyTodoApi.Service
{
    public class TodoService : ITodoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TodoService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ApiResponse> AddAsync(TodoDto model)
        {
            try
            {
                var todo = _mapper.Map<ToDo>(model);
                todo.CreateDate = DateTime.Now;
                await _unitOfWork.GetRepository<ToDo>().InsertAsync(todo);
                if (await _unitOfWork.SaveChangesAsync() > 0)
                {
                   return new ApiResponse(true, todo);
                }
                return new ApiResponse(false, "添加数据失败");
            }
            catch (System.Exception ex)
            {
                return new ApiResponse(ex.Message);
            }
          
        }

        public async Task<ApiResponse> DeleteAsync(int id)
        {
            try
            {
                var repository = _unitOfWork.GetRepository<ToDo>();
                var todo = await repository.GetFirstOrDefaultAsync(predicate:c => c.Id.Equals(id));
                if (todo != null)
                {
                    repository.Delete(todo);
                    if (await _unitOfWork.SaveChangesAsync() > 0)
                    {
                        return new ApiResponse(true, todo);
                    }
                    return new ApiResponse("删除失败");
                }
                return new ApiResponse("删除失败");
            }
            catch (System.Exception ex)
            {
                return new ApiResponse(ex.Message);
            }
        }

        public async Task<ApiResponse> GetAllAsync(QueryParameter parameter)
        {
            try
            {
                var res = await _unitOfWork.GetRepository<ToDo>().GetPagedListAsync(predicate: x => string.IsNullOrWhiteSpace(parameter.Search) ? true : x.Title.Contains(parameter.Search),
                    pageIndex: parameter.PageIndex,
                    pageSize: parameter.PageSize,
                    orderBy: source => source.OrderByDescending(t => t.CreateDate));
                return new ApiResponse(true, res);
            }
            catch (System.Exception ex)
            {
                return new ApiResponse(ex.Message);
            }
        }

        public async Task<ApiResponse> GetAllAsync(FilterQueryParameter parameter)
        {
            try
            {
                var res = await _unitOfWork.GetRepository<ToDo>().GetPagedListAsync(predicate: x => (string.IsNullOrWhiteSpace(parameter.Search) ? true : x.Title.Contains(parameter.Search))&&(parameter.Status==null?true: x.Status.Equals(parameter.Status)),           
                    pageIndex: parameter.PageIndex,
                    pageSize: parameter.PageSize,
                    orderBy: source => source.OrderByDescending(t => t.CreateDate));
                return new ApiResponse(true, res);
            }
            catch (System.Exception ex)
            {
                return new ApiResponse(ex.Message);
            }
        }

        public async Task<ApiResponse> GetSingleAsync(int id)
        {
            try
            {
                var res = await _unitOfWork.GetRepository<ToDo>().GetFirstOrDefaultAsync(predicate: c => c.Id.Equals(id));
                if(res != null)
                {
                    return new ApiResponse(true, res);
                }
                return new ApiResponse(false, "not data");
            }
            catch (System.Exception ex)
            {
                return new ApiResponse(ex.Message);
            }
        }

        public async Task<ApiResponse> Summary()
        {
            try
            {
                var todos = await _unitOfWork.GetRepository<ToDo>().GetAllAsync(orderBy: source => source.OrderByDescending(c => c.CreateDate));
                var memos = await _unitOfWork.GetRepository<Memo>().GetAllAsync(orderBy: source => source.OrderByDescending(c => c.CreateDate));

                SummaryDto summary = new SummaryDto();
                summary.Sum = todos.Count();
                summary.CompletedCount = todos.Where(t => t.Status == 1).Count();
                summary.MemoCount = memos.Count();
                summary.CompletedRatio = (summary.CompletedCount / (double)summary.Sum).ToString("0%");
                summary.TodoList = new ObservableCollection<TodoDto>(_mapper.Map<List<TodoDto>>(todos.Where(t => t.Status == 0)));
                summary.MemoList = new ObservableCollection<MemoDto>(_mapper.Map<List<MemoDto>>(memos));
                return new ApiResponse(true, summary);
            }
            catch (Exception ex)
            {
                return new ApiResponse(ex.Message);
            }
          
        }

        public async Task<ApiResponse> UpdateAsync(TodoDto model)
        {
            try
            {
                var todo = await _unitOfWork.GetRepository<ToDo>().GetFirstOrDefaultAsync(predicate: c => c.Id.Equals(model.Id));
                if (todo != null)
                {
                    todo.Title = model.Title;
                    todo.Content = model.Content;
                    todo.UpdateDate = DateTime.Now;
                    todo.Status = model.Status;

                    _unitOfWork.GetRepository<ToDo>().Update(todo);
                    if (await _unitOfWork.SaveChangesAsync() > 0)
                    {
                        return new ApiResponse(true, todo);
                    }
                    return new ApiResponse(false, todo);
                }
                return new ApiResponse("更新数据异常");
            }
            catch (System.Exception ex)
            {
                return new ApiResponse(ex.Message);
            }
        }
    }
}
