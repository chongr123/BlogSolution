using Abp.Domain.Entities;
using Abp.Localization.Sources;
using Blog_Solution.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Blog_Solution.Web.Framework
{
    public static class EnumExtensions
    {
        public static SelectList ToSelectList<TEnum>(this TEnum enumObj, ILocalizationSource localizationService,
           bool markCurrentAsSelected = true, int[] valuesToExclude = null, bool useLocalization = true) where TEnum : struct
        {
            if (!typeof(TEnum).IsEnum) throw new ArgumentException("An Enumeration type is required.", "enumObj");
            
            var values = from TEnum enumValue in Enum.GetValues(typeof(TEnum))
                         where valuesToExclude == null || !valuesToExclude.Contains(Convert.ToInt32(enumValue))
                         select new { ID = Convert.ToInt32(enumValue), Name = useLocalization ? enumValue.GetLocalizedEnum(localizationService) : CommonHelper.ConvertEnum(enumValue.ToString()) };
            object selectedValue = null;
            if (markCurrentAsSelected)
                selectedValue = Convert.ToInt32(enumObj);
            return new SelectList(values, "ID", "Name", selectedValue);
        }

        public static SelectList ToSelectList<T>(this T objList, Func<Entity, string> selector) where T : IEnumerable<Entity>
        {
            return new SelectList(objList.Select(p => new { ID = p.Id, Name = selector(p) }), "ID", "Name");
        }

        public static string GetLocalizedEnum<T>(this T enumValue, ILocalizationSource localizationService)
        {
            if (localizationService == null)
                throw new ArgumentNullException("localizationService");

            if (!typeof(T).IsEnum) throw new ArgumentException("T must be an enumerated type");

            //localized value
            string resourceName = string.Format("Enums.{0}.{1}",
                typeof(T).ToString(),
                //Convert.ToInt32(enumValue)
                enumValue.ToString());
            string result = localizationService.GetString(resourceName);

            //set default value if required
            if (String.IsNullOrEmpty(result))
                result = CommonHelper.ConvertEnum(enumValue.ToString());

            return result;
        }
    }
}