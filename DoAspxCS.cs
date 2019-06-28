using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HeYang.DecodeASPX
{
    public class DoAspxCS
    {

        public static void Start() {

            DirectoryInfo dir = new DirectoryInfo(Config.ASPXCSPath);
            GetDir(dir);
        }




        public static void GetDir(DirectoryInfo dir)
        {
            FileInfo[] fileInfos = dir.GetFiles();   //目录下的文件
            if (fileInfos != null)
            {
                foreach (var file in fileInfos)
                {
                    DoFiles(file);
                }
            }


            DirectoryInfo[] subDirectories = dir.GetDirectories();//获得目录 
            if (subDirectories != null)
                foreach (DirectoryInfo dirinfo in subDirectories)
                {
                    GetDir(dirinfo);
                }
        }


        public static void DoFiles(FileInfo file)
        {
            if (file.Extension == ".cs")
            {

                string savePath = Config.Target;
                {
                    string folder = file.DirectoryName.Replace(Config.ASPXCSPath, "").Substring(1);
                    var list = folder.Split('.');
                    if (list != null)
                    {
                        foreach (var item in list)
                        {
                            savePath = System.IO.Path.Combine(savePath, item);
                            if (!Directory.Exists(savePath))
                                Directory.CreateDirectory(savePath);

                        }
                    } 
                }
                {

                    if (File.Exists(Path.Combine(savePath, file.Name.Replace(".cs", ".aspx"))))
                        savePath = Path.Combine(savePath, file.Name.Replace(".cs", ".aspx.cs"));
                    else if (File.Exists(Path.Combine(savePath, file.Name.Replace(".cs", ".ascx"))))
                        savePath = Path.Combine(savePath, file.Name.Replace(".cs", ".ascx.cs"));
                    else if (File.Exists(Path.Combine(savePath, file.Name.Replace(".cs", ".ashx"))))
                        savePath = Path.Combine(savePath, file.Name.Replace(".cs", ".ashx.cs")); 
                    else if (File.Exists(Path.Combine(savePath, file.Name.Replace(".cs", ".asax"))))
                        savePath = Path.Combine(savePath, file.Name.Replace(".cs", ".asax.cs"));
                    else
                        savePath = Path.Combine(savePath, file.Name);


                }
               
                 
 
                string sourceCode = File.ReadAllText(file.FullName, Encoding.UTF8);
                File.WriteAllText(savePath, sourceCode, Encoding.UTF8);
            }

        }


    }
}
