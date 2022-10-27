using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace T4CodeGenerator.Utilities
{
    public class Tool
    {
        //不同类型的 项目获取的地址不同 这个是获取控制台项目的项目文件夹。
        public static string GetProjectPath()
        {
            return new DirectoryInfo(Directory.GetCurrentDirectory())
                           .Parent.Parent.Parent.FullName;
          
        }
        //获取所有的程序集（有缺陷）
        public static IEnumerable<Type> GetAllTypes()
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var types = assemblies.SelectMany(e => e.GetTypes());
            return types;
        }
    }
}
