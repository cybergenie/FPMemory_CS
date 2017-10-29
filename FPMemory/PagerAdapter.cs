
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V4.App;

using Java.Lang;

namespace FPMemory
{
    class PagerAdapter: FragmentPagerAdapter
    {
        private List<Fragment> fragmentsList;


        public PagerAdapter(FragmentManager fm):base(fm)
        {            
        }

        public PagerAdapter(FragmentManager fm, List<Fragment> fragments):base(fm)
        {            
            this.fragmentsList = fragments;
        }
        
    public override Fragment GetItem(int position)
        {
            return fragmentsList[position];
        }
        
    public override int Count
        {
            get { return fragmentsList.Count(); }
            
        }
       
    public override int GetItemPosition(Object @object)
        {
            return base.GetItemPosition(@object);
        }
    }
}