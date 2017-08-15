using Android.App;
using Android.Widget;
using Android.OS;
using System.Diagnostics;
using DualSplash.Core;

namespace SingleSplash.Android
{
    [Activity(Label = "SingleSplash.Android", MainLauncher = false , 
        Icon = "@drawable/icon",
         Theme = "@style/MainTheme"
        )]
    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]
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

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

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
                System.Diagnostics.Trace.WriteLine($"\n ---------------------------Reach BEFORE LoadApplication( SingleSplashApp.......  ");
                SingleSplashApp.stopWatch.Start();

#endif


                LoadApplication(new SingleSplashApp());


#if TRACE
                //SingleSplashApp.stopWatch.Stop();
                System.Diagnostics.Trace.WriteLine($"\n ---------------------------Reach After LoadApplication( SingleSplashApp....... {SingleSplashApp.stopWatch.Elapsed.TotalSeconds} ");
#endif



            }
            catch (System.Exception ex)
            {

                throw;
            }


            // Set our view from the "main" layout resource
            // SetContentView (Resource.Layout.Main);
        }
    }
}

