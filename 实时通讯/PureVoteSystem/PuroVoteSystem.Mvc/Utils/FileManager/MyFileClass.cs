namespace PuroVoteSystem.Mvc.Utils.FileManager
{
    public static class MyFileClass
    {
        public static string GetFileName(IFormFile file, IWebHostEnvironment evn )
        {
            var uniqueFileName = "default.jpg";
            if (file != null)
            {
                uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            }
 
            return uniqueFileName;
        }
        //文件上传
        public static async Task  FileUpLoadAsync(IFormFile file, string fileName, IWebHostEnvironment evn)
        {
            var uploadFolder = Path.Combine(evn.WebRootPath, "Image/DefaultAvator");//获取wwwroot下的图片资源根路径

            var filePath = Path.Combine(uploadFolder, fileName);

            await file.CopyToAsync(new FileStream(filePath, FileMode.Create));
        }
        public static void  FileRemove(string fileName, IWebHostEnvironment evn)
        {
            var uploadFolder = Path.Combine(evn.WebRootPath, "Image/DefaultAvator");//获取wwwroot下的图片资源根路径
            var filePath = Path.Combine(uploadFolder, fileName);
         　
            File.Delete(filePath);
        }
    }
}
