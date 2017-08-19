using System;
using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using DualSplash.Core;
using Xamarin;


namespace DualSplash.Android
{

    [Activity(Label = "@string/ApplicationTitle",
        Icon = "@drawable/icon",
        Theme = "@style/FirstScreen.Before",
        MainLauncher = false,
        ScreenOrientation = ScreenOrientation.SensorPortrait,
        LaunchMode = LaunchMode.SingleInstance,
        NoHistory = false,

        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    [Preserve(AllMembers = true)]
    public class MainActivity : Xamarin.Forms.Platform.Android.FormsAppCompatActivity //AppCompatActivity   // global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public MainActivity()
        {
#if TRACE

            DualSplashApp.stopWatch.Stop();
            System.Diagnostics.Trace.WriteLine($"\n ---------------------------------------------------------------------------------" +
                                               $"\n ---------------------------------------------------------------------------------");
            System.Diagnostics.Trace.WriteLine($"\n ---------------------------Starting MainActivity Constructor:  {DualSplashApp.stopWatch.Elapsed.TotalSeconds}");
            DualSplashApp.stopWatch.Start();

#endif
        }
        private static int Frame_CONTENT_VIEW_ID = 10101010;
        protected override async void OnCreate(Bundle bundle)
        {

#if TRACE
            DualSplashApp.stopWatch.Stop();
            System.Diagnostics.Trace.WriteLine(
                $"\n ---------------------------MainActivity ----- OnCreate:  {DualSplashApp.stopWatch.Elapsed.TotalSeconds}");
            DualSplashApp.stopWatch.Start();
#endif

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            //set Splash screen and back normal Theme
            base.Window.RequestFeature(WindowFeatures.ActionBar);

            // Name of the MainActivity theme you had there before.
            // Or you can use global::Android.Resource.Style.ThemeHoloLight


            base.SetTheme(Resource.Style.FirstScreen_After);
            base.OnCreate(bundle);


            /*
                        // this if if you don't want to use UserDialogs.ShowLoading/HideLoading and want to use Native ProgressBar

                        MainActivity activity = this;
            
                        FrameLayout.LayoutParams fLParams = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);//ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.WrapContent);
                        fLParams.Gravity = GravityFlags.Center;

                        ProgressBar progressBar = new ProgressBar(activity, null, Android.Resource.Attribute.ProgressBarStyleLarge);
                        progressBar.Indeterminate = true;   //.setIndeterminate(true);
                        progressBar.Visibility = ViewStates.Visible; //setVisibility(View.VISIBLE);


                        FrameLayout frame = new FrameLayout(this);
                        frame.Id = Frame_CONTENT_VIEW_ID;
                        this.AddContentView(frame, fLParams);
            


                        frame.AddView(progressBar);
            */






            //Activating UserDialogs
            //Acr.UserDialogs.UserDialogs.Init((Activity)Forms.Context);
            Acr.UserDialogs.UserDialogs.Instance.ShowLoading();

#if TRACE
            DualSplashApp.stopWatch.Stop();
            System.Diagnostics.Trace.WriteLine(
                $"\n ---------------------------MainActivity -- OnCreate --After ShowLoading:  {DualSplashApp.stopWatch.Elapsed.TotalSeconds}");
            DualSplashApp.stopWatch.Start();
#endif


            try
            {


                await Task.Run(() =>
                {


                    /*
                                    // Init Code that moved to SplashActivity 

                                        //init Google Analytics for mobile
                                        GATracking_Android.GetGASInstance()
                                        .Initialize_NativeGAS("Stam", this); //"UA-40001613-3", this); //TrackingID first parameter

                    etc........

                    */

                                        //init Insights
                                        if (bundle == null && !Insights.IsInitialized)
                                        {
                                            Xamarin.Insights.Initialize("AppID",
                                                ApplicationContext); //"b7015d6e120008cb54e81254b603f354855b059b", ApplicationContext);
                                                                     //Insights.Initialize("apikey", ApplicationContext);
                                            Insights.DisableCollection = false;
                                            Insights.DisableDataTransmission = false;
                                            Insights.DisableExceptionCatching = false;
                                        }



                                        //await Task.Delay(500); // slow analytics init
                                        Thread.Sleep(500); // 1





                });






                await Task.Run(() =>
                {
                    RunOnUiThread(() =>
                    {
#if TRACE
                        DualSplashApp.stopWatch.Stop();
                        System.Diagnostics.Trace.WriteLine($"\n ---------------------------MainActivity -Reach BEFORE LoadApplication( DualSplashApp.......) -----:  {DualSplashApp.stopWatch.Elapsed.TotalSeconds}");
                        DualSplashApp.stopWatch.Start();
#endif




                        LoadApplication(new DualSplashApp());
#if TRACE
                        DualSplashApp.stopWatch.Stop();
                        System.Diagnostics.Trace.WriteLine($"\n ---------------------------MainActivity - AFTER LoadApplication( DualSplashApp.......) -----:  {DualSplashApp.stopWatch.Elapsed.TotalSeconds}");
                        DualSplashApp.stopWatch.Start();
#endif


                    });
                });

#if TRACE
                DualSplashApp.stopWatch.Stop();
                System.Diagnostics.Trace.WriteLine($"\n ---------------------------MainActivity -finish OnCreate   -----:  {DualSplashApp.stopWatch.Elapsed.TotalSeconds}");
                DualSplashApp.stopWatch.Start();
#endif




            }
            catch (Exception ex)
            {
                Insights.Report(ex, Insights.Severity.Error);
//                TrackService.Track_App_Exception(String.Format("GA Exception Message: \n {0} \n GA Exception StackTrace: \n {1}", ex.Message, ex.StackTrace), false);


            }
        }

    }
}

