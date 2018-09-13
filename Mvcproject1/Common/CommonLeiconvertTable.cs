﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;
namespace Common
{
    public class CommonLeiconvertTable<T> where T : new()
    {
        //将Datatable转换为实体
        public List<T> ConvertToList(DataTable dt)
        {
            var list = new List<T>();
            if (0 == dt.Rows.Count)
            {
                return list;
            }
            //获得此模型的可写公共属性
            IEnumerable<PropertyInfo> propertys = new T().GetType().GetProperties().Where(u => u.CanWrite);
            list = ConvertToEntity(dt, propertys);
            return list;
        }
        /// <summary>
        ///     将DataTable的首行转换为实体
        ///     作者: oldman
        ///     创建时间: 2015年9月13日
        /// </summary>
        /// <param name="dt">待转换的DataTable</param>
        /// <returns></returns>
        public T ConvertToEntity(DataTable dt)
        {
            DataTable dtTable = dt.Clone();
            dtTable.Rows.Add(dt.Rows[0].ItemArray);
            return ConvertToList(dtTable)[0];
        }
        private List<T> ConvertToEntity(DataTable dt, IEnumerable<PropertyInfo> propertys)
        {
            var list = new List<T>();
            //遍历DataTable中所有的数据行  
            foreach (DataRow dr in dt.Rows)
            {
                var entity = new T();

                //遍历该对象的所有属性  
                foreach (PropertyInfo p in propertys)
                {
                    //将属性名称赋值给临时变量
                    string tmpName = p.Name;

                    //检查DataTable是否包含此列（列名==对象的属性名）    
                    if (!dt.Columns.Contains(tmpName)) continue;
                    //取值  
                    object value = dr[tmpName];
                    //如果非空，则赋给对象的属性  
                    if (value != DBNull.Value)
                    {
                        p.SetValue(entity, value, null);
                    }
                }
                //对象添加到泛型集合中  
                list.Add(entity);
            }
            return list;
        }
    }
}
