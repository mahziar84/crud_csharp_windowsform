using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD
{
    public class human
    {
        public int id { get; set; }
        public string name { get; set; }
        public string family { get; set; }
        public int age { get; set; }

         db db1 = new db();



        public bool register(human h)
        {
            if(exist(h) == false)
            {
                db1.Humans.Add(h);
                db1.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
            
        }
        public bool exist(human h)
        {
             var a=db1.Humans.Where(i=>i.name==h.name && i.family==h.family && i.age == h.age).ToList();
            if(a.Count == 1)
            {
                return true;
            }
            else 
            {
                return false;
            }  
        }
        public List<human> readAll()
        {
            return db1.Humans.ToList();
        }
        public List<human> readByName(string s)
        {
           return db1.Humans.Where(i=>i.name.Contains(s) || i.family.Contains(s) || (i.age).ToString() == s).ToList();
        }
        public human readbyid(int id)
        {
            return db1.Humans.Where(i => i.id == id).FirstOrDefault();
        }
        public void delete(int id)
        {
           var h = db1.Humans.Where(i => i.id == id).FirstOrDefault();
           db1.Humans.Remove(h);
            db1.SaveChanges();
        }
        public void update(human h,int id)
        {
            //human h1 = readbyid(id);
            //delete(id);
            //  register(h);
            var a2 = db1.Humans.Where(i => i.id == id).FirstOrDefault();
            a2.name = h.name;
            a2.family = h.family;
            a2.age = h.age;
            db1.SaveChanges();

        }
    }
}
