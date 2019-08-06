﻿using Natasha.Complier;
using System;
using System.Reflection;

namespace Natasha
{
    public static class RuntimeComplier
    {


        /// <summary>
        /// 编译脚本，生成委托
        /// </summary>
        /// <param name="className">类名</param>
        /// <param name="methodName">方法名</param>
        /// <param name="delegateType">委托类型</param>
        /// <returns></returns>
        public static Delegate GetDelegate(string className, string content, string methodName, Type delegateType)
        {

            //获取程序集
            Assembly assembly = ScriptComplierEngine.StreamComplier(content,out _);


            //判空
            if (assembly == null)
            {

                return null;

            }


            //获取方法委托
            return AssemblyOperator
                .Loader(assembly)[className]
                .GetMethod(methodName)
                .CreateDelegate(delegateType);

        }




        /// <summary>
        /// 编译脚本，生成委托
        /// </summary>
        /// <param name="className">类名</param>
        /// <param name="methodName">方法名</param>
        /// <param name="delegateType">委托类型</param>
        /// <returns></returns>
        public static Delegate GetDelegate<T>(string className, string content, string methodName)
        {

            //获取程序集
            Assembly assembly = ScriptComplierEngine.StreamComplier(content,out _);


            //判空
            if (assembly == null)
            {

                return null;

            }


            //获取方法委托
            return AssemblyOperator
                .Loader(assembly)[className]
                .GetMethod(methodName)
                .CreateDelegate(typeof(T));

        }




        /// <summary>
        /// 根据命名空间和类的位置获取类型
        /// </summary>
        /// <param name="content">脚本内容</param>
        /// <param name="classIndex">命名空间里的第index个类</param>
        /// <param name="namespaceIndex">第namespaceIndex个命名空间</param>
        /// <returns></returns>
        public static Type GetClassType(string content, int classIndex = 1, int namespaceIndex = 1)
        {

            //获取程序集
            Assembly assembly = ScriptComplierEngine.FileComplier(content, out _);

            //根据索引获取类名
            string className = ScriptHelper.GetClassName(content, classIndex, namespaceIndex);

            //获取类型
            return AssemblyOperator.Loader(assembly)[className];

        }
        public static Type GetStructType(string content, int structIndex = 1, int namespaceIndex = 1)
        {

            //根据索引获取类名
            string structName = ScriptHelper.GetStructName(content, structIndex, namespaceIndex);


            //获取程序集
            Assembly assembly = ScriptComplierEngine.FileComplier(content, out _);


            //获取类型
            return AssemblyOperator.Loader(assembly)[structName];

        }

    }

}
