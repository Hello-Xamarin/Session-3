using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Android.Content;
using Android.Provider;

namespace msp_droid_1
{
    [Activity(Label = "msp_droid_1", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            Button testBtn = FindViewById<Button>(Resource.Id.testBtn);
            testBtn.Click += delegate
            {
                AlertDialog.Builder builder = new AlertDialog.Builder(this);
                builder.SetTitle("Wow alert");
                builder.SetMessage("button is clicked");
                builder.Show();

            };

            Button callBtn = FindViewById<Button>(Resource.Id.callBtn);
            callBtn.Click += delegate
            {
                AlertDialog.Builder builder = new AlertDialog.Builder(this);
                EditText userInput = new EditText(this);
                userInput.InputType = Android.Text.InputTypes.ClassNumber;

                builder.SetTitle("call ~~!!");
                builder.SetMessage("type phone number");
                builder.SetView(userInput);
                builder.SetPositiveButton("Created", delegate
                {
                    var uri = Android.Net.Uri.Parse("tel:" + userInput.Text);
                    var intent = new Intent(Intent.ActionDial, uri);
                    StartActivity(intent);
                });
                builder.Show();
            };

            Button cameraBtn = FindViewById<Button>(Resource.Id.cameraBtn);
            cameraBtn.Click += delegate
            {
                var intent = new Intent(MediaStore.ActionImageCapture);
                StartActivity(intent);
            };

        }
    }
}

