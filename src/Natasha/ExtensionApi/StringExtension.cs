﻿using System;

namespace Natasha.Method
{
    public static class StringExtension
    {
        public static T CreateUsingStrings<T>(this string instance,params string[] usings) where T : Delegate
        {
            return DelegateOperator<T>.CreateUsingStrings(instance, usings);
        }
        public static T Create<T>(this string instance,params Type[] types) where T : Delegate
        {
            return DelegateOperator<T>.Create(instance, types);
        }
        public static FastMethodOperator FastOperator(this string instance, params Type[] types)
        {
            var builder = FastMethodOperator.New;
            builder.UsingRecoder.Add(types);
            return builder.MethodBody(instance);
        }
    }
}
