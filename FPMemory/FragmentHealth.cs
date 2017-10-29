using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Support.V4.View;
using Android.Support.V4.App;
using Android.Graphics.Drawables;

namespace FPMemory
{
    public class FragmentHealth : Fragment, RadioGroup.IOnCheckedChangeListener, ViewPager.IOnPageChangeListener
    {
        private ViewPager mPager;
        private List<Fragment> fragmentsList;
        private Fragment heartrate;
        private Fragment bloodpressure;
        private Fragment bloodoxygen;
        protected RadioGroup rgHealthBar;
        protected RadioButton rbHeartrate, rbBloodpressure, rbBloodoxygen;

        public void OnCheckedChanged(RadioGroup group, int checkedId)
        {
            switch (checkedId)
            {
                case Resource.Id.rb_heartrate:
                    mPager.SetCurrentItem(0,true);
                    break;
                case Resource.Id.rb_bloodpressure:
                    mPager.SetCurrentItem(1, true);
                    break;
                case Resource.Id.rb_bloodoxygen:
                    mPager.SetCurrentItem(2, true);
                    break;
            }
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.fg_health, container, false);
            InitView(view);
            InitViewPager(view);
            rbHeartrate.Checked = true;
            return view;
        }

        private void InitViewPager(View parentView)
        {
            mPager = (ViewPager)parentView.FindViewById(Resource.Id.vPager);
            fragmentsList = new List<Fragment>();
            heartrate = new FragmentHeartrate();
            bloodpressure = new FragmentBloodpressure();
            bloodoxygen = new FragmentBloodoxygen();

            fragmentsList.Add(heartrate);
            fragmentsList.Add(bloodpressure);
            fragmentsList.Add(bloodoxygen);

            mPager.Adapter = new PagerAdapter(ChildFragmentManager, fragmentsList);
            mPager.AddOnPageChangeListener(this);
            mPager.SetCurrentItem(0,true);
        }

        private void InitView(View parentView)
        {
            rgHealthBar = (RadioGroup)parentView.FindViewById(Resource.Id.rg_health_bar);
            rbHeartrate = (RadioButton)parentView.FindViewById(Resource.Id.rb_heartrate);
            rbBloodpressure = (RadioButton)parentView.FindViewById(Resource.Id.rb_bloodpressure);
            rbBloodoxygen = (RadioButton)parentView.FindViewById(Resource.Id.rb_bloodoxygen);
            rgHealthBar.SetOnCheckedChangeListener(this);

            //        定义图片大小，单位是dx
            int imagesize = 65;
            //        定义rb_heartrate标签图片大小和位置
            Drawable drawable_heartrate = Resources.GetDrawable(Resource.Drawable.tab_health_heartrate, null);
            drawable_heartrate.SetBounds(0, 0, DensityUtil.dip2px(this.Activity, imagesize), DensityUtil.dip2px(this.Activity, imagesize));
            rbHeartrate.SetCompoundDrawables(null, drawable_heartrate, null, null);

            //        定义rb_bloodpressure标签图片大小和位置
            Drawable drawable_bloodpressure = Resources.GetDrawable(Resource.Drawable.tab_health_bloodpressure, null);
            drawable_bloodpressure.SetBounds(0, 0, DensityUtil.dip2px(this.Activity, imagesize), DensityUtil.dip2px(this.Activity, imagesize));
            rbBloodpressure.SetCompoundDrawables(null, drawable_bloodpressure, null, null);

            //        定义rb_bloodoxygen标签图片大小和位置
            Drawable drawable_bloodoxygen = Resources.GetDrawable(Resource.Drawable.tab_health_bloodoxygen, null);
            drawable_bloodoxygen.SetBounds(0, 0, DensityUtil.dip2px(this.Activity, imagesize), DensityUtil.dip2px(this.Activity, imagesize));
            rbBloodoxygen.SetCompoundDrawables(null, drawable_bloodoxygen, null, null);

        }
       
            

            public void OnPageScrolled(int position, float positionOffset, int positionOffsetPixels)
            {
                
            }

            public void OnPageScrollStateChanged(int state)
            {
                
            }

        public void OnPageSelected(int arg0)
        {
            switch (arg0)
            {
                case 0:
                    rbHeartrate.Checked = true;
                    break;
                case 1:
                    rbBloodpressure.Checked = true;
                    break;
                case 2:
                    rbBloodoxygen.Checked = true;
                    break;
            }
        }
    }
}