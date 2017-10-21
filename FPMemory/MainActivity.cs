using Android.App;
using Android.Widget;
using Android.OS;
using Android.Graphics.Drawables;

namespace FPMemory
{
    [Activity(Label = "FPMemory", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity,RadioGroup.IOnCheckedChangeListener
    {
        private RadioButton rbSports;
        private RadioButton rbHealth;
        private RadioButton rbFind;
        private RadioButton rbMe;

        private RadioGroup rgBottomBar;

        int IamgeSize = 35;

        

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            InitBottomBar(IamgeSize); 
            


        }
        

        private void InitBottomBar( int size)
        {
            rgBottomBar = FindViewById<RadioGroup>(Resource.Id.bottomBar);
            rgBottomBar.SetOnCheckedChangeListener(this);

            rbSports = FindViewById<RadioButton>(Resource.Id.rbSports);
            Drawable drawableSports = GetDrawable(Resource.Drawable.tab_menu_sports);
            drawableSports.SetBounds(0, 0, DensityUtil.dip2px(this, size), DensityUtil.dip2px(this, size));
            rbSports.SetCompoundDrawables(null, drawableSports, null, null);

            rbHealth = FindViewById<RadioButton>(Resource.Id.rbHealth);
            Drawable drawableHealth = GetDrawable(Resource.Drawable.tab_menu_health);
            drawableHealth.SetBounds(0, 0, DensityUtil.dip2px(this, size), DensityUtil.dip2px(this, size));
            rbHealth.SetCompoundDrawables(null, drawableHealth, null, null);

            rbFind = FindViewById<RadioButton>(Resource.Id.rbFind);
            Drawable drawableFind = GetDrawable(Resource.Drawable.tab_menu_find);
            drawableFind.SetBounds(0, 0, DensityUtil.dip2px(this, size), DensityUtil.dip2px(this, size));
            rbFind.SetCompoundDrawables(null, drawableFind, null, null);

            rbMe= FindViewById<RadioButton>(Resource.Id.rbMe);
            Drawable drawableMe = GetDrawable(Resource.Drawable.tab_menu_me);
            drawableMe.SetBounds(0, 0, DensityUtil.dip2px(this, size), DensityUtil.dip2px(this, size));
            rbMe.SetCompoundDrawables(null, drawableMe, null, null);
        }

        public void OnCheckedChanged(RadioGroup group, int checkedId)
        {
            throw new System.NotImplementedException();
        }
    }   
}

