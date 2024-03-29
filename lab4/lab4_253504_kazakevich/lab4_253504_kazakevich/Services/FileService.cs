﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab4_253504_kazakevich.Interfaces;

namespace lab4_253504_kazakevich.Services
{
    internal class FileService<T> : IFileService<T>
    {
        private static readonly List<string> extensions
            = new() { "txt", "rtf", "dat", "inf" };

        public ISerializer<T>? Serializer { get; set; }

        public IEnumerable<T> ReadFile(string fileName)
            => Serializer!.Deserialize(fileName);

        public void SaveData(IEnumerable<T> data, string fileName)
        {
            var file = new FileInfo(fileName);
            if (file.Exists)
                file.Delete();
            file.Create().Close();
            Serializer!.Serialize(data, fileName);
        }

        public void CreateFilesWithRandomNames(string path, int count)
        {
            for (int i = 0; i < count; i++)
            {
                string fileName =
                    $"{Path.GetRandomFileName().Split(".")[0]}." +
                    $"{extensions[new Random().Next(extensions.Count)]}";
                File.Create(path + fileName).Close();
            }
        }
    }
}
