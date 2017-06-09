using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web;

namespace DynamicQuery.Mvc
{
    public static class QueryConditionExtension
    {
        public static MvcHtmlString QueryTextbox(this HtmlHelper html, string properyName, string labelText, QueryOperator opt = QueryOperator.EQUAL, string valuetype = null)
        {
            var input = "<label>{0}</label><input class='input-medium search-query' type='text' name='{1}'/>";
            var res = string.Format(input, HttpUtility.HtmlEncode(labelText), "_query." + properyName);
            if (QueryOperator.EQUAL != opt)
            {
                res += "<input type='hidden' name='_query." + properyName + ".operator' value='" + opt.ToString() + "'/>";
            }

            if (!string.IsNullOrEmpty(valuetype))
            {
                res += "<input type='hidden' name='_query." + properyName + ".valuetype' value='" + valuetype + "'/>";
            }
            return MvcHtmlString.Create(res);
        }

        public static MvcHtmlString QueryTextbox(this HtmlHelper html, string properyName, QueryOperator opt = QueryOperator.EQUAL, string valuetype = null)
        {
            var input = "<input class='input-medium search-query' type='text' name='{0}'/>";
            var res = string.Format(input, "_query." + properyName);
            if (QueryOperator.EQUAL != opt)
            {
                res += "<input type='hidden' name='_query." + properyName + ".operator' value='" + opt.ToString() + "'/>";
            }

            if (!string.IsNullOrEmpty(valuetype))
            {
                res += "<input type='hidden' name='_query." + properyName + ".valuetype' value='" + valuetype + "'/>";
            }
            return MvcHtmlString.Create(res);
        }
        public static MvcHtmlString QueryTextbox(this HtmlHelper html, string properyName, QueryOperator opt = QueryOperator.EQUAL, string valuetype = null, object htmlAttributes = null)
        {
            string attrstring = string.Empty;
            if (htmlAttributes != null)
            {
                Type tt = htmlAttributes.GetType();
                foreach (var info in tt.GetProperties())
                {
                    attrstring += info.Name + "=\"" + info.GetValue(htmlAttributes, null) + "\"   ";
                }
            }
            var input = "<input  type='text' name='{0}' {1}/>";
            var res = string.Format(input, "_query." + properyName, attrstring);
            if (QueryOperator.EQUAL != opt)
            {
                res += "<input type='hidden' name='_query." + properyName + ".operator' value='" + opt.ToString() + "' />";
            }

            if (!string.IsNullOrEmpty(valuetype))
            {
                res += "<input type='hidden' name='_query." + properyName + ".valuetype' value='" + valuetype + "'  />";
            }
            return MvcHtmlString.Create(res);
        }





        public static MvcHtmlString QueryDropdownList(this HtmlHelper html, string properyName, IEnumerable<SelectListItem> selectList,
            QueryOperator opt = QueryOperator.EQUAL, string valuetype = null, String excludeValue = null)
        {
            var select = "<select id='{0}' name='{1}'>{2}</select>";
            var option = "<option {2} value='{0}'>{1}</option>";
            String optionList = String.Empty;
            if (selectList != null)
            {
                foreach (SelectListItem item in selectList)
                {
                    optionList += String.Format(option, item.Value, item.Text, item.Selected ? "selected=\"selected\"" : String.Empty);
                }
            }
            var res = string.Format(select, properyName, "_query." + properyName, optionList);
            if (QueryOperator.EQUAL != opt)
            {
                res += "<input type='hidden' name='_query." + properyName + ".operator' value='" + opt.ToString() + "'/>";
            }
            if (!string.IsNullOrEmpty(valuetype))
            {
                res += "<input type='hidden' name='_query." + properyName + ".valuetype' value='" + valuetype + "'/>";
            }
            if (!String.IsNullOrEmpty(excludeValue))
            {
                res += "<input type='hidden' name='_query." + properyName + ".exclude' value='" + excludeValue + "'/>";
            }
            return MvcHtmlString.Create(res);
        }

