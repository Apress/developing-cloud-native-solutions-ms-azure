using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;

namespace Speech2Text
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnConvert_Click(object sender, EventArgs e)
        {
            string key = "d37c267db84740969a379614abfc7edd";
            string region = "eastus";

            var speechCfg = SpeechConfig.FromSubscription(key, region);
            speechCfg.SpeechRecognitionLanguage = "en-US";

            using var audioToConvert = AudioConfig.FromWavFileInput(txtWMVFile.Text);
            using var speechCoversionOutput = new SpeechRecognizer(speechCfg, audioToConvert);
            var speechConversionResult = await speechCoversionOutput.RecognizeOnceAsync();

            lblOutput.Text = lblOutput.Text + " " + speechConversionResult.Text;
        }
       
    }
}