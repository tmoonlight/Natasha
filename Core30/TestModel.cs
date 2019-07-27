using System;
using System.Collections.Generic;
using System.Text;

namespace Core30
{

    public abstract class AbsTest {

        public abstract T Get<T>();
    }
    //public class TestModel:AbsTest
    //{
    //    public int Age;
    //    public string Name;

    //    public override T Get<T>()
    //    {
    //        if (Age is T)
    //        {
    //            return Age;
    //        }
    //        else if (Name is T)
    //        {
    //            return Name;
    //        }
    //    }
    //}
}
