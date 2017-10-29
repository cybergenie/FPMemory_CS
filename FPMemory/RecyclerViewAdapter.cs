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
using Android.Support.V7.Widget;
using Android.Graphics.Drawables;
using Android.Content.Res;
using Android.Graphics;
using Android.Util;

namespace FPMemory
{
    public abstract class RecyclerViewAdapter<T> : RecyclerView.Adapter
    {
        private List<T> mDatas;
        private Context mContext;
        private int mLayoutId;
        private LayoutInflater mInflater;
        public RecyclerViewAdapter(Context context,int layoutId,List<T> datas)
        {            
            mContext = context;
            mInflater = LayoutInflater.From(context);
            mLayoutId = layoutId;
            mDatas = datas;
        }
        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            ViewHolder mHolder = holder as ViewHolder;
            convert(mHolder, mDatas[position]);
        }
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewItem)
        {
            ViewHolder viewHolder = ViewHolder.Get(mContext, parent, mLayoutId);
            return viewHolder;
        }

        public abstract void convert(ViewHolder holder, T t);
        public override int ItemCount
        {
            get
            {
                return mDatas.Count;
            }
        }
        public override void OnViewRecycled(Java.Lang.Object holder)
        {
            base.OnViewRecycled(holder);
            ViewHolder mHolder = holder as ViewHolder;
        }
    }

    public class ViewHolder : RecyclerView.ViewHolder
    {
        private SparseArray<View> mViews;
        private View mConvertView;
        private Context mContext;       

        public ViewHolder(Context context,View itemview):base(itemview)
        {
            mContext = context;
            mConvertView = itemview;
            mViews = new SparseArray<View>();
        }

        public static ViewHolder Get(Context context,ViewGroup parent,int layoutId)
        {
            View view = LayoutInflater.From(parent.Context).Inflate(layoutId, parent, false);
            ViewHolder holder = new ViewHolder(context, view);
            return holder;
        }

        public T GetView<T>(int viewId)
        {
            View view = mViews.Get(viewId);
            if(view==null)
            {
                view = mConvertView.FindViewById(viewId);
                mViews.Put(viewId, view);
            }
            return (T)Convert.ChangeType(view,view.GetType());
        }

        public ViewHolder setText(int viewId, String text)
        {
            TextView tv = GetView<TextView>(viewId);
            tv.SetText(text,TextView.BufferType.Normal);
            return this;
        }

        public ViewHolder setImageResource(int viewId, int resId)
        {
            ImageView view = GetView<ImageView>(viewId);
            view.SetImageResource(resId);
            return this;
        }

        public ViewHolder setOnClickListener(int viewId,View.IOnClickListener listener)
        {
            View view = GetView<View>(viewId);
            view.SetOnClickListener(listener);
            return this;
        }
    }  

}