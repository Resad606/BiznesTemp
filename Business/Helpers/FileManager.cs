namespace Business.Helpers
{
    public class FileManager
    {
        public static string SaveFile(string rootpath,string filename,IFormFile formFile)
        {
            
            string name = Guid.NewGuid().ToString() + formFile.FileName;
            string path = Path.Combine(rootpath,filename,name);
            using (FileStream fileStream = new FileStream(path, FileMode.Create))
            {
                formFile.CopyTo(fileStream);
            }
                return (name);  
        }
        public static void DeleteFile(string path,string fileName,string image)
        {
            string deletepath = Path.Combine(path,fileName,image);    
            if(System.IO.File.Exists(deletepath))
            {
                System.IO.File.Delete(deletepath);
            }
        }
    }
}
