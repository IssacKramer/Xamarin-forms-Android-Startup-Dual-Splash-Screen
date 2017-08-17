using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Autofac;
using DualSplash.Core;
using SingleSplash.Android.Ioc.Locator;
using Xamarin;
using Xamarin.Forms;
using XLabs.Ioc;
using XLabs.Ioc.Autofac;
using IContainer = System.ComponentModel.IContainer;

namespace SingleSplash.Android
{

    [Activity(Label = "@string/ApplicationTitle",
        Icon = "@drawable/icon",
        Theme = "@style/splashscreen",
        MainLauncher = true,
        ScreenOrientation = ScreenOrientation.SensorPortrait,
        LaunchMode = LaunchMode.SingleInstance,
        NoHistory = false,

        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    [Preserve(AllMembers = true)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public MainActivity()
        {
#if TRACE

            // AtrizA.Common.Utils.Utils.globalStopWatch = new Stopwatch();
            SingleSplashApp.stopWatch = new Stopwatch();
            System.Diagnostics.Trace.WriteLine($"\n ---------------------------------------------------------------------------------" +
                                               $"\n ---------------------------------------------------------------------------------");
            System.Diagnostics.Trace.WriteLine($"\n ---------------------------Starting MainActivity Constructor:  {SingleSplashApp.stopWatch.Elapsed.TotalSeconds}");
            SingleSplashApp.stopWatch.Start();
            //AtrizA.Common.Utils.Utils.globalStopWatch.Start();

#endif
        }

        protected override  void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;



            //set Splash screen and back normal Theme
            base.Window.RequestFeature(WindowFeatures.ActionBar);
            // Name of the MainActivity theme you had there before.
            // Or you can use global::Android.Resource.Style.ThemeHoloLight
            base.SetTheme(Resource.Style.MainTheme);

            try
            {

 #if TRACE

//                AtrizA.Common.Utils.Utils.globalStopWatch = new Stopwatch();
                SingleSplashApp.stopWatch.Stop();
                System.Diagnostics.Trace.WriteLine($"\n ---------------------------MainActivity ----- OnCreate:  {SingleSplashApp.stopWatch.Elapsed.TotalSeconds}");
                SingleSplashApp.stopWatch.Start();
//                AtrizA.Common.Utils.Utils.globalStopWatch.Start();

#endif


                base.OnCreate(bundle);

#if TRACE

                SingleSplashApp.stopWatch.Stop();
                System.Diagnostics.Trace.WriteLine($"\n ---------------------------MainActivity -OnCreate---------Before Forms.Init:  {SingleSplashApp.stopWatch.Elapsed.TotalSeconds}");
                SingleSplashApp.stopWatch.Start();

#endif

                global::Xamarin.Forms.Forms.Init(this, bundle);

#if TRACE

                SingleSplashApp.stopWatch.Stop();
                System.Diagnostics.Trace.WriteLine($"\n ---------------------------MainActivity -OnCreate---------AFTER Forms.Init:  {SingleSplashApp.stopWatch.Elapsed.TotalSeconds}");
                System.Diagnostics.Trace.WriteLine($"\n ---------------------------Reach BEFORE All packages Init (userdialog, insights ..etc.......  ");
                SingleSplashApp.stopWatch.Start();

#endif


                //init Google Analytics for mobile
                //GATracking_Android.GetGASInstance()
               //     .Initialize_NativeGAS("Stam", this); //"UA-XXXXXXXXX-X", this); //TrackingID first parameter
                //await Task.Delay(500); // slow analytics init
                Thread.Sleep(500);  // 1



                //init Insights
                if (bundle == null && !Insights.IsInitialized)
                {
                    Xamarin.Insights.Initialize("AppID",
                        ApplicationContext); //Insights.Initialize("apikey", ApplicationContext);
                    Insights.DisableCollection = false;
                    Insights.DisableDataTransmission = false;
                    Insights.DisableExceptionCatching = false;
                }

                //Activating UserDialogs
                Acr.UserDialogs.UserDialogs.Init((Activity)Forms.Context);



                //Nav Service 
                // INavigationService _navService;


#if TRACE

                SingleSplashApp.stopWatch.Stop();
                System.Diagnostics.Trace.WriteLine($"\n ---------------------------MainActivity -OnCreate---------BEFORE CONTAINER INIT:  {SingleSplashApp.stopWatch.Elapsed.TotalSeconds}");
                
                SingleSplashApp.stopWatch.Start();

#endif

                //Ioc Container and Xlab Setup

                //ViewModelLocator Init instead of bootstrapper init
                Autofac.IContainer container =  ViewModelLocator.RegisterDependencies(false);

                //var container = AppContainer.Container;

#if TRACE

                SingleSplashApp.stopWatch.Stop();
                System.Diagnostics.Trace.WriteLine($"\n ---------------------------MainActivity -OnCreate---------AFTER container INIT:  {SingleSplashApp.stopWatch.Elapsed.TotalSeconds}");

                SingleSplashApp.stopWatch.Start();

#endif


                IResolver autofacResolver = new AutofacResolver(container);
                Resolver.SetResolver(autofacResolver);


                //init interstitial ad by leadbolt
                string LeadBoltInterStitial_API_KEY = "XXXXXXXXXXXXXXXXXXXXXXXXXX";
                //                InterStitial_Android_LeadBolt.Get_ServiceInstance().Init_InterStitial(LeadBoltInterStitial_API_KEY, this);


                //init interstitial ad by AdMob 
                string Admob_Interstit_Ad_UnitID =
                    "ca-app-pub-XXXXXXXXXXXXXXXXXXXXXXXX"; 
                //InterStitial_Android_AdMob.Get_ServiceInstance().Init_InterStitial(Admob_Interstit_Ad_UnitID, this);

                //await Task.Delay(500); // Slow Init Code
                Thread.Sleep(500);      //  3

                //init interstitial ad by Facebook
                string Fb_PlacementID = "XXXXXXXXXXXXXXXXXXXXXXXXXX";
                //InterStitial_Android_Facebook.Get_ServiceInstance().Init_InterStitial(Fb_PlacementID, this);

                //await Task.Delay(500); // Slow Init Code
                Thread.Sleep(500);  //  4

                //init interstitial ad Mock
                //                string Stam_PlacementID = "XXXXXXXXXXXXXXXXXXXXXXXXXXXX";
                //                                InterStitial_Android_Mock.Get_ServiceInstance().Init_InterStitial("Stam");







#if TRACE

                SingleSplashApp.stopWatch.Stop();
                System.Diagnostics.Trace.WriteLine($"\n ---------------------------MainActivity -AFTER Packages init (userdialogs, Insights etc--------:  {SingleSplashApp.stopWatch.Elapsed.TotalSeconds}");
                System.Diagnostics.Trace.WriteLine($"\n ---------------------------Reach BEFORE LoadApplication( SingleSplashApp.......  ");
                SingleSplashApp.stopWatch.Start();

#endif




                LoadApplication(new SingleSplashApp());



#if TRACE
                SingleSplashApp.stopWatch.Stop();
                System.Diagnostics.Trace.WriteLine($"\n ---------------------------Reach After LoadApplication( SingleSplashApp)...... {SingleSplashApp.stopWatch.Elapsed.TotalSeconds}");
                SingleSplashApp.stopWatch.Start();
#endif


            }
            catch (Exception ex)
            {
                Insights.Report(ex, Insights.Severity.Error);
                //TrackService.Track_App_Exception(String.Format("GA Exception Message: \n {0} \n GA Exception StackTrace: \n {1}", ex.Message, ex.StackTrace), false);


            }
        }

        protected override void OnResume()
        {
            base.OnResume();

#if TRACE
            SingleSplashApp.stopWatch.Stop();
            System.Diagnostics.Trace.WriteLine($"\n ---------------------------MainActivity - OnResume ...... {SingleSplashApp.stopWatch.Elapsed.TotalSeconds}");
            SingleSplashApp.stopWatch.Start();
#endif


        }
    }
}

