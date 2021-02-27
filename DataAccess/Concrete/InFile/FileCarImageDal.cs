using Core.DataAccess.Abstract;
using Entities.Concrete.Properties;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.InFile
{
    public class FileCarImageDal : IFileRepository<CarImage>
    {
        string _archivePath;

        public FileCarImageDal(string archivePath)
        {
            _archivePath = archivePath;
        }
        public void Add(CarImage entity)
        {
            string fileName = entity.Name;
            string filePath = System.IO.Path.Combine(_archivePath, fileName);

            if (!System.IO.File.Exists(filePath))
            {
                using (System.IO.FileStream fs = System.IO.File.Create(filePath))
                {
                    for (byte i = 0; i < 100; i++)
                    {
                        fs.WriteByte(i);
                    }
                }
            }
        }

        public void Delete(CarImage entity)
        {
            string fileName = entity.Name;
            string filePath = System.IO.Path.Combine(_archivePath, fileName);

            if (System.IO.File.Exists(filePath))
            {
                try
                {
                    System.IO.File.Delete(filePath);
                }
                catch (System.IO.IOException e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
            }
        }

        public void Update(CarImage entity)
        {
            string fileName = entity.Name;
            string filePath = System.IO.Path.Combine(_archivePath, fileName);

            if (System.IO.File.Exists(filePath))
            {
                using (System.IO.FileStream fs = System.IO.File.Create(filePath))
                {
                    for (byte i = 0; i < 100; i++)
                    {
                        fs.WriteByte(i);
                    }
                }
            }
        }

    }
}
