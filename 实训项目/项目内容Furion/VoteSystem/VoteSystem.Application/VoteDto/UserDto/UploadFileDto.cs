using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoteSystem.Application.VoteDto.UserDto
{
    public class UploadFileDto
    {
        //用户Id
        public int UserId { get; set; }
        //文件地址
        public string FilePath { get; set; }  
        //文件
        public List<IFormFile> files { get; set; }
    }
}
