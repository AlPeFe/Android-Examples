using Android.App;
using Android.Widget;
using Android.OS;
using Android.Speech.Tts;
using Android.Runtime;
using System;
using Android.Speech;
using Android.Content;

namespace SpeechTest
{
    [Activity(Label = "SpeechTest", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity, TextToSpeech.IOnInitListener
    {
        TextToSpeech _speak;
        Button _button;
        Button _hablar;
        

        public void OnInit([GeneratedEnum] OperationResult status)
        {
            if (status == OperationResult.Error)
                _speak.SetLanguage(Java.Util.Locale.Default);

            if (status == OperationResult.Success)
                _speak.SetLanguage(Java.Util.Locale.Default);
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

   
            SetContentView (Resource.Layout.Main);

            _button = FindViewById<Button>(Resource.Id.button1);
            _hablar = FindViewById<Button>(Resource.Id.button2);

            _hablar.Click += delegate { GetSpeech(); };

            _button.Click += delegate
            {
                _speak.Speak("text", QueueMode.Flush, null);

            };

            _speak = new TextToSpeech(this, this, "com.google.android.tts");
            _speak.SetLanguage(Java.Util.Locale.Default);

            _speak.SetPitch(.5f);
            _speak.SetSpeechRate(.5f);



           
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {

            if(requestCode == 10)
            {
                if(resultCode == Result.Ok)
                {
                    var matches = data.GetStringArrayListExtra(RecognizerIntent.ExtraResults);

                    if(matches.Count != 0)
                    {
                        var input = matches[0];

                    }

                }

            }


            base.OnActivityResult(requestCode, resultCode, data);
        }


        private void GetSpeech()
        {

            var voiceIntent = new Intent(RecognizerIntent.ActionRecognizeSpeech);

            voiceIntent.PutExtra(RecognizerIntent.ExtraLanguageModel, RecognizerIntent.LanguageModelFreeForm);
            voiceIntent.PutExtra(RecognizerIntent.ExtraSpeechInputCompleteSilenceLengthMillis, 1500);
            voiceIntent.PutExtra(RecognizerIntent.ExtraSpeechInputMinimumLengthMillis, 15000);
            voiceIntent.PutExtra(RecognizerIntent.ExtraMaxResults, 1);


            voiceIntent.PutExtra(RecognizerIntent.ExtraLanguage, Java.Util.Locale.Default);
            StartActivityForResult(voiceIntent, 10);
        }

    }
}

