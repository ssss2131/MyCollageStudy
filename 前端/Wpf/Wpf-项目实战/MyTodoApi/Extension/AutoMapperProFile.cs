using AutoMapper;
using MyTodo.Shared.Dtos;
using MyTodoApi.Context;

namespace MyTodoApi.Extension
{
    public class AutoMapperProFile:MapperConfigurationExpression
    {
        public AutoMapperProFile()
        {
            CreateMap<ToDo, TodoDto>().ReverseMap();
            CreateMap<Memo, MemoDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
