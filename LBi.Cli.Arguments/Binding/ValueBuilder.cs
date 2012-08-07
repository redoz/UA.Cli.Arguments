/*
 * Copyright 2012 LBi Netherlands B.V.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License. 
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using LBi.Cli.Arguments.Parsing.Ast;

namespace LBi.Cli.Arguments.Binding
{
    public class ValueBuilder : IAstVisitor, IDisposable
    {

        private readonly Stack<Type> _targetType;
        private readonly List<TypeError> _errors;
        private readonly CultureInfo _culture;
        private object _value;
        private static TypeDescriptionProvider _typeDescriptorProvider;

        public ValueBuilder()
            : this(CultureInfo.InvariantCulture)
        {
            // register custom BooleanTypeConverter
            TypeConverterAttribute converterAttribute = new TypeConverterAttribute(typeof(CustomBooleanConverter));
            _typeDescriptorProvider = TypeDescriptor.AddAttributes(typeof(Boolean), converterAttribute);
        }

        public ValueBuilder(CultureInfo cultureInfo)
        {
            this._culture = cultureInfo;
            this._errors = new List<TypeError>();
            this._targetType = new Stack<Type>();
        }

        public bool Build(Type propertyType, AstNode astNode)
        {
            this._targetType.Push(propertyType);

            astNode.Visit(this);


            return this._errors.Count == 0;
        }

        public IEnumerable<TypeError> Errors { get { return this._errors; } }

        public object Value
        {
            get { return _value; }
        }

        private bool TryConvertType(Type targetType, object input, out object output)
        {
            bool ret = false;
            output = null;
            if (targetType.IsInstanceOfType(input))
            {
                output = input;
                ret = true;
            }
            else
            {
                var targetConverter = TypeDescriptor.GetConverter(targetType);
                var sourceConverter = TypeDescriptor.GetConverter(input);
                if (targetConverter.CanConvertFrom(input.GetType()))
                {
                    output = targetConverter.ConvertFrom(null, this._culture, input);
                    ret = true;
                }
                else if (sourceConverter.CanConvertTo(targetType))
                {
                    output = sourceConverter.ConvertTo(null, this._culture, input, targetType);
                    ret = true;
                }
                else
                {

                    try
                    {
                        output = Convert.ChangeType(input, targetType, this._culture);
                        ret = true;
                    }
                    catch (InvalidCastException)
                    {
                    }
                    catch (FormatException)
                    {
                    }
                    catch (OverflowException)
                    {
                    }
                    catch (ArgumentNullException)
                    {
                    }

                    if (!ret)
                    {
                        // attempt round-trip to string
                        if (targetConverter.CanConvertFrom(typeof(string)))
                        {
                            string tmp;
                            if (sourceConverter.CanConvertTo(typeof(string)))
                                tmp = sourceConverter.ConvertToString(null, this._culture, input);
                            else
                                tmp = input.ToString();

                            output = targetConverter.ConvertFromString(null, this._culture, tmp);
                            ret = true;
                        }
                    }
                }
            }

            return ret;
        }


        #region Implementation of IAstVisitor

        void IAstVisitor.Visit(LiteralValue literalValue)
        {
            switch (literalValue.Type)
            {
                case LiteralValueType.Numeric:
                    // this looks pretty evil
                    sbyte signedByte;
                    if (sbyte.TryParse(literalValue.Value, NumberStyles.Any, _culture, out signedByte))
                        this._value = signedByte;
                    else
                    {
                        byte usignedByte;
                        if (byte.TryParse(literalValue.Value, NumberStyles.Any, _culture, out usignedByte))
                            this._value = usignedByte;
                        else
                        {
                            short signedShort;
                            if (short.TryParse(literalValue.Value, NumberStyles.Any, _culture, out signedShort))
                                this._value = signedShort;
                            else
                            {
                                ushort unsignedShort;
                                if (ushort.TryParse(literalValue.Value, NumberStyles.Any, _culture, out unsignedShort))
                                    this._value = unsignedShort;
                                else
                                {
                                    int signedInt;
                                    if (int.TryParse(literalValue.Value, NumberStyles.Any, _culture, out signedInt))
                                        this._value = signedInt;
                                    else
                                    {
                                        uint unsignedInt;
                                        if (uint.TryParse(literalValue.Value, NumberStyles.Any, _culture, out unsignedInt))
                                            this._value = unsignedInt;
                                        else
                                        {
                                            long signedLong;
                                            if (long.TryParse(literalValue.Value, NumberStyles.Any, _culture, out signedLong))
                                                this._value = signedLong;
                                            else
                                            {
                                                ulong unsignedLong;
                                                if (ulong.TryParse(literalValue.Value, NumberStyles.Any, _culture, out unsignedLong))
                                                    this._value = unsignedLong;
                                                else
                                                {
                                                    Single single;
                                                    if (Single.TryParse(literalValue.Value, NumberStyles.Any, _culture, out single))
                                                        this._value = single;
                                                    else
                                                    {
                                                        Double dble;
                                                        if (Double.TryParse(literalValue.Value, NumberStyles.Any, _culture, out dble))
                                                            this._value = dble;
                                                        else
                                                        {
                                                            Decimal dec;
                                                            if (Decimal.TryParse(literalValue.Value, NumberStyles.Any, _culture, out dec))
                                                                this._value = dec;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    if (!this.TryConvertType(this._targetType.Peek(), this.Value, out this._value))
                    {
                        this._errors.Add(new TypeError(this._targetType.Peek(), this.Value, literalValue));
                    }

                    break;
                case LiteralValueType.String:
                    this._value = literalValue.Value;
                    if (this._targetType.Peek() != typeof(string))
                    {
                        if (!this.TryConvertType(this._targetType.Peek(), this.Value, out this._value))
                        {
                            this._errors.Add(new TypeError(this._targetType.Peek(), this.Value, literalValue));
                        }
                    }
                    break;
                case LiteralValueType.Null:
                    this._value = null;
                    break;
                case LiteralValueType.Boolean:
                    this._value = StringComparer.InvariantCultureIgnoreCase.Equals(literalValue.Value, "$true");
                    if (this._targetType.Peek() != typeof(bool))
                    {
                        if (!this.TryConvertType(this._targetType.Peek(), this.Value, out this._value))
                        {
                            this._errors.Add(new TypeError(this._targetType.Peek(), this.Value, literalValue));
                        }
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }


        void IAstVisitor.Visit(Sequence sequence)
        {
            Type targetType = this._targetType.Peek();
            Type elementType;

            Action<int, object> elementHandler;
            object nextValue;

            if (targetType.IsArray)
            {
                elementType = targetType.GetElementType();
                nextValue = Array.CreateInstance(elementType, sequence.Elements.Length);
                Array newArray = (Array)nextValue;
                elementHandler = (i, o) => newArray.SetValue(o, i);
            }
            else
            {
                if (targetType.IsInterface)
                {
                    if (targetType.IsInterface && targetType == typeof(IEnumerable))
                    {
                        elementType = typeof(object);
                    }
                    else if (targetType.IsInterface &&
                             targetType.IsGenericType &&
                             targetType.GetGenericTypeDefinition() == typeof(IEnumerable<>))
                    {
                        elementType = targetType.GetGenericArguments()[0];
                    }
                    else
                    {
                        // TODO fix this
                        throw new Exception("Unsupported");
                    }

                    nextValue = Activator.CreateInstance(typeof(List<>).MakeGenericType(elementType));
                    MethodInfo addMethod = nextValue.GetType().GetMethod("Add", new[] { elementType });
                    Debug.Assert(addMethod != null, "addMethod is null. Add some error checking here.");
                    elementHandler = (i, o) => addMethod.Invoke(nextValue, new[] { o });
                }
                else
                {
                    MethodInfo addMethod =
                        targetType.GetMethods(BindingFlags.Public | BindingFlags.Instance)
                            .Where(m => StringComparer.InvariantCultureIgnoreCase.Equals("Add", m.Name))
                            .Single(m => m.GetParameters().Length == 1);
                    elementType = addMethod.GetParameters()[0].ParameterType;
                    nextValue = Activator.CreateInstance(targetType);
                    elementHandler = (i, o) => addMethod.Invoke(nextValue, new[] { o });
                }
            }

            this._targetType.Push(elementType);
            for (int elemNum = 0; elemNum < sequence.Elements.Length; elemNum++)
            {
                AstNode element = sequence.Elements[elemNum];
                element.Visit(this);
                elementHandler(elemNum, this.Value);
            }
            this._targetType.Pop();
            this._value = nextValue;
        }

        void IAstVisitor.Visit(AssociativeArray array)
        {
            Type targetType = this._targetType.Peek();
            if (targetType.IsInterface)
            {
                if (targetType.IsGenericType)
                {
                    Type genericTypeDef = targetType.GetGenericTypeDefinition();
                    if (genericTypeDef == typeof(IEnumerable<>))
                    {
                        Type genericTypeArg = targetType.GetGenericArguments()[0];

                        if (genericTypeArg.IsGenericType)
                        {
                            if (genericTypeArg == typeof(KeyValuePair<,>))
                            {
                                
                            } else if (genericTypeArg == typeof(Tuple<,>))
                            {
                                
                            } else
                            {
                                throw new NotSupportedException("Unknown type: " + genericTypeArg.FullName);
                            }
                        } else
                        {
                            
                        }
                    }
                }
            } else
            {
                MethodInfo addMethod = targetType.GetMethods(BindingFlags.Instance | BindingFlags.Public)
                    .FirstOrDefault(
                        m => StringComparer.OrdinalIgnoreCase.Equals("Add", m.Name) &&
                             m.GetParameters().Length == 2);

                if (addMethod == null)
                {
                    // TODO add error
                }

                Type keyType = null;
                Type valueType = null;

                for (int elemNum = 0; elemNum < array.Elements.Length; elemNum++)
                {
                    array.Elements[elemNum].Key.Visit(this);
                    object keyValue = this._value;
                    if (!keyType.IsAssignableFrom(keyValue.GetType()))
                    {
                        if (!this.TryConvertType(keyType, keyValue, out keyValue))
                        {
                            // error
                        }
                    }
                    array.Elements[elemNum].Value.Visit(this);
                    object valueValue = this._value;
                    if (!keyType.IsAssignableFrom(valueType.GetType()))
                    {
                        if (!this.TryConvertType(valueType, keyValue, out keyValue))
                        {
                            // error
                        }
                    }
                }
            }
        }

        #endregion

        #region Implementation of IDisposable

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~ValueBuilder()
        {
            this.Dispose(false);
        }

        protected virtual void Dispose(bool isDisposing)
        {
            if (isDisposing)
            {
                TypeDescriptor.RemoveProvider(_typeDescriptorProvider, typeof(Boolean));
                TypeDescriptor.Refresh(typeof(Boolean));
            }
        }

        #endregion
    }
}