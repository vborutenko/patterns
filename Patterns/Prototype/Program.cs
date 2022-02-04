using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    /// <summary>
    /// Prototype is a creational design pattern that lets you copy
    /// existing objects without making your code dependent on their classes.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Person
    {
        public int Age;
        public DateTime BirthDate;
        public string Name;
        public IdInfo IdInfo;

        public Person ShallowCopy()
        {
            return (Person) this.MemberwiseClone();
        }

        public Person DeepCopy()
        {
            Person clone = (Person) this.MemberwiseClone();
            clone.IdInfo = new IdInfo(IdInfo.IdNumber);
            clone.Name = String.Copy(Name);
            return clone;
        }
    }

    public class IdInfo
    {
        public int IdNumber;

        public IdInfo(int idNumber)
        {
            this.IdNumber = idNumber;
        }
    }


    public abstract class AbstractCloneable : ICloneable
    {
        public object Clone()
        {
            var clone = (AbstractCloneable) this.MemberwiseClone();
            HandleCloned(clone);
            return clone;
        }

        protected virtual void HandleCloned(AbstractCloneable clone)
        {
            //Nothing particular in the base class, but maybe useful for children.
            //Not abstract so children may not implement this if they don't need to.
        }
    }


    public class ConcreteCloneable : AbstractCloneable
    {
        public IdInfo IdInfo { get; set; }
        protected override void HandleCloned(AbstractCloneable clone)
        {
            //Get whathever magic a base class could have implemented.
            base.HandleCloned(clone);

            //Clone is of the current type.
            ConcreteCloneable obj = (ConcreteCloneable) clone;

            //Here you have a superficial copy of "this". You can do whathever 
            //specific task you need to do.
            //e.g.:
            obj.IdInfo = new IdInfo(1);
        }
    }


}
