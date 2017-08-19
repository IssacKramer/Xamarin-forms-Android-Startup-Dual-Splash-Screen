using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using DualSplash.Android.Ioc.Locator;
using DualSplash.Core;
using DualSplash.Core.Ioc;
using Xamarin;
using Xamarin.Forms;
using XLabs.Ioc;
using XLabs.Ioc.Autofac;
using Application = Android.App.Application;

namespace DualSplash.Android
{
    [Activity(Label = "@string/ApplicationTitle",
        Icon = "@drawable/icon",
        Theme = "@style/splashscreen",
        MainLauncher = true,
        ScreenOrientation = ScreenOrientation.SensorPortrait,
        LaunchMode = LaunchMode.SingleTop,
        NoHistory = true,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    [Preserve(AllMembers = true)]
    public class SplashActivity : AppCompatActivity

    {

        public static bool IsInitialized = false;

        static readonly string TAG = "X:" + typeof(SplashActivity).Name;
        public IResolver AutofacResolver;


        public SplashActivity()
        {
#if TRACE
            


            DualSplashApp.stopWatch = new Stopwatch();
            System.Diagnostics.Trace.WriteLine($"\n ---------------------------------------------------------------------------------" +
                                               $"\n ---------------------------------------------------------------------------------");
            System.Diagnostics.Trace.WriteLine($"\n ---------------------------Starting SplashActivity Constructor:  {DualSplashApp.stopWatch.Elapsed.TotalSeconds}");
            DualSplashApp.stopWatch.Start();
#endif
        }

        protected override void OnCreate(Bundle savedInstanceState)// ,PersistableBundle persistantState)
        {

#if TRACE
            DualSplashApp.stopWatch.Stop();
            System.Diagnostics.Trace.WriteLine($"\n ---------------------------SplashActivity Starting From  OnCreate:  {DualSplashApp.stopWatch.Elapsed.TotalSeconds}");
            DualSplashApp.stopWatch.Start();
#endif

            base.OnCreate(savedInstanceState);    //,persistantState);
            System.Diagnostics.Debug.WriteLine(TAG, "SplashActivity.OnCreate");


            //init Xamarin Forms
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            //Activating UserDialogs
            Acr.UserDialogs.UserDialogs.Init((Activity)Forms.Context);
            
            // Slow Init Code only needed at start -- moved to MainActivity on final tweak
            if (!IsInitialized)
            {
                //await Task.Delay(500); // slow analytics init
//                Thread.Sleep(500); // 1

                

            }
            IsInitialized = true;



#if TRACE
            DualSplashApp.stopWatch.Stop();
            System.Diagnostics.Trace.WriteLine($"\n ---------------------------SplashActivity  OnCreate AFTER FORMS.init and UserDialogs.Init :  {DualSplashApp.stopWatch.Elapsed.TotalSeconds}");
            DualSplashApp.stopWatch.Start();
#endif


        }



        // Launches the startup task
        protected override void OnResume()
        {
            base.OnResume();
            Task startupWork = new Task(() => { SimulateStartup(); });

#if TRACE
            DualSplashApp.stopWatch.Stop();
            System.Diagnostics.Trace.WriteLine($"\n ---------------------------SplashActivity  OnResume  Before UserDialogs.ShowLoading :  {DualSplashApp.stopWatch.Elapsed.TotalSeconds}");
            DualSplashApp.stopWatch.Start();
#endif
            Acr.UserDialogs.UserDialogs.Instance.ShowLoading();
            startupWork.Start();
        }

        // Simulates background work that happens behind the splash screen
         void SimulateStartup()
        {
#if TRACE
            DualSplashApp.stopWatch.Stop();
            System.Diagnostics.Trace.WriteLine($"\n ---------------------------SplashActivity  SimulateStartup Before Slow Init Code :  {DualSplashApp.stopWatch.Elapsed.TotalSeconds}");
            DualSplashApp.stopWatch.Start();
#endif
            System.Diagnostics.Debug.WriteLine(TAG, "Performing some startup work that takes a bit of time.");
            //            await Task.Delay(1000); // Simulate a bit of startup work.

            //Starting all kind of  Initialization methods that make delays
            //init AutoFac container for DI
            if(AppContainer.Container==null)
            AppContainer.Container = ViewModelLocator.RegisterDependencies(false);


            //for XLabs Init
            if (AutofacResolver == null)
                AutofacResolver = new AutofacResolver(AppContainer.Container);
            if (!Resolver.IsSet)
                Resolver.SetResolver(AutofacResolver);

            //init Google Analytics for mobile
            //GATracking_Android.GetGASInstance()
            //     .Initialize_NativeGAS("Stam", this); //"UA-XXXXXXXXX-X", this); //TrackingID first parameter

            //init Insights -- moved to MainActivity on Final tweak
//            if (bundle == null && !Insights.IsInitialized)
/*            if (!Insights.IsInitialized)
            {
                Xamarin.Insights.Initialize("AppID",
                    ApplicationContext); //"b7015d6e120008cb54e81254b603f354855b059b", ApplicationContext);
                //Insights.Initialize("apikey", ApplicationContext);
                Insights.DisableCollection = false;
                Insights.DisableDataTransmission = false;
                Insights.DisableExceptionCatching = false;
            }

*/
            //Init Code for Ads of Admob , Facebook , Leadbolt etc.
            //init interstitial ad by leadbolt
            string LeadBoltInterStitial_API_KEY = "XXXXXXXXXXXXXXXXXXXXXXXXXX";
            //                InterStitial_Android_LeadBolt.Get_ServiceInstance().Init_InterStitial(LeadBoltInterStitial_API_KEY, this);


            //init interstitial ad by AdMob 
            string Admob_Interstit_Ad_UnitID =
                "ca-app-pub-XXXXXXXXXXXXXXXXXXXXXXXX";
            //InterStitial_Android_AdMob.Get_ServiceInstance().Init_InterStitial(Admob_Interstit_Ad_UnitID, this);

            

            //init interstitial ad by Facebook
            string Fb_PlacementID = "XXXXXXXXXXXXXXXXXXXXXXXXXX";
            //InterStitial_Android_Facebook.Get_ServiceInstance().Init_InterStitial(Fb_PlacementID, this);


            //init interstitial ad Mock
            //                string Stam_PlacementID = "XXXXXXXXXXXXXXXXXXXXXXXXXXXX";
            //                                InterStitial_Android_Mock.Get_ServiceInstance().Init_InterStitial("Stam");




            System.Diagnostics.Debug.WriteLine(TAG, "Startup work is finished - starting MainActivity.");
#if TRACE
            DualSplashApp.stopWatch.Stop();
            System.Diagnostics.Trace.WriteLine($"\n ---------------------------SplashActivity  SimulateStartup AFTER Slow Init Code :  {DualSplashApp.stopWatch.Elapsed.TotalSeconds}");
            System.Diagnostics.Trace.WriteLine($"\n --------------------------- BEFORE StartActivity MainActivity :  {DualSplashApp.stopWatch.Elapsed.TotalSeconds}");
            DualSplashApp.stopWatch.Start();
#endif


            StartActivity(new Intent(Application.Context, typeof(MainActivity)));
            Finish();
        }

        protected override void OnPause()
        {
            base.OnPause();
            Acr.UserDialogs.UserDialogs.Instance.HideLoading();
        }
    }
}