        public static MvcHtmlString QueryDropdownList(this HtmlHelper html, string properyName, IEnumerable<SelectListItem> selectList,
          QueryOperator opt = QueryOperator.EQUAL, string valuetype = null, String excludeValue = null, object htmlAttributes = null)
        {
            string attrstring = string.Empty;
            if (htmlAttributes != null)
            {
                Type tt = htmlAttributes.GetType();
                foreach (var info in tt.GetProperties())
                {
                    attrstring += info.Name + "=\"" + info.GetValue(htmlAttributes, null) + "\"     ";
                }
            }
            var select = "<select id='{0}' name='{1}' {3}>{2}</select>";
            var option = "<option {2} value='{0}'>{1}</option>";
            String optionList = String.Empty;
            if (selectList != null)
            {
                foreach (SelectListItem item in selectList)
                {
                    optionList += String.Format(option, item.Value, item.Text, item.Selected ? "selected=\"selected\"" : String.Empty);
                }
            }
            var res = string.Format(select, properyName, "_query." + properyName, optionList, attrstring);
            if (QueryOperator.EQUAL != opt)
            {
                res += "<input type='hidden' name='_query." + properyName + ".operator' value='" + opt.ToString() + "'/>";
            }
            if (!string.IsNullOrEmpty(valuetype))
            {
                res += "<input type='hidden' name='_query." + properyName + ".valuetype' value='" + valuetype + "'/>";
            }
            if (!String.IsNullOrEmpty(excludeValue))
            {
                res += "<input type='hidden' name='_query." + properyName + ".exclude' value='" + excludeValue + "'/>";
            }

            return MvcHtmlString.Create(res);
        }


        public static MvcHtmlString QueryEnumDropdownList(this HtmlHelper html, string properyName, Type enumType,
            QueryOperator opt = QueryOperator.EQUAL, String excludeValue = null)
        {
            // Looks for a [Display(Name="Some Name")] or a [Display(Name="Some Name", ResourceType=typeof(ResourceFile)] Attribute on your enum
            Func<Enum, string> getDescription = en =>
            {
                Type type = en.GetType();
                System.Reflection.MemberInfo[] memInfo = type.GetMember(en.ToString());

                if (memInfo != null && memInfo.Length > 0)
                {
                    object[] attrs = memInfo[0].GetCustomAttributes(typeof(System.ComponentModel.DataAnnotations.DisplayAttribute), false);

                    if (attrs != null && attrs.Length > 0)
                        return ((System.ComponentModel.DataAnnotations.DisplayAttribute)attrs[0]).GetName();
                }

                return en.ToString();
            };

            var select = "<select id='{0}' name='{1}'>{2}</select>";
            var option = "<option {2} value='{0}'>{1}</option>";
            String optionList = String.Empty;

            var listItems = Enum.GetValues(enumType).OfType<Enum>();

            int count = 0;
            foreach (Enum obj in listItems)
            {
                optionList += String.Format(option, obj, getDescription(obj), (count == 0) ? "selected=\"selected\"" : String.Empty);
                count++;
            }

            var res = string.Format(select, properyName, "_query." + properyName, optionList);
            if (QueryOperator.EQUAL != opt)
            {
                res += "<input type='hidden' name='_query." + properyName + ".operator' value='" + opt.ToString() + "'/>";
            }
            if (!String.IsNullOrEmpty(excludeValue))
            {
                res += "<input type='hidden' name='_query." + properyName + ".exclude' value='" + excludeValue + "'/>";
            }
            res += "<input type='hidden' name='_query." + properyName + ".valuetype' value='String'/>";
            return MvcHtmlString.Create(res);
        }




