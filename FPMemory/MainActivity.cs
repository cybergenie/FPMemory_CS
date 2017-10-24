using Android.App;
using Android.Widget;
using Android.OS;
using Android.Graphics.Drawables;

namespace FPMemory
{
    [Activity(Label = "FPMemory", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity,RadioGroup.IOnCheckedChangeListener
    {
        private RadioGroup rgBottomBar;
        private RadioButton rbExercise;
        private RadioButton rbHealth;
        private RadioButton rbFind;
        private RadioButton rbMe;

        
        FragmentTransaction ft = null;
        FragmentExercise fgExercise = null;
        FragmentHealth fgHealth = null;
        FragmentFind fgFind = null;
        FragmentMe fgMe = null;

        int IamgeSize = 35;

        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            InitBottomBar(IamgeSize);
            rbExercise.Checked = true;


        }
        

        private void InitBottomBar( int size)
        {
            rgBottomBar = FindViewById<RadioGroup>(Resource.Id.bottomBar);
            rgBottomBar.SetOnCheckedChangeListener(this);

            rbExercise = FindViewById<RadioButton>(Resource.Id.rbExercise);
            Drawable drawableExercise = GetDrawable(Resource.Drawable.tab_menu_Exercise);
            drawableExercise.SetBounds(0, 0, DensityUtil.dip2px(this, size), DensityUtil.dip2px(this, size));
            rbExercise.SetCompoundDrawables(null, drawableExercise, null, null);

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
            ft = FragmentManager.BeginTransaction();            
            TextView tvTopBar = FindViewById<TextView>(Resource.Id.txTopBar);
            hideFragment(ft);

            switch (checkedId)
            {
                case Resource.Id.rbExercise:
                    if (fgExercise == null)
                    {
                        fgExercise = new FragmentExercise();
                        ft.Add(Resource.Id.fragmentCanvas, fgExercise, "PAGE_EXERCISE");
                    }
                    else
                        ft.Show(fgExercise);
                    tvTopBar.SetText(Resource.String.tab_menu_exercise);
                    break;
                case Resource.Id.rbHealth:
                    if (fgHealth == null)
                    {
                        fgHealth = new FragmentHealth();
                        ft.Add(Resource.Id.fragmentCanvas,fgHealth, "PAGE_HEALTH");
                    }
                    else
                        ft.Show(fgHealth);
                    tvTopBar.SetText(Resource.String.tab_menu_health);
                    break;
                case Resource.Id.rbFind:
                    if (fgFind == null)
                    {
                        fgFind = new FragmentFind();
                        ft.Add(Resource.Id.fragmentCanvas,fgFind, "PAGE_FIND");
                    }
                    else
                        ft.Show(fgFind);
                    tvTopBar.SetText(Resource.String.tab_menu_find);
                    break;
                case Resource.Id.rbMe:
                    if (fgMe == null)
                    {
                        fgMe = new FragmentMe();
                        ft.Add(Resource.Id.fragmentCanvas,fgMe, "PAGE_ME");
                    }
                    else
                        ft.Show(fgMe);
                    tvTopBar.SetText(Resource.String.tab_menu_me);
                    break;
            }
            ft.Commit();

        }

        private void hideFragment(FragmentTransaction transaction)
        {
            if (fgExercise != null)
            {
                transaction.Hide(fgExercise);
            }
            if (fgHealth != null)
            {
                transaction.Hide(fgHealth);
            }
            if (fgFind != null)
            {
                transaction.Hide(fgFind);
            }
            if (fgMe != null)
            {
                transaction.Hide(fgMe);
            }

        }
    }   
}

