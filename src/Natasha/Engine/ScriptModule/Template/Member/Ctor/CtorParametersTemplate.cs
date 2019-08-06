﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Natasha.Template
{
    public class CtorParametersTemplate<T>: CtorNameTemplate<T>
    {

        public readonly List<KeyValuePair<Type, string>> ParametersMappings;
        public readonly List<Type> ParametersTypes;
        public string CtorParametersScript;


        public CtorParametersTemplate()
        {

            ParametersTypes = new List<Type>();
            ParametersMappings = new List<KeyValuePair<Type, string>>();

        }




        public T Parameter(MethodInfo info)
        {

            UsingRecoder.Add(info);
            CtorParametersScript = DeclarationReverser.GetParameters(info).ToString();
            return Link;

        }




        public T Parameter(string parameters)
        {

            CtorParametersScript = parameters;
            return Link;

        }




        public T Parameter(IEnumerable<KeyValuePair<Type, string>> parameters)
        {

            UsingRecoder.Add(parameters.Select(item => item.Key));
            CtorParametersScript = DeclarationReverser.GetParameters(parameters).ToString(); ;
            return Link;

        }




        /// <summary>
        /// 添加参数
        /// </summary>
        /// <typeparam name="S">参数类型</typeparam>
        /// <param name="key">参数名字</param>
        /// <returns></returns>
        public T Param<S>(string key)
        {

            return Param(typeof(S), key);

        }




        /// <summary>
        /// 添加参数
        /// </summary>
        /// <param name="type">参数类型</param>
        /// <param name="key">参数名字</param>
        /// <returns></returns>
        public T Param(Type type, string key)
        {

            ParametersTypes.Add(type);
            UsingRecoder.Add(type);
            ParametersMappings.Add(new KeyValuePair<Type, string>(type, key));
            return Link;

        }




        public override T Builder()
        {

            if (CtorParametersScript == null)
            {
                Parameter(ParametersMappings);
            }
            _script.Append($@"{CtorParametersScript}{{");
            return base.Builder();

        }

    }

}
