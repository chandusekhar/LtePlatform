﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lte.Domain.Regular
{
    [AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    public sealed class ExcelColumnAttribute : Attribute
    {
        private readonly TransformEnum _transformation;

        public ExcelColumnAttribute(string columnName, TransformEnum transformation = TransformEnum.Default)
        {
            ColumnName = columnName;
            _transformation = transformation;
        }

        public string ColumnName { get; }

        public Func<string, object> Transformation
        {
            get
            {
                //这里可以根据需要增加我们的转换规则
                switch (_transformation)
                {
                    case TransformEnum.IntegerDefaultToZero:
                        return x => x.ToString().ConvertToInt(0);
                    case TransformEnum.IntegerRemoveDots:
                        return x => x.ToString().Replace(".", "").ConvertToInt(0);
                    case TransformEnum.IpAddress:
                        return x => new IpAddress(x.ToString());
                    case TransformEnum.DefaultZeroDouble:
                        return x => x.ToString().ConvertToDouble(0.0);
                    case TransformEnum.DefaultOpenDate:
                        return x => x.ToString().ConvertToDateTime(DateTime.Today.AddMonths(-1));
                    case TransformEnum.AntiNullAddress:
                        return x => string.IsNullOrEmpty(x.ToString()) ? "请编辑地址" : x.ToString();
                    default:
                        return null;
                }
            }
        }
    }
}
