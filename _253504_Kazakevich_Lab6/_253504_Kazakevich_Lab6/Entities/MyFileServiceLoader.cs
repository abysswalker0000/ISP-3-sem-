using _253504_Kazakevich_Lab6.Interfaces;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;

namespace _253504_Kazakevich_Lab6.Entities
{
	public class MyFileServiceLoader<T>
	{
		public static IFileService<T> Load(string fileName)
		{
            Assembly asm = Assembly.LoadFrom(@"D:\Other\uni\cSHarp\_253504_Kazakevich_Lab6\FileServiceLib\bin\Debug\net7.0\FileServiceLib.dll");
            var allTypes = asm.GetTypes();
            foreach (var type in allTypes)
            {
                try
                {
                    Type toCreate = type;
                    Type[] typeArgs = { typeof(T) };
                    Type constructed = toCreate.MakeGenericType(typeArgs);
                    var serializer = (IFileService<T>)Activator.CreateInstance(constructed)!;
                    return serializer;
                }
                catch
                {
                    continue;
                }
            }
            throw new Exception("No such class found in given DLL");
		}
	}
}