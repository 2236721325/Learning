using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace 反射实现IOC.Iocs
{

    public class MyIOCContainer : IMyIOCContainer
    {
        private readonly Dictionary<string, Type> MyContianerDictionary = new Dictionary<string, Type>();

        /// <summary>
        /// 保存将抽象类型名称和实体类类型保存到字典
        /// </summary>
        /// <typeparam name="TFrom"></typeparam>
        /// <typeparam name="TTo"></typeparam>
        public void ResolveType<TFrom, TTo>()
        {
            MyContianerDictionary.Add(typeof(TFrom).FullName, typeof(TTo));
        }

        /// <summary>
        /// 创建对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Resolve<T>()
        {
            Type type = MyContianerDictionary[typeof(T).FullName];
            return (T)CreateObject(type);
        }

        public object CreateObject(Type type)
        {
            //获取构造函数
            ConstructorInfo[] cons = type.GetConstructors();

            List<object> paraList = new List<object>();

            //如果构造函数数量大于0
            if (cons.Count() > 0)
            {
                //选择参数数量最多的构造函数
                ConstructorInfo con = cons.OrderByDescending(c => c.GetParameters().Length).FirstOrDefault();
                foreach (ParameterInfo para in con.GetParameters())
                {
                    Type paraType = para.ParameterType;
                    //字典容器查询出具体的参数对象类型
                    Type targetType = MyContianerDictionary[paraType.FullName];
                    //递归实例化所有参数对象，以及其依赖的对象，并添加到数组中
                    paraList.Add(this.CreateObject(targetType));
                }
            }

            //返回对象
            return Activator.CreateInstance(type, paraList.ToArray());
        }
    }
};
