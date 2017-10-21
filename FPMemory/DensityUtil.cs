using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Util;
using Android.Content.Res;

namespace FPMemory
{
    class DensityUtil
    {
        public static int dip2px(Context context, float dpValue)
        {
            float scale = Resources.System.DisplayMetrics.Density; 
            return (int)(dpValue * scale + 0.5f);
        }

        public static int px2dip(Context context, float pxValue)
        {
            float scale = Resources.System.DisplayMetrics.Density;
            return (int)(pxValue / scale + 0.5f);
        }
    }
}