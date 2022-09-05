using AutoMapper;
using MyTodo.Shared;
using MyTodo.Shared.Dtos;
using MyTodo.Shared.Parameter;
using MyTodoApi.Context;
using MyTodoApi.Context.UnitOfWork;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MyTodoApi.Service
{
    public class MemoService : IMemoService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public MemoService(IMapper mapper,IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<ApiResponse> AddAsync(MemoDto model)
        {
            try
            {
                var memo = _mapper.Map<Memo>(model);
                memo.CreateDate = DateTime.Now;
                await _unitOfWork.GetRepository<Memo>().InsertAsync(memo);
                if (await _unitOfWork.SaveChangesAsync() > 0)
                {
                    return new ApiResponse(true, memo);
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
                var repository = _unitOfWork.GetRepository<Memo>();
                var memo = await repository.GetFirstOrDefaultAsync(predicate: c => c.Id.Equals(id));
                if (memo != null)
                {
                    repository.Delete(memo);
                    if (await _unitOfWork.SaveChangesAsync() > 0)
                    {
                        return new ApiResponse(true, memo);
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

        public async Task<ApiResponse> GetAllAsync(QueryParameter query)
        {
            try
            {
                var res = await _unitOfWork.GetRepository<Memo>().GetPagedListAsync(predicate: x =>
                    string.IsNullOrWhiteSpace(query.Search) ? true : x.Title.Contains(query.Search),
                    pageIndex: query.PageIndex,
                    pageSize: query.PageSize,
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
                var res = await _unitOfWork.GetRepository<Memo>().GetFirstOrDefaultAsync(predicate: c => c.Id.Equals(id));
                if (res != null)
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

        public async Task<ApiResponse> UpdateAsync(MemoDto model)
        {
            try
            {
                var memo = await _unitOfWork.GetRepository<Memo>().GetFirstOrDefaultAsync(predicate: c => c.Id.Equals(model.Id));
                if (memo != null)
                {
                    memo.Title = model.Title;
                    memo.Content = model.Content;
                    memo.UpdateDate = DateTime.Now;

                    _unitOfWork.GetRepository<Memo>().Update(memo);
                    if (await _unitOfWork.SaveChangesAsync() > 0)
                    {
                        return new ApiResponse(true, memo);
                    }
                    return new ApiResponse(false, memo);
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
