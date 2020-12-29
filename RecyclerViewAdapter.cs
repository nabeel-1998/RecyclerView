﻿using Android.Graphics;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Refractored.Controls;
using System.Collections.Generic;
using recycler_test;
using System;
using Android.Content;
using AndroidX.Core.Graphics;

namespace FinalProject_PU.Helper
{
    class RecyclerViewHolder : RecyclerView.ViewHolder
    {
        public ImageView imageview { get; set; }
        public CircleImageView UserImage { get; set; }
        public TextView UserName { get; set; }
        public TextView IssueDate { get; set; }
        public TextView IssueStatement { get; set; }

        Android.Graphics.Typeface tf;
        //
        // public TextView Description { get; set; }
        public RecyclerViewHolder(Android.Views.View itemView) : base(itemView)
        {
            imageview = itemView.FindViewById<ImageView>(recycler_test.Resource.Id.imageView1);
            UserImage = itemView.FindViewById<CircleImageView>(recycler_test.Resource.Id.imgProfile);
            UserName = itemView.FindViewById<TextView>(recycler_test.Resource.Id.tvname);
            IssueDate = itemView.FindViewById<TextView>(recycler_test.Resource.Id.tvtime);
            IssueStatement = itemView.FindViewById<TextView>(recycler_test.Resource.Id.tvinfo);
            //beauttification
            
            /*
            tf = Typeface.CreateFromAsset(Assets, "Quicksand-Bold.otf");
            IssueStatement.SetTypeface(tf, TypefaceStyle.Bold);

           
            tf = Typeface.CreateFromAsset(Assets, "Quicksand-Bold.otf");
            UserName.SetTypeface(tf, TypefaceStyle.Bold);

           
            tf = Typeface.CreateFromAsset(Assets, "Quicksand-Bold.otf");
            IssueDate.SetTypeface(tf, TypefaceStyle.Bold);
            */
        }
    }
    class RecyclerViewAdapter : RecyclerView.Adapter
    {
        private List<Data> lstData = new List<Data>();

        public RecyclerViewAdapter(List<Data> lstData)
        {
            this.lstData = lstData;
        }

        public override int ItemCount
        {
            get
            {
                return lstData.Count;
            }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            RecyclerViewHolder viewHolder = holder as RecyclerViewHolder;
            byte[] arr0 = Convert.FromBase64String(lstData[position].IssueImage); //IssueImage
            Bitmap b0 = BitmapFactory.DecodeByteArray(arr0, 0, arr0.Length);
            viewHolder.imageview.SetImageBitmap(b0);
            byte[] arr1 = Convert.FromBase64String(lstData[position].UserImage); //UserImage
            Bitmap b1 = BitmapFactory.DecodeByteArray(arr1, 0, arr1.Length);
            viewHolder.UserImage.SetImageBitmap(b1); //
            viewHolder.UserName.Text = lstData[position].UserName;
            viewHolder.IssueDate.Text = lstData[position].ElevatedDays;
            viewHolder.IssueStatement.Text = lstData[position].IssueStatement;

        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            LayoutInflater inflater = LayoutInflater.From(parent.Context);
            Android.Views.View itemView = inflater.Inflate(Resource.Layout.items, parent, false);
            return new RecyclerViewHolder(itemView);
        }
    }
}