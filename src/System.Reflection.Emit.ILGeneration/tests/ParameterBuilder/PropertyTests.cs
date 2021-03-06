// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Xunit;

namespace System.Reflection.Emit.Tests
{
    public class PropertyTests
    {
        [Fact]
        public void Properties()
        {
            TypeBuilder type = Helpers.DynamicType(TypeAttributes.Public);
            MethodBuilder methodBuilder = type.DefineMethod("TestMethod", MethodAttributes.Public, typeof(void), new Type[] { typeof(int?) });
            ILGenerator generator = methodBuilder.GetILGenerator();
            generator.Emit(OpCodes.Ret);
            ParameterBuilder parameter = methodBuilder.DefineParameter(1, ParameterAttributes.In, "paramName");

            Assert.Equal(ParameterAttributes.In, (ParameterAttributes)parameter.Attributes);
            Assert.True(parameter.IsIn);
            Assert.False(parameter.IsOptional);
            Assert.False(parameter.IsOut);
            Assert.Equal("paramName", parameter.Name);
            Assert.Equal(1, parameter.Position);
        }
    }
}