        /// <summary>
        /// 绑定下拉列表 枚举
        /// </summary>
        /// <param name="html"></param>
        /// <param name="properyName">字段名称</param>
        /// <param name="enumType">枚举类型 例如typeof(Enum)</param>
        /// <param name="defalutV">扩展项值</param>
        /// <param name="defaultName">扩展项名称 空不扩展</param>
        /// <param name="val">默认选择项</param>
        /// <param name="opt"></param>
        /// <param name="ignore">忽略选择项 如 new string[]{"2"}</param>
        /// <param name="excludeValue"></param>
        /// <returns></returns>
        public static MvcHtmlString QueryEnumForIntDropdownListLYM(this HtmlHelper html, string properyName, Type enumType, string defalutV, string defaultName, object val,
           QueryOperator opt = QueryOperator.EQUAL, string[] ignore = null, string valuetype = null, String excludeValue = null, object htmlAttributes = null)
        {

            string attrstring = string.Empty;
            if (htmlAttributes != null)
            {
                Type tt = htmlAttributes.GetType();
                foreach (var info in tt.GetProperties())
                {
                    attrstring += info.Name + "=\"" + info.GetValue(htmlAttributes, null) + "\"     ";
                }
            }

            // Looks for a [Display(Name="Some Name")] or a [Display(Name="Some Name", ResourceType=typeof(ResourceFile)] Attribute on your enum
            Func<Enum, string> getDescription = en =>
            {
                Type type = en.GetType();
                System.Reflection.MemberInfo[] memInfo = type.GetMember(en.ToString());

                if (memInfo != null && memInfo.Length > 0)
                {
                    object[] attrs = memInfo[0].GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false);

                    if (attrs != null && attrs.Length > 0)
                        return ((System.ComponentModel.DescriptionAttribute)attrs[0]).Description;
                }

                return en.ToString();
            };

            Func<Enum, int?> GetEnumValue = en =>
            {
                Type type = en.GetType();
                System.Reflection.MemberInfo[] memInfo = type.GetMember(en.ToString());

                if (memInfo != null && memInfo.Length > 0)
                {
                    object[] attrs = memInfo[0].GetCustomAttributes(typeof(System.ComponentModel.DataAnnotations.DisplayAttribute), false);

                    if (attrs != null && attrs.Length > 0)
                        return ((System.ComponentModel.DataAnnotations.DisplayAttribute)attrs[0]).GetOrder();
                }

                return null;
            };

            var select = "<select id='{0}' name='{1}'  "+ attrstring + ">{2}</select>";
            var option = "<option {2} value='{0}'>{1}</option>";
            String optionList = String.Empty;

            var listItems = Enum.GetValues(enumType).OfType<Enum>();



            if (!string.IsNullOrEmpty(defaultName))
            {
                optionList += string.Format(option, defalutV, defaultName, (val == (object)defalutV) ? "selected=\"selected\"" : String.Empty);
            }
            int count = 0;

            Dictionary<string, int?> lst = new Dictionary<string, int?>();
            foreach (Enum obj in listItems)
            {
                int? value = GetEnumValue(obj);
                string key = getDescription(obj);
                if (ignore != null)
                {
                    if (!ignore.ToList().Contains(value + ""))
                    {
                        lst.Add(key, value);
                    }
                }
                else {
                    lst.Add(key, value);
                }


                count++;
            }
            lst = lst.OrderBy(x => x.Value).ToDictionary(c => c.Key, c => c.Value);

            foreach (var item in lst)
            {
                bool isSelect = (((object)item.Value).ToString() == val.ToString());
                optionList += String.Format(option, item.Value, item.Key, isSelect ? "selected=\"selected\"" : String.Empty);
            }
            var res = string.Format(select, properyName, "_query." + properyName, optionList);
            if (QueryOperator.EQUAL != opt)
            {
                res += "<input type='hidden' name='_query." + properyName + ".operator' value='" + opt.ToString() + "'/>";
            }
            if (!string.IsNullOrEmpty(valuetype))
            {
                res += "<input type='hidden' name='_query." + properyName + ".valuetype' value='" + valuetype + "'/>";
            }
            if (!String.IsNullOrEmpty(excludeValue))
            {
                res += "<input type='hidden' name='_query." + properyName + ".exclude' value='" + excludeValue + "'/>";
            }
          
            return MvcHtmlString.Create(res);
        }
    }

}
