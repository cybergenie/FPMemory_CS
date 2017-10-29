using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.Support.V4.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;

namespace FPMemory
{
    public class FragmentExercise : Fragment
        //,View.IOnClickListener
    {
        private List<ItemExercise> itemExerciseList = new List<ItemExercise>();

        

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.fg_exercise, container, false);
            RecyclerView rvExercise = view.FindViewById(Resource.Id.rvExercise) as RecyclerView;

            LinearLayoutManager layoutManager = new LinearLayoutManager(this.Activity.ApplicationContext);
            InitItemExercise();
            RVExerciseAdapter rvExerciseAdapter = new RVExerciseAdapter(this.Activity.ApplicationContext, Resource.Layout.item_exercise, itemExerciseList);

            rvExercise.SetLayoutManager(layoutManager);
            rvExercise.SetAdapter(rvExerciseAdapter);

            //ImageView iv_history = (ImageView)itemExerciseList[0].ItemPicGoto;
            //iv_history.SetOnClickListener(this);
            //ImageView iv_finished = (ImageView)itemExerciseList[1].ItemPicGoto;
            //iv_finished.SetOnClickListener(this);
            //ImageView iv_nonfinished = (ImageView)itemExerciseList[2].ItemPicGoto;
            //iv_nonfinished.SetOnClickListener(this);

            return view;
        }
        //public void OnClick(View v)
        //{
        //    switch (v.Id)
        //    {
        //        //    case Resource.Id.arrow_history:
        //        //        Intent sports_history = new Intent(this.Activity, sports_history_content.class);
        //        //    startActivity(sports_history);
        //        //    break;
        //        //case R.id.arrow_finished:
        //        //    Intent sports_finished = new Intent(this.Activity, sports_finished_content.class);
        //        //    startActivity(sports_finished);
        //        //    break;
        //        //case R.id.arrow_nonfinished:
        //        //    Intent sports_nonfinished = new Intent(this.Activity, sports_nonfinished_content.class);
        //        //    startActivity(sports_nonfinished);
        //        //    break;
        //        default:
        //            break;
        //    }
        //}


        private void InitItemExercise()
        {
            ItemExercise itemExercise = null;
            itemExercise = new ItemExercise(Resource.Mipmap.tips_history,"历史运动强度", Resource.Drawable.arrow_right_click);
            itemExerciseList.Add(itemExercise);
            itemExercise = new ItemExercise(Resource.Mipmap.tips_finished,"已完成运动项目", Resource.Drawable.arrow_right_click);
            itemExerciseList.Add(itemExercise);
            itemExercise = new ItemExercise(Resource.Mipmap.tips_nonfinished, "未完成运动项目", Resource.Drawable.arrow_right_click);
            itemExerciseList.Add(itemExercise);
        }
    }

    public class ItemExercise
    {
        private int itemIcon;
        private string itemName;
        private int itemPicGoto;

        public int ItemIcon { get => itemIcon; set => itemIcon = value; }
        public string ItemName { get => itemName; set => itemName = value; }
        public int ItemPicGoto { get => itemPicGoto; set => itemPicGoto = value; }

        public ItemExercise(int itemIcon, string itemName,int itemPicGoto)
        {
            ItemIcon = itemIcon;
            ItemName = itemName;
            ItemPicGoto = itemPicGoto;
        }
    }

    public class RVExerciseAdapter : RecyclerViewAdapter<ItemExercise>
    {
        public RVExerciseAdapter(Context context, int layoutId, List<ItemExercise> datas) : base(context, layoutId, datas)
        {

        }
        public override void convert(ViewHolder holder, ItemExercise t)
        {
            holder.setImageResource(Resource.Id.item_exercise_icon, t.ItemIcon);
            holder.setText(Resource.Id.item_exercise_name, t.ItemName);
            holder.setImageResource(Resource.Id.item_exercise_goto, t.ItemPicGoto);               

        }
        
    }
}