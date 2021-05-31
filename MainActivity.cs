using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace MyBibleCompanion
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Spinner spinner;
        TextView txtVerses;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            

            SetContentView(Resource.Layout.activity_main);
            txtVerses = FindViewById<TextView>(Resource.Id.txtVerses);
            
            spinner = FindViewById<Spinner>(Resource.Id.spinner);
            bool stillRunning = true;
            string selectedItem = spinner.SelectedItem.ToString();
            string datingverses = ("Psalms 46:5, Proverbs 3:5-6, 1 Corinthians 15:33, 2 Corinthians 6:14-15, 1 Peter 4:8");
            spinner.ItemSelected += (s, e) =>
            {
             
                if (selectedItem.Equals(spinner.SelectedItem.ToString()))
                {
                    string checkpos = e.Parent.GetItemIdAtPosition(e.Position).ToString();
                    if(checkpos == "0")
                    {
                        Toast.MakeText(this, "Please choose a topic: " + e.Parent.GetItemIdAtPosition(e.Position).ToString(), ToastLength.Short).Show();
                        txtVerses.Text = "Description";
                    }
                }               

                string whatItem = e.Parent.GetItemIdAtPosition(e.Position).ToString();

                if (whatItem.Equals("1"))
                {
                    txtVerses.Text = datingverses;
                }
              
            };
           
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View) sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
	}
}

