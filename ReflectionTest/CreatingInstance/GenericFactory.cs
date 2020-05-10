using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace ReflectionTest.CreatingInstance
{
    public class GenericFactory<TKey, TType>
    {
        // Constructor işlemlerini tutan dictionary nesnemiz.
        private readonly Dictionary<TKey, Func<object[], TType>> _registeredTypes;

        // Thread safe yapacağımız nesne.
        private object _locker = new object();

        public GenericFactory() {
            _registeredTypes = new Dictionary<TKey, Func<object[], TType>>();
        }

        public void Register(TKey key, params Type[] parameters) {
            ConstructorInfo ci = typeof(TType).GetConstructor(BindingFlags.Public | BindingFlags.Instance, null, CallingConventions.HasThis, parameters, new ParameterModifier[] { });
            if (ci == null)
                throw new InvalidOperationException(string.Format("Constructor for type '{0}' was not found.", typeof(TType)));
            Func<object[], TType> ctor;
            lock (_locker)
            {
                // Servisimizin zaten register edilip edilmediğini belirtiyor.
                if (!_registeredTypes.TryGetValue(key, out ctor))
                {
                    var pExp = Expression.Parameter(typeof(object[]), "arguments"); // Bir parametre expressionu oluşturduk.
                    var ctorParams = ci.GetParameters(); // constructer parametre bilgisini getir.
                    var argExpressions = new Expression[ctorParams.Length]; // Parametre expressionları içeren argümanlar.
                    for (var i = 0; i < parameters.Length; i++)
                    {
                        var indexedAcccess = Expression.ArrayIndex(pExp, Expression.Constant(i));
                        if (!parameters[i].IsClass && !parameters[i].IsInterface)
                        { // Parametrenin bir değer türü olup olmadığını kontrol eder.

                            // öyleyse - parametre değerini depolayacak yerel değişken oluşturmalıyız
                            var localVariable = Expression.Variable(parameters[i], "localVariable");
                            var block = Expression.Block(new[] { localVariable }, 
                                Expression.IfThenElse(Expression.Equal(indexedAcccess, Expression.Constant(null)), 
                                Expression.Assign(localVariable, Expression.Default(parameters[i])), 
                                Expression.Assign(localVariable, Expression.Convert(indexedAcccess, parameters[i]))), localVariable);
                            argExpressions[i] = block;

                        }
                        else 
                            argExpressions[i] = Expression.Convert(indexedAcccess, parameters[i]);
                    }
                    // belirtilen argümanlarla belirtilen ctor çağrısını temsil eden ifade yarat.
                    var newExpr = Expression.New(ci, argExpressions);
                    // delege oluşturmak için ifadeyi derleyin ve sözlüğe işlev ekleyin
                    _registeredTypes.Add(key, Expression.Lambda(newExpr, new[] { pExp }).Compile() as Func<object[], TType>);
                }
            }
        }

        public TType Create(TKey key, params object[] args) {
            Func<object[], TType> foo; if (_registeredTypes.TryGetValue(key, out foo)) { return (TType)foo(args); }
            throw new ArgumentException("No type registered for this key.");
        }
    }
}