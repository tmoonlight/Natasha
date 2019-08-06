﻿using System;
using System.Reflection;

namespace Natasha.Template
{
    public class MethodReturnTemplate<T>: MethodAsyncTemplate<T>
    {

        public string MethodReturnScript;
        public Type ReturnType;


        /// <summary>
        /// 设置返回类型
        /// </summary>
        /// <typeparam name="T">返回类型</typeparam>
        /// <returns></returns>
        public T Return<S>()
        {

            return Return(typeof(S));

        }




        public T Return(MethodInfo info)
        {

            return Return(info.ReturnType);

        }




        public T Return(Type type = null)
        {

            if (type == null)
            {

                type = typeof(void);
                ReturnType = type;

            }
            else if(type.IsGenericType)
            {

                UsingRecoder.Add(type.GetAllGenericTypes());

            }


            UsingRecoder.Add(type);
            MethodReturnScript = type.GetDevelopName()+" ";
            return Link;

        }

        public override T Builder()
        {

            base.Builder();
            _script.Append(MethodReturnScript);
            return Link;

        }

    }

}
