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

        public ViewHolder(Context context,View itemview,ViewGroup parent):base(itemview)
        {
            mContext = context;
            mConvertView = itemview;
            mViews = new SparseArray<View>();
        }

        public static ViewHolder Get(Context context,ViewGroup parent,int layoutId)
        {
            View itemView = LayoutInflater.From(context).Inflate(layoutId, parent, false);
            ViewHolder holder = new ViewHolder(context, itemView, parent);
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

    public class MyItemDecoration : RecyclerView.ItemDecoration
    {
        private static int[] ATTRS = new int[] { Android.Resource.Attribute.ListDivider };
        public static int HORIZONTAL = LinearLayoutManager.Horizontal;
        public static int VERTICAL = LinearLayoutManager.Vertical;
        private Drawable _divider;
        private int _orientation;
        public MyItemDecoration(Context context, int orientation)
        {
            TypedArray t = context.ObtainStyledAttributes(ATTRS);
            _divider = t.GetDrawable(0);
            t.Recycle();
            SetOrientation(orientation);
        }
        public void SetOrientation(int orientation)
        {
            if (orientation != HORIZONTAL && orientation != VERTICAL)
                throw new System.Exception("invalid orientation");
            _orientation = orientation;
        }
        public override void OnDraw(Canvas cValue, RecyclerView parent,RecyclerView.State state)
        {
            if (_orientation == VERTICAL)
            {
                DrawVertical(cValue, parent);
            }
            else
            {
                DrawHorizontal(cValue, parent);
            }
        }
        //竖屏时画竖线
        public void DrawVertical(Canvas c, RecyclerView parent)
        {
            int left = parent.PaddingLeft;
            int right = parent.Width - parent.PaddingRight;
            int childCount = parent.ChildCount;
            for (int i = 0; i < childCount; i++)
            {
                View childView = parent.GetChildAt(i);
                RecyclerView v = new RecyclerView(parent.Context);
                RecyclerView.LayoutParams _params = (RecyclerView.LayoutParams)childView.LayoutParameters;
                int top = childView.Bottom + _params.BottomMargin;
                int bottom = top + _divider.IntrinsicHeight;
                _divider.SetBounds(left, top, right, bottom);
                _divider.Draw(c);
            }
        }
        //横屏时画横线
        public void DrawHorizontal(Canvas c, RecyclerView parent)
        {
            int top = parent.PaddingTop;
            int bottom = parent.Height - parent.PaddingBottom;
            int childCount = parent.ChildCount;
            for (int i = 0; i < childCount; i++)
            {
                View childView = parent.GetChildAt(i);
                RecyclerView v = new RecyclerView(parent.Context);
                RecyclerView.LayoutParams _params = (RecyclerView.LayoutParams)childView.LayoutParameters;
                int left = childView.Right + _params.RightMargin;
                int right = left + _divider.IntrinsicHeight;
                _divider.SetBounds(left, top, right, bottom);
                _divider.Draw(c);
            }
        }
        public override void GetItemOffsets(Rect outRect,View view,RecyclerView parent,RecyclerView.State state)
        {
            if (_orientation == VERTICAL)
            {
                outRect.Set(0, 0, 0, _divider.IntrinsicHeight);
            }
            else
            {
                outRect.Set(0, 0, _divider.IntrinsicWidth, 0);
            }
        }
    }
}