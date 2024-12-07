using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Views;
using AndroidX.AppCompat.Widget;
using AndroidX.AppCompat.App;
using Google.Android.Material.FloatingActionButton;
using Google.Android.Material.Snackbar;


namespace AnimalCount
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        int score = 0;
        Android.Widget.TextView scoreTextView;

        (int, int)[] idScores = new (int, int)[]
        {
            (Resource.Id.sheep, 1),
            (Resource.Id.cow, 3),
            (Resource.Id.dog, 1),
            (Resource.Id.pig, 4)
        };

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            Toolbar toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            this.scoreTextView = FindViewById<Android.Widget.TextView>(Resource.Id.scoreTextView);
            this.scoreTextView.Text = String.Format("score: {0}", score);

            var ids = new int[] { Resource.Id.sheep, Resource.Id.cow, Resource.Id.dog, Resource.Id.pig };
            foreach (var (id,score) in idScores)
            {
                var button = FindViewById<Android.Widget.Button>(id);
                button.Click += AddOneButton_Click;
            }
        }

        private void AddOneButton_Click(object sender, EventArgs e)
        {
            var button = (Android.Widget.Button)sender;
            int the_score = -1;
            foreach (var (id,score) in idScores)
            {
                if (id == button.Id)
                {
                    the_score = score;
                    break;
                }
            }

            score += the_score;
            this.scoreTextView.Text = String.Format("score: {0}", score);
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

   
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
	}
}
