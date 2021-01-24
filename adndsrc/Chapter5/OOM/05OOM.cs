using System;
using System.IO;
using System.Xml.Serialization;

namespace Advanced.NET.Debugging.Chapter5
{

    public class Person
    {
        private string name;
        private string social;
        private int age;

        public string Name 
        { 
            get { return name; } 
            set { this.name=value;} 
        }
        
        public string SocialSecurity 
        { 
            get { return social; } 
            set { this.social= value; } 
        }
        
        public int Age 
        { 
            get { return age; } 
            set { this.age = value; } 
        }

        public Person() {}
        public Person(string name, string ss, int age)
        {
            this.name = name; this.social = ss; this.age = age;
        }
    }

    class OOM
    {
        static void Main(string[] args)
        {
            OOM o = new OOM();
            o.Run();
        }

        public void Run()
        {
            XmlRootAttribute root = new XmlRootAttribute();
            root.ElementName = "MyPersonRoot";
            root.Namespace = "http://www.contoso.com";
            root.IsNullable = true;

            while (true)
            {
                Person p = new Person();
                p.Name = "Mario Hewardt";
                p.SocialSecurity = "xxx-xx-xxxx";
                p.Age = 99;

                XmlSerializer ser = new 
                    XmlSerializer(typeof(Person), root);
                Stream s = new 
                    FileStream("c:\\ser.txt", FileMode.Create);

                ser.Serialize(s, p);
                s.Close();
            }
        }
    }
}