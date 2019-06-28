using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HeYang.DecodeASPX
{
    public class DoAspx
    {


        public static void Start() {
            DirectoryInfo dir = new DirectoryInfo(Config.ASPXPath);
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
            if (file.Extension == ".aspx" || file.Extension == ".ascx" || file.Extension == ".ashx" || file.Extension == ".asax")
            {
                string path = file.FullName.Replace(Config.ASPXPath, "").Substring(1);

                path = System.IO.Path.Combine(Config.Target, path);
                {
                    FileInfo targetFile = new FileInfo(path);
                    if (!Directory.Exists(targetFile.DirectoryName))
                        Directory.CreateDirectory(targetFile.DirectoryName);
                }

                string sourceCode = File.ReadAllText(file.FullName, Encoding.UTF8);
                File.WriteAllText(path, sourceCode, Encoding.UTF8);
            }
             
        }


    }
}
