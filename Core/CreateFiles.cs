using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Core
{
    public class CreateFiles
    {
        string path = @"C:\Files\f";
        Random random = new Random();
        string s = "";

        public delegate void delNew(string name);
        public event delNew Handler_FileCreated;

        public void Run()
        {
            Task.Factory.StartNew(Create10Files);
        }

        public void Create10Files()
        {
            int num;
            s = "";
            for (int j = 0; j < 1000; j++)
            {
                s += "* ";
            }
            for (int i = 0; i < 10; i++)
            {
                num = random.Next(100, 10000);
                File.WriteAllText($"{path}{num}.txt", s);
            }
        }

        public void Run5Threads()
        {
            for (int i = 0; i < 5; i++)
            {
                Run();
            }
        }


        public async void CreateNDelete10Files()
        {
            s = "";
            for (int j = 0; j < 1000; j++)
            {
                s += "* ";
            }
            for (int i = 0; i < 10; i++)
            {
                string name = await CreateOneFile();

                //File.Delete(path + name);         //8.3

                await Task.Factory.StartNew(() =>   //9-10
                {
                    File.Delete(path + name);
                });

                //Task.Factory.StartNew(async() =>
                //{
                //    File.Delete(path + await CreateOneFile());
                //});
            }
        }

        public Task<string> CreateOneFile()
        {
            Task<string> taskRet = Task.Factory.StartNew(() =>
            {
                int num = random.Next(100, 10000);
                string name = $"{num}.txt";
                File.WriteAllText(path + name, s);
                //Handler_FileCreated(name);
                return name;
            });
            System.Threading.Thread.Sleep(2000);
            return taskRet;
        }



        //public void DeleteOneFile(string name)  //del
        //{
        //    File.Delete(path + name);
        //}
    }
}
